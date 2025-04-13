using MindSweeperClasses;
using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Threading.Timer;
using System.IO;
using Newtonsoft.Json;

namespace MineSweeperGUI
{
    public partial class Frm_MineSweeper : Form
    {
        Board GameBoard;
        Button[,] buttons;
        int cellSize = 70;
        private Image[] numberTiles;

        private bool awaitingDetectorTarget = false;
        private bool awaitingRadarTarget = false;

        public Frm_MineSweeper(int size, float bombDensity, string difficultyType)
        {

            GameBoard = new Board(size, bombDensity, difficultyType);
            InitializeComponent();

            GameBoard.FeedbackHandler = message => MessageBox.Show(message);

            LoadTiles();

            int panelSize = size * cellSize;
            pnl_Main.Width = panelSize;
            pnl_Main.Height = panelSize;

            this.Width = panelSize + 370;
            this.Height = panelSize + 420;

            SetupButtons();
            GameBoard.SetupBombs();

            GameBoard.SetupRewards();
            GameBoard.CountBombNearby(); // Calculate neighboring bomb counts

            lbl_DetectorCount.Text = $"{GameBoard.DetectorOwned} / {GameBoard.DetectorFound} / {GameBoard.TotalDetectors}";
            lbl_RadarCount.Text = $"{GameBoard.RadarOwned} / {GameBoard.RadarFound} / {GameBoard.TotalRadar}";

            difficultyType = GameBoard.DifficultyType;

            btn_UseDetector.Enabled = false;
            btn_UseDetector.BackColor = Color.LightGray;
            btn_UseRadar.Enabled = false;
            btn_UseRadar.BackColor = Color.LightGray;
        }


        public Frm_MineSweeper(Board savedBoard)
        {
            InitializeComponent();
            LoadTiles();

            GameBoard = savedBoard;

            SetupButtons();
            UpdateButtonFaces(GameBoard);

            gameTimer.Start();

            lbl_numOfBombs.Text = GameBoard.GetBombCount().ToString();
            lbl_DetectorCount.Text = $"{GameBoard.DetectorOwned} / {GameBoard.DetectorFound} / {GameBoard.TotalDetectors}";
            lbl_RadarCount.Text = $"{GameBoard.RadarOwned} / {GameBoard.RadarFound} / {GameBoard.TotalRadar}";

        }

        private void SetupButtons()
        {
            int buttonSize = cellSize;
            buttons = new Button[GameBoard.Size, GameBoard.Size];

            for (int row = 0; row < GameBoard.Size; row++)
            {
                for (int col = 0; col < GameBoard.Size; col++)
                {
                    buttons[row, col] = new Button
                    {
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0 },
                        ImageAlign = ContentAlignment.MiddleCenter,
                        Width = buttonSize,
                        Height = buttonSize,
                        Left = col * buttonSize,
                        Top = row * buttonSize,
                        BackColor = Color.LightGray,
                        Tag = new Point(row, col),
                        Image = numberTiles[9]
                    };

                    // Left-click to reveal the cell
                    buttons[row, col].Click += GridButton_Click;

                    // Right-click to flag the cell
                    buttons[row, col].MouseDown += GridButton_MouseDown;

                    pnl_Main.Controls.Add(buttons[row, col]);
                }
            }
        }

        private void GridButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                Point p = (Point)b.Tag;
                int row = p.X;
                int col = p.Y;

                var cell = GameBoard.Cells[row, col];

                if (!cell.IsVisited)
                {
                    // Toggle the flag state
                    cell.IsFlagged = !cell.IsFlagged;

                    // Visually update the button immediately
                    UpdateButtonFaces(GameBoard);
                }
            }
        }


        private void GridButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Point p = (Point)b.Tag;
            int row = p.X;
            int col = p.Y;
            var cell = GameBoard.Cells[row, col];

            // --- Handle Detector Reward Mode ---
            if (awaitingDetectorTarget)
            {
                awaitingDetectorTarget = false;

                if (GameBoard.UseDetectorReward(cell))
                {
                    UpdateButtonFaces(GameBoard);
                    lbl_DetectorCount.Text = $"{GameBoard.DetectorOwned} / {GameBoard.DetectorFound} / {GameBoard.TotalDetectors}";

                    // Disable button if no more detectors
                    if (GameBoard.DetectorOwned == 0)
                    {
                        btn_UseDetector.Enabled = false;
                        btn_UseDetector.BackColor = Color.LightGray;
                    }
                }

                return; // skip regular cell reveal
            }

            // --- Handle Radar Reward Mode ---
            if (awaitingRadarTarget)
            {
                awaitingRadarTarget = false;

                if (GameBoard.UseRadarReward(cell))
                {
                    UpdateButtonFaces(GameBoard);
                    lbl_RadarCount.Text = $"{GameBoard.RadarOwned} / {GameBoard.RadarFound} / {GameBoard.TotalRadar}";

                    if (GameBoard.RadarOwned == 0)
                    {
                        btn_UseRadar.Enabled = false;
                        btn_UseRadar.BackColor = Color.LightGray;
                    }
                }

                return;
            }

            // Reveal the cell
            RevealCell(row, col);

            // Update the board display after clicking
            UpdateButtonFaces(GameBoard);

            // Check for win/loss conditions
            if (GameBoard.DetermineGameState() == Board.GameStatus.Won)
            {
                gameTimer.Stop();
                int finalScore = GameBoard.DetermineFinalScore(Board.GameStatus.Won);

                Frm_GetPlayerName frm_GetPlayerName = new Frm_GetPlayerName(finalScore);
                frm_GetPlayerName.ShowDialog();

                RevealAllCells();
            }
            else if (GameBoard.Cells[row, col].IsBomb)
            {
                gameTimer.Stop();
                int finalScore = GameBoard.DetermineFinalScore(Board.GameStatus.Lost);

                MessageBox.Show($"Game Over! You hit a bomb! Final Score: {finalScore}");

                RevealAllCells();
            }
        }

        private void RevealCell(int row, int col, bool isFloodFill = false)
        {
            if (!gameTimer.Enabled)
            {
                StartGameTimer();
            }

            if (!GameBoard.IsCellOnBoard(row, col) || GameBoard.Cells[row, col].IsVisited) return;

            if (GameBoard.Cells[row, col].IsFlagged) return;

            var cell = GameBoard.Cells[row, col];

            if (cell.Reward == Cell.RewardType.Detector && isFloodFill)
            {
                MessageBox.Show("Detector reward found but not collected.");
                GameBoard.DetectorFound++;
                cell.FloodFilled = true;
                lbl_DetectorCount.Text = $"{GameBoard.DetectorOwned} / {GameBoard.DetectorFound} / {GameBoard.TotalDetectors}";
            }
            else if (cell.Reward == Cell.RewardType.Detector)
            {
                GameBoard.DetectorOwned++;
                GameBoard.DetectorFound++;
                btn_UseDetector.Enabled = true;
                btn_UseDetector.BackColor = Color.Gold;
                lbl_DetectorCount.Text = $"{GameBoard.DetectorOwned} / {GameBoard.DetectorFound} / {GameBoard.TotalDetectors}";
            }

            if (cell.Reward == Cell.RewardType.Radar && isFloodFill)
            {
                MessageBox.Show("Radar reward found but not collected.");
                GameBoard.RadarFound++;
                cell.FloodFilled = true;
                lbl_RadarCount.Text = $"{GameBoard.RadarOwned} / {GameBoard.RadarFound} / {GameBoard.TotalRadar}";
            }
            else if (cell.Reward == Cell.RewardType.Radar)
            {
                GameBoard.RadarOwned++;
                GameBoard.RadarFound++;
                btn_UseRadar.Enabled = true;
                btn_UseRadar.BackColor = Color.Gold;
                lbl_RadarCount.Text = $"{GameBoard.RadarOwned} / {GameBoard.RadarFound} / {GameBoard.TotalRadar}";
            }

            // Mark as visited
            cell.IsVisited = true;

            // Bomb check
            if (cell.IsBomb && !cell.IsDeactivated)
            {
                GameBoard.DetermineGameState();
                MessageBox.Show("Boom! You hit a bomb! Game Over.");
                RevealAllCells();
                return;
            }

            // Normal cell logic
            if (cell.NumberOfBombNeighbors == 0)
            {
                FloodFill(row, col);
            }

            UpdateButtonFaces(GameBoard);
        }


        private void StartGameTimer()
        {
            startTime = DateTime.Now;
            gameTimer.Start();
        }

        private void FloodFill(int row, int col)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int newRow = row + i;
                    int newCol = col + j;

                    if (GameBoard.IsCellOnBoard(newRow, newCol) &&
                        !GameBoard.Cells[newRow, newCol].IsVisited &&
                        !GameBoard.Cells[newRow, newCol].IsFlagged)
                    {
                        GameBoard.Cells[newRow, newCol].FloodFilled = true;
                        RevealCell(newRow, newCol, isFloodFill: true);
                    }
                }
            }
        }

        private void UpdateButtonFaces(Board myBoard)
        {
            lbl_numOfBombs.Text = myBoard.GetBombCount().ToString();

            for (int row = 0; row < myBoard.Size; row++)
            {
                for (int col = 0; col < myBoard.Size; col++)
                {
                    var cell = myBoard.Cells[row, col];

                    if (cell.IsFlagged)
                    {
                        buttons[row, col].Image = numberTiles[10]; // Flag
                    }
                    else if (cell.IsVisited)
                    {
                        if (cell.IsBomb && !cell.IsDeactivated)
                        {
                            buttons[row, col].Image = numberTiles[7]; // Bomb
                        }
                        else if (cell.IsDeactivated)
                        {
                            buttons[row, col].Image = numberTiles[13]; // Bomb detected
                        }
                        else if (cell.Reward == Cell.RewardType.Detector && cell.FloodFilled)
                        {
                            buttons[row, col].Image = numberTiles[11]; // FF Detector
                        }
                        else if (cell.Reward == Cell.RewardType.Radar && cell.FloodFilled)
                        {
                            buttons[row, col].Image = numberTiles[12]; // FF Radar
                        }
                        else if (cell.Reward == Cell.RewardType.Detector && !cell.FloodFilled)
                        {
                            buttons[row, col].Image = numberTiles[8]; // Detector clicked
                        }
                        else if (cell.Reward == Cell.RewardType.Radar && !cell.FloodFilled)
                        {
                            buttons[row, col].Image = numberTiles[6]; // Radar clicked
                        }
                        else if (cell.NumberOfBombNeighbors > 0)
                        {
                            buttons[row, col].Image = numberTiles[cell.NumberOfBombNeighbors];
                        }
                        else
                        {
                            buttons[row, col].Image = numberTiles[0]; // Blank
                        }
                    }
                    else
                    {
                        buttons[row, col].Image = numberTiles[9]; // Covered tile
                    }
                }
            }
        }

        private void RevealAllCells()
        {
            for (int row = 0; row < GameBoard.Size; row++)
            {
                for (int col = 0; col < GameBoard.Size; col++)
                {
                    if (GameBoard.Cells[row, col].IsBomb)
                    {
                        buttons[row, col].Image = numberTiles[7];
                    }
                    else if (GameBoard.Cells[row, col].Reward == Cell.RewardType.Detector)
                    {
                        buttons[row, col].Image = numberTiles[8];
                    }
                    else if (GameBoard.Cells[row, col].Reward == Cell.RewardType.Radar)
                    {
                        buttons[row, col].Image = numberTiles[6];
                    }
                    else
                    {
                        buttons[row, col].Image = GameBoard.Cells[row, col].NumberOfBombNeighbors > 0
                            ? numberTiles[GameBoard.Cells[row, col].NumberOfBombNeighbors]
                            : numberTiles[0];
                    }
                }
            }
        }

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            gameTimer.Stop(); // Stop existing timer
            lbl_Timer.Text = "00:00"; // Reset the timer display
            this.Close();
            Frm_StartGame startGame = new Frm_StartGame();
            startGame.Show();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            lbl_Timer.Text = $"{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadTiles()
        {

            numberTiles = new Image[14];
            numberTiles[0] = Image.FromFile("../Tiles/empty.bmp");
            numberTiles[1] = Image.FromFile("../Tiles/1.bmp");
            numberTiles[2] = Image.FromFile("../Tiles/2.bmp");
            numberTiles[3] = Image.FromFile("../Tiles/3.bmp");
            numberTiles[4] = Image.FromFile("../Tiles/4.bmp");
            numberTiles[5] = Image.FromFile("../Tiles/5.bmp");
            numberTiles[6] = Image.FromFile("../Tiles/radar.bmp");
            numberTiles[7] = Image.FromFile("../Tiles/bomb.bmp");
            numberTiles[8] = Image.FromFile("../Tiles/Detector.bmp");
            numberTiles[9] = Image.FromFile("../Tiles/Tiles.bmp");
            numberTiles[10] = Image.FromFile("../Tiles/flag.bmp");
            numberTiles[11] = Image.FromFile("../Tiles/FF-Detector.bmp");
            numberTiles[12] = Image.FromFile("../Tiles/FF-Radar.bmp");
            numberTiles[13] = Image.FromFile("../Tiles/Bomb-detected.bmp");
        }

        private void btn_UseDetector_Click(object sender, EventArgs e)
        {
            if (GameBoard.DetectorOwned > 0)
            {
                awaitingDetectorTarget = true;
                MessageBox.Show("Click a cell to scan with your Detector.");
            }
        }

        private void btn_UseRadar_Click(object sender, EventArgs e)
        {
            if (GameBoard.RadarOwned > 0)
            {
                awaitingRadarTarget = true;
                MessageBox.Show("Click a cell to activate Radar and reveal surrounding cells.");
            }
        }

        private void SaveGame_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JSON files|*.json";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                GameState.SaveGame(GameBoard, saveDialog.FileName);
            }
        }
        private void LoadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "JSON files|*.json";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                GameBoard = GameState.LoadGame(openDialog.FileName);

                // You may need to call SetupButtons() again or UpdateButtonFaces()
                UpdateButtonFaces(GameBoard);

                // Also rebind your reward counters:
                lbl_DetectorCount.Text = $"{GameBoard.DetectorOwned} / {GameBoard.DetectorFound} / {GameBoard.TotalDetectors}";
                lbl_RadarCount.Text = $"{GameBoard.RadarOwned} / {GameBoard.RadarFound} / {GameBoard.TotalRadar}";
            }
        }
    }
}

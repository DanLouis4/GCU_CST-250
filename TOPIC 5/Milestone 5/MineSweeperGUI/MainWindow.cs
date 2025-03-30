using MindSweeperClasses;
using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace MineSweeperGUI
{
    public partial class Frm_MineSweeper : Form
    {
        Board GameBoard;
        Button[,] buttons;
        int cellSize = 70;
        private Image[] numberTiles;

        public Frm_MineSweeper(int size, float bombDensity)
        {

            GameBoard = new Board(size, bombDensity);
            InitializeComponent();

            GameBoard.FeedbackHandler = message => MessageBox.Show(message);

            LoadTiles();

            int panelSize = size * cellSize;
            pnl_Main.Width = panelSize;
            pnl_Main.Height = panelSize;

            this.Width = panelSize + 370;
            this.Height = panelSize + 210;

            SetupButtons();
            GameBoard.SetupBombs();

            GameBoard.SetupRewards();
            GameBoard.CountBombNearby(); // Calculate neighboring bomb counts
            lbl_rewardCount.Text = GameBoard.RewardsOwned.ToString() + " / " + GameBoard.RewardsFound.ToString() + " / " + GameBoard.TotalRewards.ToString();
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
                        Image = numberTiles[8]
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

                // Allow flagging only if the cell has NOT been revealed
                if (!GameBoard.Cells[row, col].IsVisited || GameBoard.Cells[row, col].IsFlagged)
                {
                    GameBoard.Cells[row, col].IsFlagged = !GameBoard.Cells[row, col].IsFlagged;
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


            // Reveal the cell
            RevealCell(row, col);

            // Update the board display after clicking
            UpdateButtonFaces(GameBoard);

            // Check for win/loss conditions
            if (GameBoard.DetermineGameState() == Board.GameStatus.Won)
            {
                gameTimer.Stop();
                int finalScore = GameBoard.DetermineFinalScore(Board.GameStatus.Won);

                lbl_Points.Text = finalScore.ToString();

                Frm_GetPlayerName frm_GetPlayerName = new Frm_GetPlayerName(finalScore);
                frm_GetPlayerName.ShowDialog();                

                RevealAllCells();
            }
            else if (GameBoard.Cells[row, col].IsBomb)
            {
                gameTimer.Stop();
                int finalScore = GameBoard.DetermineFinalScore(Board.GameStatus.Lost);

                lbl_Points.Text = finalScore.ToString();
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

            if (GameBoard.RewardsOwned > 0 && !isFloodFill)
            {
                DialogResult result = MessageBox.Show("Do you want to use the special reward?", "Use Reward", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    GameBoard.UseSpecialBonus(GameBoard.Cells[row, col]);
                    lbl_rewardCount.Text = GameBoard.RewardsOwned.ToString() + " / " + GameBoard.RewardsFound.ToString() + " / " + GameBoard.TotalRewards.ToString();
                }
            }

            GameBoard.Cells[row, col].IsVisited = true;

            if (GameBoard.Cells[row, col].IsBomb && !GameBoard.Cells[row, col].IsDeactivated)
            {
                GameBoard.DetermineGameState();
                MessageBox.Show("Boom! You hit a bomb! Game Over.");
                RevealAllCells();
                return;
            }

            else if (GameBoard.Cells[row, col].HasSpecialReward && !isFloodFill)
            {
                MessageBox.Show("You found a special reward!");
                GameBoard.RewardsFound++;
                GameBoard.RewardsOwned++;
                lbl_rewardCount.Text = GameBoard.RewardsOwned.ToString() + " / " + GameBoard.RewardsFound.ToString() + " / " + GameBoard.TotalRewards.ToString();
                GameBoard.Cells[row, col].IsVisited = true;
            }
            else if (GameBoard.Cells[row, col].HasSpecialReward && isFloodFill)
            {
                MessageBox.Show("Special reward found cannot be uncollected!");
                GameBoard.RewardsFound++;
                lbl_rewardCount.Text = GameBoard.RewardsOwned.ToString() + " / " + GameBoard.RewardsFound.ToString() + " / " + GameBoard.TotalRewards.ToString();
                GameBoard.Cells[row, col].IsVisited = true;
            }

            else if (GameBoard.Cells[row, col].NumberOfBombNeighbors > 0 && !isFloodFill)
            {
                GameBoard.Cells[row, col].IsVisited = true;
            }

            else if (GameBoard.Cells[row, col].NumberOfBombNeighbors == 0)
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
                    if (myBoard.Cells[row, col].IsFlagged)
                    {
                        buttons[row, col].Text = "F";
                        buttons[row, col].ForeColor = Color.Yellow;
                    }
                    else if (myBoard.Cells[row, col].IsVisited)
                    {
                        if (myBoard.Cells[row, col].IsBomb)
                        {
                            buttons[row, col].Image = numberTiles[7];
                        }
                        else if (myBoard.Cells[row, col].HasSpecialReward)
                        {
                            buttons[row, col].Image = numberTiles[6];
                        }
                        else if (myBoard.Cells[row, col].NumberOfBombNeighbors > 0)
                        {
                            buttons[row, col].Image = numberTiles[myBoard.Cells[row, col].NumberOfBombNeighbors];
                        }
                        else
                        {
                            buttons[row, col].Image = numberTiles[0];
                        }
                    }
                    else
                    {
                        buttons[row, col].Image = numberTiles[8];
                        buttons[row, col].BackColor = Color.Gray;
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
                        buttons[row, col].BackColor = Color.Red;
                    }
                    else if (GameBoard.Cells[row, col].HasSpecialReward)
                    {
                        buttons[row, col].Image = numberTiles[6];
                        buttons[row, col].BackColor = Color.Gold;
                    }
                    else
                    {
                        buttons[row, col].Image = GameBoard.Cells[row, col].NumberOfBombNeighbors > 0
                            ? numberTiles[GameBoard.Cells[row, col].NumberOfBombNeighbors]
                            : numberTiles[0];
                        buttons[row, col].BackColor = Color.LightGray;
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

            numberTiles = new Image[10];
            numberTiles[0] = Image.FromFile("../Tiles/Tile Flat.png");
            numberTiles[1] = Image.FromFile("../Tiles/Number 1.png");
            numberTiles[2] = Image.FromFile("../Tiles/Number 2.png");
            numberTiles[3] = Image.FromFile("../Tiles/Number 3.png");
            numberTiles[4] = Image.FromFile("../Tiles/Number 4.png");
            numberTiles[5] = Image.FromFile("../Tiles/Number 5.png");
            numberTiles[6] = Image.FromFile("../Tiles/Gold.png");
            numberTiles[7] = Image.FromFile("../Tiles/Skull.png");
            numberTiles[8] = Image.FromFile("../Tiles/Tile 1.png");
            numberTiles[9] = Image.FromFile("../Tiles/Tile 2.png");


        }
    }
}

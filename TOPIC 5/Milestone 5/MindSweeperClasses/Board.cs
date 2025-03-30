namespace MindSweeperClasses
{
    public class Board
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewardsOwned { get; set; }
        public int RewardsFound { get; set; }
        public int TotalRewards { get; private set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BombCount { get; set; }
        public enum GameStatus { InProgress, Won, Lost }

        Random random = new Random();

        public Board(int size, float difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size]; // Creates the array

            // This loop initializes each Cell in the 2D array
            for (int row = 0; row < Size; row++) // Iterates through each row
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col] = new Cell(row, col); // Instantiates each Cell object
                }
            }
        }

        // Used during setup to place bombs on the board
        public void SetupBombs()
        {
            int bombsOnBoard = (int)(Size * Size * Difficulty);
            BombCount = 0;

            while (BombCount < bombsOnBoard)
            {
                int row = random.Next(Size);
                int col = random.Next(Size);

                if (!Cells[row, col].IsBomb)
                {
                    Cells[row, col].IsBomb = true;
                    BombCount++;
                }
            }
        }

        // Retrieves the total number of bombs on the board.
        public int GetBombCount()
        {
            return BombCount;
        }

        // Used during setup to place rewards on the board
        public void SetupRewards()
        {
            int availableCells = (int)(Size * Size - BombCount);
            int maxRewards = availableCells / 20; // Example: to adjust based on available cells

            int rewardCount = 0;

            while (rewardCount < maxRewards)
            {
                int row = random.Next(Size);
                int col = random.Next(Size);

                if (!Cells[row, col].IsBomb && !Cells[row, col].HasSpecialReward)
                {
                    Cells[row, col].HasSpecialReward = true;
                    rewardCount++;
                }
            }

            TotalRewards = rewardCount; // Track total rewards
        }


        // Use during setup to calculate the number of bomb neighbors for each cell
        public void CountBombNearby()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col].NumberOfBombNeighbors = GetNumberOfBombNeighbors(row, col);
                }
            }
        }

        // Helper function to determine the number of bomb neighbors for a cell
        public int GetNumberOfBombNeighbors(int row, int col)
        {
            int bombCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newRow = row + i;
                    int newCol = col + j;
                    if (IsCellOnBoard(newRow, newCol) && Cells[newRow, newCol].IsBomb)
                    {
                        bombCount++;
                    }
                }
            }
            return bombCount;
        }

        // Helper function to determine if a cell is out of bounds
        public bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        // Used every turn to determine the current game state
        public GameStatus DetermineGameState()
        {
            foreach (var cell in Cells)
            {
                if (!cell.IsBomb && !cell.IsVisited)
                    return GameStatus.InProgress;
            }
            return GameStatus.Won;
        }

        // Used when the player selects a cell and chooses to play the reward
        public bool UseSpecialBonus(Cell cell)
        {
            bool rewardUsed = false;

            if (cell.IsBomb)
            {
                if (FeedbackHandler != null)
                {
                    FeedbackHandler("ALERT! Bomb Detected! Bomb Deactivated!");
                }
                else
                {
                    Console.WriteLine("ALERT! Bomb Detected! Bomb Deactivated!");
                }
                cell.IsVisited = true;
                cell.IsDeactivated = true;
                rewardUsed = true;
            }
            else
            {
                if (FeedbackHandler != null)
                {
                    FeedbackHandler("No Bomb Detected.");
                }
                else
                {
                    Console.WriteLine("No Bomb Detected.");
                }
                cell.IsVisited = true;
                rewardUsed = true;
            }

            RewardsOwned--;

            return rewardUsed;
        }

        public Action<string>? FeedbackHandler; // Event to handle feedback messages

        // Used after game is over to calculate final score
        public int DetermineFinalScore(GameStatus status)
        {
            int score = 0;

            //  Add 10 points for each revealed safe cell
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Cells[row, col].IsVisited && !Cells[row, col].IsBomb)
                    {
                        score += 10;
                    }
                }
            }

            //  Subtract 100 points if the player hit a bomb
            if (status == GameStatus.Lost)
            {
                score -= 100;
            }

            //  Add 1 point per unused reward
            score += RewardsOwned;

            //  Subtract 1 point for every second of playtime
            if (StartTime != default)
            {
                TimeSpan duration = DateTime.Now - StartTime;
                score -= (int)duration.TotalSeconds;
            }

            return Math.Max(score, 0); // Prevent negative scores
        }
    }
}

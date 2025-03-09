using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MindSweeperClasses
{
    public class Board
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewardsRemaining { get; set; }
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

           Console.WriteLine("Bomb detector activated!");

           if(cell.IsBomb)
            {
                Console.WriteLine("Bomb detected!");
                cell.IsVisited = true;
            }
            else
            {
                Console.WriteLine("No bomb detected.");
                cell.IsVisited = true;
            }
            
            RewardsRemaining--;

            return rewardUsed = true;
        }

        // Used after game is over to calculate final score
        public int DetermineFinalScore()
        {
            return 0; // Placeholder logic based chosen parameters
        }
    }
}

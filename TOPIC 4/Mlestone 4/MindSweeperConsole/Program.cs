using System.Threading.Tasks;
using MindSweeperClasses;

public class Program
{
    static void Main(string[] args)
    {

        bool victory = false;
        bool death = false;

        Console.WriteLine("\nHello, welcome to Minesweeper");


        /*
         * 
         * 1. Select Board Size
         * 
         */
        Console.WriteLine("\nPlease select your Board Size: ");
        Console.WriteLine("\nBoard Size: (10, 15, 20)");
        int boardSize = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int size))
            {
                if (size == 10 || size == 15 || size == 20)
                {
                    boardSize = size;
                    break; // Exit loop once a valid size is entered
                }
                else if (size < 10)
                {
                    Console.WriteLine($"Sorry, {size} is too small. Please enter 10, 15, or 20.");
                }
                else if (size > 20)
                {
                    Console.WriteLine($"Sorry, {size} is too big. Please enter 10, 15, or 20.");
                }
                else
                {
                    Console.WriteLine("Sorry, 10, 15, or 20 are the only available board sizes.");
                }
            }
            else
            {
                Console.WriteLine("That's not a number... Please enter a number (10, 15, or 20).");
            }
        }

        /* 
         * 
         * 2. Select Difficulty
         * 
         */
        float bombDensity = 0;
        Console.WriteLine("\nSelect Difficulty Level: ");
        Console.WriteLine("1 - Easy");
        Console.WriteLine("2 - Normal");
        Console.WriteLine("3 - Hard");

        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int difficulty))
            {
                if (difficulty == 1)
                {
                    bombDensity = 0.075f;
                    break;
                }
                else if (difficulty == 2)
                {
                    bombDensity = 0.10f;
                    break;
                }
                else if (difficulty == 3)
                {
                    bombDensity = 0.25f;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            }
        }

        /*
         * 
         * 3. Start Game
         * 
         */
        Board board = new Board(boardSize, bombDensity);
        Console.WriteLine("\n\nBoard Size: " + board.Size);

        if (board.Difficulty == 0.075f)
            Console.WriteLine("Difficulty: Easy");
        else if (board.Difficulty == 0.10f)
            Console.WriteLine("Difficulty: Normal");
        else if (board.Difficulty == 0.25f)
            Console.WriteLine("Difficulty: Hard");
        else
            Console.WriteLine("\nGood Luck!");

        board.SetupBombs();
        board.SetupRewards();
        board.CountBombNearby();
        // Show answers for Testing
        PrintAnswers(board);
        
        PrintBoard(board);
        
        /*
         * 
         * 4. Game Loop
         * 
         */
        while (!victory && !death)
        {
            // Setup row and column variables to store user input
            int row, col;
            int cellsFlagged = 0;

            /*
             *
             * 4a. Ask for row input
             * 
             */
            while (true)
            {
                Console.Write("\nSelect row: ");
                string rowInput = Console.ReadLine();

                if (int.TryParse(rowInput, out row) && board.IsCellOnBoard(row, 0))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid row. Please enter a valid row number.");
                }
            }

            /*
             * 
             * 4b. Ask for column input
             * 
             */
            while (true)
            {
                Console.Write("Select column: ");
                string colInput = Console.ReadLine();

                if (int.TryParse(colInput, out col) && board.IsCellOnBoard(0, col))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid column. Please enter a valid column number.");
                }
            }

            // setup cell variable to store cell coordinates
            Cell cell = board.Cells[row, col];

            /*
             * 
             * 4c. Check if cell is already visited or flagged
             * 
             */
            if (cell.IsVisited || cell.IsFlagged)
            {
                if (cell.IsVisited)
                {
                    Console.WriteLine("Cell already visited. Please select a different cell.");

                }
                else
                {
                    // This cell is flagged, ask if the user wants to unflag it
                    Console.WriteLine("This Cell is Flagged, Unflag it (y/n)?");
                    string unflagInput = Console.ReadLine().Trim();

                    // If the user wants to unflag the cell, unflag it
                    if (unflagInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        cell.IsFlagged = false;
                        cellsFlagged--;
                        Console.WriteLine("Cell unflagged.");

                        PrintBoard(board);
                    }

                    // If the user doesn't want to unflag the cell, ask them to select a different cell
                    else
                    {
                        Console.WriteLine("Please select a different cell.");
                    }
                }
                continue;
            }

            /*
             * 
             * 4d. Display for cell options
             * 
             */
            Console.WriteLine($"\nWhat would you like to do at Cell({row},{col}):");
            Console.WriteLine("1 - Show it");
            Console.WriteLine("2 - Flag it");

            // Only show the reward option if there are rewards remaining
            if (board.RewardsOwned > 0)
            {
                Console.WriteLine("3 - Use Reward");
            }

            // Get user input for action
            string actionInput = Console.ReadLine().Trim();

            // Check if the input is a valid number
            if (int.TryParse(actionInput, out int action))
            {
                /*
                 * 
                 * 4d.1. Action 1: Show cell
                 * 
                 */
                if (action == 1)
                {
                    // If cell contain a bomb...
                    if (cell.IsBomb)
                    {
                        // mark it as visited
                        cell.IsVisited = true;

                        // Then, set the game state to lost
                        death = true;
                        cell.IsKillerBomb = true;

                        // Display game over message
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nBoom! You hit a bomb! Game Over.");
                        Console.ResetColor();

                        // Show the board with the bomb
                        PrintBoard(board);
                        

                        // Ask if the player wants to see the answers
                        Console.WriteLine("\nShow answers? (y/n)");
                        string answerInput = Console.ReadLine().Trim();

                        // If the player wants to see the answers, print them
                        if (answerInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            PrintAnswers(board);
                            Console.WriteLine("\nThanks for playing!");
                            Console.Write("Press any key to exit...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nThanks for playing!");
                            Console.Write("Press any key to exit...");
                            Console.ReadLine();
                        }
                    }

                    // If the cell is not a bomb...
                    else
                    {
                        // mark it as visited
                        cell.IsVisited = true;

                        // If the cell has is a reward...
                        if (cell.HasSpecialReward)
                        {
                            // display a message
                            Console.WriteLine("\nYou found a special reward!");

                            // add an usable reward to player options
                            board.RewardsOwned++;

                            // mark the cell as having a special reward
                            cell.HasSpecialReward = true;
                        }
                        else if (cell.NumberOfBombNeighbors == 0)
                        {
                            FloodFill(board, row, col);
                        }
                        PrintBoard(board);
                    }
                }

                /*
                 * 
                 * 4d.2. Action 2: Flag cell
                 * 
                 */
                else if (action == 2)
                {                    
                    cell.IsFlagged = true;
                    Console.WriteLine($"\nCell ({row},{col}) was flagged");

                    PrintBoard(board);                                                        
                }

                /*
                 * 
                 * 4d.3. Action 3: Use reward
                 * 
                 */
                else if (action == 3 && board.RewardsOwned > 0)
                {
                    Console.WriteLine("\nUsing special reward...");

                    cell.HasSpecialReward = board.UseSpecialBonus(cell);

                    PrintBoard(board);
                }

                // 4d.4. If the user enters an invalid action
                else
                {
                    Console.WriteLine("\nInvalid choice. Please select a valid option.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter 1, 2, or 3.");

                continue;
            }

            /*
             * 
             * 4e. Check game state after action
             * 
             */
            Board.GameStatus status = board.DetermineGameState();
            if (status == Board.GameStatus.Won)
            {
                victory = true;
                Console.WriteLine("\nCongratulations! You've won!");

            }
            else if (status == Board.GameStatus.Lost)
            {
                death = true;
                Console.WriteLine("\nGame over! Better luck next time.");
            }
        }
    }


    public static void FloodFill(Board board, int row, int col)
    {
        int[] rowOffsets = { -1, -1, 0, 1, 1, 1, 0, -1};
        int[] colOffsets = {  0,  1, 1, 1, 0,-1,-1, -1}; 

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + rowOffsets[i];
            int newCol = col + colOffsets[i];

            if (board.IsCellOnBoard(newRow, newCol) &&
                !board.Cells[newRow, newCol].IsVisited &&
                !board.Cells[newRow, newCol].IsFlagged &&
                !board.Cells[newRow, newCol].IsBomb)
            {
                board.Cells[newRow, newCol].IsVisited = true;
                board.Cells[newRow, newCol].FloodFilled = true;

                // If the revealed cell has a reward, increment RewardsFound
                if (board.Cells[newRow, newCol].HasSpecialReward)
                {
                    board.RewardsFound++;
                }
                PrintBoard(board);
                Thread.Sleep(750);
                Console.Clear();

                if (board.Cells[newRow, newCol].NumberOfBombNeighbors == 0)
                {
                    FloodFill(board, newRow, newCol);
                    Thread.Sleep(750);
                }
            }
        }
    }

    // Method to print game board
    public static void PrintBoard(Board board)
    {
        Console.WriteLine("\nTotal Bombs Remaining: " + board.GetBombCount());
        Console.WriteLine($"\nRewards: {board.RewardsOwned}/{board.RewardsFound}/{board.TotalRewards} (Owned/Found/Total)");


        // Column Numbers 
        Console.Write("\n   "); // Space for row numbers
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write(col.ToString().PadLeft(3) + " ");
        }
        Console.WriteLine();

        // Upper Corners
        Console.Write("   +"); // First upper corner
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("---+");  // upper right corners
        }

        // Move to first row
        Console.WriteLine();

        // Rows with Row # and Vertical Dividers
        for (int row = 0; row < board.Size; row++)
        {
            // Row # and Left border
            Console.Write(row.ToString().PadLeft(2) + " |");

            // Iterate through each cell in the row
            for (int col = 0; col < board.Size; col++)
            {
                Cell cell = board.Cells[row, col]; // stored coordinate of cell

                // Check if the cell is visited
                if (cell.IsVisited)
                {
                    if (cell.IsBomb)
                    {
                        // Display in blue if revealed by reward
                        if (cell.HasSpecialReward)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (cell.IsKillerBomb)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        Console.Write(" B ");
                        Console.ResetColor();
                    }
                    else if (cell.HasSpecialReward)
                    {
                        // If revealed through FloodFill, set color to DarkCyan; otherwise Blue
                        if (cell.FloodFilled)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }

                        if (cell.NumberOfBombNeighbors > 0)
                        {
                            Console.Write(" " + cell.NumberOfBombNeighbors + " ");
                        }
                        else
                        {
                            Console.Write(" r ");
                        }
                        Console.ResetColor();
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        SetNumberColor(cell.NumberOfBombNeighbors);
                        Console.Write(" " + cell.NumberOfBombNeighbors + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                else if (cell.IsFlagged)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" F ");
                    Console.ResetColor();
                }
                else
                    // If the cell is not visited, print a question mark
                    Console.Write(" ? ");

                // Vertical separator between cells
                Console.Write("|");
            }

            // Move to next row
            Console.WriteLine();

            // Corners, including last
            Console.Write("   +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }
    }

    // Method to print board answer key
    public static void PrintAnswers(Board board)
    {
        Console.WriteLine("\n----------Answer Key-------------");
        // Column Numbers 

        Console.Write("\n   "); // Space for row numbers

        for (int col = 0; col < board.Size; col++)
        {
            Console.Write(col.ToString().PadLeft(3) + " ");
        }
        Console.WriteLine();


        // Upper Corners
        Console.Write("   +"); // First upper corner

        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("---+");  // upper right corners
        }
        Console.WriteLine(); // Move to first row


        // Rows with Row # and Vertical Dividers
        for (int row = 0; row < board.Size; row++)
        {
            Console.Write(row.ToString().PadLeft(2) + " |"); // Row # and Left border

            for (int col = 0; col < board.Size; col++)
            {
                Cell cell = board.Cells[row, col]; // stored coordinate of cell

                if (cell.IsBomb)
                {
                    // Display in blue if revealed by reward
                    if (cell.HasSpecialReward)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (cell.IsKillerBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Write(" B ");
                    Console.ResetColor();
                }
                else if (cell.HasSpecialReward)
                {
                    // If revealed through FloodFill, set color to DarkCyan; otherwise Blue
                    if (cell.FloodFilled)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    Console.Write(" r ");
                    Console.ResetColor();
                }
                else if (cell.NumberOfBombNeighbors > 0)
                {
                    SetNumberColor(cell.NumberOfBombNeighbors);
                    Console.Write(" " + cell.NumberOfBombNeighbors + " ");
                    Console.ResetColor();
                }
                else if (cell.IsFlagged)
                {
                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    
                    Console.Write(" F ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" . ");
                }

                // Vertical separator between cells
                Console.Write("|");
            }

            Console.WriteLine(); // Move to next row

            // Corners, including last
            Console.Write("   +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }
    }

    // Helper Method to Color Numbers
    private static void SetNumberColor(int number)
    {
        switch (number)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
        }
    }
}

using System.IO;
using Newtonsoft.Json;
using MindSweeperClasses;
using System.Collections.Generic;

namespace MineSweeperGUI
{
    internal static class GameState
    {
        public static void SaveGame(Board gameBoard, string filePath)
        {
            var flatCells = new List<Cell>();
            for (int row = 0; row < gameBoard.Size; row++)
            {
                for (int col = 0; col < gameBoard.Size; col++)
                {
                    flatCells.Add(gameBoard.Cells[row, col]);
                }
            }

            var save = new SaveState
            {
                Size = gameBoard.Size,
                Difficulty = gameBoard.Difficulty,
                DifficultyType = gameBoard.DifficultyType,
                Cells = flatCells,
                DetectorOwned = gameBoard.DetectorOwned,
                DetectorFound = gameBoard.DetectorFound,
                RadarOwned = gameBoard.RadarOwned,
                RadarFound = gameBoard.RadarFound,
                TotalDetectors = gameBoard.TotalDetectors,
                TotalRadar = gameBoard.TotalRadar,
                StartTime = gameBoard.StartTime,
                EndTime = gameBoard.EndTime,
                BombCount = gameBoard.BombCount
            };

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(save, settings);
            File.WriteAllText(filePath, json);
        }

        public static Board LoadGame(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Save file not found.");

            string json = File.ReadAllText(filePath);
            var save = JsonConvert.DeserializeObject<SaveState>(json);

            var board = new Board(save.Size, save.Difficulty, save.DifficultyType)
            {
                DetectorOwned = save.DetectorOwned,
                DetectorFound = save.DetectorFound,
                RadarOwned = save.RadarOwned,
                RadarFound = save.RadarFound,
                StartTime = save.StartTime,
                EndTime = save.EndTime,
                BombCount = save.BombCount
            };

            // Rebuild Cells[,]
            int index = 0;
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    board.Cells[row, col] = save.Cells[index++];
                }
            }

            board.CountBombNearby(); // Recalculate numbers just in case
            return board;
        }
    }
    public class SaveState
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public string DifficultyType { get; set; }
        public List<Cell> Cells { get; set; }
        public int DetectorOwned { get; set; }
        public int DetectorFound { get; set; }
        public int RadarOwned { get; set; }
        public int RadarFound { get; set; }
        public int TotalDetectors { get; set; }
        public int TotalRadar { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BombCount { get; set; }
    }
}

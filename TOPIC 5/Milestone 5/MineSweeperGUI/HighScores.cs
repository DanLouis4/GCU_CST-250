using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.IO;

namespace MineSweeperGUI
{
    public partial class Frm_HighScores : Form
    {
        GameStat PlayerStat;
        private string defaultFile = Path.Combine(Application.StartupPath, "highscores.txt");

        public List<GameStat> HighScores = new List<GameStat>();

        public Frm_HighScores(string name, int score)
        {
            PlayerStat = new GameStat();
            PlayerStat.Id = HighScores.Count + 1;
            PlayerStat.PlayerName = name;
            PlayerStat.Score = score;
            PlayerStat.GameTime = DateTime.Now;

            HighScores.Add(PlayerStat);

            InitializeComponent();

            LoadScores(); // load previous scores

            PlayerStat = new GameStat
            {
                Id = HighScores.Count + 1,
                PlayerName = name,
                Score = score,
                GameTime = DateTime.Now
            };
            HighScores.Add(PlayerStat);

            lbl_HighScores.Left = (this.ClientSize.Width / 2) - (lbl_HighScores.Width / 2);
            dgv_HighScores.Left = (this.ClientSize.Width / 2) - (dgv_HighScores.Width / 2);
            btn_HighScoresOK.Left = (this.ClientSize.Width / 2) - (btn_HighScoresOK.Width / 2);

            dgv_HighScores.DataSource = HighScores;
        }

        /*
         * Retrieve List
         */
        private void LoadScores()
        {
            HighScores.Clear();

            if (File.Exists(defaultFile))
            {
                using (StreamReader reader = new StreamReader(defaultFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            GameStat newScore = new GameStat
                            {
                                Id = int.Parse(parts[0]),
                                PlayerName = parts[1],
                                Score = int.Parse(parts[2]),
                                GameTime = DateTime.Parse(parts[3])
                            };
                            HighScores.Add(newScore);
                        }
                    }
                }
            }
        }

        /*
         * Menu Item File - Save or load scores.
         */
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Title = "Saving High Scores";
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter saveFile = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (GameStat stat in HighScores)
                    {
                        string line = $"{stat.Id},{stat.PlayerName},{stat.Score},{stat.GameTime}";
                        saveFile.WriteLine(line);
                    }
                }
                MessageBox.Show("High Scores Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.InitialDirectory = Application.StartupPath;
            loadFileDialog.Title = "Loading High Scores";
            loadFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                HighScores.Clear(); // Clear current list

                using (StreamReader loadFile = new StreamReader(loadFileDialog.FileName))
                {
                    string line;
                    while ((line = loadFile.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 4)
                        {
                            GameStat stat = new GameStat();
                            stat.Id = int.Parse(parts[0]);
                            stat.PlayerName = parts[1];
                            stat.Score = int.Parse(parts[2]);
                            stat.GameTime = DateTime.Parse(parts[3]);

                            HighScores.Add(stat);
                        }
                    }
                }

                dgv_HighScores.DataSource = null;
                dgv_HighScores.DataSource = HighScores;

                MessageBox.Show("High Scores Loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         * Menu Item: Sort - Sorting the List
         */
        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var byName = HighScores.OrderBy(stat => stat.PlayerName).ToList();
            SortingList(byName);
        }
        private void byScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var byDate = HighScores.OrderBy(stat => stat.Score).ToList();
            SortingList(byDate);
        }
        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var byDate = HighScores.OrderBy(stat => stat.GameTime).ToList();
            SortingList(byDate);
        }
        private void SortingList(List<GameStat> sortedList)
        {
            dgv_HighScores.DataSource = null;
            dgv_HighScores.DataSource = sortedList;
        }


        /*
         * Close Window.
         */
        private void btn_HighScoresOK_Click(object sender, EventArgs e)
        {
            Frm_StartGame frm_StartGame = new Frm_StartGame();
            this.Close();
        }
    }
}

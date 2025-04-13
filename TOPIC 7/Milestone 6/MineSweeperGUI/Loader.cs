using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using MindSweeperClasses;

namespace MineSweeperGUI
{
    public partial class Frm_Loader : Form
    {
        public Frm_Loader()
        {
            InitializeComponent();
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            Frm_StartGame NewGame = new Frm_StartGame();
            NewGame.Show();
            this.Hide();
        }

        private void btn_LoadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "JSON Files|*.json";
            openDialog.Title = "Select a Saved Game";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the board from file
                    Board loadedBoard = GameState.LoadGame(openDialog.FileName);

                    // Pass the board to your game form
                    Frm_MineSweeper resumeGame = new Frm_MineSweeper(loadedBoard);
                    resumeGame.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load game:\n" + ex.Message);
                }
            }
        }

    }
}

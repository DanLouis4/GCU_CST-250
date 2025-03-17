using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class Frm_StartGame : Form
    {
        // Declare variables for difficulty and board size 
        float difficulty = 0.075f; // Default difficulty
        int boardSize = 10; // Default board size

        public Frm_StartGame()
        {
            InitializeComponent();
        }

        // Handle the ValueChanged event to snap to nearest value
        private void tkb_boardSize_Scroll(object sender, EventArgs e)
        {
            // Set up the trackbar properties
            trk_boardSize.Minimum = 10;
            trk_boardSize.Maximum = 20;
            trk_boardSize.TickFrequency = 5;
            trk_boardSize.SmallChange = 5;
            trk_boardSize.LargeChange = 5;

            if (trk_boardSize.Value <= 12) trk_boardSize.Value = 10;
            else if (trk_boardSize.Value <= 17) trk_boardSize.Value = 15;
            else trk_boardSize.Value = 20;

            // Update the label to show the current value
            lbl_SizeSelect.Text = trk_boardSize.Value.ToString();

            boardSize = trk_boardSize.Value; // Update the board size
        }

        // Handle the radio button checked change event
        private void rbn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Easy.Checked)
            {
                difficulty = 0.075f; // Set difficulty to Easy
            }
            else if (rdo_Normal.Checked)
            {
                difficulty = 0.10f; // Set difficulty to Normal
            }
            else if (rdo_Hard.Checked)
            {
                difficulty = 0.25f; // Set difficulty to Hard
            }
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            Frm_MineSweeper NewGame = new Frm_MineSweeper(boardSize, difficulty);
            NewGame.Show(); // Show the new game form
            this.Hide(); // Hide the start game form
        }
    }
}

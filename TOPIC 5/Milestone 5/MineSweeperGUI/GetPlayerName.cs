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
    public partial class Frm_GetPlayerName : Form
    {
        string InputName = "";
        int finalScore;

        public Frm_GetPlayerName(int score)
        {
            finalScore = score;
            InitializeComponent();
            lbl_FinalScoreValue.Text = score.ToString();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            InputName = txt_GetPlayerName.Text;
  
            Frm_HighScores frm_HighScores = new Frm_HighScores(InputName, finalScore);
            frm_HighScores.ShowDialog();
                        
            this.DialogResult = DialogResult.OK;            
        }
    }
}

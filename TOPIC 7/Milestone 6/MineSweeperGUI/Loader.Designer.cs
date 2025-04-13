namespace MineSweeperGUI
{
    partial class Frm_Loader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_WelcomeTo = new Label();
            lbl_MineSweeper = new Label();
            lbl_DeveloperName = new Label();
            btn_LoadGame = new Button();
            btn_NewGame = new Button();
            SuspendLayout();
            // 
            // lbl_WelcomeTo
            // 
            lbl_WelcomeTo.AutoSize = true;
            lbl_WelcomeTo.BackColor = Color.Transparent;
            lbl_WelcomeTo.Font = new Font("Kabel Ult BT", 12F);
            lbl_WelcomeTo.Location = new Point(109, 77);
            lbl_WelcomeTo.Name = "lbl_WelcomeTo";
            lbl_WelcomeTo.Size = new Size(193, 39);
            lbl_WelcomeTo.TabIndex = 0;
            lbl_WelcomeTo.Text = "Welcome To";
            // 
            // lbl_MineSweeper
            // 
            lbl_MineSweeper.AutoSize = true;
            lbl_MineSweeper.BackColor = Color.Transparent;
            lbl_MineSweeper.Font = new Font("Stencil Std", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_MineSweeper.ForeColor = Color.DarkGreen;
            lbl_MineSweeper.Location = new Point(97, 105);
            lbl_MineSweeper.Name = "lbl_MineSweeper";
            lbl_MineSweeper.Size = new Size(556, 88);
            lbl_MineSweeper.TabIndex = 1;
            lbl_MineSweeper.Text = "MineSweeper";
            // 
            // lbl_DeveloperName
            // 
            lbl_DeveloperName.AutoSize = true;
            lbl_DeveloperName.BackColor = Color.Transparent;
            lbl_DeveloperName.Font = new Font("Arial Rounded MT Bold", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_DeveloperName.Location = new Point(470, 182);
            lbl_DeveloperName.Name = "lbl_DeveloperName";
            lbl_DeveloperName.Size = new Size(161, 24);
            lbl_DeveloperName.TabIndex = 2;
            lbl_DeveloperName.Text = "By Daniel Lous";
            // 
            // btn_LoadGame
            // 
            btn_LoadGame.BackColor = Color.RoyalBlue;
            btn_LoadGame.Cursor = Cursors.Hand;
            btn_LoadGame.FlatStyle = FlatStyle.Flat;
            btn_LoadGame.ForeColor = Color.White;
            btn_LoadGame.Location = new Point(550, 535);
            btn_LoadGame.Name = "btn_LoadGame";
            btn_LoadGame.Size = new Size(150, 75);
            btn_LoadGame.TabIndex = 3;
            btn_LoadGame.Text = "Load Game";
            btn_LoadGame.UseVisualStyleBackColor = false;
            btn_LoadGame.Click += btn_LoadGame_Click;
            // 
            // btn_NewGame
            // 
            btn_NewGame.BackColor = Color.LimeGreen;
            btn_NewGame.Cursor = Cursors.Hand;
            btn_NewGame.FlatStyle = FlatStyle.Flat;
            btn_NewGame.ForeColor = SystemColors.ButtonHighlight;
            btn_NewGame.Location = new Point(550, 406);
            btn_NewGame.Name = "btn_NewGame";
            btn_NewGame.Size = new Size(150, 75);
            btn_NewGame.TabIndex = 4;
            btn_NewGame.Text = "New Game";
            btn_NewGame.UseVisualStyleBackColor = false;
            btn_NewGame.Click += btn_NewGame_Click;
            // 
            // Frm_Loader
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(742, 697);
            Controls.Add(btn_NewGame);
            Controls.Add(btn_LoadGame);
            Controls.Add(lbl_DeveloperName);
            Controls.Add(lbl_WelcomeTo);
            Controls.Add(lbl_MineSweeper);
            Name = "Frm_Loader";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_WelcomeTo;
        private Label lbl_MineSweeper;
        private Label lbl_DeveloperName;
        private Button btn_LoadGame;
        private Button btn_NewGame;
    }
}
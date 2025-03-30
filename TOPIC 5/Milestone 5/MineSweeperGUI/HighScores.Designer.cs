namespace MineSweeperGUI
{
    partial class Frm_HighScores
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
            menuStrip1 = new MenuStrip();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem1 = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            sortToolStripMenuItem = new ToolStripMenuItem();
            mnu_SortByName = new ToolStripMenuItem();
            mnu_SortByScore = new ToolStripMenuItem();
            mnu_SortByDate = new ToolStripMenuItem();
            dgv_HighScores = new DataGridView();
            lbl_HighScores = new Label();
            btn_HighScoresOK = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_HighScores).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem, sortToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(804, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem1, loadToolStripMenuItem, exitToolStripMenuItem });
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(71, 38);
            saveToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.Size = new Size(198, 44);
            saveToolStripMenuItem1.Text = "Save";
            saveToolStripMenuItem1.Click += saveToolStripMenuItem1_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(198, 44);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(198, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnu_SortByName, mnu_SortByScore, mnu_SortByDate });
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(77, 36);
            sortToolStripMenuItem.Text = "Sort";
            // 
            // mnu_SortByName
            // 
            mnu_SortByName.Name = "mnu_SortByName";
            mnu_SortByName.Size = new Size(359, 44);
            mnu_SortByName.Text = "By Name";
            mnu_SortByName.Click += byNameToolStripMenuItem_Click;
            // 
            // mnu_SortByScore
            // 
            mnu_SortByScore.Name = "mnu_SortByScore";
            mnu_SortByScore.Size = new Size(244, 44);
            mnu_SortByScore.Text = "By Score";
            mnu_SortByScore.Click += byScoreToolStripMenuItem_Click;
            // 
            // mnu_SortByDate
            // 
            mnu_SortByDate.Name = "mnu_SortByDate";
            mnu_SortByDate.Size = new Size(244, 44);
            mnu_SortByDate.Text = "By Date";
            mnu_SortByDate.Click += byDateToolStripMenuItem_Click;
            // 
            // dgv_HighScores
            // 
            dgv_HighScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HighScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HighScores.Location = new Point(12, 140);
            dgv_HighScores.Name = "dgv_HighScores";
            dgv_HighScores.RowHeadersWidth = 82;
            dgv_HighScores.Size = new Size(750, 468);
            dgv_HighScores.TabIndex = 1;
            // 
            // lbl_HighScores
            // 
            lbl_HighScores.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_HighScores.Location = new Point(242, 70);
            lbl_HighScores.Name = "lbl_HighScores";
            lbl_HighScores.Size = new Size(300, 45);
            lbl_HighScores.TabIndex = 2;
            lbl_HighScores.Text = "High Scores";
            lbl_HighScores.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_HighScoresOK
            // 
            btn_HighScoresOK.Location = new Point(498, 632);
            btn_HighScoresOK.Name = "btn_HighScoresOK";
            btn_HighScoresOK.Size = new Size(150, 46);
            btn_HighScoresOK.TabIndex = 3;
            btn_HighScoresOK.Text = "OK";
            btn_HighScoresOK.UseVisualStyleBackColor = true;
            btn_HighScoresOK.Click += btn_HighScoresOK_Click;
            // 
            // Frm_HighScores
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 739);
            Controls.Add(btn_HighScoresOK);
            Controls.Add(lbl_HighScores);
            Controls.Add(dgv_HighScores);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Frm_HighScores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HighScores";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_HighScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private DataGridView dgv_HighScores;
        private Label lbl_HighScores;
        private Button btn_HighScoresOK;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem mnu_SortByName;
        private ToolStripMenuItem mnu_SortByScore;
        private ToolStripMenuItem mnu_SortByDate;
    }
}
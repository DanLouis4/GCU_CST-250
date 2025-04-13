namespace MineSweeperGUI
{
    partial class Frm_MineSweeper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnl_Main = new Panel();
            lbl_StartTime = new Label();
            lbl_Timer = new Label();
            btn_Restart = new Button();
            btn_Exit = new Button();
            lbl_MainTitle = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            gameTimer = new System.Windows.Forms.Timer(components);
            lbl_TotalBombs = new Label();
            lbl_numOfBombs = new Label();
            ttp_Rewards = new ToolTip(components);
            btn_UseDetector = new Button();
            btn_UseRadar = new Button();
            lbl_DetectorText = new Label();
            lbl_RadarText = new Label();
            lbl_RadarCount = new Label();
            lbl_DetectorCount = new Label();
            btn_SaveGame = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            mnu_NewGame = new ToolStripMenuItem();
            mnu_LoadGame = new ToolStripMenuItem();
            mnu_SaveGame = new ToolStripMenuItem();
            mnu_Exit = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_Main
            // 
            pnl_Main.BackColor = SystemColors.ActiveCaption;
            pnl_Main.Location = new Point(26, 195);
            pnl_Main.Name = "pnl_Main";
            pnl_Main.Size = new Size(700, 700);
            pnl_Main.TabIndex = 0;
            // 
            // lbl_StartTime
            // 
            lbl_StartTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_StartTime.AutoSize = true;
            lbl_StartTime.Location = new Point(886, 195);
            lbl_StartTime.Name = "lbl_StartTime";
            lbl_StartTime.Size = new Size(134, 32);
            lbl_StartTime.TabIndex = 1;
            lbl_StartTime.Text = "Start Time: ";
            // 
            // lbl_Timer
            // 
            lbl_Timer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Timer.AutoSize = true;
            lbl_Timer.Font = new Font("Segoe UI Black", 12F);
            lbl_Timer.ForeColor = Color.SteelBlue;
            lbl_Timer.Location = new Point(1001, 195);
            lbl_Timer.Name = "lbl_Timer";
            lbl_Timer.Size = new Size(87, 45);
            lbl_Timer.TabIndex = 2;
            lbl_Timer.Text = "0:00";
            // 
            // btn_Restart
            // 
            btn_Restart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Restart.BackColor = Color.ForestGreen;
            btn_Restart.Cursor = Cursors.Hand;
            btn_Restart.ForeColor = Color.White;
            btn_Restart.Location = new Point(26, 925);
            btn_Restart.Name = "btn_Restart";
            btn_Restart.Size = new Size(180, 75);
            btn_Restart.TabIndex = 5;
            btn_Restart.Text = "Restart";
            btn_Restart.UseVisualStyleBackColor = false;
            btn_Restart.Click += btn_Restart_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Exit.BackColor = Color.IndianRed;
            btn_Exit.Cursor = Cursors.Hand;
            btn_Exit.ForeColor = SystemColors.ButtonHighlight;
            btn_Exit.Location = new Point(546, 925);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(180, 75);
            btn_Exit.TabIndex = 6;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // lbl_MainTitle
            // 
            lbl_MainTitle.AutoSize = true;
            lbl_MainTitle.Font = new Font("Stencil Std", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_MainTitle.ForeColor = Color.DarkGreen;
            lbl_MainTitle.Location = new Point(27, 89);
            lbl_MainTitle.Name = "lbl_MainTitle";
            lbl_MainTitle.Size = new Size(442, 70);
            lbl_MainTitle.TabIndex = 7;
            lbl_MainTitle.Text = "MineSweeper";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            // 
            // lbl_TotalBombs
            // 
            lbl_TotalBombs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_TotalBombs.AutoSize = true;
            lbl_TotalBombs.Location = new Point(953, 328);
            lbl_TotalBombs.Name = "lbl_TotalBombs";
            lbl_TotalBombs.Size = new Size(150, 32);
            lbl_TotalBombs.TabIndex = 10;
            lbl_TotalBombs.Text = "Total Bombs:";
            // 
            // lbl_numOfBombs
            // 
            lbl_numOfBombs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_numOfBombs.AutoSize = true;
            lbl_numOfBombs.Font = new Font("Segoe UI Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_numOfBombs.Location = new Point(1026, 350);
            lbl_numOfBombs.Name = "lbl_numOfBombs";
            lbl_numOfBombs.Size = new Size(62, 71);
            lbl_numOfBombs.TabIndex = 11;
            lbl_numOfBombs.Text = "0";
            // 
            // ttp_Rewards
            // 
            ttp_Rewards.ToolTipTitle = "Rewards Tip";
            // 
            // btn_UseDetector
            // 
            btn_UseDetector.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_UseDetector.BackColor = Color.Gold;
            btn_UseDetector.ForeColor = Color.DodgerBlue;
            btn_UseDetector.Location = new Point(871, 540);
            btn_UseDetector.Name = "btn_UseDetector";
            btn_UseDetector.Size = new Size(232, 100);
            btn_UseDetector.TabIndex = 12;
            btn_UseDetector.Text = "Use Detector";
            btn_UseDetector.UseVisualStyleBackColor = false;
            btn_UseDetector.Click += btn_UseDetector_Click;
            // 
            // btn_UseRadar
            // 
            btn_UseRadar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_UseRadar.BackColor = Color.Gold;
            btn_UseRadar.ForeColor = Color.Green;
            btn_UseRadar.Location = new Point(871, 795);
            btn_UseRadar.Name = "btn_UseRadar";
            btn_UseRadar.Size = new Size(232, 100);
            btn_UseRadar.TabIndex = 13;
            btn_UseRadar.Text = "Use Radar";
            btn_UseRadar.UseVisualStyleBackColor = false;
            btn_UseRadar.Click += btn_UseRadar_Click;
            // 
            // lbl_DetectorText
            // 
            lbl_DetectorText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_DetectorText.AutoSize = true;
            lbl_DetectorText.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_DetectorText.ForeColor = Color.DarkGreen;
            lbl_DetectorText.Location = new Point(908, 434);
            lbl_DetectorText.Name = "lbl_DetectorText";
            lbl_DetectorText.Size = new Size(200, 32);
            lbl_DetectorText.TabIndex = 14;
            lbl_DetectorText.Text = "Bomb Detector:";
            // 
            // lbl_RadarText
            // 
            lbl_RadarText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_RadarText.AutoSize = true;
            lbl_RadarText.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_RadarText.ForeColor = Color.Blue;
            lbl_RadarText.Location = new Point(920, 689);
            lbl_RadarText.Name = "lbl_RadarText";
            lbl_RadarText.Size = new Size(188, 32);
            lbl_RadarText.TabIndex = 16;
            lbl_RadarText.Text = "Scanner Radar:";
            // 
            // lbl_RadarCount
            // 
            lbl_RadarCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_RadarCount.BackColor = Color.Transparent;
            lbl_RadarCount.Font = new Font("Segoe UI Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_RadarCount.ForeColor = Color.Blue;
            lbl_RadarCount.Location = new Point(732, 721);
            lbl_RadarCount.Name = "lbl_RadarCount";
            lbl_RadarCount.Size = new Size(371, 71);
            lbl_RadarCount.TabIndex = 17;
            lbl_RadarCount.Text = "0 / 0 / 0";
            lbl_RadarCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_DetectorCount
            // 
            lbl_DetectorCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_DetectorCount.BackColor = Color.Transparent;
            lbl_DetectorCount.Font = new Font("Segoe UI Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_DetectorCount.ForeColor = Color.SeaGreen;
            lbl_DetectorCount.Location = new Point(732, 466);
            lbl_DetectorCount.Name = "lbl_DetectorCount";
            lbl_DetectorCount.Size = new Size(371, 71);
            lbl_DetectorCount.TabIndex = 18;
            lbl_DetectorCount.Text = "0 / 0 / 0";
            lbl_DetectorCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_SaveGame
            // 
            btn_SaveGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_SaveGame.BackColor = Color.LightBlue;
            btn_SaveGame.Cursor = Cursors.Hand;
            btn_SaveGame.ForeColor = Color.DarkRed;
            btn_SaveGame.Location = new Point(289, 925);
            btn_SaveGame.Name = "btn_SaveGame";
            btn_SaveGame.Size = new Size(180, 75);
            btn_SaveGame.TabIndex = 19;
            btn_SaveGame.Text = "Save Game";
            btn_SaveGame.UseVisualStyleBackColor = false;
            btn_SaveGame.Click += SaveGame_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1124, 42);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnu_NewGame, mnu_LoadGame, mnu_SaveGame, mnu_Exit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // mnu_NewGame
            // 
            mnu_NewGame.Name = "mnu_NewGame";
            mnu_NewGame.Size = new Size(359, 44);
            mnu_NewGame.Text = "New Game";
            mnu_NewGame.Click += btn_Restart_Click;
            // 
            // mnu_LoadGame
            // 
            mnu_LoadGame.Name = "mnu_LoadGame";
            mnu_LoadGame.Size = new Size(359, 44);
            mnu_LoadGame.Text = "Load Game";
            mnu_LoadGame.Click += LoadGame_Click;
            // 
            // mnu_SaveGame
            // 
            mnu_SaveGame.Name = "mnu_SaveGame";
            mnu_SaveGame.Size = new Size(359, 44);
            mnu_SaveGame.Text = "Save Game";
            mnu_SaveGame.Click += SaveGame_Click;
            // 
            // mnu_Exit
            // 
            mnu_Exit.Name = "mnu_Exit";
            mnu_Exit.Size = new Size(359, 44);
            mnu_Exit.Text = "Exit";
            mnu_Exit.Click += btn_Exit_Click;
            // 
            // Frm_MineSweeper
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 1027);
            Controls.Add(btn_SaveGame);
            Controls.Add(lbl_TotalBombs);
            Controls.Add(btn_UseRadar);
            Controls.Add(lbl_RadarText);
            Controls.Add(lbl_DetectorText);
            Controls.Add(btn_UseDetector);
            Controls.Add(lbl_numOfBombs);
            Controls.Add(lbl_Timer);
            Controls.Add(lbl_StartTime);
            Controls.Add(lbl_MainTitle);
            Controls.Add(btn_Exit);
            Controls.Add(btn_Restart);
            Controls.Add(pnl_Main);
            Controls.Add(lbl_DetectorCount);
            Controls.Add(lbl_RadarCount);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Frm_MineSweeper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DL's MineSweeper 1.0";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnl_Main;
        private Label lbl_StartTime;
        private Label lbl_Timer;
        private Button btn_Restart;
        private Button btn_Exit;
        private Label lbl_MainTitle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer gameTimer;
        private DateTime startTime;
        private Label lbl_TotalBombs;
        private Label lbl_numOfBombs;
        private ToolTip ttp_Rewards;
        private Button btn_UseDetector;
        private Button btn_UseRadar;
        private Label lbl_DetectorText;
        private Label lbl_RadarText;
        private Label lbl_RadarCount;
        private Label lbl_DetectorCount;
        private Button btn_SaveGame;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mnu_NewGame;
        private ToolStripMenuItem mnu_LoadGame;
        private ToolStripMenuItem mnu_SaveGame;
        private ToolStripMenuItem mnu_Exit;
    }
}

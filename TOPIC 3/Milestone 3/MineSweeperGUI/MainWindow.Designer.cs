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
            label1 = new Label();
            lbl_rewardCount = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            lbl_TotalBombs = new Label();
            lbl_numOfBombs = new Label();
            lbl_Score = new Label();
            lbl_Points = new Label();
            SuspendLayout();
            // 
            // pnl_Main
            // 
            pnl_Main.BackColor = SystemColors.ActiveCaption;
            pnl_Main.Location = new Point(26, 106);
            pnl_Main.Name = "pnl_Main";
            pnl_Main.Size = new Size(700, 700);
            pnl_Main.TabIndex = 0;
            // 
            // lbl_StartTime
            // 
            lbl_StartTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_StartTime.AutoSize = true;
            lbl_StartTime.Location = new Point(784, 106);
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
            lbl_Timer.Location = new Point(916, 96);
            lbl_Timer.Name = "lbl_Timer";
            lbl_Timer.Size = new Size(87, 45);
            lbl_Timer.TabIndex = 2;
            lbl_Timer.Text = "0:00";
            // 
            // btn_Restart
            // 
            btn_Restart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Restart.BackColor = Color.ForestGreen;
            btn_Restart.Cursor = Cursors.Hand;
            btn_Restart.ForeColor = Color.White;
            btn_Restart.Location = new Point(823, 246);
            btn_Restart.Name = "btn_Restart";
            btn_Restart.Size = new Size(180, 84);
            btn_Restart.TabIndex = 5;
            btn_Restart.Text = "Restart";
            btn_Restart.UseVisualStyleBackColor = false;
            btn_Restart.Click += btn_Restart_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Exit.BackColor = Color.IndianRed;
            btn_Exit.Cursor = Cursors.Hand;
            btn_Exit.ForeColor = SystemColors.ButtonHighlight;
            btn_Exit.Location = new Point(823, 736);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(180, 72);
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
            lbl_MainTitle.Location = new Point(12, 9);
            lbl_MainTitle.Name = "lbl_MainTitle";
            lbl_MainTitle.Size = new Size(442, 70);
            lbl_MainTitle.TabIndex = 7;
            lbl_MainTitle.Text = "MineSweeper";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(777, 597);
            label1.Name = "label1";
            label1.Size = new Size(226, 32);
            label1.TabIndex = 8;
            label1.Text = "Rewards Remaining:";
            // 
            // lbl_rewardCount
            // 
            lbl_rewardCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_rewardCount.AutoSize = true;
            lbl_rewardCount.Font = new Font("Segoe UI Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_rewardCount.Location = new Point(941, 629);
            lbl_rewardCount.Name = "lbl_rewardCount";
            lbl_rewardCount.Size = new Size(62, 71);
            lbl_rewardCount.TabIndex = 9;
            lbl_rewardCount.Text = "0";
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
            lbl_TotalBombs.Location = new Point(858, 380);
            lbl_TotalBombs.Name = "lbl_TotalBombs";
            lbl_TotalBombs.Size = new Size(145, 32);
            lbl_TotalBombs.TabIndex = 10;
            lbl_TotalBombs.Text = "Total Bombs";
            // 
            // lbl_numOfBombs
            // 
            lbl_numOfBombs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_numOfBombs.AutoSize = true;
            lbl_numOfBombs.Font = new Font("Segoe UI Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_numOfBombs.Location = new Point(941, 412);
            lbl_numOfBombs.Name = "lbl_numOfBombs";
            lbl_numOfBombs.Size = new Size(62, 71);
            lbl_numOfBombs.TabIndex = 11;
            lbl_numOfBombs.Text = "0";
            // 
            // lbl_Score
            // 
            lbl_Score.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Score.AutoSize = true;
            lbl_Score.Location = new Point(823, 164);
            lbl_Score.Name = "lbl_Score";
            lbl_Score.Size = new Size(78, 32);
            lbl_Score.TabIndex = 3;
            lbl_Score.Text = "Score:";
            // 
            // lbl_Points
            // 
            lbl_Points.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Points.AutoSize = true;
            lbl_Points.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Points.Location = new Point(916, 154);
            lbl_Points.Name = "lbl_Points";
            lbl_Points.Size = new Size(39, 45);
            lbl_Points.TabIndex = 4;
            lbl_Points.Text = "0";
            lbl_Points.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Frm_MineSweeper
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 839);
            Controls.Add(lbl_numOfBombs);
            Controls.Add(lbl_TotalBombs);
            Controls.Add(lbl_rewardCount);
            Controls.Add(label1);
            Controls.Add(lbl_MainTitle);
            Controls.Add(btn_Exit);
            Controls.Add(btn_Restart);
            Controls.Add(lbl_Points);
            Controls.Add(lbl_Score);
            Controls.Add(lbl_Timer);
            Controls.Add(lbl_StartTime);
            Controls.Add(pnl_Main);
            MaximizeBox = false;
            Name = "Frm_MineSweeper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DL's MineSweeper 1.0";
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
        private Label label1;
        private Label lbl_rewardCount;
        private System.Windows.Forms.Timer gameTimer;
        private DateTime startTime;
        private Label lbl_TotalBombs;
        private Label lbl_numOfBombs;
        private Label lbl_Score;
        private Label lbl_Points;
    }
}

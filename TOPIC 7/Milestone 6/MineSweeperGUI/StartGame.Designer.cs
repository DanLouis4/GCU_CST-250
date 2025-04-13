namespace MineSweeperGUI
{
    partial class Frm_StartGame
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
            trk_boardSize = new TrackBar();
            lbl_StartTitle = new Label();
            lbl_Size = new Label();
            btn_Play = new Button();
            gbx_Difficulty = new GroupBox();
            rdo_Hard = new RadioButton();
            rdo_Normal = new RadioButton();
            rdo_Easy = new RadioButton();
            lbl_SizeSelect = new Label();
            ((System.ComponentModel.ISupportInitialize)trk_boardSize).BeginInit();
            gbx_Difficulty.SuspendLayout();
            SuspendLayout();
            // 
            // trk_boardSize
            // 
            trk_boardSize.Location = new Point(70, 113);
            trk_boardSize.Maximum = 20;
            trk_boardSize.Minimum = 10;
            trk_boardSize.Name = "trk_boardSize";
            trk_boardSize.Size = new Size(423, 90);
            trk_boardSize.SmallChange = 5;
            trk_boardSize.TabIndex = 0;
            trk_boardSize.TickFrequency = 5;
            trk_boardSize.TickStyle = TickStyle.Both;
            trk_boardSize.Value = 10;
            trk_boardSize.Scroll += tkb_boardSize_Scroll;
            // 
            // lbl_StartTitle
            // 
            lbl_StartTitle.AutoSize = true;
            lbl_StartTitle.Location = new Point(176, 23);
            lbl_StartTitle.Name = "lbl_StartTitle";
            lbl_StartTitle.Size = new Size(210, 32);
            lbl_StartTitle.TabIndex = 2;
            lbl_StartTitle.Text = "Play MineSweeper";
            lbl_StartTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Size
            // 
            lbl_Size.AutoSize = true;
            lbl_Size.Location = new Point(74, 93);
            lbl_Size.Name = "lbl_Size";
            lbl_Size.Size = new Size(57, 32);
            lbl_Size.TabIndex = 3;
            lbl_Size.Text = "Size";
            // 
            // btn_Play
            // 
            btn_Play.BackColor = Color.ForestGreen;
            btn_Play.Cursor = Cursors.Hand;
            btn_Play.ForeColor = Color.White;
            btn_Play.Location = new Point(191, 542);
            btn_Play.Name = "btn_Play";
            btn_Play.Size = new Size(180, 80);
            btn_Play.TabIndex = 5;
            btn_Play.Text = "Play";
            btn_Play.UseVisualStyleBackColor = false;
            btn_Play.Click += btn_Play_Click;
            // 
            // gbx_Difficulty
            // 
            gbx_Difficulty.BackColor = Color.LightSteelBlue;
            gbx_Difficulty.Controls.Add(rdo_Hard);
            gbx_Difficulty.Controls.Add(rdo_Normal);
            gbx_Difficulty.Controls.Add(rdo_Easy);
            gbx_Difficulty.Location = new Point(74, 256);
            gbx_Difficulty.Name = "gbx_Difficulty";
            gbx_Difficulty.Size = new Size(414, 268);
            gbx_Difficulty.TabIndex = 1;
            gbx_Difficulty.TabStop = false;
            gbx_Difficulty.Text = "Difficulty";
            // 
            // rdo_Hard
            // 
            rdo_Hard.AutoSize = true;
            rdo_Hard.Location = new Point(33, 200);
            rdo_Hard.Name = "rdo_Hard";
            rdo_Hard.Size = new Size(96, 36);
            rdo_Hard.TabIndex = 4;
            rdo_Hard.Text = "Hard";
            rdo_Hard.UseVisualStyleBackColor = true;
            rdo_Hard.CheckedChanged += rbn_CheckedChanged;
            // 
            // rdo_Normal
            // 
            rdo_Normal.AutoSize = true;
            rdo_Normal.Location = new Point(33, 127);
            rdo_Normal.Name = "rdo_Normal";
            rdo_Normal.Size = new Size(124, 36);
            rdo_Normal.TabIndex = 3;
            rdo_Normal.Text = "Normal";
            rdo_Normal.UseVisualStyleBackColor = true;
            rdo_Normal.CheckedChanged += rbn_CheckedChanged;
            // 
            // rdo_Easy
            // 
            rdo_Easy.AutoSize = true;
            rdo_Easy.Checked = true;
            rdo_Easy.Location = new Point(33, 54);
            rdo_Easy.Name = "rdo_Easy";
            rdo_Easy.Size = new Size(91, 36);
            rdo_Easy.TabIndex = 2;
            rdo_Easy.TabStop = true;
            rdo_Easy.Text = "Easy";
            rdo_Easy.UseVisualStyleBackColor = true;
            rdo_Easy.CheckedChanged += rbn_CheckedChanged;
            // 
            // lbl_SizeSelect
            // 
            lbl_SizeSelect.AutoSize = true;
            lbl_SizeSelect.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            lbl_SizeSelect.Location = new Point(241, 174);
            lbl_SizeSelect.Name = "lbl_SizeSelect";
            lbl_SizeSelect.Size = new Size(80, 65);
            lbl_SizeSelect.TabIndex = 6;
            lbl_SizeSelect.Text = "10";
            lbl_SizeSelect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Frm_StartGame
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(574, 649);
            Controls.Add(lbl_SizeSelect);
            Controls.Add(lbl_Size);
            Controls.Add(gbx_Difficulty);
            Controls.Add(btn_Play);
            Controls.Add(lbl_StartTitle);
            Controls.Add(trk_boardSize);
            ForeColor = Color.Black;
            Name = "Frm_StartGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Start a new Game";
            ((System.ComponentModel.ISupportInitialize)trk_boardSize).EndInit();
            gbx_Difficulty.ResumeLayout(false);
            gbx_Difficulty.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trk_boardSize;
        private Label lbl_StartTitle;
        private Label lbl_Size;
        private Button btn_Play;
        private GroupBox gbx_Difficulty;
        private RadioButton rdo_Hard;
        private RadioButton rdo_Normal;
        private RadioButton rdo_Easy;
        private Label lbl_SizeSelect;
    }
}
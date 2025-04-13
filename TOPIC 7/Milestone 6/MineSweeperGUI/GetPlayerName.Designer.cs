namespace MineSweeperGUI
{
    partial class Frm_GetPlayerName
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
            txt_GetPlayerName = new TextBox();
            lbl_EnterName = new Label();
            lbl_Congrats = new Label();
            lbl_FinalScoreValue = new Label();
            lbl_FinalScoreText = new Label();
            btn_GetNameOK = new Button();
            SuspendLayout();
            // 
            // txt_GetPlayerName
            // 
            txt_GetPlayerName.BorderStyle = BorderStyle.FixedSingle;
            txt_GetPlayerName.Location = new Point(137, 348);
            txt_GetPlayerName.Name = "txt_GetPlayerName";
            txt_GetPlayerName.Size = new Size(300, 39);
            txt_GetPlayerName.TabIndex = 0;
            txt_GetPlayerName.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_EnterName
            // 
            lbl_EnterName.AutoSize = true;
            lbl_EnterName.Location = new Point(122, 313);
            lbl_EnterName.Name = "lbl_EnterName";
            lbl_EnterName.Size = new Size(331, 32);
            lbl_EnterName.TabIndex = 1;
            lbl_EnterName.Text = "Please enter your name blow!";
            // 
            // lbl_Congrats
            // 
            lbl_Congrats.AutoSize = true;
            lbl_Congrats.Font = new Font("Segoe UI Black", 13F, FontStyle.Bold);
            lbl_Congrats.ForeColor = Color.RoyalBlue;
            lbl_Congrats.Location = new Point(47, 78);
            lbl_Congrats.Name = "lbl_Congrats";
            lbl_Congrats.Size = new Size(481, 47);
            lbl_Congrats.TabIndex = 2;
            lbl_Congrats.Text = "Congratulations! You Win!";
            // 
            // lbl_FinalScoreValue
            // 
            lbl_FinalScoreValue.Font = new Font("Microsoft Sans Serif", 25F, FontStyle.Bold);
            lbl_FinalScoreValue.Location = new Point(207, 201);
            lbl_FinalScoreValue.Name = "lbl_FinalScoreValue";
            lbl_FinalScoreValue.Size = new Size(160, 75);
            lbl_FinalScoreValue.TabIndex = 3;
            lbl_FinalScoreValue.Text = "000";
            lbl_FinalScoreValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_FinalScoreText
            // 
            lbl_FinalScoreText.AutoSize = true;
            lbl_FinalScoreText.Location = new Point(222, 169);
            lbl_FinalScoreText.Name = "lbl_FinalScoreText";
            lbl_FinalScoreText.Size = new Size(130, 32);
            lbl_FinalScoreText.TabIndex = 4;
            lbl_FinalScoreText.Text = "Final Score";
            // 
            // btn_GetNameOK
            // 
            btn_GetNameOK.Location = new Point(212, 441);
            btn_GetNameOK.Name = "btn_GetNameOK";
            btn_GetNameOK.Size = new Size(150, 46);
            btn_GetNameOK.TabIndex = 5;
            btn_GetNameOK.Text = "OK";
            btn_GetNameOK.UseVisualStyleBackColor = true;
            btn_GetNameOK.Click += btn_Ok_Click;
            // 
            // Frm_GetPlayerName
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 579);
            Controls.Add(btn_GetNameOK);
            Controls.Add(lbl_FinalScoreText);
            Controls.Add(lbl_FinalScoreValue);
            Controls.Add(lbl_Congrats);
            Controls.Add(lbl_EnterName);
            Controls.Add(txt_GetPlayerName);
            Name = "Frm_GetPlayerName";
            StartPosition = FormStartPosition.CenterParent;
            Text = "GetPlayerName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_GetPlayerName;
        private Label lbl_EnterName;
        private Label lbl_Congrats;
        private Label lbl_FinalScoreValue;
        private Label lbl_FinalScoreText;
        private Button btn_GetNameOK;
    }
}
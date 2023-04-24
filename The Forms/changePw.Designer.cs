namespace Hand2
{
    partial class changePw
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.verifyCode = new System.Windows.Forms.TextBox();
            this.newPw1 = new System.Windows.Forms.TextBox();
            this.newPw2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.doneNewPw = new System.Windows.Forms.Button();
            this.codeChecker = new System.Windows.Forms.Timer(this.components);
            this.truemarkIcon = new System.Windows.Forms.PictureBox();
            this.truemarkIcon2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.truemarkIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.truemarkIcon2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verification Code";
            // 
            // verifyCode
            // 
            this.verifyCode.Location = new System.Drawing.Point(145, 31);
            this.verifyCode.Name = "verifyCode";
            this.verifyCode.Size = new System.Drawing.Size(264, 20);
            this.verifyCode.TabIndex = 1;
            this.verifyCode.TextChanged += new System.EventHandler(this.verifyCode_TextChanged);
            // 
            // newPw1
            // 
            this.newPw1.Location = new System.Drawing.Point(145, 59);
            this.newPw1.Name = "newPw1";
            this.newPw1.PasswordChar = '•';
            this.newPw1.Size = new System.Drawing.Size(264, 20);
            this.newPw1.TabIndex = 2;
            this.newPw1.TextChanged += new System.EventHandler(this.newPw1_TextChanged);
            // 
            // newPw2
            // 
            this.newPw2.Location = new System.Drawing.Point(145, 87);
            this.newPw2.Name = "newPw2";
            this.newPw2.PasswordChar = '•';
            this.newPw2.Size = new System.Drawing.Size(264, 20);
            this.newPw2.TabIndex = 3;
            this.newPw2.TextChanged += new System.EventHandler(this.newPw2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm Password";
            // 
            // doneNewPw
            // 
            this.doneNewPw.Enabled = false;
            this.doneNewPw.Location = new System.Drawing.Point(237, 115);
            this.doneNewPw.Name = "doneNewPw";
            this.doneNewPw.Size = new System.Drawing.Size(75, 23);
            this.doneNewPw.TabIndex = 6;
            this.doneNewPw.Text = "Change";
            this.doneNewPw.UseVisualStyleBackColor = true;
            this.doneNewPw.Click += new System.EventHandler(this.doneNewPw_Click);
            // 
            // codeChecker
            // 
            this.codeChecker.Enabled = true;
            this.codeChecker.Tick += new System.EventHandler(this.codeChecker_Tick);
            // 
            // truemarkIcon
            // 
            this.truemarkIcon.Image = global::Hand2.Properties.Resources.rsz_warning_02_512;
            this.truemarkIcon.Location = new System.Drawing.Point(415, 29);
            this.truemarkIcon.Name = "truemarkIcon";
            this.truemarkIcon.Size = new System.Drawing.Size(25, 25);
            this.truemarkIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.truemarkIcon.TabIndex = 7;
            this.truemarkIcon.TabStop = false;
            this.truemarkIcon.Visible = false;
            // 
            // truemarkIcon2
            // 
            this.truemarkIcon2.Image = global::Hand2.Properties.Resources.rsz_warning_02_512;
            this.truemarkIcon2.Location = new System.Drawing.Point(415, 86);
            this.truemarkIcon2.Name = "truemarkIcon2";
            this.truemarkIcon2.Size = new System.Drawing.Size(25, 25);
            this.truemarkIcon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.truemarkIcon2.TabIndex = 8;
            this.truemarkIcon2.TabStop = false;
            this.truemarkIcon2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(143, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fill in the information below:";
            // 
            // changePw
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(447, 171);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.truemarkIcon2);
            this.Controls.Add(this.truemarkIcon);
            this.Controls.Add(this.doneNewPw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newPw2);
            this.Controls.Add(this.newPw1);
            this.Controls.Add(this.verifyCode);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(463, 210);
            this.MinimumSize = new System.Drawing.Size(463, 210);
            this.Name = "changePw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set a new password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.changePw_FormClosed);
            this.Load += new System.EventHandler(this.changePw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.truemarkIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.truemarkIcon2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox verifyCode;
        private System.Windows.Forms.TextBox newPw1;
        private System.Windows.Forms.TextBox newPw2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button doneNewPw;
        private System.Windows.Forms.Timer codeChecker;
        private System.Windows.Forms.PictureBox truemarkIcon;
        private System.Windows.Forms.PictureBox truemarkIcon2;
        private System.Windows.Forms.Label label4;
    }
}
﻿namespace Hand2
{
    partial class forgotPW
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
            this.forgotpwEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fgtpwSendCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // forgotpwEmail
            // 
            this.forgotpwEmail.Location = new System.Drawing.Point(73, 16);
            this.forgotpwEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.forgotpwEmail.Name = "forgotpwEmail";
            this.forgotpwEmail.Size = new System.Drawing.Size(220, 20);
            this.forgotpwEmail.TabIndex = 0;
            this.forgotpwEmail.TextChanged += new System.EventHandler(this.forgotpwEmail_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // fgtpwSendCode
            // 
            this.fgtpwSendCode.Location = new System.Drawing.Point(130, 40);
            this.fgtpwSendCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fgtpwSendCode.Name = "fgtpwSendCode";
            this.fgtpwSendCode.Size = new System.Drawing.Size(91, 19);
            this.fgtpwSendCode.TabIndex = 2;
            this.fgtpwSendCode.Text = "Send Code";
            this.fgtpwSendCode.UseVisualStyleBackColor = true;
            this.fgtpwSendCode.Click += new System.EventHandler(this.fgtpwSendCode_Click);
            // 
            // forgotPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 74);
            this.Controls.Add(this.fgtpwSendCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.forgotpwEmail);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(333, 113);
            this.MinimumSize = new System.Drawing.Size(333, 113);
            this.Name = "forgotPW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Recovery";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.forgotPW_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox forgotpwEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fgtpwSendCode;
    }
}
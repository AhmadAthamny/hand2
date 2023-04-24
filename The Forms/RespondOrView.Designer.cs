namespace Hand2
{
    partial class RespondOrView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FRTO = new System.Windows.Forms.TextBox();
            this.FRID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FRContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FRSendMails = new System.Windows.Forms.CheckBox();
            this.FRCount = new System.Windows.Forms.Label();
            this.FRSubmit = new System.Windows.Forms.Button();
            this.FRResponseBy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feedback Response";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Respond to:";
            // 
            // FRTO
            // 
            this.FRTO.BackColor = System.Drawing.Color.White;
            this.FRTO.Location = new System.Drawing.Point(103, 70);
            this.FRTO.MaxLength = 200;
            this.FRTO.Name = "FRTO";
            this.FRTO.ReadOnly = true;
            this.FRTO.Size = new System.Drawing.Size(220, 22);
            this.FRTO.TabIndex = 2;
            // 
            // FRID
            // 
            this.FRID.BackColor = System.Drawing.Color.White;
            this.FRID.Location = new System.Drawing.Point(103, 42);
            this.FRID.MaxLength = 200;
            this.FRID.Name = "FRID";
            this.FRID.ReadOnly = true;
            this.FRID.Size = new System.Drawing.Size(220, 22);
            this.FRID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Report ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 5;
            // 
            // FRContent
            // 
            this.FRContent.BackColor = System.Drawing.Color.White;
            this.FRContent.Location = new System.Drawing.Point(19, 159);
            this.FRContent.MaxLength = 2000;
            this.FRContent.Multiline = true;
            this.FRContent.Name = "FRContent";
            this.FRContent.ReadOnly = true;
            this.FRContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FRContent.Size = new System.Drawing.Size(601, 196);
            this.FRContent.TabIndex = 7;
            this.FRContent.TextChanged += new System.EventHandler(this.FR_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Response:";
            // 
            // FRSendMails
            // 
            this.FRSendMails.AutoSize = true;
            this.FRSendMails.Location = new System.Drawing.Point(19, 363);
            this.FRSendMails.Name = "FRSendMails";
            this.FRSendMails.Size = new System.Drawing.Size(242, 20);
            this.FRSendMails.TabIndex = 8;
            this.FRSendMails.Text = "Send a copy to the recipient\'s Email.";
            this.FRSendMails.UseVisualStyleBackColor = true;
            // 
            // FRCount
            // 
            this.FRCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FRCount.Location = new System.Drawing.Point(314, 362);
            this.FRCount.Name = "FRCount";
            this.FRCount.Size = new System.Drawing.Size(158, 21);
            this.FRCount.TabIndex = 26;
            this.FRCount.Text = "0 / 2000";
            this.FRCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FRSubmit
            // 
            this.FRSubmit.Location = new System.Drawing.Point(478, 361);
            this.FRSubmit.Name = "FRSubmit";
            this.FRSubmit.Size = new System.Drawing.Size(142, 23);
            this.FRSubmit.TabIndex = 25;
            this.FRSubmit.Text = "Send Response";
            this.FRSubmit.UseVisualStyleBackColor = true;
            this.FRSubmit.Click += new System.EventHandler(this.FRSubmit_Click);
            // 
            // FRResponseBy
            // 
            this.FRResponseBy.BackColor = System.Drawing.Color.White;
            this.FRResponseBy.Location = new System.Drawing.Point(103, 98);
            this.FRResponseBy.MaxLength = 200;
            this.FRResponseBy.Name = "FRResponseBy";
            this.FRResponseBy.ReadOnly = true;
            this.FRResponseBy.Size = new System.Drawing.Size(220, 22);
            this.FRResponseBy.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Response by:";
            // 
            // RespondOrView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 391);
            this.Controls.Add(this.FRResponseBy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FRCount);
            this.Controls.Add(this.FRSubmit);
            this.Controls.Add(this.FRSendMails);
            this.Controls.Add(this.FRContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FRID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FRTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(659, 430);
            this.Name = "RespondOrView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Feedback Response";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RespondOrView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FRTO;
        private System.Windows.Forms.TextBox FRID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FRContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox FRSendMails;
        private System.Windows.Forms.Label FRCount;
        private System.Windows.Forms.Button FRSubmit;
        private System.Windows.Forms.TextBox FRResponseBy;
        private System.Windows.Forms.Label label6;
    }
}
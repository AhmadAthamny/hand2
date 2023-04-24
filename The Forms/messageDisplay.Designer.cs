namespace Hand2
{
    partial class messageDisplay
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
            this.mdFrom = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mdTitle = new System.Windows.Forms.Label();
            this.mdDate = new System.Windows.Forms.Label();
            this.mdContent = new System.Windows.Forms.TextBox();
            this.replyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mdFrom
            // 
            this.mdFrom.AutoSize = true;
            this.mdFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mdFrom.Location = new System.Drawing.Point(22, 47);
            this.mdFrom.Name = "mdFrom";
            this.mdFrom.Size = new System.Drawing.Size(104, 16);
            this.mdFrom.TabIndex = 0;
            this.mdFrom.Text = "From: Someone";
            // 
            // mdTitle
            // 
            this.mdTitle.AutoSize = true;
            this.mdTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.mdTitle.Location = new System.Drawing.Point(22, 22);
            this.mdTitle.Name = "mdTitle";
            this.mdTitle.Size = new System.Drawing.Size(98, 20);
            this.mdTitle.TabIndex = 1;
            this.mdTitle.Text = "title is here";
            // 
            // mdDate
            // 
            this.mdDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mdDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mdDate.Location = new System.Drawing.Point(601, 43);
            this.mdDate.Name = "mdDate";
            this.mdDate.Size = new System.Drawing.Size(189, 20);
            this.mdDate.TabIndex = 2;
            this.mdDate.Text = "23/12/2018 23:33:25 AM";
            this.mdDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mdContent
            // 
            this.mdContent.BackColor = System.Drawing.Color.White;
            this.mdContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mdContent.Location = new System.Drawing.Point(26, 94);
            this.mdContent.Multiline = true;
            this.mdContent.Name = "mdContent";
            this.mdContent.ReadOnly = true;
            this.mdContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mdContent.Size = new System.Drawing.Size(757, 236);
            this.mdContent.TabIndex = 3;
            this.mdContent.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\n ";
            // 
            // replyButton
            // 
            this.replyButton.Enabled = false;
            this.replyButton.Location = new System.Drawing.Point(26, 338);
            this.replyButton.Name = "replyButton";
            this.replyButton.Size = new System.Drawing.Size(94, 24);
            this.replyButton.TabIndex = 4;
            this.replyButton.Text = "Reply";
            this.replyButton.UseVisualStyleBackColor = true;
            this.replyButton.Click += new System.EventHandler(this.replyButton_Click);
            // 
            // messageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 378);
            this.Controls.Add(this.replyButton);
            this.Controls.Add(this.mdContent);
            this.Controls.Add(this.mdDate);
            this.Controls.Add(this.mdTitle);
            this.Controls.Add(this.mdFrom);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(827, 417);
            this.MinimumSize = new System.Drawing.Size(814, 381);
            this.Name = "messageDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hand2 - Viewing Message";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.messageDisplay_FormClosed);
            this.Load += new System.EventHandler(this.messageDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label mdFrom;
        public System.Windows.Forms.Label mdTitle;
        public System.Windows.Forms.Label mdDate;
        public System.Windows.Forms.TextBox mdContent;
        private System.Windows.Forms.Button replyButton;
    }
}
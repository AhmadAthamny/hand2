namespace Hand2
{
    partial class viewMessages
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.msgNoResults = new System.Windows.Forms.Label();
            this.btnmsgsAll = new System.Windows.Forms.Button();
            this.btnmsgsSent = new System.Windows.Forms.Button();
            this.btnmsgsInbox = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.msgNoResults);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 447);
            this.panel2.TabIndex = 1;
            // 
            // msgNoResults
            // 
            this.msgNoResults.AutoSize = true;
            this.msgNoResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.msgNoResults.Location = new System.Drawing.Point(123, 167);
            this.msgNoResults.Name = "msgNoResults";
            this.msgNoResults.Size = new System.Drawing.Size(706, 120);
            this.msgNoResults.TabIndex = 1;
            this.msgNoResults.Text = "No Messages";
            this.msgNoResults.Visible = false;
            // 
            // btnmsgsAll
            // 
            this.btnmsgsAll.Location = new System.Drawing.Point(977, 70);
            this.btnmsgsAll.Name = "btnmsgsAll";
            this.btnmsgsAll.Size = new System.Drawing.Size(97, 23);
            this.btnmsgsAll.TabIndex = 6;
            this.btnmsgsAll.Text = "All";
            this.btnmsgsAll.UseVisualStyleBackColor = true;
            this.btnmsgsAll.Click += new System.EventHandler(this.btnmsgsAll_Click);
            // 
            // btnmsgsSent
            // 
            this.btnmsgsSent.Location = new System.Drawing.Point(977, 41);
            this.btnmsgsSent.Name = "btnmsgsSent";
            this.btnmsgsSent.Size = new System.Drawing.Size(97, 23);
            this.btnmsgsSent.TabIndex = 5;
            this.btnmsgsSent.Text = "Sent";
            this.btnmsgsSent.UseVisualStyleBackColor = true;
            this.btnmsgsSent.Click += new System.EventHandler(this.btnmsgsSent_Click);
            // 
            // btnmsgsInbox
            // 
            this.btnmsgsInbox.Location = new System.Drawing.Point(977, 12);
            this.btnmsgsInbox.Name = "btnmsgsInbox";
            this.btnmsgsInbox.Size = new System.Drawing.Size(97, 23);
            this.btnmsgsInbox.TabIndex = 4;
            this.btnmsgsInbox.Text = "Inbox";
            this.btnmsgsInbox.UseVisualStyleBackColor = true;
            this.btnmsgsInbox.Click += new System.EventHandler(this.btnmsgsInbox_Click);
            // 
            // viewMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 471);
            this.Controls.Add(this.btnmsgsAll);
            this.Controls.Add(this.btnmsgsSent);
            this.Controls.Add(this.btnmsgsInbox);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1102, 510);
            this.MinimumSize = new System.Drawing.Size(1102, 510);
            this.Name = "viewMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hand2 - Messages";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.viewMessages_FormClosed);
            this.Load += new System.EventHandler(this.viewMessages_Load);
            this.LocationChanged += new System.EventHandler(this.viewMessages_LocationChanged);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnmsgsAll;
        private System.Windows.Forms.Button btnmsgsSent;
        private System.Windows.Forms.Button btnmsgsInbox;
        private System.Windows.Forms.Label msgNoResults;
    }
}
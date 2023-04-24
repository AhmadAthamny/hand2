namespace Hand2
{
    partial class messageDisplayInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(messageDisplayInfo));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.msgDate = new System.Windows.Forms.Label();
            this.msgFrom = new System.Windows.Forms.Label();
            this.msgTitle = new System.Windows.Forms.Label();
            this.msgContent = new System.Windows.Forms.Label();
            this.msgHoldsID = new System.Windows.Forms.Label();
            this.msgRead = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgDate
            // 
            this.msgDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.msgDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.msgDate.Location = new System.Drawing.Point(648, 10);
            this.msgDate.Name = "msgDate";
            this.msgDate.Size = new System.Drawing.Size(199, 23);
            this.msgDate.TabIndex = 0;
            this.msgDate.Text = "24/11/2018";
            this.msgDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msgDate.Click += new System.EventHandler(this.label1_Click);
            // 
            // msgFrom
            // 
            this.msgFrom.AutoSize = true;
            this.msgFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.msgFrom.Location = new System.Drawing.Point(12, 30);
            this.msgFrom.Name = "msgFrom";
            this.msgFrom.Size = new System.Drawing.Size(136, 16);
            this.msgFrom.TabIndex = 1;
            this.msgFrom.Text = "From: Ahmad Athamny";
            // 
            // msgTitle
            // 
            this.msgTitle.AutoSize = true;
            this.msgTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.msgTitle.Location = new System.Drawing.Point(12, 10);
            this.msgTitle.Name = "msgTitle";
            this.msgTitle.Size = new System.Drawing.Size(289, 18);
            this.msgTitle.TabIndex = 2;
            this.msgTitle.Text = "Hello it\'s a very big shit here loooool.";
            // 
            // msgContent
            // 
            this.msgContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.msgContent.Location = new System.Drawing.Point(12, 59);
            this.msgContent.Name = "msgContent";
            this.msgContent.Size = new System.Drawing.Size(835, 43);
            this.msgContent.TabIndex = 3;
            this.msgContent.Text = resources.GetString("msgContent.Text");
            // 
            // msgHoldsID
            // 
            this.msgHoldsID.AutoSize = true;
            this.msgHoldsID.Location = new System.Drawing.Point(441, 77);
            this.msgHoldsID.Name = "msgHoldsID";
            this.msgHoldsID.Size = new System.Drawing.Size(35, 13);
            this.msgHoldsID.TabIndex = 4;
            this.msgHoldsID.Text = "label1";
            this.msgHoldsID.Visible = false;
            // 
            // msgRead
            // 
            this.msgRead.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.msgRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.msgRead.ForeColor = System.Drawing.Color.Red;
            this.msgRead.Location = new System.Drawing.Point(730, 33);
            this.msgRead.Name = "msgRead";
            this.msgRead.Size = new System.Drawing.Size(117, 13);
            this.msgRead.TabIndex = 5;
            this.msgRead.Text = "*UNREAD";
            this.msgRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageDisplayInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.msgRead);
            this.Controls.Add(this.msgHoldsID);
            this.Controls.Add(this.msgContent);
            this.Controls.Add(this.msgTitle);
            this.Controls.Add(this.msgFrom);
            this.Controls.Add(this.msgDate);
            this.Name = "messageDisplayInfo";
            this.Size = new System.Drawing.Size(860, 111);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label msgDate;
        public System.Windows.Forms.Label msgFrom;
        public System.Windows.Forms.Label msgTitle;
        public System.Windows.Forms.Label msgContent;
        public System.Windows.Forms.Label msgHoldsID;
        public System.Windows.Forms.Label msgRead;
    }
}

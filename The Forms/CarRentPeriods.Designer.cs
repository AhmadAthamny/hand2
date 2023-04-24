namespace Hand2
{
    partial class CarRentPeriods
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
            this.CRPFromDate = new System.Windows.Forms.Label();
            this.CRPToDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CRPUserID = new System.Windows.Forms.Label();
            this.CRPMoreInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CRPFromDate
            // 
            this.CRPFromDate.AutoSize = true;
            this.CRPFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CRPFromDate.ForeColor = System.Drawing.Color.White;
            this.CRPFromDate.Location = new System.Drawing.Point(117, 6);
            this.CRPFromDate.Name = "CRPFromDate";
            this.CRPFromDate.Size = new System.Drawing.Size(79, 18);
            this.CRPFromDate.TabIndex = 0;
            this.CRPFromDate.Text = "From Date";
            // 
            // CRPToDate
            // 
            this.CRPToDate.AutoSize = true;
            this.CRPToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CRPToDate.ForeColor = System.Drawing.Color.White;
            this.CRPToDate.Location = new System.Drawing.Point(296, 6);
            this.CRPToDate.Name = "CRPToDate";
            this.CRPToDate.Size = new System.Drawing.Size(61, 18);
            this.CRPToDate.TabIndex = 1;
            this.CRPToDate.Text = "To Date";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(-1, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 375);
            this.panel1.TabIndex = 2;
            // 
            // CRPUserID
            // 
            this.CRPUserID.AutoSize = true;
            this.CRPUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CRPUserID.ForeColor = System.Drawing.Color.White;
            this.CRPUserID.Location = new System.Drawing.Point(13, 6);
            this.CRPUserID.Name = "CRPUserID";
            this.CRPUserID.Size = new System.Drawing.Size(58, 18);
            this.CRPUserID.TabIndex = 3;
            this.CRPUserID.Text = "User ID";
            // 
            // CRPMoreInfo
            // 
            this.CRPMoreInfo.AutoSize = true;
            this.CRPMoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CRPMoreInfo.ForeColor = System.Drawing.Color.White;
            this.CRPMoreInfo.Location = new System.Drawing.Point(446, 6);
            this.CRPMoreInfo.Name = "CRPMoreInfo";
            this.CRPMoreInfo.Size = new System.Drawing.Size(71, 18);
            this.CRPMoreInfo.TabIndex = 2;
            this.CRPMoreInfo.Text = "More Info";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.panel2.Controls.Add(this.CRPFromDate);
            this.panel2.Controls.Add(this.CRPUserID);
            this.panel2.Controls.Add(this.CRPToDate);
            this.panel2.Controls.Add(this.CRPMoreInfo);
            this.panel2.Location = new System.Drawing.Point(-1, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 26);
            this.panel2.TabIndex = 4;
            // 
            // CarRentPeriods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 410);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 449);
            this.Name = "CarRentPeriods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Car Rent Periods";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CarRentPeriods_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label CRPFromDate;
        public System.Windows.Forms.Label CRPToDate;
        public System.Windows.Forms.Label CRPMoreInfo;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label CRPUserID;
        public System.Windows.Forms.Panel panel2;
    }
}
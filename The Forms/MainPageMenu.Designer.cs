namespace Hand2
{
    partial class MainPageMenu
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
            this.mpmMessages = new System.Windows.Forms.Button();
            this.mpmMyCars = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.mpmSelectBoard = new System.Windows.Forms.Button();
            this.mpmFeedback = new System.Windows.Forms.Button();
            this.mpmAboutUs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mpmMessages
            // 
            this.mpmMessages.Enabled = false;
            this.mpmMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mpmMessages.Location = new System.Drawing.Point(5, 105);
            this.mpmMessages.Name = "mpmMessages";
            this.mpmMessages.Size = new System.Drawing.Size(226, 45);
            this.mpmMessages.TabIndex = 2;
            this.mpmMessages.Text = "View Messages";
            this.mpmMessages.UseVisualStyleBackColor = true;
            this.mpmMessages.Click += new System.EventHandler(this.mpmMessages_Click);
            // 
            // mpmMyCars
            // 
            this.mpmMyCars.Enabled = false;
            this.mpmMyCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mpmMyCars.Location = new System.Drawing.Point(5, 54);
            this.mpmMyCars.Name = "mpmMyCars";
            this.mpmMyCars.Size = new System.Drawing.Size(226, 45);
            this.mpmMyCars.TabIndex = 1;
            this.mpmMyCars.Text = "My Cars";
            this.mpmMyCars.UseVisualStyleBackColor = true;
            this.mpmMyCars.Click += new System.EventHandler(this.mpmMyCars_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(5, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelTotal
            // 
            this.LabelTotal.BackColor = System.Drawing.Color.Red;
            this.LabelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LabelTotal.ForeColor = System.Drawing.Color.White;
            this.LabelTotal.Location = new System.Drawing.Point(192, 115);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(33, 27);
            this.LabelTotal.TabIndex = 8;
            this.LabelTotal.Text = "12";
            this.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelTotal.Visible = false;
            // 
            // mpmSelectBoard
            // 
            this.mpmSelectBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mpmSelectBoard.Location = new System.Drawing.Point(5, 3);
            this.mpmSelectBoard.Name = "mpmSelectBoard";
            this.mpmSelectBoard.Size = new System.Drawing.Size(226, 45);
            this.mpmSelectBoard.TabIndex = 0;
            this.mpmSelectBoard.Text = "Selection Board";
            this.mpmSelectBoard.UseVisualStyleBackColor = true;
            this.mpmSelectBoard.Click += new System.EventHandler(this.mpmSelectBoard_Click);
            // 
            // mpmFeedback
            // 
            this.mpmFeedback.Enabled = false;
            this.mpmFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mpmFeedback.Location = new System.Drawing.Point(5, 207);
            this.mpmFeedback.Name = "mpmFeedback";
            this.mpmFeedback.Size = new System.Drawing.Size(226, 45);
            this.mpmFeedback.TabIndex = 9;
            this.mpmFeedback.Text = "Feedback / Contact us";
            this.mpmFeedback.UseVisualStyleBackColor = true;
            this.mpmFeedback.Click += new System.EventHandler(this.mpmFeedback_Click);
            // 
            // mpmAboutUs
            // 
            this.mpmAboutUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mpmAboutUs.Location = new System.Drawing.Point(5, 156);
            this.mpmAboutUs.Name = "mpmAboutUs";
            this.mpmAboutUs.Size = new System.Drawing.Size(226, 45);
            this.mpmAboutUs.TabIndex = 10;
            this.mpmAboutUs.Text = "About Us";
            this.mpmAboutUs.UseVisualStyleBackColor = true;
            this.mpmAboutUs.Click += new System.EventHandler(this.mpmAboutUs_Click);
            // 
            // MainPageMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 308);
            this.Controls.Add(this.mpmAboutUs);
            this.Controls.Add(this.mpmFeedback);
            this.Controls.Add(this.mpmSelectBoard);
            this.Controls.Add(this.LabelTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mpmMessages);
            this.Controls.Add(this.mpmMyCars);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPageMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainPageMenu";
            this.Load += new System.EventHandler(this.MainPageMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPageMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mpmMessages;
        private System.Windows.Forms.Button mpmMyCars;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Button mpmSelectBoard;
        private System.Windows.Forms.Button mpmFeedback;
        private System.Windows.Forms.Button mpmAboutUs;
    }
}
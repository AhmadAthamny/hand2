namespace Hand2
{
    partial class Credits
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CopyRights = new System.Windows.Forms.Label();
            this.Hand2Pic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Hand2Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.CopyRights);
            this.panel1.Controls.Add(this.Hand2Pic);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 365);
            this.panel1.TabIndex = 0;
            // 
            // CopyRights
            // 
            this.CopyRights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CopyRights.Location = new System.Drawing.Point(0, 250);
            this.CopyRights.Name = "CopyRights";
            this.CopyRights.Size = new System.Drawing.Size(316, 24);
            this.CopyRights.TabIndex = 2;
            this.CopyRights.Text = "Copyrights Reserved To Hand2 (updating year)";
            this.CopyRights.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Hand2Pic
            // 
            this.Hand2Pic.Image = global::Hand2.Properties.Resources.anotherwhiteblack;
            this.Hand2Pic.Location = new System.Drawing.Point(21, 124);
            this.Hand2Pic.Name = "Hand2Pic";
            this.Hand2Pic.Size = new System.Drawing.Size(273, 126);
            this.Hand2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hand2Pic.TabIndex = 1;
            this.Hand2Pic.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hand2 - Rent And Sell";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(316, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Credits";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credits";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Credits_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Credits_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Hand2Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label CopyRights;
        private System.Windows.Forms.PictureBox Hand2Pic;
    }
}
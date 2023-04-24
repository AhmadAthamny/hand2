namespace Hand2
{
    partial class chooseBuyRent
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
            this.rentCar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buyCar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rentCar
            // 
            this.rentCar.Image = global::Hand2.Properties.Resources.rentcar;
            this.rentCar.Location = new System.Drawing.Point(362, 77);
            this.rentCar.Name = "rentCar";
            this.rentCar.Size = new System.Drawing.Size(338, 276);
            this.rentCar.TabIndex = 1;
            this.rentCar.UseVisualStyleBackColor = true;
            this.rentCar.Click += new System.EventHandler(this.rentCar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(91, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 73);
            this.label1.TabIndex = 2;
            this.label1.Text = "BUY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(430, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 73);
            this.label2.TabIndex = 3;
            this.label2.Text = "RENT";
            // 
            // buyCar
            // 
            this.buyCar.Image = global::Hand2.Properties.Resources.buycar;
            this.buyCar.Location = new System.Drawing.Point(12, 77);
            this.buyCar.Name = "buyCar";
            this.buyCar.Size = new System.Drawing.Size(338, 276);
            this.buyCar.TabIndex = 0;
            this.buyCar.UseVisualStyleBackColor = true;
            this.buyCar.Click += new System.EventHandler(this.buyCar_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.label4.Location = new System.Drawing.Point(419, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 10);
            this.label4.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.label3.Location = new System.Drawing.Point(73, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 10);
            this.label3.TabIndex = 4;
            // 
            // chooseBuyRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rentCar);
            this.Controls.Add(this.buyCar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "chooseBuyRent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chooseBuyRent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyCar;
        private System.Windows.Forms.Button rentCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
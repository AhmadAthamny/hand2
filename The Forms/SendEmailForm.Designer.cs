namespace Hand2
{
    partial class SendEmailForm
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
            this.seftxtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.seftxtContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sefLabelCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.seftxtTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // seftxtTo
            // 
            this.seftxtTo.Enabled = false;
            this.seftxtTo.Location = new System.Drawing.Point(115, 13);
            this.seftxtTo.Name = "seftxtTo";
            this.seftxtTo.Size = new System.Drawing.Size(432, 20);
            this.seftxtTo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(73, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // seftxtContent
            // 
            this.seftxtContent.Location = new System.Drawing.Point(115, 79);
            this.seftxtContent.Multiline = true;
            this.seftxtContent.Name = "seftxtContent";
            this.seftxtContent.Size = new System.Drawing.Size(432, 164);
            this.seftxtContent.TabIndex = 2;
            this.seftxtContent.TextChanged += new System.EventHandler(this.seftxtContent_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(42, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Content";
            // 
            // sefLabelCount
            // 
            this.sefLabelCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sefLabelCount.Location = new System.Drawing.Point(387, 258);
            this.sefLabelCount.Name = "sefLabelCount";
            this.sefLabelCount.Size = new System.Drawing.Size(160, 23);
            this.sefLabelCount.TabIndex = 4;
            this.sefLabelCount.Text = "0 / 2000";
            this.sefLabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(53, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subject";
            // 
            // seftxtTitle
            // 
            this.seftxtTitle.Location = new System.Drawing.Point(116, 45);
            this.seftxtTitle.Name = "seftxtTitle";
            this.seftxtTitle.Size = new System.Drawing.Size(432, 20);
            this.seftxtTitle.TabIndex = 1;
            // 
            // SendEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 290);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seftxtTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sefLabelCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seftxtContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seftxtTo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 329);
            this.MinimumSize = new System.Drawing.Size(610, 329);
            this.Name = "SendEmailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send Message";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendEmailForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox seftxtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox seftxtContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sefLabelCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox seftxtTitle;
    }
}
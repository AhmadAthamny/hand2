namespace Hand2
{
    partial class feedBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(feedBack));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fdbContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fdbType = new System.Windows.Forms.ComboBox();
            this.fdbWordCount = new System.Windows.Forms.Label();
            this.fdbSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feedback / Contact us";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(754, 102);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // fdbContent
            // 
            this.fdbContent.Location = new System.Drawing.Point(12, 182);
            this.fdbContent.MaxLength = 2000;
            this.fdbContent.Multiline = true;
            this.fdbContent.Name = "fdbContent";
            this.fdbContent.Size = new System.Drawing.Size(751, 158);
            this.fdbContent.TabIndex = 2;
            this.fdbContent.TextChanged += new System.EventHandler(this.fdbContent_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(13, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "What is this feedback for?";
            // 
            // fdbType
            // 
            this.fdbType.FormattingEnabled = true;
            this.fdbType.Items.AddRange(new object[] {
            "Feedback",
            "Help Request",
            "Bug Report",
            "User Report",
            "Other"});
            this.fdbType.Location = new System.Drawing.Point(179, 152);
            this.fdbType.Name = "fdbType";
            this.fdbType.Size = new System.Drawing.Size(121, 21);
            this.fdbType.TabIndex = 4;
            this.fdbType.Text = "Objective";
            // 
            // fdbWordCount
            // 
            this.fdbWordCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fdbWordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.fdbWordCount.Location = new System.Drawing.Point(667, 345);
            this.fdbWordCount.Name = "fdbWordCount";
            this.fdbWordCount.Size = new System.Drawing.Size(96, 16);
            this.fdbWordCount.TabIndex = 5;
            this.fdbWordCount.Text = "0 / 2000";
            this.fdbWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fdbSubmit
            // 
            this.fdbSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.fdbSubmit.Location = new System.Drawing.Point(12, 342);
            this.fdbSubmit.Name = "fdbSubmit";
            this.fdbSubmit.Size = new System.Drawing.Size(75, 23);
            this.fdbSubmit.TabIndex = 6;
            this.fdbSubmit.Text = "Submit";
            this.fdbSubmit.UseVisualStyleBackColor = true;
            this.fdbSubmit.Click += new System.EventHandler(this.fdbSubmit_Click);
            // 
            // feedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 370);
            this.Controls.Add(this.fdbSubmit);
            this.Controls.Add(this.fdbWordCount);
            this.Controls.Add(this.fdbType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fdbContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(795, 409);
            this.Name = "feedBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hand2 - Feedback / Contact us";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.feedBack_Closed);
            this.Load += new System.EventHandler(this.feedBack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fdbContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fdbType;
        private System.Windows.Forms.Label fdbWordCount;
        private System.Windows.Forms.Button fdbSubmit;
    }
}
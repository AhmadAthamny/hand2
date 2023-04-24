namespace Hand2
{
    partial class initPage
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
            this.usrText = new System.Windows.Forms.TextBox();
            this.usrLabel = new System.Windows.Forms.Label();
            this.pwLabel = new System.Windows.Forms.Label();
            this.noAccount = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.emailText = new System.Windows.Forms.TextBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.pass2Text = new System.Windows.Forms.TextBox();
            this.fnLabel = new System.Windows.Forms.Label();
            this.emlLabel = new System.Windows.Forms.Label();
            this.RpwLabel = new System.Windows.Forms.Label();
            this.cpwLabel = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pwForgotLabel = new System.Windows.Forms.Label();
            this.initPageBack = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idText = new System.Windows.Forms.TextBox();
            this.erProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pwText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.initPageBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // usrText
            // 
            this.usrText.Location = new System.Drawing.Point(135, 118);
            this.usrText.Name = "usrText";
            this.usrText.Size = new System.Drawing.Size(450, 19);
            this.usrText.TabIndex = 0;
            this.usrText.TextChanged += new System.EventHandler(this.usrText_TextChanged);
            // 
            // usrLabel
            // 
            this.usrLabel.AutoSize = true;
            this.usrLabel.BackColor = System.Drawing.Color.Transparent;
            this.usrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.usrLabel.ForeColor = System.Drawing.Color.Transparent;
            this.usrLabel.Location = new System.Drawing.Point(28, 115);
            this.usrLabel.Name = "usrLabel";
            this.usrLabel.Size = new System.Drawing.Size(83, 20);
            this.usrLabel.TabIndex = 1;
            this.usrLabel.Text = "Username";
            // 
            // pwLabel
            // 
            this.pwLabel.AutoSize = true;
            this.pwLabel.BackColor = System.Drawing.Color.Transparent;
            this.pwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pwLabel.ForeColor = System.Drawing.Color.Transparent;
            this.pwLabel.Location = new System.Drawing.Point(33, 151);
            this.pwLabel.Name = "pwLabel";
            this.pwLabel.Size = new System.Drawing.Size(78, 20);
            this.pwLabel.TabIndex = 3;
            this.pwLabel.Text = "Password";
            // 
            // noAccount
            // 
            this.noAccount.AutoSize = true;
            this.noAccount.BackColor = System.Drawing.Color.Transparent;
            this.noAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.noAccount.ForeColor = System.Drawing.Color.Transparent;
            this.noAccount.Location = new System.Drawing.Point(16, 268);
            this.noAccount.Name = "noAccount";
            this.noAccount.Size = new System.Drawing.Size(328, 20);
            this.noAccount.TabIndex = 4;
            this.noAccount.Text = "Don\'t have an account? Register below!";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(148, 301);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(450, 19);
            this.nameText.TabIndex = 5;
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(148, 326);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(450, 19);
            this.emailText.TabIndex = 6;
            // 
            // passText
            // 
            this.passText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.passText.Location = new System.Drawing.Point(148, 378);
            this.passText.MaxLength = 32;
            this.passText.Name = "passText";
            this.passText.PasswordChar = '•';
            this.passText.Size = new System.Drawing.Size(450, 21);
            this.passText.TabIndex = 8;
            // 
            // pass2Text
            // 
            this.pass2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pass2Text.Location = new System.Drawing.Point(148, 406);
            this.pass2Text.MaxLength = 32;
            this.pass2Text.Name = "pass2Text";
            this.pass2Text.PasswordChar = '•';
            this.pass2Text.Size = new System.Drawing.Size(450, 21);
            this.pass2Text.TabIndex = 9;
            // 
            // fnLabel
            // 
            this.fnLabel.AutoSize = true;
            this.fnLabel.BackColor = System.Drawing.Color.Transparent;
            this.fnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.fnLabel.ForeColor = System.Drawing.Color.Transparent;
            this.fnLabel.Location = new System.Drawing.Point(33, 299);
            this.fnLabel.Name = "fnLabel";
            this.fnLabel.Size = new System.Drawing.Size(80, 20);
            this.fnLabel.TabIndex = 9;
            this.fnLabel.Text = "Full Name";
            // 
            // emlLabel
            // 
            this.emlLabel.AutoSize = true;
            this.emlLabel.BackColor = System.Drawing.Color.Transparent;
            this.emlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.emlLabel.ForeColor = System.Drawing.Color.Transparent;
            this.emlLabel.Location = new System.Drawing.Point(65, 326);
            this.emlLabel.Name = "emlLabel";
            this.emlLabel.Size = new System.Drawing.Size(48, 20);
            this.emlLabel.TabIndex = 10;
            this.emlLabel.Text = "Email";
            // 
            // RpwLabel
            // 
            this.RpwLabel.AutoSize = true;
            this.RpwLabel.BackColor = System.Drawing.Color.Transparent;
            this.RpwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RpwLabel.ForeColor = System.Drawing.Color.Transparent;
            this.RpwLabel.Location = new System.Drawing.Point(35, 374);
            this.RpwLabel.Name = "RpwLabel";
            this.RpwLabel.Size = new System.Drawing.Size(78, 20);
            this.RpwLabel.TabIndex = 11;
            this.RpwLabel.Text = "Password";
            // 
            // cpwLabel
            // 
            this.cpwLabel.AutoSize = true;
            this.cpwLabel.BackColor = System.Drawing.Color.Transparent;
            this.cpwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cpwLabel.ForeColor = System.Drawing.Color.Transparent;
            this.cpwLabel.Location = new System.Drawing.Point(2, 402);
            this.cpwLabel.Name = "cpwLabel";
            this.cpwLabel.Size = new System.Drawing.Size(111, 20);
            this.cpwLabel.TabIndex = 12;
            this.cpwLabel.Text = "Con Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLogin.Location = new System.Drawing.Point(135, 179);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(450, 45);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRegister.Location = new System.Drawing.Point(148, 433);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(450, 39);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pwForgotLabel
            // 
            this.pwForgotLabel.AutoSize = true;
            this.pwForgotLabel.BackColor = System.Drawing.Color.Transparent;
            this.pwForgotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pwForgotLabel.ForeColor = System.Drawing.Color.White;
            this.pwForgotLabel.Location = new System.Drawing.Point(205, 227);
            this.pwForgotLabel.Name = "pwForgotLabel";
            this.pwForgotLabel.Size = new System.Drawing.Size(244, 20);
            this.pwForgotLabel.TabIndex = 16;
            this.pwForgotLabel.Text = "Forgot your password? Click here";
            this.pwForgotLabel.Click += new System.EventHandler(this.pwForgotLabel_Click);
            // 
            // initPageBack
            // 
            this.initPageBack.BackColor = System.Drawing.Color.Transparent;
            this.initPageBack.Image = global::Hand2.Properties.Resources.rsz_2000px_back_arrowsvg;
            this.initPageBack.Location = new System.Drawing.Point(12, 12);
            this.initPageBack.Name = "initPageBack";
            this.initPageBack.Size = new System.Drawing.Size(45, 45);
            this.initPageBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.initPageBack.TabIndex = 17;
            this.initPageBack.TabStop = false;
            this.initPageBack.Click += new System.EventHandler(this.initPageBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(49, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Your ID";
            // 
            // idText
            // 
            this.idText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.idText.Location = new System.Drawing.Point(148, 351);
            this.idText.MaxLength = 32;
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(450, 21);
            this.idText.TabIndex = 7;
            // 
            // erProvider
            // 
            this.erProvider.BlinkRate = 150;
            this.erProvider.ContainerControl = this;
            // 
            // pwText
            // 
            this.pwText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pwText.Location = new System.Drawing.Point(135, 150);
            this.pwText.MaxLength = 32;
            this.pwText.Name = "pwText";
            this.pwText.PasswordChar = '•';
            this.pwText.Size = new System.Drawing.Size(450, 21);
            this.pwText.TabIndex = 1;
            // 
            // initPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Hand2.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(740, 476);
            this.Controls.Add(this.pwText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idText);
            this.Controls.Add(this.initPageBack);
            this.Controls.Add(this.pwForgotLabel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cpwLabel);
            this.Controls.Add(this.RpwLabel);
            this.Controls.Add(this.emlLabel);
            this.Controls.Add(this.fnLabel);
            this.Controls.Add(this.pass2Text);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.noAccount);
            this.Controls.Add(this.pwLabel);
            this.Controls.Add(this.usrLabel);
            this.Controls.Add(this.usrText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1076, 515);
            this.MinimumSize = new System.Drawing.Size(756, 515);
            this.Name = "initPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hand2 - Membership board";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.initPage_FormClosed);
            this.Load += new System.EventHandler(this.initPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.initPageBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usrText;
        private System.Windows.Forms.Label usrLabel;
        private System.Windows.Forms.Label pwLabel;
        private System.Windows.Forms.Label noAccount;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.TextBox pass2Text;
        private System.Windows.Forms.Label fnLabel;
        private System.Windows.Forms.Label emlLabel;
        private System.Windows.Forms.Label RpwLabel;
        private System.Windows.Forms.Label cpwLabel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label pwForgotLabel;
        private System.Windows.Forms.PictureBox initPageBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.ErrorProvider erProvider;
        private System.Windows.Forms.TextBox pwText;

    }
}
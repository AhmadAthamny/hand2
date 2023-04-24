using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hand2
{
    public partial class changePw : Form
    {
        User usr;
        initPage the_mainpage;
        public changePw(User u, initPage mp_temp)
        {
            InitializeComponent();
            usr = u;
            the_mainpage = mp_temp;
        }

        private void changePw_Load(object sender, EventArgs e)
        {

        }

        private void doneNewPw_Click(object sender, EventArgs e)
        {
            if (usr.code != verifyCode.Text) MessageBox.Show("Incorrect verfication code.");
            else if (newPw1.Text.Length < 6 || newPw1.Text.Length > 32) MessageBox.Show("Minimum password is 6, and max is 32.");
            else if (newPw1.Text != newPw2.Text) MessageBox.Show("Both passwords don't match.");
            else
            {
                DbUser db = new DbUser();
                SqlCommand sqlString = new SqlCommand("update users set password=@password, verified=1, code=null where email=@email", db.cnn);
                sqlString.Parameters.AddWithValue("@password", newPw1.Text);
                sqlString.Parameters.AddWithValue("@email", usr.email);
                db.InsDelUpd(sqlString);
                MessageBox.Show("Your password has been changed successfully.");
                this.Close();
            }
        }

        private void codeChecker_Tick(object sender, EventArgs e)
        {
            if(Clipboard.ContainsText(TextDataFormat.Text))
                if(Clipboard.GetText(TextDataFormat.Text) == usr.code) 
                {
                    verifyCode.Text = usr.code;
                    truemarkIcon.Visible = true;
                    verifyCode.Enabled = false;
                    codeChecker.Enabled = false;
                }
        }

        private void newPw2_TextChanged(object sender, EventArgs e)
        {
            if ((newPw2.Text == newPw1.Text) && (newPw1.Text.Length >= 6 && newPw1.Text.Length <= 32))
            {
                truemarkIcon2.Visible = true;
                if (truemarkIcon.Visible == true)
                    doneNewPw.Enabled = true;
            }
            else if (truemarkIcon2.Visible == true)
            {
                truemarkIcon2.Visible = false;
                doneNewPw.Enabled = false;
            }
        }

        private void verifyCode_TextChanged(object sender, EventArgs e)
        {
            if (usr.code == verifyCode.Text)
            {
                truemarkIcon.Visible = true;
                verifyCode.Enabled = false;
                codeChecker.Enabled = false;
                if (truemarkIcon2.Visible == true)
                    doneNewPw.Enabled = true;
            }
        }

        private void changePw_FormClosed(object sender, FormClosedEventArgs e)
        {
            the_mainpage.Enabled = true;
        }

        private void newPw1_TextChanged(object sender, EventArgs e)
        {
            if ((newPw2.Text == newPw1.Text) && (newPw1.Text.Length >= 6 && newPw1.Text.Length <= 32))
            {
                truemarkIcon2.Visible = true;
                if (truemarkIcon.Visible == true)
                    doneNewPw.Enabled = true;
            }
            else if (truemarkIcon2.Visible == true)
            {
                truemarkIcon2.Visible = false;
                doneNewPw.Enabled = false;
            }
        }
    }
}

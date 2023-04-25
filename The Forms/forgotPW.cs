using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hand2
{
    public partial class forgotPW : Form
    {
        initPage the_mainpage;
        public forgotPW(initPage mp_temp)
        {
            InitializeComponent();
            the_mainpage = mp_temp;
        }

        private void fgtpwSendCode_Click(object sender, EventArgs e)
        {

            initPage ip = new initPage(null, 0);
            if (ip.IsNetworkAvailable())
            {
                User u = new User();
                DbUser db = new DbUser();
                u.email = forgotpwEmail.Text;
                if (db.Found(u.email))
                {
                    string name = db.getUserName(u.email);
                    u.code = db.generateVerifyCode(u);
                    string content = "<center><h2>Hand2 Password Recovery</h2>" +
                        "Hello " + name + ", This message is for your password recovery, if you didn't ask to change<br>" +
                        "your password, then you can simply ignore this message, and we highly recommend you to change the password regularly.<br>" +
                        "Here's the code you need in order to create a new password for your account:<br>" +
                        "<b>" + u.code + "</b>" +
                        "<br><br><i>Hand2 © Copyrights reserved to Hand2, " + DateTime.Now.Year + "</i>";
                    ip.SendEmail(u.email, "Password Recovery", content);
                    changePw thewin = new changePw(u, the_mainpage);
                    thewin.Show();
                    MessageBox.Show("A verfication code has been sent to your email, \npaste it in the box below.");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("This user doesn't exist.");
                }
            }
            else
                MessageBox.Show("Sorry, you need to be connected to the internet first.");
        }

        private void forgotpwEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void forgotPW_FormClosed(object sender, FormClosedEventArgs e)
        {
            the_mainpage.Enabled = true;
        }

        private void forgotPW_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class SendEmailForm : Form
    {
        User u;
        User to;
        Cars car;
        Form fopenedfrom;
        public SendEmailForm(User utemp, User target, Form openedFrom, Cars cartalking = null)
        {
            InitializeComponent();
            this.seftxtContent.MaxLength = 2000;
            this.seftxtContent.ScrollBars = ScrollBars.Vertical;
            this.seftxtTo.Text = target.name;
            this.seftxtContent.Text = "";
            this.seftxtTitle.Text = "";
            u = utemp;
            to = target;
            car = cartalking;
            fopenedfrom = openedFrom;
        }

        private void seftxtContent_TextChanged(object sender, EventArgs e)
        {
            sefLabelCount.Text = seftxtContent.Text.Length.ToString() + " / 2000";
        }

        private void SendEmailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(fopenedfrom != null)
                fopenedfrom.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbUser dbuser = new DbUser();
            initPage ip = new initPage(null, 0);
            if (seftxtTitle.Text.Length < 3) MessageBox.Show("The subject you entered is too short.");
            else if (seftxtContent.Text.Length > 2000) MessageBox.Show("The content you've entered has exceeded the maximum text length.");
            else if (seftxtContent.Text.Length < 6) MessageBox.Show("The content you entered is too short.");
            else if (!ip.IsNetworkAvailable()) MessageBox.Show("Sorry, you need to be connected to the internet first.");
            else
            {
                string content = "<center><h2>Hand2 - You receieved a message</h2>" +
                        "Hello " + to.name + ", We want to inform you that you've recieved a message from " + u.name + "<br>";
                if (car != null) content += "The message was sent for the " + car.company + " " + car.version + " that you're selling.<br><br>";

                content += "You can view the full message in our Hand2 software after logging in your account." +
               "<br><br><i>Hand2 © Copyrights reserved to Hand2, " + DateTime.Now.Year + "</i>";
                ip.SendEmail(to.email, "Hand2 - You've receieved a message.", content);
                dbuser.addMessage(u, to, seftxtContent.Text, seftxtTitle.Text);
                this.Close();
                MessageBox.Show("Message has been sent successfully.");
            }
        }
    }
}

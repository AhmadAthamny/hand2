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
    public partial class messageDisplay : Form
    {
        viewMessages msginfo;
        viewMessages theform;
        bool canReply = true;
        User u;
        public messageDisplay(viewMessages msginfo_temp, viewMessages this_form, User u_temp)
        {
            msginfo = msginfo_temp;
            InitializeComponent();
            u = u_temp;
            theform = this_form;
        }

        private void messageDisplay_Load(object sender, EventArgs e)
        {
            DbUser db = new DbUser();
            string thename;
            if (msginfo.toid == -1)
            {
                thename = msginfo.title;
                this.mdTitle.Text = thename;
                this.mdFrom.Text = string.Empty;
                this.mdContent.Location = new Point(this.mdContent.Location.X, 54);
                this.mdDate.Location = new Point(this.mdDate.Location.X, 22);
                this.replyButton.Location = new Point(this.replyButton.Location.X, 303);
                this.Size = new Size(this.Size.Width, 318);
                canReply = false;
            }

            else if (msginfo.fromid == u.id)
            {
                thename = "To: " + db.getUserNamebyID(msginfo.toid);
                canReply = false;
            }
            else
            {
                if (msginfo.fromid == -1)
                {
                    thename = "Hand2";
                    canReply = false;
                }
                else
                    thename = "From: " + db.getUserNamebyID(msginfo.fromid);
            }
            if (msginfo.toid != -1)
            {
                this.mdTitle.Text = msginfo.title;
                this.mdFrom.Text = thename;
            }
            this.mdDate.Text = msginfo.date.ToString();
            this.mdContent.Text = msginfo.content;

            if (canReply == true)
                this.replyButton.Enabled = true;
        }

        private void messageDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            theform.Enabled = true;
        }

        private void replyButton_Click(object sender, EventArgs e)
        {
            DbUser dbuser = new DbUser();
            User toID = dbuser.returnUserInfoByID(msginfo.fromid);
            SendEmailForm sEF = new SendEmailForm(this.u, toID, null, null);
            this.Close();
            sEF.Show();
        }
    }
}

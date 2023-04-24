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
    public partial class RespondOrView : Form
    {
        reports r;
        AdminForm sourceform;
        User u;
        public RespondOrView(reports report, User u, AdminForm source_form)
        {
            InitializeComponent();
            this.r = report;
            this.sourceform = source_form;
            this.u = u;
            FRTO.Text = this.r.sender_id.ToString();
            FRID.Text = this.r.id.ToString();
            if (this.r.response_id != -1)
            {
                DbUser db = new DbUser();
                viewMessages vm = new viewMessages();
                FRContent.Text = vm.returnMessageInfo(r.response_id).content;
                FRResponseBy.Text = db.returnUserInfoByID(vm.returnMessageInfo(r.response_id).fromid).name;
                FRSubmit.Enabled = false;
                FRSendMails.Enabled = false;
            }
            else
            {
                FRResponseBy.Text = u.name;
                FRContent.ReadOnly = false;
                FRSubmit.Enabled = true;
                FRSendMails.Enabled = true;
            }
        }

        private void FR_TextChanged(object sender, EventArgs e)
        {
            FRCount.Text = FRContent.TextLength.ToString() + " / " + FRContent.MaxLength.ToString();
        }

        private void RespondOrView_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceform.Enabled = true;
            sourceform.FeedbackRefreshList();
        }

        private void FRSubmit_Click(object sender, EventArgs e)
        {
            if (FRContent.TextLength < 5) MessageBox.Show("Sorry, the text you've entered is too short.");
            else
            {
                if (FRTO.TextLength != 0 && FRResponseBy.TextLength != 0)
                {
                    DbUser db = new DbUser();
                    User touser = new User();
                    int response_id = -1;
                    touser = db.returnUserInfoByID(r.sender_id);
                    response_id = db.addMessage(u, touser, FRContent.Text, "Response to your report");
                    if (FRSendMails.Checked)
                    {
                        initPage ip = new initPage();
                        if (ip.IsNetworkAvailable())
                        {
                            string content = "<center><h2>Hand2 - Response to your report</h2></center>" +
                            FRContent.Text + "<center><br><br><i>Hand2 © Copyrights reserved to Hand2, " + DateTime.Now.Year + "</i></center>";
                            content = content.Replace("\r\n", "<br>");
                            ip.SendEmail(touser.email, "Response to your sent report", content);
                        }
                        else
                            MessageBox.Show("Email wasn't sent due to network problems.");
                    }
                    Admin ad = new Admin();
                    ad.updateReportResponseID(r.id, response_id);
                    MessageBox.Show("You have successfully responded to the report.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sorry, there was a problem. Try again.");
                    this.Close();
                }
            }
        } 
    }
}

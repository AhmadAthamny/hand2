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
    public partial class feedBack : Form
    {
 
        //Feedback Types: 
        public int feedbackType_feedback = 0;
        public int feedbackType_helpRequest = 1;
        public int feedbackType_bugReport = 2;
        public int feedbackType_userReport = 3;
        public int feedbackType_other = 4;
        User u;
        int target_id;
        public int f_type;
        Form to_return;
        Loading lding = null;
        public feedBack(User u_tmp, int target, Form to_return_tmp, int f_typetemp = -1)
        {
            lding = new Loading();
            lding.Show();
            InitializeComponent();

            u = u_tmp;
            target_id = target;
            to_return = to_return_tmp;
            f_type = f_typetemp;
        }

        private void fdbSubmit_Click(object sender, EventArgs e)
        {
            if (fdbType.SelectedIndex == -1) MessageBox.Show("Sorry, you need to select the objective of this message.\n\nChoose \"Other\" if there's no specified reason for it.");
            else if (fdbContent.TextLength < 10) MessageBox.Show("Sorry, the content is too short.");
            else
            {
                Admin ad = new Admin();
                ad.InsertReport(u.id, target_id, fdbContent.Text, fdbType.SelectedIndex);
                this.Close();
                MessageBox.Show("Your feedback has been submitted successfully.\n\nWe will respond as soon as possible. Thank you!");
            }
        }
        private void feedBack_Closed(object sender, EventArgs e)
        {
            to_return.Enabled = true;
        }

        private void feedBack_Load(object sender, EventArgs e)
        {
            lding.Close();
            if (f_type != -1)
            {
                fdbType.SelectedIndex = f_type;
                fdbType.Enabled = false;
            }
        }

        private void fdbContent_TextChanged(object sender, EventArgs e)
        {
            fdbWordCount.Text = fdbContent.TextLength.ToString() + " / " + fdbContent.MaxLength.ToString();
        }

    }
}

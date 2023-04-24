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
    public partial class MainPageMenu : Form
    {
        User u;
        mainPage mp;
        public MainPageMenu(User utemp, mainPage mp2)
        {
            InitializeComponent();
            u = utemp;
            mp = mp2;
            if (utemp.id != -1)
            {
                mpmMyCars.Enabled = true;
                mpmMessages.Enabled = true;
                mpmFeedback.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void MainPageMenu_Load(object sender, EventArgs e)
        {
            if (u.id != -1)
            {
                viewMessages vm = new viewMessages(u, mp);
                int totalmsgs = vm.GetUserUnreadMessages(u);
                if (totalmsgs > 0)
                {
                    LabelTotal.Visible = true;
                    LabelTotal.Text = totalmsgs.ToString();
                }
            }
        }

        private void MainPageMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                mp.Enabled = true;
            }
        }

        public void mpmMyCars_Click(object sender, EventArgs e)
        {
            mp.Enabled = true;
            if (mp.buyOrRent == 0)
            {
                SqlCommand query = new SqlCommand("select * from cars where userid=@userid", new DbCars().cnn);
                query.Parameters.AddWithValue("@userid", u.id);
                mp.init(query);
                mp.updateCarInfo(-1);
            }
            else
            {
                DbCars db = new DbCars();
                mp.init_rent(db.getUserRentedCarsQuery(u));
            }
            this.Close();
        }
        private void mpmMessages_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            viewMessages vm = new viewMessages(u, mp);
            vm.ShowDialog(mp);
        }

        private void mpmReports_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.id = -1;
            u.verified = -1;
            u.level = 0;
            u.viewingCarID = -1;
            u.name = "Guest";
            this.Close();
            mp.Close();
            mainPage nmp = new mainPage(u, mp.buyOrRent);
            nmp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mpmSelectBoard_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.Close();
            chooseBuyRent cbr = new chooseBuyRent(u);
            cbr.Show();
        }

        private void mpmFeedback_Click(object sender, EventArgs e)
        {
            this.Close();
            feedBack fb = new feedBack(u, -1, mp);
            fb.ShowDialog(mp);
        }

        private void mpmAboutUs_Click(object sender, EventArgs e)
        {
            this.Close();
            aboutUs aus = new aboutUs(mp);
            aus.ShowDialog(mp);
        }
    }
}

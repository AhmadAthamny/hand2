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
    public partial class chooseBuyRent : Form
    {
        User u;
        public chooseBuyRent(User utmp)
        {
            u = utmp;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buyCar_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainPage mp = new mainPage(u, 0);
            mp.Show();
        }

        private void rentCar_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainPage mp = new mainPage(u, 1);
            mp.Show();
        }
    }
}

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
    public partial class carRentFullPicture : Form
    {
        mainPage theback;
        public carRentFullPicture(mainPage tmp)
        {
            InitializeComponent();
            theback = tmp;
        }

        private void carRentFullPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            theback.Enabled = true;
            this.Enabled = false;
        }

        private void CarRentFullPicture_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                theback.Enabled = true;
            }
        }
    }
}

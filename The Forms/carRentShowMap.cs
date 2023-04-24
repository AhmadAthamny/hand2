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
    public partial class carRentShowMap : Form
    {
        mainPage tobebackto;
        public carRentShowMap(mainPage mainpagetmp)
        {
            InitializeComponent();
            tobebackto = mainpagetmp;
        }

        private void carRentShowMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            tobebackto.Enabled = true;
            this.Close();
        }

        private void carRentShowMap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                tobebackto.Enabled = true;
            }
        }
    }
}

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
    public partial class CarRentPeriods : Form
    {
        Form thesource;
        public CarRentPeriods(Form the_source)
        {
            InitializeComponent();
            this.thesource = the_source;
        }

        private void CarRentPeriods_FormClosed(object sender, FormClosedEventArgs e)
        {
            thesource.Enabled = true;
        }
    }
}

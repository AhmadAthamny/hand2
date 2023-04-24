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
    public partial class aboutUs : Form
    {
        Form sourceform;
        public aboutUs(Form source_form)
        {
            sourceform = source_form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Credits crdt = new Credits(this);
            crdt.Show();
        }

        private void aboutUs_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceform.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            BigCEOPicture bcp = new BigCEOPicture(this);
            bcp.Show();
        }
    }
}

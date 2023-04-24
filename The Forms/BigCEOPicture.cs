using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Hand2
{
    public partial class BigCEOPicture : Form
    {
        Form scfm;
        Loading loadingform = null;
        public BigCEOPicture(Form sourceform)
        {
            loadingform = new Loading();
            loadingform.Show();

            InitializeComponent();            
            this.scfm = sourceform;
        }

        private void BigCEOPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            scfm.Enabled = true;
        }

        private void BigCEOPicture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void BigCEOPicture_Load(object sender, EventArgs e)
        {
            initPage ip = new initPage();
            if (ip.IsNetworkAvailable())
            {
                ServicePointManager.Expect100Continue = true; /// To prevent http connection request errors.
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; /// To prevent http connection request errors.

                try
                {
                    pictureBox1.Load("http://page.photos/Hand2_AhmedAtamny");
                }
                catch
                {
                    setPictureToMe(); /// So if anything wrong goes with the redirecting website, it sets the picture to me, and that's to avoid any crashes in the program.
                }
            }
            else
                setPictureToMe(); /// If user isn't even connected to the internet, then simply show the "me" picture.

            this.CenterToScreen();
            loadingform.Close();

            this.Size = pictureBox1.Size;
            this.MaximumSize = this.Size;
        }
        private void setPictureToMe()
        {
            pictureBox1.Image = Hand2.Properties.Resources.me;
        }
    }
}

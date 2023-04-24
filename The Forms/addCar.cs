using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hand2
{
    public partial class addCar : Form
    {
        User u;
        int buyOrRent;
        Loading lding = null;
        public addCar(User tmpUser, int buyOrRent2)
        {
            InitializeComponent();
            lding = new Loading();
            lding.Show();

            u = tmpUser;
            buyOrRent = buyOrRent2;
        }
        byte[] acCarImageData = null;
        private void txtacPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.Title = "C# - Select photo for car" ;
            fdialog.InitialDirectory = @"c:\" ;
            fdialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                acCarImageData = ReadFile(fdialog.FileName);
                acCarPicture.ImageLocation = fdialog.FileName;
            }
        }
        private void acAddCarButton_OnClick(object sender, EventArgs e)
        {
            if (u.id == -1)
            {
                this.Hide();
                MessageBox.Show("You must be logged in to add cars.");
            }
            bool success = true;
            Cars c = new Cars();
            DbCars db = new DbCars();
            try
            {
                c.year = int.Parse(txtacYear.Text);
                c.kilometers = int.Parse(txtacKilos.Text);
                c.hand = int.Parse(txtacHand.Text);
                c.price = int.Parse(txtacPrice.Text);
            }
            catch
            {
                MessageBox.Show("Make sure you've filled everything correctly.");
                success = false;
            }
            if (success)
            {
                c.cartype = txtacCarType.SelectedIndex;
                c.company = txtacCompany.Text;
                c.version = txtacVersion.Text;
                c.geartype = txtacGearType.Text;
                c.gastype = txtacGasType.Text;
                c.color = txtacColor.Text;
                c.pic = acCarImageData;
                c.sellerid = u.id;
                c.description = txtacDescription.Text;
                if (txtacGearType.SelectedIndex == -1 || txtacGasType.SelectedIndex == -1 || txtacCompany.SelectedIndex == -1 || c.cartype == -1 || c.company.Length == 0 || c.version.Length == 0 || c.geartype.Length == 0 || c.gastype.Length == 0 || c.color.Length == 0 || !(c.pic != null && c.pic.Length > 0) || c.description.Length == 0)
                {
                    MessageBox.Show("Make sure you've filled everything correctly.");
                    success = false;
                }
                else
                {
                    int carid_log = db.InsertCar(c);
                    string content = "{_userid_} has added a new car (ID "+carid_log+")";
                    Admin dbadmin = new Admin(4, c.sellerid, content);
                    
                    dbadmin.InsertLog(dbadmin);
                    this.Hide();
                    mainPage mp = new mainPage(u, this.buyOrRent);
                    mp.Show();
                    MessageBox.Show("Added new car.\n\nPlease wait until an admin approves your new car.\n\nThanks!");
                }
            }
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        string PrintBytes(byte[] byteArray)
        {
            var sb = new StringBuilder("new byte[] { ");
            for (var i = 0; i < byteArray.Length; i++)
            {
                var b = byteArray[i];
                sb.Append(b);
                if (i < byteArray.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }

        private void addcarBack_Click(object sender, EventArgs e)
        {
            mainPage mp = new mainPage(u, this.buyOrRent);
            this.Hide();
            mp.Show();
        }

        private void addCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainPage mp = new mainPage(u, this.buyOrRent);
            this.Hide();
            mp.Show();
        }

        private void addCar_Load(object sender, EventArgs e)
        {
            lding.Close();
        }
    }
}

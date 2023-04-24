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
    public partial class editCar : Form
    {
        User u;
        Cars c_forcheck;
        mainPage themainpage;
        carDisplayInfo theclicked;
        Loading lding = null;
        byte[] acCarImageData = null;
        public editCar(User utemp, Cars ctemp, mainPage tempmain, carDisplayInfo the_clickedtemp)
        {
            lding = new Loading();
            lding.Show();
            u = utemp;
            c_forcheck = ctemp;
            themainpage = tempmain;
            theclicked = the_clickedtemp;
            InitializeComponent();
        }

        private void editCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            themainpage.Enabled = true;
            this.Close();
        }

        private void acCarPicture_Click(object sender, EventArgs e)
        {

        }

        private void editCar_Leave(object sender, EventArgs e)
        {

        }

        private void editCar_Load(object sender, EventArgs e)
        {
            lding.Close();
            this.Text = "Edit Car - " + c_forcheck.company + " " + c_forcheck.version;
            txtacCarType.SelectedIndex = c_forcheck.cartype; ;
            txtacCompany.Text = c_forcheck.company;
            txtacVersion.Text = c_forcheck.version;
            txtacYear.Text = c_forcheck.year.ToString();
            txtacPrice.Text = c_forcheck.price.ToString();
            txtacGearType.Text = c_forcheck.geartype;
            txtacGasType.Text = c_forcheck.gastype;
            txtacKilos.Text = c_forcheck.kilometers.ToString();
            txtacColor.Text = c_forcheck.color;
            txtacHand.Text = c_forcheck.hand.ToString();
            txtacDescription.Text = c_forcheck.description;
            acCarPicture.Image = byteArrayToImage(c_forcheck.pic);
        }
        private void txtacPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.Title = "C# Corner Open File Dialog";
            fdialog.InitialDirectory = @"c:\";
            fdialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                acCarImageData = ReadFile(fdialog.FileName);
                acCarPicture.ImageLocation = fdialog.FileName;
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
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }

        private void acAddCarButton_Click(object sender, EventArgs e)
        {
            DbCars pp = new DbCars();
            if (u.id == -1)
            {
                this.Hide();
                MessageBox.Show("You must be logged in to edit cars.");
            }
            else if (editCarPass.Text != u.password)
            {
                MessageBox.Show("You've entered a wrong password.");
            }
            else if (pp.returnCarInfo(c_forcheck.id).status != 3)
            {
                this.Hide();
                MessageBox.Show("Sorry, you cannot edit this car right now because of its status. "+pp.returnCarInfo(c_forcheck.id).status);
            }
            else
            {
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
                    c.id = c_forcheck.id;
                    c.cartype = txtacCarType.SelectedIndex;
                    c.company = txtacCompany.Text;
                    c.version = txtacVersion.Text;
                    c.geartype = txtacGearType.Text;
                    c.gastype = txtacGasType.Text;
                    c.color = txtacColor.Text;
                    c.sellerid = c_forcheck.sellerid;
                    c.status = c_forcheck.status;
                    if (acCarImageData == null)
                        c.pic = c_forcheck.pic;
                    else
                        c.pic = acCarImageData;
                    c.description = txtacDescription.Text;
                    if (txtacGearType.SelectedIndex == -1 || txtacGasType.SelectedIndex == -1 || txtacCompany.SelectedIndex == -1 || c.cartype == -1 || c.company.Length == 0 || c.version.Length == 0 || c.geartype.Length == 0 || c.gastype.Length == 0 || c.color.Length == 0 || !(c.pic != null && c.pic.Length > 0) || c.description.Length == 0)
                    {
                        MessageBox.Show("Make sure you've filled everything correctly.");
                        success = false;
                    }
                    else
                    {
                        string content = "{_userid_} has edited car ID " + c.id;
                        Admin dbadmin = new Admin(0, u.id, content);
                        db.updateCar(c);
                        dbadmin.InsertLog(dbadmin);
                        MessageBox.Show("Changes were saved successfully!");
                        this.Hide();
                        this.themainpage.Enabled = true;
                        this.themainpage.updateCarInfo(c_forcheck.id);
                        this.themainpage.updateCarDisplayInfo(theclicked, c);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCars pp = new DbCars();
            Cars nowcar = pp.returnCarInfo(c_forcheck.id);
            if (u.id == -1)
            {
                this.Hide();
                MessageBox.Show("You must be logged in to delete cars.");
            }
            else if (editCarPass.Text != u.password)
            {
                MessageBox.Show("You've entered a wrong password.");
            }
            else if (nowcar.status != 3 && nowcar.status != 0)
            {
                this.Hide();
                MessageBox.Show("Sorry, you cannot delete this car right now because of its status.");
            }
            else
            {
                string content = "{_userid_} has deleted his car(" + c_forcheck.id + ")";
                Admin dbadmin = new Admin(2, u.id, content);
                c_forcheck.status = 2;
                pp.updateCar(c_forcheck);
                dbadmin.InsertLog(dbadmin);
                MessageBox.Show("Your car has been hidden from others successfully!");
                this.Hide();
                this.themainpage.Enabled = true;
                this.themainpage.updateCarDisplayInfo(theclicked, c_forcheck);
            }
        }
    }
}

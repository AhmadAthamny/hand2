using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.NetworkInformation;

namespace Hand2
{
    public partial class AdminForm : Form
    {
        string API_KEY = "81GJA929K12G@$"; // DONT CHANGE THIS
        User u;
        int buyOrRent;
        int selectedRow = -1;
        Admin ad = new Admin();
        ComboBox MRCStation = new ComboBox();
        byte[] acCarImageData = null;
        byte[] acCarImageData2 = null;
        public SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();

        Loading lding = null;
        public AdminForm(User utemp, int buyOrRenttmp)
        {
            lding = new Loading();
            lding.Show();

            InitializeComponent();
            u = utemp;
            buyOrRent = buyOrRenttmp;
            MRCYear.Maximum = DateTime.Now.Year;
            MCYear.Maximum = DateTime.Now.Year;
            BRDLevel.Text = "Everyone";
            cnn.ConnectionString = new sqlConnection().returnConnectionString();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            updateSelectedTab();
            if (ad.CanManageStations(u))
            {
                btnesSaveAllChanges.Enabled = true;
                btnAddStation.Enabled = true;
            }
            if (ad.CanManageRentCars(u))
            {
                MRCAddNew.Enabled = true;
                MRCSave.Enabled = true;
            }

            if (ad.CanManageCars(u))
            {
                MCSave.Enabled = true;
                MCDeleteCar.Enabled = true;
            }

            if (ad.CanSendMessageToAll(u))
                BRDSend.Enabled = true;

            if (ad.CanManageUsers(u))
                MADSave.Enabled = true;

            VLFromDate.Value = DateTime.Now.AddDays(-14);
            VLToDate.Value = DateTime.Now;

            dbRentStations dbrs = new dbRentStations();
            DbCars db = new DbCars();
            dataGridView1.DataSource = dbrs.returnAllStations().Tables[0];
            dataGridView2.DataSource = db.returnAllRentCars().Tables[0];
            dataGridView3.DataSource = db.dgv_returnAllCars().Tables[0];
            dataGridView4.DataSource = ad.returnAllUsers().Tables[0];
            dataGridView5.DataSource = returnAllReports().Tables[0];
            dataGridView6.DataSource = ad.returnAllLogs().Tables[0];
            updateRentStationsList();
            addRentStationCombo();
            updateRentCarList();
            updateCarList();
            updateAdminList();
            updateFABList();
            updateLogList();

            statsFromDate.Value = DateTime.Now.AddDays(-9);
            statsToDate.Value = DateTime.Now;
            updateMessagesCake(DateTime.Now.AddDays(-9), DateTime.Now);
            updateUsersCake(DateTime.Now.AddDays(-9), DateTime.Now);
            updateCarsCake(DateTime.Now.AddDays(-9), DateTime.Now);
            updateReportsCake(DateTime.Now.AddDays(-9), DateTime.Now);
            graph_FillArrayValuesWithType(DateTime.Now.AddDays(-9), DateTime.Now, "Messages");
            lding.Close();
        }

        private void adminformBack_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (buyOrRent >= 0)
            {
                mainPage mp = new mainPage(u, buyOrRent);
                mp.Show();
            }
        }

        private void manageStations_Click(object sender, EventArgs e)
        {
            
        }
        private void onStationSelectionchanged(int stationid)
        {
            dbRentStations dbrs = new dbRentStations();
            rentStation rs = new rentStation();
            rs = dbrs.returnStationInfo(stationid);
            txtesID.Text = rs.id.ToString();
            txtesLocation.Text = rs.location;
            txtesName.Text = rs.name;
            txtesOpensFrom.Text = rs.opensfrom.ToString();
            txtesOpensTo.Text = rs.opensto.ToString();

            if (rs.status == 0)
                cbAvailCheck.Checked = false;
            else cbAvailCheck.Checked = true;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
                selectedRow = dataGridView1.CurrentRow.Index;
                int stationid = int.Parse(dataGridView1.Rows[selectedRow].Cells[0].Value.ToString());
            if(stationid != -1)
            onStationSelectionchanged(stationid);
        }

        private void btnesSaveAllChanges_Click(object sender, EventArgs e)
        {
            if (ad.CanManageStations(u))
            {
                if (int.Parse(txtesID.Text) == -1 || !IsAllControlsFull(txtesID, txtesLocation, txtesName, txtesOpensFrom, txtesOpensTo))
                {
                    MessageBox.Show("Error: You have left an empty input.");
                    return;
                }
                dbRentStations dbrs = new dbRentStations();
                rentStation rs_temp = dbrs.returnStationInfoFromName(txtesName.Text);
                rentStation rs = new rentStation();
                rs.id = int.Parse(txtesID.Text);
                if (rs_temp != null && rs.id != rs_temp.id)
                {
                    MessageBox.Show("Error: This station name exists already.");
                    return;
                }

                if (dataGridView1.CurrentRow != null)
                {
                    selectedRow = dataGridView1.CurrentRow.Index;
                    rs.location = txtesLocation.Text;
                    rs.name = txtesName.Text;
                    rs.opensfrom = int.Parse(txtesOpensFrom.Text);
                    rs.opensto = int.Parse(txtesOpensTo.Text);
                    station_updateSingleRow(rs, selectedRow);

                    if (cbAvailCheck.Checked) rs.status = 1;
                    else rs.status = 0;

                    dbrs.updateStation(rs);
                    MRC_btnRefresh_Click(null, null);
                    MessageBox.Show("Rent station has been updated successfully!");
                    Admin logg = new Admin(1, u.id, "{_userid_} has edited rent-station ID " + rs.id.ToString());
                    logg.InsertLog(logg);
                }
                else
                    MessageBox.Show("Make sure you're selecting a rent-station first.");
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage stations.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dbRentStations dbrs = new dbRentStations();
            dataGridView1.DataSource = dbrs.returnAllStations().Tables[0];
            updateRentStationsList();
        }
        private void MRC_btnRefresh_Click(object sender, EventArgs e)
        {
            addRentStationCombo();
            DbCars db = new DbCars();
            dataGridView2.DataSource = db.returnAllRentCars().Tables[0];
            updateRentCarList();
        }
        private bool IsAllControlsFull(params Control[] ctrl)
        {
            for (int i = 0; i < ctrl.Length; i++)
                if (ctrl[i].Text.Length == 0)
                    return false;
            return true;
        }
        private bool IsAllCombosGood(params ComboBox[] ctrl)
        {
            for (int i = 0; i < ctrl.Length; i++)
                if (ctrl[i].SelectedIndex == -1)
                    return false;
            return true;
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            if (ad.CanManageStations(u))
            {
                if (!IsAllControlsFull(txtesID, txtesLocation, txtesName, txtesOpensFrom, txtesOpensTo))
                {
                    MessageBox.Show("Error: You have left an empty input.");
                    return;
                }
                dbRentStations dbrs = new dbRentStations();
                rentStation rs = new rentStation();
                if (dbrs.returnStationInfoFromName(txtesName.Text) != null)
                {
                    MessageBox.Show("Error: This station name exists already.");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to add a new rent station?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;

                int station_id = -1;
                rs.location = txtesLocation.Text;
                rs.name = txtesName.Text;
                rs.opensfrom = int.Parse(txtesOpensFrom.Text);
                rs.opensto = int.Parse(txtesOpensTo.Text);
                station_id = dbrs.InsertStation(rs);
                MRC_btnRefresh_Click(null, null);
                MessageBox.Show("New rent-station has been added successfully!");
                Admin logg = new Admin(6, u.id, "{_userid_} has added a new rent station (ID " + station_id + ")");
                logg.InsertLog(logg);
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage stations.");
            }
        }
        private void MRC_SelectionChanged(int rentcarid)
        {
            dbRentStations dbrs = new dbRentStations();
            DbCars db = new DbCars();
            RentCar rc = new RentCar();
            rc = db.returnRentCarInfo(rentcarid);
            if (rc.available != -1)
                MRCStation.Text = (dbrs.returnStationInfo(rc.available)).name;
            else MRCStation.Text = "Station";
            MRCID.Text = rc.id.ToString();
            MRCCompany.Text = rc.company;
            MRCVersion.Text = rc.version;
            MRCGearType.Text = rc.geartype;
            MRCYear.Text = rc.year.ToString();
            MRCPriceDay.Text = rc.priceday.ToString();
            MRCPictureBox.Image = byteArrayToImage(rc.picture);
            acCarImageData = rc.picture;
        }

        private void MRC_SelectionCallBack(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
                return;
            selectedRow = dataGridView2.CurrentRow.Index;
            int carrentid = int.Parse(dataGridView2.Rows[selectedRow].Cells[0].Value.ToString());
            MRC_SelectionChanged(carrentid);
        }
        private void MRC_SaveAllChanges(object sender, EventArgs e)
        {
            if (ad.CanManageRentCars(u))
            {
                if (int.Parse(MRCID.Text) == -1 || !IsAllControlsFull(MRCID, MRCPriceDay, MRCVersion, MRCYear, MRCGearType, MRCCompany) || MRCStation.Text == "Station" || acCarImageData == null)
                {
                    MessageBox.Show("Error: You have left an empty input.");
                    return;
                }
                dbRentStations dbrs = new dbRentStations();
                rentStation rs = dbrs.returnStationInfoFromName(MRCStation.Text);
                if (rs == null)
                {
                    MessageBox.Show("Error: You've selected an invalid station.");
                    return;
                }

                if (dataGridView2.CurrentRow != null)
                {
                    DbCars db = new DbCars();
                    selectedRow = dataGridView2.CurrentRow.Index;
                    RentCar rc = db.returnRentCarInfo(int.Parse(MRCID.Text));
                    rc.priceday = int.Parse(MRCPriceDay.Text);
                    rc.year = int.Parse(MRCYear.Text);
                    rc.company = MRCCompany.Text;
                    rc.version = MRCVersion.Text;
                    rc.geartype = MRCGearType.Text;

                    if (rs.id != -2)
                    {
                        if (rc.available == -2)
                            rc.available = 1;
                        dbrs.scheduleStationChange(rc, rs.id);
                    }
                    else rc.available = -2;
                    rc.picture = acCarImageData;
                    db.updateRentCar(rc);
                    MRC_updateSingleRow(rc, selectedRow);
                    MessageBox.Show("Rent car has been updated successfully!");
                    Admin logg = new Admin(2, u.id, "{_userid_} has edited rent-car ID " + rc.id.ToString() + ".");
                    logg.InsertLog(logg);
                }
                else
                    MessageBox.Show("Make sure you've selected a rent-car first.");
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage rent cars.");
            }
        }
        private void btnSearchByID_Click(object sender, EventArgs e)
        {
            if (ad.CanManageRentCars(u))
            {
                int n;
                bool isNumeric = int.TryParse(txtSearchByID.Text, out n);
                if (isNumeric)
                {
                    DbUser db = new DbUser();
                    bool usrExist = db.isUserFoundByIdentity(txtSearchByID.Text);
                    if (usrExist)
                    {
                        User targetUser = new DbUser().returnUserInfoByIdentity(txtSearchByID.Text);
                        buyOrRent = -1;
                        mainPage mp = new mainPage(u, 1);
                        DbCars dbcars = new DbCars();
                        this.Close();
                        mp.Show();
                        mp.init_rent(dbcars.getUserRentedCarsQuery(targetUser), targetUser);
                    }
                    else
                    {
                        MessageBox.Show("There's no user with this identity.");
                    }
                }
                else
                {
                    MessageBox.Show("You've entered an invalid identity.");
                }
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage rent cars.");
            }
        }
        public void addRentStationCombo()
        {
            MRCStation.Location = new Point(241, 308);
            MRCStation.Width = 100;
            MRCStation.Text = "Station";
            if (!manageRentCars.Controls.Contains(MRCStation))
            manageRentCars.Controls.Add(MRCStation);
            MRCStation.Items.Clear();
            string to_check = null;
            DbCars pp = new DbCars();
            SqlCommand selectStationInfo = new SqlCommand("select * from rent_stations", pp.cnn);
            DataRowCollection rows = pp.ReturnDS(selectStationInfo).Tables[0].Rows;
            string[] stationsArray = new string[rows.Count];
            if (rows.Count == 0)
                MRCStation.Enabled = false;
            else MRCStation.Enabled = true;
            for (int i = 0, j = 0; i < rows.Count; i++)
            {
                if (to_check != null)
                {
                    if (!to_check.Contains("#" + (string)(rows[i]["name"])))
                    {
                        stationsArray[j] = (string)(rows[i]["name"]);
                        to_check += "#" + (string)(rows[i]["name"]);
                        j++;
                    }
                }
                else if (to_check == null)
                {
                    stationsArray[j] = (string)(rows[i]["name"]);
                    to_check = "#" + (string)(rows[i]["name"]);
                    j++;
                }
            }
            foreach (String s in stationsArray)
            {
                if (s == null) break;
                MRCStation.Items.Add(s);
            }
        }
        public void updateRentCarList()
        {
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Company";
            dataGridView2.Columns[2].HeaderText = "Version";
            dataGridView2.Columns[3].HeaderText = "Year";
            dataGridView2.Columns[4].HeaderText = "Gear Type";
            dataGridView2.Columns[5].HeaderText = "Station";
            dataGridView2.Columns[6].HeaderText = "Price/Day";

            dbRentStations dbrs = new dbRentStations();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                dataGridView2.Rows[i].Cells[5].Value = dbrs.returnStationInfo(int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString())).name;
        }
        public void updateCarList()
        {
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Company";
            dataGridView3.Columns[2].HeaderText = "Version";
            dataGridView3.Columns[3].HeaderText = "Year";
            dataGridView3.Columns[4].HeaderText = "Gear Type";
            dataGridView3.Columns[5].HeaderText = "Price";
            dataGridView3.Columns[6].HeaderText = "Hand";
            dataGridView3.Columns[7].HeaderText = "Gas Type";
            dataGridView3.Columns[8].HeaderText = "Kilometers";
            dataGridView3.Columns[9].HeaderText = "Color";
            dataGridView3.Columns[10].HeaderText = "Car Type";
            dataGridView3.Columns[11].HeaderText = "Status";
            DbCars db = new DbCars();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells[10].Value = db.returnCartypeName(int.Parse(dataGridView3.Rows[i].Cells[10].Value.ToString()));
                dataGridView3.Rows[i].Cells[11].Value = db.returnCarStatus(int.Parse(dataGridView3.Rows[i].Cells[11].Value.ToString()));
            }
        }
        public void updateAdminList()
        {
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Name";
            dataGridView4.Columns[2].HeaderText = "Email";
            dataGridView4.Columns[3].HeaderText = "Level";
            dataGridView4.Columns[4].HeaderText = "Identity";
            dataGridView4.Columns[5].HeaderText = "Verified";

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                dataGridView4.Rows[i].Cells[3].Value = ad.returnAdminLevelName(int.Parse(dataGridView4.Rows[i].Cells[3].Value.ToString()));
                if (int.Parse(dataGridView4.Rows[i].Cells[5].Value.ToString()) == 0)
                    dataGridView4.Rows[i].Cells[5].Value = "No";
                else dataGridView4.Rows[i].Cells[5].Value = "Yes";
            }
        }
        private void MRCAddNew_Click(object sender, EventArgs e)
        {
            if (ad.CanManageRentCars(u))
            {
                if (!IsAllControlsFull(MRCID, MRCPriceDay, MRCVersion, MRCYear, MRCGearType, MRCCompany) || MRCStation.Text == "Station" || acCarImageData == null)
                {
                    MessageBox.Show("Error: You have left an empty input.");
                    return;
                }
                dbRentStations dbrs = new dbRentStations();
                rentStation rs = dbrs.returnStationInfoFromName(MRCStation.Text);
                if (rs == null)
                {
                    MessageBox.Show("Error: You've not selected a station.");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to add a new rent-car?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;

                DbCars db = new DbCars();
                RentCar rc = new RentCar();
                rc.company = MRCCompany.Text;
                rc.version = MRCVersion.Text;
                rc.year = int.Parse(MRCYear.Text);
                rc.geartype = MRCGearType.Text;
                rc.available = rs.id;
                rc.picture = acCarImageData;
                rc.priceday = int.Parse(MRCPriceDay.Text);
                int rentcar_id = db.InsertRentCar(rc);
                MessageBox.Show("New rent-car has been added successfully!");
                Admin logg = new Admin(5, u.id, "{_userid_} has added a new rent-car. (ID " + rentcar_id + ")");
                logg.InsertLog(logg);
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage rent cars.");
            }
        }
        private void MRCBookedRents_Click(object sender, EventArgs e)
        {
            if (ad.CanManageRentCars(u))
            {
                if (int.Parse(MRCID.Text) != -1)
                {
                    DbCars db = new DbCars();
                    RentCar rc = new RentCar();
                    rc = db.returnRentCarInfo(int.Parse(MRCID.Text));
                    if (rc == null)
                    {
                        MessageBox.Show("Sorry, an error has occoured, please refresh the page.");
                        return;
                    }

                    SqlCommand cmd = new SqlCommand("select * from rent_periods where carid=@carid order by to_date desc", cnn);
                    cmd.Parameters.AddWithValue("@carid", rc.id);
                    cmd.Parameters.AddWithValue("@thisdate", DateTime.Now.Date);
                    rentPeriod[] rp = db.returnCurrentAndComingCarPeriods(rc, cmd);
                    if (rp == null)
                    {
                        MessageBox.Show("This car doesn't have any booked rents.");
                        return;
                    }
                    mainPage mp = new mainPage(u, 1);
                    mp.showUserRentsList(rc, rp, this);
                    mp.lding.Close();
                    mp.Close();
                }
                else
                    MessageBox.Show("You need to select a rent car first.");
            }
            else
                MessageBox.Show("Sorry, you don't have permissions to manage rent cars.");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.Title = "Hand2 - Rent-car Image";
            fdialog.InitialDirectory = @"c:\";
            fdialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                acCarImageData = ReadFile(fdialog.FileName);
                MRCPictureBox.ImageLocation = fdialog.FileName;
            }
        }
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
                return;
            selectedRow = dataGridView3.CurrentRow.Index;
            int carid = int.Parse(dataGridView3.Rows[selectedRow].Cells[0].Value.ToString());
            MC_SelectionChanged(carid);
        }
        private void MC_SelectionChanged(int carid)
        {
            if (carid != -1)
            {
                DbCars db = new DbCars();
                Cars c = db.returnCarInfo(carid);
                MCID.Text = c.id.ToString();
                MCCompany.Text = c.company;
                MCVersion.Text = c.version;
                MCGearType.Text = c.geartype;
                MCYear.Text = c.year.ToString();
                MCPrice.Text = c.price.ToString();
                MCHand.Text = c.hand.ToString();
                MCKilosDriven.Text = c.kilometers.ToString();
                MCStatus.Text = db.returnCarStatus(c.status);
                MCColor.Text = c.color;
                MCGasType.Text = c.gastype;
                MCCarType.Text = db.returnCartypeName(c.cartype);
                MCPictureBox.Image = byteArrayToImage(c.pic);
                MCDescription.Text = c.description;
                acCarImageData2 = c.pic;
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
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

        private void MCBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.Title = "Hand2 - Car Image";
            fdialog.InitialDirectory = @"c:\";
            fdialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                acCarImageData2 = ReadFile(fdialog.FileName);
                MCPictureBox.ImageLocation = fdialog.FileName;
            }
        }
        private void MCSave_Click(object sender, EventArgs e)
        {
            if (ad.CanManageCars(u))
            {
                if (int.Parse(MCID.Text) == -1 || !IsAllControlsFull(MCID, MCCompany, MCVersion, MCColor, MCYear, MCPrice, MCHand, MCKilosDriven, MCDescription) || !IsAllCombosGood(MCGearType, MCGasType, MCCarType, MCStatus) || acCarImageData2 == null)
                {
                    MessageBox.Show("Error: You have left an empty input or chose an invalid option.");
                    return;
                }

                if (dataGridView3.CurrentRow != null)
                {
                    selectedRow = dataGridView3.CurrentRow.Index;
                    DbCars db = new DbCars();
                    Cars c = db.returnCarInfo(int.Parse(MCID.Text));
                    c.company = MCCompany.Text;
                    c.version = MCVersion.Text;
                    c.color = MCColor.Text;
                    c.year = int.Parse(MCYear.Text);
                    c.price = int.Parse(MCPrice.Text);
                    c.hand = int.Parse(MCHand.Text);
                    c.kilometers = int.Parse(MCKilosDriven.Text);
                    c.description = MCDescription.Text;
                    c.geartype = MCGearType.Text;
                    c.gastype = MCGasType.Text;
                    c.cartype = MCCarType.SelectedIndex;
                    c.status = MCStatus.SelectedIndex;
                    c.pic = acCarImageData2;
                    db.updateCar(c);
                    MC_updateSingleRow(c, selectedRow);
                    MessageBox.Show("Car has been updated successfully!");
                    Admin logg = new Admin(0, u.id, "{_userid_} has edited car ID " + c.id.ToString() + " (ADMIN PANEL)");
                    logg.InsertLog(logg);
                }
                else
                    MessageBox.Show("Make sure you've selected a car first.");
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage cars.");
            }
        }
        private void MCDeleteCar_Click(object sender, EventArgs e)
        {
            if (ad.CanManageCars(u))
            {
                if (int.Parse(MCID.Text) == -1 || dataGridView3.CurrentRow == null)
                    MessageBox.Show("Sorry, you need to select a valid car first.");
                else
                {
                    int tmpCarID = int.Parse(MCID.Text);
                    DbCars db = new DbCars();
                    SqlCommand pp = new SqlCommand("delete from Cars where id=@theid", db.cnn);
                    pp.Parameters.AddWithValue("@theid", tmpCarID);
                    db.InsDelUpd(pp);
                    MessageBox.Show("Car has been deleted successfully.");
                    selectedRow = dataGridView3.CurrentRow.Index;
                    dataGridView3.Rows[selectedRow].Cells[0].Value = -1;
                    button4_Click(null, null);
                    Admin logg = new Admin(8, u.id, "{_userid_} has deleted car ID " + tmpCarID.ToString() + " (ADMIN PANEL)");
                    logg.InsertLog(logg);
                }
            }
            else
            {
                MessageBox.Show("Sorry, you don't have permissions to manage cars.");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DbCars db = new DbCars();
            dataGridView3.DataSource = db.dgv_returnAllCars().Tables[0];
            updateCarList();
        }
        private void SendEmailToAll(string title, string content, int level = 0)
        {
            if (IsNetworkAvailable())
            {
                DbUser db = new DbUser();
                string[] the_array;
                SqlCommand str = new SqlCommand("select email from users where level>=@level", ad.cnn);
                str.Parameters.AddWithValue("@level", level);
                the_array = db.returnAllValidEmails(str);
                if (the_array == null) return;
                var msg = new MailMessage();
                for (int i = 0; i < the_array.Length; i++)
                    msg.Bcc.Add(the_array[i]);
                msg.From = new MailAddress("thehandtwo@gmail.com");
                msg.Body = content;
                msg.Subject = title;
                msg.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("thehandtwo@gmail.com", API_KEY);
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }
            else
                MessageBox.Show("Sorry, you need to connect to internet in order to send and receive Emails.");
        }

        private void BRDContent_TextChanged(object sender, EventArgs e)
        {
            BRDCount.Text = BRDContent.Text.Length + " / " + BRDContent.MaxLength;
        }

        private void BRDSend_Click(object sender, EventArgs e)
        {
            if (ad.CanSendMessageToAll(u))
            {
                if (BRDTitle.TextLength < 6 || BRDTitle.TextLength > 100)
                    MessageBox.Show("Title is too short or too long.");
                else if (BRDLevel.SelectedIndex == -1)
                    MessageBox.Show("Invalid level selected.");
                else if (BRDContent.TextLength <= 20)
                    MessageBox.Show("Message content is too short.");
                else
                {
                    int tolevel;
                    DbUser db = new DbUser();
                    User to = new User();
                    to.id = -1;
                    if (BRDLevel.Text == "Everyone") tolevel = -1;
                    else tolevel = ad.returnAdminLevelFromName(BRDLevel.Text);
                    db.addMessage(u, to, BRDContent.Text, BRDTitle.Text, tolevel);
                    string thelog_content = "{_userid_} has submitted a new broadcast to " + BRDLevel.Text + " and higher";
                    if (BRDToEmails.Checked)
                    {
                        if (IsNetworkAvailable())
                        {
                            thelog_content += "(EMAILS INCLUDED)";
                            string content = "<center><h2>Hand2 - " + BRDTitle.Text + "</h2></center>" +
                            BRDContent.Text + "<center><br><br><i>Hand2 © Copyrights reserved to Hand2, " + DateTime.Now.Year + "</i></center>";
                            content = content.Replace("\r\n", "<br>");
                            SendEmailToAll(BRDTitle.Text, content, tolevel);
                        }
                        else
                            MessageBox.Show("Sorry, you need to be connected to the internet to send Emails.");
                    }
                    Admin logg = new Admin(7, u.id, thelog_content);
                    logg.InsertLog(logg);
                    MessageBox.Show("Broadcast Complete!");
                    BRDTitle.Text = "";
                    BRDContent.Text = "Broadcast Content";
                    BRDLevel.Text = "Everyone";
                    BRDToEmails.Checked = false;
                }
            }
            else
                MessageBox.Show("Sorry, you don't have enough permissions to submit broadcasts.");
        }

        private void adminTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == manageCars && !ad.CanManageCars(u))
                e.Cancel = true;

            else if (e.TabPage == manageRentCars && !ad.CanManageRentCars(u))
                e.Cancel = true;

            else if (e.TabPage == manageStations && !ad.CanManageStations(u))
                e.Cancel = true;

            else if (e.TabPage == sendEmails && !ad.CanSendMessageToAll(u))
                e.Cancel = true;

            else if (e.TabPage == manageUsers && !ad.CanManageUsers(u))
                e.Cancel = true;

            else if (e.TabPage == viewLogs && !ad.CanViewLogs(u))
                e.Cancel = true;

            else if (e.TabPage == feedBackPage && !ad.CanViewFeedback(u))
                e.Cancel = true;
            else if (e.TabPage == statsPage && !ad.CanViewStats(u))
                e.Cancel = true;
        }
        public void updateSelectedTab()
        {
            if (ad.CanManageStations(u))
                adminTabControl.SelectedIndex = 0;

            else if (ad.CanManageRentCars(u))
                adminTabControl.SelectedIndex = 1;

            else if (ad.CanManageCars(u))
                adminTabControl.SelectedIndex = 2;

            else if (ad.CanManageUsers(u))
                adminTabControl.SelectedIndex = 3;

            else if (ad.CanSendMessageToAll(u))
                adminTabControl.SelectedIndex = 4;

            else if (ad.CanViewLogs(u))
                adminTabControl.SelectedIndex = 5;

            else if (ad.CanViewFeedback(u))
                adminTabControl.SelectedIndex = 6;

            else
                adminTabControl.Enabled = false;
        }

        private void MADSave_Click(object sender, EventArgs e)
        {
            if (ad.CanManageUsers(u))
            {
                if (IsAllControlsFull(MADID, MADFullName, MADEmail, MADIdentity) && IsAllCombosGood(MADLevel, MADVerified) && MADVerified.SelectedIndex > 0 && MADID.Text != "-1" && IsNumeric(MADIdentity.Text) && MADIdentity.TextLength == 9)
                {
                    DbUser db = new DbUser();
                    User target = new User();
                    int selected_level = ad.returnAdminLevelFromName(MADLevel.Text);
                    target = db.returnUserInfoByID(int.Parse(MADID.Text));
                    if (target.email != MADEmail.Text && db.Found(MADEmail.Text))
                    {
                        MessageBox.Show("Sorry, this Email already exists and is being used by someone else.");
                        return;
                    }
                    if (dataGridView4.CurrentRow != null)
                    {
                        selectedRow = dataGridView4.CurrentRow.Index;
                        target.name = MADFullName.Text;
                        target.email = MADEmail.Text;
                        target.user_id = MADIdentity.Text;
                        target.verified = MADVerified.SelectedIndex - 1;
                        if (ad.CanManageAdmins(u))
                        {
                            if (target.level != selected_level && u.level <= target.level)
                            {
                                MessageBox.Show("Sorry, you may not change admin level of this user.");
                                return;
                            }
                            target.level = ad.returnAdminLevelFromName(MADLevel.Text);
                        }
                        else MADLevel.Text = ad.returnAdminLevelName(target.level);
                        db.updateUser(target);
                        db.UpdateUserReadMessages(target);
                        MAD_updateSingleRow(target, selectedRow);
                        MessageBox.Show("User information have been updated successfully!");
                        Admin logg = new Admin(3, u.id, "{_userid_} has edited user ID (" + target.id + ") information");
                        logg.InsertLog(logg);
                    }
                    else
                        MessageBox.Show("Make sure you're selecting a user first.");
                }
                else
                    MessageBox.Show("Error: You've left something empty or entered an invalid value.");
            }
            else
                MessageBox.Show("Sorry, you don't have enough permissions to change user info.");
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow == null)
                return;
            selectedRow = dataGridView4.CurrentRow.Index;
            int userid = int.Parse(dataGridView4.Rows[selectedRow].Cells[0].Value.ToString());
            MAD_SelectionChanged(userid);
        }
        private void MAD_SelectionChanged(int userid)
        {
            DbUser db = new DbUser();
            User user = db.returnUserInfoByID(userid);
            MADID.Text = user.id.ToString();
            MADFullName.Text = user.name;
            MADEmail.Text = user.email;
            MADLevel.Text = ad.returnAdminLevelName(user.level);
            MADIdentity.Text = user.user_id;

            if (user.verified == 0) MADVerified.Text = "No";
            else MADVerified.Text = "Yes";
        }

        private void MADRefresh_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = ad.returnAllUsers().Tables[0];
            updateAdminList();
        }
        private void MAD_updateSingleRow(User userid, int rowid)
        {
            if (dataGridView4.Rows[rowid] == null)
                return;
            dataGridView4.Rows[rowid].Cells[0].Value = userid.id;
            dataGridView4.Rows[rowid].Cells[1].Value = userid.name;
            dataGridView4.Rows[rowid].Cells[2].Value = userid.email;
            dataGridView4.Rows[rowid].Cells[3].Value = ad.returnAdminLevelName(userid.level);
            dataGridView4.Rows[rowid].Cells[4].Value = userid.user_id;

            if (userid.verified == 0)
                dataGridView4.Rows[rowid].Cells[5].Value = "No";
            else dataGridView4.Rows[rowid].Cells[5].Value = "Yes";
        }
        private void MRC_updateSingleRow(RentCar rc, int rowid)
        {
            if (dataGridView2.Rows[rowid] == null)
                return;
            dbRentStations dbrs = new dbRentStations();
            dataGridView2.Rows[rowid].Cells[0].Value = rc.id;
            dataGridView2.Rows[rowid].Cells[1].Value = rc.company;
            dataGridView2.Rows[rowid].Cells[2].Value = rc.version;
            dataGridView2.Rows[rowid].Cells[3].Value = rc.year.ToString();
            dataGridView2.Rows[rowid].Cells[4].Value = rc.geartype;
            dataGridView2.Rows[rowid].Cells[5].Value = dbrs.returnStationInfo(rc.available).name;
            dataGridView2.Rows[rowid].Cells[6].Value = rc.priceday;
                
        }
        private void MC_updateSingleRow(Cars c, int rowid)
        {
            if (dataGridView3.Rows[rowid] == null)
                return;
            DbCars db = new DbCars();
            dataGridView3.Rows[rowid].Cells[0].Value = c.id;
            dataGridView3.Rows[rowid].Cells[1].Value = c.company;
            dataGridView3.Rows[rowid].Cells[2].Value = c.version;
            dataGridView3.Rows[rowid].Cells[3].Value = c.year.ToString();
            dataGridView3.Rows[rowid].Cells[4].Value = c.geartype;
            dataGridView3.Rows[rowid].Cells[5].Value = c.price.ToString();
            dataGridView3.Rows[rowid].Cells[6].Value = c.hand.ToString();
            dataGridView3.Rows[rowid].Cells[7].Value = c.gastype;
            dataGridView3.Rows[rowid].Cells[8].Value = c.kilometers.ToString();
            dataGridView3.Rows[rowid].Cells[9].Value = c.color;
            dataGridView3.Rows[rowid].Cells[10].Value = db.returnCartypeName(c.cartype);
            dataGridView3.Rows[rowid].Cells[11].Value = db.returnCarStatus(c.status);
        }
        private void station_updateSingleRow(rentStation rs, int rowid)
        {
            dataGridView1.Rows[rowid].Cells[0].Value = rs.id;
            dataGridView1.Rows[rowid].Cells[1].Value = rs.name;
            dataGridView1.Rows[rowid].Cells[2].Value = rs.location;
            dataGridView1.Rows[rowid].Cells[3].Value = rs.opensfrom;
            dataGridView1.Rows[rowid].Cells[4].Value = rs.opensto;
        }

        private void feedBackPage_Click(object sender, EventArgs e)
        {

        }
        public int getResponderID(int response_id)
        {
            viewMessages vm = new viewMessages();
            return vm.returnMessageInfo(response_id).fromid;
        }
        public DataSet returnAllReports(SqlCommand sqlcmd = null)
        {
            if (sqlcmd == null)
                sqlcmd = new SqlCommand("select id, CONVERT(varchar(30), f_type), sender, target, f_content, CONVERT(varchar(150), response_id), date from reports", cnn);
            return ReturnDS(sqlcmd);
        }
        public void InsDelUpd(SqlCommand SqlStr)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cnn.Open();
                SqlStr.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public DataSet ReturnDS(SqlCommand SqlStr)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlStr);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return ds;
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
        private void FABFilter_Click(object sender, EventArgs e)
        {
            SqlCommand the_query = new SqlCommand("select id, CONVERT(varchar(30), f_type), sender, target, f_content, CONVERT(varchar(150), response_id), date from reports", cnn);
            bool added_before = false;
            if (FABType.SelectedIndex != -1 && FABType.SelectedIndex != 0)
            {
                added_before = true;
                the_query.CommandText += " where f_type=@ftype";
                the_query.Parameters.AddWithValue("@ftype", FABType.SelectedIndex - 1);
            }
            else FABType.SelectedIndex = 0;
            if (FABSender.TextLength != 0 && IsNumeric(FABSender.Text))
            {
                if (added_before == true)
                    the_query.CommandText += " and ";
                else
                {
                    the_query.CommandText += " where ";
                    added_before = true;
                }
                the_query.CommandText += "sender=@senderid";
                the_query.Parameters.AddWithValue("@senderid", int.Parse(FABSender.Text));
            }
            else FABSender.Text = "";
            if (FABTarget.TextLength != 0 && IsNumeric(FABTarget.Text))
            {
                if (added_before == true)
                    the_query.CommandText += " and ";
                else
                {
                    the_query.CommandText += " where ";
                    added_before = true;
                }
                the_query.CommandText += "target=@targetid";
                the_query.Parameters.AddWithValue("@targetid", int.Parse(FABTarget.Text));
            }
            else FABTarget.Text = "";
            if (FABPartOfContent.TextLength >= 4)
            {
                if (added_before == true)
                    the_query.CommandText += " and ";
                else
                {
                    the_query.CommandText += " where ";
                    added_before = true;
                }
                the_query.CommandText += "f_content LIKE @partcontent";
                the_query.Parameters.AddWithValue("@partcontent", '%' + FABPartOfContent.Text + '%');
            }
            else FABPartOfContent.Text = "";
            if (FABRespondedOrNo.Checked)
            {
                if (added_before == true)
                    the_query.CommandText += " and ";
                else
                {
                    the_query.CommandText += " where ";
                    added_before = true;
                }
                the_query.CommandText += "response_id=-1";
            }
            dataGridView5.DataSource = returnAllReports(the_query).Tables[0];
            updateFABList();
        }
        public void updateFABList()
        {
            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[1].HeaderText = "Type";
            dataGridView5.Columns[2].HeaderText = "Sender ID";
            dataGridView5.Columns[3].HeaderText = "Target ID";
            dataGridView5.Columns[4].HeaderText = "Content";
            dataGridView5.Columns[5].HeaderText = "Responded By";
            dataGridView5.Columns[6].HeaderText = "Submitted In";

            DbUser db = new DbUser();
            int responder_id;
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                responder_id = int.Parse(dataGridView5.Rows[i].Cells[5].Value.ToString());
                if (responder_id == -1) dataGridView5.Rows[i].Cells[5].Value = "None";
                else dataGridView5.Rows[i].Cells[5].Value = db.returnUserInfoByID(getResponderID(responder_id)).name;
                dataGridView5.Rows[i].Cells[1].Value = ad.returnReportTypeName(int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString()));
            }
        }
        private void FAB_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
                return;
            reports r = new reports();
            DbUser db = new DbUser();
            selectedRow = dataGridView5.CurrentRow.Index;
            r = ad.returnReportInfo(int.Parse(dataGridView5.Rows[selectedRow].Cells[0].Value.ToString()));
            FAB2ReportID.Text = r.id.ToString();
            FAB2Type.Text = ad.returnReportTypeName(r.f_type);
            FAB2Sender.Text = r.sender_id.ToString();
            FAB2Target.Text = r.target_id.ToString();
            FAB2Content.Text = r.f_content;
            FAB2Date.Text = r.date.ToString();
            if (r.response_id == -1)
            {                
                FAB2Responded.Text = "None";
                FABViewResponse.Enabled = false;
                if (r.sender_id != u.id)
                    FABRespond.Enabled = true;
                else
                    FABRespond.Enabled = false;
            }
            else
            {
                FAB2Responded.Text = db.returnUserInfoByID(getResponderID(r.response_id)).name;
                FABRespond.Enabled = false;
                FABViewResponse.Enabled = true;
            }
        }

        private void FABViewResponse_Click(object sender, EventArgs e)
        {
            if (ad.CanViewLogs(u))
            {
                this.Enabled = false;
                int report_id = int.Parse(FAB2ReportID.Text);
                if (report_id == -1) return;
                RespondOrView rov = new RespondOrView(ad.returnReportInfo(report_id), u, this);
                rov.ShowDialog(this);
            }
            else
                MessageBox.Show("Sorry, you don't have enough permission to view logs.");
        }

        private void FABRespond_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int report_id = int.Parse(FAB2ReportID.Text);
            if (report_id == -1) return;

            RespondOrView rov = new RespondOrView(ad.returnReportInfo(report_id), u, this);
            rov.ShowDialog(this);
        }
        public void FeedbackRefreshList()
        {
            FABFilter_Click(null, null);
        }

        private void MADIDSearch_Click(object sender, EventArgs e)
        {
            if (MADIDForSearch.TextLength > 0)
            {
                int id;
                bool isInt = Int32.TryParse(MADIDForSearch.Text, out id);
                if (isInt)
                {
                    SqlCommand query = new SqlCommand("select id, name, email, CONVERT(varchar(50), level),  user_id, CONVERT(varchar(50), verified) from Users where id like @theid and id>0", cnn);
                    query.Parameters.AddWithValue("@theid", "%"+id.ToString()+"%");
                    dataGridView4.DataSource = ad.returnAllUsers(query).Tables[0];
                    updateAdminList();
                }
            }
        }

        private void MADFullSearch_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("select id, name, email, CONVERT(varchar(50), level),  user_id, CONVERT(varchar(50), verified) from Users", cnn);
            bool added_before = false;
            if (MADFullName.TextLength != 0)
            {
                added_before = true;
                query.CommandText += " where name like @fname";
                query.Parameters.AddWithValue("@fname", "%"+MADFullName.Text+"%");
            }
            if (MADEmail.TextLength != 0)
            {
                if (added_before == true)
                    query.CommandText += " and ";
                else
                {
                    query.CommandText += " where ";
                    added_before = true;
                }
                query.CommandText += "email like @email";
                query.Parameters.AddWithValue("@email", "%"+MADEmail.Text+"%");
            }
            if (MADIdentity.TextLength <= 9 && MADIdentity.TextLength > 0 && IsNumeric(MADIdentity.Text))
            {
                if (added_before == true)
                    query.CommandText += " and ";
                else
                {
                    query.CommandText += " where ";
                    added_before = true;
                }
                query.CommandText += "user_id like @identity";
                query.Parameters.AddWithValue("@identity", "%"+MADIdentity.Text+"%");
            }
            if (MADVerified.SelectedIndex > 0)
            {
                if (added_before == true)
                    query.CommandText += " and ";
                else
                {
                    query.CommandText += " where ";
                    added_before = true;
                }
                query.CommandText += "verified=@verified";
                query.Parameters.AddWithValue("@verified", MADVerified.SelectedIndex-1);
            }
            if (MADLevel.SelectedIndex != -1)
            {
                if (added_before == true)
                    query.CommandText += " and ";
                else
                {
                    query.CommandText += " where ";
                    added_before = true;
                }
                query.CommandText += "level>=@level";
                query.Parameters.AddWithValue("@level", ad.returnAdminLevelFromName(MADLevel.Text));
            }
            MADID.Text = "-1";
            dataGridView4.SelectionChanged -= dataGridView4_SelectionChanged;
            dataGridView4.DataSource = ad.returnAllUsers(query).Tables[0];
            updateAdminList();
            dataGridView4.SelectionChanged += new EventHandler(dataGridView4_SelectionChanged);
        }
        public void updateLogList()
        {
            dataGridView6.Columns[0].HeaderText = "User ID";
            dataGridView6.Columns[1].HeaderText = "Log";
            dataGridView6.Columns[2].HeaderText = "Date";

            DbUser db = new DbUser();
            int id;
            for (int i = 0; i < dataGridView6.Rows.Count; i++)
            {
                id = int.Parse(dataGridView6.Rows[i].Cells[0].Value.ToString());
                dataGridView6.Rows[i].Cells[1].Value = dataGridView6.Rows[i].Cells[1].Value.ToString().Replace("{_userid_}", db.returnUserInfoByID(id).name);
            }
            if (dataGridView6.Rows.Count == 0)
                MessageBox.Show("There are no results\nMake sure you have selected a proper date period.");
        }
        public void updateRentStationsList()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Location";
            dataGridView1.Columns[3].HeaderText = "Opens From";
            dataGridView1.Columns[4].HeaderText = "Opens To";
            dataGridView1.Columns[5].HeaderText = "Status";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) == 0)
                    dataGridView1.Rows[i].Cells[5].Value = "Inactive";
                else dataGridView1.Rows[i].Cells[5].Value = "Active";
            }
        }
        private void VLFilter_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("select userid, logcontent, date from Logs", cnn);
            bool added_before = false;
            if (VLUserID.TextLength != 0 && IsNumeric(VLUserID.Text))
            {
                added_before = true;
                query.CommandText += " where userid like @userid";
                query.Parameters.AddWithValue("@userid", "%" + VLUserID.Text + "%");
            }
            if (VLType.SelectedIndex > 0)
            {
                if (added_before == true)
                    query.CommandText += " and ";
                else
                {
                    query.CommandText += " where ";
                    added_before = true;
                }
                query.CommandText += "logtype=@logtype";
                query.Parameters.AddWithValue("@logtype", VLType.SelectedIndex-1);
            }
            if (added_before == true)
                query.CommandText += " and ";
            else
            {
                query.CommandText += " where ";
                added_before = true;
            }
            query.CommandText += "date>=@fromdate and date<=@todate";
            query.Parameters.AddWithValue("@fromdate", VLFromDate.Value);
            query.Parameters.AddWithValue("@todate", VLToDate.Value);
            query.CommandText += " order by id desc";
            dataGridView6.DataSource = ad.returnAllLogs(query).Tables[0];
            updateLogList();
        }
        public int countTotalUsersRegisteredBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM users where joindate>=@dt1 and joindate<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int[] getTotalPeopleRegisteredBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * FROM users where joindate>=@dt1 and joindate<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);

            int[] thearray = new int[2];
            int verified;
            DataRowCollection rows = ReturnDS(cmd).Tables[0].Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                verified = (int)(rows[i]["verified"]);
                if (verified == 1)
                    thearray[1]++;
                else 
                    thearray[0]++;
            }
            cnn.Close();
            return thearray;
        }
        public int countTotalMessagesBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM messages where date>=@dt1 and date<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int[] getTotalMessagesBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            /*///// Values of message types:
             * 0 = Hand2 message (where fromid = -1)
             * 1 = Private message (fromid != -1 && toid != -1)
             * 2 = Broadcast (toid == -1)
             * 3 = Response to Report = getTotalReportResponsesBetweenDates..
             * */
            int[] thearr = new int[4];
            SqlCommand cmd = new SqlCommand("select * from messages where date>=@dt1 and date<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);

            int toid, fromid;
            DataRowCollection rows = ReturnDS(cmd).Tables[0].Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                fromid = (int)(rows[i]["fromuser"]);
                toid = (int)(rows[i]["touser"]);
                if (fromid == -1)
                    thearr[0]++;

                else if (toid == -1)
                    thearr[2]++;

                else 
                    thearr[1]++;
            }
            thearr[3] = countTotalResponsesBetweenDates(dt1, dt2);
            cnn.Close();
            return thearr;
        }
        /*public dateAndValue[] graph_returnMessages(DateTime dt1, DateTime dt2)
        {
            dateAndValue[] thearray;
            if ((dt2 - dt1).TotalDays <= 8)
            {
                thearray = new dateAndValue[8];
                for (int i = 0; i < thearray.Length; i++)
                {
                    thearray[i].thedate = 
                }
            }
        }*/
        public int countTotalCarsBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM cars where adddate>=@dt1 and adddate<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int[] getTotalCarsBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            /* status value keys:
             * 0 = Car pending - awaiting admin to approve/deny
             * 1 = Car denied/rejected by admin
             * 2 = Car deleted by owner/admin.
             * 3 = Car accepted/approved by admin.
             */
            int[] thearr = new int[4];
            SqlCommand cmd = new SqlCommand("select * from Cars where adddate>=@dt1 and adddate<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);

            int status;
            DataRowCollection rows = ReturnDS(cmd).Tables[0].Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                status = (int)(rows[i]["status"]);
                thearr[status]++;
            }
            cnn.Close();
            return thearr;
        }
        public int countTotalRentCarsBetweenDates(DateTime dt1, DateTime dt2, bool availableones = false)
        {
            cnn.Open();
            SqlCommand cmd;
            if (availableones)
                cmd = new SqlCommand("select COUNT(*) FROM CarRent where available>0", cnn);
            else
                cmd = new SqlCommand("select COUNT(*) FROM CarRent", cnn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int[] getTotalReportsBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            /* type value keys:
             * 0 - Feedback
            * 1 - Help Request
            * 2 - Bug Report
            * 3 - User Report
            * 4 - Other   */
            int[] thearr = new int[5];
            SqlCommand cmd = new SqlCommand("select * from reports where date>=@dt1 and date<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);

            int type;
            DataRowCollection rows = ReturnDS(cmd).Tables[0].Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                type = (int)(rows[i]["f_type"]);
                thearr[type]++;
            }
            cnn.Close();
            return thearr;
        }
        public int countTotalReportsBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM reports where date>=@dt1 and date<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int countTotalResponsesBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM reports where response_id!=-1 and date>=@dt1 and date<=@dt2", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int countTotalAdmins()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM users where level>0", cnn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int countTotalRentStations()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM rent_stations", cnn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int countTotalRentPeriodsBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM rent_periods where (from_date>=@dt1 and from_date<=@dt2) or (to_date>=@dt1 and to_date<=@dt2)", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            Int32 count = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public int calcTotalEarningsBetweenDates(DateTime dt1, DateTime dt2)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from rent_periods where (from_date>=@dt1 and from_date<=@dt2) or (to_date>=@dt1 and to_date<=@dt2)", cnn);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            DataRowCollection rows = ReturnDS(cmd).Tables[0].Rows;

            int totalmoney = 0, moneyperday; DateTime thefrom, theto;
            for (int i = 0; i < rows.Count; i++)
            {
                thefrom = (DateTime)(rows[i]["from_date"]);
                theto = (DateTime)(rows[i]["to_date"]);
                moneyperday = (int)(rows[i]["moneyperday"]);
                if (thefrom >= dt1 && theto <= dt2)
                    totalmoney += (int)(moneyperday * (theto - thefrom).TotalDays);
                else if (thefrom >= dt1 && thefrom <= dt2 && theto >= dt2)
                    totalmoney += (int)(moneyperday * (dt2-thefrom).TotalDays);
                else if(theto >= dt1 && theto <= dt2 && thefrom <= dt1)
                    totalmoney += (int)(moneyperday * (theto-dt1).TotalDays);
            }
            cnn.Close();
            return totalmoney;
        }
        public void updateMessagesCake(DateTime dt1, DateTime dt2)
        {
            
             /* 0 = Hand2 message (where fromid = -1)
             * 1 = Private message (fromid != -1 && toid != -1)
             * 2 = Broadcast (toid == -1)
             * 3 = Response to Report = getTotalReportResponsesBetweenDates.*/
            string[] seriesous = { "System Messages", "Private Messages", "Broadcasts", "Responses" };
            int[] thearray = getTotalMessagesBetweenDates(dt1.AddDays(-1), dt2.AddDays(1));
            thearray[1] -= thearray[3];
            int totalmsgs = thearray[0] + thearray[1] + thearray[2] + thearray[3];
            messagesChart.Series[0].Points.Clear();
            messagesChart.Titles.Clear();
            messagesChart.Titles.Add("Messages (Total: "+totalmsgs+")");
            messagesChart.Series["s1"].IsValueShownAsLabel = true;
            for (int i = 0; i < thearray.Length; i++)
                messagesChart.Series["s1"].Points.AddXY(seriesous[i], thearray[i]);
        }
        public void updateUsersCake(DateTime dt1, DateTime dt2)
        {
            string[] seriesous = { "Un-verified", "Verified" };
            int[] thearray = getTotalPeopleRegisteredBetweenDates(dt1.AddDays(-1), dt2.AddDays(1));
            int totalusers = thearray[0] + thearray[1];
            usersChart.Series[0].Points.Clear();
            usersChart.Titles.Clear();
            usersChart.Titles.Add("Users (Total: " + totalusers + ")");
            usersChart.Series["s1"].IsValueShownAsLabel = true;
            for (int i = 0; i < thearray.Length; i++)
                usersChart.Series["s1"].Points.AddXY(seriesous[i], thearray[i]);
        }
        public void updateCarsCake(DateTime dt1, DateTime dt2)
        {
            string[] seriesous = { "Pending", "Rejected", "Deleted", "Approved" };
            int[] thearray = getTotalCarsBetweenDates(dt1.AddDays(-1), dt2.AddDays(1));
            int totalcars = thearray[0] + thearray[1] + thearray[2] + thearray[3];
            carsCake.Series[0].Points.Clear();
            carsCake.Titles.Clear();
            carsCake.Titles.Add("Cars (Total: " + totalcars + ")");
            carsCake.Series["s1"].IsValueShownAsLabel = true;
            for (int i = 0; i < thearray.Length; i++)
                carsCake.Series["s1"].Points.AddXY(seriesous[i], thearray[i]);
        }
        public void updateReportsCake(DateTime dt1, DateTime dt2)
        {
            int[] thearray = getTotalReportsBetweenDates(dt1.AddDays(-1), dt2.AddDays(1));
            int totalreports = thearray[0] + thearray[1] + thearray[2] + thearray[3] + thearray[4];
            reportsCake.Series[0].Points.Clear();
            reportsCake.Titles.Clear();
            reportsCake.Titles.Add("Reports (Total: " + totalreports + ")");
            reportsCake.Series[0].IsValueShownAsLabel = true;
            for (int i = 0; i < thearray.Length; i++)
                reportsCake.Series[0].Points.AddXY(ad.returnReportTypeName(i), thearray[i]);
        }
        public void graph_FillArrayValuesWithType(DateTime dt1, DateTime dt2, string type)
        {
            dateAndValue[] thearray = graph_returnGoodDates(dt1, dt2);
            int month, day, year;
            double dif = (thearray[1].thedate - thearray[0].thedate).TotalDays;

            theGraph.Series[0].Points.Clear();
            theGraph.Series[0].Name = type;
            theGraph.Series[0].YValueType = ChartValueType.Int32;
            theGraph.Series[0].IsValueShownAsLabel = true;
            theGraph.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            theGraph.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            theGraph.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            theGraph.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            for (int i = 0; i < thearray.Length; i++)
            {
                DateTime from_date;
                if (i != 0)
                    from_date = thearray[i - 1].thedate;
                else
                    from_date = thearray[i].thedate;

                if (type == "Messages")
                {
                    thearray[i].thevalue = countTotalMessagesBetweenDates(from_date, thearray[i].thedate);
                    theGraph.Series[0].Color = Color.Aqua;
                }
                else if (type == "Users")
                {
                    thearray[i].thevalue = countTotalUsersRegisteredBetweenDates(from_date, thearray[i].thedate);
                    theGraph.Series[0].Color = Color.Orange;
                }
                else if (type == "Cars")
                {
                    thearray[i].thevalue = countTotalCarsBetweenDates(from_date, thearray[i].thedate);
                    theGraph.Series[0].Color = Color.Blue;
                }
                else if (type == "Reports")
                {
                    thearray[i].thevalue = countTotalReportsBetweenDates(from_date, thearray[i].thedate);
                    theGraph.Series[0].Color = Color.Red;
                }
                else if (type == "Earnings")
                {
                    thearray[i].thevalue = calcTotalEarningsBetweenDates(from_date, thearray[i].thedate);
                    theGraph.Series[0].Color = Color.Green;
                }

                month = thearray[i].thedate.Month;
                day = thearray[i].thedate.Day;
                year = thearray[i].thedate.Year%100;
                theGraph.Series[0].Points.AddXY(day + "/" + month + "/" + year, thearray[i].thevalue);
            }
            theGraph.ResetAutoValues();
        }
        public dateAndValue[] graph_returnGoodDates(DateTime dt1, DateTime dt2, string type = "Messages")
        {
            dateAndValue[] thearray = new dateAndValue[9];
            double difBetweenEachDay = ((dt2 - dt1).TotalDays) / thearray.Length;
            for (int i = 0; i < thearray.Length; i++)
            {
                dateAndValue dav = new dateAndValue();
                dav.thedate = dt1.AddDays(i * difBetweenEachDay);
                    
                if (i == thearray.Length - 1)
                    dav.thedate = dt2;

                thearray[i] = dav;
            }
            return thearray;
        }

        private void statsPrint_Click(object sender, EventArgs e)
        {
            DateTime dt_from = statsFromDate.Value;
            DateTime dt_to = statsToDate.Value;
            if((dt_to-dt_from).TotalDays < 9)
            {
                MessageBox.Show("Sorry, days difference must be at least 9 days.");
                return;
            }
            updateMessagesCake(dt_from, dt_to);
            updateUsersCake(dt_from, dt_to);
            updateCarsCake(dt_from, dt_to);
            updateReportsCake(dt_from, dt_to);

            if(statsType.SelectedIndex != -1)
                graph_FillArrayValuesWithType(dt_from, dt_to, statsType.Text);
        }
        public static bool IsNetworkAvailable(long minimumSpeed = 10000000)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                    continue;

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                    continue;

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                    continue;

                return true;
            }
            return false;
        }

        private void statsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt_from = statsFromDate.Value;
            DateTime dt_to = statsToDate.Value;
            if ((dt_to - dt_from).TotalDays < 9)
            {
                MessageBox.Show("Sorry, days difference must be at least 9 days.");
                return;
            }
            if (statsType.SelectedIndex != -1)
                graph_FillArrayValuesWithType(dt_from, dt_to, statsType.Text);
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView6.CurrentCell != null)
                MessageBox.Show(dataGridView6.CurrentCell.Value.ToString());
        }
    }
    public class dateAndValue
    {
        public DateTime thedate { get; set; }
        public int thevalue { get; set; }
        public dateAndValue()
        {
        }
    }
}

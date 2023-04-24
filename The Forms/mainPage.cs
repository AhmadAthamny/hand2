using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;


namespace Hand2
{
    public partial class mainPage : Form
    {
        /* status value keys:
         * 0 = Car pending - awaiting admin to approve/deny
         * 1 = Car denied/rejected by admin
         * 2 = Car deleted by owner/admin.
         * 3 = Car accepted/approved by admin.
         */


        /* buyOrRent Values:
         * 0 = buy
         * 1 = rent
         * */
        List<Cars> list = new List<Cars>();

        public User u;
        carDisplayInfo top = new carDisplayInfo();
        carDisplayInfo lastChosenCar = null;
        carRentSquare lastChosenCarRent = null;
        public int buyOrRent;
        string tmp_writtenPass = "";
        ComboBox fltrVersionC = new ComboBox();
        ComboBox fltrRentStation = new ComboBox();
        public Admin tmp_admpanel = new Admin();
        private User searchingForUser = null;
        private bool addedButtons = false;
        Button addCarButton = new Button();
        Button reportSellerButton = new Button();

        public Loading lding = null;
        public mainPage(User utmp, int buyOrRent_tmp)
        {
            InitializeComponent();
            lding = new Loading();
            lding.Show();
            buyOrRent = buyOrRent_tmp;
            this.KeyPreview = true;
            u = utmp;
            label2.Text = u.name;
            if (u.id != -1)
            {
                button5.Hide();
                label2.Location = new Point(button4.Location.X - label2.Width - 13, label2.Location.Y);
                label2.TextAlign = ContentAlignment.MiddleRight;
            }

            if (buyOrRent == 1)
            {
                fltrVersionC.Text = "Version";
                panel1.Width = 1085;
                panel1.Location = new Point(0, panel3.Location.Y + panel3.Height + 2);
                panel1.Height = this.Size.Height - panel3.Size.Height - 44 ;
                addRentStationButton();
                addCompanyButton();
                fltrVersionC.Location = new Point(fltrCompany.Location.X + fltrCompany.Width+10, fltrCompany.Location.Y);
                button1.Location = new Point(fltrVersionC.Location.X+fltrVersionC.Width + 10, fltrVersionC.Location.Y - 2);
                label3.Location = new Point(this.Size.Width / 4, label3.Location.Y);
                panel3.Controls.Add(fltrVersionC);
                fltrVersionC.Enabled = false;
                fltrType.Hide();
                fltrYear.Hide();
                fltrHand.Hide();
                fltrFromPrice.Hide();
                fltrGas.Hide();
                fltrGear.Hide();
                fltrKilometers.Hide();
                fltrVersion.Hide();
                label9.Hide();
                label5.Hide();
                label10.Hide();
                label11.Hide();
                label7.Hide();
                ciDescription.Hide();
                ciAddDate.Hide();
                ciLabelGasType.Hide();
                ciGasType.Hide();
                ciColor.Hide();
                ciCarType.Hide();
                ciSellerName.Hide();
                ciCompany.Hide();
                ciVersion.Hide();
                ciYear.Hide();
                ciKilos.Hide();
                ciHand.Hide();
                ciGear.Hide();
                ciPrice.Hide();
                btnSendMail.Hide();
                label1.Hide();
                label4.Hide();
                label6.Hide();
                fltrToPrice.Hide();
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                ciPictureBox.Hide();
                btnEditCar.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            initPage bb = new initPage(this, 2);
            bb.Show();
        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            RentNowPage rnp = new RentNowPage(u);
            DbCars db = new DbCars();
            rnp.updateAllRentAvails(db.forupdateavail_returnAllRentCars());
            updateCarInfo(-1);
            if (buyOrRent == 0)
                init(new SqlCommand("select * from cars where status=3", new DbCars().cnn));
            else
    
                init_rent(new SqlCommand("select * from carrent where available>0", new DbCars().cnn));
            if(lding != null)
            lding.Close();
            this.FormClosed += mainPage_FormClosed;
        }

        public void init(SqlCommand query)
        {
            top.Controls.Remove(addCarButton);
            top.Controls.Remove(reportSellerButton);
            this.Controls.Remove(top);
            top.Dispose();
            top = new carDisplayInfo();

            panel1.VerticalScroll.Value = 0;
            panel1.Controls.Clear();
            panel1.Controls.Add(label3);

            top.Width = panel3.Width;
            top.BackColor = Color.FromArgb(255, 173, 66);
            top.Location = new Point(panel1.Location.X-2, panel1.Location.Y - top.Height - 2);
            foreach (Control b in top.Controls)
            {
                b.Location = new Point(b.Location.X + 2, b.Location.Y);
            }
            this.Controls.Add(top);
            DbCars db = new DbCars();
            list = db.getallCars(query);
            carDisplayInfo[] arr = new carDisplayInfo[list.Count];
            int i = 0;
            foreach (Cars c in list)
            {
                carDisplayInfo d = new carDisplayInfo();
                d.Click += (sender, e) => d_Click(sender, e);
                d.label1.Click += (sender, e) => d_Click(d, e);
                d.label10.Click += (sender, e) => d_Click(d, e);
                d.label11.Click += (sender, e) => d_Click(d, e);
                d.label2.Click += (sender, e) => d_Click(d, e);
                d.label4.Click += (sender, e) => d_Click(d, e);
                d.label5.Click += (sender, e) => d_Click(d, e);
                d.label6.Click += (sender, e) => d_Click(d, e);
                d.label7.Click += (sender, e) => d_Click(d, e);
                d.label8.Click += (sender, e) => d_Click(d, e);
                d.MouseEnter += (sender, e) => d_MouseEnter(sender, e);
                d.MouseLeave += (sender, e) => d_MouseLeave(sender, e);
                d.label1.Text = c.company;
                d.label2.Text = c.version;
                d.label10.Text = c.year.ToString();
                d.label4.Text = "₪" + c.price.ToString("#,##0");
                d.label5.Text = c.hand.ToString();
                d.label6.Text = c.geartype;
                d.label7.Text = c.kilometers.ToString("#,##0") + " km";
                d.label8.Text = c.adddate.ToString("d");
                d.label11.Text = c.status.ToString();
                d.ciCarID.Text = c.id.ToString();
                d.BackColor = returnCarColor(c.status, 0);
                arr[i] = d;
                i++;
            }
            if (i == 0)
                label3.Visible = true;
            else label3.Visible = false;
            int y = 0;
            i = 0;
            foreach (carDisplayInfo c in arr) 
            {
                c.Location = new Point(0,y);
                panel1.Controls.Add(c);
                y += c.Height+2;
                i++;
            }
            if (!addedButtons)
            {
                addedButtons = true;

                addCarButton.Width = 100;
                addCarButton.Height = 24;
                addCarButton.Text = "Add Car";
                addCarButton.Location = new Point(ciPictureBox.Location.X+ciPictureBox.Width-addCarButton.Width, addCarButton.Location.Y);
                addCarButton.Click += (sender, e) => addCarButton_Click(addCarButton, e);
                top.Controls.Add(addCarButton);

                reportSellerButton.Width = 100;
                reportSellerButton.Height = 24;
                reportSellerButton.Text = "Report Seller";
                reportSellerButton.Location = new Point(addCarButton.Location.X - reportSellerButton.Width - 20, addCarButton.Location.Y);
                reportSellerButton.Click += (sender, e) => reportSellerButton_Click(reportSellerButton, e);
                if (u.id == -1) reportSellerButton.Enabled = false;
                top.Controls.Add(reportSellerButton);
            }
            else
            {
                top.Controls.Add(addCarButton);
                top.Controls.Add(reportSellerButton);
            }
        }
        public void init_rent(SqlCommand query, User searching_ForUser = null)
        {
            this.searchingForUser = searching_ForUser;

            panel1.VerticalScroll.Value = 0;
            panel1.Controls.Clear();
            panel1.Controls.Add(label3);
            top.Location = new Point(15, 15);
            DbCars db = new DbCars();
            List<RentCar> list_rent = new List<RentCar>();
            int[] rentedcars_array = null;
            if (searchingForUser != null)
                rentedcars_array = db.GetUserRentCarsArray(searchingForUser);
            else   
                if(u.id != -1)
                    rentedcars_array = db.GetUserRentCarsArray(u);

            list_rent = db.getallRentCars(query);

            if (this.Text.Contains(" results)"))
                this.Text = "Main Page";

            // Updating the mainpage title:
            if (list_rent.Count > 0)
                this.Text += " (" + list_rent.Count + " results)";
            else
                this.Text += " (No results)";

            if (list_rent.Count == 0)
            {
                label3.Show();
                return;
            }
            carRentSquare[] arr = new carRentSquare[list_rent.Count];
            int i = 0;
            foreach (RentCar c in list_rent)
            {
                carRentSquare d = new carRentSquare();
                d.Click += (sender, e) => d_Click(sender, e, d);
                d.MouseEnter += (sender, e) => d_MouseEnter(sender, e, d);
                d.MouseLeave += (sender, e) => d_MouseLeave(sender, e, d);
                d.cRentPicture.Click += (sender, e) => d_Click(sender, e, d);
                d.cRentByYou.Click += (sender, e) => d_Click(sender, e, d);
                d.cRentPicture.MouseEnter += (sender, e) => d_MouseEnter(sender, e, d);
                d.cRentPicture.MouseLeave += (sender, e) => d_MouseLeave(sender, e, d);
                d.button1.Click += (sender, e) => onClickRentNow(sender, e);
                d.button2.Click += (sender, e) => onClickShowMap(sender, e);
                d.button4.Click += (sender, e) => onClickFullPicture(sender, e);
                d.button5.Click += (sender, e) => onClickShowRentInfo(sender, e);
                d.cRentCompanyVersion.Text = c.company+" "+c.version;
                d.cRentYear.Text = c.year.ToString();
                d.cRentPrice.Text = "₪" + c.priceday.ToString("#,##0")+"/day";
                //d.cRentPrice.Parent = d.cRentPicture; /// This to make the price's background invisible but not needed anymore.
                if(u.id != -1 && rentedcars_array != null)
                    for (int b = 0; b < rentedcars_array.Length; b++)
                        if (rentedcars_array[b] == c.id)
                        {
                            d.cRentByYou.Visible = true;
                            d.cRentByYou.Parent = d.cRentPicture;
                        }
                d.cRentStationName.Text = db.returnCarAvail(c.available);
                d.cRentID.Text = c.id.ToString();
                d.cRentPicture.Image = byteArrayToImage(c.picture);
                if (c.available == -1)
                    d.cRentStationName.ForeColor = Color.Red;
                arr[i] = d;
                i++;
            }
            if (i == 0)
                label3.Visible = true;
            else label3.Visible = false;
            Point top_point = new Point(10, 15);
            i = 0;

            foreach (carRentSquare c in arr)
            {
                if (i % 3 == 0 && i != 0)
                {
                    top_point.X = 10;
                    top_point.Y += 270;
                }
                else if(i != 0)
                    top_point.X += 360;
                
                c.Location = top_point;
                panel1.Controls.Add(c);
                i++;
            }
        }
        public void onClickShowMap(object sender, EventArgs e)
        {
            initPage ip = new initPage();
            if (ip.IsNetworkAvailable())
            {
                DbCars db = new DbCars();
                RentCar rc = new RentCar();
                rc = db.returnRentCarInfo(int.Parse(lastChosenCarRent.cRentID.Text));
                if (rc.available <= -1)
                    MessageBox.Show("Sorry, this car is unavailable right now.");
                else
                {
                    dbRentStations dbrs = new dbRentStations();
                    rentStation rs = new rentStation();
                    rs = dbrs.returnStationInfo(rc.available);
                    carRentShowMap crsm = new carRentShowMap(this);
                    crsm.label1.Text = rs.name;
                    crsm.webBrowser1.Navigate(new Uri("https://www.google.com/maps/place/" + rs.location));
                    this.Enabled = false;
                    crsm.ShowDialog(this);
                }
            }
            else
                MessageBox.Show("Sorry, you need to be connected to the internet first.");
        }
        public void onClickFullPicture(object sender, EventArgs e)
        {
            DbCars db = new DbCars();
            RentCar rc = new RentCar();
            rc = db.returnRentCarInfo(int.Parse(lastChosenCarRent.cRentID.Text));
            carRentFullPicture crfp = new carRentFullPicture(this);
            crfp.pictureBox1.Image = byteArrayToImage(rc.picture);
            this.Enabled = false;
            crfp.ShowDialog(this);
        }
        public void onClickRentNow(object sender, EventArgs e)
        {
            if (u.id == -1)
            {  
                MessageBox.Show("Sorry, you must be logged in to rent a car.");
                return;
            }
            DbCars db = new DbCars();
            RentCar rc = new RentCar();
            rc = db.returnRentCarInfo(int.Parse(lastChosenCarRent.cRentID.Text));
            if (rc.available < 0)
            {
                MessageBox.Show("Sorry, this car is unavailable right now.");
                return;
            }
            RentNowPage crfp = new RentNowPage(u, rc, this);
            this.Enabled = false;
            crfp.ShowDialog(this);
        }
        public void onClickShowRentInfo(object sender, EventArgs e)
        {
            if (u.id == -1)
            {
                MessageBox.Show("Sorry, you must be logged in to rent a car.");
                return;
            }
            DbCars db = new DbCars();
            RentCar rc = new RentCar();
            rc = db.returnRentCarInfo(int.Parse(lastChosenCarRent.cRentID.Text));
            if (rc == null)
            {
                MessageBox.Show("Sorry, an error has occoured, please refresh the page.");
                return;
            }

            rentPeriod[] rp = db.returnCurrentAndComingCarPeriods(rc);
            if (rp == null)
            {
                MessageBox.Show("Sorry, an error has occured, please refresh the page.");
                return;
            }
            if(searchingForUser == null)
                showUserRentsList(rc, rp, this, u);
            else
                showUserRentsList(rc, rp, this, searchingForUser);
        }
        public void d_Click(object sender, EventArgs e, carRentSquare the_square = null)
        {
            if(the_square != null)
            {
                showCarSquareButtons(the_square);
                if(lastChosenCarRent != null && lastChosenCarRent != the_square)
                    lastChosenCarRent.BackColor = returnCarColor(3, 0);
                lastChosenCarRent = the_square;
                the_square.BackColor = returnCarColor(3, 2);
            }
            else
            {
                carDisplayInfo clickedCar = (carDisplayInfo)sender;
                int id = int.Parse(clickedCar.ciCarID.Text);
                clickedCar.BackColor = returnCarColor(int.Parse(clickedCar.label11.Text), 2);
                if (lastChosenCar != null && lastChosenCar != clickedCar)
                {
                    int laststatus = int.Parse(lastChosenCar.label11.Text);
                    lastChosenCar.BackColor = returnCarColor(laststatus, 0);
                }
                lastChosenCar = clickedCar;
                updateCarInfo(id);
            }
        }
        public void d_MouseEnter(object sender, EventArgs e, carRentSquare the_square = null)
        {
            if(the_square != null)
            {
                if(the_square != lastChosenCarRent)
                    the_square.BackColor = returnCarColor(3, 1);
            }
            else
            {
                carDisplayInfo hoveringCar = (carDisplayInfo)sender;
                if (hoveringCar != lastChosenCar)
                    hoveringCar.BackColor = returnCarColor(int.Parse(hoveringCar.label11.Text), 1);
            }
        }
        public void d_MouseLeave(object sender, EventArgs e, carRentSquare the_square = null)
        {
            if(the_square != null)
            {
                if(the_square != lastChosenCarRent)
                    the_square.BackColor = returnCarColor(3, 0);
            }
            else
            {
                carDisplayInfo leavingCar = (carDisplayInfo)sender;
                if (leavingCar != lastChosenCar)
                    leavingCar.BackColor = returnCarColor(int.Parse(leavingCar.label11.Text), 0);
            }
        }
        public void showUserRentsList(RentCar rc, rentPeriod[] rp, Form theform, User target = null)
        {
            if (rp == null)
            {
                MessageBox.Show("An error has occured, please refresh the page.");
                return;
            }
            int length = 0; ///// Presents how many rent periods belong to the "target" user. Because the car might be rented by different people.
            if (target == null)
                length = rp.Length; ///// Not looking for a rent period that is made by a specific user, so the length is the whole result which is the array length.
            if (target != null)
            {
                rentPeriod rp2 = new rentPeriod();
                for (int i = 0; i < rp.Length; i++)
                    if (rp[i].rent_by == target.id)
                    {
                        length++;
                        rp2 = rp[i];
                    }
                if (length == 1)
                {
                    ShowUserRentInfo(null, null, theform, target, rc, rp2);
                    return;
                }
                else if (length == 0)
                {
                    MessageBox.Show("This car isn't rented for the user and no booked-rents were found for this user.\n\nRefresh the page if it was an error.");
                    return;
                }
            }
            if ((target != null && rp.Length > 1) || (target == null && length > 0))
            {
                CarRentPeriods crp = new CarRentPeriods(theform);
                int last_y = 10;
                for (int i = 0; i < rp.Length; i++)
                {
                    if (rp[i] == null) continue;
                    if (target != null && rp[i].rent_by != target.id) continue;

                    DbUser db = new DbUser();
                    rentPeriod the_rp = rp[i];

                    User target2;
                    Label fromdate = new Label();
                    Label todate = new Label();
                    Label moreInfo = new Label();
                    Label userid = new Label();
                    if (rp[i].to_date < DateTime.Now)
                    {
                        fromdate.ForeColor = Color.Gray;
                        todate.ForeColor = Color.Gray;
                        userid.ForeColor = Color.Gray;
                        moreInfo.ForeColor = Color.Gray;
                    }
                    if (the_rp.rent_by == -1)
                    {
                        dbRentStations dbrs = new dbRentStations();
                        if (the_rp.from_date >= DateTime.Now)
                        {
                            userid.ForeColor = Color.Red;
                            todate.ForeColor = Color.Red;
                            fromdate.ForeColor = Color.Red;
                            todate.Text = "Car will be moved to " + dbrs.returnStationInfo(rp[i].return_to).name + " rent station!";
                        }
                        else
                        {
                            userid.ForeColor = Color.IndianRed;
                            todate.ForeColor = Color.IndianRed;
                            fromdate.ForeColor = Color.IndianRed;
                            todate.Text = "This car was moved to " + dbrs.returnStationInfo(rp[i].return_to).name + " by a manager!";
                        }
                        userid.Text = "N/A";
                        fromdate.Text = rp[i].from_date.ToString("g");
                    }
                    else
                    {
                        userid.Text = rp[i].rent_by.ToString();
                        fromdate.Text = rp[i].from_date.ToString("g");
                        todate.Text = rp[i].to_date.ToString("g");
                        moreInfo.Text = "Click Here For More Information";
                        moreInfo.Font = new Font(moreInfo.Font.Name, moreInfo.Font.SizeInPoints, FontStyle.Underline);
                    
                        target2 = db.returnUserInfoByID(the_rp.rent_by);
                        moreInfo.Click += (sender, e) => ShowUserRentInfo(null, null, crp, target2, rc, the_rp);
                    }
                    userid.AutoSize = true;
                    fromdate.AutoSize = true;
                    moreInfo.AutoSize = true;
                    todate.AutoSize = true;

                    userid.Location = new Point(crp.CRPUserID.Location.X, last_y);
                    fromdate.Location = new Point(crp.CRPFromDate.Location.X, last_y);
                    todate.Location = new Point(crp.CRPToDate.Location.X, last_y);
                    moreInfo.Location = new Point(crp.CRPMoreInfo.Location.X, last_y);
                    last_y += 30;

                    crp.panel1.Controls.Add(fromdate);
                    crp.panel1.Controls.Add(todate);
                    crp.panel1.Controls.Add(moreInfo);
                    crp.panel1.Controls.Add(userid);
                }
                theform.Enabled = false;
                crp.ShowDialog(theform);
            }
        }
        public void ShowUserRentInfo(object sender, EventArgs e, Form theform, User target, RentCar rc, rentPeriod rp)
        {

            dbRentStations rs = new dbRentStations();
            RentNowPage crfp = new RentNowPage(target, rc, theform);
            crfp.rnpDoPayment.Visible = false;

            TextBox tb = new TextBox(); /// Pickup From Station
            tb.Text = rs.returnStationInfo(rp.pickup_from).name;
            tb.Location = crfp.rnpPickupFrom.Location;
            tb.Width = crfp.rnpPickupFrom.Width;
            tb.ReadOnly = true;
            crfp.Controls.Add(tb);
            crfp.Controls.Remove(crfp.rnpPickupFrom);

            tb = new TextBox(); /// Return To Station
            tb.Text = rs.returnStationInfo(rp.return_to).name;
            tb.Location = crfp.rnpReturnTo.Location;
            tb.Width = crfp.rnpReturnTo.Width;
            tb.ReadOnly = true;
            crfp.Controls.Add(tb);
            crfp.Controls.Remove(crfp.rnpReturnTo);

            tb = new TextBox(); /// Pickup Date
            tb.Text = rp.from_date.ToString("g");
            tb.Location = crfp.rnpPickupDate.Location;
            tb.Width = crfp.rnpPickupDate.Width;
            tb.ReadOnly = true;
            crfp.Controls.Add(tb);
            crfp.Controls.Remove(crfp.rnpPickupDate);

            tb = new TextBox(); /// Return Date
            tb.Text = rp.to_date.ToString("g");
            tb.Location = crfp.rnpReturnDate.Location;
            tb.Width = crfp.rnpReturnDate.Width;
            tb.ReadOnly = true;
            crfp.Controls.Add(tb);
            crfp.Controls.Remove(crfp.rnpReturnDate);

            int totaldays = (rp.to_date.Date - rp.from_date.Date).Days + 1;
            crfp.rnpAmount.Text = "₪" + (totaldays * rp.moneyperday).ToString("#,##0");
            crfp.rnpTotalDays.Text = "Total Rent Days: " + totaldays;

            string[] cc_and_number = new string[6];
            cc_and_number = rp.rent_info.Split('#').Select(n => Convert.ToString(n)).ToArray();

            crfp.rnpPhone.Text = cc_and_number[0];
            crfp.rnpCardNum.Text = cc_and_number[1];
            crfp.rnpExpiryMonth.Text = cc_and_number[2];
            crfp.rnpExpiryYear.Text = cc_and_number[3];
            crfp.rnpCSC.Text = cc_and_number[4];
            crfp.rnpPrice.Text = "Price: ₪" + (rp.moneyperday).ToString("#,##0");
            crfp.rnpPickupHour.Visible = false;
            crfp.rnpPickupMinute.Visible = false;
            crfp.rnpReturnHour.Visible = false;
            crfp.rnpReturnMinute.Visible = false;
            crfp.label18.Visible = false;
            crfp.label19.Visible = false;

            crfp.rnpPhone.ReadOnly = true;
            crfp.rnpCardNum.ReadOnly = true;
            crfp.rnpExpiryMonth.ReadOnly = true;
            crfp.rnpExpiryYear.ReadOnly = true;
            crfp.rnpCSC.ReadOnly = true;
            crfp.rnpPickupHour.Enabled = false;
            crfp.rnpPickupMinute.Enabled = false;
            crfp.rnpReturnHour.Enabled = false;
            crfp.rnpReturnMinute.Enabled = false;


            theform.Enabled = false;
            crfp.ShowDialog(theform);
        }
        public void showCarSquareButtons(carRentSquare crs)
        {
            if (lastChosenCarRent != null)
                hideCarSquareButtons(lastChosenCarRent);
            if(crs != null)
            {
                crs.button1.Visible = true;
                crs.button2.Visible = true;
                crs.button4.Visible = true;
                if (crs.cRentByYou.Visible)
                    crs.button5.Visible = true;
            }
            panel1.ScrollControlIntoView(crs);
        }
        public void hideCarSquareButtons(carRentSquare crs)
        {
            if (crs != null)
            {
                crs.button1.Visible = false;
                crs.button2.Visible = false;
                crs.button4.Visible = false;
                crs.button5.Visible = false;
            }
        }
        public void updateCarInfo(int carid)
        {
            DbCars dbc = new DbCars();
            DbUser db = new DbUser();
            Cars c;
            if (carid != -1)
            {
                c = dbc.returnCarInfo(carid);
                ciCompany.Text = c.company;
                ciVersion.Text = c.version;
                ciCarType.Text = dbc.returnCartypeName(c.cartype);
                ciYear.Text = c.year.ToString();
                ciAddDate.Text = c.adddate.ToString("d");
                ciPrice.Text = "₪" + c.price.ToString("#,##0");
                ciKilos.Text = c.kilometers.ToString("#,##0") + " km";
                ciHand.Text = c.hand.ToString();
                ciGear.Text = c.geartype.ToString();
                ciGasType.Text = c.gastype;
                ciColor.Text = c.color;
                ciSellerName.Text = db.getUserNamebyID(c.sellerid);
                ciPictureBox.Image = byteArrayToImage(c.pic);
                ciDescription.Text = c.description;
                if (u.id != -1)
                {
                    if (u.id == c.sellerid)
                    {
                        reportSellerButton.Enabled = false;
                        btnSendMail.Enabled = false;
                        btnEditCar.Enabled = true;
                    }
                    else
                    {
                        reportSellerButton.Enabled = true;
                        btnSendMail.Enabled = true;
                        if (new Admin().CanManageCars(u))
                            btnEditCar.Enabled = true;
                        else btnEditCar.Enabled = false;
                    }
                }
            }
            else
            {
                ciCompany.Text = " ";
                ciVersion.Text = " ";
                ciCarType.Text = " ";
                ciYear.Text = " ";
                ciAddDate.Text = " ";
                ciPrice.Text = " ";
                ciKilos.Text = " ";
                ciHand.Text = " ";
                ciGear.Text = " ";
                ciGasType.Text = " ";
                ciColor.Text = " ";
                ciSellerName.Text = " ";
                ciDescription.Text = " ";
                ciPictureBox.Image = null;
                reportSellerButton.Enabled = false;
                btnSendMail.Enabled = false;
                btnEditCar.Enabled = false;
            }
            u.viewingCarID = carid;
        }
        public void updateCarDisplayInfo(carDisplayInfo d, Cars c)
        {
            d.label1.Text = c.company;
            d.label2.Text = c.version;
            d.label10.Text = c.year.ToString();
            d.label4.Text = "₪" + c.price.ToString("#,##0");
            d.label5.Text = c.hand.ToString();
            d.label6.Text = c.geartype;
            d.label7.Text = c.kilometers.ToString("#,##0") + " km";
            d.label11.Text = c.status.ToString();
            d.ciCarID.Text = c.id.ToString();
            d.BackColor = returnCarColor(c.status, 0);
        }
        private void mainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Enabled)
                System.Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ciCompany_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void mainPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!tmp_admpanel.CanViewAdminPanel(u)) return;
            if (e.KeyChar.ToString() == "a")
                tmp_writtenPass = "a";
            else
            {
                tmp_writtenPass = tmp_writtenPass.Insert(tmp_writtenPass.Length, e.KeyChar.ToString());
                if (tmp_writtenPass == "admin")
                {
                    this.FormClosed -= mainPage_FormClosed;
                    this.Close();
                    AdminForm af = new AdminForm(u, this.buyOrRent);
                    af.Show();
                }
            }
        }

        private void mainPage_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }

        private void mainPage_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buyOrRent == 0)
            {
                updateCarInfo(-1);
                SqlCommand query = new SqlCommand();
                try
                {
                    string the_query = "select * from cars";
                    string lookingfor_string = "Looking for:";
                    bool addedWHEREBefore = false;
                    if (fltrType.SelectedIndex > 0)
                    {
                        addedWHEREBefore = true;
                        the_query += " where cartype=@type";
                        query.Parameters.AddWithValue("@type", fltrType.SelectedIndex-1);
                        lookingfor_string += ", "+fltrType.Text;
                    }
                    if (fltrCompany.SelectedIndex > 0)
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "company=@company";
                        query.Parameters.AddWithValue("@company", fltrCompany.Text);
                        lookingfor_string += ", " + fltrCompany.Text;
                    }
                    if (fltrVersion.TextLength > 0 && fltrVersion.Text != "Version")
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "version like @version";
                        query.Parameters.AddWithValue("@version", "%"+fltrVersion.Text+"%");
                        lookingfor_string += ", " + fltrVersion.Text;
                    }
                    if (IsNumeric(fltrYear.Text) && fltrYear.TextLength > 0 && fltrYear.Text != "Year")
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "year>=@year";
                        query.Parameters.AddWithValue("@year", int.Parse(fltrYear.Text));
                        lookingfor_string += ", " + fltrYear.Text+" or higher";
                    }
                    if (IsNumeric(fltrHand.Text) && fltrHand.TextLength > 0 && fltrHand.Text != "Hand")
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "hand<=@hand";
                        query.Parameters.AddWithValue("@hand", int.Parse(fltrHand.Text));
                        lookingfor_string += ", hand " + fltrHand.Text+" or lower";
                    }
                    if (fltrGear.SelectedIndex > 0)
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "gear=@gear";
                        query.Parameters.AddWithValue("@gear", fltrGear.Text);
                        lookingfor_string += ", " + fltrGear.Text;
                    }
                    if (fltrGas.SelectedIndex > 0)
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "gastype=@gas";
                        query.Parameters.AddWithValue("@gas", fltrGas.Text);
                        lookingfor_string += ", " + fltrGas.Text;
                    }
                    if (IsNumeric(fltrFromPrice.Text) &&  fltrFromPrice.TextLength > 0 && fltrFromPrice.Text != "From Price")
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "price>=@fromprice";
                        query.Parameters.AddWithValue("@fromprice", int.Parse(fltrFromPrice.Text));
                        lookingfor_string += ", from ₪" + int.Parse(fltrFromPrice.Text).ToString("#,##0");
                    }
                    if (IsNumeric(fltrToPrice.Text) && fltrToPrice.TextLength > 0 && fltrToPrice.Text != "To Price")
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "price<=@toprice";
                        query.Parameters.AddWithValue("@toprice", int.Parse(fltrToPrice.Text));
                        lookingfor_string += ", to ₪" + int.Parse(fltrToPrice.Text).ToString("#,##0");
                    }
          
                    if (IsNumeric(fltrKilometers.Text) && fltrKilometers.TextLength > 0 && fltrKilometers.Text != "Max Kilometers")
                    {
                        if (addedWHEREBefore == true)
                            the_query += " and ";
                        else
                        {
                            addedWHEREBefore = true;
                            the_query += " where ";
                        }
                        the_query += "kilodriven<=@kilos";
                        query.Parameters.AddWithValue("@kilos", int.Parse(fltrKilometers.Text));
                        lookingfor_string += ", " + int.Parse(fltrKilometers.Text).ToString("#,##0")+" kilometers or lower";
                    }
                    if (addedWHEREBefore == true)
                        the_query += " and ";
                    else
                        the_query += " where ";
                    the_query += "status=3";

                    query.CommandText = the_query;
                    query.Connection = new DbCars().cnn;
                    if (lookingfor_string.Length > 12)
                        this.Text = "Main Page - " + lookingfor_string.Remove(12, 1);
                    else this.Text = "Main Page";
                    init(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                string query2;
                try
                {
                    if (fltrCompany.Text == "Company" || fltrCompany.Text == "Any")
                    {
                        if (fltrRentStation.Text == "Station" || fltrRentStation.Text == "Any")
                            query2 = string.Format("select * from CarRent where available!=-2");
                        else
                            query2 = string.Format("select * from CarRent where available=(select id from rent_stations where name=@name)");
                    }
                    else if (fltrVersionC.Enabled == false || fltrVersionC.Text == "Version" || fltrVersionC.Text == "Any")
                    {
                        if (fltrRentStation.Text == "Station" || fltrRentStation.Text == "Any")
                            query2 = string.Format("select * from CarRent where available!=-2 and company=@company");
                        else
                            query2 = string.Format("select * from CarRent where company=@company and available=(select id from rent_stations where name=@name)");

                    }
                    else
                    {
                        if (fltrRentStation.Text == "Station" || fltrRentStation.Text == "Any")
                            query2 = string.Format("select * from CarRent where company=@company and version=@version and available!=-2");
                        else
                            query2 = string.Format("select * from CarRent where company=@company and version=@version and available=(select id from rent_stations where name=@name)");
                    }
                    SqlCommand query = new SqlCommand(query2, new DbCars().cnn);
                    query.Parameters.AddWithValue("@company", fltrCompany.Text);
                    query.Parameters.AddWithValue("@name", fltrRentStation.Text);
                    query.Parameters.AddWithValue("@version", fltrVersionC.Text);

                    string searchText = "Main Page";
                    bool foundsmth_tmp = false;;
                    if (fltrRentStation.SelectedIndex > 0)
                    {
                        if (!foundsmth_tmp)
                        {
                            foundsmth_tmp = !foundsmth_tmp;
                            searchText += " - Looking for a rent car: in " + fltrRentStation.Text;
                        }
                    }
                    if (fltrCompany.SelectedIndex > 0)
                    {
                        if (!foundsmth_tmp)
                        {
                            foundsmth_tmp = !foundsmth_tmp;
                            searchText += " - Looking for a rent car: " + fltrCompany.Text;
                        }
                        else
                        {
                            searchText += ", " + fltrCompany.Text;
                        }
                    }
                    if (fltrVersionC.SelectedIndex > 0 && fltrVersionC.Enabled)
                    {
                        if (!foundsmth_tmp)
                        {
                            foundsmth_tmp = !foundsmth_tmp;
                            searchText += " - Looking for: "+ fltrVersionC.Text;
                        }
                        else
                        {
                            searchText += ", " + fltrVersionC.Text;
                        }
                    }
                    this.Text = searchText;
                    init_rent(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addCarButton_Click(object sender, EventArgs e)
        {
            if (u.id == -1)
            {
                MessageBox.Show("Please login first to add a car.");
            }
            else
            {
                addCar adcar = new addCar(u, this.buyOrRent);
                this.FormClosed -= mainPage_FormClosed;
                this.Hide();
                adcar.ShowDialog(this);
                this.Close();
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            User u2 = new User();
            DbCars dbcars = new DbCars();
            DbUser dbuser = new DbUser();
            Cars c = new Cars();
            this.Enabled = false;
            c = dbcars.returnCarInfo(u.viewingCarID);
            u2 = dbuser.returnUserInfoByID(c.sellerid);
            SendEmailForm sef = new SendEmailForm(u, u2, this, c);
            sef.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            MainPageMenu mpm = new MainPageMenu(u, this);
            mpm.ShowDialog(this);
        }

        private void mainPage_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void ciDescription_Click(object sender, EventArgs e)
        {
            if(u.viewingCarID != -1)
                MessageBox.Show("Full description:\n" + ciDescription.Text);
        }
        private Color returnCarColor(int status, int mousevalue)
        {
            // mousevalue:
            // 0 = mouse not on it
            // 1 = mouse on it
            // 2 = clicked
            if (status == 0)
            {
                if (mousevalue == 0)
                    return Color.FromArgb(237, 232, 92);
                else if (mousevalue == 1)
                    return Color.FromArgb(240, 235, 96);
                else if (mousevalue == 2)
                    return Color.FromArgb(232, 227, 93);
                else
                    return Color.FromArgb(237, 232, 92);
            }
            else if (status == 1)
            {
                if (mousevalue == 0)
                    return Color.FromArgb(242, 151, 102);
                else if (mousevalue == 1)
                    return Color.FromArgb(247, 154, 104);
                else if (mousevalue == 2)
                    return Color.FromArgb(237, 148, 100);
                else
                    return Color.FromArgb(242, 151, 102);
            }
            else if (status == 2)
            {
                if (mousevalue == 0)
                    return Color.FromArgb(245, 100, 100);
                else if (mousevalue == 1)
                    return Color.FromArgb(252, 104, 104);
                else if (mousevalue == 2)
                    return Color.FromArgb(230, 94, 94);
                else
                    return Color.FromArgb(245, 100, 100);
            }
            else if (status == 3)
            {
                if (mousevalue == 0)
                    return Color.FromArgb(212, 212, 212);
                else if (mousevalue == 1)
                    return Color.FromArgb(227, 227, 227);
                else if (mousevalue == 2)
                    return Color.FromArgb(240, 240, 240);
                else
                    return Color.FromArgb(212, 212, 212);
            }
            else return Color.FromArgb(212, 212, 212);
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            DbCars pp = new DbCars();
            Cars theCar = pp.returnCarInfo(int.Parse(lastChosenCar.ciCarID.Text));
            if (theCar.status != 3)
            {
                btnEditCar.Enabled = false;
                MessageBox.Show("Sorry, this car cannot be edited right now because of its current status.");
            }
            else
            {
                this.Enabled = false;
                editCar mpm = new editCar(u, theCar, this, lastChosenCar);
                mpm.ShowDialog(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            initPage bb = new initPage(this, 2);
            bb.Show();
        }
        public void updateVersions(string c_name)
        {
            Point theVersionLocation = fltrVersionC.Location;
            panel3.Controls.Remove(fltrVersionC);
            fltrVersionC = new ComboBox();
            fltrVersionC.Text = "Version";
            fltrVersionC.Location = theVersionLocation;
            panel3.Controls.Add(fltrVersionC);
            string to_check = null;
            DbCars pp = new DbCars();
            SqlCommand selectCarInfo = new SqlCommand("select * from CarRent where company=@cname and available>0", pp.cnn);
            selectCarInfo.Parameters.AddWithValue("@cname", c_name);
            DataRowCollection rows = pp.ReturnDS(selectCarInfo).Tables[0].Rows;
            string[] versionsArray = new string[rows.Count];
            if (rows.Count == 0)
                fltrVersionC.Enabled = false;
            else fltrVersionC.Enabled = true;
            for (int i = 0, j = 0; i < rows.Count; i++)
            {
                if (to_check != null)
                {
                    if (!to_check.Contains("#" + (string)(rows[i]["version"])))
                    {
                        versionsArray[j] = (string)(rows[i]["version"]);
                        to_check += "#" + (string)(rows[i]["version"]);
                        j++;
                    }
                }
                else if (to_check == null)
                {
                    versionsArray[j] = (string)(rows[i]["version"]);
                    to_check = "#" + (string)(rows[i]["version"]);
                    j++;
                }
            }
            fltrVersionC.Items.Add("Any");
            foreach (String s in versionsArray)
            {
                if (s == null) break;
                fltrVersionC.Items.Add(s);
            }
        }
        public void addRentStationButton()
        {
            fltrRentStation.Location = new Point(fltrType.Location.X, fltrType.Location.Y);
            fltrRentStation.Width = 120;
            fltrRentStation.Text = "Station";
            panel3.Controls.Add(fltrRentStation);
            string to_check = null;
            DbCars pp = new DbCars();
            SqlCommand selectStationInfo = new SqlCommand("select * from rent_stations where id>0 and status=1", pp.cnn);
            DataRowCollection rows = pp.ReturnDS(selectStationInfo).Tables[0].Rows;
            string[] stationsArray = new string[rows.Count];
            if (rows.Count == 0)
                fltrRentStation.Enabled = false;
            else fltrRentStation.Enabled = true;
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
            fltrRentStation.Items.Add("Any");
            foreach (String s in stationsArray)
            {
                if (s == null) break;
                fltrRentStation.Items.Add(s);
            }
        }
        public void addCompanyButton()
        {
            panel3.Controls.Remove(fltrCompany);
            fltrCompany = new ComboBox();
            fltrCompany.Items.Clear();
            fltrCompany.Location = new Point(fltrRentStation.Location.X+fltrRentStation.Width+10, fltrType.Location.Y);
            fltrCompany.Width = 120;
            fltrCompany.Text = "Company";
            fltrCompany.SelectedIndexChanged += (sender, e) => fltrCompany_SelectedIndexChanged(sender, e);
            panel3.Controls.Add(fltrCompany);
            string to_check = null;
            DbCars pp = new DbCars();
            SqlCommand selectCarInfo = new SqlCommand("select * from CarRent where available>0", pp.cnn);
            DataRowCollection rows = pp.ReturnDS(selectCarInfo).Tables[0].Rows;
            string[] companiesArray = new string[rows.Count];
            if (rows.Count == 0)
                fltrCompany.Enabled = false;
            else fltrCompany.Enabled = true;
            for (int i = 0, j = 0; i < rows.Count; i++)
            {
                if (to_check != null)
                {
                    if (!to_check.Contains("#" + (string)(rows[i]["company"])))
                    {
                        companiesArray[j] = (string)(rows[i]["company"]);
                        to_check += "#" + (string)(rows[i]["company"]);
                        j++;
                    }
                }
                else if (to_check == null)
                {
                    companiesArray[j] = (string)(rows[i]["company"]);
                    to_check = "#" + (string)(rows[i]["company"]);
                    j++;
                }
            }
            fltrCompany.Items.Add("Any");
            foreach (String s in companiesArray)
            {
                if (s == null) break;
                fltrCompany.Items.Add(s);
            }
        }
        private void fltrCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateVersions(fltrCompany.Text);
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void leftTheTextArea(object sender, EventArgs e)
        {
            if (sender == fltrType && fltrType.SelectedIndex == -1)
                fltrType.Text = "Type";
            if (sender == fltrCompany && fltrCompany.SelectedIndex == -1)
                fltrCompany.Text = "Company";
            if (sender == fltrVersion && fltrVersion.TextLength == 0)
                fltrVersion.Text = "Version";
            if (sender == fltrYear && (fltrYear.TextLength == 0 || !IsNumeric(fltrYear.Text)))
                fltrYear.Text = "Year";
            if (sender == fltrHand && (fltrHand.TextLength == 0 || !IsNumeric(fltrHand.Text)))
                fltrHand.Text = "Hand";
            if (sender == fltrGear && fltrGear.SelectedIndex == -1)
                fltrGear.Text = "Gear Type";
            if (sender == fltrGas && fltrGas.SelectedIndex == -1)
                fltrGas.Text = "Gas Type";
            if (sender == fltrKilometers && (fltrKilometers.TextLength == 0 || !IsNumeric(fltrKilometers.Text)))
                fltrKilometers.Text = "Max Kilometers";
            if (sender == fltrFromPrice && (fltrFromPrice.TextLength == 0 || !IsNumeric(fltrFromPrice.Text)))
                fltrFromPrice.Text = "From Price";
            if (sender == fltrToPrice && (fltrToPrice.TextLength == 0 || !IsNumeric(fltrToPrice.Text)))
                fltrToPrice.Text = "To Price";
        }

        private void reportSellerButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DbCars db = new DbCars();
            feedBack fb = new feedBack(u, db.returnCarInfo(u.viewingCarID).sellerid, this);
            fb.f_type = fb.feedbackType_userReport;
            fb.ShowDialog(this);    
        }
    }
}

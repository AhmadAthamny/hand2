using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.IO;

namespace Hand2
{
    public partial class RentNowPage : Form
    {
        DateTime toreturn_tmp;
        User u;
        RentCar rc;
        Form mp;
        rentStation rent_station;
        DateTime value_beforeOpen;
        DateTime returnValue_beforeOpen;
        public RentNowPage(User utmp, RentCar rctmp = null, Form mptmp = null)
        {
            InitializeComponent();
            if(mptmp != null && rctmp != null)
            {
                u = utmp;
                rc = rctmp;
                mp = mptmp;
                rnpCompany.Text = "Company: "+rc.company;
                rnpVersion.Text = "Version: "+rc.version;
                rnpYear.Text = "Year: "+rc.year.ToString();
                rnpPrice.Text = "Price: ₪" + rc.priceday.ToString("#,##0") + "/day";
                rnpFullName.Text = u.name;
                rnpEmail.Text = u.email;
                rnpUserID.Text = u.user_id;
                updateReturnStationList();
                rnpPickupDate.Format = DateTimePickerFormat.Custom;
                rnpReturnDate.Format = DateTimePickerFormat.Custom;
                rnpPickupDate.CustomFormat = "dd/MM/yyyy";
                rnpReturnDate.CustomFormat = "dd/MM/yyyy";
                updatePickupDate(DateTime.Now.AddDays(1));
                rnpReturnDate.CloseUp += new EventHandler(onChangeReturnDate);
                rnpReturnDate.KeyDown += new KeyEventHandler(onChangeReturnDate);
                rnpReturnDate.Leave += new EventHandler(onChangeReturnDate);
                //pictureBox1.Image = byteArrayToImage(rc.picture);
            }
        }

        private void RentNowPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            mp.Enabled = true;
            this.Close();
        }
        private void updateOpenOrNo()
        {
            if (DateTime.Now.Hour < rent_station.opensfrom || DateTime.Now.Hour >= rent_station.opensto)
            {
                rnpOpenOrNo.Text = "Closed";
                rnpOpenOrNo.ForeColor = Color.Red;
            }
            else
            {
                rnpOpenOrNo.Text = "Open";
                rnpOpenOrNo.ForeColor = Color.Green;
            }
            rnpPickupHour.Minimum = 0; /// to avoid buggy bugs.
            rnpPickupHour.Minimum = rent_station.opensfrom;
            rnpPickupHour.Maximum = rent_station.opensto - 1;
            rnpPickupHour.Value = rnpPickupHour.Minimum;
        }
        private bool IsPickupStationOpenInTime(int hour)
        {
            DateTime dt = new DateTime().Date;
            dbRentStations dbrs = new dbRentStations();
            rentStation rs = new rentStation();
            rs = dbrs.returnStationInfoFromName(rnpPickupFrom.Text);
            if (hour < rs.opensfrom) return false;
            else if (hour >= rs.opensto) return false;
            else return true;
        }
        private bool IsReturnStationOpenInTime(int hour)
        {
            DateTime dt = new DateTime().Date;
            dbRentStations dbrs = new dbRentStations();
            rentStation rs = new rentStation();
            rs = dbrs.returnStationInfoFromName(rnpReturnTo.Text);
            if (hour < rs.opensfrom) return false;
            else if (hour >= rs.opensto) return false;
            else return true;
        }
        private string GetPickupStationOpenTime( )
        {
            dbRentStations dbrs = new dbRentStations();
            rentStation rs = new rentStation();
            rs = dbrs.returnStationInfoFromName(rnpPickupFrom.Text);
            return rs.opensfrom + ":00" + " to " + rs.opensto + ":00";
        }
        private string GetReturnStationOpenTime( )
        {
            dbRentStations dbrs = new dbRentStations();
            rentStation rs = new rentStation();
            rs = dbrs.returnStationInfoFromName(rnpReturnTo.Text);
            return rs.opensfrom + ":00" + " to " + rs.opensto + ":00";
        }
        public void updateReturnStationList()
        {
            rnpReturnTo.Text = "Station";
            string to_check = null;
            DbCars pp = new DbCars();
            SqlCommand selectStationInfo = new SqlCommand("select * from rent_stations where id>0 and status=1", pp.cnn);
            DataRowCollection rows = pp.ReturnDS(selectStationInfo).Tables[0].Rows;
            string[] stationsArray = new string[rows.Count];
            if (rows.Count == 0)
                rnpReturnTo.Enabled = false;
            else rnpReturnTo.Enabled = true;
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
                rnpReturnTo.Items.Add(s);
            }
        }
        public void updatePickupDate(DateTime dt)
        {
            rnpReturnDate.MinDate = DateTime.Now; ///// Just to avoid a crash/timeout.
            rnpPickupDate.MinDate = returnFirstDayPossible(DateTime.Now.AddDays(1).Date);
            if (rnpPickupDate.MinDate >= DateTime.Now.AddMonths(3))
            {
                MessageBox.Show("Sorry, this car is rented for the next 3 months.");
                rnpPickupFrom.Text = getThePickupStation(rnpPickupDate.Value).name;
                rnpPickupDate.Enabled = false;
                rnpReturnDate.Enabled = false;
                rnpDoPayment.Enabled = false;
                return;
            }
            rnpPickupDate.MaxDate = DateTime.Now.AddMonths(3);
            rnpReturnDate.MaxDate = returnLastDayPossible(rnpPickupDate.Value.Date);
            rnpReturnDate.MinDate = rnpPickupDate.Value.AddDays(1);
            rnpReturnDate.Value = rnpReturnDate.MinDate;
            value_beforeOpen = rnpPickupDate.Value;
            returnValue_beforeOpen = rnpReturnDate.Value;
            rnpPickupFrom.Text = getThePickupStation(rnpPickupDate.Value.Date).name;
            updateTotalDaysAmount();
        }
        public rentPeriod[] returnAllPeriods(int carid, SqlCommand thesqlcmd = null)
        {
            DbCars pp = new DbCars();
            if(thesqlcmd == null)
                thesqlcmd = new SqlCommand("select * from rent_periods where carid=@carid order by from_date asc");

            thesqlcmd.Connection = pp.cnn;
            thesqlcmd.Parameters.AddWithValue("@carid", carid);
            DataRowCollection rows = pp.ReturnDS(thesqlcmd).Tables[0].Rows;
            rentPeriod[] the_array = new rentPeriod[rows.Count];
            if (rows.Count == 0)
                return null;
            for (int i = 0; i < rows.Count; i++)
            {
                the_array[i] = new rentPeriod();
                the_array[i].id = (int)(rows[i]["id"]);
                the_array[i].from_date = (DateTime)(rows[i]["from_date"]);
                the_array[i].to_date = (DateTime)(rows[i]["to_date"]);
                the_array[i].pickup_from = (int)(rows[i]["pickup_from"]);
                the_array[i].return_to = (int)(rows[i]["return_to"]);
            }
            return the_array;
        }
        public DateTime checkIfTimeIsInPeriod(DateTime dt)
        {
            rentPeriod[] the_array = returnAllPeriods(rc.id);
            if (the_array == null)
                return new DateTime(0);
            for (int i = 0; i < the_array.Length; i++)
            {
                if (dt.Date >= the_array[i].from_date.Date && dt.Date <= the_array[i].to_date.Date)
                    return the_array[i].to_date.Date;
            }
            return new DateTime(0).Date;
        }
        public bool canBeSelected(DateTime dt)
        {
            rentPeriod[] the_array = returnAllPeriods(rc.id);
            if (the_array == null)
                return true;
            else
                for (int i = 0; i < the_array.Length; i++)
                    if ((dt.Date >= the_array[i].from_date.Date && dt.Date <= the_array[i].to_date.Date) ||
                        (dt.AddDays(1).Date >= the_array[i].from_date.Date && dt.AddDays(1).Date <= the_array[i].to_date.Date))
                        return false;
            return true;
        }
        public DateTime returnLastDayPossible(DateTime dt)
        {
            rentPeriod[] the_array = returnAllPeriods(rc.id);
            if (the_array == null)
                return dt.AddDays(29).Date;
            for (int i = 0; i < the_array.Length; i++)
                if (dt.Date <= the_array[i].from_date.Date && the_array[i].from_date.Date <= dt.AddDays(29).Date)
                    return the_array[i].from_date.AddDays(-1).Date;
            return dt.AddDays(29).Date;
        }
        public DateTime returnFirstDayPossible(DateTime dt)
        {
            DateTime first_day = checkIfTimeIsInPeriod(dt.Date);
            DateTime second_Day = checkIfTimeIsInPeriod(dt.AddDays(1).Date);
            if (first_day != new DateTime(0))
                return returnFirstDayPossible(first_day.AddDays(1).Date);
            else if (second_Day != new DateTime(0))
                return returnFirstDayPossible(second_Day.AddDays(1).Date);
            return dt;
        }
        public void updateTotalDaysAmount()
        {
            int totaldays = (rnpReturnDate.Value - rnpPickupDate.Value).Days+1;
            rnpAmount.Text = "₪" + (totaldays * rc.priceday).ToString("#,##0");//("#,##0");
            rnpTotalDays.Text = "Total Rent Days: " + totaldays;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }
        private void rnpPickupDate_CloseUp(object sender, EventArgs e)
        {
            if (rnpPickupDate.Value != value_beforeOpen)
            {
                if (!canBeSelected(rnpPickupDate.Value))
                {
                    MessageBox.Show("Sorry, someone is already renting this car in this day.");
                    rnpPickupDate.Value = value_beforeOpen;
                }
                else
                    updatePickupDate(rnpPickupDate.Value.Date);
            }
        }

        private void rnpPickupDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (rnpPickupDate.Value != value_beforeOpen)
            {
                if (!canBeSelected(rnpPickupDate.Value))
                {
                    MessageBox.Show("Sorry, someone is already renting this car in this day.");
                    rnpPickupDate.Value = value_beforeOpen;
                }
                else
                    updatePickupDate(rnpPickupDate.Value.Date);
            }
        }

        private void rnpPickupDate_Leave(object sender, EventArgs e)
        {
            if (rnpPickupDate.Value != value_beforeOpen)
            {
                if (!canBeSelected(rnpPickupDate.Value))
                {
                    MessageBox.Show("Sorry, someone is already renting this car in this day.");
                    rnpPickupDate.Value = value_beforeOpen;
                }
                else
                    updatePickupDate(rnpPickupDate.Value.Date);
            }
        }
        private void onChangeReturnDate(object sender, EventArgs e)
        {
            if (rnpReturnDate.Value != returnValue_beforeOpen)
                updateTotalDaysAmount();
        }
        private void printCorrectFormat(DateTime dt)
        {

        }
        private rentStation getThePickupStation(DateTime dt)
        {
            rent_station = demo_getThePickupStation(dt, rc.id, rc.available, rc.last_period_date);
            rnpOpenTime.Text = "Open Time: " + rent_station.opensfrom + ":00 to " + rent_station.opensto + ":00";
            updateOpenOrNo();
            return rent_station;
        }
        private rentStation demo_getThePickupStation(DateTime dt, int tmp_carid, int tmp_available, DateTime tmp_lastperiod)
        {
            dbRentStations dbrs = new dbRentStations();
            rentStation therent = null;

            SqlCommand sqlcmd = new SqlCommand("select * from rent_periods where carid=@carid and to_date>=@lastperiod order by from_date asc");
            sqlcmd.Parameters.AddWithValue("@lastperiod", tmp_lastperiod.Date);

            rentPeriod[] the_array = returnAllPeriods(tmp_carid, sqlcmd);
            if (the_array == null)
            {
                therent = dbrs.returnStationInfo(tmp_available);
                toreturn_tmp = DateTime.Now;
            }

            else
                for (int i = the_array.Length - 1; i >= 0; i--)
                    if (the_array[i].from_date.Date <= dt)
                    {
                        therent = dbrs.returnStationInfo(the_array[i].return_to);
                        toreturn_tmp = the_array[i].to_date;
                        break;
                    }
            if (therent == null)
            {
                therent = dbrs.returnStationInfo(tmp_available);
                toreturn_tmp = DateTime.Now;
            }
            return therent;
        }
        public void updateAllRentAvails(int[,] the_array)
        {
            DbCars db = new DbCars();
            for (int i = 0; i < the_array.GetLength(0); i++)
            {
                rc = new RentCar();
                rc.id = the_array[i, 0];
                rentStation theresult = demo_getThePickupStation(returnFirstDayPossible(DateTime.Now.AddDays(1).Date).Date, the_array[i, 0], the_array[i, 1], db.returnRentCarInfo(the_array[i, 0]).last_period_date);
                db.forupdateavail_updateCarAvailable(the_array[i,0], theresult.id, toreturn_tmp);
            }
        }

        private void rnpDoPayment_Click(object sender, EventArgs e)
        {
            DbCars db = new DbCars();
            RentCar rc_new = db.returnRentCarInfo(rc.id);
            if (rc_new.available != -2)
            {
                if (rnpReturnTo.SelectedIndex != -1)
                {
                    if ((rnpReturnDate.Value - rnpPickupDate.Value).Days + 1 >= 2 && (rnpReturnDate.Value - rnpPickupDate.Value).Days + 1 <= 30)
                    {
                        if (checkIfTimeIsInPeriod(rnpPickupDate.Value.Date) == new DateTime(0) && checkIfTimeIsInPeriod(rnpReturnDate.Value.Date) == new DateTime(0))
                        {
                            if (IsNumeric(rnpPhone.Text) && rnpPhone.TextLength >= 7)
                            {
                                if (rnpCardNum.TextLength == 16 && IsNumeric(rnpCardNum.Text) && rnpCSC.TextLength == 3 && IsNumeric(rnpCSC.Text) && rnpExpiryMonth.TextLength == 2 && IsNumeric(rnpExpiryMonth.Text) && IsNumeric(rnpExpiryYear.Text) && rnpExpiryYear.TextLength == 4 && int.Parse(rnpExpiryMonth.Text) <= 12 && int.Parse(rnpExpiryMonth.Text) > 0)
                                {
                                    int expMonth = int.Parse(rnpExpiryMonth.Text),
                                        expYear = int.Parse(rnpExpiryYear.Text),
                                        pickupFromHour = int.Parse(rnpPickupHour.Text),
                                        pickupFromMinute = int.Parse(rnpPickupMinute.Text),
                                        returnOnHour = int.Parse(rnpReturnHour.Text),
                                        returnOnMinute = int.Parse(rnpReturnMinute.Text);
                                    if (IsPickupStationOpenInTime(pickupFromHour))
                                    {
                                        if (IsReturnStationOpenInTime(returnOnHour))
                                        {
                                            dbRentStations dbrs = new dbRentStations();
                                            DateTime pickupTime = rnpPickupDate.Value.AddHours(pickupFromHour).AddMinutes(pickupFromMinute);
                                            DateTime returnTime = rnpReturnDate.Value.AddHours(returnOnHour).AddMinutes(returnOnMinute);

                                            takeScreenShotAndStoreInHand2();
                                            string rent_info = rnpPhone.Text + "#" + rnpCardNum.Text + "#" + rnpExpiryMonth.Text + "#" + rnpExpiryYear.Text + "#" + rnpCSC.Text;
                                            dbrs.InsertRentPeriod(rc.id, returnTime, pickupTime, rc.priceday, dbrs.returnStationInfoFromName(rnpPickupFrom.Text).id, dbrs.returnStationInfoFromName(rnpReturnTo.Text).id, u.id, rent_info);

                                            RentNowPage_FormClosed(null, null);
                                            var result = MessageBox.Show("The deal have been completed successfully and payment was done.\nThe rent details were saved as a picture in the Hand2 folder.\n\nWould you like to view it?", "Deal Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (result == DialogResult.Yes)
                                            {
                                                if (Directory.Exists(getScreenshotsFolderPath()))
                                                    System.Diagnostics.Process.Start(getScreenshotsFolderPath());
                                                else
                                                    MessageBox.Show("Invalid Path:\nSorry, the folder that saves bills wasn't found.");
                                            }
                                        }
                                        else
                                            MessageBox.Show("Invalid return time or the station is not open at the time you've chosen for return.\n\nIt's open from "+GetReturnStationOpenTime() );
                                    }
                                    else
                                        MessageBox.Show("Invalid pickup time or the station is not open at the time you've chosen for pickup.\n\nIt's open from "+GetPickupStationOpenTime() );
                                }
                                else
                                    MessageBox.Show("Invalid credit card information.");
                            }
                            else
                                MessageBox.Show("Invalid phone number.");
                        }
                        else MessageBox.Show("Sorry, someone has just rented this car with a rent time that collides with yours.");
                    }
                    else MessageBox.Show("Sorry, total rent days must be between 2 and 30.");
                }
                else MessageBox.Show("You need to select the place where you want to return your rented car.");
            }
            else MessageBox.Show("Sorry, this rent car is currently unavailable to rent.");
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
        public void takeScreenShotAndStoreInHand2()
        {
            if (Directory.Exists(getScreenshotsFolderPath()))
            {
                this.CenterToScreen();
                string fname = DateTime.Today.Year.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".jpg";
                string location = getScreenshotsFolderPath()+"\\";

                var frm = Form.ActiveForm;
                using (var bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(location + fname);
                }
            }
        }
        public string getScreenshotsFolderPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName+"\\Hand2 Images";
            if (!Directory.Exists(projectDirectory))
                Directory.CreateDirectory(projectDirectory);
            return projectDirectory;
        }
    }
}
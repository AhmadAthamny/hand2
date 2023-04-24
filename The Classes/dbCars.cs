using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hand2
{
    public class DbCars
    {
        public SqlConnection cnn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public DataSet ds = new DataSet();
        public DbCars() // Constructor Function
        {
            cnn.ConnectionString = new sqlConnection().returnConnectionString();
        }

        public int InsertCar(Cars c) // Adds a new forsale car to the table.
        {
            SqlCommand command =
                new SqlCommand("insert into Cars (company, version, year, gear, price, hand, gastype, kilodriven, color, picture, description, cartype, userid) output INSERTED.ID values (@company, @version, @year, @gear, @price, @hand, @gastype, @kilodriven, @color, @picture, @description, @cartype, @userid)", cnn);

            command.Parameters.Add(new SqlParameter("@company", c.company));
            command.Parameters.Add(new SqlParameter("@version", c.version));
            command.Parameters.Add(new SqlParameter("@year", c.year));
            command.Parameters.Add(new SqlParameter("@gear", c.geartype));
            command.Parameters.Add(new SqlParameter("@price", c.price));
            command.Parameters.Add(new SqlParameter("@hand", c.hand));
            command.Parameters.Add(new SqlParameter("@gastype", c.gastype));
            command.Parameters.Add(new SqlParameter("@kilodriven", c.kilometers));
            command.Parameters.Add(new SqlParameter("@color", c.color));
            command.Parameters.Add(new SqlParameter("@picture", c.pic));
            command.Parameters.Add(new SqlParameter("@description", c.description));
            command.Parameters.Add(new SqlParameter("@cartype", c.cartype));
            command.Parameters.Add(new SqlParameter("@userid", c.sellerid));
            return InsDelUpd(command);
        }
        public int InsertRentCar(RentCar rc) // Adds a new rentable cars to the table.
        {
            SqlCommand command =
                new SqlCommand("insert into CarRent (company, version, year, geartype, priceday, available, picture) output INSERTED.ID values (@company, @version, @year, @geartype, @priceday, @available, @picture)", cnn);

            command.Parameters.Add(new SqlParameter("@company", rc.company));
            command.Parameters.Add(new SqlParameter("@version", rc.version));
            command.Parameters.Add(new SqlParameter("@year", rc.year));
            command.Parameters.Add(new SqlParameter("@geartype", rc.geartype));
            command.Parameters.Add(new SqlParameter("@priceday", rc.priceday));
            command.Parameters.Add(new SqlParameter("@picture", rc.picture));
            command.Parameters.Add(new SqlParameter("@available", rc.available));
            return InsDelUpd(command);
        }
        public void updateCar(Cars c) // Updates the info of a forsale car.
        {
            using (cnn)
            {
                SqlCommand command =
                    new SqlCommand("update cars set company=@company, version=@version, year=@year, gear=@gear, price=@price, hand=@hand, gastype=@gastype, kilodriven=@kilodriven, color=@color, picture=@picture, description=@description, cartype=@cartype, status=@status, userid=@userid where id=@carid", cnn);

                command.Parameters.Add(new SqlParameter("@company", c.company));
                command.Parameters.Add(new SqlParameter("@version", c.version));
                command.Parameters.Add(new SqlParameter("@year", c.year));
                command.Parameters.Add(new SqlParameter("@gear", c.geartype));
                command.Parameters.Add(new SqlParameter("@price", c.price));
                command.Parameters.Add(new SqlParameter("@hand", c.hand));
                command.Parameters.Add(new SqlParameter("@gastype", c.gastype));
                command.Parameters.Add(new SqlParameter("@kilodriven", c.kilometers));
                command.Parameters.Add(new SqlParameter("@color", c.color));
                command.Parameters.Add(new SqlParameter("@picture", c.pic));
                command.Parameters.Add(new SqlParameter("@description", c.description));
                command.Parameters.Add(new SqlParameter("@cartype", c.cartype));
                command.Parameters.Add(new SqlParameter("@userid", c.sellerid));
                command.Parameters.Add(new SqlParameter("@carid", c.id));
                command.Parameters.Add(new SqlParameter("@status", c.status));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
            }
        }

        public Cars returnCarInfo(int carid) // Returns information of a specified forsale car.
        {
            Cars c = new Cars();
            SqlCommand selectCarInfo = new SqlCommand("select * from cars where id=@carid", cnn);
            selectCarInfo.Parameters.Add(new SqlParameter("@carid", carid));
            DataRowCollection rows = ReturnDS(selectCarInfo).Tables[0].Rows;
            c.id = (int)(rows[0]["id"]);
            c.company = (string)(rows[0]["company"]);
            c.version = (string)(rows[0]["version"]);
            c.cartype = (int)(rows[0]["cartype"]);
            c.year = (int)(rows[0]["year"]);
            c.price = (int)(rows[0]["price"]);
            c.hand = (int)(rows[0]["hand"]);
            c.geartype = (string)(rows[0]["gear"]);
            c.color = (string)(rows[0]["color"]);
            c.description = (string)(rows[0]["description"]);
            c.gastype = (string)(rows[0]["gastype"]);
            c.kilometers = (int)(rows[0]["kilodriven"]);
            c.adddate = (DateTime)(rows[0]["adddate"]);
            c.pic = (Byte[])(rows[0]["picture"]);
            c.sellerid = (int)(rows[0]["userid"]);
            c.status = (int)(rows[0]["status"]);
            return c;
        }
        public List<Cars> getallCars(SqlCommand  q) // Returns a list of Cars according to the selection command (Used for the mainpage to display cars)
        {
            int length = ReturnDS(q).Tables[0].Rows.Count;
            DataRowCollection rows = ReturnDS(q).Tables[0].Rows; 
            List<Cars> ppap = new List<Cars>();
            for (int i = 0; i < length; i++)
            {
                Cars c = new Cars();
                c.id = (int)(rows[i]["id"]);
                c.company = (string)(rows[i]["company"]);
                c.version = (string)(rows[i]["version"]);
                c.year = (int)(rows[i]["year"]);
                c.price = (int)(rows[i]["price"]);
                c.hand = (int)(rows[i]["hand"]);
                c.geartype = (string)(rows[i]["gear"]);
                c.kilometers = (int)(rows[i]["kilodriven"]);
                c.adddate = (DateTime)(rows[i]["adddate"]);
                c.pic = (Byte[])(rows[i]["picture"]);
                c.status = (int)(rows[i]["status"]);
                ppap.Add(c);
            }
            return ppap;
        }
        public List<RentCar> getallRentCars(SqlCommand q) // Returns a list of RentCars according to the selection command (Used for the mainpage to display rentcars)
        {
            int length = ReturnDS(q).Tables[0].Rows.Count;
            DataRowCollection rows = ReturnDS(q).Tables[0].Rows;
            List<RentCar> ppap = new List<RentCar>();
            for (int i = 0; i < length; i++)
            {
                RentCar rc = new RentCar();
                rc.id = (int)(rows[i]["id"]);
                rc.company = (string)(rows[i]["company"]);
                rc.version = (string)(rows[i]["version"]);
                rc.year = (int)(rows[i]["year"]);
                rc.priceday = (int)(rows[i]["priceday"]);
                rc.geartype = (string)(rows[i]["geartype"]);
                rc.picture = (Byte[])(rows[i]["picture"]);
                rc.available = (int)(rows[i]["available"]);
                rc.last_period_date = (DateTime)(rows[i]["last_period_date"]);
                ppap.Add(rc);
            }
            return ppap;
        }
        public SqlCommand getUserRentedCarsQuery(User u) // Returns the sql command that can be used to select all user's rented cars.
        {
            SqlCommand tmp = new SqlCommand("select * from rent_periods where rent_by=@userid", cnn);
            tmp.Parameters.AddWithValue("@userid", u.id);

            int length = ReturnDS(tmp).Tables[0].Rows.Count;
            DataRowCollection rows = ReturnDS(tmp).Tables[0].Rows;
            if (length < 1)
            {
                SqlCommand the_cmd = new SqlCommand("select * from carrent where id=-1", cnn);
                return the_cmd;
            }

            int id;
            SqlCommand final_cmd = new SqlCommand("select * from carrent where ", cnn);
            for (int i = 0; i < length; i++)
            {
                id = (int)(rows[i]["carid"]);
                if (i == 0) final_cmd.CommandText += "id=" + id;
                else final_cmd.CommandText += " or id=" + id;
            }
            return final_cmd;
        }
        public int[] GetUserRentCarsArray(User u) // Returns an integer array of all rent cars ID's rented by a specified user.
        {
            int[] the_array;
            SqlCommand tmp = new SqlCommand("select * from rent_periods where rent_by=@userid and ((from_date<=@thisdate and to_date>=@thisdate) or from_date>=@thisdate)", cnn);
            tmp.Parameters.AddWithValue("@userid", u.id);
            tmp.Parameters.AddWithValue("@thisdate", DateTime.Now.Date);
            DataRowCollection rows = ReturnDS(tmp).Tables[0].Rows;
            if (rows.Count < 1)
                the_array = null;
            else
            {
                the_array = new int[rows.Count];
                for(int i = 0; i < the_array.Length; i++)
                    the_array[i] = (int)(rows[i]["carid"]);
            }
            return the_array;
        }
        public int[,] forupdateavail_returnAllRentCars() // Returns a 2D integer array ( rent car ID , rent car current station ). This is used to refresh and update current rentcars places.
        {
            SqlCommand q = new SqlCommand("select * from CarRent where available>0", cnn);
            DataSet ds = new DataSet();
            ds = ReturnDS(q);

            int length = ds.Tables[0].Rows.Count;
            int[,] the_array = new int[length, 3];
            DataRowCollection rows = ds.Tables[0].Rows;
            for (int i = 0; i < length; i++)
            {
                the_array[i, 0] = (int)(rows[i]["id"]);
                the_array[i, 1] = (int)(rows[i]["available"]);
            }
            return the_array;
        }
        public rentPeriod[] returnCurrentAndComingCarPeriods(RentCar rc, SqlCommand the_command = null) // Returns all rent periods of a rent car.
        {

            if (the_command == null)
            {
                the_command = new SqlCommand("select * from rent_periods where carid=@carid and rent_by!=-1 order by id desc", cnn);
                the_command.Parameters.AddWithValue("@carid", rc.id);
            }
            DataRowCollection rows = ReturnDS(the_command).Tables[0].Rows;
            if (rows.Count == 0)
                return null;
            else
            {
                rentPeriod[] tobe_returned = new rentPeriod[rows.Count];
                for (int i = 0; i < rows.Count; i++)
                {
                    rentPeriod rp = new rentPeriod();
                    rp.id = (int)(rows[i]["id"]);
                    rp.carid = (int)(rows[i]["carid"]);
                    rp.to_date = (DateTime)(rows[i]["to_date"]);
                    rp.from_date = (DateTime)(rows[i]["from_date"]);
                    rp.moneyperday = (int)(rows[i]["moneyperday"]);
                    rp.pickup_from = (int)(rows[i]["pickup_from"]);
                    rp.return_to = (int)(rows[i]["return_to"]);
                    rp.rent_by = (int)(rows[i]["rent_by"]);
                    rp.rent_info = (string)(rows[i]["rent_info"]);
                    //rp.pickupTime = (TimeSpan)(rows[i]["from_time"]);
                    //rp.returnTime = (TimeSpan)(rows[i]["to_time"]);
                    tobe_returned[i] = rp;
                }
                return tobe_returned;
            }
        }
        public DataSet returnAllRentCars() // Returns a dataset of all rent cars (Used to manage rent stations on administration panel)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select id, company, version, year, geartype, CONVERT(varchar(100), available) , priceday from CarRent";
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnn.Close(); }
            return ds;
        }
        public DataSet dgv_returnAllCars() // Returns a dataset of all forsale cars (Used to manage forsale cars on administration panel)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select id, company, version, year, gear, price, hand, gastype, kilodriven, color, CONVERT(varchar(50), cartype), CONVERT(varchar(50), status) from Cars";
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnn.Close(); }
            return ds;
        }
        public RentCar returnRentCarInfo(int carid) // Returns an object of RentCar that contains data of a specified rent car
        {
            RentCar c = new RentCar();
            SqlCommand selectCarInfo = new SqlCommand("select * from CarRent where id=@carid", cnn);
            selectCarInfo.Parameters.AddWithValue("@carid", carid);
            DataRowCollection rows = ReturnDS(selectCarInfo).Tables[0].Rows;
            if (rows.Count == 0) return null;
            c.id = (int)(rows[0]["id"]);
            c.company = (string)(rows[0]["company"]);
            c.version = (string)(rows[0]["version"]);
            c.year = (int)(rows[0]["year"]);
            c.priceday = (int)(rows[0]["priceday"]);
            c.geartype = (string)(rows[0]["geartype"]);
            c.picture = (Byte[])(rows[0]["picture"]);
            c.available= (int)(rows[0]["available"]);
            c.last_period_date = (DateTime)(rows[0]["last_period_date"]);
            return c;
        }
        public void forupdateavail_updateCarAvailable(int tmpp_carid, int tmpp_available, DateTime tmpp_lastperiod) // Updates the current rent station of a specified rent car.
        {
            SqlCommand SqlStr = new SqlCommand("update CarRent set available=@available, last_period_date=@lastperiod where id=@id", cnn);
            SqlStr.Parameters.AddWithValue("@available", tmpp_available);
            SqlStr.Parameters.AddWithValue("@id", tmpp_carid);
            SqlStr.Parameters.AddWithValue("@lastperiod", tmpp_lastperiod);
            InsDelUpd(SqlStr);
        }

        public void updateRentCar(RentCar c) // Updates the information of a specified rent car.
        {
            using (cnn)
            {
                SqlCommand command =
                    new SqlCommand("update CarRent set company=@company, version=@version, year=@year, geartype=@geartype, priceday=@priceday, picture=@picture, available=@available where id=@carid", cnn);

                command.Parameters.Add(new SqlParameter("@company", c.company));
                command.Parameters.Add(new SqlParameter("@version", c.version));
                command.Parameters.Add(new SqlParameter("@year", c.year));
                command.Parameters.Add(new SqlParameter("@geartype", c.geartype));
                command.Parameters.Add(new SqlParameter("@priceday", c.priceday));
                command.Parameters.Add(new SqlParameter("@picture", c.picture));
                command.Parameters.Add(new SqlParameter("@carid", c.id));
                command.Parameters.Add(new SqlParameter("@available", c.available));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
            }
        }
        public int InsDelUpd(SqlCommand SqlStr) // Function used to pass single sql queries like UPDATE, DELETE or INSERT.
        {
            SqlCommand cmd = new SqlCommand();
            int to_return = -1;
            try
            {
                cnn.Open();
                if (SqlStr.CommandText.Contains("output INSERTED.ID"))
                    to_return = (int)SqlStr.ExecuteScalar();
                else
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
            return to_return;
        }
        public DataSet ReturnDS(SqlCommand SqlStr) // Returns a dataset of a specified SQL selection.
        {
            DataSet ds = new DataSet();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(SqlStr);
                da.Fill(ds);
            }
            catch {
                MessageBox.Show("An error has occured. Please quit the program and open it again.");
                cnn.Close();
                System.Environment.Exit(0);
            }
            finally
            {
                cnn.Close();
            }
            return ds;
        }
        public string returnCartypeName(int cartype) // Returns the type name from its ID.
        {
            if(cartype == 0) return "Private";
            else if(cartype == 1) return "Vans";
            else if(cartype == 2) return "Jeeps";
            else if(cartype == 3) return "Motorbikes";
            else if (cartype == 4) return "Special";
            else return "Unknown";
        }
        public string returnCarAvail(int caravail) // Returns the station name of the current rentcar location.
        {
            if (caravail == -1 || caravail == -2)
                return "unavailable";
            else
            {
                dbRentStations dbrs = new dbRentStations();
                return dbrs.returnStationInfo(caravail).name;
            }
        }

        /* status value keys:
         * 0 = Car pending - awaiting admin to approve/deny
         * 1 = Car denied/rejected by admin
         * 2 = Car deleted by owner/admin.
         * 3 = Car accepted/approved by admin.
         */
        public string returnCarStatus(int statustmp) // Returns the car's current status (Pending/Rejected/Deleted/Approved), if status is invalid then it returns "Unknown Status" to avoid unexceptions.
        {
            if (statustmp == 0) return "Pending";
            else if (statustmp == 1) return "Rejected";
            else if (statustmp == 2) return "Deleted";
            else if (statustmp == 3) return "Approved";
            else return "Unknown Status";
        }
    }
}

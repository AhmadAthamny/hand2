using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hand2
{
    public class dbRentStations
    {
        public SqlConnection cnn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public DataSet ds = new DataSet();
        public dbRentStations() // Constructor Function
        {
            cnn.ConnectionString = new sqlConnection().returnConnectionString();
        }
        public int InsertStation(rentStation rs) // Inserts a new station ID.
        {
            SqlCommand command =
                new SqlCommand("insert into rent_stations (name, location, opensfrom, opensto) output INSERTED.ID values (@name, @location, @opensfrom, @opensto)", cnn);

            command.Parameters.Add(new SqlParameter("@name", rs.name));
            command.Parameters.Add(new SqlParameter("@location", rs.location));
            command.Parameters.Add(new SqlParameter("@opensfrom", rs.opensfrom));
            command.Parameters.Add(new SqlParameter("@opensto", rs.opensto));
            return InsDelUpd(command);
        }
        public void updateStation(rentStation rs) // Updates a specified station ID data.
        {
            using (cnn)
            {
                SqlCommand command =
                    new SqlCommand("update rent_stations set name=@name, location=@location, opensfrom=@opensfrom, opensto=@opensto, status=@status where id=@stationid", cnn);

                command.Parameters.Add(new SqlParameter("@name", rs.name));
                command.Parameters.Add(new SqlParameter("@location", rs.location));
                command.Parameters.Add(new SqlParameter("@opensfrom", rs.opensfrom));
                command.Parameters.Add(new SqlParameter("@opensto", rs.opensto));
                command.Parameters.Add(new SqlParameter("@stationid", rs.id));
                command.Parameters.Add(new SqlParameter("@status", rs.status));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
            }
        }

        public rentStation returnStationInfo(int stationid) // Returns an object of "rentStation" that contains information of a specified rentstation.
        {
            rentStation rs = new rentStation();
            SqlCommand selectionStationInfo = new SqlCommand("select * from rent_stations where id=@id", cnn);
            selectionStationInfo.Parameters.Add(new SqlParameter("@id", stationid));
            DataRowCollection rows = ReturnDS(selectionStationInfo).Tables[0].Rows;
            rs.id = (int)(rows[0]["id"]);
            rs.name = (string)(rows[0]["name"]);
            rs.location = (string)(rows[0]["location"]);
            rs.opensfrom = (int)(rows[0]["opensfrom"]);
            rs.opensto = (int)(rows[0]["opensto"]);
            rs.status = (int)(rows[0]["status"]);
            return rs;
        }
        public DataSet returnAllStations() // Returns a Dataset of a sql selection query (Used for managing rent stations)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select id, name, location, opensfrom, opensto, CONVERT(varchar(50), status) from rent_stations where id>0";
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
        public rentStation returnStationInfoFromName(string station_name) // Returns station data from name (not from ID)
        {       
            rentStation rs = new rentStation();
            SqlCommand selectStationInfo = new SqlCommand("select * from rent_stations where name=@stationname", cnn);
            selectStationInfo.Parameters.Add(new SqlParameter("@stationname", station_name));
            DataRowCollection rows = ReturnDS(selectStationInfo).Tables[0].Rows;
            if (rows.Count == 0) return null;
            rs.id = (int)(rows[0]["id"]);
            rs.name = (string)(rows[0]["name"]);
            rs.location = (string)(rows[0]["location"]);
            rs.opensfrom = (int)(rows[0]["opensfrom"]);
            rs.opensto = (int)(rows[0]["opensto"]);
            return rs;
        }
        public void InsertRentPeriod(int iID, DateTime iReturnDate, DateTime iPickupDate, int iPrice, int iFromStationID, int iToStationID, int iUserID, string iRentInfo) // Inserts a new rent period to a specified rent car. (From date to dat etc)
        {
            SqlCommand query = new SqlCommand("insert into rent_periods (carid, to_date, from_date, moneyperday, pickup_from, return_to, rent_by, rent_info) values (@carid, @todate, @fromdate, @moneyperday, @pickupfrom, @returnto, @rentby, @rentinfo)", cnn);
            query.Parameters.AddWithValue("@carid", iID);
            query.Parameters.AddWithValue("@todate", iReturnDate);
            query.Parameters.AddWithValue("@fromdate", iPickupDate);
            query.Parameters.AddWithValue("@moneyperday", iPrice);
            query.Parameters.AddWithValue("@pickupfrom", iFromStationID);
            query.Parameters.AddWithValue("@returnto", iToStationID);
            query.Parameters.AddWithValue("@rentby", iUserID);
            query.Parameters.AddWithValue("@rentinfo", iRentInfo);
            InsDelUpd(query);
        }
        public void scheduleStationChange(RentCar rc, int new_station) // When admin forces to move a rent station from place to place.
        {
            DateTime dt = returnDateWhereCarCanBeMoved(rc);
            SqlCommand query = new SqlCommand("insert into rent_periods (carid, to_date, from_date, moneyperday, pickup_from, return_to, rent_by, rent_info) values (@carid, @todate, @fromdate, @moneyperday, @pickupfrom, @returnto, @rentby, @rentinfo)", cnn);
            query.Parameters.AddWithValue("@carid", rc.id);
            query.Parameters.AddWithValue("@todate", dt);
            query.Parameters.AddWithValue("@fromdate", dt);
            query.Parameters.AddWithValue("@moneyperday", 0); // This shit must stay at "0", otherwise it will affect the total earnings in the stats.
            query.Parameters.AddWithValue("@pickupfrom", -2);
            query.Parameters.AddWithValue("@returnto", new_station);
            query.Parameters.AddWithValue("@rentby", -1);
            query.Parameters.AddWithValue("@rentinfo", "1#1#1#1#1");
            InsDelUpd(query);
        }
        public DateTime returnDateWhereCarCanBeMoved(RentCar rc) // Returns the date where the car is free of rents to the admin can move it.
        {
            DbCars db = new DbCars();
            SqlCommand cmd = new SqlCommand("select * from rent_periods where carid=@carid and to_date>=@thisdate order by to_date desc", cnn);
            cmd.Parameters.AddWithValue("@carid", rc.id);
            cmd.Parameters.AddWithValue("@thisdate", DateTime.Now.Date);
            rentPeriod[] rparray = db.returnCurrentAndComingCarPeriods(rc, cmd);
            if (rparray == null)
                return DateTime.Now;
            else
            {
                if (rparray[0].rent_by == -1)
                {
                    SqlCommand sqlcmd = new SqlCommand("delete from rent_periods where id=@theid", cnn);
                    sqlcmd.Parameters.AddWithValue("@theid", rparray[0].id);
                    InsDelUpd(sqlcmd);
                    return rparray[0].to_date;
                }
                else
                    return rparray[0].to_date.AddDays(1).Date;
            } 
        }
        public int InsDelUpd(SqlCommand SqlStr) // Function to execute single sql queries like INSERT/DELETE/UPDATE..
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
        public DataSet ReturnDS(SqlCommand SqlStr) // Returns a dataset of a specified sql command selection.
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlStr);
                da.Fill(ds);
            }
            catch { }
            finally
            {
                cnn.Close();
            }
            return ds;
        }
    }
}

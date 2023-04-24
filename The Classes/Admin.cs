using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hand2
{
    public class Admin
    {
        const int maximumAdminLevel = 20;
        const int minLevelToManageAdmins = 20;
        const int minLevelToManageUsers = 17;
        const int minLevelToSendMessagesToAll = 17;
        const int minLevelToManageStations = 16;
        const int minLevelToManageRentCars = 15;
        const int minLevelToManageCars = 14;
        const int minLevelToViewStats = 13;
        const int minLevelToViewLogs = 12; ///  Logs only**
        const int minLevelToViewFeedback = 11; // Supporter's job..
        const int minLevelToOpenAdminPanel = 11;

        


        public int userid { get; set; }
        public string logcontent { get; set; }
        public int logtype { get; set; }

        public SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public Admin(int logtype1 = 0, int userid1 = 0, string logcontent1 = "") /// Constructor function, builds an object of "Admin", which is for logging admin activities.
        {
            userid = userid1;
            logcontent = logcontent1;
            logtype = logtype1;
            cnn.ConnectionString = new sqlConnection().returnConnectionString();
        }

        public void InsertLog(Admin l) // Inserts or adds a new log to the logs table.
        {
            SqlCommand SqlStr = new SqlCommand("insert into Logs (userid, logcontent, logtype) values (@userid, @logcontent, @logtype)", cnn);
            SqlStr.Parameters.AddWithValue("@userid", l.userid);
            SqlStr.Parameters.AddWithValue("@logcontent", l.logcontent);
            SqlStr.Parameters.AddWithValue("@logtype", l.logtype);
            InsDelUpd(SqlStr);
        }
        public void InsertReport(int sender, int target, string content, int f_type) // Inserts feedback/report/help request to the reports table.
        {
            SqlCommand SqlStr = new SqlCommand("insert into reports (sender, target, f_type, f_content) values (@sender, @target, @f_type, @content)", cnn);
            SqlStr.Parameters.AddWithValue("@sender", sender);
            SqlStr.Parameters.AddWithValue("@target", target);
            SqlStr.Parameters.AddWithValue("@content", content);
            SqlStr.Parameters.AddWithValue("@f_type", f_type);
            InsDelUpd(SqlStr);
        }
        public void InsDelUpd(SqlCommand SqlStr) // This is used to pass single queries, to update, delete or insert..
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
        public int returnMaxAdminLevel() // Returns the value of the maximum admin level.
        {
            return maximumAdminLevel;
        }
        public bool CanViewAdminPanel(User u) // Checks if user can open admin panel.
        {
            if (u.level >= minLevelToOpenAdminPanel)
                return true;
            else return false;
        }
        public bool CanManageAdmins(User u) // Checks if user can manage administrators.
        {
            if (u.level >= minLevelToManageAdmins)
                return true;
            else return false;
        }
        public bool CanManageUsers(User u) // Checks if user can manage other users data.
        {
            if (u.level >= minLevelToManageUsers)
                return true;
            else return false;
        }
        public bool CanManageStations(User u) // Checks if user can manage rent stations.
        {
            if(u.level >= minLevelToManageStations)
                return true;
            else return false;
        }
        public bool CanEditStationID(User u, int stationid) // Checks if user can manage a specified station.
        {
            if (u.level == stationid || u.level >= minLevelToManageStations)
                return true;
            else return false;
        }
        public bool CanManageRentCars(User u) // Checks if user can manage rentable cars.
        {
            if (u.level >= minLevelToManageRentCars)
                return true;
            else return false;
        }
        public bool CanManageCars(User u) // Checks if user can manage forsale cars.
        {
            if (u.level >= minLevelToManageCars)
                return true;
            else return false;
        }
        public bool CanViewStats(User u) // Checks if user can view the Hand2 company statistics.
        {
            if (u.level >= minLevelToViewStats)
                return true;
            else return false;
        }
        public bool CanViewLogs(User u) // Checks if user can view activity logs.
        {
            if (u.level >= minLevelToViewLogs)
                return true;
            else return false;
        }
        public bool CanSendMessageToAll(User u) // Checks if user can submit broadcasts to all users.
        {
            if (u.level >= minLevelToSendMessagesToAll)
                return true;
            else return false;
        }
        public bool CanViewFeedback(User u) // Checks if user can view the feedback table (reports, help requests..)
        {
            if (u.level >= minLevelToViewFeedback)
                return true;
            else return false;
        }
        public DataSet ReturnDS(SqlCommand SqlStr) // Returns the dataset of a selection query.
        {
            DataSet ds = new DataSet();
            try
            {
                cnn.Open();
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
       
        public string returnAdminLevelName(int level) // Return the rank name of a specified admin level.
        {
            string the_name;
            if (level >= 20) the_name = "CEO";
            else if (level >= 17) the_name = "Councilist";
            else if (level >= 16) the_name = "Stations Manager";
            else if (level >= 15) the_name = "Rent Cars Manager";
            else if (level >= 14) the_name = "Cars Manager";
            else if (level >= 13) the_name = "Advisor";
            else if (level >= 12) the_name = "Spectator";
            else if (level >= 11) the_name = "Supporter";
            else the_name = "None";

            return the_name;
        }
        public int returnAdminLevelFromName(string lvlname) // Returns the admin level of a specified rank name.
        {
            if (lvlname == "CEO") return 20;
            else if (lvlname == "Councilist") return 17;
            else if (lvlname == "Stations Manager") return 16;
            else if (lvlname == "Rent Cars Manager") return 15;
            else if (lvlname == "Cars Manager") return 14;
            else if (lvlname == "Advisor") return 13;
            else if (lvlname == "Spectator") return 12;
            else if (lvlname == "Supporter") return 11;
            else return 0;
        }
        /// <summary>
        /// LogType:
        /// 0 - Edits a car
        /// 1 - Edits rent station
        /// 2 - Edits rent car
        /// 3 - Edits User Info
        /// 4 - Adds new car
        /// 5 - Adds a new rent car
        /// 6 - Adds a new rent station
        /// 7 - Adds a new broadcast
        /// 8 - Delets a car
        /// </summary>
        public string returnReportTypeName(int type_tmp) // Returns the report type from type ID.
        {
            if (type_tmp == 0) return "Feedback";
            else if (type_tmp == 1) return "Help Request";
            else if (type_tmp == 2) return "Bug Report";
            else if (type_tmp == 3) return "User Report";
            else return "Other";
        }
        public DataSet returnAllUsers(SqlCommand query = null) // Returns a dataset if selected users (Used for administration panel)
        {
            if (query == null)
                query = new SqlCommand("select id, name, email, CONVERT(varchar(50), level),  user_id, CONVERT(varchar(50), verified) from Users where id>0 order by level DESC", cnn);
            return ReturnDS(query);
        }
        public User[] returnAllAdmins() // Returns an array of Users that contains all admins.
        {
            SqlCommand query = new SqlCommand("select name, level from users where level > 0 order by level DESC", cnn);
            DataRowCollection rows = ReturnDS(query).Tables[0].Rows;
            User[] ar_admins = new User[rows.Count];
            for (int i = 0; i < rows.Count; i++)
            {
                ar_admins[i] = new User();
                ar_admins[i].name = (string)(rows[i]["name"]);
                ar_admins[i].level = (int)(rows[i]["level"]); 
            }
            return ar_admins;
        }
        public DataSet returnAllLogs(SqlCommand query = null) // Returns a dataset of logs selection.
        {
            if (query == null)
                query = new SqlCommand("select userid, logcontent, date from Logs ORDER by date desc", cnn);
            return ReturnDS(query);
        }
        public reports returnReportInfo(int reportid) // Returns a "report" object that contains data of a specified report ID.
        {
            reports r = new reports();
            SqlCommand selectReportInfo = new SqlCommand("select * from reports where id=@reportid", cnn);
            selectReportInfo.Parameters.Add(new SqlParameter("@reportid", reportid));
            DataRowCollection rows = ReturnDS(selectReportInfo).Tables[0].Rows;
            r.id = (int)(rows[0]["id"]);
            r.f_type = (int)(rows[0]["f_type"]);
            r.sender_id = (int)(rows[0]["sender"]);
            r.target_id = (int)(rows[0]["target"]);
            r.f_content = (string)(rows[0]["f_content"]);
            r.date = (DateTime)(rows[0]["date"]);
            r.response_id = (int)(rows[0]["response_id"]);
            return r;
        }
        public void updateReportResponseID(int reportid, int newresponse) // Updates the reference to a report's response.
        {
            SqlCommand thecmd = new SqlCommand("update reports set response_id=@responseid where id=@reportid", cnn);
            thecmd.Parameters.AddWithValue("@responseid", newresponse);
            thecmd.Parameters.AddWithValue("@reportid", reportid);
            InsDelUpd(thecmd);
        }
    }
}

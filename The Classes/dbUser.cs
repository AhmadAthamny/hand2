using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hand2
{
    public class DbUser
    {
        public SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public DbUser() // Constructor Function
        {
            cnn.ConnectionString = new sqlConnection().returnConnectionString();
        }

        public int InsertUser(User u) // Inserts a new user to the table.
        {
            SqlCommand SqlStr = new SqlCommand("insert into Users (name, password, email, user_id) output INSERTED.ID values (@name, @password, @email, @user_id)", cnn);
            SqlStr.Parameters.AddWithValue("@name", u.name);
            SqlStr.Parameters.AddWithValue("@password", u.password);
            SqlStr.Parameters.AddWithValue("@email", u.email);
            SqlStr.Parameters.AddWithValue("@user_id", u.user_id);
            return InsDelUpd(SqlStr);
        }
        public void deleteUser(User u) // Deletes a specified user. (Which was never used, because there's no reasonable use for it)
        {
            SqlCommand sqlstr = new SqlCommand("delete from Users where id=@id", cnn);
            sqlstr.Parameters.AddWithValue("@id", u.id);
            InsDelUpd(sqlstr);
        }


        public void updateUser(User u) // Updates a specified user.
        {
            SqlCommand SqlStr = new SqlCommand("update Users set name=@name, email=@email, password=@password, user_id=@iden, verified=@verified, level=@level where id=@id", cnn);
            SqlStr.Parameters.AddWithValue("@name", u.name);
            SqlStr.Parameters.AddWithValue("@email", u.email);
            SqlStr.Parameters.AddWithValue("@password", u.password);
            SqlStr.Parameters.AddWithValue("@level", u.level);
            SqlStr.Parameters.AddWithValue("@id", u.id);
            SqlStr.Parameters.AddWithValue("@iden", u.user_id);
            SqlStr.Parameters.AddWithValue("@verified", u.verified);
            InsDelUpd(SqlStr);
        }
        public DataSet getallUsers() // Returns a dataset of users (Used for managing users in administration panel)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Users where id>0";
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
        public bool Found(string  email) // Checks whether an email is already registered.
        {
            DataSet ds = new DataSet();
            SqlCommand str = new SqlCommand("select * from users where email=@email", cnn);
            str.Parameters.AddWithValue("@email", email);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
        public bool isUserFoundByIdentity(string id) // Checks whether someone registered with a specified ID or no.
        {
            DataSet ds = new DataSet();
            SqlCommand str = new SqlCommand("select * from users where user_id=@id", cnn);
            str.Parameters.AddWithValue("@id", id);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
        public int addMessage(User from, User to, string content, string title, int tmp_tolvl = -1) // Sends a message from user to user with proper content and title.
        {
            content = Regex.Replace(content, "<.*?>", string.Empty);
            SqlCommand SqlStr = new SqlCommand("insert into Messages (fromuser, touser, title, contents, tolevel) output INSERTED.ID values (@fromuser,@touser,@title,@contents, @tolevel)", cnn);
            SqlStr.Parameters.AddWithValue("@fromuser", from.id);
            SqlStr.Parameters.AddWithValue("@touser", to.id);
            SqlStr.Parameters.AddWithValue("@title", title);
            SqlStr.Parameters.AddWithValue("@contents", content);
            SqlStr.Parameters.AddWithValue("@tolevel", tmp_tolvl);
            return InsDelUpd(SqlStr);
        }
        public User returnUserInfo(string email) // Returns an object of "User" that contains data of a specified user by user's Email.
        {
            User u = new User();
            SqlCommand command = new SqlCommand("select * from users where email=@email", cnn);
            command.Parameters.AddWithValue("@email", email);
            DataRowCollection rows = ReturnDS(command).Tables[0].Rows;
            u.id = (int)(rows[0]["id"]);
            u.name = (string)(rows[0]["name"]);
            u.email = (string)(rows[0]["email"]);
            u.password = (string)(rows[0]["password"]);
            u.level = (int)(rows[0]["level"]);
            u.joindate = (DateTime)(rows[0]["joindate"]);
            u.verified = (int)(rows[0]["verified"]);
            u.user_id = (string)(rows[0]["user_id"]);
            return u;
        }
        public User returnUserInfoByID(int id) // Returns an object of "User" by user's table ID.
        {
            User u = new User();
            SqlCommand command = new SqlCommand("select * from users where id=@id", cnn);
            command.Parameters.AddWithValue("@id", id);
            DataRowCollection rows = ReturnDS(command).Tables[0].Rows;
            u.id = id;
            u.name = (string)(rows[0]["name"]);
            u.email = (string)(rows[0]["email"]);
            u.password = (string)(rows[0]["password"]);
            u.level = (int)(rows[0]["level"]);
            u.joindate = (DateTime)(rows[0]["joindate"]);
            u.verified = (int)(rows[0]["verified"]);
            u.user_id = (string)(rows[0]["user_id"]);
            return u;
        }
        public User returnUserInfoByIdentity(string id) // Returns an object of "User" by user's identity ID.
        {
            User u = new User();
            SqlCommand command = new SqlCommand("select * from users where user_id=@id", cnn);
            command.Parameters.AddWithValue("@id", id);
            DataRowCollection rows = ReturnDS(command).Tables[0].Rows;
            u.id = (int)(rows[0]["id"]);
            u.name = (string)(rows[0]["name"]);
            u.email = (string)(rows[0]["email"]);
            u.password = (string)(rows[0]["password"]);
            u.level = (int)(rows[0]["level"]);
            u.joindate = (DateTime)(rows[0]["joindate"]);
            u.verified = (int)(rows[0]["verified"]);
            u.user_id = (string)(rows[0]["user_id"]);
            return u;
        }
        public string getUserName(string email) // Returns the name of a user by user's email.
        {
            return returnUserInfo(email).name;
        }
        public string getUserNamebyID(int id) // Returns the name of a user by user's table ID.
        {
            return returnUserInfoByID(id).name;
        }
        public bool accValidInfo(User u) // Checks whether user has entered a valid login information (email & password)
        {
            DataSet ds = new DataSet();
            SqlCommand str = new SqlCommand("select * from users where email=@email and password=@password", cnn);
            str.Parameters.AddWithValue("@email", u.email);
            str.Parameters.AddWithValue("@password", u.password);
            ds = ReturnDS(str);
            if(ds.Tables[0].Rows.Count == 0)
                return false;
            else return true;
        }
        public string returnUserReadMessages(int u_id) // Returns the string of all user's read messages (Used to show proper notification pop-up)
        {
            SqlCommand cmd = new SqlCommand("select messages_read from users where id=@id", cnn);
            cmd.Parameters.AddWithValue("@id", u_id);
            DataRowCollection rows = ReturnDS(cmd).Tables[0].Rows;
            return (string)(rows[0]["messages_read"]);
        }
        public string[] returnAllValidEmails(SqlCommand q) // Returns an array of strings that contains all account's emails.
        {
            int length = ReturnDS(q).Tables[0].Rows.Count;
            DataRowCollection rows = ReturnDS(q).Tables[0].Rows;
            if (rows.Count == 0) return null;
            string[] the_final = new string[rows.Count];
            for (int i = 0; i < length; i++)
                the_final[i] = (string)(rows[i]["email"]);
            return the_final;
        }
        public DataSet SearchUserbyID(int id) // Returns a dataset that contains a user data.
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from Users where id={0} and id>0", id);
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ds;
        }
        public int InsDelUpd(SqlCommand SqlStr) // Function that executes single sql queries like INSERT/DELETE/UPLOAD
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
        public DataSet ReturnDS(SqlCommand SqlStr) // Returns a dataset of a specified sql query.
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
        public string generateVerifyCode(User u) // Generates a randomized code for accounts' verifications.
        {
            string randomcode = RandomString(16);
            SqlCommand SqlStr = new SqlCommand("update Users set code=@code where email=@email", cnn);
            SqlStr.Parameters.AddWithValue("@code", randomcode);
            SqlStr.Parameters.AddWithValue("@email", u.email);
            InsDelUpd(SqlStr);
            return randomcode;
        }
        public bool UserCanSeeMessage(User u, int msg_id) // Checks whether a specified user can view a specified message. (Has enough permissions)
        {
            viewMessages vm = new viewMessages();
            vm = vm.returnMessageInfo(msg_id);
            if (vm.toid == u.id || (vm.toid == -1 && u.level >= vm.tolevel))
                return true;
            else return false;
        }
        public void UpdateUserReadMessages(User u) // Updates the string of read messages of a specified user id (Complicated idea)
        {
            int[] the_array = null;
            string user_readmsgs = returnUserReadMessages(u.id);
            string final_string = user_readmsgs;
            if (user_readmsgs != "none")
            {
                final_string = user_readmsgs.Remove(0, 1);
                the_array = final_string.Split('#').Select(n => Convert.ToInt32(n)).ToArray();
            }
            final_string = user_readmsgs;
            if (the_array != null)
            {
                for (int i = 0; i < the_array.Length; i++)
                {
                    if (!UserCanSeeMessage(u, the_array[i]))
                        final_string = final_string.Replace("#" + the_array[i], "");
                }
            }
            if (final_string.Length == 0 || the_array == null)
                final_string = "none";
            SqlCommand SqlStr = new SqlCommand("update Users set messages_read=@finalstring where id=@id", cnn);
            SqlStr.Parameters.AddWithValue("@finalstring", final_string);
            SqlStr.Parameters.AddWithValue("@id", u.id);
            InsDelUpd(SqlStr);
        }
        private static Random random = new Random();
        public static string RandomString(int length) // Returns a randomized string.
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}

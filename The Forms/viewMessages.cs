using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hand2
{
    public partial class viewMessages : Form
    {
        User u;
        mainPage mp;
        public string msgs_read = "none";
        messageDisplayInfo lastChosenMessage = null;
        List<viewMessages> list = new List<viewMessages>();
   
        public int msgid { get; set; }
        public int fromid { get; set; }
        public int toid { get; set; }
        public int tolevel { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }

        public SqlConnection cnn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public DataSet ds = new DataSet();
        public viewMessages() 
        {
            cnn.ConnectionString = new sqlConnection().returnConnectionString();
        }
        public viewMessages(User tmpu, mainPage tmpmp)
        {
            InitializeComponent();
            u = tmpu;
            mp = tmpmp;
            cnn.ConnectionString = new sqlConnection().returnConnectionString();

            DbUser db = new DbUser();
            msgs_read = db.returnUserReadMessages(u.id);
        }

        private void viewMessages_FormClosed(object sender, FormClosedEventArgs e)
        {
            mp.Enabled = true;
        }

        private void viewMessages_LocationChanged(object sender, EventArgs e)
        {

        }

        private void viewMessages_Load(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("select * from messages where touser=@userid or (tolevel<=@userlevel and touser=-1 and date>=@userdate) ORDER BY id DESC", cnn);
            query.Parameters.AddWithValue("@userid", u.id);
            query.Parameters.AddWithValue("@userlevel", u.level);
            query.Parameters.AddWithValue("@userdate", u.joindate);
            init(query);
        }
        public void init(SqlCommand query)
        {
            DbUser bb = new DbUser();
            panel2.VerticalScroll.Value = 0;
            panel2.Controls.Clear();
            panel2.Controls.Add(msgNoResults);
            list = getAllMessages(query);
            messageDisplayInfo[] arr = new messageDisplayInfo[list.Count];
            int i = 0;
            foreach (viewMessages vm in list)
            {
                string toname = "";
                string fromname;
                if (vm.fromid == -1)
                    fromname = "Hand2";
                else
                    fromname = bb.getUserNamebyID(vm.fromid);
                if(vm.toid != -1)
                     toname = bb.getUserNamebyID(vm.toid);
                messageDisplayInfo d = new messageDisplayInfo();
                d.DoubleClick += new EventHandler(d_doubleclick);
                d.MouseEnter += new EventHandler(d_MouseEnter);
                d.MouseLeave += new EventHandler(d_MouseLeave);
                if (vm.toid == -1)
                {
                    d.msgTitle.Text = vm.title;
                    d.msgContent.Location = new Point(d.msgContent.Location.X, 34);
                    d.msgFrom.Text = string.Empty;
                }
                else if (vm.fromid == u.id) d.msgFrom.Text = "To: " + toname;
                else if (vm.toid == u.id) d.msgFrom.Text = "From: " + fromname;
                d.msgTitle.Text = vm.title;
                d.msgDate.Text = vm.date.ToString();
                d.msgContent.Text = vm.content;
                d.msgHoldsID.Text = vm.msgid.ToString();
                if (vm.fromid == u.id && vm.toid != -1)
                {
                    d.msgRead.Visible = true;
                    if (IsMessageReadByUser(vm.toid, vm.msgid))
                        d.msgRead.Text = "*SEEN";
                    else
                        d.msgRead.Text = "*DELIVERED";
                }
                else if (vm.toid == u.id || (vm.toid == -1 && u.level >= vm.tolevel))
                {
                    
                    if (!IsMessageReadByUser(u.id, vm.msgid))
                        d.msgRead.Visible = true;
                    else
                        d.msgRead.Visible = false;
                }
                else
                    d.msgRead.Visible = false;
                arr[i] = d;
                i++;
            }
            if (i == 0)
                msgNoResults.Visible = true;
            else
                msgNoResults.Visible = false;
            int y = 0;
            foreach (messageDisplayInfo vm in arr)
            {
                vm.Location = new Point(0, y);
                vm.BackColor = Color.FromArgb(212, 212, 212);
                panel2.Controls.Add(vm);
                y += vm.Height + 2;
            }
        }
        public void d_doubleclick(object sender, EventArgs e)
        {
            messageDisplayInfo clickedMessage = (messageDisplayInfo)sender;
            int id = int.Parse(clickedMessage.msgHoldsID.Text);
            clickedMessage.BackColor = Color.FromArgb(227, 227, 227);
            if (lastChosenMessage != null && lastChosenMessage != clickedMessage)
                    clickedMessage.BackColor = Color.FromArgb(212, 212, 212);

            lastChosenMessage = clickedMessage;
            messageDisplay msgdiaplyform = new messageDisplay(returnMessageInfo(id), this, u);
            msgdiaplyform.Show();
            this.Enabled = false;
            if (clickedMessage.msgRead.Visible == true && (returnMessageInfo(id).fromid != u.id || returnMessageInfo(id).toid == -1))
            {
                DbUser db = new DbUser();
                User updated_leveluser = db.returnUserInfoByID(u.id);
                if (db.UserCanSeeMessage(updated_leveluser, id))
                {
                    clickedMessage.msgRead.Visible = false;
                    UserDidReadMessage(u, id);
                }
                else
                {
                    msgdiaplyform.Close();
                    this.Hide();
                    this.Close();
                    mp.Close();
                    mp = new mainPage(updated_leveluser, mp.buyOrRent);

                    MessageBox.Show("Re-opening messages due to some technical purposes.");
                    viewMessages vm = new viewMessages(updated_leveluser, mp);
                    mp.Show();
                    mp.Enabled = false;
                    vm.ShowDialog(mp);
                }
            }
        }
        public void d_MouseEnter(object sender, EventArgs e)
        {
            messageDisplayInfo hoveringMessage = (messageDisplayInfo)sender;
            if (hoveringMessage != lastChosenMessage)
                hoveringMessage.BackColor = Color.FromArgb(227, 227, 227);
        }
        public void d_MouseLeave(object sender, EventArgs e)
        {
            messageDisplayInfo leavingMessage = (messageDisplayInfo)sender;
            if (leavingMessage != lastChosenMessage)
                leavingMessage.BackColor = Color.FromArgb(212, 212, 212);

        }

        private void btnmsgsInbox_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("select * from messages where touser=@userid or (tolevel<=@userlevel and touser=-1 and date>=@userdate) ORDER BY id DESC", cnn);
            query.Parameters.AddWithValue("@userid", u.id);
            query.Parameters.AddWithValue("@userlevel", u.level);
            query.Parameters.AddWithValue("@userdate", u.joindate);
            init(query);
        }

        private void btnmsgsSent_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("select * from messages where fromuser=@userid ORDER BY id DESC", cnn);
            query.Parameters.AddWithValue("@userid", u.id);
            init(query);
        }

        private void btnmsgsAll_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("select * from messages where touser=@userid or (tolevel<=@userlevel and touser=-1 and date>=@userdate) or fromuser=@userid ORDER BY id DESC", cnn);
            query.Parameters.AddWithValue("@userid", u.id);
            query.Parameters.AddWithValue("@userlevel", u.level);
            query.Parameters.AddWithValue("@userdate", u.joindate);
            init(query);
        }
        public List<viewMessages> getAllMessages(SqlCommand q)
        {
            int length = ReturnDS(q).Tables[0].Rows.Count;
            DataRowCollection rows = ReturnDS(q).Tables[0].Rows;
            List<viewMessages> ppap = new List<viewMessages>();
            for (int i = 0; i < length; i++)
            {
                viewMessages vm = new viewMessages();
                vm.msgid = (int)(rows[i]["id"]);
                vm.fromid = (int)(rows[i]["fromuser"]);
                vm.toid = (int)(rows[i]["touser"]);
                vm.tolevel = (int)(rows[i]["tolevel"]);
                vm.title = (string)(rows[i]["title"]);
                vm.content = (string)(rows[i]["contents"]);
                vm.date = (DateTime)(rows[i]["date"]);
                ppap.Add(vm);
            }
            return ppap;
        }
        public viewMessages returnMessageInfo(int msgid)
        {
            viewMessages vm = new viewMessages();
            SqlCommand query = new SqlCommand("select * from messages where id=@msgid", cnn);
            query.Parameters.AddWithValue("@msgid", msgid);
            DataRowCollection rows = ReturnDS(query).Tables[0].Rows;
            vm.msgid = (int)(rows[0]["id"]);
            vm.fromid = (int)(rows[0]["fromuser"]);
            vm.toid = (int)(rows[0]["touser"]);
            vm.tolevel = (int)(rows[0]["tolevel"]);
            vm.title = (string)(rows[0]["title"]);
            vm.content = (string)(rows[0]["contents"]);
            vm.date = (DateTime)(rows[0]["date"]);
            return vm;
        }
        public int GetUserUnreadMessages(User u)
        {
            cnn.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM messages where touser=@touser or (tolevel<=@tolevel and touser=-1 and date>=@joindate)", cnn);
            comm.Parameters.AddWithValue("@touser", u.id);
            comm.Parameters.AddWithValue("@tolevel", u.level);
            comm.Parameters.AddWithValue("@joindate", u.joindate);
            Int32 total_readmsgs = (Int32) comm .ExecuteScalar();
            cnn.Close();
            if (msgs_read != "none")
                return total_readmsgs - ((msgs_read.Length - msgs_read.Replace("#", "").Length) / "#".Length);
            else
                return total_readmsgs;
        }
        public void UserDidReadMessage(User u, int msg_id)
        {
            if (msgs_read == "none")
                msgs_read = msgs_read.Remove(0, "none".Length);
            msgs_read = msgs_read.Insert(msgs_read.Length, "#" + msg_id.ToString());

            SqlCommand query = new SqlCommand("UPDATE Users SET messages_read=@msgsread where id=@userid", cnn);
            query.Parameters.AddWithValue("@msgsread", msgs_read);
            query.Parameters.AddWithValue("@userid", u.id);
            InsDelUpd(query);
        }
        public bool IsMessageReadByUser(int userid, int msg_id)
        {
            DbUser db = new DbUser();
            if (db.returnUserReadMessages(userid).Contains("#" + msg_id.ToString()))
                return true;
            else
                return false;
        }
        public int InsDelUpd(SqlCommand SqlStr)
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
        public DataSet ReturnDS(SqlCommand SqlStr)
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
    }
}

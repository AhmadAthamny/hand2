using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;

namespace Hand2
{
    public partial class initPage : Form
    {
        string API_KEY = "zgdwgjcevfsnoqoo"; // DONT CHANGE THIS

        int redirectID;
        mainPage to_redirect;
        public initPage(mainPage mp_temp, int redirectToPage = 0)
        {
            InitializeComponent();
            redirectID = redirectToPage;
            to_redirect = mp_temp;
        }
        public initPage()
        {
        }

        private void initPage_Load(object sender, EventArgs e)
        {
        }

        private void usrText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DbUser db = new DbUser();
            User u = new User();
            int id;
            u.email = emailText.Text;
            if (nameText.Text.Length < 6)
            {
                resetErrorProvider();
                erProvider.SetError(nameText, "Your name is too short.");
            }
            else if (!IsValidEmail(u.email))
            {
                resetErrorProvider();
                erProvider.SetError(emailText, "Invalid email address.");
            }
            else if (!int.TryParse(idText.Text, out id) || idText.Text.Length != 9)
            {
                resetErrorProvider();
                erProvider.SetError(idText, "Invalid ID");
            }
            else if (db.isUserFoundByIdentity(idText.Text))
            {
                resetErrorProvider();
                erProvider.SetError(idText, "ID exists already.");
            }

            else if (passText.Text.Length < 6 || passText.Text.Length > 32)
            {
                resetErrorProvider();
                erProvider.SetError(passText, "Minimum password is 6 and maximum is 32.");
            }
            else if (passText.Text != pass2Text.Text)
            {
                resetErrorProvider();
                erProvider.SetError(passText, "Passwords don't match.");
            }
            else if (!db.Found(u.email))
            {
                resetErrorProvider();
                u.name = nameText.Text;
                u.level = 0;
                u.password = passText.Text;
                u.user_id = idText.Text;
                u.id = db.InsertUser(u);
                u = db.returnUserInfoByID(u.id);

                User from_hand2 = new User();
                from_hand2.id = -1;

                string msgContent =
                  "<center><h2>Hand2 - Account registered successfully!</h2>" +
                  "Hello " + u.name + ", welcome to the Hand2, we are very glad to see you joining us!" +
                  "<br>We highly advise you to take a good trip around our program to know more about it." +
                  "<br><br>Here is more info about the registration:" +
                  "<br><b>Full name:</b> " + u.name +
                  "<br><b>Identificaiton Number:</b>" + u.user_id +
                  "<br><b>Email:</b> " + u.email + " (It's the username you will use to log into your account)" +
                  "<br><b>Password:</b> ******** (If you've forgotten your password, then you can ask for recovery in the Hand2 application)" +
                  "<br><b>Registration Date:</b> " + u.joindate +
                  "<br><br><i>Hand2 © Copyrights reserved to Hand2, " + DateTime.Now.Year + "</i>" +
                  "</center>";

                string forTheMessage = msgContent.Replace("<br>", System.Environment.NewLine);
                forTheMessage = forTheMessage.Replace("Hand2 - Account registered successfully!", "");
                db.addMessage(from_hand2, u, forTheMessage, "Welcome to the Hand2!");
                MessageBox.Show("Your account has been registered successfully.\n\nYou may check your Email inbox for more info about your account.");
                SendEmail(u.email, "Hand2 - Welcome " + u.name + "!", msgContent);
            }
            else if (db.Found(u.email))
            {
                resetErrorProvider();
                erProvider.SetError(emailText, "This email exists already.");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DbUser db = new DbUser();
            User u = new User();
            u.email = usrText.Text;
            u.password = pwText.Text;
            if (db.accValidInfo(u))
            {
                u = db.returnUserInfo(u.email);
                redirectToPage(redirectID, u, to_redirect.buyOrRent);
            }
            else MessageBox.Show("Incorrect username or password.");
        }
        private void pwForgotLabel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            forgotPW fpw = new forgotPW(this);
            fpw.Show();
        }
        public void SendEmail(string to, string title, string content)
        {
            if (IsNetworkAvailable())
            {
                try
                {
                    var msg = new MailMessage("Hand2 - Password Reset <thehandtwo@gmail.com>", to, title, content);
                    msg.IsBodyHtml = true;
                    var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("thehandtwo@gmail.com", API_KEY);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(msg);
                }
                catch
                {
                    MessageBox.Show("Message wasn't sent due to technical issues\n\ninitPage.cs Line 149");
                }
            }
            else
                MessageBox.Show("Sorry, you must be connected to the internet in order to send and receive Emails.");
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public void redirectToPage(int redirectToPage, User u, int buyOrRent = 0)
        {
            this.Hide();
            if (redirectToPage == 1)
            {
                addCar ad = new addCar(u, buyOrRent);
                ad.Show();
            }
            if (redirectToPage == 2)
            {
                mainPage mp = new mainPage(u, buyOrRent);
                mp.Show();
            }
        }
        private void initPageBack_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.id = -1;
            u.verified = -1;
            u.name = "Guest";
            redirectToPage(redirectID, u, to_redirect.buyOrRent);
        }

        private void initPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            User u = new User();
            u.id = -1;
            u.verified = -1;
            u.name = "Guest";
            redirectToPage(redirectID, u, to_redirect.buyOrRent);
        }
        private void BOR_updateVersionList(string company_name)
        {
            
        }
        public bool IsAllControlsFull(params Control[] ctrl)
        {
            for (int i = 0; i < ctrl.Length; i++)
                if (ctrl[i].Text.Length == 0)
                    return false;
            return true;
        }
        public void resetErrorProvider()
        {
            erProvider.SetError(emailText, "");
            erProvider.SetError(nameText, "");
            erProvider.SetError(passText, "");
            erProvider.SetError(idText, "");
        }
        public bool IsNetworkAvailable(long minimumSpeed = 10000000)
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
    }
}

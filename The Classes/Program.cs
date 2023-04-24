using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hand2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initPage ip = new initPage();
            if (!ip.IsNetworkAvailable())
                MessageBox.Show("No internet connection detected.\n\nWe highly recommend you to connect to the internet while using the Hand2 program, otherwise you won't be able to use many features.", "No Internet Connection");

            User u = new User();
            u.id = -1;
            u.verified = -1;
            u.level = 0;
            u.name = "Guest";
            Application.Run(new chooseBuyRent(u));
        }
    }
}

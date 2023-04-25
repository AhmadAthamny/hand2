using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hand2
{
    public class sqlConnection // A little class that handles sql connection and ensure the sql database file exists to avoid crashes.
    {
        public sqlConnection()
        {
        }
        public string returnConnectionString()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            string sqlDBLocation = projectDirectory + "\\HandDatabase.mdf";
            if (!File.Exists(sqlDBLocation))
            {
                MessageBox.Show("Sorry, the SQL database file wasn't found.\n\nYou can download it from the link provided in README file of the Github repo.\n\nFor more information, contact Ahmad! :)");
                System.Environment.Exit(1);
            }
            return @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=" + sqlDBLocation+ ";Integrated Security=True; Connect Timeout=30";

            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Ahmad Athamny\Desktop\high-school-project\Hand2\HandDatabase.mdf";Integrated Security=True;Connect Timeout=30

            //Data Source =.\SQLEXPRESS;AttachDbFilename="C:\Users\Ahmad Athamny\Desktop\high-school-project\Hand2\HandDatabase.mdf"; Integrated Security = True; User Instance = True
        }
    }
}

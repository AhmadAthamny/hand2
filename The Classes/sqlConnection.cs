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

            string sqlDBLocation = @"C:\Users\אחמד עתאמנה\Documents\Visual Studio 2010\Projects\Hand2\Hand2\HandDatabase.mdf"; // Edit this variable only, please don't touch anything else.

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            if (File.Exists(projectDirectory + "\\HandDatabase.mdf")) 
                sqlDBLocation = projectDirectory + "\\HandDatabase.mdf";
            else
                if (!File.Exists(sqlDBLocation))
                {
                    MessageBox.Show("Sorry, the SQL database file wasn't found.\n\nTo fix this, please open the project code, open \"sqlConnection.cs\" file and edit the \"sqlDBLocation\" to the current one.\n\nSorry for the inconvinence.");
                    System.Environment.Exit(1);
                }
            return @"Data Source=.\SQLExpress;Integrated Security=true; 
        AttachDbFilename="+sqlDBLocation+";User Instance=true";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hand2
{
    public class rentStation // Class for rent stations (Constructor Function)
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public int opensfrom { get; set; }
        public int opensto { get; set; }
        public int status { get; set; }
    }
}

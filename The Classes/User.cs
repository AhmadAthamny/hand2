using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hand2
{
   public class User // A class for users (Constructor Function)
    {
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public DateTime joindate { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int verified { get; set; }
        public string code { get; set; }
        public int viewingCarID { get; set; }
        public string user_id { get; set; }
    }
}

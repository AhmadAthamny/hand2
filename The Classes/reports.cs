using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hand2
{

    public class reports // Class for reports (feedback, help requests, user report, bug reports, other..)
    {
        public int id { get; set; }
        public int f_type { get; set; }
        public int sender_id { get; set; }
        public int target_id { get; set; }
        public string f_content { get; set; }
        public DateTime date { get; set; }
        public int response_id { get; set; }
    }
}

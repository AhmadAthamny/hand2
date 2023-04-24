using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hand2
{
    public class rentPeriod // Class for rent periods (Constructor Function)
    {
        public int id { get; set; }
        public int carid { get; set; }
        public DateTime to_date { get; set; }
        public DateTime from_date { get; set; }
        public int moneyperday { get; set; }
        public int pickup_from { get; set; }
        public int return_to { get; set; }
        public int rent_by { get; set; }
        public string rent_info { get; set; }
    }
}

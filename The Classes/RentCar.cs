using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hand2
{
    public class RentCar // Class for rent cars. (Constructor Function)
    {
        public int id { get; set; }
        public string company { get; set; }
        public string version { get; set; }
        public int year { get; set; }
        public int priceday { get; set; }
        public string geartype { get; set; }
        public byte[] picture { get; set; }
        public int available { get; set; }
        public DateTime last_period_date { get; set; }
    }
}

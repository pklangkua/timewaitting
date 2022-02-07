using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace time_waitting.Models
{
    public class SumpatienModel
    {
        public double t_newpatien { get; set; }
        public double t_oldpatien { get; set; }
        public double t_admit { get; set; }
        public double sumtime { get; set; }

        public int t_year { get; set; }
        public int t_year2 { get; set; }
        public int t_month { get; set; }
        public string point { get; set; }
        public string t_hosp { get; set; }
    }
}

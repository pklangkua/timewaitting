using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace time_waitting.Models
{
    public class cmonth
    {
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int m_id { get; set; }
        public string m_name { get; set; }
    }
}

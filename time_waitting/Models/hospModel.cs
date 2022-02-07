using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace time_waitting.Models
{
    public class hospModel
    {
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string hospcode { get; set; }
        public string hospname { get; set; }
    }
}

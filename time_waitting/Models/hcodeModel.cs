using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace time_waitting.Models
{
    public class hcodeModel
    {
        [Display(Name = "โรงพยาบาล")]
        public int hospcode { get; set; }
        [Display(Name = "ชื่อโรงพยาบาล")]
        public string hospname { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อผู้ใช้")]
        public string huser { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "รหัสผ่าน")]
        public string hpass { get; set; }
        [Display(Name = "สิทธิ์ผู้ใช้งาน")]
        public int status { get; set; }
        [Display(Name = "ชื่อ")]
        public string fname { get; set; }
        [Display(Name = "นามสกุล")]
        public string lname { get; set; }
        public string name { get; set; }
        public int hid { get; set; }
        public int type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace time_waitting.Models
{
    public class timeWaittingModel
    {
        public int t_id { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "จำนวนผู้ป่วยนอกใหม่")]
        public int t_newpatien { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "จำนวนผู้ป่วยนอกเก่า")]
        public int t_oldpatien { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลาลงทะเบียนที่ห้องบัตร")]
        public float t_card { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลาการคัดกรอง")]
        public float t_screen { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลารอพบแพทย์")]
        public float t_waitdoc { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลาในห้องตรวจแพทย์")]
        public float t_roomdoc { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลาหลังพบแพทย์")]
        public float t_prescription { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลารอการชำระเงิน")]
        public float t_waitmed { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลารอรับยา")]
        public float t_med { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลารอรับยาเดิม")]
        public float t_oldmed { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลากรณีผู้ป่วยได้รับ intervention อื่นๆ")]
        public float t_inter { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "จำนวนผู้ป่วยรับไว้รักษา (Admit)")]
        public float t_admit { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ระยะเวลาในการจัดทำบริการเพื่อรับไว้รักษา (Admit)")]
        public float t_prepare_admit { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "รหัสโรงพยาบาล")]
        public int t_hcode { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ประจำเดือน")]
        public int t_month { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ปีงบประมาณ")]
        public int t_year { get; set; }
        [Display(Name = "สถานะการแก้ไข")]
        public int t_edit  { get; set; }
        [Display(Name = "วันที่บันทึกข้อมูล")]
        public DateTime t_date { get; set; }
        [Display(Name = "โรงพยาบาล")]
        public string hname { get; set; }
        [Display(Name = "เดือน")]
        public string m_name { get; set; }
        public string t_user { get; set; }
        [Display(Name = "ประเภทของผู้ป่วย")]
        public int type { get; set; }


    }
}

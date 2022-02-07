using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace time_waitting
{
    public class function
    {
        public string subsql(string point)
        {
            string subsql = string.Empty;
            switch (point)
            {
                case "t_card":
                    subsql = "ROUND(SUM(t_card )/COUNT(t_id), 2)";
                    break;
                case "t_screen":
                    subsql = "ROUND(SUM(t_screen )/COUNT(t_id), 2)";
                    break;
                case "t_waitdoc":
                    subsql = "ROUND(SUM(t_waitdoc )/COUNT(t_id), 2)";
                    break;
                case "t_roomdoc":
                    subsql = "ROUND(SUM(t_roomdoc ) / COUNT(t_id), 2)";
                    break;
                case "t_prescription":
                    subsql = "ROUND(SUM(t_prescription ) / COUNT(t_id), 2)";
                    break;
                case "t_waitmed":
                    subsql = "ROUND(SUM(t_waitmed ) / COUNT(t_id), 2)";
                    break;
                case "t_med":
                    subsql = "ROUND(SUM(t_med ) / COUNT(t_id), 2)";
                    break;
                case "t_oldmed":
                    subsql = "ROUND(SUM(t_oldmed ) / COUNT(t_id), 2)";
                    break;
                case "t_inter":
                    subsql = "ROUND(SUM(t_inter ) / COUNT(t_id), 2)";
                    break;
                case "t_prepare_admit":
                    subsql = "ROUND(SUM(t_prepare_admit ) / COUNT(t_id), 2)";
                    break;

                default:
                    subsql = "ROUND(SUM(t_card + t_screen + t_waitdoc + t_roomdoc + t_prescription + t_waitmed + t_med + t_oldmed + t_inter + t_prepare_admit) / COUNT(t_id) , 2)";
                    break;
            }
            return subsql;
        }

        public string chartYear(int years, string point)
        {
            string sql = @"SELECT
                             ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2) AS t_card , 
                             ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2) AS t_screen , 
                             ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2) AS t_waitdoc , 
                             ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2) AS t_roomdoc , 
                             ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2) AS t_prescription ,
                             ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2) AS t_waitmed , 
                             ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2) AS t_med , 
                             ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2) AS t_oldmed, 
                             ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2) AS t_inter , 
                             ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2) AS t_prepare_admit
                            FROM timeWaitting ";
            if (years != 0 && point == "0")
            {
                sql += @" WHERE t_year = '" + years + "'  GROUP BY t_year";
            }
            else if (years == 0 && point == "0")
            {
                sql += @" WHERE t_year = '" + years + "'  GROUP BY t_year";
            }
            else
            {
                sql += @" WHERE t_year = '" + years + "' AND t_hcode = '" + point + "'  GROUP BY t_year";
            }

            return sql;
        }

        public string hosp(string hosp)
        {
            string hosps = string.Empty;
            switch (hosp)
            {
                case "11597":
                    hosps = "สถาบันกัลยาณ์ราชนครินทร์";
                    break;
                case "12244":
                    hosps = "สถาบันจิตเวชศาสตร์สมเด็จเจ้าพระยา";
                    break;
                case "12246":
                    hosps = "สถาบันราชานุกูล";
                    break;
                case "12251":
                    hosps = "โรงพยาบาลยุวประสาทไวทโยปถัมภ์";
                    break;
                case "12260":
                    hosps = "โรงพยาบาลศรีธัญญา";
                    break;
                case "12268":
                    hosps = "โรงพยาบาลจิตเวชนครราชสีมาราชนครินทร์";
                    break;
                case "12269":
                    hosps = "โรงพยาบาลพระศรีมหาโพธิ์";
                    break;
                case "12272":
                    hosps = "โรงพยาบาลจิตเวชขอนแก่นราชนครินทร์";
                    break;
                case "12277":
                    hosps = "โรงพยาบาลจิตเวชนครพนมราชนครินทร์";
                    break;
                case "12280":
                    hosps = "โรงพยาบาลสวนปรุง";
                    break;
                case "12289":
                    hosps = "โรงพยาบาลสวนสราญรมย์";
                    break;
                case "12290":
                    hosps = "โรงพยาบาลจิตเวชสงขลาราชนครินทร์";
                    break;
                case "13775":
                    hosps = "สถาบันพัฒนาการเด็กราชนครินทร์";
                    break;
                case "14171":
                    hosps = "โรงพยาบาลจิตเวชนครสวรรค์ราชนครินทร์";
                    break;
                case "14644":
                    hosps = "โรงพยาบาลจิตเวชเลยราชนครินทร์";
                    break;
                case "14717":
                    hosps = "โรงพยาบาลจิตเวชสระแก้วราชนครินทร์";
                    break;
                case "14955":
                    hosps = "สถาบันสุขภาพจิตเด็กและวัยรุ่นราชนครินทร์";
                    break;
                case "24746":
                    hosps = "สถาบันสุขภาพจิตเด็กและวัยรุ่นภาคตะวันออกเฉียงเหนือ";
                    break;
                case "40915":
                    hosps = "สถาบันสุขภาพจิตเด็กและวัยรุ่นภาคใต้";
                    break;
                case "41429":
                    hosps = "โรงพยาบาลจิตเวชพิษณุโลก";
                    break;
                case "0":
                    hosps = "";
                    break;
            }
            return hosps;
        }

        public string point(string point)
        {
            string points = string.Empty;

            switch (point)
            {
                case "t_card":
                    points = "ระยะเวลาลงทะเบียนที่ห้องบัตร";
                    break;
                case "t_screen":
                    points = "ระยะเวลาการคัดกรอง";
                    break;
                case "t_waitdoc":
                    points = "ระยะเวลารอพบแพทย์";
                    break;
                case "t_roomdoc":
                    points = "ระยะเวลาในห้องตรวจแพทย์";
                    break;
                case "t_prescription":
                    points = "ระยะเวลาหลังพบแพทย์จนถึงยื่นใบสั่งยา";
                    break;
                case "t_waitmed":
                    points = "ระยะเวลารอรับยา";
                    break;
                case "t_med":
                    points = "ระยะเวลารับยาเดิม";
                    break;
                case "t_oldmed":
                    points = "ระยะเวลารอรับยาเดิม";
                    break;
                case "t_inter":
                    points = "ระยะเวลากรณีได้รับ intervention อื่นๆ(บำบัดรักษา ฟื้นฟูทางจิต สังคม)";
                    break;
                case "t_prepare_admit":
                    points = "ระยะเวลาในการจัดทำ/บริการเพื่อรับไว้รักษา(Admit)";
                    break;

            }
            return points;
        }

    }
}

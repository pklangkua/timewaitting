using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Session;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using time_waitting.Models;

namespace time_waitting
{
    public class Datetime
    {
        public string changeDatetime(DateTime dpt) // แปลงวันที่เป็น 00/00/0000
        {
            string changeDate = "";
            string Year = (dpt.Year).ToString();
            string month = (dpt.Month).ToString("00");
            string day = (dpt.Day).ToString("00");
            //string month = dpt.Month.ToString("00");

            changeDate = Year + "-" + month + "-" + day;

            return changeDate;
        }

        public int Years()
        {
            int Years = 0;
            DateTime Y = DateTime.Now;
            int m = Convert.ToInt32(Y.Month);
            int YY = Convert.ToInt32(Y.Year);
            if (m > 9)
            {
                Years = YY + 544;
            }
            else
            {
                Years = YY + 543;
            }
            return Years;

        }
        public string Month(int m)
        {
            string Month = string.Empty;

            switch (m)
            {
                case 1:
                    Month = "มกราคม";
                    break;
                case 2:
                    Month = "กุมภาพันธ์";
                    break;
                case 3:
                    Month = "มีนาคม";
                    break;
                case 4:
                    Month = "เมษายน";
                    break;
                case 5:
                    Month = "พฤษภาคม";
                    break;
                case 6:
                    Month = "มิถุนายน";
                    break;
                case 7:
                    Month = "กรกฎาคม";
                    break;
                case 8:
                    Month = "สิงหาคม";
                    break;
                case 9:
                    Month = "กันยายน";
                    break;
                case 10:
                    Month = "ตุลาคม";
                    break;
                case 11:
                    Month = "พฤศจิกายน";
                    break;
                case 12:
                    Month = "ธันวาคม";
                    break;
            }

            return Month;

        }

        public int CheckDate()
        {
            SqlConnection sqlconn = new DBClass().SqlStrCon();
            int Check = 0;

            string sql = @"select * from Setting WHERE id = 1";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                Check = Convert.ToInt32(sdr["set"]);
            }
            sqlconn.Close();

            return Check;

        }

    }
}

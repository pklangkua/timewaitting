using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Session;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using time_waitting.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace time_waitting.Controllers
{
    public class ReportController : Controller
    {
        SqlConnection sqlconn = new DBClass().SqlStrCon();
        Datetime Years = new Datetime();
        function chartYear = new function();
        public IActionResult Report1()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                int hcode = (int)HttpContext.Session.GetInt32("hospcode");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                ViewData["hosp"] = hosp();
                ViewData["cmonth"] = cmonth();
                int y = Years.Years();

                //Chart1(y - 1, "0");
                //Chart2(y, "0");
                ChartReport1(y - 1, y, "0", hcode);
                ChartReport1_old(y - 1, y, "0", hcode);

                ViewData["Date2"] = y;
                ViewData["Date1"] = y - 1;

                ViewData["Y1"] = y - 1; ;
                ViewData["Y2"] = y;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public List<hospModel> hosp()
        {
            List<hospModel> hosps = new List<hospModel>();
            string sql = @"select * from hosp";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                hospModel hosp = new hospModel();

                hosp.hospcode = sdr["hospcode"].ToString();
                hosp.hospname = sdr["hospname"].ToString();
                hosps.Add(hosp);
            }
            sqlconn.Close();
            return hosps;
        }
        public List<cmonth> cmonth()
        {
            List<cmonth> State = new List<cmonth>();
            string sql = "select * from cmonth ";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                cmonth States = new cmonth();

                States.m_id = Convert.ToInt32(sdr["m_id"]);
                States.m_name = sdr["m_name"].ToString();

                State.Add(States);
            }
            //ViewBag.OffList = off;
            sqlconn.Close();
            return State;
        }

        //public void Chart1(int t_year, string point)
        //{
        //    function subsql = new function();
        //    string sub = subsql.subsql(point);

        //    string sql = @"SELECT c.m_name, " + sub + " AS sumtime FROM timeWaitting INNER JOIN cmonth c on c.m_id = t_month ";

        //    if (t_year == 0)
        //    {
        //        sql += "GROUP BY c.m_name";
        //    }
        //    else if (t_year != 0)
        //    {
        //        sql += "WHERE t_year = '" + t_year + "'  GROUP BY c.m_name";
        //    }

        //    List<DataPoint> dataPoints = new List<DataPoint>();
        //    SqlCommand sqlcomm = new SqlCommand(sql);
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    sqlcomm.Connection = sqlconn;
        //    sqlconn.Open();
        //    sda.SelectCommand = sqlcomm;

        //    SqlDataReader sdr = sqlcomm.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        dataPoints.Add(new DataPoint(sdr["m_name"].ToString(), Convert.ToDouble(sdr["sumtime"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาลงทะเบียนที่ห้องบัตร", Convert.ToDouble(sdr["t_card"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาการคัดกรอง", Convert.ToDouble(sdr["t_screen"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารอพบแพทย์", Convert.ToDouble(sdr["t_waitdoc"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาในห้องตรวจแพทย์", Convert.ToDouble(sdr["t_roomdoc"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาหลังพบแพทย์จนถึงยื่นใบสั่งยา", Convert.ToDouble(sdr["t_prescription"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารอรับยา", Convert.ToDouble(sdr["t_waitmed"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารับยาเดิม", Convert.ToDouble(sdr["t_med"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารอรับยาเดิม", Convert.ToDouble(sdr["t_oldmed"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลากรณีได้รับ intervention อื่นๆ (บำบัดรักษา ฟื้นฟูทางจิต สังคม)", Convert.ToDouble(sdr["t_inter"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาในการจัดทำ/บริการเพื่อรับไว้รักษา (Admit)", Convert.ToDouble(sdr["t_prepare_admit"])));
        //    }
        //    sqlconn.Close();
        //    ViewData["Year1"] = dataPoints;
        //    //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
        //}
        public void ChartReport1(int t_year, int t_year2, string point, int hcode)
        {
            function subsql = new function();
            string sub = subsql.subsql(point);
            string sql = string.Empty;
            string orderby = "ORDER BY CASE c.m_name " +
                                                " WHEN  'ตุลาคม' THEN 1 " +
                                                 " WHEN 'พฤศจิกายน' THEN 2 " +
                                                 " WHEN 'ธันวาคม' THEN 3 " +
                                                 " WHEN 'มกราคม' THEN 4 " +
                                                 " WHEN 'กุมภาพันธ์' THEN 5 " +
                                                 " WHEN 'มีนาคม' THEN 6 " +
                                                 " WHEN 'เมษายน' THEN 7 " +
                                                 " WHEN 'พฤษภาคม' THEN 8 " +
                                                 " WHEN 'มิถุนายน' THEN 9 " +
                                                 " WHEN 'กรกฎาคม' THEN 10 " +
                                                 " WHEN 'สิงหาคม' THEN 11 " +
                                                 " WHEN 'กันยายน' THEN 12 " +
                                                 " END";
            if (hcode == 99999)
            {
                sql = @"SELECT c.m_name, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year + " AND t_month = c.m_id AND type = 2  GROUP BY t_month ),0)AS sumtime1, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year2 + " AND t_month = c.m_id AND type = 2  GROUP BY t_month),0)AS sumtime2 " +
                         " FROM cmonth c " + orderby;
            }
            else
            {
                sql = @"SELECT c.m_name, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year + " AND t_month = c.m_id AND type = 2 AND t_hcode =" + hcode + " GROUP BY t_month ),0)AS sumtime1, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year2 + " AND t_month = c.m_id AND type = 2 AND t_hcode =" + hcode + "  GROUP BY t_month),0)AS sumtime2 " +
                         " FROM cmonth c " + orderby;
            }

            List<SumYearModel> dataPoints = new List<SumYearModel>();
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                SumYearModel data = new SumYearModel();
                data.month = sdr["m_name"].ToString();
                data.y1 = Convert.ToUInt32(sdr["sumtime1"]);
                data.y2 = Convert.ToUInt32(sdr["sumtime2"]);
                dataPoints.Add(data);
            }

            sqlconn.Close();
            ViewData["Year1"] = dataPoints;
            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
        }
        public void ChartReport1_old(int t_year, int t_year2, string point, int hcode)
        {
            function subsql = new function();
            string sub = subsql.subsql(point);
            string sql = string.Empty;
            string orderby = "ORDER BY CASE c.m_name " +
                                                " WHEN  'ตุลาคม' THEN 1 " +
                                                 " WHEN 'พฤศจิกายน' THEN 2 " +
                                                 " WHEN 'ธันวาคม' THEN 3 " +
                                                 " WHEN 'มกราคม' THEN 4 " +
                                                 " WHEN 'กุมภาพันธ์' THEN 5 " +
                                                 " WHEN 'มีนาคม' THEN 6 " +
                                                 " WHEN 'เมษายน' THEN 7 " +
                                                 " WHEN 'พฤษภาคม' THEN 8 " +
                                                 " WHEN 'มิถุนายน' THEN 9 " +
                                                 " WHEN 'กรกฎาคม' THEN 10 " +
                                                 " WHEN 'สิงหาคม' THEN 11 " +
                                                 " WHEN 'กันยายน' THEN 12 " +
                                                 " END";
            if (hcode == 99999)
            {
                sql = @"SELECT c.m_name, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year + " AND t_month = c.m_id AND type = 1  GROUP BY t_month ),0)AS sumtime1, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year2 + " AND t_month = c.m_id AND type = 1  GROUP BY t_month),0)AS sumtime2 " +
                         " FROM cmonth c " + orderby;
            }
            else
            {
                sql = @"SELECT c.m_name, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year + " AND t_month = c.m_id AND type = 1 AND t_hcode =" + hcode + " GROUP BY t_month ),0)AS sumtime1, " +
                         " ISNULL((SELECT " + sub + " " +
                         " FROM timeWaitting WHERE t_year = " + t_year2 + " AND t_month = c.m_id AND type = 1 AND t_hcode =" + hcode + "  GROUP BY t_month),0)AS sumtime2 " +
                         " FROM cmonth c " + orderby;
            }

            List<SumYearModel> dataPoints = new List<SumYearModel>();
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                SumYearModel data = new SumYearModel();
                data.month = sdr["m_name"].ToString();
                data.y1 = Convert.ToUInt32(sdr["sumtime1"]);
                data.y2 = Convert.ToUInt32(sdr["sumtime2"]);
                dataPoints.Add(data);
            }

            sqlconn.Close();
            ViewData["Year1_old"] = dataPoints;
            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
        }

        //public void Chart2(int t_year, string point)
        //{
        //    function subsql = new function();
        //    string sub = subsql.subsql(point);

        //    string sql = @"SELECT c.m_name, " + sub + " AS sumtime FROM timeWaitting INNER JOIN cmonth c on c.m_id = t_month ";

        //    if (t_year == 0)
        //    {
        //        sql += "GROUP BY c.m_name";
        //    }
        //    else if (t_year != 0)
        //    {
        //        sql += "WHERE t_year = '" + t_year + "'  GROUP BY c.m_name";
        //    }

        //    List<DataPoint> dataPoints = new List<DataPoint>();

        //    SqlCommand sqlcomm = new SqlCommand(sql);
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    sqlcomm.Connection = sqlconn;
        //    sqlconn.Open();
        //    sda.SelectCommand = sqlcomm;

        //    SqlDataReader sdr = sqlcomm.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        dataPoints.Add(new DataPoint(sdr["m_name"].ToString(), Convert.ToDouble(sdr["sumtime"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาลงทะเบียนที่ห้องบัตร", Convert.ToDouble(sdr["t_card"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาการคัดกรอง", Convert.ToDouble(sdr["t_screen"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารอพบแพทย์", Convert.ToDouble(sdr["t_waitdoc"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาในห้องตรวจแพทย์", Convert.ToDouble(sdr["t_roomdoc"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาหลังพบแพทย์จนถึงยื่นใบสั่งยา", Convert.ToDouble(sdr["t_prescription"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารอรับยา", Convert.ToDouble(sdr["t_waitmed"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารับยาเดิม", Convert.ToDouble(sdr["t_med"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลารอรับยาเดิม", Convert.ToDouble(sdr["t_oldmed"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลากรณีได้รับ intervention อื่นๆ (บำบัดรักษา ฟื้นฟูทางจิต สังคม)", Convert.ToDouble(sdr["t_inter"])));
        //        //dataPoints.Add(new DataPoint("ระยะเวลาในการจัดทำ/บริการเพื่อรับไว้รักษา (Admit)", Convert.ToDouble(sdr["t_prepare_admit"])));

        //    }
        //    sqlconn.Close();
        //    ViewData["Year2"] = dataPoints;
        //    //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
        //}

        [HttpPost]
        public IActionResult Report1(int t_year, int t_year2, string point)
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            int hcode = (int)HttpContext.Session.GetInt32("hospcode");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["hosp"] = hosp();
            ViewData["cmonth"] = cmonth();
            int y = Years.Years();

            if (t_year == 0 && t_year2 == 0 && point == "0")
            {
                ChartReport1(y - 1, y, "0", hcode);
                ChartReport1_old(y - 1, y, "0", hcode);
                ViewData["Y1"] = y - 1;
                ViewData["Y2"] = y;
            }
            else if (t_year == 0 && t_year2 == 0 && point != "0")
            {
                ChartReport1(y - 1, y, point, hcode);
                ChartReport1_old(y - 1, y, point, hcode);
                ViewData["Y1"] = y - 1;
                ViewData["Y2"] = y;
            }
            else /*if(t_year != 0 && t_hosp == 0)*/
            {
                ChartReport1(t_year, t_year2, point, hcode);
                ChartReport1_old(t_year, t_year2, point, hcode);
                ViewData["Y1"] = t_year;
                ViewData["Y2"] = t_year2;
            }

            ViewData["Date2"] = y;
            ViewData["Date1"] = y - 1;

            ViewData["Showhosp"] = chartYear.point(point.ToString());

            return View();

        }

        public IActionResult Report2()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                int hcode = (int)HttpContext.Session.GetInt32("hospcode");
                ViewData["hospcode"] = HttpContext.Session.GetInt32("hospcode");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                ViewData["hosp"] = hosp();
                ViewData["cmonth"] = cmonth();
                int y = Years.Years();

                ViewData["Sumyear"] = sumyear(hcode);
                ViewData["Sumyear_old"] = sumyear_old(hcode);
                ViewData["hospnames"] = chartYear.hosp("0");

                ViewData["Date2"] = y;
                ViewData["Date1"] = y - 1;

                ViewData["Y1"] = y - 1; ;
                ViewData["Y2"] = y;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Report2(int t_hosp)
        {
            //if (HttpContext.Session.GetString("hospcode") != null)
            //{
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            int hcode = (int)HttpContext.Session.GetInt32("hospcode");
            ViewData["hospcode"] = HttpContext.Session.GetInt32("hospcode");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["hosp"] = hosp();
            ViewData["cmonth"] = cmonth();
            int y = Years.Years();

            ViewData["Sumyear"] = sumyear(t_hosp);
            ViewData["Sumyear_old"] = sumyear_old(t_hosp);

            ViewData["Date2"] = y;
            ViewData["Date1"] = y - 1;

            ViewData["hospnames"] = chartYear.hosp(t_hosp.ToString());
            //ViewData["Y1"] = t_year;
            // ViewData["Y2"] = t_year2;
            return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        public List<SumYearModel> sumyear(int t_hosp)
        {
            List<SumYearModel> sums = new List<SumYearModel>();
            string sql = @"SELECT t_year,ROUND(SUM(t_card + t_screen + t_waitdoc + t_roomdoc + t_prescription + 
                            t_waitmed + t_med + t_oldmed + t_inter + t_prepare_admit)/COUNT(t_id) , 2)  AS sumtime1
                            FROM timeWaitting  WHERE t_hcode<>99999 AND type = 2 ";
            if (t_hosp == 99999)
            {
                sql += " GROUP BY t_year";
            }
            else
            {
                sql += " AND t_hcode =" + t_hosp + " GROUP BY t_year";
            }
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();

            while (sdr.Read())
            {
                SumYearModel sum = new SumYearModel();
                sum.years = sdr["t_year"].ToString();
                sum.y1 = Convert.ToDouble(sdr["sumtime1"]);

                sums.Add(sum);
            }
            sqlconn.Close();
            return sums;
        }
        public List<SumYearModel> sumyear_old(int t_hosp)
        {
            List<SumYearModel> sums = new List<SumYearModel>();
            string sql = @"SELECT t_year,ROUND(SUM(t_card + t_screen + t_waitdoc + t_roomdoc + t_prescription + 
                            t_waitmed + t_med + t_oldmed + t_inter + t_prepare_admit)/COUNT(t_id) , 2)  AS sumtime1
                            FROM timeWaitting  WHERE t_hcode<>99999 AND type = 1 ";
            if (t_hosp == 99999)
            {
                sql += " GROUP BY t_year";
            }
            else
            {
                sql += " AND t_hcode =" + t_hosp + " GROUP BY t_year";
            }
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();

            while (sdr.Read())
            {
                SumYearModel sum = new SumYearModel();
                sum.years = sdr["t_year"].ToString();
                sum.y1 = Convert.ToDouble(sdr["sumtime1"]);

                sums.Add(sum);
            }
            sqlconn.Close();
            return sums;
        }

        public IActionResult Report3()
        {

            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                int hcode = (int)HttpContext.Session.GetInt32("hospcode");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                ViewData["hosp"] = hosp();
                ViewData["cmonth"] = cmonth();
                int y = Years.Years();

                ViewData["Date2"] = y;
                ViewData["Date1"] = y - 1;

                ViewData["Y1"] = "ทั้งหมด";

                ViewData["Sumpoint"] = SumPoint(y, hcode);
                ViewData["Sumpoint_old"] = SumPoint_old(y, hcode);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Report3(int t_year)
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            int hcode = (int)HttpContext.Session.GetInt32("hospcode");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["hosp"] = hosp();
            ViewData["cmonth"] = cmonth();
            int y = Years.Years();

            ViewData["Date2"] = y;
            ViewData["Date1"] = y - 1;

            ViewData["Y1"] = t_year;
            if (t_year == 0)
            {
                ViewData["Sumpoint"] = SumPoint(y, hcode);
                ViewData["Sumpoint_old"] = SumPoint_old(y, hcode);
                ViewData["Y1"] = y;
            }
            else
            {
                ViewData["Sumpoint"] = SumPoint(t_year, hcode);
                ViewData["Sumpoint_old"] = SumPoint_old(t_year, hcode);
                ViewData["Y1"] = t_year;
            }

            return View();
        }

        public List<DataPoint> SumPoint(int t_year, int hcode)
        {
            string sql = @"SELECT
                             ISNULL(ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2),0) AS t_card , 
                             ISNULL(ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2),0) AS t_screen , 
                             ISNULL(ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2),0) AS t_waitdoc , 
                             ISNULL(ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2),0) AS t_roomdoc , 
                             ISNULL(ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2),0) AS t_prescription ,
                             ISNULL(ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2),0) AS t_waitmed , 
                             ISNULL(ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2),0) AS t_med , 
                             ISNULL(ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2),0) AS t_oldmed, 
                             ISNULL(ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2),0) AS t_inter , 
                             ISNULL(ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2),0) AS t_prepare_admit
                            FROM timeWaitting  WHERE t_year = '" + t_year + "' ";
            if (hcode == 99999)
            {
                sql += " AND type = 1";
            }
            else
            {
                sql += "AND t_hcode =" + hcode + " AND type = 2";
            }

            List<DataPoint> dataPoints = new List<DataPoint>();
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;
            SqlDataReader sdr = sqlcomm.ExecuteReader();

            while (sdr.Read())
            {
                dataPoints.Add(new DataPoint("ระยะเวลาลงทะเบียนที่ห้องบัตร", Convert.ToDouble(sdr["t_card"])));
                dataPoints.Add(new DataPoint("ระยะเวลาการคัดกรอง", Convert.ToDouble(sdr["t_screen"])));
                dataPoints.Add(new DataPoint("ระยะเวลารอพบแพทย์", Convert.ToDouble(sdr["t_waitdoc"])));
                dataPoints.Add(new DataPoint("ระยะเวลาในห้องตรวจแพทย์", Convert.ToDouble(sdr["t_roomdoc"])));
                dataPoints.Add(new DataPoint("ระยะเวลาหลังพบแพทย์", Convert.ToDouble(sdr["t_prescription"])));
                dataPoints.Add(new DataPoint("ระยะเวลารอการชำระเงิน", Convert.ToDouble(sdr["t_waitmed"])));
                dataPoints.Add(new DataPoint("ระยะเวลารับยา", Convert.ToDouble(sdr["t_med"])));
                dataPoints.Add(new DataPoint("ระยะเวลารอรับยาเดิม", Convert.ToDouble(sdr["t_oldmed"])));
                dataPoints.Add(new DataPoint("ระยะเวลากรณีได้รับ intervention อื่นๆ", Convert.ToDouble(sdr["t_inter"])));
                dataPoints.Add(new DataPoint("ระยะเวลาในการจัดทำบริการเพื่อรับไว้รักษา (Admit)", Convert.ToDouble(sdr["t_prepare_admit"])));
            }
            sqlconn.Close();
            return dataPoints;
        }
        public List<DataPoint> SumPoint_old(int t_year, int hcode)
        {
            string sql = @"SELECT
                             ISNULL(ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2),0) AS t_card , 
                             ISNULL(ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2),0) AS t_screen , 
                             ISNULL(ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2),0) AS t_waitdoc , 
                             ISNULL(ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2),0) AS t_roomdoc , 
                             ISNULL(ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2),0) AS t_prescription ,
                             ISNULL(ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2),0) AS t_waitmed , 
                             ISNULL(ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2),0) AS t_med , 
                             ISNULL(ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2),0) AS t_oldmed, 
                             ISNULL(ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2),0) AS t_inter , 
                             ISNULL(ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2),0) AS t_prepare_admit
                            FROM timeWaitting  WHERE t_year = '" + t_year + "' ";
            if (hcode == 99999)
            {
                sql += " AND type = 2";
            }
            else
            {
                sql += "AND t_hcode =" + hcode + " AND type = 1";
            }

            List<DataPoint> dataPoints = new List<DataPoint>();
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;
            SqlDataReader sdr = sqlcomm.ExecuteReader();

            while (sdr.Read())
            {
                dataPoints.Add(new DataPoint("ระยะเวลาลงทะเบียนที่ห้องบัตร", Convert.ToDouble(sdr["t_card"])));
                dataPoints.Add(new DataPoint("ระยะเวลาการคัดกรอง", Convert.ToDouble(sdr["t_screen"])));
                dataPoints.Add(new DataPoint("ระยะเวลารอพบแพทย์", Convert.ToDouble(sdr["t_waitdoc"])));
                dataPoints.Add(new DataPoint("ระยะเวลาในห้องตรวจแพทย์", Convert.ToDouble(sdr["t_roomdoc"])));
                dataPoints.Add(new DataPoint("ระยะเวลาหลังพบแพทย์", Convert.ToDouble(sdr["t_prescription"])));
                dataPoints.Add(new DataPoint("ระยะเวลารอการชำระเงิน", Convert.ToDouble(sdr["t_waitmed"])));
                dataPoints.Add(new DataPoint("ระยะเวลารับยา", Convert.ToDouble(sdr["t_med"])));
                dataPoints.Add(new DataPoint("ระยะเวลารอรับยาเดิม", Convert.ToDouble(sdr["t_oldmed"])));
                dataPoints.Add(new DataPoint("ระยะเวลากรณีได้รับ intervention อื่นๆ", Convert.ToDouble(sdr["t_inter"])));
                dataPoints.Add(new DataPoint("ระยะเวลาในการจัดทำบริการเพื่อรับไว้รักษา (Admit)", Convert.ToDouble(sdr["t_prepare_admit"])));
            }
            sqlconn.Close();
            return dataPoints;
        }

        public IActionResult Report4()
        {

            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                int hcode = (int)HttpContext.Session.GetInt32("hospcode");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                ViewData["hosp"] = hosp();
                ViewData["cmonth"] = cmonth();
                int y = Years.Years();

                ViewData["Date2"] = y;
                ViewData["Date1"] = y - 1;

                ViewData["Y1"] = "ทั้งหมด";

                Datapoint(0, "0", hcode);
                Datapoint_old(0, "0", hcode);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Report4(int t_year, string point)
        {

            //if (HttpContext.Session.GetString("hospcode") != null)
            //{
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            int hcode = (int)HttpContext.Session.GetInt32("hospcode");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["hosp"] = hosp();
            ViewData["cmonth"] = cmonth();
            int y = Years.Years();

            ViewData["Date2"] = y;
            ViewData["Date1"] = y - 1;


            //ViewData["Y2"] = y;
            if (t_year == 0)
            {
                ViewData["Y1"] = "ทั้งหมด";
            }
            else
            {
                ViewData["Y1"] = t_year;
            }
            Datapoint(t_year, point, hcode);
            Datapoint_old(t_year, point, hcode);
            return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }
        public void Datapoint(int t_year, string point, int hcode)
        {
            function subsql = new function();
            string sub = subsql.subsql(point);

            string orderby = "ORDER BY CASE c.m_name " +
                                                  " WHEN  'ตุลาคม' THEN 1 " +
                                                   " WHEN 'พฤศจิกายน' THEN 2 " +
                                                   " WHEN 'ธันวาคม' THEN 3 " +
                                                   " WHEN 'มกราคม' THEN 4 " +
                                                   " WHEN 'กุมภาพันธ์' THEN 5 " +
                                                   " WHEN 'มีนาคม' THEN 6 " +
                                                   " WHEN 'เมษายน' THEN 7 " +
                                                   " WHEN 'พฤษภาคม' THEN 8 " +
                                                   " WHEN 'มิถุนายน' THEN 9 " +
                                                   " WHEN 'กรกฎาคม' THEN 10 " +
                                                   " WHEN 'สิงหาคม' THEN 11 " +
                                                   " WHEN 'กันยายน' THEN 12 " +
                                                   " END";

            string sql = @"SELECT c.m_name, " + sub + " AS sumtime FROM timeWaitting INNER JOIN cmonth c on c.m_id = t_month ";
            if (hcode == 99999)
            {
                if (t_year == 0)
                {
                    sql += "WHERE type = 2 GROUP BY c.m_name " + orderby;
                }
                else if (t_year != 0)
                {
                    sql += "WHERE type = 2 AND t_year = '" + t_year + "' GROUP BY c.m_name " + orderby;
                }
            }
            else
            {
                if (t_year == 0)
                {
                    sql += "WHERE type = 2 AND t_hcode = " + hcode + " GROUP BY c.m_name " + orderby;
                }
                else if (t_year != 0)
                {
                    sql += "WHERE type = 2 AND t_year = '" + t_year + "' AND t_hcode = " + hcode + " GROUP BY c.m_name " + orderby;
                }
            }


            List<SumYearModel> datas = new List<SumYearModel>();

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                SumYearModel sum = new SumYearModel();
                sum.hospname = sdr["m_name"].ToString();
                sum.y1 = Convert.ToDouble(sdr["sumtime"]);

                datas.Add(sum);
                // datas.Add(new DataPoint(sdr["m_name"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewData["Datapoint"] = datas;
            // ViewBag.DataPoints1 = JsonConvert.SerializeObject(datas);
        }
        public void Datapoint_old(int t_year, string point, int hcode)
        {
            function subsql = new function();
            string sub = subsql.subsql(point);

            string orderby = "ORDER BY CASE c.m_name " +
                                                  " WHEN  'ตุลาคม' THEN 1 " +
                                                   " WHEN 'พฤศจิกายน' THEN 2 " +
                                                   " WHEN 'ธันวาคม' THEN 3 " +
                                                   " WHEN 'มกราคม' THEN 4 " +
                                                   " WHEN 'กุมภาพันธ์' THEN 5 " +
                                                   " WHEN 'มีนาคม' THEN 6 " +
                                                   " WHEN 'เมษายน' THEN 7 " +
                                                   " WHEN 'พฤษภาคม' THEN 8 " +
                                                   " WHEN 'มิถุนายน' THEN 9 " +
                                                   " WHEN 'กรกฎาคม' THEN 10 " +
                                                   " WHEN 'สิงหาคม' THEN 11 " +
                                                   " WHEN 'กันยายน' THEN 12 " +
                                                   " END";

            string sql = @"SELECT c.m_name, " + sub + " AS sumtime FROM timeWaitting INNER JOIN cmonth c on c.m_id = t_month ";
            if (hcode == 99999)
            {
                if (t_year == 0)
                {
                    sql += "WHERE type = 1 GROUP BY c.m_name " + orderby;
                }
                else if (t_year != 0)
                {
                    sql += "WHERE type = 1 AND t_year = '" + t_year + "' GROUP BY c.m_name " + orderby;
                }
            }
            else
            {
                if (t_year == 0)
                {
                    sql += "WHERE type = 1 AND t_hcode = " + hcode + " GROUP BY c.m_name " + orderby;
                }
                else if (t_year != 0)
                {
                    sql += "WHERE type = 1 AND t_year = '" + t_year + "' AND t_hcode = " + hcode + " GROUP BY c.m_name " + orderby;
                }
            }


            List<SumYearModel> datas = new List<SumYearModel>();

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                SumYearModel sum = new SumYearModel();
                sum.hospname = sdr["m_name"].ToString();
                sum.y1 = Convert.ToDouble(sdr["sumtime"]);

                datas.Add(sum);
                // datas.Add(new DataPoint(sdr["m_name"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewData["Datapoint_old"] = datas;
            // ViewBag.DataPoints1 = JsonConvert.SerializeObject(datas);
        }

    }
}


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
    public class HomeController : Controller
    {
        SqlConnection sqlconn = new DBClass().SqlStrCon();
        Datetime Years = new Datetime();
        public IActionResult Index()
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["hosp"] = hosp();
            ViewData["cmonth"] = cmonth();
            ViewData["Sumpatien"] = Sumpatien(0, 0);
            Datapoint(0, 0, "0");
            Datapoint_old(0, 0, "0");

            int y = Years.Years();
            Chart2(y - 1);
            Chart_year(y);
            Chart_old1(y - 1);
            Chart_old2(y);

            ChartDept(0, 0, "0");
            ChartDept_new(0, 0, "0");

            ChartDept2(0, 0, "0");
            ChartDept2_new(0, 0, "0");

            ViewData["Date2"] = y;
            ViewData["Date1"] = y - 1;
            ViewData["Y"] = y;
            return View();
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

        public List<SumpatienModel> Sumpatien(int t_year, int t_month)
        {
            string sql = @"SELECT SUM(t_newpatien) AS t_newpatien ,SUM(t_oldpatien) AS t_oldpatien 
                        , SUM(t_admit) AS t_admit, ROUND(SUM(t_card + t_screen + t_waitdoc + t_roomdoc + t_prescription +
                         t_waitmed + t_med + t_oldmed + t_prepare_admit) / COUNT(t_id), 2) AS sumtime
                        FROM timeWaitting WHERE t_hcode <> 0 ";
            if (t_year == 0 && t_month == 0)
            {
                sql += "";
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "AND t_year = '" + t_year + "' AND t_month = '" + t_month + "'";
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "AND t_year = '" + t_year + "'";
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "AND t_month = '" + t_month + "'";
            }

            List<SumpatienModel> sums = new List<SumpatienModel>();
            //string sql = "select * from cmonth ";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                SumpatienModel sum = new SumpatienModel();
                if (!sdr.IsDBNull((int)sum.t_newpatien))
                {
                    sum.t_newpatien = Convert.ToInt32(sdr["t_newpatien"]);
                    sum.t_oldpatien = Convert.ToInt32(sdr["t_oldpatien"]);
                    sum.t_admit = Convert.ToInt32(sdr["t_admit"]);
                    sum.sumtime = Convert.ToInt32(sdr["sumtime"]);
                }

                sums.Add(sum);
            }
            //ViewBag.OffList = off;
            sqlconn.Close();
            return sums;
        }

        //public List<SumpatienModel> Sumpatien()
        //{
        //    List<SumpatienModel> model = null;
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44305/api/");
        //    var task = client.GetAsync("Sumpatien")
        //      .ContinueWith((taskwithresponse) =>
        //      {
        //          var response = taskwithresponse.Result;
        //          var jsonString = response.Content.ReadAsStringAsync();
        //          jsonString.Wait();
        //          model = JsonConvert.DeserializeObject<List<SumpatienModel>>(jsonString.Result);

        //      });
        //    task.Wait();
        //    return model.ToList();
        //}

        public void Datapoint(int t_year, int t_month, string point)
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

            if (t_year == 0 && t_month == 0)
            {
                sql += "WHERE type = 2 GROUP BY c.m_name " + orderby;
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "WHERE type = 2 AND t_year = '" + t_year + "' AND t_month = '" + t_month + "' GROUP BY c.m_name " + orderby;
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "WHERE type = 2 AND t_year = '" + t_year + "' GROUP BY c.m_name " + orderby;
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "WHERE type = 2 AND t_month = '" + t_month + "' GROUP BY c.m_name " + orderby;
            }
            List<DataPoint> datas = new List<DataPoint>();

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                datas.Add(new DataPoint(sdr["m_name"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(datas);
        }
        public void Datapoint_old(int t_year, int t_month, string point)
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

            if (t_year == 0 && t_month == 0)
            {
                sql += "WHERE type = 1 GROUP BY c.m_name " + orderby;
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "WHERE type = 1 AND t_year = '" + t_year + "' AND t_month = '" + t_month + "' GROUP BY c.m_name " + orderby;
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "WHERE type = 1 AND t_year = '" + t_year + "' GROUP BY c.m_name " + orderby;
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "WHERE type = 1 AND t_month = '" + t_month + "' GROUP BY c.m_name " + orderby;
            }
            List<DataPoint> datas = new List<DataPoint>();

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                datas.Add(new DataPoint(sdr["m_name"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(datas);
        }
        public void Chart2(int date1)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            string sql = @"SELECT
                             ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2) AS t_card , 
                             ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2) AS t_screen , 
                             ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2) AS t_waitdoc , 
                             ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2) AS t_roomdoc , 
                             ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2) AS t_prescription ,
                             ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2) AS t_waitmed , 
                             ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2) AS t_med , 
                             ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2) AS t_oldmed, 
                             ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2) AS t_inter,
                             ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2) AS t_prepare_admit
                            FROM timeWaitting WHERE t_year = '" + date1 + "' AND type = 2  GROUP BY t_year";

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
            ViewBag.DataPointsYear1 = JsonConvert.SerializeObject(dataPoints);
        }//ผู้ป่วยใหม่
        public void Chart_year(int date2)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            string sql = @"SELECT
                             ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2) AS t_card , 
                             ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2) AS t_screen , 
                             ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2) AS t_waitdoc , 
                             ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2) AS t_roomdoc , 
                             ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2) AS t_prescription ,
                             ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2) AS t_waitmed , 
                             ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2) AS t_med , 
                             ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2) AS t_oldmed, 
                             ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2) AS t_inter,
                             ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2) AS t_prepare_admit
                            FROM timeWaitting WHERE t_year = '" + date2 + "' AND type = 2  GROUP BY t_year";

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
            ViewBag.DataPointsYear2 = JsonConvert.SerializeObject(dataPoints);
        }//ผู้ป่วยใหม่
        public void Chart_old1(int date1)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            string sql = @"SELECT
                             ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2) AS t_card , 
                             ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2) AS t_screen , 
                             ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2) AS t_waitdoc , 
                             ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2) AS t_roomdoc , 
                             ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2) AS t_prescription ,
                             ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2) AS t_waitmed , 
                             ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2) AS t_med , 
                             ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2) AS t_oldmed, 
                             ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2) AS t_inter,
                             ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2) AS t_prepare_admit
                            FROM timeWaitting WHERE t_year = '" + date1 + "' AND type = 1  GROUP BY t_year";

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
            ViewBag.DataPointsYear3 = JsonConvert.SerializeObject(dataPoints);
        }//ผู้ป่วยเก่า
        public void Chart_old2(int date2)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            string sql = @"SELECT
                             ROUND(ROUND(SUM(t_card), 2)/COUNT(t_id),2) AS t_card , 
                             ROUND(ROUND(SUM(t_screen), 2)/COUNT(t_id),2) AS t_screen , 
                             ROUND(ROUND(SUM(t_waitdoc), 2)/COUNT(t_id),2) AS t_waitdoc , 
                             ROUND(ROUND(SUM(t_roomdoc), 2)/COUNT(t_id),2) AS t_roomdoc , 
                             ROUND(ROUND(SUM(t_prescription), 2)/COUNT(t_id),2) AS t_prescription ,
                             ROUND(ROUND(SUM(t_waitmed), 2)/COUNT(t_id),2) AS t_waitmed , 
                             ROUND(ROUND(SUM(t_med), 2)/COUNT(t_id),2) AS t_med , 
                             ROUND(ROUND(SUM(t_oldmed), 2)/COUNT(t_id),2) AS t_oldmed, 
                             ROUND(ROUND(SUM(t_inter), 2)/COUNT(t_id),2) AS t_inter,
                             ROUND(ROUND(SUM(t_prepare_admit), 2)/COUNT(t_id),2) AS t_prepare_admit
                            FROM timeWaitting WHERE t_year = '" + date2 + "' AND type = 1  GROUP BY t_year";

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
            ViewBag.DataPointsYear4 = JsonConvert.SerializeObject(dataPoints);
        }//ผู้ป่วยเก่า

        public void ChartDept(int t_year, int t_month, string point)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            function subsql = new function();
            string sub = subsql.subsql(point);

            string sql = @"SELECT hosp.hospname," + sub + " AS sumtime " +
                            "FROM timeWaitting " +
                            "INNER JOIN hosp  on hosp.hospcode = t_hcode ";

            if (t_year == 0 && t_month == 0)
            {
                sql += "WHERE hosp.status = 1 AND type = 2 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND t_month = '" + t_month + "' AND hosp.status = 1 AND type = 2 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND hosp.status = 1 AND type = 2 GROUP BY hosp.hospname";
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "WHERE t_month = '" + t_month + "' AND hosp.status = 1 AND type = 2 GROUP BY hosp.hospname";
            }

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                dataPoints.Add(new DataPoint(sdr["hospname"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewBag.DataPointsDept_new1 = JsonConvert.SerializeObject(dataPoints);
        } //ผู้ป่วยใหม่
        public void ChartDept_new(int t_year, int t_month, string point)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            function subsql = new function();
            string sub = subsql.subsql(point);

            string sql = @"SELECT hosp.hospname," + sub + " AS sumtime " +
                            "FROM timeWaitting " +
                            "INNER JOIN hosp  on hosp.hospcode = t_hcode ";

            if (t_year == 0 && t_month == 0)
            {
                sql += "WHERE hosp.status = 1 AND type = 1 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND t_month = '" + t_month + "' AND hosp.status = 1 AND type = 1 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND hosp.status = 1 AND type = 1 GROUP BY hosp.hospname";
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "WHERE t_month = '" + t_month + "' AND hosp.status = 1 AND type = 1 GROUP BY hosp.hospname";
            }

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                dataPoints.Add(new DataPoint(sdr["hospname"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewBag.DataPointsDept_new2 = JsonConvert.SerializeObject(dataPoints);
        } //ผู้ป่วยเก่า
        public void ChartDept2(int t_year, int t_month, string point)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            function subsql = new function();
            string sub = subsql.subsql(point);

            string sql = @"SELECT hosp.hospname," + sub + " AS sumtime " +
                           "FROM timeWaitting " +
                           "INNER JOIN hosp  on hosp.hospcode = t_hcode ";

            if (t_year == 0 && t_month == 0)
            {
                sql += "WHERE hosp.status = 2 AND type = 2 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND t_month = '" + t_month + "' AND hosp.status = 2 AND type = 2 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND hosp.status = 2 AND type = 2 GROUP BY hosp.hospname";
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "WHERE t_month = '" + t_month + "' AND hosp.status = 2 AND type = 2 GROUP BY hosp.hospname";
            }

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                dataPoints.Add(new DataPoint(sdr["hospname"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewBag.DataPointsDept2_new1 = JsonConvert.SerializeObject(dataPoints);
        } //ผู้ป่วยใหม่
        public void ChartDept2_new(int t_year, int t_month, string point)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            function subsql = new function();
            string sub = subsql.subsql(point);

            string sql = @"SELECT hosp.hospname," + sub + " AS sumtime " +
                           "FROM timeWaitting " +
                           "INNER JOIN hosp  on hosp.hospcode = t_hcode ";

            if (t_year == 0 && t_month == 0)
            {
                sql += "WHERE hosp.status = 2 AND type = 1 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month != 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND t_month = '" + t_month + "' AND hosp.status = 2 AND type = 1 GROUP BY hosp.hospname";
            }
            else if (t_year != 0 && t_month == 0)
            {
                sql += "WHERE t_year = '" + t_year + "' AND hosp.status = 2 AND type = 1 GROUP BY hosp.hospname";
            }
            else if (t_year == 0 && t_month != 0)
            {
                sql += "WHERE t_month = '" + t_month + "' AND hosp.status = 2 AND type = 1 GROUP BY hosp.hospname";
            }

            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                dataPoints.Add(new DataPoint(sdr["hospname"].ToString(), Convert.ToDouble(sdr["sumtime"])));
            }
            sqlconn.Close();
            ViewBag.DataPointsDept2_new2 = JsonConvert.SerializeObject(dataPoints);
        } //ผู้ป่วยเก่า

        [HttpPost]
        public IActionResult Index(int t_year, int t_month, string point)
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["hosp"] = hosp();
            ViewData["cmonth"] = cmonth();
            ViewData["Sumpatien"] = Sumpatien(t_year, t_month);
            Datapoint(t_year, t_month, point);
            Datapoint_old(t_year, t_month, point);

            int y = Years.Years();
            if (t_year == 0)
            {
                Chart2(y - 1);
                Chart_year(y);
                Chart_old1(y - 1);
                Chart_old2(y);
                ViewData["Date2"] = y;
                ViewData["Date1"] = y - 1;
            }
            else
            {
                Chart2(t_year - 1);
                Chart_year(t_year);
                Chart_old1(t_year - 1);
                Chart_old2(t_year);
                ViewData["Date2"] = t_year;
                ViewData["Date1"] = t_year - 1;
            }

            ChartDept(t_year, t_month, point);
            ChartDept_new(t_year, t_month, point);

            ChartDept2(t_year, t_month, point);
            ChartDept2_new(t_year, t_month, point);

            ViewData["Y"] = y;

            return View();
        }

    }
}

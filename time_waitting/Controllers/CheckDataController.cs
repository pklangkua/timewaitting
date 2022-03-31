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
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace time_waitting.Controllers
{
    public class CheckDataController : Controller
    {
        SqlConnection sqlconn = new DBClass().SqlStrCon();
        Datetime date = new Datetime();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                int chk = date.Years();
                ViewData["Date2"] = chk;

                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["Datachk"] = Data(chk);

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public IActionResult Index(int years)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                int chk = date.Years();
                ViewData["Date2"] = chk;

                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["Datachk"] = Data(years);

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public List<CheckdataModel> Data(int year)
        {
            List<CheckdataModel> chks = new List<CheckdataModel>();
            string sql = @"SELECT c.m_name," +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 11597 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h1'," +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12244 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h2'," +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12246 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h3', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12251 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h4', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12260 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h5', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12268 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h6', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12269 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h7', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12272 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h8', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12277 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h9', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12280 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h10', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12289 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h11', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 12290 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h12', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 13775 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h13', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 14171 AND t2.t_year ='" + year + "' " +
                               " ),0)AS 'h14', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 14644 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h15', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 14717 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h16', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 14955 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h17'," +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 24746 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h18', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 40915 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h19', " +
                               " ISNULL((SELECT DISTINCT COUNT(t2.t_month) FROM timeWaitting t2 " +
                               " WHERE t2.t_month = t.t_month AND t2.t_hcode = 41429 AND t2.t_year ='" + year + "' " +
                               "  ),0)AS 'h20' " +
                               " FROM timeWaitting t INNER JOIN cmonth c on c.m_id = t.t_month " +
                               " WHERE t.t_year ='" + year + "' " +
                               " GROUP BY c.m_name ,t.t_month " +
                               " ORDER BY CASE c.m_name WHEN  'ตุลาคม' THEN 1  WHEN 'พฤศจิกายน' THEN 2 " +
                               " WHEN 'ธันวาคม' THEN 3  WHEN 'มกราคม' THEN 4  WHEN 'กุมภาพันธ์' THEN 5 " +
                               " WHEN 'มีนาคม' THEN 6  WHEN 'เมษายน' THEN 7  WHEN 'พฤษภาคม' THEN 8 " +
                               " WHEN 'มิถุนายน' THEN 9  WHEN 'กรกฎาคม' THEN 10  WHEN 'สิงหาคม' THEN 11 " +
                               " WHEN 'กันยายน' THEN 12  END";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                CheckdataModel chk = new CheckdataModel();

                chk.month = sdr["m_name"].ToString();
                chk.h1 = Convert.ToInt32(sdr["h1"]);
                chk.h2 = Convert.ToInt32(sdr["h2"]);
                chk.h3 = Convert.ToInt32(sdr["h3"]);
                chk.h4 = Convert.ToInt32(sdr["h4"]);
                chk.h5 = Convert.ToInt32(sdr["h5"]);
                chk.h6 = Convert.ToInt32(sdr["h6"]);
                chk.h7 = Convert.ToInt32(sdr["h7"]);
                chk.h8 = Convert.ToInt32(sdr["h8"]);
                chk.h9 = Convert.ToInt32(sdr["h9"]);
                chk.h10 = Convert.ToInt32(sdr["h10"]);
                chk.h11 = Convert.ToInt32(sdr["h11"]);
                chk.h12 = Convert.ToInt32(sdr["h12"]);
                chk.h13 = Convert.ToInt32(sdr["h13"]);
                chk.h14 = Convert.ToInt32(sdr["h14"]);
                chk.h15 = Convert.ToInt32(sdr["h15"]);
                chk.h16 = Convert.ToInt32(sdr["h16"]);
                chk.h17 = Convert.ToInt32(sdr["h17"]);
                chk.h18 = Convert.ToInt32(sdr["h18"]);
                chk.h19 = Convert.ToInt32(sdr["h19"]);
                chk.h20 = Convert.ToInt32(sdr["h20"]);


                chks.Add(chk);
            }
            sqlconn.Close();
            return chks;
        }
    }
}

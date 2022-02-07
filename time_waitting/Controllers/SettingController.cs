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
    public class SettingController : Controller
    {
        SqlConnection sqlconn = new DBClass().SqlStrCon();
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewBag.Page = "Data";
                ViewData["Setdate"] = Setdate();

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public List<SettingModel> Setdate()
        {
            List<SettingModel> dates = new List<SettingModel>();
            string sql = "select * from Setting ";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                SettingModel date = new SettingModel();

                date.id = Convert.ToInt32(sdr["id"]);
                date.names = sdr["name"].ToString();
                date.setdate = sdr["set"].ToString();

                dates.Add(date);
            }

            sqlconn.Close();
            return dates;
        }
        [HttpPost]
        public IActionResult Index(SettingModel sd)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                sqlconn.Open();
                string sql = @"UPDATE Setting SET [set]=@set  WHERE id = @id";
                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

                sqlcomm.Parameters.AddWithValue("@id", sd.id);
                sqlcomm.Parameters.AddWithValue("@set", sd.setdate);

                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();

                return RedirectToAction("Index", "Setting");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}

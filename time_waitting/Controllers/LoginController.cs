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

namespace time_waitting.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection sqlconn = new DBClass().SqlStrCon();
        SqlConnection sqlconn2 = new DBClass().SqlStrCon();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(hcodeModel obj)
        {
            if (ModelState.IsValid)
            {
                sqlconn.Open();
                string sql = @"select h.hospcode,ho.hospname,h.huser,h.status,h.fname,h.lname,h.hid from hcode h 
                                INNER JOIN hosp ho on ho.hospcode = h.hospcode WHERE huser = @UserName and 
                                hpass =CONVERT(VARCHAR(32), HashBytes('MD5',@Password), 2) ";

                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

                sqlcomm.Parameters.AddWithValue("@UserName", obj.huser.ToString());
                sqlcomm.Parameters.AddWithValue("@Password", obj.hpass.ToString());
                SqlDataReader sdr = sqlcomm.ExecuteReader();

                if (sdr.Read())
                {
                    HttpContext.Session.SetInt32("hospcode", sdr.GetInt32(0));
                    HttpContext.Session.SetString("hospname", sdr.GetString(1));
                    HttpContext.Session.SetString("huser", sdr.GetString(2));
                    HttpContext.Session.SetInt32("status", sdr.GetInt32(3));
                    HttpContext.Session.SetString("fname", sdr.GetString(4));
                    HttpContext.Session.SetString("lname", sdr.GetString(5));
                    HttpContext.Session.SetInt32("hid", sdr.GetInt32(6));

                    //HttpContext.Session.SetString("Username", obj.UserName);
                    /*ViewData["hospcode"] = HttpContext.Session.GetString("hospcode");
                    ViewData["hospname"] = HttpContext.Session.GetString("hospname");*/
                    // ViewData["chiefoff"] = HttpContext.Session.GetString("chiefoff");

                    sqlconn.Close();
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "goBackJS", " window.history.back();", true);
                    return RedirectToAction("Index", "Home");
                    // return Redirect(Request.Headers["Referer"].ToString());
                }
                else
                {
                    ViewData["ErrorLogin"] = "ไม่สามารถเข้าสู่ระบบได้ กรุณาตรวจสอบ Username และ Password";
                }

            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult showUser()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewBag.Page = "Data";
                ViewData["DisplayUser"] = DisplayUser();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public List<hcodeModel> DisplayUser()
        {
            List<hcodeModel> hcodes = new List<hcodeModel>();
            string sql = @"select h.hid,h.hospcode,ho.hospname,h.huser,h.status,h.fname,h.lname,r.name from hcode h 
                                INNER JOIN hosp ho on ho.hospcode = h.hospcode INNER JOIN [right] r on r.id = h.status ";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                hcodeModel hcode = new hcodeModel();

                hcode.hid = Convert.ToInt32(sdr["hid"]);
                hcode.hospcode = Convert.ToInt32(sdr["hospcode"]);
                hcode.hospname = sdr["hospname"].ToString();
                hcode.huser = sdr["huser"].ToString();
                hcode.status = Convert.ToInt32(sdr["status"]);
                hcode.fname = sdr["fname"].ToString();
                hcode.lname = sdr["lname"].ToString();
                hcode.name = sdr["name"].ToString();

                hcodes.Add(hcode);
            }
            sqlconn.Close();
            return hcodes;
        }
        [HttpPost]
        public IActionResult DeleteUser(string idDelete)
        {
            sqlconn.Open();
            string sql = @"delete from hcode WHERE  huser =@UserId ";
            SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

            sqlcomm.Parameters.AddWithValue("@UserId", idDelete);

            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            return RedirectToAction("showUser");
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["right"] = right();
                ViewData["hosp"] = hosp();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public List<rightModel> right()
        {
            List<rightModel> rights = new List<rightModel>();
            string sql = @"select * from [right]";
            SqlCommand sqlcomm = new SqlCommand(sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                rightModel right = new rightModel();

                right.id = Convert.ToInt32(sdr["id"]);
                right.name = sdr["name"].ToString();
                rights.Add(right);
            }
            sqlconn.Close();
            return rights;
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

        [HttpPost]
        public IActionResult Create(hcodeModel ur)
        {
            if (ur.huser != null)
            {
                sqlconn.Open();
                string sql = @"select * from hcode where huser = @UserName ";

                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

                sqlcomm.Parameters.AddWithValue("@UserName", ur.huser.ToString());
                SqlDataReader sdr = sqlcomm.ExecuteReader();

                if (sdr.Read())
                {
                    sqlconn.Close();
                    ViewData["right"] = right();
                    ViewData["hosp"] = hosp();
                    ViewData["CheckUser"] = "มี Username นี้แล้วในระบบ";
                }
                else
                {
                    sqlconn2.Open();
                    string sql2 = @"INSERT INTO hcode VALUES(@hospcode,@huser,CONVERT(VARCHAR(32), HashBytes('MD5',@hpass), 2),@status,@fname,@lname,@type)";
                    SqlCommand sqlcomm2 = new SqlCommand(sql2, sqlconn2);

                    sqlcomm2.Parameters.AddWithValue("@hospcode", ur.hospcode);
                    sqlcomm2.Parameters.AddWithValue("@huser", ur.huser);
                    sqlcomm2.Parameters.AddWithValue("@hpass", ur.hpass);
                    sqlcomm2.Parameters.AddWithValue("@status", ur.status);
                    sqlcomm2.Parameters.AddWithValue("@fname", ur.fname);
                    sqlcomm2.Parameters.AddWithValue("@lname", ur.lname);
                    sqlcomm2.Parameters.AddWithValue("@type", 2);

                    sqlcomm2.ExecuteNonQuery();
                    sqlconn2.Close();

                    return RedirectToAction("showUser");
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["right"] = right();
                ViewData["hosp"] = hosp();

                hcodeModel hcode = new hcodeModel();
                DataTable dt = new DataTable();
                sqlconn.Open();
                string sql = @"SELECT h.* FROM hcode h
                                INNER JOIN [right] r on r.id = h.status 
                                INNER JOIN hosp ho on ho.hospcode = h.hospcode
                               WHERE h.hid=@hid";
                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
                sda.SelectCommand.Parameters.AddWithValue("@hid", id);
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    hcode.hid = Convert.ToInt32(dt.Rows[0][0]);
                    hcode.hospcode = Convert.ToInt32(dt.Rows[0][1]);
                    hcode.huser = dt.Rows[0][2].ToString();
                    hcode.hpass = dt.Rows[0][3].ToString();
                    hcode.status = Convert.ToInt32(dt.Rows[0][4]);
                    hcode.fname = dt.Rows[0][5].ToString();
                    hcode.lname = dt.Rows[0][6].ToString();
                    hcode.type = Convert.ToInt32(dt.Rows[0][7]);

                    return View(hcode);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(hcodeModel ur)
        {
            if (ur.hpass == null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["right"] = right();
                ViewData["hosp"] = hosp();
            }
            else if (ur.fname == null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["right"] = right();
                ViewData["hosp"] = hosp();
                ViewData["Errorfname"] = "กรุณากรอกข้อมูล";
            }
            else if (ur.lname == null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["right"] = right();
                ViewData["hosp"] = hosp();
                ViewData["Errorlname"] = "กรุณากรอกข้อมูล";
            }
            else
            {
                sqlconn.Open();
                string sql = @"UPDATE hcode SET 
                                hpass = CONVERT(VARCHAR(32), HashBytes('MD5', @hpass),2), 
                                status = @status , 
                                fname = @fname,
                                lname=@lname 
                                WHERE hid =@hid";
                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);


                sqlcomm.Parameters.AddWithValue("@hid", ur.hid);
                sqlcomm.Parameters.AddWithValue("@hpass", ur.hpass);
                sqlcomm.Parameters.AddWithValue("@status", ur.status);
                sqlcomm.Parameters.AddWithValue("@fname", ur.fname);
                sqlcomm.Parameters.AddWithValue("@lname", ur.lname);

                int rowsAffected = sqlcomm.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return RedirectToAction("showUser", "Login");

                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}

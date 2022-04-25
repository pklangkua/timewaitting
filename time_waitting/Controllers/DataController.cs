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
//using System.Web.Mvc;

namespace time_waitting.Controllers
{
    public class DataController : Controller
    {
        SqlConnection sqlconn = new DBClass().SqlStrCon();
        Datetime date = new Datetime();
        // string keyvalue = ConfigurationManager.AppSettings["aspNetCore"];

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewBag.Page = "Data";
                ViewData["ShowData"] = DataDisplay();

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> file)
        {

            var size = file.Sum(f => f.Length);
            var filePaths = new List<string>();
            try
            {

                foreach (var formFile in file)
                {
                    if (formFile.Length > 0)
                    {
                        string FileName = Path.GetRandomFileName() + Path.GetFileNameWithoutExtension(formFile.FileName) + Path.GetExtension(formFile.FileName);
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\File", FileName);
                        var type = Path.GetExtension(formFile.FileName);
                        //string temp = Path.GetTempFileName(filePath);
                        if (type != ".txt")
                        {
                            ViewBag.ErrorType = "File type not specified ";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            filePaths.Add(filePath);
                            using (var strem = new FileStream(filePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(strem);

                                DataTable dt = new DataTable();
                                dt.Columns.AddRange(new DataColumn[18] {
                                new DataColumn("t_id", typeof(int)),
                                new DataColumn("t_newpatien", typeof(int)),
                                new DataColumn("t_oldpatien",typeof(int)),
                                new DataColumn("t_card",typeof(float)),
                                new DataColumn("t_screen",typeof(float)),
                                new DataColumn("t_waitdoc",typeof(float)),
                                new DataColumn("t_roomdoc",typeof(float)),
                                new DataColumn("t_prescription",typeof(float)),
                                new DataColumn("t_waitmed",typeof(float)),
                                new DataColumn("t_med",typeof(float)),
                                new DataColumn("t_oldmed",typeof(float)),
                                new DataColumn("t_inter",typeof(float)),
                                new DataColumn("t_admit",typeof(int)),
                                new DataColumn("t_prepare_admit",typeof(float)),
                                new DataColumn("t_hcode",typeof(int)),
                                new DataColumn("t_month",typeof(int)),
                                new DataColumn("t_year",typeof(int)),
                                new DataColumn("type",typeof(int))
                            });

                                var csvData = new StreamReader(formFile.OpenReadStream());
                                string[] headers = csvData.ReadLine().Split(','); //ตัด Header ออก

                                while (!csvData.EndOfStream)
                                {
                                    string[] rows = csvData.ReadLine().Split(',');
                                    if (rows[0] != "")
                                    {
                                        dt.Rows.Add(rows);
                                    }
                                }

                                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlconn);

                                //Set the database table name.
                                sqlBulkCopy.DestinationTableName = "timeWaitting";

                                //[OPTIONAL]: Map the DataTable columns with that of the database table
                                sqlBulkCopy.ColumnMappings.Add("t_id", "t_id");
                                sqlBulkCopy.ColumnMappings.Add("t_newpatien", "t_newpatien");
                                sqlBulkCopy.ColumnMappings.Add("t_oldpatien", "t_oldpatien");
                                sqlBulkCopy.ColumnMappings.Add("t_card", "t_card");
                                sqlBulkCopy.ColumnMappings.Add("t_screen", "t_screen");
                                sqlBulkCopy.ColumnMappings.Add("t_waitdoc", "t_waitdoc");
                                sqlBulkCopy.ColumnMappings.Add("t_roomdoc", "t_roomdoc");
                                sqlBulkCopy.ColumnMappings.Add("t_prescription", "t_prescription");
                                sqlBulkCopy.ColumnMappings.Add("t_waitmed", "t_waitmed");
                                sqlBulkCopy.ColumnMappings.Add("t_med", "t_med");
                                sqlBulkCopy.ColumnMappings.Add("t_oldmed", "t_oldmed");
                                sqlBulkCopy.ColumnMappings.Add("t_inter", "t_inter");
                                sqlBulkCopy.ColumnMappings.Add("t_admit", "t_admit");
                                sqlBulkCopy.ColumnMappings.Add("t_prepare_admit", "t_prepare_admit");
                                sqlBulkCopy.ColumnMappings.Add("t_hcode", "t_hcode");
                                sqlBulkCopy.ColumnMappings.Add("t_month", "t_month");
                                sqlBulkCopy.ColumnMappings.Add("t_year", "t_year");
                                sqlBulkCopy.ColumnMappings.Add("type", "type");

                                sqlconn.Open();

                                sqlBulkCopy.WriteToServer(dt);

                                sqlconn.Close();

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorInsert", "Data");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Add()
        {
            string keyvalue = ConfigurationManager.AppSettings["countoffiles"];
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                DateTime M = DateTime.Now;
                int days = Convert.ToInt32(M.Day);
                int m = Convert.ToInt32(M.Month);
                int chk = date.CheckDate();

                if (days <= chk)
                {
                    string fname = HttpContext.Session.GetString("fname");
                    string lname = HttpContext.Session.GetString("lname");
                    ViewData["fullname"] = fname + " " + lname;
                    ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                    ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                    ViewBag.Page = "Data";
                    ViewData["cmonth"] = cmonth();

                    int y = date.Years();
                    ViewData["Date2"] = y;

                    // int m = Convert.ToInt32(M.Month);
                    int mm = m - 1;
                    if (mm == 0)
                    {
                        ViewData["Month"] = date.Month(12);
                        ViewData["MonthNum"] = 12;

                    }
                    else
                    {
                        ViewData["Month"] = date.Month(mm);
                        ViewData["MonthNum"] = mm;
                    }

                    return View();
                }
                else
                {
                    return RedirectToAction("Error", "Data");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Add(timeWaittingModel time)
        {
            DateTime M = DateTime.Now;
            int days = Convert.ToInt32(M.Day);
            int m = Convert.ToInt32(M.Month);
            int chk = date.CheckDate();

            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
            ViewBag.Page = "Data";
            ViewData["cmonth"] = cmonth();

            int y = date.Years();
            ViewData["Date2"] = y;
            try
            {
                int hcode = Convert.ToInt32(HttpContext.Session.GetInt32("hospcode"));

                sqlconn.Open();
                string sql = @"INSERT INTO timeWaitting VALUES(@t_newpatien,@t_oldpatien,@t_card,@t_screen,@t_waitdoc,
                               @t_roomdoc,@t_prescription,@t_waitmed,@t_med,@t_oldmed,@t_inter,@t_admit,
                               @t_prepare_admit,@t_hcode,@t_month,@t_year,'',GETDATE(),@type)";
                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

                sqlcomm.Parameters.AddWithValue("@t_newpatien", time.t_newpatien);
                sqlcomm.Parameters.AddWithValue("@t_oldpatien", time.t_oldpatien);
                sqlcomm.Parameters.AddWithValue("@t_card", time.t_card);
                sqlcomm.Parameters.AddWithValue("@t_screen", time.t_screen);
                sqlcomm.Parameters.AddWithValue("@t_waitdoc", time.t_waitdoc);
                sqlcomm.Parameters.AddWithValue("@t_roomdoc", time.t_roomdoc);
                sqlcomm.Parameters.AddWithValue("@t_prescription", time.t_prescription);
                sqlcomm.Parameters.AddWithValue("@t_waitmed", time.t_waitmed);
                sqlcomm.Parameters.AddWithValue("@t_med", time.t_med);
                sqlcomm.Parameters.AddWithValue("@t_oldmed", time.t_oldmed);
                sqlcomm.Parameters.AddWithValue("@t_inter", time.t_inter);
                sqlcomm.Parameters.AddWithValue("@t_admit", time.t_admit);
                sqlcomm.Parameters.AddWithValue("@t_prepare_admit", time.t_prepare_admit);
                sqlcomm.Parameters.AddWithValue("@t_hcode", hcode);
                sqlcomm.Parameters.AddWithValue("@t_month", time.t_month);
                sqlcomm.Parameters.AddWithValue("@t_year", time.t_year);
                sqlcomm.Parameters.AddWithValue("@type", time.type);
                //sqlcomm.Parameters.AddWithValue("@t_edit", 0);
                //sqlcomm.Parameters.AddWithValue("@t_date", time.t_date);

                sqlcomm.ExecuteNonQuery();

                return RedirectToAction("ShowData");
            }
            catch
            {
                ViewData["ErrorInsert"] = "ไม่สามารถบันทึกข้อมูลได้กรุณาตวจสอบ อาจจะมีการบันทึกข้อมูลซ้ำกับที่มีอยู่";
                return View();
            }

        }
        public ActionResult ShowData()
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewBag.Page = "Data";
                ViewData["ShowData"] = DataDisplay();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
        public List<timeWaittingModel> DataDisplay()
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            int hcode = Convert.ToInt32(HttpContext.Session.GetInt32("hospcode"));
            int status = Convert.ToInt32(HttpContext.Session.GetInt32("status"));
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
            List<timeWaittingModel> times = new List<timeWaittingModel>();

            string Ssql = @"select t.*,h.hospname,m.m_name from timeWaitting t 
                            INNER JOIN hosp h ON h.hospcode = t.t_hcode
                            INNER JOIN cmonth m on m.m_id = t.t_month";
            if (status == 2)
            {
                Ssql += @" ORDER BY t_id desc";
            }
            else
            {
                Ssql += @" where t.t_hcode =" + hcode + " ORDER BY t_id desc";
            }

            SqlCommand sqlcomm = new SqlCommand(Ssql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            sda.SelectCommand = sqlcomm;

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            while (sdr.Read())
            {
                timeWaittingModel time = new timeWaittingModel();

                time.t_id = Convert.ToInt32(sdr["t_id"]);
                time.t_newpatien = Convert.ToInt32(sdr["t_newpatien"]);
                time.t_oldpatien = Convert.ToInt32(sdr["t_oldpatien"]);
                time.t_card = (float)Convert.ToDouble(sdr["t_oldpatien"]);
                time.t_screen = (float)Convert.ToDouble(sdr["t_screen"]);
                time.t_waitdoc = (float)Convert.ToDouble(sdr["t_waitdoc"]);
                time.t_roomdoc = (float)Convert.ToDouble(sdr["t_roomdoc"]);
                time.t_prescription = (float)Convert.ToDouble(sdr["t_prescription"]);
                time.t_waitmed = (float)Convert.ToDouble(sdr["t_waitmed"]);
                time.t_med = (float)Convert.ToDouble(sdr["t_med"]);
                time.t_oldmed = (float)Convert.ToDouble(sdr["t_oldmed"]);
                time.t_inter = (float)Convert.ToDouble(sdr["t_inter"]);
                time.t_admit = Convert.ToInt32(sdr["t_admit"]);
                time.t_prepare_admit = (float)Convert.ToDouble(sdr["t_prepare_admit"]);
                time.t_hcode = Convert.ToInt32(sdr["t_hcode"]);
                time.t_month = Convert.ToInt32(sdr["t_month"]);
                time.t_year = Convert.ToInt32(sdr["t_year"]);
                time.t_edit = Convert.ToInt32(sdr["t_edit"]);
                time.t_date = Convert.ToDateTime(sdr["t_date"]);
                time.hname = sdr["hospname"].ToString();
                time.m_name = sdr["m_name"].ToString();
                time.type = Convert.ToInt32(sdr["type"]);

                times.Add(time);
            }
            sqlconn.Close();
            return times;
        }

        public IActionResult Detail(int? id)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["cmonth"] = cmonth();
                ViewBag.Page = "Data";

                timeWaittingModel time = new timeWaittingModel();
                DataTable dt = new DataTable();
                sqlconn.Open();
                string sql = @"select t.*,h.hospname,m.m_name from timeWaitting t 
                            INNER JOIN hosp h ON h.hospcode = t.t_hcode
                            INNER JOIN cmonth m on m.m_id = t.t_month
                            where t_id =@t_id";
                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
                sda.SelectCommand.Parameters.AddWithValue("@t_id", id);
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    time.t_id = Convert.ToInt32(dt.Rows[0][0]);
                    time.t_newpatien = Convert.ToInt32(dt.Rows[0][1]);
                    time.t_oldpatien = Convert.ToInt32(dt.Rows[0][2]);
                    time.t_card = (float)Convert.ToDouble(dt.Rows[0][3]);
                    time.t_screen = (float)Convert.ToDouble(dt.Rows[0][4]);
                    time.t_waitdoc = (float)Convert.ToDouble(dt.Rows[0][5]);
                    time.t_roomdoc = (float)Convert.ToDouble(dt.Rows[0][6]);
                    time.t_prescription = (float)Convert.ToDouble(dt.Rows[0][7]);
                    time.t_waitmed = (float)Convert.ToDouble(dt.Rows[0][8]);
                    time.t_med = (float)Convert.ToDouble(dt.Rows[0][9]);
                    time.t_oldmed = (float)Convert.ToDouble(dt.Rows[0][10]);
                    time.t_inter = (float)Convert.ToDouble(dt.Rows[0][11]);
                    time.t_admit = Convert.ToInt32(dt.Rows[0][12]);
                    time.t_prepare_admit = (float)Convert.ToDouble(dt.Rows[0][13]);
                    time.t_hcode = Convert.ToInt32(dt.Rows[0][14]);
                    time.t_month = Convert.ToInt32(dt.Rows[0][15]);
                    time.t_year = Convert.ToInt32(dt.Rows[0][16]);
                    time.t_edit = Convert.ToInt32(dt.Rows[0][17]);
                    time.t_date = Convert.ToDateTime(dt.Rows[0][18]);
                    time.type = Convert.ToInt32(dt.Rows[0][19]);
                    time.hname = dt.Rows[0][20].ToString();
                    time.m_name = dt.Rows[0][21].ToString();

                    return View(time);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                timeWaittingModel time = new timeWaittingModel();
                DataTable dt = new DataTable();
                sqlconn.Open();
                string sql = @"select t.*,h.hospname,m.m_name from timeWaitting t 
                            INNER JOIN hosp h ON h.hospcode = t.t_hcode
                            INNER JOIN cmonth m on m.m_id = t.t_month
                            where t_id =@t_id";
                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
                sda.SelectCommand.Parameters.AddWithValue("@t_id", id);
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    time.t_id = Convert.ToInt32(dt.Rows[0][0]);

                    return View(time);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult EditData(int? id)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));
                ViewData["cmonth"] = cmonth();
                ViewBag.Page = "Data";

                timeWaittingModel time = new timeWaittingModel();
                DataTable dt = new DataTable();
                sqlconn.Open();
                string sql = @"select t.*,h.hospname,m.m_name from timeWaitting t 
                            INNER JOIN hosp h ON h.hospcode = t.t_hcode
                            INNER JOIN cmonth m on m.m_id = t.t_month
                            where t_id =@t_id";
                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
                sda.SelectCommand.Parameters.AddWithValue("@t_id", id);
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    time.t_id = Convert.ToInt32(dt.Rows[0][0]);
                    time.t_newpatien = Convert.ToInt32(dt.Rows[0][1]);
                    time.t_oldpatien = Convert.ToInt32(dt.Rows[0][2]);
                    time.t_card = (float)Convert.ToDouble(dt.Rows[0][3]);
                    time.t_screen = (float)Convert.ToDouble(dt.Rows[0][4]);
                    time.t_waitdoc = (float)Convert.ToDouble(dt.Rows[0][5]);
                    time.t_roomdoc = (float)Convert.ToDouble(dt.Rows[0][6]);
                    time.t_prescription = (float)Convert.ToDouble(dt.Rows[0][7]);
                    time.t_waitmed = (float)Convert.ToDouble(dt.Rows[0][8]);
                    time.t_med = (float)Convert.ToDouble(dt.Rows[0][9]);
                    time.t_oldmed = (float)Convert.ToDouble(dt.Rows[0][10]);
                    time.t_inter = (float)Convert.ToDouble(dt.Rows[0][11]);
                    time.t_admit = Convert.ToInt32(dt.Rows[0][12]);
                    time.t_prepare_admit = (float)Convert.ToDouble(dt.Rows[0][13]);
                    time.t_hcode = Convert.ToInt32(dt.Rows[0][14]);
                    time.t_month = Convert.ToInt32(dt.Rows[0][15]);
                    time.t_year = Convert.ToInt32(dt.Rows[0][16]);
                    time.t_edit = Convert.ToInt32(dt.Rows[0][17]);
                    time.t_date = Convert.ToDateTime(dt.Rows[0][18]);
                    time.type = Convert.ToInt32(dt.Rows[0][19]);
                    time.hname = dt.Rows[0][20].ToString();
                    time.m_name = dt.Rows[0][21].ToString();
                    //if (time.t_edit == 1)
                    //{
                    return View(time);
                    //}
                    //else
                    //{
                    //    return RedirectToAction("ShowData");
                    //}

                }
                else
                {
                    return RedirectToAction("ShowData");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult EditData(timeWaittingModel tm)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                sqlconn.Open();
                string sql = @"UPDATE timeWaitting SET t_newpatien=@t_newpatien ,t_oldpatien=@t_oldpatien ,t_card=@t_card ,t_screen=@t_screen ,t_waitdoc=@t_waitdoc
                                ,t_roomdoc=@t_roomdoc ,t_prescription=@t_prescription ,t_waitmed=@t_waitmed ,t_med=@t_med ,t_oldmed=@t_oldmed ,t_inter=@t_inter ,t_admit=@t_admit ,
                                 t_prepare_admit=@t_prepare_admit ,t_date=@t_date,type=@type WHERE t_id = @t_id";
                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

                sqlcomm.Parameters.AddWithValue("@t_id", tm.t_id);
                sqlcomm.Parameters.AddWithValue("@t_newpatien", tm.t_newpatien);
                sqlcomm.Parameters.AddWithValue("@t_oldpatien", tm.t_oldpatien);
                sqlcomm.Parameters.AddWithValue("@t_card", tm.t_card);
                sqlcomm.Parameters.AddWithValue("@t_screen", tm.t_screen);
                sqlcomm.Parameters.AddWithValue("@t_waitdoc", tm.t_waitdoc);
                sqlcomm.Parameters.AddWithValue("@t_roomdoc", tm.t_roomdoc);
                sqlcomm.Parameters.AddWithValue("@t_prescription", tm.t_prescription);
                sqlcomm.Parameters.AddWithValue("@t_waitmed", tm.t_waitmed);
                sqlcomm.Parameters.AddWithValue("@t_med", tm.t_med);
                sqlcomm.Parameters.AddWithValue("@t_oldmed", tm.t_oldmed);
                sqlcomm.Parameters.AddWithValue("@t_inter", tm.t_inter);
                sqlcomm.Parameters.AddWithValue("@t_admit", tm.t_admit);
                sqlcomm.Parameters.AddWithValue("@t_prepare_admit", tm.t_prepare_admit);
                sqlcomm.Parameters.AddWithValue("@t_date", DateTime.Now);
                sqlcomm.Parameters.AddWithValue("@type", tm.type);

                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
                return RedirectToAction("ShowData", "Data");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Edit(timeWaittingModel tm)
        {
            if (HttpContext.Session.GetString("hospcode") != null)
            {
                string fname = HttpContext.Session.GetString("fname");
                string lname = HttpContext.Session.GetString("lname");
                ViewData["fullname"] = fname + " " + lname;
                ViewData["hospname"] = HttpContext.Session.GetString("hospname");
                ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

                sqlconn.Open();
                string sql = @"UPDATE timeWaitting SET t_edit=@t_edit  WHERE t_id = @t_id";
                SqlCommand sqlcomm = new SqlCommand(sql, sqlconn);

                sqlcomm.Parameters.AddWithValue("@t_id", tm.t_id);
                sqlcomm.Parameters.AddWithValue("@t_edit", tm.t_edit);

                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
                return RedirectToAction("ShowData", "Data");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Error()
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["Check"] = date.CheckDate(); ;
            return View();
        }
        public ActionResult ErrorInsert()
        {
            string fname = HttpContext.Session.GetString("fname");
            string lname = HttpContext.Session.GetString("lname");
            ViewData["fullname"] = fname + " " + lname;
            ViewData["hospname"] = HttpContext.Session.GetString("hospname");
            ViewData["status"] = Convert.ToString(HttpContext.Session.GetInt32("status"));

            ViewData["Check"] = date.CheckDate(); ;
            return View();
        }
    }
}

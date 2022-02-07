using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace time_waitting.Controllers
{
    [Route("api/Sumpatien")]
    [ApiController]
    public class apiController : ControllerBase
    {
        SqlConnection con = new DBClass().SqlStrCon();

        [HttpGet]
        public string ConvertDataTabletoString()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT SUM(t_newpatien) AS t_newpatien ,SUM(t_oldpatien) AS t_oldpatien 
                        , SUM(t_admit) AS t_admit, ROUND(SUM(t_card + t_screen + t_waitdoc + t_roomdoc + t_prescription +
                         t_waitmed + t_med + t_oldmed + t_inter + t_prepare_admit) / 10, 2) AS sumtime
                        FROM timeWaitting";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return JsonSerializer.Serialize(rows);


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace time_waitting
{
    public class DBClass
    {
        public SqlConnection SqlStrCon()
        {
            // string config = @"Data Source=pradit\SQLEXPRESS;Initial Catalog=DUR;Persist Security Info=True;User ID=sa;Password=21652671";
            // string config = @"Data Source=pradit-thinkpad\sqlexpress;Initial Catalog=DRU;Persist Security Info=True;User ID=sa;Password=21652671";
            // string config = @"Data Source=localhost;Initial Catalog=DUR;Persist Security Info=True;User ID=sa;Password=#theredsCe3k#1";
             string config = @"Data Source=internal\sqlexpress;Initial Catalog=DRU;Persist Security Info=True;User ID=sa;Password=#theredsCe3k#1";
            return new SqlConnection(config);
        }
    }
    
}


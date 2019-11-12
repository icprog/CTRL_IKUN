using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;

namespace 优课堂
{
    class Updatedata
    {
        public static int Update1(string sql)
        {
            string cons = PubConstant.ConnectionString;
            SqlConnection con = new SqlConnection(cons);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int t = cmd.ExecuteNonQuery();
            con.Close();
            return t;
        }
        public static int Update2(string sql)
        {
            string cons = PubConstant.ConnectionString;
            SqlConnection con = new SqlConnection(cons);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int t = cmd.ExecuteNonQuery();
            con.Close();
            return t;
        }
    }
}

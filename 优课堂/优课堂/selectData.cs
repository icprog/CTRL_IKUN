using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;

namespace 优课堂
{
    class selectData
    {
        public static DataTable table(string tablename)
        {
            string con = PubConstant.ConnectionString;
            string sql = string.Format("select * from {0}", tablename);
            SqlConnection connection = new SqlConnection(con);
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            connection.Open();
            cmd.Fill(dataSet);
            connection.Close();
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            return dataTable;
        }
    }
}

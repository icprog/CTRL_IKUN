using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;
namespace 优课堂
{
    public class Class1
    {
        public static bool ExistsTable(string tablename)
        { 
            /// <summary>
            /// 判断数据库表是否存在，返回页头，通过指定专用的连接字符串，执行一个不需要返回值的SqlCommand命令。
            /// </summary>
            /// <param name="tablename">bhtsoft表</param>
            /// <returns></returns>
            string ConnectionString = PubConstant.ConnectionString;
            string tableNameStr = "select count(1) from sysobjects where name = '" + tablename + "'";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(tableNameStr, con);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public void CreateDataTable(string db, string dt, Dictionary<string, string> dic,string Key)
        {
            string connToMaster = PubConstant.ConnectionString;

            //如果数据库表存在，则抛出错误
            if (ExistsTable(dt) == true)
            {
                throw new Exception("数据库表已经存在！");
            }
            else//数据表不存在，创建数据表
            {
                //拼接字符串，（该串为创建内容）
                string content = string.Format("{0} varchar(20) primary key ",Key);
                //取出dic中的内容，进行拼接
                List<string> test = new List<string>(dic.Keys);
                for (int i = 0; i < dic.Count(); i++)
                {
                    content = content + " , " + test[i] + " " + dic[test[i]];
                }

                //其后判断数据表是否存在，然后创建数据表
                string createTableStr = "use " + db + " create table " + dt + " (" + content + ")";
                SqlConnection con = new SqlConnection(connToMaster);
                SqlCommand cmd = new SqlCommand(createTableStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
        }

    }
    

}

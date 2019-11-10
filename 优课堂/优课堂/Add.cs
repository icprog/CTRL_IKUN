using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;
using System.Windows.Forms;

namespace 优课堂
{
    public partial class Add : Form
    {
        string user;
        public Add(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            //用一个dictionary类型，来保存 数据库表的字段 和 数据类型
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("姓名", "varchar(20)");
            dic.Add("专业年级", "varchar(20)");
            dic.Add("辅导员", "varchar(20)");
            string tablename = string.Format("学生用户{0}基本信息",user);
            class1.CreateDataTable("优课堂", tablename, dic,"学号");
            string cons = PubConstant.ConnectionString;
            SqlConnection con = new SqlConnection(cons);
            string sql = string.Format("insert into {4}(学号,姓名,专业年级,辅导员) values('{0}','{1}','{2}','{3}')", skinWaterTextBox1.Text.ToString(), skinWaterTextBox5.Text.ToString(), skinWaterTextBox4.Text.ToString(), skinWaterTextBox2.Text.ToString(),tablename);
            SqlCommand cmd1 = new SqlCommand(sql, con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("信息录入成功,请重新登录。");
            this.Close();
        }
    }
}

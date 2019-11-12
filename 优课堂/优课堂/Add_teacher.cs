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
    public partial class Add_teacher : Form
    {
        string user;
        public Add_teacher(string user)
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
            dic.Add("学院", "varchar(20)");
            string tablename = string.Format("教师用户{0}基本信息", user);
            class1.CreateDataTable("优课堂", tablename, dic, "教工号");
            string cons = PubConstant.ConnectionString;
            SqlConnection con = new SqlConnection(cons);
            string sql = string.Format("insert into {3}(教工号,姓名,学院) values('{0}','{1}','{2}')", skinWaterTextBox1.Text.ToString(), skinWaterTextBox5.Text.ToString(), skinWaterTextBox4.Text.ToString(), tablename);
            SqlCommand cmd1 = new SqlCommand(sql, con);
            con.Open();
            int i=cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("信息录入成功,请重新登录。");
            
            Teacher teacher = new Teacher();
            this.Close();
            teacher.ShowDialog();
        }
    }
}

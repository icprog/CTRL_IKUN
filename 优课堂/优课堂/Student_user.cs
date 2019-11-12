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
    public partial class Student_user : Form
    {
        public Student_user()
        {
            InitializeComponent();
        }
        string user;
        
        public Student_user(string user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void Student_user_Load(object sender, EventArgs e)
        {
            string tablename = string.Format("学生用户{0}基本信息", user);
            if (Class1.ExistsTable(tablename))
            {
                DataTable table = 优课堂.selectData.table(tablename);
                skinLabel2.Text = table.Rows[0][0].ToString();
                skinLabel3.Text = table.Rows[0][1].ToString();
                skinLabel4.Text = table.Rows[0][2].ToString();
                skinLabel5.Text = table.Rows[0][3].ToString();
                skinLabel1.Text = "选择教师及课程、学生姓名查看考勤信息";
            }
            if (skinLabel1.Text == "点击添加个人信息")
            {
                
                Add add = new Add(user);
                this.Close();
                add.ShowDialog();
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string tablename = string.Format("{0}{1}{2}课程考勤表", skinWaterTextBox1.Text.ToString(), skinWaterTextBox2.Text.ToString(), skinWaterTextBox4.Text.ToString());
                string cons = PubConstant.ConnectionString;
                SqlConnection con = new SqlConnection(cons);
                string sql = "select name from sysobjects where xtype='u' order by name";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                bool test = false; ;
                while (dr.Read())
                {
                    string str = dr["name"].ToString();
                    if (str.Contains(string.Format("{0}", skinWaterTextBox1.Text.ToString())) && str.Contains("课程考勤表") && str.Contains(skinWaterTextBox2.Text.ToString()))
                    {
                        test = true;
                    }

                }
                if (test == false)
                {
                    MessageBox.Show("无该教师考勤表");
                }
                if (test == true)
                {

                    string con1 = PubConstant.ConnectionString;
                    string sql1 = string.Format("select * from {0} where 姓名='{1}'", tablename, skinWaterTextBox3.Text.ToString());
                    SqlConnection connection = new SqlConnection(con1);
                    SqlDataAdapter cmd1 = new SqlDataAdapter(sql1, connection);
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    cmd1.Fill(dataSet);
                    connection.Close();
                    DataTable dataTable = new DataTable();
                    dataTable = dataSet.Tables[0];
                    skinDataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception  ex)
            {
                MessageBox.Show("请输入完整的学生课程信息");

            }
            
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            DialogResult t = MessageBox.Show("确认退出程序", "提示", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == t)
                Application.Exit();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            this.Hide();
            form.ShowDialog();
            Application.ExitThread();
        }
    }
}

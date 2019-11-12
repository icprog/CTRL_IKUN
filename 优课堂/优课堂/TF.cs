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
    public partial class TF : Form
    {
        string tablename;
        public TF()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            try
            {
                tablename = string.Format("{0}{1}{2}课程考勤表", skinWaterTextBox1.Text.ToString(), skinWaterTextBox2.Text.ToString(), skinWaterTextBox4.Text.ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show("请输入完整的学生课程信息");

            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            string time = "考勤时间" + skinWaterTextBox5.Text.ToString();
            if (skinCheckBox1.Checked == true && skinCheckBox3.Checked == true && skinCheckBox4.Checked == true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox1.Checked == true && skinCheckBox3.Checked == true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox1.Checked == true && skinCheckBox4.Checked == true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox3.Checked == true && skinCheckBox4.Checked == true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox1.Checked == true && skinCheckBox3.Checked == false && skinCheckBox4.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox1.Text.ToString(), skinWaterTextBox3.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table1(tablename,skinWaterTextBox3.Text.ToString());
                    skinDataGridView1.DataSource = dataTable;

                }
            }
            if (skinCheckBox3.Checked == true && skinCheckBox1.Checked == false && skinCheckBox4.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox3.Text.ToString(), skinWaterTextBox3.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table1(tablename, skinWaterTextBox3.Text.ToString()); 
                    skinDataGridView1.DataSource = dataTable;

                }
            }
            if (skinCheckBox4.Checked == true && skinCheckBox1.Checked == false && skinCheckBox3.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox4.Text.ToString(), skinWaterTextBox3.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table1(tablename, skinWaterTextBox3.Text.ToString());
                    skinDataGridView1.DataSource = dataTable;

                }
            }
        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            this.Hide();
            form.ShowDialog();
            Application.ExitThread();
        }

        private void skinButton5_Click(object sender, EventArgs e)
        {
            DialogResult t = MessageBox.Show("确认退出程序", "提示", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == t)
                Application.Exit();
        }
    }
}

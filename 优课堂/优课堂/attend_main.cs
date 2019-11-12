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
    public partial class attend_main : Form
    {
        int i = 0;
        string tablename = null;
        string time = null;
        public attend_main(string tablename,string time)
        {
            InitializeComponent();
            this.tablename = tablename;
            this.time = time;
        }

        private void attend_main_Load(object sender, EventArgs e)
        {
            try
            {
                skinButton1.Visible=false;
                skinButton2.Visible = false;
                skinButton3.Visible = false;
                skinButton4.Visible = false;
                skinLabelallname.Visible = false;
                skinCheckBox1.Visible = false;
                skinCheckBox2.Visible = false;

                skinButton5.Visible = false;
                skinButton6.Visible = false;
                skinButton7.Visible = false;
                skinButton8.Visible = false;
                time = "考勤时间" + time + "时";
                string cons = PubConstant.ConnectionString;
                SqlConnection con = new SqlConnection(cons);
                string sql = string.Format("alter  table {0}  add {1} varchar(50)", tablename, time);
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DataTable dataTable = selectData.table(tablename);
                skinDataGridView1.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("唯一"))
                {
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void skinButtonall_Click(object sender, EventArgs e)
        {
            skinButton1.Visible = true;
            skinButton2.Visible = true;
            skinButton3.Visible = true;
            skinButton4.Visible = true;
            skinLabelallname.Visible = true;
            skinCheckBox1.Visible = true;
            skinCheckBox2.Visible = true;
            
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                skinLabelallname.Text = skinDataGridView1.Rows[i].Cells["姓名"].Value.ToString();
            }
            if (i >=1 && i != skinDataGridView1.RowCount - 1)
            {
                skinLabelallname.Text = skinDataGridView1.Rows[i].Cells["姓名"].Value.ToString();
                i--;
            }
            if(i== skinDataGridView1.RowCount - 1)
            {
                i--;
                skinLabelallname.Text = skinDataGridView1.Rows[i].Cells["姓名"].Value.ToString();
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            if (i < skinDataGridView1.RowCount - 1&& i>=0)
            {
                skinLabelallname.Text = skinDataGridView1.Rows[i].Cells["姓名"].Value.ToString();
                i++;
            }
            else
            {
                MessageBox.Show("点名结束");
            }
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            if(skinCheckBox1.Checked == true && skinCheckBox2.Checked == true)
            {
                MessageBox.Show("请不要勾选两项");
            }
            if (skinCheckBox1.Checked==true)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox1.Text.ToString(), skinLabelallname.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
            if (skinCheckBox2.Checked==true)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox2.Text.ToString(), skinLabelallname.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            DataTable dataTable = selectData.table(tablename);
            skinDataGridView1.DataSource = dataTable;
            skinButton1.Visible = false;
            skinButton2.Visible = false;
            skinButton3.Visible = false;
            skinButton4.Visible = false;
            skinLabelallname.Visible = false;
            skinCheckBox1.Visible = false;
            skinCheckBox2.Visible = false;

            skinButton5.Visible = false;
            skinButton6.Visible = false;
            skinButton7.Visible = false;
            skinButton8.Visible = false;
        }

        private void skinButtonSJ_Click(object sender, EventArgs e)
        {
            skinButton5.Visible = true;
            skinButton6.Visible = true;
            skinButton7.Visible = true;
            skinButton8.Visible = true;
            skinLabelallname.Visible = true;
            skinCheckBox1.Visible = true;
            skinCheckBox2.Visible = true;

        }

        private void timer_(object sender, EventArgs e)
        {
            Random random = new Random();
            int l = random.Next(0, skinDataGridView1.RowCount - 1);
            skinLabelallname.Text= skinDataGridView1.Rows[l].Cells["姓名"].Value.ToString();
        }

        private void skinButton8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void skinButton7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void skinButton5_Click(object sender, EventArgs e)
        {

            if (skinCheckBox1.Checked == true && skinCheckBox2.Checked == true)
            {
                MessageBox.Show("请不要勾选两项");
            }
            if (skinCheckBox1.Checked == true && skinCheckBox2.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox1.Text.ToString(), skinLabelallname.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
            if (skinCheckBox2.Checked == true && skinCheckBox1.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox2.Text.ToString(), skinLabelallname.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            DataTable dataTable = selectData.table(tablename);
            skinDataGridView1.DataSource = dataTable;
            skinButton1.Visible = false;
            skinButton2.Visible = false;
            skinButton3.Visible = false;
            skinButton4.Visible = false;
            skinLabelallname.Visible = false;
            skinCheckBox1.Visible = false;
            skinCheckBox2.Visible = false;

            skinButton5.Visible = false;
            skinButton6.Visible = false;
            skinButton7.Visible = false;
            skinButton8.Visible = false;
        }

        private void skinButton9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void skinButton10_Click(object sender, EventArgs e)
        {
            DialogResult t = MessageBox.Show("确认退出程序", "提示", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == t)
                Application.Exit();
        }
    }
}

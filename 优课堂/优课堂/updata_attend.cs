using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 优课堂
{
    public partial class updata_attend : Form
    {
        string tablename;
        public updata_attend(string tablename)
        {
            InitializeComponent();
            this.tablename = tablename;
        }

        private void updata_attend_Load(object sender, EventArgs e)
        {
            DataTable dataTable = selectData.table(tablename);
            skinDataGridView1.DataSource = dataTable;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string time = "考勤时间" + skinWaterTextBox2.Text.ToString();
            if (skinCheckBox1.Checked == true && skinCheckBox3.Checked == true && skinCheckBox4.Checked==true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox1.Checked == true && skinCheckBox3.Checked == true )
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox1.Checked == true &&  skinCheckBox4.Checked == true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox3.Checked == true && skinCheckBox4.Checked == true)
            {
                MessageBox.Show("请不要勾选多项");
            }
            if (skinCheckBox1.Checked == true && skinCheckBox3.Checked==false && skinCheckBox4.Checked==false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox1.Text.ToString(), skinWaterTextBox1.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
            if (skinCheckBox3.Checked == true && skinCheckBox1.Checked == false && skinCheckBox4.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox3.Text.ToString(), skinWaterTextBox1.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
            if (skinCheckBox4.Checked == true && skinCheckBox1.Checked == false && skinCheckBox3.Checked == false)
            {
                string sql = string.Format("update {0} set {1}='{2}' where 姓名='{3}'", tablename, time, skinCheckBox4.Text.ToString(), skinWaterTextBox1.Text.ToString());
                if (Updatedata.Update1(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    DataTable dataTable = selectData.table(tablename);
                    skinDataGridView1.DataSource = dataTable;

                }
            }
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

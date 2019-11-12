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
    public partial class Teacher_zone : Form
    {
        public Teacher_zone()
        {
            InitializeComponent();
        }
        string user;

        public Teacher_zone(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Teacher_zone_Load(object sender, EventArgs e)
        {
            string tablename = string.Format("教师用户{0}基本信息", user);
            if (Class1.ExistsTable(tablename))
            {
                DataTable table = 优课堂.selectData.table(tablename);
                skinLabel2.Text = table.Rows[0][0].ToString();
                skinLabel3.Text = table.Rows[0][1].ToString();
                skinLabel4.Text = table.Rows[0][2].ToString();
                skinLabel1.Text = "CTRL_IKUN团队";
            }
            if (skinLabel1.Text == "点击添加个人信息")
            {
                Add_teacher add = new Add_teacher(user);
                this.Close();
                add.ShowDialog();
                
            }

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Add_course add_Course = new Add_course();
            add_Course.Show();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            skinComboBox1.Items.Clear();
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
                if (str.Contains(string.Format("{0}", skinLabel3.Text.ToString())) && str.Contains("课程考勤表"))
                {
                    int index = this.skinDataGridView1.Rows.Add();
                    skinDataGridView1.Rows[index].Cells["Column1"].Value = str;
                    test = true;
                    skinComboBox1.Items.Add(str.ToString());
                }
                   
            }
            if(test==false)
            {
                MessageBox.Show("请导入课程表");
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            if (skinComboBox1.Text.ToString().Contains("考勤表"))
            {
                string time = dateTimePicker1.Text.ToString() + dateTimePicker1.Value.Hour.ToString();
                attend_main _Main = new attend_main(skinComboBox1.Text.ToString(),time);
                _Main.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择课程。");
            }
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            if (skinComboBox1.Text.ToString().Contains("考勤表"))
            {
                updata_attend updata_Attend = new updata_attend(skinComboBox1.Text.ToString());
                updata_Attend.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择课程。");
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

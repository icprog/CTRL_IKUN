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
                this.Close();
                Add_teacher add = new Add_teacher(user);
                add.Show();
            }

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Add_course add_Course = new Add_course();
            add_Course.Show();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            cbTablesName.Items.Clear();
            string cons = PubConstant.ConnectionString;
            SqlConnection con = new SqlConnection(cons);
            string sql = "select name from sysobjects where xtype='u' order by name";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string str = dr["name"].ToString();
                this.cbTablesName.Items.Add(str);
            }
        }
    }
}

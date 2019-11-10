using System;
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
                skinLabel1.Text = "选择考勤时间及班级查看考勤信息";
            }
            if (skinLabel1.Text == "点击添加个人信息")
            {
                this.Close();
                Add add = new Add(user);
                add.Show();
            }
        }
    }
}

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
    public partial class Add_course : Form
    {
        public Add_course()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Excel(97-2003)文件|*.xls|所有文件|*.*";
                op.Title = "打开文件夹";
                string path = null;
                op.InitialDirectory = "d:\\";//最初从D盘开始查找文件，测试文件放置于本文件夹。
                op.FilterIndex = 1;
                if (op.ShowDialog() == DialogResult.OK)//判断路径是否正确
                {
                    path = op.FileName;
                }
                string name = GetExcelFile.GetFile(path);//获取Excel文件。
                string Tsql = "SELECT * FROM [" + name + "]";
                DataTable table = ExcelToDataTable.Redatatable(path, Tsql).Tables[0];//将Excel转换为dataset类型并赋值于table

                Class1 class1 = new Class1();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("姓名", "varchar(20)");
                dic.Add("课程名", "varchar(20)");
                dic.Add("辅导员", "varchar(50)");
                string tablename = string.Format("{0}{1}{2}课程考勤表", skinWaterTextBox1.Text.ToString(), skinWaterTextBox2.Text.ToString(), skinWaterTextBox3.Text.ToString());
                class1.CreateDataTable("优课堂", tablename, dic, "学号");
                string cons = PubConstant.ConnectionString;
                SqlConnection con = new SqlConnection(cons);
                
                con.Open();
                for (int i = 1; i < table.Rows.Count; i++)
                {
                    string sql = string.Format("insert into 地科院肖斌软件工程课程考勤表(学号,姓名,课程名,辅导员) values ('{0}','{1}','{2}','{3}')", table.Rows[i][0], table.Rows[i][1], table.Rows[i][2], table.Rows[i][3]);
                    SqlCommand cmd1 = new SqlCommand(sql, con);
                    cmd1.ExecuteNonQuery();
                }
                con.Close();

                skinDataGridView1.DataSource = selectData.table(tablename);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

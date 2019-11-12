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
    public partial class Teacher : Form
    {
        int t = 0;
        public Teacher()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from User_Teacher where userName='{0}' and userPassword='{1}'", user.Text.ToString(), password.Text.ToString());
            if (skinCode1.CodeStr == skinWaterTextBox1.Text.ToString())
            {
                if (selectData.table2(sql).Rows.Count > 0)
                {
                    Teacher_zone User = new Teacher_zone(user.Text.ToString());
                    this.Hide();
                    User.ShowDialog();
                    Application.ExitThread();
                }
                else
                {
                    t++;
                    MessageBox.Show("用户名或密码错误!", "提示");
                    user.Text = "";
                    password.Text = "";
                    if(t > 5)
                    {
                        MessageBox.Show("多次登录失败，可能不存在该用户");
                    }
                }
            }
            else
            {
                MessageBox.Show("验证码错误！", "提示");
                skinWaterTextBox1.Text = "";
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Teacher_ZC _ZC = new Teacher_ZC();
            this.Hide();
            _ZC.ShowDialog();
        }
    }
}

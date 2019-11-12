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
    public partial class Teacher_ZC : Form
    {
        public Teacher_ZC()
        {
            InitializeComponent();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("insert into User_Teacher(userName,userPassword) values ('{0}','{1}')", user.Text.ToString(), password.Text.ToString());
            if (skinWaterTextBox1.Text.ToString() == skinCode1.CodeStr)
            {
                if (password.Text.ToString() == skinWaterTextBox2.Text.ToString())
                {
                    if (Updatedata.Update1(sql) > 0)
                        MessageBox.Show("注册成功！", "提示");
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致!", "提示");
                    skinWaterTextBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("验证码错误！", "提示");

                skinWaterTextBox1.Text = "";
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Form form = new Teacher();
            this.Hide();
            form.ShowDialog();
            Application.ExitThread();
        }
    }
}

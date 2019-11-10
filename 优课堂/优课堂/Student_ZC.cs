using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Model;

namespace 优课堂
{
    public partial class Student_ZC : Form
    {
        public Student_ZC()
        {
            InitializeComponent();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            User_list user_List = new User_list();
            Maticsoft.Model.User_list _List = new Maticsoft.Model.User_list();
            _List.userName = user.Text.ToString();
            _List.userPassword = password.Text.ToString();
            if (skinWaterTextBox1.Text.ToString() == skinCode1.CodeStr)
            {
                if (password.Text.ToString() == skinWaterTextBox2.Text.ToString())
                {
                    if (user_List.Add(_List))
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
            Student student = new Student();
            this.Hide();
            student.ShowDialog();
        }
    }
}

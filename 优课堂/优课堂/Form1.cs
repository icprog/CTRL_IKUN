using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CCWin;


namespace 优课堂
{
    public partial class Form1 : Form
    {
        Sunisoft.IrisSkin.SkinEngine skinEngine = new Sunisoft.IrisSkin.SkinEngine();
        List<string> skins;
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载所有皮肤列表
            skins = System.IO.Directory.GetFiles(Application.StartupPath + @"\界面ssk", "*.ssk").ToList();
            skins.ForEach(x =>
            {
                skinDataGridView1.Rows.Add(Path.GetFileNameWithoutExtension(x));
            });

            skinEngine.SkinFile = skins[25];
            skinEngine.Active = true;
        }

        private void skinDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (skinDataGridView1.CurrentRow != null)
            {
                //加载皮肤
                skinEngine.SkinFile = skins[skinDataGridView1.CurrentRow.Index];
                skinEngine.Active = true;
            }

        }

        private void skinButton_t_MouseClick(object sender, MouseEventArgs e)
        {
            Form form = new Teacher();
            this.Hide();
            form.ShowDialog();
            Application.ExitThread();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            DialogResult t = MessageBox.Show("确认退出程序", "提示", MessageBoxButtons.YesNo);
            if(DialogResult.Yes==t)
                Application.Exit();
        }

        private void skinButton_S_Click(object sender, EventArgs e)
        {
            Form form = new Student();
            this.Hide();
            form.ShowDialog();
            Application.ExitThread();         
        }
    }
}

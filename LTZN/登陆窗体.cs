using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTZN
{
    public partial class 登陆窗体 : Form
    {
        private string pyonghu = "";
        private string pmima = "";
        public string mima
        {
            get
            {
                return pmima;
            }
            set
            {
                pmima = value;
            }
        }
        public string yonghu
        {
            get
            {
                return pyonghu;
            }
            set
            {
                pyonghu = value;
            }
        }

        public 登陆窗体()
        {
            InitializeComponent();
            string strNetVersion = LtznUserManager.getNetVersion();
            if (strNetVersion != System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", ""))
            {
                MessageBox.Show("不是最新的客户端，请联系技术人员及时更新！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            yonghu = yonghuCtl.Text;
            mima = mimaCtl.Text;
          

        }

        private void 登陆窗体_Load(object sender, EventArgs e)
        {
            yonghuCtl.Items.Clear();
            foreach (string user in LtznUserManager.instance.getAllUsers())
            {
                yonghuCtl.Items.Add(user);
            }
        }

    }
}
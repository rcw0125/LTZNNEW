using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using System.Security.Principal;
using Rcw.Method;
using Rcw.Data;
using System.Linq;

namespace LTZN.调度
{
    public partial class 调度窗体 : Form
    {
        private DateTime pDate = DateTime.Today;
        private string pBanci = "夜班";
        private decimal pBanluci = 1;
        private bool 更改 = false;
        private bool 提示保存 = false;
        private bool 自动保存 = false;
        private bool 更新 = true;
        private int 原料权限 = 0; //&1,1烧。&2,2烧。&4竖球
       
        private YLXiaoHao ylxhData = new YLXiaoHao();

        private void DataBind()
        {
            this.ylxhT1.DataBindings.Add("Value", ylxhData, "ShaoJieKuang", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT2.DataBindings.Add("Value", ylxhData, "Qiutuankuang", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT3.DataBindings.Add("Value", ylxhData, "Guoneiqiutuankuang", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT4.DataBindings.Add("Value", ylxhData, "Jinkouqiutuankuang", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT5.DataBindings.Add("Value", ylxhData, "PBKuai", true, DataSourceUpdateMode.OnPropertyChanged);
            //纽曼块改为罗伊山块
            this.ylxhT6.DataBindings.Add("Value", ylxhData, "Luoyishankuai", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT7.DataBindings.Add("Value", ylxhData, "Qitakuaikuang", true, DataSourceUpdateMode.OnPropertyChanged);

            this.ylxhT8.DataBindings.Add("Value", ylxhData, "Gaotaiqiutuankuang", true, DataSourceUpdateMode.OnPropertyChanged);
            //高品位钛球 改为 废钢
            this.ylxhT9.DataBindings.Add("Value", ylxhData, "Feigang", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT10.DataBindings.Add("Value", ylxhData, "GuiShi", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT11.DataBindings.Add("Value", ylxhData, "YingShi", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT12.DataBindings.Add("Value", ylxhData, "SheWenShi", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT13.DataBindings.Add("Value", ylxhData, "Qitarongji", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT14.DataBindings.Add("Value", ylxhData, "FuYangLiang", true, DataSourceUpdateMode.OnPropertyChanged);

            this.ylxhT15.DataBindings.Add("Value", ylxhData, "GongYiCheng", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT16.DataBindings.Add("Value", ylxhData, "PenMei", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT17.DataBindings.Add("Value", ylxhData, "JiaoDing", true, DataSourceUpdateMode.OnPropertyChanged);

            this.ylxhT18.DataBindings.Add("Value", ylxhData, "ZiChanShiJiao", true, DataSourceUpdateMode.OnPropertyChanged);
            this.ylxhT19.DataBindings.Add("Value", ylxhData, "LuoDiShiJiao", true, DataSourceUpdateMode.OnPropertyChanged);
          

            ylxhData.PropertyChanged += new PropertyChangedEventHandler(ylxhData_PropertyChanged);

        }

        void ylxhData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            更改 = true;
            buttonSave.Enabled = true;
        }

        public 调度窗体()
        {
            InitializeComponent();

            comboBoxEdit1.SelectedIndex = 0;
            
            tabControl1.SelectedIndex = 1;
            DataBind();

            buttonSave.Visible = false;

            c1FlexGrid1.AllowAddNew = false;
            c1FlexGrid1.AllowEditing = false;
            c1FlexGrid1.AllowDelete = false;

            c1FlexGrid2.AllowAddNew = false;
            c1FlexGrid2.AllowEditing = false;
            c1FlexGrid2.AllowDelete = false;

            c1FlexGrid3.AllowAddNew = false;
            c1FlexGrid3.AllowEditing = false;
            c1FlexGrid3.AllowDelete = false;

            c1FlexGrid4.AllowAddNew = false;
            c1FlexGrid4.AllowEditing = false;
            c1FlexGrid4.AllowDelete = false;

            c1FlexGrid5.AllowAddNew = false;
            c1FlexGrid5.AllowEditing = false;
            c1FlexGrid5.AllowDelete = false;

            c1FlexGrid6.AllowAddNew = false;
            c1FlexGrid6.AllowEditing = false;
            c1FlexGrid6.AllowDelete = false;

            c1FlexGrid7.AllowAddNew = false;
            c1FlexGrid7.AllowEditing = false;
            c1FlexGrid7.AllowDelete = false;

            c1FlexGrid8.AllowAddNew = false;
            c1FlexGrid8.AllowEditing = false;
            c1FlexGrid8.AllowDelete = false;

            button1.Enabled = false;
            textBoxJSB.ReadOnly = true;
            textBoxJSB.BackColor = Color.LightYellow;

            LtznUserManager.instance.RegisterHandler(this, instance_UserChanged);
            


        }

        private void 调度窗体_Load(object sender, EventArgs e)
        {
            oracleConnection1.ConnectionString = Properties.Settings.Default.ltznConnectionString;

            //foreach (string s1 in Properties.Settings.Default.熟料分类)
            //{
            //    ylxhT11.Items.Add(s1);
            //}
            //foreach (string s2 in Properties.Settings.Default.生料分类)
            //{
            //    ylxhT13.Items.Add(s2);
            //}
            //selectLuci(pDate,pBanci,pBanluci);
            this.ddmfTableAdapter1.FillByRQ(this.调度数据集1.DDMF, this.dateTimePicker1.Value.Date);
            comboBoxEdit3.Text = "高炉全部";
            comboBoxEdit2.SelectedIndex = 0;

        }

        private void 调度窗体_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (自动保存 && 更改)
            {
                buttonSave_Click(null, null);
            }
            else
            {
                if (提示保存 && 更改)
                {
                    DialogResult dr = MessageBox.Show("数据已修改是否保存？", "提示", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Cancel)
                        e.Cancel = true;
                    if (dr == DialogResult.Yes)
                        buttonSave_Click(null, null);
                }
            }
        }

        void instance_UserChanged(LtznUser ltznUser)
        {
            IPrincipal p = LtznUserManager.instance.CurrentUser;
            if (p != null)
            {
                if (p.IsInRole("2#大烧"))
                {
                    //STLR.Parent = null;

                }
                if (p.IsInRole("1#大烧"))
                {
                    //STLR.Parent = null;

                }
                if (p.IsInRole("无时间限制") || this.dateTimePicker1.Value.Date > DateTime.Now - TimeSpan.FromHours(32))
                {
                    if (p.IsInRole("调度"))
                    {
                        //添加新增权限 20181108 
                        btnUpdate_PlanOrder.Enabled = true;
                        btnDelete_PlanOrder.Enabled = true;
                        simpleButton2.Enabled = true;

                        c1FlexGrid1.AllowAddNew = true;
                        c1FlexGrid1.AllowEditing = true;
                        c1FlexGrid1.AllowDelete = true;

                        c1FlexGrid2.AllowAddNew = true;
                        c1FlexGrid2.AllowEditing = true;
                        c1FlexGrid2.AllowDelete = true;

                        c1FlexGrid3.AllowAddNew = true;
                        c1FlexGrid3.AllowEditing = true;
                        c1FlexGrid3.AllowDelete = true;

                        c1FlexGrid4.AllowAddNew = true;
                        c1FlexGrid4.AllowEditing = true;
                        c1FlexGrid4.AllowDelete = true;

                        c1FlexGrid5.AllowAddNew = true;
                        c1FlexGrid5.AllowEditing = true;
                        c1FlexGrid5.AllowDelete = true;

                        c1FlexGrid6.AllowAddNew = true;
                        c1FlexGrid6.AllowEditing = true;
                        c1FlexGrid6.AllowDelete = true;

                        c1FlexGrid7.AllowAddNew = true;
                        c1FlexGrid7.AllowEditing = true;
                        c1FlexGrid7.AllowDelete = true;

                        c1FlexGrid8.AllowAddNew = true;
                        c1FlexGrid8.AllowEditing = true;
                        c1FlexGrid8.AllowDelete = true;

                        c1FlexGrid9.AllowAddNew = true;
                        c1FlexGrid9.AllowEditing = true;
                        c1FlexGrid9.AllowDelete = true;
                        button1.Enabled = true;
                        textBoxJSB.ReadOnly = false;
                        textBoxJSB.BackColor = Color.White;
                        自动保存 = true;
                        原料权限 = 7;

                    }
                    if (p.IsInRole("统计") || p.IsInRole("调度2"))
                    {
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;

                        c1FlexGrid1.AllowAddNew = true;
                        c1FlexGrid1.AllowEditing = true;
                        c1FlexGrid1.AllowDelete = true;

                        c1FlexGrid2.AllowAddNew = true;
                        c1FlexGrid2.AllowEditing = true;
                        c1FlexGrid2.AllowDelete = true;

                        c1FlexGrid3.AllowAddNew = true;
                        c1FlexGrid3.AllowEditing = true;
                        c1FlexGrid3.AllowDelete = true;

                        c1FlexGrid4.AllowAddNew = true;
                        c1FlexGrid4.AllowEditing = true;
                        c1FlexGrid4.AllowDelete = true;

                        c1FlexGrid5.AllowAddNew = true;
                        c1FlexGrid5.AllowEditing = true;
                        c1FlexGrid5.AllowDelete = true;

                        c1FlexGrid6.AllowAddNew = true;
                        c1FlexGrid6.AllowEditing = true;
                        c1FlexGrid6.AllowDelete = true;
                        //加载原料名称
                        List<string> lists = new List<string>();
                        高炉燃料比综合分析.LegendEnviroment.loadGLYL("调度原料",out lists);
                        StringBuilder sb = new StringBuilder();
                        foreach (String s in lists)
                        {
                            sb.Append(s + "|");
                        }
                        c1FlexGrid6.Cols[0].ComboList = sb.ToString();

                        c1FlexGrid7.AllowAddNew = true;
                        c1FlexGrid7.AllowEditing = true;
                        c1FlexGrid7.AllowDelete = true;

                        c1FlexGrid8.AllowAddNew = true;
                        c1FlexGrid8.AllowEditing = true;
                        c1FlexGrid8.AllowDelete = true;


                        c1FlexGrid9.AllowAddNew = true;
                        c1FlexGrid9.AllowEditing = true;
                        c1FlexGrid9.AllowDelete = true;
                        button1.Enabled = true;
                        textBoxJSB.ReadOnly = false;
                        textBoxJSB.BackColor = Color.White;
                        提示保存 = true;
                        原料权限 = 7;
                    }

                    if (p.IsInRole("煤粉分析"))
                    {
                        c1FlexGrid1.AllowAddNew = true;
                        c1FlexGrid1.AllowEditing = true;
                        c1FlexGrid1.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                    if (p.IsInRole("焦炭分析"))
                    {
                        c1FlexGrid2.AllowAddNew = true;
                        c1FlexGrid2.AllowEditing = true;
                        c1FlexGrid2.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                    if (p.IsInRole("焦炭粒度组成"))
                    {
                        c1FlexGrid3.AllowAddNew = true;
                        c1FlexGrid3.AllowEditing = true;
                        c1FlexGrid3.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                    if (p.IsInRole("机烧粒度组成"))
                    {
                        c1FlexGrid4.AllowAddNew = true;
                        c1FlexGrid4.AllowEditing = true;
                        c1FlexGrid4.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                    if (p.IsInRole("煤气分析"))
                    {
                        c1FlexGrid5.AllowAddNew = true;
                        c1FlexGrid5.AllowEditing = true;
                        c1FlexGrid5.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                    if (p.IsInRole("原料成分"))
                    {
                        c1FlexGrid6.AllowAddNew = true;
                        c1FlexGrid6.AllowEditing = true;
                        c1FlexGrid6.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                    if (p.IsInRole("原料消耗"))
                    {
                        button1.Enabled = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    }
                  
                  //套筒窑  
                    
                    if (p.IsInRole("机烧粒度组成"))
                    {
                        c1FlexGrid9.AllowAddNew = true;
                        c1FlexGrid9.AllowEditing = true;
                        c1FlexGrid9.AllowDelete = true;
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                        提示保存 = true;
                    
                    }
                    if (p.IsInRole("1#大烧"))
                    {
                        原料权限 |= 1;
                        List<string> lists = new List<string>();
                        高炉燃料比综合分析.LegendEnviroment.loadGLYL("调度原料", out lists);
                        StringBuilder sb = new StringBuilder();
                        foreach (String s in lists)
                        {
                            sb.Append(s + "|");
                        }
                        c1FlexGrid6.Cols[0].ComboList = sb.ToString();
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                    }
                    if (p.IsInRole("2#大烧"))
                    {
                        原料权限 |= 2;
                        List<string> lists = new List<string>();
                        高炉燃料比综合分析.LegendEnviroment.loadGLYL("调度原料", out lists);
                        StringBuilder sb = new StringBuilder();
                        foreach (String s in lists)
                        {
                            sb.Append(s + "|");
                        }
                        c1FlexGrid6.Cols[0].ComboList = sb.ToString();
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                    }
                    if (p.IsInRole("竖球"))
                    {
                        原料权限 |= 4;
                        c1FlexGrid6.Cols["MC"].ComboList = "竖球";
                        buttonSave.Visible = true;
                        buttonSave.Enabled = 更改;
                    }
                    return;
                }
            }
            else
            {
                //添加新增权限 20181108 
                btnUpdate_PlanOrder.Enabled = false;
                btnDelete_PlanOrder.Enabled = false;
                simpleButton2.Enabled = false;

                buttonSave.Visible = false;

                c1FlexGrid1.AllowAddNew = false;
                c1FlexGrid1.AllowEditing = false;
                c1FlexGrid1.AllowDelete = false;

                c1FlexGrid2.AllowAddNew = false;
                c1FlexGrid2.AllowEditing = false;
                c1FlexGrid2.AllowDelete = false;

                c1FlexGrid3.AllowAddNew = false;
                c1FlexGrid3.AllowEditing = false;
                c1FlexGrid3.AllowDelete = false;

                c1FlexGrid4.AllowAddNew = false;
                c1FlexGrid4.AllowEditing = false;
                c1FlexGrid4.AllowDelete = false;

                c1FlexGrid5.AllowAddNew = false;
                c1FlexGrid5.AllowEditing = false;
                c1FlexGrid5.AllowDelete = false;

                c1FlexGrid6.AllowAddNew = false;
                c1FlexGrid6.AllowEditing = false;
                c1FlexGrid6.AllowDelete = false;

                c1FlexGrid7.AllowAddNew = false;
                c1FlexGrid7.AllowEditing = false;
                c1FlexGrid7.AllowDelete = false;

                c1FlexGrid8.AllowAddNew = false;
                c1FlexGrid8.AllowEditing = false;
                c1FlexGrid8.AllowDelete = false;

                button1.Enabled = false;
                textBoxJSB.ReadOnly = true;
                textBoxJSB.BackColor = Color.LightYellow;
                原料权限 = 0;
                更改 = false;
                提示保存 = false;
                自动保存 = false;
            }
        }

        //查询数据
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (!更新) return;
            switch (this.tabControl1.SelectedTab.Name)
            {
                case "MFFX":
                    this.ddmfTableAdapter1.FillByRQ(this.调度数据集1.DDMF, this.dateTimePicker1.Value.Date);
                    break;
                case "JTFX":
                    this.ddjtTableAdapter1.FillByRQ(this.调度数据集1.DDJT, this.dateTimePicker1.Value.Date);
                    c1FlexGrid2Alarm();
                    break;
                case "JTLD":
                    this.ddldTableAdapter1.FillByRQ(this.调度数据集1.DDLD, this.dateTimePicker1.Value.Date);
                    c1FlexGrid3Alarm();
                    break;
                case "JSLD":
                    this.ddjsTableAdapter1.FillByRQ(this.调度数据集1.DDJS, this.dateTimePicker1.Value.Date);
                    c1FlexGrid4Alarm();
                    break;
                case "MQFX":
                    this.ddmqTableAdapter1.FillByRQ(this.调度数据集1.DDMQ, this.dateTimePicker1.Value.Date);
                    break;
                case "YLFX":
                    this.ddylTableAdapter1.FillByRQ(this.调度数据集1.DDYL, this.dateTimePicker1.Value.Date);
                    c1FlexGrid6Alarm();
                    break;
                case "QT":
                    OracleConnection cn = new OracleConnection();
                    cn.ConnectionString = Properties.Settings.Default.ltznConnectionString;
                    cn.Open();

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT YB,BB,ZB,FK,MK,JK FROM DDQT WHERE RQ=:RQ";
                    cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = this.dateTimePicker1.Value.Date;
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox1.Value = dr.IsDBNull(0) ? System.DBNull.Value : (object)dr.GetDecimal(0);
                        textBox2.Value = dr.IsDBNull(1) ? System.DBNull.Value : (object)dr.GetDecimal(1);
                        textBox3.Value = dr.IsDBNull(2) ? System.DBNull.Value : (object)dr.GetDecimal(2);
                        textBox4.Value = dr.IsDBNull(3) ? System.DBNull.Value : (object)dr.GetDecimal(3);
                        textBox5.Value = dr.IsDBNull(4) ? System.DBNull.Value : (object)dr.GetDecimal(4);
                        textBox6.Value = dr.IsDBNull(5) ? System.DBNull.Value : (object)dr.GetDecimal(5);
                    }
                    else
                    {
                        textBox1.Value = textBox2.Value = textBox3.Value = textBox4.Value = textBox5.Value = textBox6.Value = System.DBNull.Value;
                    }
                    dr.Close();


                    cmd.CommandText = "SELECT ROUND(AVG(FESI),2),ROUND(AVG(FES),3),ROUND(AVG(ZHAR2),2) FROM DDLUCI WHERE TRUNC(ZDSJ)=:RQ AND GAOLU=:GAOLU";
                    cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = dateTimePicker1.Value.Date;
                    OracleParameter gaolu = cmd.Parameters.Add(":GAOLU", OracleType.Int32);

                    gaolu.Value = 1;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox14.Value = dr.IsDBNull(0) ? System.DBNull.Value : (object)dr.GetDecimal(0);
                        textBox19.Value = dr.IsDBNull(1) ? System.DBNull.Value : (object)dr.GetDecimal(1);
                        textBox24.Value = dr.IsDBNull(2) ? System.DBNull.Value : (object)dr.GetDecimal(2);
                    }
                    else
                    { textBox14.Value = textBox19.Value = textBox24.Value = System.DBNull.Value; }
                    dr.Close();

                    gaolu.Value = 2;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox15.Value = dr.IsDBNull(0) ? System.DBNull.Value : (object)dr.GetDecimal(0);
                        textBox20.Value = dr.IsDBNull(1) ? System.DBNull.Value : (object)dr.GetDecimal(1);
                        textBox25.Value = dr.IsDBNull(2) ? System.DBNull.Value : (object)dr.GetDecimal(2);
                    }
                    else
                    { textBox15.Value = textBox20.Value = textBox25.Value = System.DBNull.Value; }
                    dr.Close();

                    gaolu.Value = 3;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox16.Value = dr.IsDBNull(0) ? System.DBNull.Value : (object)dr.GetDecimal(0);
                        textBox21.Value = dr.IsDBNull(1) ? System.DBNull.Value : (object)dr.GetDecimal(1);
                        textBox26.Value = dr.IsDBNull(2) ? System.DBNull.Value : (object)dr.GetDecimal(2);
                    }
                    else
                    { textBox16.Value = textBox21.Value = textBox26.Value = System.DBNull.Value; }
                    dr.Close();

                    gaolu.Value = 4;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox17.Value = dr.IsDBNull(0) ? System.DBNull.Value : (object)dr.GetDecimal(0);
                        textBox22.Value = dr.IsDBNull(1) ? System.DBNull.Value : (object)dr.GetDecimal(1);
                        textBox27.Value = dr.IsDBNull(2) ? System.DBNull.Value : (object)dr.GetDecimal(2);
                    }
                    else
                    { textBox17.Value = textBox22.Value = textBox27.Value = System.DBNull.Value; }
                    dr.Close();

                    gaolu.Value = 5;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox18.Value = dr.IsDBNull(0) ? System.DBNull.Value : (object)dr.GetDecimal(0);
                        textBox23.Value = dr.IsDBNull(1) ? System.DBNull.Value : (object)dr.GetDecimal(1);
                        textBox28.Value = dr.IsDBNull(2) ? System.DBNull.Value : (object)dr.GetDecimal(2);
                    }
                    else
                    { textBox18.Value = textBox23.Value = textBox28.Value = System.DBNull.Value; }
                    dr.Close();

                    cmd.CommandText = "SELECT ROUND(SUM(竖球)*100/(SUM(机烧矿)+SUM(竖球)),2) FROM 原料消耗 WHERE 日期=:RQ-1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = dateTimePicker1.Value.Date;
                    try { textBox8.Value = ((decimal)cmd.ExecuteScalar()); }
                    catch { textBox8.Value = DBNull.Value; }

                    cn.Close();
                    this.ddjsylTableAdapter1.FillByRQ(this.调度数据集1.DDJSYL, this.dateTimePicker1.Value.Date);
                    this.ddhuiTableAdapter1.FillByRQ(this.调度数据集1.DDHUI, this.dateTimePicker1.Value.Date);
                    break;
                case "JSB":
                    cn = new OracleConnection();
                    cn.ConnectionString = Properties.Settings.Default.ltznConnectionString;
                    cn.Open();
                    cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT JSB FROM DDJSB WHERE RQ=:RQ";
                    cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = this.dateTimePicker1.Value.Date;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        textBoxJSB.Text = dr.IsDBNull(0) ? "" : dr.GetString(0);
                    else
                        textBoxJSB.Text = "";
                    dr.Close();
                    cn.Close();
                    break;
                //case "STLR":
                //    if (System.DateTime.Today >= dateTimePicker1.Value.AddDays(-2))
                //    {
                //        try
                //        { 
                //           selectLuci(this.dateTimePicker1.Value.Date, this.InputCHUTE1.Text, this.InputCHUTE2.Value);
                //        }
                //        catch(Exception ex)
                //        {
                //            MessageBox.Show("出错：+" + ex);
                //        }
                   
                //    }
                //    break;
                case "tpst":
                    if (System.DateTime.Today >= dateTimePicker1.Value.AddDays(-2))
                    {
                        loadDdLuCi();
                       

                    }
                    break;
                case "YLXH":
                    ylxhData.LoadData(tabControl2.SelectedIndex + 1, dateTimePicker1.Value.Date);

                    //V2.88
                    //qingkong();
 
                    //this.oracleConnection1.Open();
                    //NEWSELECT原料消耗.Parameters["RQ"].Value = dateTimePicker1.Value.Date;
                    //NEWSELECT原料消耗.Parameters["GAOLU"].Value = tabControl2.SelectedIndex + 1;
                    //NEWSELECT原料消耗.ExecuteNonQuery();
                    //ylxhT1.Value = NEWSELECT原料消耗.Parameters["JISHAO"].Value;
                    //ylxhT2.Value = NEWSELECT原料消耗.Parameters["SHUQIU"].Value;
                    //ylxhT3.Value = NEWSELECT原料消耗.Parameters["BENXI"].Value;
                    //ylxhT4.Value = NEWSELECT原料消耗.Parameters["GONGYI"].Value;
                    //ylxhT5.Value = NEWSELECT原料消耗.Parameters["JIAODING"].Value;
                    //ylxhT6.Value = NEWSELECT原料消耗.Parameters["MEIFEN"].Value;
                    //ylxhT7.Value = NEWSELECT原料消耗.Parameters["FUYANG"].Value;
                    //ylxhT8.Value = NEWSELECT原料消耗.Parameters["ZICHAN"].Value;
                    //ylxhT9.Value = NEWSELECT原料消耗.Parameters["LUODI"].Value;
                    //ylxhT10.Value = NEWSELECT原料消耗.Parameters["SHULIAO"].Value;

                    //ylxhTPB.Value = NEWSELECT原料消耗.Parameters["PBKUAI"].Value;
                    //ylxhTFMG.Value = NEWSELECT原料消耗.Parameters["FMGKUAI"].Value;
                    //ylxhTGS.Value = NEWSELECT原料消耗.Parameters["GUISHI"].Value;
                    //ylxhTSWS.Value = NEWSELECT原料消耗.Parameters["SHEWENSHI"].Value;
                    //ylxhTYS.Value = NEWSELECT原料消耗.Parameters["YINGSHI"].Value;
                    //ylxhTBYS.Value = NEWSELECT原料消耗.Parameters["BAIYUNSHI"].Value;
                    //ylxhTTQ.Value = NEWSELECT原料消耗.Parameters["TAIQIU"].Value;
                    //ylxhTMK.Value = NEWSELECT原料消耗.Parameters["MENGKUANG"].Value;

                    //if (NEWSELECT原料消耗.Parameters["SHULIAOMC"].Value == System.DBNull.Value)
                    //    ylxhT11.Text = "其它熟料";
                    //else
                    //    ylxhT11.Text = (string)NEWSELECT原料消耗.Parameters["SHULIAOMC"].Value;
                    //ylxhT12.Value = NEWSELECT原料消耗.Parameters["SHENGLIAO"].Value;
                    //if (NEWSELECT原料消耗.Parameters["SHENGLIAOMC"].Value == System.DBNull.Value)
                    //    ylxhT13.Text = "其它生料";
                    //else
                    //    ylxhT13.Text = (string)NEWSELECT原料消耗.Parameters["SHENGLIAOMC"].Value;

                    //this.oracleConnection1.Close();
                    break;
            }
            更改 = false;
            pDate = dateTimePicker1.Value.Date;
          
            buttonSave.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        public List<ddluci> luciList = new List<ddluci>();

        private void c1FlexGrid1_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (MessageBox.Show("您确实要删除记录吗？", "询问", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
                this.更改 = true;
        }

        private void c1FlexGrid1_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid1[e.Row, 0] = "煤粉";
            c1FlexGrid1[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;
        }

        private void c1FlexGrid2_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid2[e.Row, 0] = "外进焦";
            c1FlexGrid2[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;

        }

        private void c1FlexGrid3_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid3[e.Row, 0] = "自产焦";
            c1FlexGrid3[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;
        }

        private void c1FlexGrid4_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid4[e.Row, 0] = "1#大烧";
            c1FlexGrid4[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;
        }

        private void c1FlexGrid5_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid5[e.Row, 0] = 1;
            c1FlexGrid5[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;
        }

        private void c1FlexGrid6_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            int hour = Convert.ToInt32(Math.Floor((double)(this.dateTimePicker1.Value.Hour / 2)) * 2);
           
          //  if ((原料权限 & 1)!=0)
            //{
               // c1FlexGrid6[e.Row, 0] = "1#大烧";
          //  }
           /// else if ((原料权限 & 2)!=0)
           // {
               // c1FlexGrid6[e.Row, 0] = "2#大烧";
           // }
            //else if ((原料权限 & 4) != 0)
           // {
                //c1FlexGrid6[e.Row, 0] = "竖球";
           // }

            c1FlexGrid6[e.Row, 2] = this.dateTimePicker1.Value.Date+TimeSpan.FromHours(hour);
            c1FlexGrid6[e.Row, 3] = "5#";
            string[] mc = new string[8] { "1#大烧", "1#大烧", "2#大烧", "2#大烧", "竖球", "竖球", "竖球",  "竖球" };
            string[] cang = new string[8] { "5#", "1--4#", "5#", "1--4#", "1--4#", "5#", "1/1", "1/2" };
            bool[] fand = new bool[8];
            for (int i = 1; i < e.Row; i++)
            {
                if(c1FlexGrid6[i, 1].ToString() == c1FlexGrid6[e.Row, 1].ToString())
                {
                    for(int j=0;j<fand.Length;j++)
                    {
                        if(c1FlexGrid6[i, 0].ToString()==mc[j] && c1FlexGrid6[i, 2].ToString()==cang[j])
                            fand[j]=true;
                    }
                }
            }
            for (int j = fand.Length-1; j >=0 ; j--)
            {
                if (!fand[j])
                {
                    c1FlexGrid6[e.Row, 0] = mc[j];
                    c1FlexGrid6[e.Row, 3] = cang[j];
                }
            }
            更改 = true;
            buttonSave.Enabled = true;

        }

        private void c1FlexGrid7_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid7[e.Row, 0] = "1#大烧";
            c1FlexGrid7[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;
        }

        private void c1FlexGrid8_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            c1FlexGrid8[e.Row, 0] = "瓦斯灰";
            c1FlexGrid8[e.Row, 1] = this.dateTimePicker1.Value;
            更改 = true;
            buttonSave.Enabled = true;
        }

      


        private void InputNumber_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                      ((C1NumericEdit)sender).Value = System.DBNull.Value;
                      break;
                  case Keys.Enter:
                      ((Control)sender).Parent.Parent.SelectNextControl((Control)sender,true,true,true,false);
                      break;
                  case Keys.Down:
                      ((Control)sender).Parent.Parent.SelectNextControl((Control)sender, true, true, true, false);
                      break;
                  case Keys.Up:
                      ((Control)sender).Parent.Parent.SelectNextControl((Control)sender,false, true, true, false);
                      break;
            }

        }
        private void qingkong()
        {
            ylxhT1.Value = 0;
            ylxhT2.Value = 0;
            ylxhT3.Value = 0;
            ylxhT4.Value = 0;
            ylxhT5.Value = 0;
            ylxhT6.Value = 0;
            ylxhT7.Value = 0;
            ylxhT8.Value = 0;
            ylxhT9.Value = 0;
            ylxhT10.Value = 0;
            ylxhT11.Value = 0;
            ylxhT12.Value = 0;

            ylxhT13.Value = 0;
            ylxhT14.Value = 0;
            ylxhT15.Value = 0;

            ylxhT16.Value = 0;
            ylxhT17.Value = 0;
            ylxhT18.Value = 0;

            ylxhT19.Value = 0;
           

        }
        // 消耗情况从生产日报提取数据
        private void button1_Click(object sender, EventArgs e)
        {
            ylxhData.ImportData(tabControl2.SelectedIndex + 1, dateTimePicker1.Value.Date);
           
            ////v2.88
            //qingkong();
   
            //OracleConnection cn = new OracleConnection();
            //cn.ConnectionString = Properties.Settings.Default.ltznConnectionString;
            //cn.Open();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = cn;
            //cmd.CommandText = "SELECT  MC,NVL(BAIBAN,0)+NVL(ZHONGBAN,0)+NVL(YEBAN,0),BEIZHU FROM RBXIAOHAO WHERE TRUNC(SJ)=:RQ AND GAOLU=:GAOLU";
            //cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = dateTimePicker1.Value.Date;
            //cmd.Parameters.Add(":GAOLU", OracleType.Int32).Value = tabControl2.SelectedIndex+1;
            //OracleDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    string mc = "";
            //    if (!dr.IsDBNull(0))
            //        mc = dr.GetString(0);
            //    switch (mc)
            //    {
            //        case "烧结矿":
            //            ylxhT1.Value= dr.GetDecimal(1);
            //            break;
            //        case "竖炉球":
            //            ylxhT2.Value = dr.GetDecimal(1);
            //            break;
            //        case "本溪矿":
            //            ylxhT3.Value = dr.GetDecimal(1);
            //            break;
            //        case "焦炭":
            //            ylxhT4.Value = dr.GetDecimal(1);
            //            break;
            //        case "焦丁":
            //            ylxhT5.Value = dr.GetDecimal(1);
            //            break;
            //        case "喷煤":
            //            ylxhT6.Value = dr.GetDecimal(1);
            //            break;
            //        case "富氧量":
            //            ylxhT7.Value = dr.GetDecimal(1);
            //            break;
            //        case "PB块":
            //            ylxhTPB.Value = dr.GetDecimal(1);
            //            break;
            //        case "FMG块":
            //            ylxhTFMG.Value = dr.GetDecimal(1);
            //            break;
            //        case "硅石":
            //            ylxhTGS.Value = dr.GetDecimal(1);
            //            break;
            //        case "蛇纹石":
            //            ylxhTSWS.Value = dr.GetDecimal(1);
            //            break;
            //        case "萤石":
            //            ylxhTYS.Value = dr.GetDecimal(1);
            //            break;
            //        case "白云石":
            //            ylxhTBYS.Value = dr.GetDecimal(1);
            //            break;
            //        case "钛球":
            //            ylxhTTQ.Value = dr.GetDecimal(1);
            //            break;
            //        case "锰矿":
            //            ylxhTMK.Value = dr.GetDecimal(1);
            //            break;
            //        case "其它熟料":   
            //            ylxhT10.Value = dr.GetDecimal(1);
            //            if (!dr.IsDBNull(2))
            //                ylxhT11.Text = dr.GetString(2);
            //            break;
            //        case "其它生料":
            //            ylxhT12.Value = dr.GetDecimal(1);
            //            if (!dr.IsDBNull(2))
            //                ylxhT13.Text = dr.GetString(2);
            //            break;

            //    }
            //}
            //dr.Close();
            //cn.Close();

        }

        //计算反矿率
        private void textBox5_ValueChanged(object sender, EventArgs e)
        {
            if (textBox4.Value != DBNull.Value && textBox5.Value != DBNull.Value && (decimal)textBox4.Value > 0)
            {
                textBox7.Value =decimal.Parse(((decimal)((decimal)textBox5.Value*100 / (decimal)textBox4.Value)).ToString("#####0.00"));
            }
            else
                textBox7.Value = DBNull.Value;

        }

        //其它选项卡输入焦点转移
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    ((C1NumericEdit)sender).Value = System.DBNull.Value;
                    break;
                case Keys.Enter:
                    ((Control)sender).Parent.SelectNextControl((Control)sender, true, true, true, false);
                    break;
                case Keys.Down:
                    ((Control)sender).Parent.SelectNextControl((Control)sender, true, true, true, false);
                    break;
                case Keys.Up:
                    ((Control)sender).Parent.SelectNextControl((Control)sender, false, true, true, false);
                    break;
            }
        }

        //保存
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (this.tabControl1.SelectedTab.Name)
            {   case "DDTTY":
                    c1FlexGrid9.FinishEditing();
                    CurrencyManager cm9 = (CurrencyManager)BindingContext[c1FlexGrid9.DataSource, c1FlexGrid9.DataMember];
                    cm9.EndCurrentEdit();
                    this.dDTTYTableAdapter.Update(this.调度数据集1.DDTTY);
                    break;  
                case "MFFX":
                    c1FlexGrid1.FinishEditing();
                    CurrencyManager cm1 = (CurrencyManager)BindingContext[c1FlexGrid1.DataSource, c1FlexGrid1.DataMember];
                    cm1.EndCurrentEdit();
                    this.ddmfTableAdapter1.Update(this.调度数据集1.DDMF);
                    break;
                case "JTFX":
                    c1FlexGrid2.FinishEditing();
                    CurrencyManager cm2 = (CurrencyManager)BindingContext[c1FlexGrid2.DataSource, c1FlexGrid2.DataMember];
                    cm2.EndCurrentEdit();
                    this.ddjtTableAdapter1.Update(this.调度数据集1.DDJT);
                    break;
                case "JTLD":
                    c1FlexGrid3.FinishEditing();
                    CurrencyManager cm3 = (CurrencyManager)BindingContext[c1FlexGrid3.DataSource, c1FlexGrid3.DataMember];
                    cm3.EndCurrentEdit();
                    this.ddldTableAdapter1.Update(this.调度数据集1.DDLD);
                    break;
                case "JSLD":
                    c1FlexGrid4.FinishEditing();
                    CurrencyManager cm4 = (CurrencyManager)BindingContext[c1FlexGrid4.DataSource, c1FlexGrid4.DataMember];
                    cm4.EndCurrentEdit();
                    this.ddjsTableAdapter1.Update(this.调度数据集1.DDJS);
                    break;
                case "MQFX":
                    c1FlexGrid5.FinishEditing();
                    CurrencyManager cm5 = (CurrencyManager)BindingContext[c1FlexGrid5.DataSource, c1FlexGrid5.DataMember];
                    cm5.EndCurrentEdit();
                    this.ddmqTableAdapter1.Update(this.调度数据集1.DDMQ);
                    break;
                case "YLFX":
                    c1FlexGrid6.FinishEditing();
                    CurrencyManager cm6 = (CurrencyManager)BindingContext[c1FlexGrid6.DataSource, c1FlexGrid6.DataMember];
                    cm6.EndCurrentEdit();
                    this.ddylTableAdapter1.Update(this.调度数据集1.DDYL);
                    break;
                case "QT":
                    OracleConnection cn = new OracleConnection();
                    cn.ConnectionString = Properties.Settings.Default.ltznConnectionString;
                    cn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE DDQT set YB=:YB,BB=:BB,ZB=:ZB,FK=:FK,MK=:MK,JK=:JK  WHERE RQ=:RQ";
                    cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = pDate;
                    cmd.Parameters.Add(":YB", OracleType.Number).Value = textBox1.Value;
                    cmd.Parameters.Add(":BB", OracleType.Number).Value = textBox2.Value;
                    cmd.Parameters.Add(":ZB", OracleType.Number).Value = textBox3.Value;
                    cmd.Parameters.Add(":FK", OracleType.Number).Value = textBox4.Value;
                    cmd.Parameters.Add(":MK", OracleType.Number).Value = textBox5.Value;
                    cmd.Parameters.Add(":JK", OracleType.Number).Value = textBox6.Value;
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        cmd.CommandText = "INSERT INTO DDQT(RQ,YB,BB,ZB,FK,MK,JK) VALUES(:RQ,:YB,:BB,:ZB,:FK,:MK,:JK)";
                        cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = pDate;
                        cmd.Parameters.Add(":YB", OracleType.Number).Value = textBox1.Value;
                        cmd.Parameters.Add(":BB", OracleType.Number).Value = textBox2.Value;
                        cmd.Parameters.Add(":ZB", OracleType.Number).Value = textBox3.Value;
                        cmd.Parameters.Add(":FK", OracleType.Number).Value = textBox4.Value;
                        cmd.Parameters.Add(":MK", OracleType.Number).Value = textBox5.Value;
                        cmd.Parameters.Add(":JK", OracleType.Number).Value = textBox6.Value;
                        if (0 == cmd.ExecuteNonQuery())
                            MessageBox.Show("出现错误");
                    }
                    cn.Close();

                    c1FlexGrid7.FinishEditing();
                    CurrencyManager cm7 = (CurrencyManager)BindingContext[c1FlexGrid7.DataSource, c1FlexGrid7.DataMember];
                    cm7.EndCurrentEdit();
                    this.ddjsylTableAdapter1.Update(this.调度数据集1.DDJSYL);

                    c1FlexGrid8.FinishEditing();
                    CurrencyManager cm8 = (CurrencyManager)BindingContext[c1FlexGrid8.DataSource, c1FlexGrid8.DataMember];

                    cm8.EndCurrentEdit();
                    this.ddhuiTableAdapter1.Update(this.调度数据集1.DDHUI);
                    break;
                case "JSB":
                    cn = new OracleConnection();
                    cn.ConnectionString = Properties.Settings.Default.ltznConnectionString;
                    cn.Open();
                    cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE DDJSB set JSB=:JSB  WHERE RQ=:RQ";
                    cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = pDate;
                    cmd.Parameters.Add(":JSB", OracleType.VarChar).Value = textBoxJSB.Text;
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        cmd.CommandText = "INSERT INTO DDJSB(RQ,JSB) VALUES(:RQ,:JSB)";
                        cmd.Parameters.Add(":RQ", OracleType.DateTime).Value = pDate;
                        cmd.Parameters.Add(":JSB", OracleType.VarChar).Value = textBoxJSB.Text;
                        if (0 == cmd.ExecuteNonQuery())
                            MessageBox.Show("出现错误");
                    }
                    cn.Close();
                    break;
               
                case "YLXH":
                    if (button1.Enabled)
                    {
                        ylxhData.SaveData(tabControl2.SelectedIndex + 1, pDate);
                        //this.oracleConnection1.Open();
                        //NEWUPDATE原料消耗.Parameters["RQ"].Value = pDate;
                        //NEWUPDATE原料消耗.Parameters["GAOLU"].Value = tabControl2.SelectedIndex + 1;
                        //NEWUPDATE原料消耗.Parameters["JISHAO"].Value = ylxhT1.Value;
                        //NEWUPDATE原料消耗.Parameters["SHUQIU"].Value = ylxhT2.Value;
                        //NEWUPDATE原料消耗.Parameters["BENXI"].Value = ylxhT3.Value;
                        //NEWUPDATE原料消耗.Parameters["GONGYI"].Value = ylxhT4.Value;
                        //NEWUPDATE原料消耗.Parameters["JIAODING"].Value = ylxhT5.Value;
                        //NEWUPDATE原料消耗.Parameters["MEIFEN"].Value = ylxhT6.Value;
                        //NEWUPDATE原料消耗.Parameters["FUYANG"].Value = ylxhT7.Value;
                        //NEWUPDATE原料消耗.Parameters["ZICHAN"].Value = ylxhT8.Value;
                        //NEWUPDATE原料消耗.Parameters["LUODI"].Value = ylxhT9.Value;
                        //NEWUPDATE原料消耗.Parameters["SHULIAO"].Value = ylxhT10.Value;
                        //NEWUPDATE原料消耗.Parameters["SHULIAOMC"].Value = ylxhT11.Text;
                        //NEWUPDATE原料消耗.Parameters["SHENGLIAO"].Value = ylxhT12.Value;
                        //NEWUPDATE原料消耗.Parameters["SHENGLIAOMC"].Value = ylxhT13.Text;

                        //NEWUPDATE原料消耗.Parameters["PBKUAI"].Value = ylxhTPB.Value;
                        //NEWUPDATE原料消耗.Parameters["FMGKUAI"].Value = ylxhTFMG.Value;
                        //NEWUPDATE原料消耗.Parameters["GUISHI"].Value = ylxhTGS.Value;
                        //NEWUPDATE原料消耗.Parameters["SHEWENSHI"].Value = ylxhTSWS.Value;
                        //NEWUPDATE原料消耗.Parameters["YINGSHI"].Value = ylxhTYS.Value;
                        //NEWUPDATE原料消耗.Parameters["BAIYUNSHI"].Value = ylxhTBYS.Value;
                        //NEWUPDATE原料消耗.Parameters["TAIQIU"].Value = ylxhTTQ.Value;
                        //NEWUPDATE原料消耗.Parameters["MENGKUANG"].Value = ylxhTMK.Value;
                        //NEWUPDATE原料消耗.Parameters["BIAOZHI"].Value = 1;

                        //NEWUPDATE原料消耗.ExecuteNonQuery();
                        //this.oracleConnection1.Close();
                    }
                    break;

            }
            更改 = false;
            buttonSave.Enabled = false;
            this.Cursor = Cursors.Default;
            
        }

        private void c1FlexGrid2_CellChanged(object sender, RowColEventArgs e)
        {
            CellStyle cs = c1FlexGrid2.Styles["CustomStyle1"];
            switch (e.Col)
            {
                case 3:
                    if (c1FlexGrid2[e.Row, e.Col] != DBNull.Value && Convert.ToDouble(c1FlexGrid2[e.Row, e.Col]) > 12.8)
                        c1FlexGrid2.SetCellStyle(e.Row, e.Col, cs);
                    break;
                case 5:
                    if (c1FlexGrid2[e.Row, e.Col] != DBNull.Value && Convert.ToDouble(c1FlexGrid2[e.Row, e.Col]) >= 0.68)
                        c1FlexGrid2.SetCellStyle(e.Row, e.Col, cs);
                    break;
                case 7:
                    if (c1FlexGrid2[e.Row, e.Col] != DBNull.Value && Convert.ToDouble(c1FlexGrid2[e.Row, e.Col]) < 91)
                        c1FlexGrid2.SetCellStyle(e.Row, e.Col, cs);
                    break;
                case 8:
                    if (c1FlexGrid2[e.Row, e.Col] != DBNull.Value && Convert.ToDouble(c1FlexGrid2[e.Row, e.Col]) > 6)
                        c1FlexGrid2.SetCellStyle(e.Row, e.Col, cs);
                    break;

            }
        }

        private void c1FlexGrid3_CellChanged(object sender, RowColEventArgs e)
        {
            CellStyle cs = c1FlexGrid3.Styles["CustomStyle1"];
            if (e.Col == 6 && c1FlexGrid3[e.Row, e.Col] != DBNull.Value && Convert.ToDouble(c1FlexGrid3[e.Row, e.Col]) > 8)
                c1FlexGrid3.SetCellStyle(e.Row, e.Col, cs);
        }

        private void c1FlexGrid6_CellChanged(object sender, RowColEventArgs e)
        {
            //CellStyle cs = c1FlexGrid6.Styles["CustomStyle1"];
            //string colName = c1FlexGrid6.Cols[e.Col].Name;
            //switch (colName)
            //{
            //    case "SiO2":
            //        if (c1FlexGrid6[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid6[e.Row, 0]) == "竖球" && Convert.ToDouble(c1FlexGrid6[e.Row, e.Col]) > 7)
            //            c1FlexGrid6.SetCellStyle(e.Row, e.Col, cs);
            //        break;
            //    case "FeO":
            //        if (c1FlexGrid6[e.Row, e.Col] != DBNull.Value && (Convert.ToString(c1FlexGrid6[e.Row, 0]) == "1#大烧" || Convert.ToString(c1FlexGrid6[e.Row, 0]) == "2#大烧") && Convert.ToDouble(c1FlexGrid6[e.Row, e.Col]) > 13)
            //            c1FlexGrid6.SetCellStyle(e.Row, e.Col, cs);
            //        if (c1FlexGrid6[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid6[e.Row, 0]) == "竖球" && Convert.ToDouble(c1FlexGrid6[e.Row, e.Col]) > 2)
            //            c1FlexGrid6.SetCellStyle(e.Row, e.Col, cs);
            //        break;
            //    case "S":
            //        if (c1FlexGrid6[e.Row, e.Col] != DBNull.Value && (Convert.ToString(c1FlexGrid6[e.Row, 0]) == "1#大烧" || Convert.ToString(c1FlexGrid6[e.Row, 0]) == "2#大烧") && Convert.ToDouble(c1FlexGrid6[e.Row, e.Col]) > 0.04)
            //            c1FlexGrid6.SetCellStyle(e.Row, e.Col, cs);
            //        if (c1FlexGrid6[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid6[e.Row, 0]) == "小烧" && Convert.ToDouble(c1FlexGrid6[e.Row, e.Col]) > 0.04)
            //            c1FlexGrid6.SetCellStyle(e.Row, e.Col, cs);
            //        break;
            //    case "TiO2":
            //        if (c1FlexGrid6[e.Row, e.Col] != DBNull.Value && Convert.ToDouble(c1FlexGrid6[e.Row, e.Col]) >= 0.3)
            //            c1FlexGrid6.SetCellStyle(e.Row, e.Col, cs);
            //        break;
            //}
        }

        private void c1FlexGrid4_CellChanged(object sender, RowColEventArgs e)
        {
             CellStyle cs = c1FlexGrid4.Styles["CustomStyle1"];
             switch (e.Col)
             {
                 case 8:
                     if (c1FlexGrid4[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid4[e.Row, 0]) == "大烧" && Convert.ToDouble(c1FlexGrid4[e.Row, e.Col]) < 64)
                         c1FlexGrid4.SetCellStyle(e.Row, e.Col, cs);
                     if (c1FlexGrid4[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid4[e.Row, 0]) == "小烧" && Convert.ToDouble(c1FlexGrid4[e.Row, e.Col]) < 75)
                         c1FlexGrid4.SetCellStyle(e.Row, e.Col, cs);
                     if (c1FlexGrid4[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid4[e.Row, 0]) == "竖球" && Convert.ToDouble(c1FlexGrid4[e.Row, e.Col]) < 94)
                         c1FlexGrid4.SetCellStyle(e.Row, e.Col, cs);
                     break;
                 case 10:
                     if (c1FlexGrid4[e.Row, e.Col] != DBNull.Value && Convert.ToString(c1FlexGrid4[e.Row, 0]) == "竖球" && Convert.ToDouble(c1FlexGrid4[e.Row, e.Col]) < 2.23)
                         c1FlexGrid4.SetCellStyle(e.Row, e.Col, cs);
                     break;
             }

        }


        private void c1FlexGrid2Alarm()
        {
            CellStyle cs = c1FlexGrid2.Styles["CustomStyle1"];
            foreach (Row r in c1FlexGrid2.Rows)
            {
                if (r.Index>0 && !r.IsNew)
                {
                    if (r[3] != DBNull.Value && Convert.ToDouble(r[3]) > 12.8)    //灰份
                         c1FlexGrid2.SetCellStyle(r.Index, 3, cs);

                     if (r[5] != DBNull.Value && Convert.ToDouble(r[5]) >= 0.68)  //S
                         c1FlexGrid2.SetCellStyle(r.Index, 5, cs);

                     if (r[7] != DBNull.Value && Convert.ToDouble(r[7]) < 91)   //M25
                         c1FlexGrid2.SetCellStyle(r.Index, 7, cs);

                     if (r[8] != DBNull.Value && Convert.ToDouble(r[8]) > 6)     //M10
                         c1FlexGrid2.SetCellStyle(r.Index, 8, cs);
                }    
            }
        }

        private void c1FlexGrid3Alarm()
        {
            CellStyle cs = c1FlexGrid3.Styles["CustomStyle1"];
            foreach (Row r in c1FlexGrid3.Rows)
            {
                if (r.Index > 0 && !r.IsNew)
                {
                     if (r[6]!=DBNull.Value &&  Convert.ToDouble(r[6]) > 8)    //粒度<25
                             c1FlexGrid3.SetCellStyle(r.Index, 6, cs);
                }
            }
        }

        private void c1FlexGrid4Alarm()
        {
            CellStyle cs = c1FlexGrid4.Styles["CustomStyle1"];
            foreach (Row r in c1FlexGrid4.Rows)
            {
                if (r.Index > 0 && !r.IsNew)
                {
                    if (Convert.ToString(r[0]) == "1#大烧" || Convert.ToString(r[0]) == "5#高炉机烧")
                    {
                        if ((this.原料权限 & 1) == 0)
                            r.AllowEditing = false;
                        else
                            r.AllowEditing = true;
                    }

                    if (Convert.ToString(r[0]) == "2#大烧" || Convert.ToString(r[0]) == "1-4#高炉机烧")
                    {
                        if ((this.原料权限 & 2) == 0)
                            r.AllowEditing = false;
                        else
                            r.AllowEditing = true;
                    }

                    if (Convert.ToString(r[0]) == "竖球")
                    {
                        if ((this.原料权限 & 4) == 0)
                            r.AllowEditing = false;
                        else
                            r.AllowEditing = true;

                    }
                   //转鼓
                    if (r[8] != DBNull.Value && Convert.ToString(r[0]) == "大烧" && Convert.ToDouble(r[8]) < 64)
                        c1FlexGrid4.SetCellStyle(r.Index , 8, cs);
                    if (r[8] != DBNull.Value && Convert.ToString(r[0]) == "小烧" && Convert.ToDouble(r[8]) < 75)
                        c1FlexGrid4.SetCellStyle(r.Index, 8, cs);
                    if (r[8] != DBNull.Value && Convert.ToString(r[0]) == "竖球" && Convert.ToDouble(r[8]) < 94)
                        c1FlexGrid4.SetCellStyle(r.Index, 8, cs);
                    //抗压
                    if (r[10] != DBNull.Value && Convert.ToString(r[0]) == "竖球" && Convert.ToDouble(r[10]) < 2.23)
                        c1FlexGrid4.SetCellStyle(r.Index, 10, cs);
                }
            }
        }

        private void c1FlexGrid6Alarm()
        {
            CellStyle cs = c1FlexGrid6.Styles["CustomStyle1"];
            foreach (Row r in c1FlexGrid6.Rows)
            {
                if (r.Index > 0 && !r.IsNew)
                {
                    if (Convert.ToString(r["MC"]) == "1#大烧")
                    {
                        if ((this.原料权限 & 1) == 0)
                            r.AllowEditing = false;
                        else
                            r.AllowEditing = true;
                    }

                    if (Convert.ToString(r["MC"]) == "2#大烧")
                    {
                        if ((this.原料权限 & 2) == 0)
                            r.AllowEditing = false;
                        else
                            r.AllowEditing = true;
                    }

                    if (Convert.ToString(r["MC"]) == "竖球")
                    {
                        if ((this.原料权限 & 4) == 0)
                            r.AllowEditing = false;
                        else
                            r.AllowEditing = true;

                    }
                ////SiO2
                //if (r["SiO2"] != DBNull.Value &&  Convert.ToString(r["MC"]) == "竖球" && Convert.ToDouble(r["SiO2"]) > 7)
                //    c1FlexGrid6.SetCellStyle(r.Index,, cs);
                ////FeO
                //if (r["FeO"] != DBNull.Value && (Convert.ToString(r["MC"]) == "1#大烧" || Convert.ToString(r["MC"]) == "2#大烧") && Convert.ToDouble(r["FeO"]) > 13)
                //    c1FlexGrid6.SetCellStyle(r.Index,6, cs);
                //if (r["FeO"] != DBNull.Value &&  Convert.ToString(r[0]) == "竖球" && Convert.ToDouble(r["FeO"]) > 2)
                //    c1FlexGrid6.SetCellStyle(r.Index,6, cs);
                ////S
                //if (r["S"] != DBNull.Value && (Convert.ToString(r["MC"]) == "1#大烧" || Convert.ToString(r["MC"]) == "2#大烧") && Convert.ToDouble(r["S"]) > 0.04)
                //    c1FlexGrid6.SetCellStyle(r.Index,8, cs);
                //if (r["S"] != DBNull.Value &&  Convert.ToString(r[0]) == "小烧" && Convert.ToDouble(r["S"]) > 0.04)
                //    c1FlexGrid6.SetCellStyle(r.Index,8, cs);
                ////TiO2
                //if (r["TiO2"] != DBNull.Value && Convert.ToDouble(r["TiO2"]) >= 0.3)
                //    c1FlexGrid6.SetCellStyle(r.Index,10, cs);
                }
            }
        }

        //更改
        private void InputG1_03_TextChanged(object sender, EventArgs e)
        {
            更改 = true;
            buttonSave.Enabled = true;
            if (sender.GetType() == typeof(C1NumericEdit))
            {
                C1NumericEdit c1 = (C1NumericEdit)sender;
                if (c1.Name.Contains("_10"))
                {
                    if (!c1.ValueIsDbNull)
                        if (Convert.ToDouble(c1.Value) > 0.7)
                           c1.BackColor = Color.Red;
                        else
                           c1.BackColor = Color.FromArgb(192, 255, 192);
                    else
                        c1.BackColor = Color.FromArgb(192, 255, 192);
                }
                if (c1.Name.Contains("_12"))
                {
                    if (!c1.ValueIsDbNull)
                        if (Convert.ToDouble(c1.Value) > 0.08)
                            c1.BackColor = Color.Red;
                        else
                            c1.BackColor = Color.FromArgb(192, 255, 192);
                    else
                        c1.BackColor = Color.FromArgb(192, 255, 192);
                }
                if (c1.Name.Contains("_13"))
                {
                    if (!c1.ValueIsDbNull)
                        if (Convert.ToDouble(c1.Value) > 0.035)
                            c1.BackColor = Color.Red;
                        else
                            c1.BackColor = Color.FromArgb(192, 255, 192);
                    else
                        c1.BackColor = Color.FromArgb(192, 255, 192);
                }
            }

        }

        private void c1FlexGrid_ChangeEdit(object sender, EventArgs e)
        {
            更改 = true;
            buttonSave.Enabled = true;
        }

        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (自动保存 && 更改)
            {
                buttonSave_Click(null, null);
            }
            else
            {
                if (提示保存 && 更改)
                {
                    DialogResult dr = MessageBox.Show("数据已修改是否保存？", "提示", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Cancel)
                        e.Cancel = true;
                    if (dr == DialogResult.Yes)
                        buttonSave_Click(null, null);
                }
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            instance_UserChanged(LtznUserManager.instance.CurrentUser);

            if (!更新) return;
            if (dateTimePicker1.Value.Date == pDate) return;
            if (自动保存 && 更改)
            {
                buttonSave_Click(null, null);
            }
            else
            {
                if (提示保存 && 更改)
                {
                    DialogResult dr = MessageBox.Show("数据已修改是否保存？", "提示", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        dateTimePicker1.Value = pDate;
                        return;
                    }
                    if (dr == DialogResult.Yes)
                        buttonSave_Click(null, null);
                }
            }
            tabControl1_TabIndexChanged(null, null);
        }

      

       
     
      

        private void c1FlexGrid9_AfterAddRow(object sender, RowColEventArgs e)
        {
            更改 = true;
            buttonSave.Enabled = true;

        }

        private void grpFe6_Enter(object sender, EventArgs e)
        {

        }

        private void btnQuery_PlanOrder_Click(object sender, EventArgs e)
        {
            string strsql = "select luci as luhao,gaolu,to_char(zdsj,'yyyy-mm-dd hh24:mi:ss') as zdsj,banci,banluci from ddluci where to_char(zdsj,'yyyy-MM-dd')='" + dateTimePicker1 .Value.ToString("yyyy-MM-dd")+ "' and gaolu='"+comboBoxEdit1.Text.Trim().Substring(0,1)+"' order by zdsj ";
            gridControl_PlanOrder.DataSource = Rcw.Data.DbContext.GetDataTable(strsql);
            DxSetting.SetMultiSelect(gridView_PlanOrder);
            simpleButton2.Enabled = false;
        }

        private List<PlanOrder> PlanOrderList = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now.AddDays(-2) || dateTimePicker1.Value > DateTime.Now.AddDays(2))
            {
                MessageBox.Show("当前时间 不允许生成计划");
                return;
            }
            PlanOrderList = PlanOrder.GetList("gaolu=@gaolu order by xuhao ", comboBoxEdit1.Text.Trim());
            string strSql = "select max(luci) from ddluci where gaolu='" + comboBoxEdit1.Text.Substring(0, 1) + "'";
            var obj = DbContext.ExecuteScalar(strSql);
            int maxLuci = 1;
            if (obj == null || Convert.IsDBNull(obj))
            {
                MessageBox.Show("没有最大炉号");
                return;
            }
            else
            {
                maxLuci = Convert.ToInt32(obj);
            }

            foreach (var item in PlanOrderList)
            {
                item.LUHAO = (maxLuci + 1).ToString();
                maxLuci++;
            }
            gridControl_PlanOrder.DataSource = PlanOrderList;
            DxSetting.SetRowIndex(gridView_PlanOrder);
                
        }

        /// <summary>
        /// 生成计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            try
            {
                if (dateTimePicker1.Value < DateTime.Now.AddDays(-2) || dateTimePicker1.Value > DateTime.Now.AddDays(2))
                {
                    MessageBox.Show("当前时间 不允许生成计划");
                    return;
                }
                if (PlanOrderList.Count < 1)
                {
                    MessageBox.Show("没有计划！");
                    return;
                }

                var count = ddluci.GetList(" to_char(zdsj,'yyyy-MM-dd')='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and gaolu='"+ comboBoxEdit1.Text.Substring(0, 1) + "' ").Count;
                if (count > 0)
                {
                    if (MessageBox.Show("当前已存在计划，是否继续？","",MessageBoxButtons.YesNo)==DialogResult.No)
                    {
                        return;
                    }
                }
       
                List<ddluci> planLuciList = new List<ddluci>();

                foreach (var item in PlanOrderList)
                {
                    ddluci luci = new ddluci();
                    luci.GAOLU = item.GAOLU.Substring(0, 1);
                    luci.luci = item.LUHAO;
                    luci.zdsj = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd ") + item.ZDSJ + ":00");
                    //luci.kksj = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd ")  + "00:00:00");
                    //luci.dksj = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd ") + "00:00:00");
                    //luci.dgsj = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd ") + "00:00:00");
                    //luci.tzsj = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd ") + "00:00:00");
                    luci.BANCI = item.BANCI;
                    luci.quchu = "炼钢";
                    luci.BANLUCI = item.BANLUCI;
                    planLuciList.Add(luci);            
                }

                planLuciList.Update();
                MessageBox.Show("操作成功");
                planLuciList.Clear();
                gridView_PlanOrder.RefreshData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("操作失败："+ex.ToString());
            }
            

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            loadDdLuCi();
        }

        public void loadDdLuCi()
        {
            try
            {
                string sql = " to_char(zdsj,'yyyy-MM-dd')='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";
                if (comboBoxEdit3.Text != "高炉全部")
                {
                    sql += " and gaolu='" + comboBoxEdit3.Text.Trim().Substring(0,1) + "' ";
                }
                if (comboBoxEdit2.Text != "班次全部")
                {
                    sql += " and banci='" + comboBoxEdit2.Text.Trim() + "' ";
                }

                sql +=  " order by banluci,gaolu";
                luciList = ddluci.GetList(sql);
                //计算碱度R2
                foreach (var item in luciList)
                {
                    if (item.zhacao > 0 && item.zhasio2 > 0 && item.zhar2==null)
                    {
                        item.zhar2 = item.zhacao / item.zhasio2;
                        item.Save();
                    }
                }

                if (comboBoxEdit2.Text == "班次全部")
                {
                    List<ddluci> listTemp = new List<ddluci>();
                    listTemp.AddRange(luciList.Where(o => o.BANCI == "夜班"));
                    listTemp.AddRange(luciList.Where(o => o.BANCI == "白班"));
                    listTemp.AddRange(luciList.Where(o => o.BANCI == "中班"));
                    luciList = listTemp;
                }

                if (comboBoxEdit3.Text == "高炉全部")
                {
                    int i = 1;
                    List<ddluci> listTemp = new List<ddluci>();
                    foreach (var item in luciList)
                    {

                        if (item.BANLUCI != i.ToString())
                        {
                            i = Convert.ToInt16(item.BANLUCI);

                            ddluci kongHang = new ddluci();

                            listTemp.Add(kongHang);
                        }
                        listTemp.Add(item);
                    }
                    luciList = listTemp;
                }
               
                gridControl_ddluci.DataSource = luciList;
                DxSetting.SetRowIndex(gridView_ddluci);

                gridView_ddluci.RefreshData();
                gridView_ddluci.BestFitColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show("出错：+" + ex);
            }
        }



        List<wdjg> wdjgList = null;
        private void btnUpdate_PlanOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value < DateTime.Now.AddDays(-2)||dateTimePicker1.Value>DateTime.Now.AddDays(2))
                {
                    MessageBox.Show("当前时间的数据不允许修改");
                    return;
                }

                if (wdjgList == null)
                {
                    wdjgList = wdjg.GetList();
                }
                //修改时间节点 并计算晚点时间  计算料批
                foreach (var item in luciList)
                {
                    if (item.luci.IsNullOrEmpty())
                    {
                        item.DataState = DataRowState.Unchanged;
                        continue;
                    }
                    if (item.DataState == DataRowState.Modified)
                    {
                       
                        if (item.dgsj != null && item.dksj != null)
                        {


                            xiuZheng(item.dgsj, item.zdsj);
                            xiuZheng(item.dksj, item.zdsj);

                            double wdjg = 50;
                            try
                            {
                                wdjg = wdjgList.FirstOrDefault(o => o.GAOLU == item.GAOLU).wdsj;
                            }
                            catch
                            {

                            }


                            //出铁时间 大于整点时间
                            if ((item.dksj > item.zdsj) && item.dksj - item.dgsj > TimeSpan.FromMinutes(wdjg))
                            {
                                if (item.zdsj - item.dgsj < TimeSpan.FromMinutes(wdjg))
                                {
                                    //出铁时间-对罐时间-间隔
                                    item.wdsj = Math.Floor((Convert.ToDateTime(item.dksj) - Convert.ToDateTime(item.dgsj) - TimeSpan.FromMinutes(wdjg)).TotalMinutes);
                                }
                                else
                                {
                                    item.wdsj = Math.Floor(((TimeSpan)(item.dksj - item.zdsj)).TotalMinutes);
                                }
                            }
                            else
                            {
                                item.wdsj = 0;
                            }
                            try
                            {
                                //计算料批
                                string strSql = "select count(distinct pishu)  from lt_liao where  t>(select dksj from ddluci where luci='" + (Convert.ToInt32(item.luci) - 1).ToString() + "') and t<=(select dksj from ddluci where luci='" + item.luci + "')";
                                var obj = DbContext.ExecuteScalar(strSql);
                                item.liaopi = Convert.ToDouble(obj);
                            }
                            catch(Exception ex)
                            {
                                string a = ex.ToString();
                            }

                        }


                    }

                }
                luciList.Update();
                MessageBox.Show("操作成功！");
                loadDdLuCi();
            }
            catch(Exception ex)
            {
                MessageBox.Show("出现异常" + ex.ToString());
                loadDdLuCi();
            }

         
        }

        public void xiuZheng(DateTime? xzTime, DateTime? zdTime)
        {
            DateTime xztime = Convert.ToDateTime(xzTime);
            DateTime zdtime = Convert.ToDateTime(zdTime);
            if (zdtime.Hour < 3)
            {
                if (xztime.Hour > 20)
                {
                    xztime = Convert.ToDateTime(zdtime.AddDays(-1).ToString("yyyy-MM-dd") + " " + xztime.ToString("HH:mm:ss"));
                }
                else
                {
                    xztime = Convert.ToDateTime(zdtime.ToString("yyyy-MM-dd") + " " + xztime.ToString("HH:mm:ss"));
                }

            }
            else if (zdtime.Hour > 22)
            {
                if (xztime.Hour < 5)
                {
                    xztime = Convert.ToDateTime(zdtime.AddDays(1).ToString("yyyy-MM-dd") + " " + xztime.ToString("HH:mm:ss"));
                }
                else
                {
                    xztime = Convert.ToDateTime(zdtime.ToString("yyyy-MM-dd") + " " + xztime.ToString("HH:mm:ss"));
                }
            }
            else
            {

                xztime = Convert.ToDateTime(zdtime.ToString("yyyy-MM-dd") + " " + xztime.ToString("HH:mm:ss"));
            }
           
        }

        private void gridView_ddluci_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string str = e.Column.Name;
            int hand = e.RowHandle;
            if (hand < 0) return;
            var luci = this.gridView_ddluci.GetRow(hand) as ddluci;
            if (luci == null) return;
            if (luci.zdsj==null)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            if (str == "colfesi"|| str == "colfep" || str == "colfes" || str == "coldksj")
            {
                
                if (str == "colfesi"&&luci.fesi > 0.7)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (str == "colfep" && luci.fep > 0.08)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (str == "colfes" && luci.fes > 0.035)
                {
                    e.Appearance.ForeColor = Color.Red;
                }

                //if (str == "coldksj")
                //{
                //    if (!(Convert.ToDateTime(luci.dksj).Hour == 0 && Convert.ToDateTime(luci.dksj).Minute == 0))
                //    {
                //        e.Appearance.BackColor = Color.LightGreen;
                //    }              
                //}
               
            }
                    
        }

        /// <summary>
        /// 删除炉次计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_PlanOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value < DateTime.Now.AddDays(-2))
                {
                    MessageBox.Show("当前时间的数据不允许删除");
                    return;
                }

                var currow = gridView_ddluci.GetFocusedRow() as ddluci;
                if (currow.luci.IsNullOrEmpty()||currow.luci.Contains("*"))
                {
                    MessageBox.Show("当前数据铁次为空不允许删除");
                    return;
                }

                var lclist = ddluci.GetList(" gaolu=@gaolu and luci >=@luci and zdsj >=@zdsj", currow.GAOLU, currow.luci,DateTime.Now.AddDays(-1));
                var lc = lclist.Where(o => o.luci == currow.luci).FirstOrDefault();
                if (lc == null)
                {
                    MessageBox.Show("该铁次不存在");
                    loadDdLuCi();
                }
                else
                {
                    if (MessageBox.Show("确认要删除这行数据，炉次："+ currow.luci+"将下移？","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (var item in lclist)
                        {
                            if (item.luci != currow.luci)
                            {
                                item.luci = (Convert.ToInt32(item.luci) - 1).ToString();
                            }
                            else
                            {
                                item.DataState = DataRowState.Deleted;
                            }
                        }

                        lclist.Update();

                    }
                   
                    loadDdLuCi();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存失败，出现异常" + ex.ToString());
                loadDdLuCi();
            }
            


        }

       

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDdLuCi();

        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadDdLuCi();
        }
    }
}
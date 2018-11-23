using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rcw.Method;
using Rcw.Data;


namespace LTZN
{
    public partial class PlanOrderFrm : Form
    {
        public PlanOrderFrm()
        {
            DbContext.Create<PlanOrder>();
            InitializeComponent();
            comboBoxEdit1.SelectedIndex = 0;
            
        }
        List<PlanOrder> PlanOrderList = new List<PlanOrder>();

        /// <summary>
        /// 获取窗体的名称
        /// </summary>
        /// <returns></returns>
        public string GetFormName()
        {
            return this.Text;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// 
        public void loadData()
        {

            PlanOrderList = PlanOrder.GetList("gaolu=@gaolu order by xuhao ",comboBoxEdit1.Text.Trim());
            gridControl_PlanOrder.DataSource = PlanOrderList;
         
        }
      
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_PlanOrder_Click(object sender, EventArgs e)
        {
            loadData();
        }
        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_PlanOrder_Click(object sender, EventArgs e)
        {
           
            foreach (var item in PlanOrderList)
            {
                if (item.ZDSJ == "")
                {
                    MessageBox.Show("整点时间不能为空！");
                    return;                      
                }
            }
            //修改操作，如果其他值修改，在ForEach中修改
            //datalist.ForEach(o => o.DataState = DataRowState.Deleted);
            PlanOrderList.Update();
            loadData();

        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_PlanOrder_Click(object sender, EventArgs e)
        {
            PlanOrder newRow = new PlanOrder();
            int xh = 1, lc = 1;
            string yeban = "夜班";
            int timespan = 0;
            DateTime lastZdsj = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            foreach (var item in PlanOrderList)
            {
                DateTime curZdsj = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")+" "+item.ZDSJ+":00");
                timespan =Convert.ToInt16( (curZdsj - lastZdsj).TotalMinutes);
                lastZdsj = curZdsj;
                xh = Convert.ToInt16(item.XUHAO)+1;
                lc = Convert.ToInt16(item.BANLUCI) + 1;
                yeban = item.BANCI;
            }

            newRow.ZDSJ = lastZdsj.AddMinutes(timespan).ToString("HH:mm");
            newRow.GAOLU = comboBoxEdit1.Text.Trim();
            newRow.XUHAO = xh;
            newRow.BANLUCI = lc.ToString();
            newRow.BANCI = yeban;
            PlanOrderList.Add(newRow);
            gridView_PlanOrder.RefreshData();
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_PlanOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要删除所选数据吗") == DialogResult.OK)
            {
                var curRow = gridView_PlanOrder.GetFocusedRow() as PlanOrder;
                curRow.DataState = DataRowState.Deleted;
                PlanOrderList.Update();
                loadData();
            }                   
        }
           
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
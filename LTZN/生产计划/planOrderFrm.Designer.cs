namespace LTZN
{
    partial class PlanOrderFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuery_PlanOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate_PlanOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd_PlanOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete_PlanOrder = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1_PlanOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl_PlanOrder = new DevExpress.XtraGrid.GridControl();
            this.gridView_PlanOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnc_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumngaolu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnxuhao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnbanci = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnbanluci = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnzdsj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnluhao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.flowLayoutPanel1_PlanOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PlanOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_PlanOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery_PlanOrder
            // 
            this.btnQuery_PlanOrder.ImageOptions.ImageUri.Uri = "Zoom;Size16x16";
            this.btnQuery_PlanOrder.Location = new System.Drawing.Point(109, 8);
            this.btnQuery_PlanOrder.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnQuery_PlanOrder.Name = "btnQuery_PlanOrder";
            this.btnQuery_PlanOrder.Size = new System.Drawing.Size(75, 23);
            this.btnQuery_PlanOrder.TabIndex = 1;
            this.btnQuery_PlanOrder.Text = "查询";
            this.btnQuery_PlanOrder.Click += new System.EventHandler(this.btnQuery_PlanOrder_Click);
            // 
            // btnUpdate_PlanOrder
            // 
            this.btnUpdate_PlanOrder.ImageOptions.ImageUri.Uri = "Edit;Size16x16";
            this.btnUpdate_PlanOrder.Location = new System.Drawing.Point(271, 8);
            this.btnUpdate_PlanOrder.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnUpdate_PlanOrder.Name = "btnUpdate_PlanOrder";
            this.btnUpdate_PlanOrder.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate_PlanOrder.TabIndex = 2;
            this.btnUpdate_PlanOrder.Text = "保存";
            this.btnUpdate_PlanOrder.Click += new System.EventHandler(this.btnUpdate_PlanOrder_Click);
            // 
            // btnAdd_PlanOrder
            // 
            this.btnAdd_PlanOrder.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btnAdd_PlanOrder.Location = new System.Drawing.Point(190, 8);
            this.btnAdd_PlanOrder.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnAdd_PlanOrder.Name = "btnAdd_PlanOrder";
            this.btnAdd_PlanOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAdd_PlanOrder.TabIndex = 3;
            this.btnAdd_PlanOrder.Text = "添加";
            this.btnAdd_PlanOrder.Click += new System.EventHandler(this.btnAdd_PlanOrder_Click);
            // 
            // btnDelete_PlanOrder
            // 
            this.btnDelete_PlanOrder.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.btnDelete_PlanOrder.Location = new System.Drawing.Point(469, 8);
            this.btnDelete_PlanOrder.Margin = new System.Windows.Forms.Padding(120, 8, 3, 3);
            this.btnDelete_PlanOrder.Name = "btnDelete_PlanOrder";
            this.btnDelete_PlanOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDelete_PlanOrder.TabIndex = 4;
            this.btnDelete_PlanOrder.Text = "删除";
            this.btnDelete_PlanOrder.Click += new System.EventHandler(this.btnDelete_PlanOrder_Click);
            // 
            // flowLayoutPanel1_PlanOrder
            // 
            this.flowLayoutPanel1_PlanOrder.Controls.Add(this.comboBoxEdit1);
            this.flowLayoutPanel1_PlanOrder.Controls.Add(this.btnQuery_PlanOrder);
            this.flowLayoutPanel1_PlanOrder.Controls.Add(this.btnAdd_PlanOrder);
            this.flowLayoutPanel1_PlanOrder.Controls.Add(this.btnUpdate_PlanOrder);
            this.flowLayoutPanel1_PlanOrder.Controls.Add(this.btnDelete_PlanOrder);
            this.flowLayoutPanel1_PlanOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1_PlanOrder.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1_PlanOrder.Name = "flowLayoutPanel1_PlanOrder";
            this.flowLayoutPanel1_PlanOrder.Size = new System.Drawing.Size(827, 38);
            this.flowLayoutPanel1_PlanOrder.TabIndex = 0;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(3, 8);
            this.comboBoxEdit1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "6#高炉",
            "5#高炉",
            "3#高炉",
            "1#高炉"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 5;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // gridControl_PlanOrder
            // 
            this.gridControl_PlanOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_PlanOrder.Location = new System.Drawing.Point(0, 38);
            this.gridControl_PlanOrder.MainView = this.gridView_PlanOrder;
            this.gridControl_PlanOrder.Name = "gridControl_PlanOrder";
            this.gridControl_PlanOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3});
            this.gridControl_PlanOrder.Size = new System.Drawing.Size(827, 412);
            this.gridControl_PlanOrder.TabIndex = 2;
            this.gridControl_PlanOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_PlanOrder});
            // 
            // gridView_PlanOrder
            // 
            this.gridView_PlanOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnc_id,
            this.gridColumngaolu,
            this.gridColumnxuhao,
            this.gridColumnbanci,
            this.gridColumnbanluci,
            this.gridColumnzdsj,
            this.gridColumnluhao});
            this.gridView_PlanOrder.GridControl = this.gridControl_PlanOrder;
            this.gridView_PlanOrder.Name = "gridView_PlanOrder";
            // 
            // gridColumnc_id
            // 
            this.gridColumnc_id.Caption = "Id";
            this.gridColumnc_id.FieldName = "C_ID";
            this.gridColumnc_id.Name = "gridColumnc_id";
            // 
            // gridColumngaolu
            // 
            this.gridColumngaolu.Caption = "高炉";
            this.gridColumngaolu.FieldName = "GAOLU";
            this.gridColumngaolu.Name = "gridColumngaolu";
            this.gridColumngaolu.OptionsColumn.AllowEdit = false;
            this.gridColumngaolu.Visible = true;
            this.gridColumngaolu.VisibleIndex = 0;
            // 
            // gridColumnxuhao
            // 
            this.gridColumnxuhao.Caption = "序号";
            this.gridColumnxuhao.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumnxuhao.FieldName = "XUHAO";
            this.gridColumnxuhao.Name = "gridColumnxuhao";
            this.gridColumnxuhao.Visible = true;
            this.gridColumnxuhao.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumnbanci
            // 
            this.gridColumnbanci.Caption = "班次";
            this.gridColumnbanci.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumnbanci.FieldName = "BANCI";
            this.gridColumnbanci.Name = "gridColumnbanci";
            this.gridColumnbanci.Visible = true;
            this.gridColumnbanci.VisibleIndex = 2;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "夜班",
            "白班",
            "中班"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridColumnbanluci
            // 
            this.gridColumnbanluci.Caption = "班炉次";
            this.gridColumnbanluci.ColumnEdit = this.repositoryItemTextEdit2;
            this.gridColumnbanluci.FieldName = "BANLUCI";
            this.gridColumnbanluci.Name = "gridColumnbanluci";
            this.gridColumnbanluci.Visible = true;
            this.gridColumnbanluci.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Mask.EditMask = "n0";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // gridColumnzdsj
            // 
            this.gridColumnzdsj.Caption = "整点时间";
            this.gridColumnzdsj.ColumnEdit = this.repositoryItemTextEdit3;
            this.gridColumnzdsj.FieldName = "ZDSJ";
            this.gridColumnzdsj.Name = "gridColumnzdsj";
            this.gridColumnzdsj.Visible = true;
            this.gridColumnzdsj.VisibleIndex = 4;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:[0-5]\\d";
            this.repositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // gridColumnluhao
            // 
            this.gridColumnluhao.Caption = "炉号";
            this.gridColumnluhao.FieldName = "LUHAO";
            this.gridColumnluhao.Name = "gridColumnluhao";
            this.gridColumnluhao.OptionsColumn.AllowEdit = false;
            // 
            // PlanOrderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 450);
            this.Controls.Add(this.gridControl_PlanOrder);
            this.Controls.Add(this.flowLayoutPanel1_PlanOrder);
            this.Name = "PlanOrderFrm";
            this.Text = "生产计划";
            this.flowLayoutPanel1_PlanOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PlanOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_PlanOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1_PlanOrder;
        private DevExpress.XtraEditors.SimpleButton btnDelete_PlanOrder;
        private DevExpress.XtraEditors.SimpleButton btnAdd_PlanOrder;
        private DevExpress.XtraEditors.SimpleButton btnUpdate_PlanOrder;
        private DevExpress.XtraEditors.SimpleButton btnQuery_PlanOrder;      
        private DevExpress.XtraGrid.GridControl gridControl_PlanOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_PlanOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnc_id;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumngaolu;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnxuhao;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnbanci;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnbanluci;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnzdsj;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnluhao;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
    }
}
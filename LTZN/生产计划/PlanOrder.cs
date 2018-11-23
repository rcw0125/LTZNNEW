using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Rcw.Data;
using System.ComponentModel;
namespace LTZN
{
	
	[DisplayName("生产计划")]
	public class PlanOrder : DbEntity
	{
   		#region  属性    
      			
		private string _c_id;	
		/// <summary>
		/// Id
        /// </summary>		
		[DbTableColumn(IsPrimaryKey = true,IsGuid = true)]	
			
		[DisplayName("Id")]
        public string C_ID
        {
            get
            {
            	return _c_id; 
            }
            set
            {
                if (_c_id != value)
                {
                   _c_id = value;
                   RaisePropertyChanged("C_ID", true);	                   
                }
            }
        }        
				
		private string _gaolu;	
		/// <summary>
		/// 高炉
        /// </summary>		
			
			
		[DisplayName("高炉")]
        public string GAOLU
        {
            get
            {
            	return _gaolu; 
            }
            set
            {
                if (_gaolu != value)
                {
                   _gaolu = value;
                   RaisePropertyChanged("GAOLU", true);	                   
                }
            }
        }        
				
		private int _xuhao;	
		/// <summary>
		/// 序号
        /// </summary>		
			
			
		[DisplayName("序号")]
        public int XUHAO
        {
            get
            {
            	return _xuhao; 
            }
            set
            {
                if (_xuhao != value)
                {
                   _xuhao = value;
                   RaisePropertyChanged("XUHAO", true);	                   
                }
            }
        }        
				
		private string _banci;	
		/// <summary>
		/// 班次
        /// </summary>		
			
			
		[DisplayName("班次")]
        public string BANCI
        {
            get
            {
            	return _banci; 
            }
            set
            {
                if (_banci != value)
                {
                   _banci = value;
                   RaisePropertyChanged("BANCI", true);	                   
                }
            }
        }        
				
		private string _banluci;	
		/// <summary>
		/// 炉次
        /// </summary>		
			
			
		[DisplayName("炉次")]
        public string BANLUCI
        {
            get
            {
            	return _banluci; 
            }
            set
            {
                if (_banluci != value)
                {
                   _banluci = value;
                   RaisePropertyChanged("BANLUCI", true);	                   
                }
            }
        }        
				
		private string _zdsj;	
		/// <summary>
		/// 整点时间
        /// </summary>		
			
			
		[DisplayName("整点时间")]
        public string ZDSJ
        {
            get
            {
            	return _zdsj; 
            }
            set
            {
                if (_zdsj != value)
                {
                   _zdsj = value;
                   RaisePropertyChanged("ZDSJ", true);	                   
                }
            }
        }        
				
		private string _luhao;	
		/// <summary>
		/// 炉号
        /// </summary>		
			
			
		[DisplayName("炉号")]
        public string LUHAO
        {
            get
            {
            	return _luhao; 
            }
            set
            {
                if (_luhao != value)
                {
                   _luhao = value;
                   RaisePropertyChanged("LUHAO", true);	                   
                }
            }
        }        
				
		#endregion 属性
		
		#region  扩展方法
		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exist(string C_ID)
		{
			return DbContext.Exist<PlanOrder>("C_ID=@C_ID", C_ID);	  
		}
		
		/// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exist(string whereSql = "1=1", params object[] args)
        {
            return DbContext.Exist<PlanOrder>(whereSql, args);
        }
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(string C_ID)
		{
		
		    DbContext.ExeSql("delete from PlanOrder where  C_ID=@C_ID", C_ID);			
		    return true;				    
		}
		/// <summary>
		/// 获取数据列表
		/// </summary>
		public static List<PlanOrder> GetList(string whereSql="1=1", params object[] args)
		{
		    return DbContext.LoadDataByWhere<PlanOrder>(whereSql, args);
		}
		
		/// <summary>
		/// 根据主键ID获取实体模型
		/// </summary>
		public static PlanOrder GetModel(string C_ID)
		{		   
			return DbContext.GetModel<PlanOrder>("C_ID=@C_ID", C_ID);		    
		}
		/// <summary>
		/// 根据条件获取实体模型
		/// </summary>
		public static PlanOrder GetModel(string whereSql="1=1", params object[] args)
		{   
			return DbContext.GetModel<PlanOrder>(whereSql,args);    
		}
		/// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="whereSql">条件</param>
        /// <returns></returns>
		public static int Max(string colName, string whereSql = "1=1")
        {
            return DbContext.Max<PlanOrder>(colName, whereSql);
        }
		/// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="whereSql">条件</param>
        /// <returns></returns>
        public static string MaxString(string colName, string whereSql = "1=1")
        {
            return DbContext.MaxString<PlanOrder>(colName, whereSql);
        }
        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="whereSql">条件</param>
        /// <returns></returns>
        public static int Min(string colName, string whereSql = "1=1")
        {
            return DbContext.Min<PlanOrder>(colName, whereSql);
        }
        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="whereSql">条件</param>
        /// <returns></returns>
        public static string MinString(string colName, string whereSql = "1=1")
        {
            return DbContext.MinString<PlanOrder>(colName, whereSql);
        }
		/// <summary>
        /// 获取带选择框的Grid的选中行
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        public static List<PlanOrder> GetSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView gv) 
        {
            List<PlanOrder> dataList = new List<PlanOrder>();
            int[] row = gv.GetSelectedRows();
            foreach (var item in row)
            {
                var da = gv.GetRow(item) as PlanOrder;
                dataList.Add(da);
            }
            return dataList;
        }
        
		
		#endregion 扩展方法   
	}
}
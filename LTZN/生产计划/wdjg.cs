using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rcw.Data;
using System.ComponentModel;

namespace LTZN
{
    [DisplayName("晚点间隔")]
    public class wdjg:DbEntity
    {
        private string _c_id;
        /// <summary>
        /// Id
        /// </summary>		
        [DbTableColumn(IsPrimaryKey = true, IsGuid = true)]

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

        private double _wdsj;
        [DisplayName("晚点时间")]
        public double wdsj
        {
            get
            {
                return _wdsj;
            }
            set
            {
                if (_wdsj != value)
                {
                    _wdsj = value;
                    RaisePropertyChanged("wdsj", true);
                }
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public static List<wdjg> GetList(string whereSql = "1=1", params object[] args)
        {
            return DbContext.LoadDataByWhere<wdjg>(whereSql, args);
        }


    }
}

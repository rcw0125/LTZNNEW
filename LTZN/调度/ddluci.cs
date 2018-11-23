using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rcw.Data;

namespace LTZN
{
    public class ddluci :DbEntity
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

        [DisplayName("班炉次")]
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

        private string _luci;      
        [DisplayName("炉次")]
        public string luci
        {
            get
            {
                return _luci;
            }
            set
            {
                if (_luci != value)
                {
                    _luci = value;
                    RaisePropertyChanged("luci", true);
                }
            }
        }

        private DateTime? _zdsj;     
        [DisplayName("整点时间")]
        public DateTime? zdsj
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
                    RaisePropertyChanged("zdsj", true);
                }
            }
        }

        private DateTime? _dgsj;
        [DisplayName("对罐时间")]
        public DateTime? dgsj
        {
            get
            {
                return _dgsj;
            }
            set
            {
                if (_dgsj != value)
                {
                    _dgsj = value;
                    RaisePropertyChanged("dgsj", true);
                }
            }
        }

        private DateTime? _kksj;
        [DisplayName("开口时间")]
        public DateTime? kksj
        {
            get
            {
                return _kksj;
            }
            set
            {
                if (_kksj != value)
                {
                    _kksj = value;
                    RaisePropertyChanged("kksj", true);
                }
            }
        }

        private DateTime? _dksj;
        [DisplayName("出铁时间")]
        public DateTime? dksj
        {
            get
            {
                return _dksj;
            }
            set
            {
                if (_dksj != value)
                {
                    _dksj = value;
                    RaisePropertyChanged("dksj", true);
                }
            }
        }

        private DateTime? _tzsj;
        [DisplayName("通知时间")]
        public DateTime? tzsj
        {
            get
            {
                return _tzsj;
            }
            set
            {
                if (_tzsj != value)
                {
                    _tzsj = value;
                    RaisePropertyChanged("tzsj", true);
                }
            }
        }

        private double? _wdsj;
        [DisplayName("晚点时间")]
        public double? wdsj
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

        private string _quchu;
        [DisplayName("去向")]
        public string quchu
        {
            get
            {
                return _quchu;
            }
            set
            {
                if (_quchu != value)
                {
                    _quchu = value;
                    RaisePropertyChanged("quchu", true);
                }
            }
        }

        private double? _feliang;
        [DisplayName("产量")]
        public double? feliang
        {
            get
            {
                return _feliang;
            }
            set
            {
                if (_feliang != value)
                {
                    _feliang = value;
                    RaisePropertyChanged("feliang", true);
                }
            }
        }

        private double? _fec;
        [DisplayName("碳[C]")]
        [DbTableColumn(IsCalcColumn =true)]
        public double? fec
        {
            get
            {
                return _fec;
            }
            set
            {
                if (_fec != value)
                {
                    _fec = value;
                    RaisePropertyChanged("fec", true);
                }
            }
        }

        private double? _fesi;
        [DisplayName("硅[Si]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? fesi
        {
            get
            {
                return _fesi;
            }
            set
            {
                if (_fesi != value)
                {
                    _fesi = value;
                    RaisePropertyChanged("fesi", true);
                }
            }
        }

        private double? _femn;
        [DisplayName("锰[Mn]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? femn
        {
            get
            {
                return _femn;
            }
            set
            {
                if (_femn != value)
                {
                    _femn = value;
                    RaisePropertyChanged("femn", true);
                }
            }
        }
        private double? _fep;
        [DisplayName("磷[P]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? fep
        {
            get
            {
                return _fep;
            }
            set
            {
                if (_fep != value)
                {
                    _fep = value;
                    RaisePropertyChanged("fep", true);
                }
            }
        }

        private double? _fes;
        [DisplayName("硫[S]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? fes
        {
            get
            {
                return _fes;
            }
            set
            {
                if (_fes != value)
                {
                    _fes = value;
                    RaisePropertyChanged("fes", true);
                }
            }
        }

        private double? _feti;
        [DisplayName("钛[Ti]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? feti
        {
            get
            {
                return _feti;
            }
            set
            {
                if (_feti != value)
                {
                    _feti = value;
                    RaisePropertyChanged("feti", true);
                }
            }
        }

        private double? _fecr;
        [DisplayName("铬[Cr]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? fecr
        {
            get
            {
                return _fecr;
            }
            set
            {
                if (_fecr != value)
                {
                    _fecr = value;
                    RaisePropertyChanged("fecr", true);
                }
            }
        }
        private double? _feni;
        [DisplayName("镍[Ni]")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? feni
        {
            get
            {
                return _feni;
            }
            set
            {
                if (_feni != value)
                {
                    _feni = value;
                    RaisePropertyChanged("feni", true);
                }
            }
        }

        private double? _zhasio2;
        [DisplayName("渣SiO2")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? zhasio2
        {
            get
            {
                return _zhasio2;
            }
            set
            {
                if (_zhasio2 != value)
                {
                    _zhasio2 = value;
                    RaisePropertyChanged("zhasio2", true);
                }
            }
        }

        private double? _zhacao;
        [DisplayName("渣氧化钙")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? zhacao
        {
            get
            {
                return _zhacao;
            }
            set
            {
                if (_zhacao != value)
                {
                    _zhacao = value;
                    RaisePropertyChanged("zhacao", true);
                }
            }
        }

        private double? _zhamgo;
        [DisplayName("渣MgO")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? zhamgo
        {
            get
            {
                return _zhamgo;
            }
            set
            {
                if (_zhamgo != value)
                {
                    _zhamgo = value;
                    RaisePropertyChanged("zhamgo", true);
                }
            }
        }
        private double? _zhaal2o3;
        [DisplayName("渣Al2O3")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? zhaal2o3
        {
            get
            {
                return _zhaal2o3;
            }
            set
            {
                if (_zhaal2o3 != value)
                {
                    _zhaal2o3 = value;
                    RaisePropertyChanged("zhaal2o3", true);
                }
            }
        }

        private double? _zhas;
        [DisplayName("渣S")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? zhas
        {
            get
            {
                return _zhas;
            }
            set
            {
                if (_zhas != value)
                {
                    _zhas = value;
                    RaisePropertyChanged("zhas", true);
                }
            }
        }

        private double? _zhatio2;
        [DisplayName("渣TiO2")]
        [DbTableColumn(IsCalcColumn = true)]
        public double? zhatio2
        {
            get
            {
                return _zhatio2;
            }
            set
            {
                if (_zhatio2 != value)
                {
                    _zhatio2 = value;
                    RaisePropertyChanged("zhatio2", true);
                }
            }
        }

        private double? _zhar2;
        [DisplayName("渣R2")]

        public double? zhar2
        {
            get
            {
                return _zhar2;
            }
            set
            {
                if (_zhar2 != value)
                {
                    _zhar2 = value;
                    RaisePropertyChanged("zhar2", true);
                }
            }
        }

        private double _liaopi;
        [DisplayName("料批")]
        public double liaopi
        {
            get
            {
                return _liaopi;
            }
            set
            {
                if (_liaopi != value)
                {
                    _liaopi = value;
                    RaisePropertyChanged("liaopi", true);
                }
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public static List<ddluci> GetList(string whereSql = "1=1", params object[] args)
        {
            return DbContext.LoadDataByWhere<ddluci>(whereSql, args);
        }
    }
}

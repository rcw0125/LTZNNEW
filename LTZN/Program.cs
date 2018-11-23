using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Rcw.Data;
using Rcw.Method;
using System.Net;
using System.Net.Sockets;

namespace LTZN
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string oracleAddress = "192.168.39.201";
            if (GetLocalIP().Contains("192.168.38"))
            {
                oracleAddress = "192.168.38.28";
            }
            DbContext.AddDataSource("ltzn", DbContext.DbType.Oracle, oracleAddress, "liantie", "LF", "LF");           
            //DbContext.AddDataSource("ltzn", DbContext.DbType.Oracle, "192.168.2.204", "orcl", "LF", "LF");
            // DbContext.AddDataSource("ltzn", DbContext.DbType.Oracle, "192.168.2.3", "xgmes", "LF", "LF");
            DbContext.DefaultDataSourceName = "ltzn";
                   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Rcw.Method.SingleApplication.Run(new 炼铁智能主窗体());          
        }

        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }

        }
        public static void Log(string content)
        {
            File.WriteAllText(@"c:\temp.txt", content);
        }
    }
}
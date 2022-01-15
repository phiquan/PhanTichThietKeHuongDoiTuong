using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAO
{
    class ReportDAO
    {
        private static ReportDAO instance;

        public static ReportDAO Instance
        {
            get { if (instance == null) instance = new ReportDAO(); return instance; }
            private set { instance = value; }
        }

        private ReportDAO() { }

        public object see(int month)
        {
            string query = "select HoaDon.NgayInHoaDon as 'DateBill', Sum(HoaDon.TongTien) as 'TotalPrice' from HoaDon where HoaDon.NgayInHoaDon >= '2022-" + month + "-01' group by HoaDon.NgayInHoaDon";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public DataTable excel(int month)
        {
            string query = "select HoaDon.NgayInHoaDon as 'DateBill', Sum(HoaDon.TongTien) as 'TotalPrice' from HoaDon where HoaDon.NgayInHoaDon >= '2022-" + month + "-01' group by HoaDon.NgayInHoaDon";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

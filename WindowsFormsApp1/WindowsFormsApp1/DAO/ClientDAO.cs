using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAO
{
    class ClientDAO
    {
        private static ClientDAO instance;

        public static ClientDAO Instance
        {
            get { if (instance == null) instance = new ClientDAO(); return instance; }
            private set { instance = value; }
        }

        private ClientDAO() { }

        public object selectClient()
        {
            string query = "select KhachHang.IDKhachHang as 'ID', KhachHang.TenKhachHang as N'Tên Khách Hàng', KhachHang.Email, KhachHang.SDT, KhachHang.NgaySinh as N'Ngày Sinh' from KhachHang";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAO
{
    class CreateBillDAO
    {
        private static CreateBillDAO instance;

        public static CreateBillDAO Instance
        {
            get { if (instance == null) instance = new CreateBillDAO(); return instance; }
            private set { instance = value; }
        }

        private CreateBillDAO() { }

        public object selectCreateBill()
        {
            string query = "select Sach.IDSach as 'ID', Sach.TenSach, Sach.Gia as N'Giá' from Sach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public object getKhach()
        {
            string query = "select * from KhachHang";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void createBill(string date, string time, int idStaff)
        {
            string query = "Insert into HoaDon(NgayInHoaDon,GioInHoaDon,IDTaiKhoan) values('" + date + "','" + time + "'," + idStaff + ")";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public int getIdBill()
        {
            string query = " select Top(1) IDHoaDon from HoaDon order by IDHoaDon DESC";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            int id = int.Parse(result.Rows[0].ItemArray[0].ToString());
            return id;
        }
    }
}

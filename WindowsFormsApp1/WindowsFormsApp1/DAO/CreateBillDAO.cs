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

        public object selectInfoBill(int idBill)
        {
            string query = " select Sach.TenSach as N'Tên Sách', SUM(ChiTietHoaDon.SoLuong) as N'Số Lượng' from ChiTietHoaDon, Sach, HoaDon where HoaDon.IDHoaDon = ChiTietHoaDon.IDHoaDon and ChiTietHoaDon.IDSach = Sach.IDSach and ChiTietHoaDon.IDHoaDon = " + idBill + "Group by Sach.TenSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void addBook(int bill, int idBook)
        {
            string query = "insert into ChiTietHoaDon(IDSach,IDHoaDon,SoLuong) values(" + idBook + "," + bill + ",1)";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void deleteBook(int idBill, string Book)
        {
            string selectId = "select IDSach from Sach where Sach.TenSach = N'" + Book + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(selectId);
            int id = int.Parse(result.Rows[0].ItemArray[0].ToString());

            string query = "delete from ChiTietHoaDon where IDHoaDon=" + idBill + " and IDSach=" + id;
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public int getMoney(int idBill)
        {
            string query = " select SUM(Sach.Gia) from Sach, ChiTietHoaDon where ChiTietHoaDon.IDHoaDon = " + idBill + " and ChiTietHoaDon.IDSach = Sach.IDSach and Sach.Gia > 0";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            int money;
            try
            {
                money = int.Parse(result.Rows[0].ItemArray[0].ToString());
            }
            catch (Exception)
            {
                money = 0;
            }          
            return money;
        }
    }
}

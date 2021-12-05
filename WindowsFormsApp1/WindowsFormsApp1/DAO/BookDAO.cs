using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAO
{
    class BookDAO
    {

        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return instance; }
            private set { instance = value; }
        }

        private BookDAO() { }

        public object selectBook()
        {
            string query = "select Sach.IDSach as 'ID', Sach.TenSach as N'Tên Sách', Sach.NXB, Sach.TenTacGia as N'Tên Tác Giả', Sach.SoLuong as N'Số Lượng' from Sach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

    }
}

﻿using System;
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
            string query = "select Sach.IDSach as 'ID', Sach.TenSach , Sach.NXB, Sach.TenTacGia as N'Tên Tác Giả', Sach.SoLuong as N'Số Lượng', Sach.Gia from Sach";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public void add(string tenSach, string tenTacGia, string NXB, int soLuong,int Gia)
        {
            string query = "insert into Sach values(N'" + tenSach + "',N'" + NXB + "',N'" + tenTacGia + "'," + Gia + "," + soLuong + ")";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void delete(int id)
        {
            string query = "delete from Sach where IDSach=" + id;
            DataProvider.Instance.ExucuteNonQuery(query);
        }
        
        public void update(string tenSach, string tenTacGia, string NXB, int soLuong,int id,int Gia)
        {
            string query = " update Sach set TenSach=N'" + tenSach + "', NXB=N'" + NXB + "', TenTacGia=N'" + tenTacGia + "', SoLuong=" + soLuong + ", Gia=" + Gia + " where IDSach=" + id;
            DataProvider.Instance.ExucuteNonQuery(query);
        }
    }
}

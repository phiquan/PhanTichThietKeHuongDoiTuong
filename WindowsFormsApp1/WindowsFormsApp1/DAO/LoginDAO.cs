using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAO
{
    class LoginDAO
    {
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get { if (instance == null) instance = new LoginDAO(); return instance; }
            private set { instance = value; }
        }

        private LoginDAO() { }

        public bool LoginManager(string userName, string passWord)
        {
            string query = "SELECT * FROM TaiKhoan WHERE SDT=" + userName + " AND MatKhau='" + passWord + "' AND ID=1";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public bool LoginStaff(string userName, string passWord)
        {
            string query = "SELECT * FROM TaiKhoan WHERE SDT=" + userName + " AND MatKhau='" + passWord + "' AND ID=2";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

       
    }
}

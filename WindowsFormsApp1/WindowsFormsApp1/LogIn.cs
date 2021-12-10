using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.FormDisplayManager;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string user = txtPhone.Text;
            string pass = txtPass.Text;
            if (LoginManager(user, pass) == true || LoginStaff(user,pass) == true)
            {
                if(LoginManager(user,pass) == true)
                {
                    this.Hide();
                    DisplayManager manager = new DisplayManager();
                    manager.ShowDialog();
                }
                else
                {
                    this.Hide();
                    DisplayStaff staff = new DisplayStaff();
                    staff.idStaff = getId(user);
                    staff.nameStaff = getName(user);
                    staff.ShowDialog();

                    FormCreateBill formCreateBill = new FormCreateBill();
                    formCreateBill.idStaff = getId(user);

                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hoặc tài khoản sai!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool LoginManager(string user, string pass)
        {
            return LoginDAO.Instance.LoginManager(user, pass);
        }

        bool LoginStaff(string user, string pass)
        {
            return LoginDAO.Instance.LoginStaff(user, pass);
        }

        string getName(string phone)
        {
            return LoginDAO.Instance.getName(phone);
        }

        int getId(string phone)
        {
            return LoginDAO.Instance.getId(phone);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Dialog
{
    public partial class Client : Form
    {
        public string id, name, email, phone, money, level;
        public int idPhanLoai; //1. sửa; 2. thêm
        private void Client_Load(object sender, EventArgs e)
        {
            if(idPhanLoai == 2)
            {
                txtLevel.Text = "Đồng";
                txtMoney.Text = "0";
            }
            else
            {
                txtID.Text = id;
                txtName.Text = name;
                txtMoney.Text = money;
                txtLevel.Text = level;
                txtEmail.Text = email;
                txtPhone.Text = phone;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.Handled)
            {
                MessageBox.Show("Bạn phải nhâp số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        public Client()
        {
            InitializeComponent();
        }
    }
}

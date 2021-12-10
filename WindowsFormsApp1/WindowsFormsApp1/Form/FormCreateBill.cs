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

namespace WindowsFormsApp1
{
    public partial class FormCreateBill : Form
    {
        public int idStaff;
        public FormCreateBill()
        {
            InitializeComponent();
            txtSoHoaDon.Text = "";
            txtSoTienTra.Text = "";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnInBill.Enabled = false;
            
        }

        private void FormCreateBill_Load(object sender, EventArgs e)
        {
            dataGridViewBook.DataSource = CreateBillDAO.Instance.selectCreateBill();
            dataGridViewBook.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBook.Columns[0].Width = 20;
            dataGridViewBook.ClearSelection();

            cbbKhach.DataSource = CreateBillDAO.Instance.getKhach();
            cbbKhach.DisplayMember = "TenKhachHang";
            cbbKhach.ValueMember = "CapBac";

            cbbKhach.Text = "Không Có";

        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSach.Text))
            {
                (dataGridViewBook.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                dataGridViewBook.ClearSelection();
            }
            else
            {
                (dataGridViewBook.DataSource as DataTable).DefaultView.RowFilter = string.Format("TenSach LIKE '{0}%'", txtTenSach.Text);
                dataGridViewBook.ClearSelection();
            }
        }

        private void cbbKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbKhach.SelectedValue.ToString() == "Dong")
            {
                txtGiamGia.Text = "5%";
            }else if(cbbKhach.SelectedValue.ToString() == "Bac")
            {
                txtGiamGia.Text = "10%";
            }else if(cbbKhach.SelectedValue.ToString() == "Vang")
            {
                txtGiamGia.Text = "15%";
            }else if(cbbKhach.SelectedValue.ToString() == "Kim Cuong")
            {
                txtGiamGia.Text = "25%";
            }
          
        }

        private void txtSoHoaDon_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void txtSoTienTra_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "")
            {
                btnInBill.Enabled = true;
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            CreateBillDAO.Instance.createBill(date, time, idStaff);
            txtSoHoaDon.Text = CreateBillDAO.Instance.getIdBill().ToString();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}

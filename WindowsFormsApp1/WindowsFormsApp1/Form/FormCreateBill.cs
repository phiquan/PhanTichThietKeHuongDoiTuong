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
        public FormCreateBill()
        {
            InitializeComponent();
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

            if (cbbKhach.SelectedValue.ToString() == "Dong")
            {
                txtGiamGia.Text = "5%";
            }
            else if (cbbKhach.SelectedValue.ToString() == "Bac")
            {
                txtGiamGia.Text = "10%";
            }

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
            }
          
        }
    }
}

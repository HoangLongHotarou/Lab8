using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class OrderForm : Form
    {
        private BillBL _billBL;

        public OrderForm()
        {
            InitializeComponent();
            _billBL = new BillBL();
            LoadBills();
        }

        private void LoadBills()
        {
            dgvBills.DataSource = _billBL.GetAll();
            TranslateToVietnamese();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            object[] s = _billBL.Search(dtpFrom.Value);
            dgvBills.DataSource = s[0];
            tsslTotal.Text = "Tổng doanh thu: " + s[1];
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBills.Rows[e.RowIndex];
            OrderDetailForm orderDetailForm = new OrderDetailForm();
            if (row.Cells[0].Value.ToString() == "") return;
            orderDetailForm.LoadBillsDetail(int.Parse(row.Cells[0].Value.ToString()));
            orderDetailForm.ShowDialog();
        }

        private void TranslateToVietnamese()
        {
            dgvBills.Columns["ID"].HeaderText = "Mã số";
            dgvBills.Columns["Name"].HeaderText = "Tên";
            dgvBills.Columns["TableID"].HeaderText = "Mã bàn";
            dgvBills.Columns["Amount"].HeaderText = "Số tiền";
            dgvBills.Columns["Discount"].HeaderText = "Giảm giá";
            dgvBills.Columns["Tax"].HeaderText = "Thuế";
            dgvBills.Columns["Status"].HeaderText = "Trạng thái";
            dgvBills.Columns["CheckoutDate"].HeaderText = "Ngày trả";
            dgvBills.Columns["Account"].HeaderText = "Tài khoảng";
        }

        private void loadLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadBills();
        }
    }
}

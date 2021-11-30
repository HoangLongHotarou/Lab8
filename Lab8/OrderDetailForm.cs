using BusinessLogic;
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
    public partial class OrderDetailForm : Form
    {
        BillDetailBL billDetailBL;

        public OrderDetailForm()
        {
            InitializeComponent();
            billDetailBL = new BillDetailBL();
        }

        public void LoadBillsDetail(int id)
        {
            dgvBills.DataSource = billDetailBL.LoadDetailFromID(id);
            TranslateToVietnamese();
        }

        private void TranslateToVietnamese()
        {
            dgvBills.Columns["ID"].HeaderText = "Mã số";
            dgvBills.Columns["InvoiceID"].HeaderText = "Mã Bills";
            dgvBills.Columns["NAME"].HeaderText = "Tên";
            dgvBills.Columns["Quantity"].HeaderText = "Số lượng";
        }
    }
}

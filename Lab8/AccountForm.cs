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
    public partial class AccountForm : Form
    {
        private AccountBL _accountBL;

        public AccountForm()
        {
            InitializeComponent();
            _accountBL = new AccountBL();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvAccount.DataSource = _accountBL.GetAll();
            TranslateToVietnamese();
        }

        private void TranslateToVietnamese()
        {
            dgvAccount.Columns["AccountName"].HeaderText = "Tên tài khoản";
            dgvAccount.Columns["FullName"].HeaderText = "Tên người dùng";
            dgvAccount.Columns["Email"].HeaderText = "Email";
            dgvAccount.Columns["Tell"].HeaderText = "Số điên thoại";
            dgvAccount.Columns["DateCreated"].Visible = false;
            dgvAccount.Columns["Password"].Visible = false;
        }

        private void dgvAccount_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewRow currow = dgvAccount.Rows[e.RowIndex];
            //if(e.RowIndex>=0 && !indexs.Contains(e.RowIndex))
            //{
            //    indexs.Add(e.RowIndex);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvAccount.Rows[e.RowIndex];
            ModifyAccount form = new ModifyAccount();
            form.LoadUser(row.Cells[0].Value.ToString(),_accountBL);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void tsmiRole_Click(object sender, EventArgs e)
        {
         
        }

        private void tmsiDiary_Click(object sender, EventArgs e)
        {
           
        }
    }
}

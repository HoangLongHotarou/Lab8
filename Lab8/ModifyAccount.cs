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
    public partial class ModifyAccount : Form
    {
        private bool checkUpdate = false;

        public ModifyAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkUpdate == true)
            {
                UpdateInfor();
            }
            else
            {
                InsertInfor();
            }
        }

        internal void InsertInfor()
        {
            
        }

        internal void UpdateInfor()
        {
           
        }

        public void LoadUser(string account,AccountBL accountBL)
        {
            Account a = accountBL.Accounts.Find(x => x.AccountName == account);
            txtAccountName.Text = a.AccountName;
            txtEmail.Text = a.Email;
            txtPass.Text = a.Password;
            txtNumber.Text = a.Tell;
            txtFullName.Text = a.FullName;
        }
    }
}

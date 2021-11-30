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
    public partial class TableForm : Form
    {
        private TableBL _tableBL;
        private BillBL _billBL;
        private int _currentID;

        public TableForm()
        {
            InitializeComponent();
            _tableBL = new TableBL();
            _billBL = new BillBL();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            List<Table> tables = _tableBL.GetAll();
            foreach (Table table in tables)
            {
                Button button = new Button();
                button.Text = table.Name;
                button.Height = 40;
                button.Width = 80;
                button.Tag = table.ID;
                button.Click += TableButton_Click;
                flpTable.Controls.Add(button);
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            _currentID = Convert.ToInt32((sender as Button).Tag);
            dgvTableDetail.DataSource = _tableBL.Tables.FindAll(x=>x.ID==_currentID);
            dgvBill.DataSource = _billBL.GetAll().FindAll(x=>x.TableID==_currentID);
        }
    }
}

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
    public partial class FormAddCategory : Form
    {
        CategoryBL categoryBL;

        public FormAddCategory()
        {
            InitializeComponent();
            categoryBL = new CategoryBL();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i = categoryBL.Insert(new DataAccess.Category() {Name = txtName.Text,Type=int.Parse(txtType.Text) });
            if (i > 0) { MessageBox.Show("Thêm thành công"); }
            MessageBox.Show("Thêm thất bại");
        }
    }
}

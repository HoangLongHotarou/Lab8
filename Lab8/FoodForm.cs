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
    public partial class FoodForm : Form
    {
        private FoodBL foodBL;
        private CategoryBL categoryBL;

        public FoodForm()
        {
            InitializeComponent();
            foodBL = new FoodBL();
            categoryBL = new CategoryBL();
            LoadCategory();
        }

        private void LoadCategory()
        {
          
            cbbCategory.DataSource = categoryBL.GetAll();
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";

            if (cbbCategory.SelectedIndex == -1) return;
            
            string id;
            if (cbbCategory.SelectedValue is Category)
            {
                Category rowView = cbbCategory.SelectedValue as Category;
                id = rowView.ID.ToString();
            }
            else
            {
                id = cbbCategory.SelectedValue.ToString();
            }
            int _id = int.Parse(id);
            foodBL.Foods = foodBL.LoadFromID(_id);
            dgvFoodList.DataSource = foodBL.Foods;
            TranslateToVietnamese();
            lbQuantity.Text = "Số lượng: " + foodBL.Foods.Count;
            lbCat.Text = "Loại: " + cbbCategory.Text;
        }

        

        private void TranslateToVietnamese()
        {
            dgvFoodList.Columns["ID"].HeaderText = "Mã số";
            dgvFoodList.Columns["Name"].HeaderText = "Tên món ăn";
            dgvFoodList.Columns["Unit"].HeaderText = "Đơn vị tính";
            dgvFoodList.Columns["FoodCategoryID"].HeaderText = "Loại";
            dgvFoodList.Columns["Price"].HeaderText = "Đơn giá";
            dgvFoodList.Columns["Notes"].HeaderText = "Ghi chú";
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                BillDetailBL billDetailBL = new BillDetailBL();
                int result = billDetailBL.Quantity(int.Parse(selectedRow.Cells[0].Value.ToString()));
                MessageBox.Show($"Tổng số lượng món {selectedRow.Cells[1].Value} đã bán là {result} {selectedRow.Cells[2].Value}");
            }
        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);
        }

        private void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                Food rowView = (Food)selectedRow.DataBoundItem;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfor(rowView);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvFoodList.DataSource = foodBL.Search(txtSearch.Text);
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm form = new AccountForm();
            form.ShowDialog();
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            form.ShowDialog();
        }

        private void viDuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}

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
    public partial class Form1 : Form
    {
        List<Category> listCategory = new List<Category>();
        List<Food> listFood = new List<Food>();
        Food foodCurrent = new Food();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.ResetText();
            mudPrice.ResetText();
            txtUnit.ResetText();
            txtNotes.ResetText();
            if (cbbCategory.Items.Count > 0)
                cbbCategory.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodDataToListView();
        }

        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }

        public void LoadFoodDataToListView()
        {
            FoodBL foodBL = new FoodBL();
            listFood = foodBL.GetAll();
            int count = 1;
            lsvFood.Items.Clear();
            foreach (var food in listFood)
            {
                ListViewItem item = lsvFood.Items.Add(count.ToString());
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());

                string foodName = listCategory.Find(x => x.ID == food.FoodcategoryID).Name;
                item.SubItems.Add(foodName);
                item.SubItems.Add(food.Notes);
                count++;
            }
        }

        public int InsertFood()
        {
            Food food = new Food();
            food.ID = 0;

            if (txtName.Text == "" || txtUnit.Text == "" || mudPrice.Value == 0)
                MessageBox.Show("Chưa nhập dữ liệu");
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;

                int price = int.Parse(mudPrice.Value.ToString());
                food.Price = price;

                food.FoodcategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                FoodBL foodBL = new FoodBL();
                return foodBL.Insert(food);
            }
            return -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi phương thức thêm dữ liệu
            int result = InsertFood();
            if (result > 0) // Nếu thêm thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Thêm dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadFoodDataToListView();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void brnUpdate_Click(object sender, EventArgs e)
        {
            int result = UpdateFood();
            if (result > 0) // Nếu cập nhật thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Cập nhật dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadFoodDataToListView();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac mua xoa mau tinh nay", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FoodBL foodBL = new FoodBL();
                if (foodBL.Delete(foodCurrent) > 0)
                {
                    MessageBox.Show("Xoá thực phẩm thành công");
                    LoadFoodDataToListView();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công");
                }
            }
        }

        public int UpdateFood()
        {
            //Khai báo đối tượng Food và lấy đối tượng hiện hành
            Food food = foodCurrent;
            if (txtName.Text == "" || txtUnit.Text == "" || mudPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                int price = 0;
                try
                {
                    price = int.Parse(mudPrice.Text);
                }
                catch
                {
                    price = 0;
                }
                food.Price = price;
                food.FoodcategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                FoodBL foodBL = new FoodBL();
                return foodBL.Update(food);
            }
            return -1;
        }

        private void lsvFood_Click(object sender, EventArgs e)
        {
            int count = lsvFood.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem item = lsvFood.SelectedItems[0];
                foodCurrent = listFood[int.Parse(item.SubItems[0].Text) - 1];
                txtName.Text =foodCurrent.Name;
                txtUnit.Text = foodCurrent.Unit;
                mudPrice.Value = foodCurrent.Price;
                cbbCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodcategoryID);
            }
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

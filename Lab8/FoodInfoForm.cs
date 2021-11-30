using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            InitValues();
        }

        private void InitValues()
        { 
            CategoryBL categoryBL = new CategoryBL();
            cbbCat.DataSource = categoryBL.GetAll();
            cbbCat.DisplayMember = "Name";
            cbbCat.ValueMember = "ID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCat.ResetText();
            cbbCat.ResetText();
            nudPrice.ResetText();
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormAddCategory form = new FormAddCategory();
            form.ShowDialog();
            InitValues();
        }

        private Food GetInfor()
        {
            int id = 0;
            try
            {
                id = int.Parse(txtID.Text);
            }
            catch (Exception)
            {
            }
            return new Food()
            {
                ID = id,
                Name = txtName.Text,
                Unit = txtUnit.Text,
                FoodcategoryID = int.Parse(cbbCat.SelectedValue.ToString()),
                Price = int.Parse(nudPrice.Value.ToString()),
                Notes = txtNotes.Text
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FoodBL foodBL = new FoodBL();
            int i = foodBL.Insert(GetInfor());
            if (i > 0)
            {
                MessageBox.Show($"Thêm  thành công Món {txtName.Text}", "Message");
                this.ResetText();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        public void DisplayFoodInfor(Food rowView)
        {
            try
            {
                txtID.Text = rowView.ID.ToString();
                txtName.Text = rowView.Name;
                txtUnit.Text = rowView.Unit;
                txtNotes.Text = rowView.Notes;
                nudPrice.Text = rowView.Price.ToString();

                for (int index = 0; index < cbbCat.Items.Count; index++)
                {
                    Category cat = cbbCat.Items[index] as Category;
                    if (cat.ID.ToString() == rowView.FoodcategoryID.ToString())
                    {
                        cbbCat.SelectedIndex = index;
                        return;
                    }
                }
                cbbCat.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Lỗi");
                this.Close();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FoodBL foodBL = new FoodBL();
            int i = foodBL.Update(GetInfor());
            if (i > 0)
            {
                MessageBox.Show($"Sửa thành công Món {txtName.Text}", "Message");
                this.ResetText();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}

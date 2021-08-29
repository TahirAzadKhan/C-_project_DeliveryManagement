using Delivarymanagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivarymanagement.UI_Layer
{
    public partial class Category_Management : Form
    {
        
        CategoryService categoryService;
        int id;
        Home home;
        public Category_Management(Home home)
        {
            InitializeComponent();
            this.categoryService = new CategoryService();
            this.home = home;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = categoryService.GetCategoryById(Convert.ToInt32(textBox1.Text));
        }

        private void Category_Management_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Category_Management_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = categoryService.GetAllCategories();
        }
        void UpdateGridView()
        {
            dataGridView1.DataSource = categoryService.GetAllCategories();
        }
        void ClearText()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            int result = categoryService.AddCategory(textBox2.Text);
            if (result > 0)
            {
                MessageBox.Show("Category added successfully.");
                UpdateGridView();
                ClearText();
            }
            else
            {
                MessageBox.Show("Error occured..");
                ClearText();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int result = categoryService.EditCategory(id,textBox3.Text);
            if (result > 0)
            {
                MessageBox.Show("Category updated successfully.");
                UpdateGridView();
                ClearText();
            }
            else
            {
                MessageBox.Show("Error occured..");
                ClearText();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            DialogResult dresult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (dresult == DialogResult.Yes)
            {
                int result = categoryService.RemoveCategory(Convert.ToInt32(textBox4.Text));
                if (result > 0)
                {
                    MessageBox.Show("Category deleted successfully.");
                    UpdateGridView();
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Error occured..");
                    ClearText();
                }
            }
            else { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateGridView();
        }
    }
}

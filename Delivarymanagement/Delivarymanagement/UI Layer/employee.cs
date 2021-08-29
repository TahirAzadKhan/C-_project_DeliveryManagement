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
    public partial class employee : Form
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        int id;
        public employee()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string category = comboBox1.Text.ToString();

            int id = categoryService.GetIdByName(category.ToString());
            int result = productService.AddProduct(textBox2.Text, Convert.ToSingle(textBox3.Text), Convert.ToInt32(textBox7.Text), id, textBox9.Text, textBox10.Text, Convert.ToInt32(textBox11.Text));
            if (result > 0)
            {
                MessageBox.Show("Product added successfully.");
                UpdateGridView();
                ClearText();
            }
            else
            {
                MessageBox.Show("Error occured..");
                ClearText();
            }
        }
        void UpdateGridView()
        {
            dataGridView1.DataSource = productService.GetAllProducts();
        }
        void ClearText()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox9.Text = textBox10.Text = textBox11.Text= textBox7.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetAllProducts();
            ClearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetProductById(Convert.ToInt32(textBox1.Text));
        }
    }
}

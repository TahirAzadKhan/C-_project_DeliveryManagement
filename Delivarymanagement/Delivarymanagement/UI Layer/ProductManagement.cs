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
    public partial class ProductManagement : Form
    {
        ProductService productService;
        CategoryService categoryService;
        int id;
        Home home;
        public ProductManagement(Home home)
        {
            InitializeComponent();
            this.productService = new ProductService();
            this.categoryService = new CategoryService();
            this.home = home;
        }

        private void ProductManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetAllProducts();
            comboBox1.DataSource = categoryService.GetAllCategoryNames();
            comboBox2.DataSource = categoryService.GetAllCategoryNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetProductById(Convert.ToInt32(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetAllProducts();
            ClearText();
        }

        void UpdateGridView()
        {
            dataGridView1.DataSource = productService.GetAllProducts();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string category=comboBox1.Text.ToString();
            
            int id=categoryService.GetIdByName(category.ToString());
            int result = productService.AddProduct(textBox2.Text, Convert.ToSingle(textBox3.Text),Convert.ToInt32(textBox7.Text),id,textBox9.Text,textBox10.Text,Convert.ToInt32(textBox11.Text) );
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string category=comboBox1.Text.ToString();
           // int id=categoryService.GetIdByName(category.ToString());
            int result = productService.EditProduct(id,textBox4.Text, Convert.ToSingle(textBox5.Text),Convert.ToInt32(textBox8.Text),id);
            if (result > 0)
            {
                MessageBox.Show("Product updated successfully.");
                UpdateGridView();
                ClearText();
            }
            else
            {
                MessageBox.Show("Error occured..");
                ClearText();
            }
        }
        void ClearText()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            DialogResult dresult = MessageBox.Show("Are you sure?","Confirmation",MessageBoxButtons.YesNo);
            if (dresult == DialogResult.Yes)
            {
                int result = productService.RemoveProduct(Convert.ToInt32(textBox6.Text));
                if (result > 0)
                {
                    MessageBox.Show("Product deleted successfully.");
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

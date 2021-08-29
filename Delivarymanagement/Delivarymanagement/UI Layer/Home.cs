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
    public partial class Home : Form
    {
        LoginForm log;
        public Home(LoginForm log)
        {
            InitializeComponent();
            this.log = log;
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Show();
            this.Hide();
        }

        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_Management catMgt = new Category_Management(this);
            this.Hide();
            catMgt.Show();
        }

        private void manageProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductManagement proMgt = new ProductManagement(this);
            this.Hide();
            proMgt.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}

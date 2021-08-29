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
    public partial class RegistrationForm : Form
    {
        RegistrationService registration;
        LoginForm loginForm;
        public RegistrationForm(LoginForm login)
        {
            InitializeComponent();
            registration = new RegistrationService();
            loginForm = login;
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int type = 0;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Field Required");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    type = 1;
                }
                else { type = 2; }

                int result=registration.UserRegistration(textBox1.Text ,textBox2.Text ,textBox3.Text,textBox4.Text,textBox5.Text,type);
                if (result > 0)
                {
                    MessageBox.Show("User registration successfull.");
                    this.Hide();
                    loginForm.Show();

                }
                else
                {
                    MessageBox.Show("Error");

                }
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}

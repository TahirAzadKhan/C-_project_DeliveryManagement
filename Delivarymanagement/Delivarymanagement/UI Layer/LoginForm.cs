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
    public partial class LoginForm : Form
    {
        LoginService login;
        public LoginForm()
        {
            InitializeComponent();
            login = new LoginService();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm register = new RegistrationForm(this);
            this.Hide();
            register.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Username or Password can not be empty");
            }
            else
            {
                

                int result = login.LoginValidation(textBox1.Text, textBox2.Text);
                if (result > 0)
                {
                    if (result == 1)
                    {
                        Home home = new Home(this);
                        this.Hide();
                        home.Show();
                    }
                    else if (result == 2)
                    {
                        employee emp = new employee();
                        this.Hide();
                        emp.Show();


                    }
                    
                    else
                    {
                        MessageBox.Show("You do not have the priviledge");
                    }
                    
                    

                }
                else
                {
                    MessageBox.Show("Login Failed");

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_magazine
{
    public partial class LoginForm : Form
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            // Retrieve the user from the database based on the entered email
            var user = dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && VerifyPassword(password, user.Password))
            {
                MessageBox.Show("Login successful!");
               /* MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();*/
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }





        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }
    }
}

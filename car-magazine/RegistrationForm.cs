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
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext dbContext = new AppDbContext();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            var users = dbContext.Users.ToList();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||  string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter all required fields.");
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Check if the passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please enter the same password in both fields.");
                return;
            }

         

            // Save the new user
            var newUser = new User { Name = name, Email = email, Password = password };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            MessageBox.Show("Registration successful!");
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

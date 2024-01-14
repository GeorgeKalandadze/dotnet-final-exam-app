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
    public partial class CrudForm : Form
    {
        private readonly CarCrudService carCrudService;

        public CrudForm()
        {
            InitializeComponent();
            carCrudService = new CarCrudService(new AppDbContext());

        }

        /*  private void UpdateUserLabel()
          {
              User loggedInUser = CurrentUser.LoggedInUser;
              if (loggedInUser != null)
              {
                  label9.Text = $"Logged in as: {loggedInUser.Email}";
              }
              else
              {
                  label9.Text = "Not logged in";
              }
          }*/

        private void LoadUserCars()
        {
            var userCars = carCrudService.GetUserCars(CurrentUser.LoggedInUser.Id);
            dataGridView1.DataSource = userCars;
        }

        private void CrudForm_Load(object sender, EventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var categories = dbContext.Categories.ToList();

                category_combobox.Items.Clear();
                foreach (var category in categories)
                {
                    category_combobox.Items.Add(category.Name);
                }
            }
            LoadUserCars();

            /*UpdateUserLabel();*/
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string model = model_textbox.Text;
                decimal price = decimal.Parse(price_textbox.Text);
                int mileage = Convert.ToInt32(mileage_textbox.Text);
                string vinCode = vin_textbox.Text;
                int year = dateTimePicker1.Value.Year;
                string categoryName = category_combobox.SelectedItem?.ToString();

                carCrudService.CreateCar(model, price, mileage, vinCode, year, categoryName, CurrentUser.LoggedInUser.Id);

                MessageBox.Show("Car created successfully!");
                carCrudService.GetUserCars(CurrentUser.LoggedInUser.Id);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Error creating car: {ex.Message}");
            }
        }

    }
}

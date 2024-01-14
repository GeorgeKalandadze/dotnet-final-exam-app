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
        public CrudForm()
        {
            InitializeComponent();
        }

        private void CrudForm_Load(object sender, EventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var categories = dbContext.Categories.ToList();

                comboBox1.Items.Clear();
                foreach (var category in categories)
                {
                    comboBox1.Items.Add(category.Name);
                }
            }
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

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4CSharp
{
    public partial class AddProduct : Form
    {
        private ProductsRepository _products = new ProductsRepository();
        public AddProduct()
        {
            InitializeComponent();
            InitializeCategoryOptions();
        }

        private void InitializeCategoryOptions()
        {
            var catRepo = new CategoriesRepository();
            foreach (var cat in catRepo.GetAll())
            {
                categories.Items.Add(cat.Denumire);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productName.Text))
            {
                MessageBox.Show("Please enter a product name.");
                return;
            }

            int qty;
            if (!int.TryParse(quantity.Text, out qty) || qty < 0)
            {
                MessageBox.Show("Quantity must be a positive whole number.");
                return;
            }

            if (categories.SelectedItem == null)
            {
                MessageBox.Show("Please choose a category.");
                return;
            }

            //  Read everything from the controls here, on the GUI thread
            //    (controls must not be touched from inside Task.Run)
            string name = productName.Text;
            string description = productDescription.Text;
            DateTime entry = arrivalDate.Value;
            DateTime expiration = expirationDate.Value;
            int categoryId = ((CategorieProdus)categories.SelectedItem).Id;

            add.Enabled = false;

            //  Database work on a background thread
            Task.Run(() =>
            {
                string result;
                try
                {
                    _products.AddProduct(name, description, entry, expiration, qty, categoryId);
                    result = "Product added successfully!";
                }
                catch (Exception ex)
                {
                    result = "An error occurred while adding the product: " + ex.Message;
                }

                // Back to the GUI thread to show the result
                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show(result);
                    add.Enabled = true;
                }));
            });
        }
    }
}

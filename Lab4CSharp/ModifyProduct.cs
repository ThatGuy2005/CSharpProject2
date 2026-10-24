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
    public partial class ModifyProduct : Form
    {
        private ProductsEFRepository _products = new ProductsEFRepository();
        public ModifyProduct()
        {
            InitializeComponent();
            LoadCategories();
        }
        public ModifyProduct(int productID) : this()
        {
            productIdentifier.Text = productID.ToString();
        }
        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LoadCategories()
        {
            categories.Items.Clear();
            categories.DisplayMember = "Denumire";

            categories.Items.Add("(keep current category)");   // index 0 = no change
            foreach (var cat in new CategoriesRepository().GetAll())
            {
                categories.Items.Add(cat);
            }
            categories.SelectedIndex = 0;
        }

        private void update_Click(object sender, EventArgs e)
        {
            int productId;
            int quantity;
            if (!int.TryParse(productIdentifier.Text, out productId) ||
                !int.TryParse(addQuantity.Text, out quantity))
            {
                MessageBox.Show("Invalid arguments!");
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Quantity cannot be negative.");
                return;
            }

            // 0 means "keep the current category"
            int categoryId = 0;
            if (categories.SelectedIndex > 0)
                categoryId = ((CategorieProdus)categories.SelectedItem).Id;

            update.Enabled = false;
            Task.Run(() =>
            {
                string result;
                try
                {
                    if (_products.UpdateProduct(productId, quantity, categoryId))
                        result = "Product updated successfully.";
                    else
                        result = "Product not found.";
                }
                catch (Exception ex)
                {
                    result = "An error occurred: " + ex.Message;
                }

                // 3. Back to the GUI thread
                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show(result);
                    update.Enabled = true;
                }));
            });
        }
    }
}

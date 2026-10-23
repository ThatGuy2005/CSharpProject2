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
        public ModifyProduct(StoreDB db)
        {
            InitializeComponent();
            _db = db;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void update_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(addQuantity.Text);
            if(quantity < 0)
            {
                MessageBox.Show("Quantity cannot be negative.");
                return;
            }
            int productId = int.Parse(productIdentifier.Text);
            var product = _db.Products.Find(productId);
            if (product != null)
            {
                product.Quantity += quantity;
                _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Product updated successfully.");
            }
            else
            {
                MessageBox.Show("Product not found.");
            }
            
        }
    }
}

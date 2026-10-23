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
    public partial class SellForm : Form
    {
        public SellForm(StoreDB db, int productIdentifier)
        {
            InitializeComponent();
            _db = db;
            _product = db.Products.FirstOrDefault(p => p.ProductID == productIdentifier);
            for(int i = 1; i <= _product.Quantity; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void sell_Click(object sender, EventArgs e)
        {
            if(_product.ProductID == 0)
            {
                MessageBox.Show("Product not found.");
                return;
            }

            _product.Quantity -= (int)comboBox1.SelectedItem;

            if(_product.Quantity == 0)
            {
                _db.Products.Remove(_product);
            } else
            {
                _db.Entry(_product).State = System.Data.Entity.EntityState.Modified;
            }
            _db.SaveChanges();
        }
    }
}

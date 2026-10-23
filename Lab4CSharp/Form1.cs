using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _db = new StoreDB();
            addProductForm = new AddProduct();
            addProductForm.Hide();
            modifyProductForm = new ModifyProduct(_db);
            modifyProductForm.Hide();
            
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadProductsAsync();
        }
        private async Task LoadProductsAsync()
        {
            UseWaitCursor = true;
            try
            {
                await Task.Run(() => _db.Database.Initialize(force: false));
                await _db.Products.LoadAsync();
                dataGridView1.DataSource = _db.Products.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Could not load products");
            }
            finally
            {
                UseWaitCursor = false;
            }
        }
        private void addProduct_Click(object sender, EventArgs e)
        {

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addProductForm.Show();
        }

        private async void Refreash_Click(object sender, EventArgs e)
        {
            await _db.Products.LoadAsync();
        }

        private void modifyProductQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifyProductForm.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

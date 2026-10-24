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
    public partial class SalesHistoryForm : Form
    {
        public SalesHistoryForm()
        {
            InitializeComponent();
        }

        private void SalesHistoryForm_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                List<Products> products;
                using (var db = new StoreDB())
                    products = db.Products.ToList();

                var sales = new SalesRepository().GetSales(products);
                this.Invoke((MethodInvoker)(() => salesGrid.DataSource = sales));
            });
        }
    }
}

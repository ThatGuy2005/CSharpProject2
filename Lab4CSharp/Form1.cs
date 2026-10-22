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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addProductForm = new AddProduct();
            addProductForm.Hide();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addProductForm.Show();
        }
    }
}

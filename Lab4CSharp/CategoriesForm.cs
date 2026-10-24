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
    public partial class CategoriesForm : Form
    {
        private CategoriesRepository _categories = new CategoriesRepository();

        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            Task.Run(() =>
            {
                var list = _categories.GetAll();
                this.Invoke((MethodInvoker)(() => categoriesGrid.DataSource = list));
            });
        }

        private CategorieProdus Selected()
        {
            return categoriesGrid.CurrentRow?.DataBoundItem as CategorieProdus;
        }

        private void add_Click(object sender, EventArgs e)
        {
            string name = categoryName.Text.Trim();
            if (name == "") return;
            Task.Run(() =>
            {
                _categories.Add(name);
                this.Invoke((MethodInvoker)(() => LoadCategories()));
            });
        }

        private void rename_Click(object sender, EventArgs e)
        {
            CategorieProdus cat = Selected();
            string name = categoryName.Text.Trim();
            if (cat == null || name == "") return;
            int id = cat.Id;
            Task.Run(() =>
            {
                _categories.Rename(id, name);
                this.Invoke((MethodInvoker)(() => LoadCategories()));
            });
        }

        private void delete_Click(object sender, EventArgs e)
        {
            CategorieProdus cat = Selected();
            if (cat == null) return;
            int id = cat.Id;
            Task.Run(() =>
            {
                bool ok = _categories.Delete(id);
                this.Invoke((MethodInvoker)(() =>
                {
                    if (!ok) MessageBox.Show("The category still has products.");
                    LoadCategories();
                }));
            });
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            add_Click(sender, e);
        }

        private void rename_Click_1(object sender, EventArgs e)
        {
            rename_Click(sender, e);
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            delete_Click(sender, e);
        }

        private void CategoriesForm_Load_1(object sender, EventArgs e)
        {
            LoadCategories();
        }
    }
}

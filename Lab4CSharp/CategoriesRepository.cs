using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class CategoriesRepository
    {
        public List<CategorieProdus> GetAll()
        {
            using (var db = new StoreDB())
            {
                return db.CategoriiProduse.ToList();
            }
        }
        public void Add(string denumire)
        {
            using (var db = new StoreDB())
            {
                db.CategoriiProduse.Add(new CategorieProdus { Denumire = denumire });
                db.SaveChanges();
            }
        }
        public void Rename(int id, string denumireNoua)
        {
            using (var db = new StoreDB())
            {
                CategorieProdus categorie = db.CategoriiProduse.Find(id);
                if (categorie != null)
                {
                    categorie.Denumire = denumireNoua;
                    db.Entry(categorie).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public bool Delete(int id)
        {
            using (var db = new StoreDB())
            {
                CategorieProdus categorie = db.CategoriiProduse.Find(id);
                if (categorie == null || db.Products.Any(p => p.CategoryID == id))
                    return false;

                db.CategoriiProduse.Remove(categorie);
                db.SaveChanges();
                return true;
            }
        }
    }
}

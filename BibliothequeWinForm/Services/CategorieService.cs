using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliothequeWinForm.Services
{
    public class CategorieService
    {
        private readonly BibliothequeContext context = new BibliothequeContext();

        public void AddCategorie(Categorie categorie)
        {
            context.Categories.Add(categorie);
            context.SaveChanges();
        }

        public List<Categorie> GetAllCategories()
           {
            return context.Categories.ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return context.Categories.Find(id);
        }

        public void UpdateCategorie(Categorie categorie)
        {
            context.Entry(categorie).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCategorie(int id)
        {
            var cat = context.Categories.Find(id);
            if (cat != null)
            {
                context.Categories.Remove(cat);
                context.SaveChanges();
            }
        }
    }
}

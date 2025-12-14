using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliothequeWinForm.Services
{
    public class AuteurService
    {
        private readonly BibliothequeContext context = new BibliothequeContext();

        public void AddAuteur(Auteur auteur)
        {
            context.Auteurs.Add(auteur);
            context.SaveChanges();
        }

        public List<Auteur> GetAllAuteurs()
        {
            return context.Auteurs.ToList();
        }

        public Auteur GetAuteurById(int id)
        {
            return context.Auteurs.Find(id);
        }

        public void UpdateAuteur(Auteur auteur)
        {
            context.Entry(auteur).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAuteur(int id)
        {
            var auteur = context.Auteurs.Find(id);
            if (auteur != null)
            {
                context.Auteurs.Remove(auteur);
                context.SaveChanges();
            }
        }
    }
}

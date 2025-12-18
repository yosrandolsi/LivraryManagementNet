using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BibliothequeWinForm.Services
{
    public class LivreService
    {
        private readonly BibliothequeContext context = new BibliothequeContext();

        // =========================
        // CRUD
        // =========================

        public void AddLivre(Livre livre)
        {
            context.Livres.Add(livre);
            context.SaveChanges();
        }

        // Inclure Auteur et Categorie pour afficher leurs noms
        public List<Livre> GetAllLivres()
        {
            return context.Livres
                          .Include(l => l.Auteur)
                          .Include(l => l.Categorie)
                          .ToList();
        }

        public Livre GetLivreById(int id)
        {
            return context.Livres
                          .Include(l => l.Auteur)
                          .Include(l => l.Categorie)
                          .FirstOrDefault(l => l.Id == id);
        }

        public void UpdateLivre(Livre livre)
        {
            context.Entry(livre).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteLivre(int id)
        {
            var livre = context.Livres.Find(id);
            if (livre != null)
            {
                context.Livres.Remove(livre);
                context.SaveChanges();
            }
        }

        // =========================
        // RECHERCHES
        // =========================

        public List<Livre> SearchByTitre(string keyword)
        {
            return context.Livres
                          .Include(l => l.Auteur)
                          .Include(l => l.Categorie)
                          .Where(l => l.Titre.ToLower().Contains(keyword.ToLower()))
                          .ToList();
        }

        public List<Livre> SearchByAuteur(string auteurKeyword)
        {
            return context.Livres
                          .Include(l => l.Auteur)
                          .Include(l => l.Categorie)
                          .Where(l => l.Auteur.Nom.ToLower().Contains(auteurKeyword.ToLower()) ||
                                      l.Auteur.Prenom.ToLower().Contains(auteurKeyword.ToLower()))
                          .ToList();
        }

        public List<Livre> SearchByCategorie(string categorieKeyword)
        {
            return context.Livres
                          .Include(l => l.Auteur)
                          .Include(l => l.Categorie)
                          .Where(l => l.Categorie.Nom.ToLower().Contains(categorieKeyword.ToLower()))
                          .ToList();
        }
    }
}

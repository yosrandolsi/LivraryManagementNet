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

        // Liste affichable dans le DataGridView
        public List<LivreViewModel> GetAllLivres()
        {
            return context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.Categorie)
                .Select(l => new LivreViewModel
                {
                    Id = l.Id,
                    Titre = l.Titre,
                    Auteur = l.Auteur.Nom,
                    Categorie = l.Categorie.Nom,
                    ExemplairesDisponibles = l.ExemplairesDisponibles
                })
                .ToList();
        }

        public Livre GetLivreById(int id)
        {
            return context.Livres.Find(id);
        }

        public void AddLivre(Livre livre)
        {
            context.Livres.Add(livre);
            context.SaveChanges();
        }

        public void UpdateLivre(Livre livre)
        {
            context.Entry(livre).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteLivre(int id)
        {
            Livre livre = context.Livres.Find(id);
            if (livre != null)
            {
                context.Livres.Remove(livre);
                context.SaveChanges();
            }
        }
    }
}

using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System;
using System.Linq;

namespace BibliothequeWinForm.Services
{
    public class EmpruntService
    {
        private readonly BibliothequeContext _context;

        public EmpruntService()
        {
            _context = new BibliothequeContext();
        }

        public bool EmprunterLivre(int livreId, int clientId)
        {
            var livre = _context.Livres.Find(livreId);
            var client = _context.Clients.Find(clientId);

            if (livre == null || client == null) return false;
            if (livre.ExemplairesDisponibles <= 0) return false;

            // Créer un nouvel emprunt
            Emprunt emprunt = new Emprunt
            {
                LivreId = livreId,
                ClientId = clientId,
                DateEmprunt = DateTime.Now,
                DateRetour = null
            };

            livre.ExemplairesDisponibles--; // réduire la quantité disponible

            _context.Emprunts.Add(emprunt);
            _context.SaveChanges();
            return true;
        }
    }
}

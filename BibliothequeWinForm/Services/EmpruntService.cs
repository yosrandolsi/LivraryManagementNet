using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Emprunter un livre pour un client
        /// </summary>
        public bool EmprunterLivre(int livreId, int clientId)
        {
            var livre = _context.Livres.Find(livreId);
            var client = _context.Clients.Find(clientId);

            if (livre == null || client == null) return false;
            if (livre.ExemplairesDisponibles <= 0) return false;

            Emprunt emprunt = new Emprunt
            {
                LivreId = livreId,
                ClientId = clientId,
                DateEmprunt = DateTime.Now,
                DateRetour = null
            };

            livre.ExemplairesDisponibles--;

            _context.Emprunts.Add(emprunt);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retourner un livre
        /// </summary>
        public bool RetournerLivre(int empruntId)
        {
            var emprunt = _context.Emprunts.Find(empruntId);
            if (emprunt == null || emprunt.DateRetour != null) return false;

            emprunt.DateRetour = DateTime.Now;

            var livre = _context.Livres.Find(emprunt.LivreId);
            if (livre != null)
            {
                livre.ExemplairesDisponibles++;
            }

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Mettre à jour un emprunt
        /// </summary>
        public bool UpdateEmprunt(Emprunt emprunt)
        {
            if (emprunt == null) return false;

            var existing = _context.Emprunts.Find(emprunt.Id);
            if (existing == null) return false;

            existing.LivreId = emprunt.LivreId;
            existing.ClientId = emprunt.ClientId;
            existing.DateEmprunt = emprunt.DateEmprunt;
            existing.DateRetour = emprunt.DateRetour;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Supprimer un emprunt
        /// </summary>
        public bool DeleteEmprunt(int empruntId)
        {
            var emprunt = _context.Emprunts.Find(empruntId);
            if (emprunt == null) return false;

            _context.Emprunts.Remove(emprunt);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Lister tous les emprunts actifs (non retournés)
        /// </summary>
        public List<Emprunt> GetEmpruntsActifs()
        {
            return _context.Emprunts
                           .Where(e => e.DateRetour == null)
                           .ToList();
        }

        /// <summary>
        /// Lister tous les emprunts
        /// </summary>
        public List<Emprunt> GetAllEmprunts()
        {
            return _context.Emprunts.ToList();
        }

        /// <summary>
        /// Vérifier si un livre est disponible
        /// </summary>
        public bool LivreDisponible(int livreId)
        {
            var livre = _context.Livres.Find(livreId);
            return livre != null && livre.ExemplairesDisponibles > 0;
        }

        /// <summary>
        /// Obtenir les emprunts d’un client
        /// </summary>
        public List<Emprunt> GetEmpruntsParClient(int clientId)
        {
            return _context.Emprunts
                           .Where(e => e.ClientId == clientId && e.DateRetour == null)
                           .ToList();
        }
    }
}

using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliothequeWinForm.Services
{
    public class AdminService
    {
        private readonly BibliothequeContext context = new BibliothequeContext();

        // Ajouter un admin
        public void AddAdmin(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        // Lister tous les admins
        public List<Admin> GetAdmins()
        {
            return context.Admins.ToList();
        }

        // Trouver un admin par Id
        public Admin GetAdminById(int id)
        {
            return context.Admins.Find(id);
        }

        // Authentification basique
        public bool Login(string username, string password)
        {
            return context.Admins.Any(a => a.Username == username && a.Password == password);
        }

        // Supprimer un admin
        public void DeleteAdmin(int id)
        {
            var admin = context.Admins.Find(id);
            if (admin != null)
            {
                context.Admins.Remove(admin);
                context.SaveChanges();
            }
        }
    }
}

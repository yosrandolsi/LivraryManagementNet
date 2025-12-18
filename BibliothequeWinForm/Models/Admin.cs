using System;
using System.Collections.Generic;

namespace BibliothequeWinForm.Models
{
    public class Admin
    {
        public int Id { get; set; } // Pour la base de données
        public string Username { get; set; }
        public string Password { get; set; } // Pour simplifier, stocké en clair ici
        public string Email { get; set; }

        // Liste statique pour simuler la "base de données"
        public static List<Admin> Admins = new List<Admin>();
    }
}

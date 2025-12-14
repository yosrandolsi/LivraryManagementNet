using System.Data.Entity;
using BibliothequeWinForm.Models;

namespace BibliothequeWinForm.Data
{
    public class BibliothequeContext : DbContext
    {
        public BibliothequeContext() : base("name=Biblio") { }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}

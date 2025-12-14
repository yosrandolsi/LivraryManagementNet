using System.Collections.Generic;

namespace BibliothequeWinForm.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Livre> Livres { get; set; }
    }
}

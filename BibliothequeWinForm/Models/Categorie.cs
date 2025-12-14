using System.Collections.Generic;

namespace BibliothequeWinForm.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Livre> Livres { get; set; }
    }
}

using System.Collections.Generic;

namespace BibliothequeWinForm.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }

        public List<Emprunt> Emprunts { get; set; }
    }
}

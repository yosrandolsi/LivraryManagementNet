namespace BibliothequeWinForm.Models
{
    public class Livre
    {
        public int Id { get; set; }

        public string Titre { get; set; }

    

        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public int ExemplairesDisponibles { get; set; }
    }
}

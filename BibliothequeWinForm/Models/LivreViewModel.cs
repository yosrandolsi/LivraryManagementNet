namespace BibliothequeWinForm.Models
{
    public class LivreViewModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Categorie { get; set; }
        public int ExemplairesDisponibles { get; set; }
    }
}

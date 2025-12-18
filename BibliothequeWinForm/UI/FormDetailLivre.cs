using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormDetailLivre : Form
    {
        private readonly LivreService livreService = new LivreService();
        private readonly int livreId;

        public FormDetailLivre(int livreId)
        {
            InitializeComponent();
            this.livreId = livreId;
            LoadLivreDetails();
        }

        private void LoadLivreDetails()
        {
            Livre livre = livreService.GetLivreById(livreId);
            if (livre != null)
            {
                lblTitre.Text = $"Titre : {livre.Titre}";
                lblAuteur.Text = $"Auteur : {livre.Auteur?.Nom ?? "N/A"}";
                lblCategorie.Text = $"Catégorie : {livre.Categorie?.Nom ?? "N/A"}";
                lblExemplaires.Text = $"Exemplaires disponibles : {livre.ExemplairesDisponibles}";
            }
            else
            {
                MessageBox.Show("Livre non trouvé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

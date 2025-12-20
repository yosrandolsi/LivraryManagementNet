using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormDetailLivre : Form
    {
        private readonly LivreService livreService = new LivreService();
        private int livreId;

        public FormDetailLivre(int id)
        {
            InitializeComponent();
            livreId = id;
            LoadLivre();
        }

        private void LoadLivre()
        {
            Livre livre = livreService.GetLivreById(livreId);

            if (livre == null)
            {
                MessageBox.Show("Livre introuvable", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblTitre.Text = livre.Titre;
            lblAuteur.Text = $"{livre.Auteur.Nom} {livre.Auteur.Prenom}";
            lblCategorie.Text = livre.Categorie.Nom;
            lblExemplaires.Text = livre.ExemplairesDisponibles.ToString();
         
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

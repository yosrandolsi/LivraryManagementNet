using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditAuteur : Form
    {
        private readonly AuteurService auteurService = new AuteurService();
        private Auteur auteur;

        public FormEditAuteur(int auteurId)
        {
            InitializeComponent();
            auteur = auteurService.GetAuteurById(auteurId);
            txtNom.Text = auteur.Nom;
            txtPrenom.Text = auteur.Prenom;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            auteur.Nom = txtNom.Text;
            auteur.Prenom = txtPrenom.Text;
            auteurService.UpdateAuteur(auteur);
            this.Close(); // rafraîchissement dans FormAuteurs
        }
    }
}

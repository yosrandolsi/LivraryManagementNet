using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddAuteur : Form
    {
        private readonly AuteurService auteurService;

        public FormAddAuteur()
        {
            InitializeComponent();
            auteurService = new AuteurService();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom et le prénom de l'auteur.");
                return;
            }

            Auteur auteur = new Auteur
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text
            };

            auteurService.AddAuteur(auteur);
            MessageBox.Show("Auteur ajouté avec succès !");
            this.Close();
        }

        private void FormAddAuteur_Load(object sender, EventArgs e)
        {

        }
    }
}

using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddLivre : Form
    {
        private readonly LivreService livreService;
        private readonly AuteurService auteurService;
        private readonly CategorieService categorieService;

        public FormAddLivre()
        {
            InitializeComponent();
            livreService = new LivreService();
            auteurService = new AuteurService();
            categorieService = new CategorieService();
            LoadComboBoxes();
        }

        // Charger auteurs et catégories dans les ComboBox
        private void LoadComboBoxes()
        {
            var auteurs = auteurService.GetAllAuteurs();
            if (auteurs.Count == 0)
            {
                MessageBox.Show("Aucun auteur disponible. Veuillez en créer un avant d'ajouter un livre.");
                this.Close();
                return;
            }

            cmbAuteurs.DataSource = auteurs;
            cmbAuteurs.DisplayMember = "Nom";
            cmbAuteurs.ValueMember = "Id";
            cmbAuteurs.SelectedIndex = 0; // sélection par défaut

            var categories = categorieService.GetAllCategories();
            if (categories.Count == 0)
            {
                MessageBox.Show("Aucune catégorie disponible. Veuillez en créer une avant d'ajouter un livre.");
                this.Close();
                return;
            }

            cmbCategories.DataSource = categories;
            cmbCategories.DisplayMember = "Nom";
            cmbCategories.ValueMember = "Id";
            cmbCategories.SelectedIndex = 0; // sélection par défaut
        }

        // Événement du bouton Enregistrer
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitre.Text))
            {
                MessageBox.Show("Veuillez saisir le titre du livre.");
                return;
            }

            if (cmbAuteurs.SelectedValue == null || cmbCategories.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un auteur et une catégorie.");
                return;
            }

            Livre livre = new Livre
            {
                Titre = txtTitre.Text,
                AuteurId = (int)cmbAuteurs.SelectedValue,
                CategorieId = (int)cmbCategories.SelectedValue,
                ExemplairesDisponibles = (int)numExemplaires.Value
            };

            livreService.AddLivre(livre);
            MessageBox.Show("Livre ajouté avec succès !");

            // Fermer ce formulaire et revenir à FormLivres
            this.Close();
        }
    }
}

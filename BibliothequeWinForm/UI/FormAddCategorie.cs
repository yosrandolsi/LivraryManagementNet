using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddCategorie : Form
    {
        private readonly CategorieService categorieService;

        public FormAddCategorie()
        {
            InitializeComponent();
            categorieService = new CategorieService();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom de la catégorie.");
                return;
            }

            Categorie categorie = new Categorie
            {
                Nom = txtNom.Text
            };

            categorieService.AddCategorie(categorie);
            MessageBox.Show("Catégorie ajoutée avec succès !");
            this.Close();
        }
    }
}

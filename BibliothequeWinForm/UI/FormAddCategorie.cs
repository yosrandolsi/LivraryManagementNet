using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddCategorie : Form
    {
        private readonly CategorieService categorieService = new CategorieService();

        public FormAddCategorie()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom de la catégorie",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Categorie categorie = new Categorie
            {
                Nom = txtNom.Text.Trim()
            };

            categorieService.AddCategorie(categorie);

            MessageBox.Show("Catégorie ajoutée avec succès",
                "Succès",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

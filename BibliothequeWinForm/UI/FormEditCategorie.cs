using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditCategorie : Form
    {
        private readonly CategorieService categorieService = new CategorieService();
        private Categorie categorie;

        public FormEditCategorie(int catId)
        {
            InitializeComponent();
            categorie = categorieService.GetCategorieById(catId);
            txtNom.Text = categorie.Nom;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            categorie.Nom = txtNom.Text;
            categorieService.UpdateCategorie(categorie);
            this.Close();
        }
    }
}

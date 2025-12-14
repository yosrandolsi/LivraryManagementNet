using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditLivre : Form
    {
        private readonly LivreService livreService = new LivreService();
        private readonly AuteurService auteurService = new AuteurService();
        private readonly CategorieService categorieService = new CategorieService();
        private Livre livre;

        public FormEditLivre(int livreId)
        {
            InitializeComponent();
            LoadAuteurs();
            LoadCategories();
            livre = livreService.GetLivreById(livreId);
            LoadData();
        }

        private void LoadAuteurs()
        {
            cmbAuteurs.DataSource = auteurService.GetAllAuteurs();
            cmbAuteurs.DisplayMember = "Nom";
            cmbAuteurs.ValueMember = "Id";
        }

        private void LoadCategories()
        {
            cmbCategories.DataSource = categorieService.GetAllCategories();
            cmbCategories.DisplayMember = "Nom";
            cmbCategories.ValueMember = "Id";
        }

        private void LoadData()
        {
            txtTitre.Text = livre.Titre;
            numExemplaires.Value = livre.ExemplairesDisponibles;
            cmbAuteurs.SelectedValue = livre.AuteurId;
            cmbCategories.SelectedValue = livre.CategorieId;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            livre.Titre = txtTitre.Text;
            livre.AuteurId = (int)cmbAuteurs.SelectedValue;
            livre.CategorieId = (int)cmbCategories.SelectedValue;
            livre.ExemplairesDisponibles = (int)numExemplaires.Value;

            livreService.UpdateLivre(livre);
            Close();
        }
    }
}

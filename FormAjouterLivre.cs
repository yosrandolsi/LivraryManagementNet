using System;
using System.Linq;
using System.Windows.Forms;
using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;

namespace BibliothequeWinForm.Forms
{
    public partial class FormAjouterLivre : Form
    {
        private BibliothequeContext _context;

        public FormAjouterLivre()
        {
            InitializeComponent();
            _context = new BibliothequeContext();
        }

        private void FormAjouterLivre_Load(object sender, EventArgs e)
        {
            cmbAuteur.DataSource = _context.Auteurs.ToList();
            cmbAuteur.DisplayMember = "Nom";
            cmbAuteur.ValueMember = "Id";

            cmbCategorie.DataSource = _context.Categories.ToList();
            cmbCategorie.DisplayMember = "Nom";
            cmbCategorie.ValueMember = "Id";
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Livre livre = new Livre
            {
                Titre = txtTitre.Text,
                AuteurId = (int)cmbAuteur.SelectedValue,
                CategorieId = (int)cmbCategorie.SelectedValue,
                ExemplairesDisponibles = (int)numExemplaires.Value
            };

            _context.Livres.Add(livre);
            _context.SaveChanges();
            MessageBox.Show("Livre ajouté !");
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditCategorie : Form
    {
        private Categorie categorie;
        private CategorieService categorieService;

        public FormEditCategorie(int categorieId)
        {
            InitializeComponent();
            categorieService = new CategorieService();
            categorie = categorieService.GetCategorieById(categorieId);
            LoadCategorieData();
        }

        public FormEditCategorie(Categorie categorie)
        {
            InitializeComponent();
            categorieService = new CategorieService();
            this.categorie = categorie;
            LoadCategorieData();
        }

        private void FormEditCategorie_Load(object sender, EventArgs e)
        {
            // Appliquer coins arrondis et design uniforme
            ApplyRoundedCorners(btnSave, 20);
            ApplyRoundedCorners(btnCancel, 20);
            this.BackColor = Color.FromArgb(245, 235, 230);
        }

        private void LoadCategorieData()
        {
            if (categorie != null)
            {
                txtNom.Text = categorie.Nom;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom de la catégorie.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            categorie.Nom = txtNom.Text.Trim();
            categorieService.UpdateCategorie(categorie);

            MessageBox.Show("Catégorie mise à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            if (control == null) return;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }
    }
}

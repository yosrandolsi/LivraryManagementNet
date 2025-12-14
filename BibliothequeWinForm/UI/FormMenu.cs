using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BibliothequeWinForm.UI;

namespace BibliothequeWinForm
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Méthode pour créer des coins arrondis
        private void ApplyRoundedCorners(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            control.Region = new Region(path);
        }

        private void ApplyRoundedBorder(Control control, int radius, Color borderColor)
        {
            control.Paint += (sender, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                using (Pen borderPen = new Pen(borderColor, 1))
                {
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(borderPen, path);
                }
            };
        }

        private void BtnAuteurs_Click(object sender, EventArgs e)
        {
            FormAuteurs formAuteurs = new FormAuteurs();
            formAuteurs.ShowDialog();
        }

        private void BtnLivres_Click(object sender, EventArgs e)
        {
            FormLivres formLivres = new FormLivres();
            formLivres.ShowDialog();
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            FormCategories formCategories = new FormCategories();
            formCategories.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(btnAuteurs, 20);
            ApplyRoundedCorners(btnLivres, 20);
            ApplyRoundedCorners(btnCategories, 20);
            ApplyRoundedCorners(btnStartLearning, 10);
            ApplyRoundedCorners(btnVisitSite, 10);
            ApplyRoundedCorners(btnSave, 10);
            ApplyRoundedCorners(txtSearch, 10);
            ApplyRoundedCorners(panelLearnMore, 15);
            ApplyRoundedCorners(panelProfile, 15);
            ApplyRoundedCorners(panelButtons, 15);

            // Appliquer les bordures arrondies
            ApplyRoundedBorder(panelLearnMore, 15, Color.LightGray);
            ApplyRoundedBorder(panelProfile, 15, Color.LightGray);
            ApplyRoundedBorder(panelButtons, 15, Color.LightGray);
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LblHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vous êtes déjà sur la page d'accueil", "Information");
        }

        private void LblAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("À propos de notre application de bibliothèque", "À propos");
        }

        private void LblContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contactez-nous à: contact@bibliotheque.com", "Contact");
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "What are you looking for?")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "What are you looking for?";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void BtnStartLearning_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenue dans notre bibliothèque!", "Information");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paramètres sauvegardés!", "Confirmation");
        }

        private void BtnVisitSite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Visitez notre site web!", "Information");
            // System.Diagnostics.Process.Start("http://www.votrebibliotheque.com");
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            // Optionnel: dessin personnalisé
        }

        private void pictureBoxLibrary_Click(object sender, EventArgs e)
        {

        }
        private void BtnClients_Click(object sender, EventArgs e)
        {
            FormClients formClients = new FormClients();
            formClients.ShowDialog();
        }

    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;

namespace BibliothequeWinForm.UI
{
    public partial class FormEmprunt : Form
    {
        private int livreId;
        private BibliothequeContext db = new BibliothequeContext();

        public FormEmprunt(int livreId)
        {
            InitializeComponent();
            this.livreId = livreId;
            LoadLivre();
            LoadClients();
            LoadEmprunts();
        }

        private void LoadLivre()
        {
            var livre = db.Livres.Find(livreId);
            if (livre != null)
            {
                txtLivre.Text = livre.Titre;
            }
        }

        private void LoadClients()
        {
            cmbClients.DataSource = db.Clients.ToList();
            cmbClients.DisplayMember = "Nom";
            cmbClients.ValueMember = "Id";
        }

        private void LoadEmprunts()
        {
            dgvEmprunts.DataSource = db.Emprunts
                .Where(e => e.LivreId == livreId && e.DateRetour == null)
                .Select(e => new
                {
                    e.Id,
                    Client = e.Client.Nom + " " + e.Client.Prenom,
                    e.DateEmprunt,
                    DateRetourPrevue = e.DateRetour
                })
                .ToList();
        }

        // 📘 EMPRUNTER AVEC DATE DE RETOUR
        private void btnEmprunter_Click(object sender, EventArgs e)
        {
            if (cmbClients.SelectedItem is Client client)
            {
                var livre = db.Livres.Find(livreId);

                if (livre.ExemplairesDisponibles <= 0)
                {
                    MessageBox.Show("Livre non disponible !");
                    return;
                }

                Emprunt emprunt = new Emprunt
                {
                    LivreId = livreId,
                    ClientId = client.Id,
                    DateEmprunt = DateTime.Now,
                    DateRetour = dtRetour.Value   // 📅 date choisie
                };

                db.Emprunts.Add(emprunt);
                livre.ExemplairesDisponibles--;

                db.SaveChanges();

                MessageBox.Show("Livre emprunté !");
                LoadEmprunts();
            }
        }

        // 🔁 RETOUR DU LIVRE + FERMETURE FORM
        private void btnRetour_Click(object sender, EventArgs e)
        {
            if (dgvEmprunts.SelectedRows.Count == 0)
            {
                this.Close(); // ⬅️ retour à FormLivres
                return;
            }

            int empruntId = (int)dgvEmprunts.SelectedRows[0].Cells["Id"].Value;
            var emprunt = db.Emprunts.Find(empruntId);

            if (emprunt != null)
            {
                emprunt.DateRetour = DateTime.Now;

                var livre = db.Livres.Find(emprunt.LivreId);
                livre.ExemplairesDisponibles++;

                db.SaveChanges();

                MessageBox.Show("Livre retourné !");
                this.Close(); // ⬅️ retour à FormLivres
            }
        }

        private void FormEmprunt_Load(object sender, EventArgs e)
        {
            dtRetour.MinDate = DateTime.Now.AddDays(1); // pas de retour passé
        }
    }
}

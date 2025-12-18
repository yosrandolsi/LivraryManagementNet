using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormDetailClient : Form
    {
        private readonly ClientService clientService = new ClientService();
        private readonly EmpruntService empruntService = new EmpruntService();
        private readonly int clientId;

        public FormDetailClient(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;

            // Configuration visuelle et coins arrondis
            SetupVisuals();

            // Charger les détails du client
            LoadClientDetails();

            // Gestion des événements du bouton Fermer
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;
            btnClose.Click += BtnClose_Click;
        }

        #region Styles et coins arrondis

        private void SetupVisuals()
        {
            this.BackColor = Color.FromArgb(255, 245, 235, 230);
            ApplyRoundedFormCorners(20);
        }

        private void ApplyRoundedFormCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        #endregion

        #region Chargement des données

        private void LoadClientDetails()
        {
            Client client = clientService.GetClientById(clientId);
            if (client != null)
            {
                lblId.Text = $"ID: {client.Id}";
                lblNom.Text = $"Nom: {client.Nom}";
                lblPrenom.Text = $"Prénom: {client.Prenom}";
                lblCIN.Text = $"CIN: {client.CIN}";

                lstEmprunts.Items.Clear();

                // Récupérer les emprunts du client avec le livre
                var emprunts = empruntService.GetAllEmprunts()
                                    .Where(e => e.ClientId == clientId)
                                    .ToList();

                if (emprunts.Count > 0)
                {
                    foreach (var emprunt in emprunts)
                    {
                        string livreTitre = emprunt.Livre != null ? emprunt.Livre.Titre : "Titre inconnu";
                        string dateEmprunt = emprunt.DateEmprunt.ToShortDateString();
                        string dateRetour = emprunt.DateRetour?.ToShortDateString() ?? "Non retourné";

                        lstEmprunts.Items.Add($"Livre: {livreTitre}, Emprunt: {dateEmprunt}, Retour: {dateRetour}");
                    }
                }
                else
                {
                    lstEmprunts.Items.Add("Aucun emprunt pour ce client.");
                }
            }
            else
            {
                MessageBox.Show("Client non trouvé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion

        #region Événements du bouton

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(200, 35, 50);
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditClient : Form
    {
        private Client client;
        private ClientService clientService;

        public FormEditClient(int clientId)
        {
            InitializeComponent();
            clientService = new ClientService();
            client = clientService.GetClientById(clientId); // récupération du client depuis l'ID
            LoadClientData();
        }

        public FormEditClient(Client client)
        {
            InitializeComponent();
            clientService = new ClientService();
            this.client = client;
            LoadClientData();
        }

        private void FormEditClient_Load(object sender, EventArgs e)
        {
            // Appliquer coins arrondis et design uniforme
            ApplyRoundedCorners(btnSave, 20);
            ApplyRoundedCorners(btnCancel, 20);
            this.BackColor = Color.FromArgb(245, 235, 230);
        }

        private void LoadClientData()
        {
            if (client != null)
            {
                txtNom.Text = client.Nom;
                txtPrenom.Text = client.Prenom;
                txtCIN.Text = client.CIN;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtCIN.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            client.Nom = txtNom.Text.Trim();
            client.Prenom = txtPrenom.Text.Trim();
            client.CIN = txtCIN.Text.Trim();

            clientService.UpdateClient(client);

            MessageBox.Show("Client mis à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

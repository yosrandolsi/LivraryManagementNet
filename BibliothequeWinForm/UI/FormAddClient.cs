using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddClient : Form
    {
        private readonly ClientService clientService;

        public FormAddClient()
        {
            InitializeComponent();
            clientService = new ClientService();
        }

        private void FormAddClient_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 235, 230);
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtCIN.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            Client client = new Client
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                CIN = txtCIN.Text
            };

            clientService.AddClient(client);
            MessageBox.Show("Client ajouté avec succès !");
            this.Close();
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

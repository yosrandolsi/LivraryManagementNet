using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddClient : Form
    {
        private readonly ClientService clientService = new ClientService();

        public FormAddClient()
        {
            InitializeComponent();
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                CIN = txtCIN.Text
            };

            clientService.AddClient(client);
            this.Close(); // retour automatique à FormClients
        }
    }
}

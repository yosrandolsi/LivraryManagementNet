using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditClient : Form
    {
        private readonly ClientService clientService = new ClientService();
        private Client client;

        public FormEditClient(int clientId)
        {
            InitializeComponent();
            client = clientService.GetClientById(clientId);

            txtNom.Text = client.Nom;
            txtPrenom.Text = client.Prenom;
            txtCIN.Text = client.CIN;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            client.Nom = txtNom.Text;
            client.Prenom = txtPrenom.Text;
            client.CIN = txtCIN.Text;

            clientService.UpdateClient(client);
            this.Close(); // rafraîchissement dans FormClients
        }
    }
}

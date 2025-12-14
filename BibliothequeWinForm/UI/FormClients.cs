using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormClients : Form
    {
        private readonly ClientService clientService = new ClientService();

        public FormClients()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            dgvClients.Columns.Clear();
            dgvClients.DataSource = clientService.GetAllClients();

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                Name = "Modifier",
                Text = "Modifier",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Supprimer",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true
            };

            dgvClients.Columns.Add(btnEdit);
            dgvClients.Columns.Add(btnDelete);
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormAddClient formAdd = new FormAddClient();
            formAdd.ShowDialog();
            LoadClients();
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int clientId = (int)dgvClients.Rows[e.RowIndex].Cells["Id"].Value;

            if (dgvClients.Columns[e.ColumnIndex].Name == "Modifier")
            {
                new FormEditClient(clientId).ShowDialog();
                LoadClients();
            }

            if (dgvClients.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                if (MessageBox.Show("Supprimer ce client ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clientService.DeleteClient(clientId);
                    LoadClients();
                }
            }
        }
    }
}

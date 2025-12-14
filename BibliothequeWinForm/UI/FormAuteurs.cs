using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAuteurs : Form
    {
        private readonly AuteurService auteurService = new AuteurService();

        public FormAuteurs()
        {
            InitializeComponent();
            LoadAuteurs();
        }

        private void LoadAuteurs()
        {
            dgvAuteurs.Columns.Clear();
            dgvAuteurs.DataSource = auteurService.GetAllAuteurs();

            // Boutons Modifier / Supprimer
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

            dgvAuteurs.Columns.Add(btnEdit);
            dgvAuteurs.Columns.Add(btnDelete);
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormAddAuteur formAdd = new FormAddAuteur();
            formAdd.ShowDialog();
            LoadAuteurs(); // 🔄 Rafraîchissement
        }

        private void dgvAuteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int auteurId = (int)dgvAuteurs.Rows[e.RowIndex].Cells["Id"].Value;

            if (dgvAuteurs.Columns[e.ColumnIndex].Name == "Modifier")
            {
                new FormEditAuteur(auteurId).ShowDialog();
                LoadAuteurs();
            }

            if (dgvAuteurs.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                if (MessageBox.Show("Supprimer cet auteur ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    auteurService.DeleteAuteur(auteurId);
                    LoadAuteurs();
                }
            }
        }
    }
}

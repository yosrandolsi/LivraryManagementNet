using BibliothequeWinForm.Services;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormLivres : Form
    {
        private readonly LivreService livreService = new LivreService();

        public FormLivres()
        {
            InitializeComponent();
            LoadLivres();
        }

        private void LoadLivres()
        {
            dgvLivres.Columns.Clear();
            dgvLivres.AutoGenerateColumns = true;
            dgvLivres.DataSource = livreService.GetAllLivres();

            // 🔹 Bouton Emprunter
            DataGridViewButtonColumn btnEmprunter = new DataGridViewButtonColumn
            {
                Name = "Emprunter",
                Text = "Emprunter",
                UseColumnTextForButtonValue = true
            };

            // 🔹 Bouton Modifier
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                Name = "Modifier",
                Text = "Modifier",
                UseColumnTextForButtonValue = true
            };

            // 🔹 Bouton Supprimer
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Supprimer",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true
            };

            dgvLivres.Columns.Add(btnEmprunter);
            dgvLivres.Columns.Add(btnEdit);
            dgvLivres.Columns.Add(btnDelete);
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormAddLivre f = new FormAddLivre();
            f.ShowDialog();
            LoadLivres();
        }

        private void dgvLivres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int livreId = (int)dgvLivres.Rows[e.RowIndex].Cells["Id"].Value;
            string columnName = dgvLivres.Columns[e.ColumnIndex].Name;

            // 📘 EMPRUNTER
            if (columnName == "Emprunter")
            {
                FormEmprunt f = new FormEmprunt(livreId);
                f.ShowDialog();
                LoadLivres();
            }

            // ✏️ MODIFIER
            if (columnName == "Modifier")
            {
                new FormEditLivre(livreId).ShowDialog();
                LoadLivres();
            }

            // 🗑️ SUPPRIMER
            if (columnName == "Supprimer")
            {
                if (MessageBox.Show("Supprimer ce livre ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    livreService.DeleteLivre(livreId);
                    LoadLivres();
                }
            }
        }

        private void FormLivres_Load(object sender, EventArgs e)
        {
        }
    }
}

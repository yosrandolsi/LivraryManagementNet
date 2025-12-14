using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormCategories : Form
    {
        private readonly CategorieService categorieService = new CategorieService();

        public FormCategories()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            dgvCategories.Columns.Clear();
            dgvCategories.DataSource = categorieService.GetAllCategories();

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

            dgvCategories.Columns.Add(btnEdit);
            dgvCategories.Columns.Add(btnDelete);
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormAddCategorie f = new FormAddCategorie();
            f.ShowDialog();
            LoadCategories(); // 🔄 rafraîchissement
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int catId = (int)dgvCategories.Rows[e.RowIndex].Cells["Id"].Value;

            if (dgvCategories.Columns[e.ColumnIndex].Name == "Modifier")
            {
                new FormEditCategorie(catId).ShowDialog();
                LoadCategories(); // 🔄 rafraîchissement
            }

            if (dgvCategories.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                if (MessageBox.Show("Supprimer cette catégorie ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    categorieService.DeleteCategorie(catId);
                    LoadCategories();
                }
            }
        }
    }
}

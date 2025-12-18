using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormLivres : Form
    {
        private readonly LivreService livreService = new LivreService();
        private readonly CategorieService categorieService = new CategorieService();
        private List<Button> categoryButtons = new List<Button>();

        public FormLivres()
        {
            InitializeComponent();
            StyleDataGridView();
        }

        private void FormLivres_Load(object sender, EventArgs e)
        {
            dgvLivres.ClearSelection();
            LoadLivres();
            LoadCategoryButtons();
        }

        #region Chargement Livres

        private void LoadLivres()
        {
            dgvLivres.Columns.Clear();
            dgvLivres.AutoGenerateColumns = true;

            dgvLivres.DataSource = livreService.GetAllLivres()
                .Select(l => new
                {
                    l.Id,
                    l.Titre,
                    Auteur = l.Auteur != null ? $"{l.Auteur.Nom} {l.Auteur.Prenom}" : "",
                    Categorie = l.Categorie != null ? l.Categorie.Nom : "",
                    l.ExemplairesDisponibles
                })
                .ToList();

            AddActionButtons();
        }

        private void LoadLivresByCategory(int catId)
        {
            dgvLivres.Columns.Clear();
            dgvLivres.AutoGenerateColumns = true;

            dgvLivres.DataSource = livreService.GetAllLivres()
                .Where(l => l.CategorieId == catId)
                .Select(l => new
                {
                    l.Id,
                    l.Titre,
                    Auteur = l.Auteur != null ? $"{l.Auteur.Nom} {l.Auteur.Prenom}" : "",
                    Categorie = l.Categorie != null ? l.Categorie.Nom : "",
                    l.ExemplairesDisponibles
                })
                .ToList();

            AddActionButtons();
        }

        private void TxtRecherche_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtRecherche.Text.Trim();
            dgvLivres.Columns.Clear();
            dgvLivres.AutoGenerateColumns = true;

            if (string.IsNullOrEmpty(keyword))
            {
                LoadLivres();
            }
            else
            {
                dgvLivres.DataSource = livreService.SearchByTitre(keyword)
                    .Select(l => new
                    {
                        l.Id,
                        l.Titre,
                        Auteur = l.Auteur != null ? $"{l.Auteur.Nom} {l.Auteur.Prenom}" : "",
                        Categorie = l.Categorie != null ? l.Categorie.Nom : "",
                        l.ExemplairesDisponibles
                    })
                    .ToList();
                AddActionButtons();
            }
        }

        #endregion

        #region Boutons Catégories

        private void LoadCategoryButtons()
        {
            panelCategories.Controls.Clear();
            categoryButtons.Clear();

            Button btnAll = new Button
            {
                Text = "Tous",
                AutoSize = true,
                BackColor = Color.FromArgb(135, 206, 235),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(5)
            };
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.Click += (s, e) => LoadLivres();
            panelCategories.Controls.Add(btnAll);
            categoryButtons.Add(btnAll);

            var categories = categorieService.GetAllCategories();
            foreach (var cat in categories)
            {
                Button btn = new Button
                {
                    Text = cat.Nom,
                    AutoSize = true,
                    BackColor = Color.FromArgb(100, 149, 237),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Margin = new Padding(5),
                    Tag = cat.Id
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += CategoryButton_Click;
                panelCategories.Controls.Add(btn);
                categoryButtons.Add(btn);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                int catId = (int)btn.Tag;
                LoadLivresByCategory(catId);
            }
        }

        #endregion

        #region DataGridView Style & Actions

        private void StyleDataGridView()
        {
            dgvLivres.BorderStyle = BorderStyle.None;
            dgvLivres.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvLivres.EnableHeadersVisualStyles = false;
            dgvLivres.ColumnHeadersHeight = 42;
            dgvLivres.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230);
            dgvLivres.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLivres.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvLivres.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvLivres.RowTemplate.Height = 40;
            dgvLivres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLivres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLivres.RowHeadersVisible = false;

            dgvLivres.CellClick += DgvLivres_CellClick;
        }

        private void AddActionButtons()
        {
            AddButton("Emprunter", "📘 Emprunter", Color.FromArgb(135, 206, 235));
            AddButton("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
            AddButton("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));
        }

        private void AddButton(string name, string text, Color color)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = name,
                Text = text,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            dgvLivres.Columns.Add(btn);

            dgvLivres.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvLivres.Columns[e.ColumnIndex].Name == name)
                {
                    e.PaintBackground(e.CellBounds, true);

                    // Récupération du nombre d'exemplaires
                    int exemplaires = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["ExemplairesDisponibles"].Value);

                    Rectangle rect = new Rectangle(
                        e.CellBounds.X + 6,
                        e.CellBounds.Y + 6,
                        e.CellBounds.Width - 12,
                        e.CellBounds.Height - 12);

                    // Si "Emprunter" et pas d'exemplaires → couleur grisée
                    Color btnColor = color;
                    if (name == "Emprunter" && exemplaires == 0)
                        btnColor = Color.FromArgb(180, Color.Gray);

                    using (GraphicsPath path = GetRoundedRect(rect, 12))
                    using (SolidBrush brush = new SolidBrush(btnColor))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, path);

                        TextRenderer.DrawText(
                            e.Graphics,
                            text,
                            new Font("Segoe UI", 9.5F, FontStyle.Bold),
                            rect,
                            Color.White,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    e.Handled = true;
                }
            };
        }

        private void DgvLivres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int livreId = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["Id"].Value);
            string col = dgvLivres.Columns[e.ColumnIndex].Name;
            int exemplaires = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["ExemplairesDisponibles"].Value);

            if (col == "Emprunter")
            {
                if (exemplaires == 0) return; // ignore click si pas d'exemplaires
                new FormEmprunt(livreId).ShowDialog();
                LoadLivres();
            }
            else if (col == "Modifier")
            {
                new FormEditLivre(livreId).ShowDialog();
                LoadLivres();
            }
            else if (col == "Supprimer")
            {
                if (MessageBox.Show("Supprimer ce livre ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    livreService.DeleteLivre(livreId);
                    LoadLivres();
                }
            }
        }

        #endregion

        #region Utilitaires

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            new FormAddLivre().ShowDialog();
            LoadLivres();
        }

        #endregion

        private void dgvLivres_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void panelContainer_Paint(object sender, PaintEventArgs e) { }
    }
}

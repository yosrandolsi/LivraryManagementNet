using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
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
            StyleDataGridView();
        }

        // =========================
        // CHARGEMENT DES LIVRES
        // =========================
        private void LoadLivres()
        {
            dgvLivres.Columns.Clear();
            dgvLivres.AutoGenerateColumns = true;
            dgvLivres.DataSource = livreService.GetAllLivres();

            AddButton("Emprunter", "📘 Emprunter", Color.FromArgb(135, 206, 235));
            AddButton("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
            AddButton("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));
        }

        // =========================
        // STYLE GLOBAL DU TABLEAU
        // =========================
        private void StyleDataGridView()
        {
            dgvLivres.BorderStyle = BorderStyle.None;
            dgvLivres.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLivres.GridColor = Color.FromArgb(230, 230, 230);

            dgvLivres.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvLivres.EnableHeadersVisualStyles = false;

            dgvLivres.ColumnHeadersHeight = 42;
            dgvLivres.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230);
            dgvLivres.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLivres.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvLivres.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvLivres.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvLivres.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvLivres.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 240);
            dgvLivres.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvLivres.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(242, 236, 233);

            dgvLivres.RowTemplate.Height = 40;
            dgvLivres.RowHeadersVisible = false;
            dgvLivres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLivres.MultiSelect = false;
            dgvLivres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLivres.CellClick += dgvLivres_CellClick;
        }

        // =========================
        // BOUTONS COLORÉS
        // =========================
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

                    Rectangle rect = new Rectangle(
                        e.CellBounds.X + 6,
                        e.CellBounds.Y + 6,
                        e.CellBounds.Width - 12,
                        e.CellBounds.Height - 12);

                    using (GraphicsPath path = GetRoundedRect(rect, 12))
                    using (SolidBrush brush = new SolidBrush(color))
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

        // =========================
        // GESTION DES CLICS
        // =========================
        private void dgvLivres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int livreId = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["Id"].Value);
            string col = dgvLivres.Columns[e.ColumnIndex].Name;

            if (col == "Emprunter")
            {
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

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            new FormAddLivre().ShowDialog();
            LoadLivres();
        }

        private void FormLivres_Load(object sender, EventArgs e)
        {
            dgvLivres.ClearSelection();
        }

        // =========================
        // UTILS
        // =========================
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
    }
}

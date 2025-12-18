using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            StyleDataGridView();
        }

        // =========================
        // CHARGEMENT DES CATÉGORIES
        // =========================
        private void LoadCategories()
        {
            dgvCategories.Columns.Clear();
            dgvCategories.AutoGenerateColumns = true;
            dgvCategories.DataSource = categorieService.GetAllCategories();

            AddButton("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
            AddButton("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));
        }

        // =========================
        // STYLE DU TABLEAU
        // =========================
        private void StyleDataGridView()
        {
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.GridColor = Color.FromArgb(230, 230, 230);

            dgvCategories.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvCategories.EnableHeadersVisualStyles = false;

            dgvCategories.ColumnHeadersHeight = 42;
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(173, 216, 230);
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvCategories.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCategories.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvCategories.DefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);
            dgvCategories.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 240);
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvCategories.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(242, 236, 233);

            dgvCategories.RowTemplate.Height = 38;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCategories.CellClick += dgvCategories_CellClick;
        }

        // =========================
        // BOUTONS ARRONDIS
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

            dgvCategories.Columns.Add(btn);

            dgvCategories.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvCategories.Columns[e.ColumnIndex].Name == name)
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
                            TextFormatFlags.HorizontalCenter |
                            TextFormatFlags.VerticalCenter);
                    }
                    e.Handled = true;
                }
            };
        }

        // =========================
        // ACTIONS SUR BOUTONS
        // =========================
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int catId = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["Id"].Value);
            string col = dgvCategories.Columns[e.ColumnIndex].Name;

            if (col == "Modifier")
            {
                new FormEditCategorie(catId).ShowDialog();
                LoadCategories();
            }
            else if (col == "Supprimer")
            {
                if (MessageBox.Show("Supprimer cette catégorie ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    categorieService.DeleteCategorie(catId);
                    LoadCategories();
                }
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            new FormAddCategorie().ShowDialog();
            LoadCategories();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu();
            menu.Show();
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            dgvCategories.ClearSelection();
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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            // Optionnel : fond custom
        }
    }
}

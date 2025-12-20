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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FormCategories_Load;
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(panelContainer, 25);
            ApplyRoundedCorners(btnAjouter, 15);
            ApplyRoundedCorners(btnRetour, 15);
            ApplyRoundedCorners(panelTop, 15);

            // Appliquer les effets visuels
            SetupVisualEffects();

            // Charger les catégories
            LoadCategories();

            // Styler le DataGridView
            StyleDataGridView();
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            if (control == null) return;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }

        private void SetupVisualEffects()
        {
            // Fond dégradé du conteneur principal
            panelContainer.Paint += (sender, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    panelContainer.ClientRectangle,
                    Color.FromArgb(255, 239, 228, 225),  // Couleur pastel claire
                    Color.FromArgb(255, 245, 235, 230),  // Couleur pastel plus claire
                    45F))
                {
                    e.Graphics.FillRectangle(brush, panelContainer.ClientRectangle);
                }

                // Bordure subtile
                using (Pen borderPen = new Pen(Color.FromArgb(180, 210, 210, 210), 1))
                {
                    Rectangle borderRect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
                    e.Graphics.DrawRectangle(borderPen, borderRect);
                }
            };

            // Effets sur les boutons
            AddButtonEffects(btnAjouter);
            AddButtonEffects(btnRetour);

            // Style de l'en-tête
            panelTop.Paint += (sender, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    panelTop.ClientRectangle,
                    Color.FromArgb(255, 173, 216, 230),  // Bleu clair pastel
                    Color.FromArgb(255, 135, 206, 235),  // Bleu ciel pastel
                    90F))
                {
                    e.Graphics.FillRectangle(brush, panelTop.ClientRectangle);
                }
            };
        }

        private void AddButtonEffects(Button button)
        {
            button.Paint += (sender, e) =>
            {
                Button btn = (Button)sender;
                if (btn.Enabled)
                {
                    using (GraphicsPath path = CreateRoundedPath(btn.ClientRectangle, 15))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                        // Ombre
                        using (Pen shadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 2))
                        {
                            e.Graphics.DrawPath(shadowPen, path);
                        }

                        // Surbrillance
                        RectangleF highlightRect = new RectangleF(3, 3, btn.Width - 6, 12);
                        using (LinearGradientBrush highlightBrush = new LinearGradientBrush(
                            highlightRect,
                            Color.FromArgb(60, 255, 255, 255),
                            Color.Transparent,
                            90F))
                        {
                            e.Graphics.FillRectangle(highlightBrush, highlightRect);
                        }
                    }
                }
            };

            // Effets hover
            button.MouseEnter += (s, e) =>
            {
                button.BackColor = Color.FromArgb(220, button.BackColor.R, button.BackColor.G, button.BackColor.B);
            };
            button.MouseLeave += (s, e) =>
            {
                if (button.Name == "btnAjouter")
                    button.BackColor = Color.FromArgb(200, 144, 238, 144); // Vert pastel
                else if (button.Name == "btnRetour")
                    button.BackColor = Color.FromArgb(200, 135, 206, 235); // Bleu pastel
            };
        }

        private GraphicsPath CreateRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        // =========================
        // CHARGEMENT DES CATÉGORIES
        // =========================
        private void LoadCategories()
        {
            try
            {
                dgvCategories.Columns.Clear();
                dgvCategories.AutoGenerateColumns = true;

                var categories = categorieService.GetAllCategories();
                dgvCategories.DataSource = categories;

                // Ajouter les colonnes de boutons
                AddButtonColumn("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
                AddButtonColumn("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));

                // Ajuster la largeur des colonnes
                if (dgvCategories.Columns.Count > 0)
                {
                    dgvCategories.Columns[0].Width = 80;  // ID
                    dgvCategories.Columns[1].Width = 300; // Nom
                    dgvCategories.Columns[2].Width = 200; // Description
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            // En-têtes de colonnes
            dgvCategories.ColumnHeadersHeight = 45;
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(173, 216, 230); // Bleu clair pastel
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvCategories.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvCategories.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);

            // Cellules normales
            dgvCategories.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvCategories.DefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);
            dgvCategories.DefaultCellStyle.BackColor =
                Color.FromArgb(255, 255, 255);
            dgvCategories.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 240); // Bleu très clair pour la sélection
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCategories.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            // Lignes alternées
            dgvCategories.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(250, 248, 246);

            // Configuration générale
            dgvCategories.RowTemplate.Height = 40;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCategories.AllowUserToResizeRows = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.ReadOnly = true;

            // Événements
            dgvCategories.CellClick += dgvCategories_CellClick;
            dgvCategories.CellPainting += dgvCategories_CellPainting;
        }

        private void AddButtonColumn(string name, string text, Color color)
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
            {
                Name = name,
                Text = text,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 120
            };

            dgvCategories.Columns.Add(btnColumn);
        }

        private void dgvCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvCategories.Columns["Modifier"].Index ||
                                   e.ColumnIndex == dgvCategories.Columns["Supprimer"].Index))
            {
                e.PaintBackground(e.CellBounds, true);

                // Créer un rectangle arrondi
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + 5,
                    e.CellBounds.Y + 5,
                    e.CellBounds.Width - 10,
                    e.CellBounds.Height - 10);

                using (GraphicsPath path = GetRoundedRect(rect, 8))
                {
                    Color btnColor = e.ColumnIndex == dgvCategories.Columns["Modifier"].Index
                        ? Color.FromArgb(255, 193, 7)
                        : Color.FromArgb(220, 53, 69);

                    using (SolidBrush brush = new SolidBrush(btnColor))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, path);
                    }

                    // Bordure
                    using (Pen borderPen = new Pen(Color.FromArgb(150, Color.White), 1))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }

                    // Texte
                    TextRenderer.DrawText(
                        e.Graphics,
                        e.Value?.ToString() ?? "",
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        rect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true;
            }
        }

        // =========================
        // ACTIONS SUR BOUTONS
        // =========================
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                int catId = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["Id"].Value);
                string colName = dgvCategories.Columns[e.ColumnIndex].Name;

                if (colName == "Modifier")
                {
                    new FormEditCategorie(catId).ShowDialog();
                    LoadCategories();
                }
                else if (colName == "Supprimer")
                {
                    string catName = dgvCategories.Rows[e.RowIndex].Cells["Nom"].Value?.ToString() ?? "";

                    if (MessageBox.Show($"Voulez-vous vraiment supprimer la catégorie '{catName}' ?",
                        "Confirmation de suppression",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        categorieService.DeleteCategorie(catId);
                        MessageBox.Show("Catégorie supprimée avec succès !",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            new FormAddCategorie().ShowDialog();
            LoadCategories();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Animation de fermeture
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                Timer fadeTimer = new Timer();
                fadeTimer.Interval = 20;
                fadeTimer.Tick += (s, ev) =>
                {
                    if (this.Opacity > 0.1)
                        this.Opacity -= 0.1;
                    else
                    {
                        fadeTimer.Stop();
                        this.Hide();
                        FormMenu menu = new FormMenu();
                        menu.Show();
                    }
                };
                fadeTimer.Start();
            }
        }

        // =========================
        // BOUTONS DE CONTRÔLE
        // =========================
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
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

        private void LblTitle_Paint(object sender, PaintEventArgs e)
        {
            // Effet de texte avec ombre
            ControlPaint.DrawBorder(e.Graphics, lblTitle.ClientRectangle,
                Color.Transparent, ButtonBorderStyle.None);
        }

        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {
            // Déjà géré dans SetupVisualEffects
        }

        // =========================
        // IMPORT DDL POUR DÉPLACEMENT DE LA FENÊTRE
        // =========================
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
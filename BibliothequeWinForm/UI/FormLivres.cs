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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FormLivres_Load;
        }

        private void FormLivres_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(panelContainer, 25);
            ApplyRoundedCorners(btnAjouter, 15);
            ApplyRoundedCorners(btnRetour, 15);
            ApplyRoundedCorners(panelTop, 15);
            ApplyRoundedCorners(txtRecherche, 10);

            // Appliquer les effets visuels
            SetupVisualEffects();

            // Charger les livres
            LoadLivres();
            LoadCategoryButtons();

            // Styler le DataGridView
            StyleDataGridView();
        }

        #region Méthodes de style et design

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
                    Color.FromArgb(255, 239, 228, 225),
                    Color.FromArgb(255, 245, 235, 230),
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
                    Color.FromArgb(255, 173, 216, 230),
                    Color.FromArgb(255, 135, 206, 235),
                    90F))
                {
                    e.Graphics.FillRectangle(brush, panelTop.ClientRectangle);
                }
            };

            // Style du champ de recherche
            txtRecherche.BackColor = Color.FromArgb(255, 253, 251);
            txtRecherche.BorderStyle = BorderStyle.None;
            txtRecherche.Font = new Font("Segoe UI", 10.5F);
            txtRecherche.Paint += (sender, e) =>
            {
                using (Pen borderPen = new Pen(Color.FromArgb(200, 173, 216, 230), 1))
                {
                    Rectangle borderRect = new Rectangle(0, 0, txtRecherche.Width - 1, txtRecherche.Height - 1);
                    e.Graphics.DrawRectangle(borderPen, borderRect);
                }
            };
        }

        private void AddButtonEffects(Button button)
        {
            if (button == null) return;

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
                    button.BackColor = Color.FromArgb(200, 144, 238, 144);
                else if (button.Name == "btnRetour")
                    button.BackColor = Color.FromArgb(200, 135, 206, 235);
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

        #endregion

        #region Chargement des livres

        private void LoadLivres()
        {
            try
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
                AdjustColumnWidths();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des livres: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            AdjustColumnWidths();
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
                AdjustColumnWidths();
            }
        }

        private void AdjustColumnWidths()
        {
            if (dgvLivres.Columns.Count > 0)
            {
                dgvLivres.Columns["Id"].Width = 60;
                dgvLivres.Columns["Titre"].Width = 250;
                dgvLivres.Columns["Auteur"].Width = 200;
                dgvLivres.Columns["Categorie"].Width = 150;
                dgvLivres.Columns["ExemplairesDisponibles"].Width = 120;
                dgvLivres.Columns["ExemplairesDisponibles"].HeaderText = "Exemplaires";
            }
        }

        #endregion

        #region Boutons Catégories

        private void LoadCategoryButtons()
        {
            panelCategories.Controls.Clear();
            categoryButtons.Clear();

            // Bouton "Tous"
            Button btnAll = new Button
            {
                Name = "btnAll",
                Text = "📚 Tous",
                AutoSize = true,
                BackColor = Color.FromArgb(200, 135, 206, 235),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Margin = new Padding(5),
                Height = 35,
                Padding = new Padding(15, 5, 15, 5)
            };
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.Click += (s, e) => LoadLivres();
            panelCategories.Controls.Add(btnAll);
            categoryButtons.Add(btnAll);
            ApplyRoundedCorners(btnAll, 15);
            AddCategoryButtonEffects(btnAll);

            // Boutons pour chaque catégorie
            var categories = categorieService.GetAllCategories();
            foreach (var cat in categories)
            {
                Button btn = new Button
                {
                    Text = "📂 " + cat.Nom,
                    AutoSize = true,
                    BackColor = Color.FromArgb(200, 100, 149, 237),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Margin = new Padding(5),
                    Height = 35,
                    Padding = new Padding(15, 5, 15, 5),
                    Tag = cat.Id
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += CategoryButton_Click;
                panelCategories.Controls.Add(btn);
                categoryButtons.Add(btn);
                ApplyRoundedCorners(btn, 15);
                AddCategoryButtonEffects(btn);
            }
        }

        private void AddCategoryButtonEffects(Button button)
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
                        using (Pen shadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 1))
                        {
                            e.Graphics.DrawPath(shadowPen, path);
                        }

                        // Surbrillance
                        RectangleF highlightRect = new RectangleF(2, 2, btn.Width - 4, 10);
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
                if (button.Text.Contains("Tous"))
                    button.BackColor = Color.FromArgb(200, 135, 206, 235);
                else
                    button.BackColor = Color.FromArgb(200, 100, 149, 237);
            };
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

        #region Style DataGridView

        private void StyleDataGridView()
        {
            dgvLivres.BorderStyle = BorderStyle.None;
            dgvLivres.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLivres.GridColor = Color.FromArgb(230, 230, 230);

            dgvLivres.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvLivres.EnableHeadersVisualStyles = false;

            // En-têtes de colonnes
            dgvLivres.ColumnHeadersHeight = 45;
            dgvLivres.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(173, 216, 230);
            dgvLivres.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLivres.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvLivres.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvLivres.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);

            // Cellules normales
            dgvLivres.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvLivres.DefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);
            dgvLivres.DefaultCellStyle.BackColor =
                Color.FromArgb(255, 255, 255);
            dgvLivres.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 240);
            dgvLivres.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLivres.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            // Lignes alternées
            dgvLivres.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(250, 248, 246);

            // Configuration générale
            dgvLivres.RowTemplate.Height = 40;
            dgvLivres.RowHeadersVisible = false;
            dgvLivres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLivres.MultiSelect = false;
            dgvLivres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLivres.AllowUserToResizeRows = false;
            dgvLivres.AllowUserToAddRows = false;
            dgvLivres.ReadOnly = true;

            // Événements
            dgvLivres.CellClick += DgvLivres_CellClick;
            dgvLivres.CellPainting += DgvLivres_CellPainting;
        }

        private void AddActionButtons()
        {
            AddButtonColumn("Emprunter", "📘 Emprunter", Color.FromArgb(135, 206, 235));
            AddButtonColumn("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
            AddButtonColumn("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));
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

            dgvLivres.Columns.Add(btnColumn);
        }

        private void DgvLivres_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvLivres.Columns["Emprunter"].Index ||
                                   e.ColumnIndex == dgvLivres.Columns["Modifier"].Index ||
                                   e.ColumnIndex == dgvLivres.Columns["Supprimer"].Index))
            {
                e.PaintBackground(e.CellBounds, true);

                // Récupération du nombre d'exemplaires pour le bouton Emprunter
                int exemplaires = 0;
                if (e.ColumnIndex == dgvLivres.Columns["Emprunter"].Index)
                {
                    exemplaires = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["ExemplairesDisponibles"].Value);
                }

                // Créer un rectangle arrondi
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + 5,
                    e.CellBounds.Y + 5,
                    e.CellBounds.Width - 10,
                    e.CellBounds.Height - 10);

                using (GraphicsPath path = GetRoundedRect(rect, 8))
                {
                    Color btnColor;
                    switch (dgvLivres.Columns[e.ColumnIndex].Name)
                    {
                        case "Emprunter":
                            btnColor = exemplaires == 0 ?
                                Color.FromArgb(180, Color.Gray) :
                                Color.FromArgb(135, 206, 235);
                            break;
                        case "Modifier":
                            btnColor = Color.FromArgb(255, 193, 7);
                            break;
                        case "Supprimer":
                            btnColor = Color.FromArgb(220, 53, 69);
                            break;
                        default:
                            btnColor = Color.Gray;
                            break;
                    }

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

        #endregion

        #region Actions sur boutons

        private void DgvLivres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                int livreId = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["Id"].Value);
                string colName = dgvLivres.Columns[e.ColumnIndex].Name;
                int exemplaires = Convert.ToInt32(dgvLivres.Rows[e.RowIndex].Cells["ExemplairesDisponibles"].Value);

                if (colName == "Emprunter")
                {
                    if (exemplaires == 0)
                    {
                        MessageBox.Show("Aucun exemplaire disponible pour l'emprunt.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    new FormEmprunt(livreId).ShowDialog();
                    LoadLivres();
                }
                else if (colName == "Modifier")
                {
                    new FormEditLivre(livreId).ShowDialog();
                    LoadLivres();
                }
                else if (colName == "Supprimer")
                {
                    string titre = dgvLivres.Rows[e.RowIndex].Cells["Titre"].Value?.ToString() ?? "";

                    if (MessageBox.Show($"Voulez-vous vraiment supprimer le livre '{titre}' ?",
                        "Confirmation de suppression",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        livreService.DeleteLivre(livreId);
                        MessageBox.Show("Livre supprimé avec succès !",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLivres();
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
            new FormAddLivre().ShowDialog();
            LoadLivres();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLivres_FormClosing(object sender, FormClosingEventArgs e)
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

        #endregion

        #region Boutons de contrôle

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

        // Import DDL pour déplacement de la fenêtre
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void dgvLivres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nécessaire pour éviter les erreurs, mais le vrai traitement est dans DgvLivres_CellClick
        }

        #endregion
    }
}
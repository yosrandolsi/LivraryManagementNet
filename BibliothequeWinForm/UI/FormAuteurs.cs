using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAuteurs : Form
    {
        private readonly AuteurService auteurService = new AuteurService();

        public FormAuteurs()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FormAuteurs_Load;
        }

        private void FormAuteurs_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(panelContainer, 25);
            ApplyRoundedCorners(btnAjouter, 15);
            ApplyRoundedCorners(btnRetour, 15);
            ApplyRoundedCorners(panelTop, 15);

            // Appliquer les effets visuels
            SetupVisualEffects();

            // Charger les auteurs
            LoadAuteurs();

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

            // Style de l'en-tête (bleu pastel comme les autres interfaces)
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
        // CHARGEMENT DES AUTEURS
        // =========================
        private void LoadAuteurs()
        {
            try
            {
                dgvAuteurs.Columns.Clear();
                dgvAuteurs.AutoGenerateColumns = true;

                var auteurs = auteurService.GetAllAuteurs();
                dgvAuteurs.DataSource = auteurs;

                // Ajouter les colonnes de boutons
                AddButtonColumn("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7)); // Jaune doré
                AddButtonColumn("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69)); // Rouge

                // Masquer la colonne ID si elle existe
                if (dgvAuteurs.Columns.Contains("Id"))
                {
                    dgvAuteurs.Columns["Id"].Visible = false;
                }

                // Ajuster la largeur des colonnes
                if (dgvAuteurs.Columns.Count > 0)
                {
                    if (dgvAuteurs.Columns.Contains("Nom"))
                        dgvAuteurs.Columns["Nom"].Width = 200;
                    if (dgvAuteurs.Columns.Contains("Prenom"))
                        dgvAuteurs.Columns["Prenom"].Width = 200;
                    if (dgvAuteurs.Columns.Contains("Nationalite"))
                        dgvAuteurs.Columns["Nationalite"].Width = 150;
                    if (dgvAuteurs.Columns.Contains("DateNaissance"))
                    {
                        dgvAuteurs.Columns["DateNaissance"].Width = 150;
                        dgvAuteurs.Columns["DateNaissance"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des auteurs: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // STYLE DU TABLEAU
        // =========================
        private void StyleDataGridView()
        {
            dgvAuteurs.BorderStyle = BorderStyle.None;
            dgvAuteurs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuteurs.GridColor = Color.FromArgb(230, 230, 230);

            dgvAuteurs.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvAuteurs.EnableHeadersVisualStyles = false;

            // En-têtes de colonnes (bleu pastel comme les autres interfaces)
            dgvAuteurs.ColumnHeadersHeight = 45;
            dgvAuteurs.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(173, 216, 230); // Bleu clair pastel
            dgvAuteurs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAuteurs.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvAuteurs.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvAuteurs.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);

            // Cellules normales
            dgvAuteurs.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvAuteurs.DefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);
            dgvAuteurs.DefaultCellStyle.BackColor =
                Color.FromArgb(255, 255, 255);
            dgvAuteurs.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 240); // Bleu très clair pour la sélection
            dgvAuteurs.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAuteurs.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            // Lignes alternées
            dgvAuteurs.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(250, 248, 246);

            // Configuration générale
            dgvAuteurs.RowTemplate.Height = 40;
            dgvAuteurs.RowHeadersVisible = false;
            dgvAuteurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuteurs.MultiSelect = false;
            dgvAuteurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvAuteurs.AllowUserToResizeRows = false;
            dgvAuteurs.AllowUserToAddRows = false;
            dgvAuteurs.ReadOnly = true;

            // Événements
            dgvAuteurs.CellClick += dgvAuteurs_CellClick;
            dgvAuteurs.CellPainting += dgvAuteurs_CellPainting;
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

            dgvAuteurs.Columns.Add(btnColumn);
        }

        private void dgvAuteurs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvAuteurs.Columns["Modifier"].Index ||
                                   e.ColumnIndex == dgvAuteurs.Columns["Supprimer"].Index))
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
                    Color btnColor = e.ColumnIndex == dgvAuteurs.Columns["Modifier"].Index
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
        private void dgvAuteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                int auteurId = Convert.ToInt32(dgvAuteurs.Rows[e.RowIndex].Cells["Id"].Value);
                string colName = dgvAuteurs.Columns[e.ColumnIndex].Name;

                if (colName == "Modifier")
                {
                    using (FormEditAuteur form = new FormEditAuteur(auteurId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadAuteurs(); // 🔥 refresh immédiat
                        }
                    }
                }

                else if (colName == "Supprimer")
                {
                    string auteurNom = dgvAuteurs.Rows[e.RowIndex].Cells["Nom"].Value?.ToString() ?? "";
                    string auteurPrenom = dgvAuteurs.Rows[e.RowIndex].Cells["Prenom"].Value?.ToString() ?? "";

                    if (MessageBox.Show($"Voulez-vous vraiment supprimer l'auteur '{auteurPrenom} {auteurNom}' ?",
                        "Confirmation de suppression",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        auteurService.DeleteAuteur(auteurId);
                        MessageBox.Show("Auteur supprimé avec succès !",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAuteurs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // ÉVÉNEMENTS DES BOUTONS
        // =========================
        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            new FormAddAuteur().ShowDialog();
            LoadAuteurs();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAuteurs_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvAuteurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
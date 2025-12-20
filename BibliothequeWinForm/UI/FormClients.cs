using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormClients : Form
    {
        private readonly ClientService clientService = new ClientService();

        public FormClients()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FormClients_Load;
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(panelContainer, 25);
            ApplyRoundedCorners(btnAjouter, 15);
            ApplyRoundedCorners(btnRetour, 15);
            ApplyRoundedCorners(panelTop, 15);
            ApplyRoundedCorners(txtSearch, 10);

            // Appliquer les effets visuels
            SetupVisualEffects();

            // Charger les clients
            LoadClients();

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

            // Style de la zone de recherche
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Paint += (sender, e) =>
            {
                using (Pen borderPen = new Pen(Color.FromArgb(200, 173, 216, 230), 2))
                {
                    Rectangle rect = new Rectangle(0, 0, txtSearch.Width - 1, txtSearch.Height - 1);
                    e.Graphics.DrawRectangle(borderPen, rect);
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
        // CHARGEMENT DES CLIENTS
        // =========================
        private void LoadClients()
        {
            try
            {
                dgvClients.Columns.Clear();
                dgvClients.AutoGenerateColumns = true;

                // Filtrage si recherche en cours
                string searchTerm = txtSearch.Text.Trim().ToLower();
                var clients = clientService.GetAllClients();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    clients = clients
                        .Where(c => c.Nom.ToLower().Contains(searchTerm) ||
                                   c.Prenom.ToLower().Contains(searchTerm) ||
                                   c.CIN.ToLower().Contains(searchTerm))
                        .ToList();
                }

                dgvClients.DataSource = clients;

                // Ajouter les colonnes de boutons
                AddButtonColumn("Detail", "ℹ️ Détails", Color.FromArgb(100, 149, 237)); // Bleu royal
                AddButtonColumn("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7)); // Jaune doré
                AddButtonColumn("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69)); // Rouge

                // Masquer la colonne ID si elle existe
                if (dgvClients.Columns.Contains("Id"))
                {
                    dgvClients.Columns["Id"].Visible = false;
                }

                // Masquer la colonne des emprunts si elle existe
                if (dgvClients.Columns.Contains("Emprunts"))
                {
                    dgvClients.Columns["Emprunts"].Visible = false;
                }

                // Ajuster la largeur des colonnes
                if (dgvClients.Columns.Count > 0)
                {
                    if (dgvClients.Columns.Contains("Nom"))
                        dgvClients.Columns["Nom"].Width = 180;
                    if (dgvClients.Columns.Contains("Prenom"))
                        dgvClients.Columns["Prenom"].Width = 180;
                    if (dgvClients.Columns.Contains("CIN"))
                        dgvClients.Columns["CIN"].Width = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des clients: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // STYLE DU TABLEAU
        // =========================
        private void StyleDataGridView()
        {
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClients.GridColor = Color.FromArgb(230, 230, 230);

            dgvClients.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvClients.EnableHeadersVisualStyles = false;

            // En-têtes de colonnes
            dgvClients.ColumnHeadersHeight = 45;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(173, 216, 230); // Bleu clair pastel
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClients.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvClients.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvClients.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);

            // Cellules normales
            dgvClients.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvClients.DefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);
            dgvClients.DefaultCellStyle.BackColor =
                Color.FromArgb(255, 255, 255);
            dgvClients.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 240); // Bleu très clair pour la sélection
            dgvClients.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClients.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            // Lignes alternées
            dgvClients.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(250, 248, 246);

            // Configuration générale
            dgvClients.RowTemplate.Height = 40;
            dgvClients.RowHeadersVisible = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvClients.AllowUserToResizeRows = false;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.ReadOnly = true;

            // Événements
            dgvClients.CellClick += dgvClients_CellClick;
            dgvClients.CellPainting += dgvClients_CellPainting;
        }

        private void AddButtonColumn(string name, string text, Color color)
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
            {
                Name = name,
                Text = text,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 110
            };

            dgvClients.Columns.Add(btnColumn);
        }

        private void dgvClients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvClients.Columns["Detail"].Index ||
                                   e.ColumnIndex == dgvClients.Columns["Modifier"].Index ||
                                   e.ColumnIndex == dgvClients.Columns["Supprimer"].Index))
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
                    Color btnColor;
                    if (e.ColumnIndex == dgvClients.Columns["Detail"].Index)
                        btnColor = Color.FromArgb(100, 149, 237); // Bleu royal
                    else if (e.ColumnIndex == dgvClients.Columns["Modifier"].Index)
                        btnColor = Color.FromArgb(255, 193, 7); // Jaune doré
                    else
                        btnColor = Color.FromArgb(220, 53, 69); // Rouge

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
        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                int clientId = Convert.ToInt32(dgvClients.Rows[e.RowIndex].Cells["Id"].Value);
                string colName = dgvClients.Columns[e.ColumnIndex].Name;

                if (colName == "Detail")
                {
                    new FormDetailClient(clientId).ShowDialog();
                }
                else if (colName == "Modifier")
                {
                    new FormEditClient(clientId).ShowDialog();
                    LoadClients();
                }
                else if (colName == "Supprimer")
                {
                    string clientNom = dgvClients.Rows[e.RowIndex].Cells["Nom"].Value?.ToString() ?? "";
                    string clientPrenom = dgvClients.Rows[e.RowIndex].Cells["Prenom"].Value?.ToString() ?? "";

                    if (MessageBox.Show($"Voulez-vous vraiment supprimer le client '{clientPrenom} {clientNom}' ?",
                        "Confirmation de suppression",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        clientService.DeleteClient(clientId);
                        MessageBox.Show("Client supprimé avec succès !",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClients();
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
            new FormAddClient().ShowDialog();
            LoadClients();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClients_FormClosing(object sender, FormClosingEventArgs e)
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
        // RECHERCHE
        // =========================
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Timer pour éviter le rechargement à chaque frappe
            Timer searchTimer = new Timer();
            searchTimer.Interval = 500;
            searchTimer.Tick += (s, ev) =>
            {
                LoadClients();
                searchTimer.Stop();
                searchTimer.Dispose();
            };
            searchTimer.Start();
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
    }
}
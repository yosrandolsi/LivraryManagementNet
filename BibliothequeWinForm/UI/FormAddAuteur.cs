using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormAddAuteur : Form
    {
        private readonly AuteurService auteurService;

        public FormAddAuteur()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            auteurService = new AuteurService();
            this.Load += FormAddAuteur_Load;
        }

        private void FormAddAuteur_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(panelContainer, 25);
            ApplyRoundedCorners(btnEnregistrer, 15);
            ApplyRoundedCorners(btnAnnuler, 15);
            ApplyRoundedCorners(panelTop, 15);
            ApplyRoundedCorners(txtNom, 10);
            ApplyRoundedCorners(txtPrenom, 10);

            // Appliquer les effets visuels
            SetupVisualEffects();
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
            AddButtonEffects(btnEnregistrer, btnAnnuler);

            // Style de l'en-tête (vert pastel)
            panelTop.Paint += (sender, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    panelTop.ClientRectangle,
                    Color.FromArgb(255, 144, 238, 144),  // Vert clair pastel
                    Color.FromArgb(255, 152, 251, 152),  // Vert pastel
                    90F))
                {
                    e.Graphics.FillRectangle(brush, panelTop.ClientRectangle);
                }
            };

            // Style des zones de texte
            SetupTextBoxEffects(txtNom);
            SetupTextBoxEffects(txtPrenom);
        }

        private void SetupTextBoxEffects(TextBox textBox)
        {
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 11F);
            textBox.Paint += (sender, e) =>
            {
                using (Pen borderPen = new Pen(Color.FromArgb(200, 144, 238, 144), 2))
                {
                    Rectangle rect = new Rectangle(0, 0, textBox.Width - 1, textBox.Height - 1);
                    e.Graphics.DrawRectangle(borderPen, rect);
                }
            };
        }

        private void AddButtonEffects(params Button[] buttons)
        {
            foreach (Button button in buttons)
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
                    if (button.Name == "btnEnregistrer")
                        button.BackColor = Color.FromArgb(200, 144, 238, 144); // Vert pastel
                    else if (button.Name == "btnAnnuler")
                        button.BackColor = Color.FromArgb(200, 255, 182, 193); // Rose pastel
                };

                // Effet click
                button.Click += (s, e) =>
                {
                    Button btn = (Button)s;
                    Color originalColor = btn.BackColor;
                    btn.BackColor = Color.FromArgb(180, btn.BackColor.R, btn.BackColor.G, btn.BackColor.B);

                    Timer timer = new Timer();
                    timer.Interval = 150;
                    timer.Tick += (timerS, timerE) =>
                    {
                        btn.BackColor = originalColor;
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                };
            }
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
        // ÉVÉNEMENTS DES BOUTONS
        // =========================
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom de l'auteur",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNom.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Veuillez saisir le prénom de l'auteur",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return;
            }

            try
            {
                Auteur auteur = new Auteur
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim()
                };

                auteurService.AddAuteur(auteur);

                MessageBox.Show("Auteur ajouté avec succès !",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'auteur: {ex.Message}",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddAuteur_FormClosing(object sender, FormClosingEventArgs e)
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
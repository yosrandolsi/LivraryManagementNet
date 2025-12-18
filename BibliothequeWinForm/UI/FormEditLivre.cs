using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditLivre : Form
    {
        private readonly LivreService livreService;
        private readonly AuteurService auteurService;
        private readonly CategorieService categorieService;
        private readonly int livreId;
        private Livre currentLivre;

        public FormEditLivre(int livreId)
        {
            InitializeComponent();
            this.livreId = livreId;

            livreService = new LivreService();
            auteurService = new AuteurService();
            categorieService = new CategorieService();

            SetupVisualEffects();
            ApplyRoundedCorners();
            LoadComboBoxes();
            LoadLivreData();
        }

        private void SetupVisualEffects()
        {
            // Style du formulaire
            this.BackColor = Color.FromArgb(255, 245, 235, 230);

            // Arrondir les bords du formulaire
            ApplyRoundedFormCorners(30);

            // Appliquer les effets aux boutons
            SetupButtonEffects();

            // Appliquer les effets aux champs
            SetupControlEffects();
        }

        private void ApplyRoundedFormCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void ApplyRoundedCorners()
        {
            ApplyRoundedControl(txtTitre, 15);
            ApplyRoundedControl(cmbAuteurs, 15);
            ApplyRoundedControl(cmbCategories, 15);
            ApplyRoundedControl(numExemplaires, 15);
            ApplyRoundedControl(btnEnregistrer, 20);
            ApplyRoundedControl(btnAnnuler, 20);
        }

        private void ApplyRoundedControl(Control control, int radius)
        {
            if (control == null) return;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            if (control is TextBox || control is ComboBox || control is NumericUpDown)
            {
                control.Region = new Region(path);
            }
        }

        private void SetupButtonEffects()
        {
            Button[] buttons = { btnEnregistrer, btnAnnuler };

            foreach (Button btn in buttons)
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.ForeColor = Color.White;

                if (btn == btnEnregistrer)
                {
                    btn.BackColor = Color.FromArgb(200, 144, 238, 144); // pastel vert
                }
                else
                {
                    btn.BackColor = Color.FromArgb(200, 255, 182, 193); // pastel rose
                }

                btn.Paint += (sender, e) =>
                {
                    Button button = (Button)sender;
                    if (button.Enabled)
                    {
                        using (GraphicsPath path = CreateRoundedPath(button.ClientRectangle, 20))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            // Ombre
                            using (Pen shadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 3))
                            {
                                e.Graphics.DrawPath(shadowPen, path);
                            }

                            // Surbrillance
                            RectangleF highlightRect = new RectangleF(5, 5, button.Width - 10, 15);
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

                btn.MouseEnter += (sender, e) =>
                {
                    Button button = (Button)sender;
                    button.BackColor = Color.FromArgb(220, button.BackColor.R, button.BackColor.G, button.BackColor.B);
                };

                btn.MouseLeave += (sender, e) =>
                {
                    Button button = (Button)sender;
                    if (button == btnEnregistrer)
                    {
                        button.BackColor = Color.FromArgb(200, 144, 238, 144);
                    }
                    else
                    {
                        button.BackColor = Color.FromArgb(200, 255, 182, 193);
                    }
                };

                btn.Click += (sender, e) =>
                {
                    Button button = (Button)sender;
                    Color originalColor = button.BackColor;
                    button.BackColor = Color.FromArgb(180, button.BackColor.R, button.BackColor.G, button.BackColor.B);

                    Timer timer = new Timer();
                    timer.Interval = 150;
                    timer.Tick += (s, ev) =>
                    {
                        button.BackColor = originalColor;
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                };
            }
        }

        private void SetupControlEffects()
        {
            // Style des labels
            Label[] labels = { lblTitre, lblAuteur, lblCategorie, lblExemplaires };
            foreach (Label lbl in labels)
            {
                lbl.Font = new Font("Segoe UI Semibold", 11);
                lbl.ForeColor = Color.FromArgb(100, 80, 80, 80);
            }

            // Style des ComboBox
            cmbAuteurs.Font = new Font("Segoe UI", 11);
            cmbAuteurs.BackColor = Color.White;
            cmbAuteurs.ForeColor = Color.FromArgb(64, 64, 64);

            cmbCategories.Font = new Font("Segoe UI", 11);
            cmbCategories.BackColor = Color.White;
            cmbCategories.ForeColor = Color.FromArgb(64, 64, 64);

            // Style des TextBox
            txtTitre.Font = new Font("Segoe UI", 11);
            txtTitre.BackColor = Color.White;
            txtTitre.ForeColor = Color.FromArgb(64, 64, 64);

            // Style des NumericUpDown
            numExemplaires.Font = new Font("Segoe UI", 11);
            numExemplaires.BackColor = Color.White;
            numExemplaires.ForeColor = Color.FromArgb(64, 64, 64);
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

        private void LoadComboBoxes()
        {
            var auteurs = auteurService.GetAllAuteurs();
            cmbAuteurs.DataSource = auteurs;
            cmbAuteurs.DisplayMember = "Nom";
            cmbAuteurs.ValueMember = "Id";

            var categories = categorieService.GetAllCategories();
            cmbCategories.DataSource = categories;
            cmbCategories.DisplayMember = "Nom";
            cmbCategories.ValueMember = "Id";
        }

        private void LoadLivreData()
        {
            currentLivre = livreService.GetLivreById(livreId);
            if (currentLivre == null)
            {
                MessageBox.Show("Livre introuvable !", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtTitre.Text = currentLivre.Titre;
            cmbAuteurs.SelectedValue = currentLivre.AuteurId;
            cmbCategories.SelectedValue = currentLivre.CategorieId;
            numExemplaires.Value = currentLivre.ExemplairesDisponibles;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitre.Text))
            {
                MessageBox.Show("Veuillez saisir le titre du livre.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentLivre.Titre = txtTitre.Text;
            currentLivre.AuteurId = (int)cmbAuteurs.SelectedValue;
            currentLivre.CategorieId = (int)cmbCategories.SelectedValue;
            currentLivre.ExemplairesDisponibles = (int)numExemplaires.Value;

            livreService.UpdateLivre(currentLivre);
            MessageBox.Show("Livre modifié avec succès !", "Succès",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditLivre_Load(object sender, EventArgs e)
        {
            // Code de chargement supplémentaire si nécessaire
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
            Timer fadeTimer = new Timer();
            fadeTimer.Interval = 20;
            fadeTimer.Tick += (s, ev) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.05;
                else
                {
                    fadeTimer.Stop();
                    this.Close();
                }
            };
            fadeTimer.Start();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
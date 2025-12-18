using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormConnexion : Form
    {
        private readonly AdminService adminService = new AdminService();

        public FormConnexion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupVisualEffects();
            ApplyRoundedCorners();
            LoadImage();
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
            ApplyRoundedControl(txtUsername, 15);
            ApplyRoundedControl(txtPassword, 15);
            ApplyRoundedControl(btnLogin, 20);
            ApplyRoundedControl(btnRegister, 20);
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

            if (control is TextBox)
            {
                control.Region = new Region(path);
            }
        }

        private void SetupButtonEffects()
        {
            Button[] buttons = { btnLogin, btnRegister };

            foreach (Button btn in buttons)
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.ForeColor = Color.White;

                if (btn == btnLogin)
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
                    if (button == btnLogin)
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
            Label[] labels = { lblUsername, lblPassword };
            foreach (Label lbl in labels)
            {
                lbl.Font = new Font("Segoe UI Semibold", 11);
                lbl.ForeColor = Color.FromArgb(100, 80, 80, 80);
            }

            // Style des TextBox
            txtUsername.Font = new Font("Segoe UI", 11);
            txtUsername.BackColor = Color.White;
            txtUsername.ForeColor = Color.FromArgb(64, 64, 64);

            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
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

        private void LoadImage()
        {
            try
            {
                // Chemin vers l'image de bibliothèque
                string imagePath = @"D:\2eme_ing\.NET\BibliothequeWinForm\BibliothequeWinForm\Assets\login.png";

                if (System.IO.File.Exists(imagePath))
                {
                    Image originalImage = Image.FromFile(imagePath);
                    pictureBoxConnexion.Image = originalImage;
                    pictureBoxConnexion.SizeMode = PictureBoxSizeMode.Zoom;

                    // Appliquer des coins arrondis à l'image
                    ApplyRoundedPictureBox();
                }
                else
                {
                    CreateFallbackImage();
                }
            }
            catch (Exception ex)
            {
                CreateFallbackImage();
                MessageBox.Show($"Impossible de charger l'image: {ex.Message}", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ApplyRoundedPictureBox()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pictureBoxConnexion.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pictureBoxConnexion.Width - radius, pictureBoxConnexion.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pictureBoxConnexion.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            pictureBoxConnexion.Region = new Region(path);
        }

        private void CreateFallbackImage()
        {
            Bitmap fallback = new Bitmap(pictureBoxConnexion.Width, pictureBoxConnexion.Height);

            using (Graphics g = Graphics.FromImage(fallback))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, fallback.Width, fallback.Height),
                    Color.FromArgb(255, 245, 235, 230),
                    Color.FromArgb(255, 235, 225, 220),
                    45F))
                {
                    g.FillRectangle(bgBrush, 0, 0, fallback.Width, fallback.Height);
                }

                using (Font font = new Font("Segoe UI", 16, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(120, 80, 80, 80)))
                {
                    string text = "🔐 Connexion";
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, textBrush,
                        (fallback.Width - textSize.Width) / 2,
                        (fallback.Height - textSize.Height) / 2);
                }
            }

            pictureBoxConnexion.Image = fallback;
            pictureBoxConnexion.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // 🔹 Bouton Login redirige directement vers FormMenu
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (adminService.Login(txtUsername.Text, txtPassword.Text))
            {
                FormMenu menu = new FormMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect",
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            this.Hide();
        }

        private void FormConnexion_Load(object sender, EventArgs e)
        {

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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
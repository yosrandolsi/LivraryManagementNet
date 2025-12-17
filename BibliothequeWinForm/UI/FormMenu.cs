using BibliothequeWinForm.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm
{
    public partial class FormMenu : Form
    {
        private Form activeForm = null;

        public FormMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FormMenu_Load;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Appliquer les coins arrondis
            ApplyRoundedCorners(panelContainer, 30);
            ApplyRoundedCorners(btnAuteurs, 20);
            ApplyRoundedCorners(btnLivres, 20);
            ApplyRoundedCorners(btnCategories, 20);
            ApplyRoundedClients(20);
            ApplyRoundedCorners(btnEmprunts, 20);

            // Appliquer les effets visuels
            SetupVisualEffects();

            // Charger l'image avec des effets d'ombre
            LoadImageWithShadowEffects();
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

        private void ApplyRoundedClients(int radius)
        {
            ApplyRoundedCorners(btnClients, radius);
        }

        private void SetupVisualEffects()
        {
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
            };

            AddButtonShadows();
        }

        private void AddButtonShadows()
        {
            Button[] buttons = { btnAuteurs, btnLivres, btnCategories, btnClients, btnEmprunts };

            foreach (Button btn in buttons)
            {
                btn.Paint += (sender, e) =>
                {
                    Button button = (Button)sender;
                    if (button.Enabled)
                    {
                        using (GraphicsPath path = CreateRoundedPath(button.ClientRectangle, 20))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            using (Pen shadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 3))
                            {
                                e.Graphics.DrawPath(shadowPen, path);
                            }

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

        private void LoadImageWithShadowEffects()
        {
            try
            {
                Image originalImage = Image.FromFile("Assets/library.jpg");
                Bitmap processedImage = CreateShadowedImage(originalImage, pictureBoxLibrary.Width, pictureBoxLibrary.Height);
                pictureBoxLibrary.Image = processedImage;
                pictureBoxLibrary.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxLibrary.BackColor = Color.Transparent;
                ApplyRoundedCorners(pictureBoxLibrary, 15);
            }
            catch (Exception ex)
            {
                CreateFallbackImage();
                MessageBox.Show($"Impossible de charger l'image: {ex.Message}", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Bitmap CreateShadowedImage(Image original, int targetWidth, int targetHeight)
        {
            int padding = 30;
            Bitmap result = new Bitmap(targetWidth + padding * 2, targetHeight + padding * 2);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                Rectangle shadowRect = new Rectangle(padding - 5, padding + 5, targetWidth, targetHeight);
                using (GraphicsPath shadowPath = CreateRoundedPath(shadowRect, 20))
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(80, 0, 0, 0);
                    shadowBrush.SurroundColors = new Color[] { Color.Transparent };
                    g.FillPath(shadowBrush, shadowPath);
                }

                Rectangle imageRect = new Rectangle(padding, padding, targetWidth, targetHeight);
                using (GraphicsPath imagePath = CreateRoundedPath(imageRect, 15))
                {
                    g.SetClip(imagePath);
                    g.DrawImage(original, imageRect);
                    g.ResetClip();

                    using (Pen borderPen = new Pen(Color.FromArgb(180, 255, 255, 255), 3))
                    {
                        g.DrawPath(borderPen, imagePath);
                    }
                }

                Rectangle reflectionRect = new Rectangle(padding, padding + targetHeight - 30, targetWidth, 30);
                using (LinearGradientBrush reflectionBrush = new LinearGradientBrush(
                    reflectionRect,
                    Color.FromArgb(100, 255, 255, 255),
                    Color.Transparent,
                    90F))
                {
                    g.FillRectangle(reflectionBrush, reflectionRect);
                }
            }

            return result;
        }

        private void CreateFallbackImage()
        {
            Bitmap fallback = new Bitmap(pictureBoxLibrary.Width, pictureBoxLibrary.Height);

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

                DrawLibraryIcon(g, fallback.Width, fallback.Height);

                using (Font font = new Font("Segoe UI", 16, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(120, 80, 80, 80)))
                {
                    string text = "Bibliothèque";
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, textBrush,
                        (fallback.Width - textSize.Width) / 2,
                        (fallback.Height - textSize.Height) / 2);
                }
            }

            pictureBoxLibrary.Image = fallback;
            pictureBoxLibrary.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DrawLibraryIcon(Graphics g, int width, int height)
        {
            int centerX = width / 2;
            int centerY = height / 2;

            Rectangle buildingRect = new Rectangle(centerX - 60, centerY - 40, 120, 80);
            using (LinearGradientBrush buildingBrush = new LinearGradientBrush(
                buildingRect,
                Color.FromArgb(255, 255, 182, 193),
                Color.FromArgb(255, 255, 192, 203),
                90F))
            {
                g.FillRectangle(buildingBrush, buildingRect);
            }

            Rectangle doorRect = new Rectangle(centerX - 15, centerY, 30, 40);
            g.FillRectangle(Brushes.PeachPuff, doorRect);

            Rectangle window1 = new Rectangle(centerX - 40, centerY - 20, 15, 15);
            Rectangle window2 = new Rectangle(centerX + 25, centerY - 20, 15, 15);
            g.FillRectangle(Brushes.LightBlue, window1);
            g.FillRectangle(Brushes.LightBlue, window2);

            Point[] roofPoints = {
                new Point(centerX - 70, centerY - 40),
                new Point(centerX, centerY - 70),
                new Point(centerX + 70, centerY - 40)
            };
            g.FillPolygon(Brushes.LightCoral, roofPoints);
        }

        // Méthode pour ouvrir les formulaires enfants dans panelContainer
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Gestionnaires d'événements pour les boutons
        private void BtnAuteurs_Click(object sender, EventArgs e)
        {
            ApplyButtonClickEffect(btnAuteurs);
            OpenChildForm(new FormAuteurs());
        }

        private void BtnLivres_Click(object sender, EventArgs e)
        {
            ApplyButtonClickEffect(btnLivres);
            OpenChildForm(new FormLivres());
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            ApplyButtonClickEffect(btnCategories);
            OpenChildForm(new FormCategories());
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            ApplyButtonClickEffect(btnClients);
            OpenChildForm(new FormClients());
        }

        private void BtnEmprunts_Click(object sender, EventArgs e)
        {
            ApplyButtonClickEffect(btnEmprunts);
            OpenChildForm(new FormGestionEmprunts());
        }

        private void ApplyButtonClickEffect(Button button)
        {
            Color originalColor = button.BackColor;
            button.BackColor = Color.FromArgb(200, button.BackColor.R, button.BackColor.G, button.BackColor.B);

            Timer timer = new Timer();
            timer.Interval = 150;
            timer.Tick += (s, ev) =>
            {
                button.BackColor = originalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void LblExit_Click(object sender, EventArgs e)
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
                    Application.Exit();
                }
            };
            fadeTimer.Start();
        }

        private void BtnClose_Click(object sender, EventArgs e) => LblExit_Click(sender, e);

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
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

        private void PictureBoxLibrary_Click(object sender, EventArgs e)
        {
            Timer pulseTimer = new Timer();
            pulseTimer.Interval = 50;
            int pulseCount = 0;

            pulseTimer.Tick += (s, ev) =>
            {
                pulseCount++;
                if (pulseCount <= 5)
                {
                    pictureBoxLibrary.Size = new Size(
                        pictureBoxLibrary.Width + (pulseCount % 2 == 0 ? 5 : -5),
                        pictureBoxLibrary.Height + (pulseCount % 2 == 0 ? 5 : -5));
                }
                else
                {
                    pictureBoxLibrary.Size = new Size(600, 400);
                    pulseTimer.Stop();
                    pulseTimer.Dispose();
                }
            };
            pulseTimer.Start();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e) { }

        private void panelImage_Paint(object sender, PaintEventArgs e) { }
    }
}

using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormEditClient : Form
    {
        private Client client;
        private readonly ClientService clientService;

        public FormEditClient(int clientId)
        {
            InitializeComponent();
            clientService = new ClientService();
            client = clientService.GetClientById(clientId);
            SetupVisualEffects();
            ApplyRoundedCorners();
            LoadClientData();
        }

        public FormEditClient(Client client)
        {
            InitializeComponent();
            clientService = new ClientService();
            this.client = client;
            SetupVisualEffects();
            ApplyRoundedCorners();
            LoadClientData();
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
            ApplyRoundedControl(txtNom, 15);
            ApplyRoundedControl(txtPrenom, 15);
            ApplyRoundedControl(txtCIN, 15);
            ApplyRoundedControl(btnSave, 20);
            ApplyRoundedControl(btnCancel, 20);
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

            if (control is TextBox || control is Button)
            {
                control.Region = new Region(path);
            }
        }

        private void SetupButtonEffects()
        {
            Button[] buttons = { btnSave, btnCancel };

            foreach (Button btn in buttons)
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.ForeColor = Color.White;

                if (btn == btnSave)
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
                    if (button == btnSave)
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
            Label[] labels = { lblNom, lblPrenom, lblCIN };
            foreach (Label lbl in labels)
            {
                lbl.Font = new Font("Segoe UI Semibold", 11);
                lbl.ForeColor = Color.FromArgb(100, 80, 80, 80);
            }

            // Style des TextBox
            TextBox[] textBoxes = { txtNom, txtPrenom, txtCIN };
            foreach (TextBox txt in textBoxes)
            {
                txt.Font = new Font("Segoe UI", 11);
                txt.BackColor = Color.White;
                txt.ForeColor = Color.FromArgb(64, 64, 64);
                txt.BorderStyle = BorderStyle.None;
                txt.Padding = new Padding(10);
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

        private void LoadClientData()
        {
            if (client != null)
            {
                txtNom.Text = client.Nom;
                txtPrenom.Text = client.Prenom;
                txtCIN.Text = client.CIN;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtCIN.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            client.Nom = txtNom.Text.Trim();
            client.Prenom = txtPrenom.Text.Trim();
            client.CIN = txtCIN.Text.Trim();

            clientService.UpdateClient(client);

            MessageBox.Show("Client mis à jour avec succès !", "Succès",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditClient_Load(object sender, EventArgs e)
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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            // Dessiner une bordure subtile autour du container
            using (Pen pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
            }
        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {
            // Effet de fond subtil
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panelForm.ClientRectangle,
                Color.FromArgb(10, 255, 255, 255),
                Color.Transparent,
                45F))
            {
                e.Graphics.FillRectangle(brush, panelForm.ClientRectangle);
            }
        }
    }
}
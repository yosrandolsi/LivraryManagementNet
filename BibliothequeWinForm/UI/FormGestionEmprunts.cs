using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    public partial class FormGestionEmprunts : Form
    {
        private readonly EmpruntService _empruntService;

        public FormGestionEmprunts()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _empruntService = new EmpruntService();
            this.Load += FormGestionEmprunts_Load;
        }

        private void FormGestionEmprunts_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners(panelContainer, 25);
            ApplyRoundedCorners(btnRetour, 15);
            ApplyRoundedCorners(panelTop, 15);

            SetupVisualEffects();
            StyleDataGridView();
            LoadEmprunts();
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

                using (Pen borderPen = new Pen(Color.FromArgb(180, 210, 210, 210), 1))
                {
                    Rectangle borderRect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
                    e.Graphics.DrawRectangle(borderPen, borderRect);
                }
            };

            AddButtonEffects(btnRetour);

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
                        using (Pen shadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 2))
                        {
                            e.Graphics.DrawPath(shadowPen, path);
                        }

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

            button.MouseEnter += (s, e) =>
            {
                button.BackColor = Color.FromArgb(220, button.BackColor.R, button.BackColor.G, button.BackColor.B);
            };
            button.MouseLeave += (s, e) =>
            {
                if (button.Name == "btnRetour")
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

        private void StyleDataGridView()
        {
            dgvEmprunts.BorderStyle = BorderStyle.None;
            dgvEmprunts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmprunts.GridColor = Color.FromArgb(230, 230, 230);

            dgvEmprunts.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvEmprunts.EnableHeadersVisualStyles = false;

            dgvEmprunts.ColumnHeadersHeight = 45;
            dgvEmprunts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230);
            dgvEmprunts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmprunts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvEmprunts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmprunts.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);

            dgvEmprunts.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvEmprunts.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvEmprunts.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dgvEmprunts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 240);
            dgvEmprunts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEmprunts.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            dgvEmprunts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 248, 246);

            dgvEmprunts.RowTemplate.Height = 40;
            dgvEmprunts.RowHeadersVisible = false;
            dgvEmprunts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmprunts.MultiSelect = false;
            dgvEmprunts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvEmprunts.AllowUserToResizeRows = false;
            dgvEmprunts.AllowUserToAddRows = false;
            dgvEmprunts.ReadOnly = true;

            dgvEmprunts.CellClick += DgvEmprunts_CellClick;
            dgvEmprunts.CellPainting += DgvEmprunts_CellPainting;
        }

        private void LoadEmprunts()
        {
            try
            {
                dgvEmprunts.Columns.Clear();
                dgvEmprunts.AutoGenerateColumns = false;

                dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
                dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Livre", DataPropertyName = "LivreTitre", Width = 200, ReadOnly = true });
                dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Client", DataPropertyName = "ClientNom", Width = 180, ReadOnly = true });
                dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Emprunt", DataPropertyName = "DateEmprunt", Width = 120, ReadOnly = true });
                dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Retour", DataPropertyName = "DateRetour", Width = 120, ReadOnly = true });

                AddButtonColumn("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
                AddButtonColumn("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));

                var emprunts = _empruntService.GetAllEmprunts()
                    .Select(e => new
                    {
                        e.Id,
                        LivreTitre = e.Livre?.Titre ?? "N/A",
                        ClientNom = e.Client != null ? $"{e.Client.Nom} {e.Client.Prenom}" : "N/A",
                        DateEmprunt = e.DateEmprunt.ToString("dd/MM/yyyy"),
                        DateRetour = e.DateRetour?.ToString("dd/MM/yyyy") ?? "En cours"
                    })
                    .ToList();

                dgvEmprunts.DataSource = emprunts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des emprunts: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            dgvEmprunts.Columns.Add(btnColumn);
        }

        private void DgvEmprunts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvEmprunts.Columns["Modifier"].Index ||
                                   e.ColumnIndex == dgvEmprunts.Columns["Supprimer"].Index))
            {
                e.PaintBackground(e.CellBounds, true);

                Rectangle rect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 5, e.CellBounds.Width - 10, e.CellBounds.Height - 10);

                using (GraphicsPath path = GetRoundedRect(rect, 8))
                {
                    Color btnColor = e.ColumnIndex == dgvEmprunts.Columns["Modifier"].Index
                        ? Color.FromArgb(255, 193, 7)
                        : Color.FromArgb(220, 53, 69);

                    using (SolidBrush brush = new SolidBrush(btnColor))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, path);
                    }

                    using (Pen borderPen = new Pen(Color.FromArgb(150, Color.White), 1))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }

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

        private void DgvEmprunts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                int empruntId = Convert.ToInt32(dgvEmprunts.Rows[e.RowIndex].Cells["Id"].Value);
                string colName = dgvEmprunts.Columns[e.ColumnIndex].Name;

                var emprunt = _empruntService.GetAllEmprunts().FirstOrDefault(x => x.Id == empruntId);
                if (emprunt == null) return;

                string livre = emprunt.Livre?.Titre ?? "N/A";
                string client = emprunt.Client != null ? $"{emprunt.Client.Nom} {emprunt.Client.Prenom}" : "N/A";

                if (colName == "Modifier")
                {
                    ModifierEmprunt(empruntId);
                }
                else if (colName == "Supprimer")
                {
                    if (MessageBox.Show($"Voulez-vous vraiment supprimer l'emprunt de '{livre}' par {client} ?",
                        "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // Incrémenter les exemplaires disponibles
                        if (emprunt.Livre != null)
                        {
                            emprunt.Livre.ExemplairesDisponibles++;
                        }

                        _empruntService.DeleteEmprunt(empruntId);

                        MessageBox.Show("Emprunt supprimé et exemplaires mis à jour !",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadEmprunts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifierEmprunt(int empruntId)
        {
            var emprunt = _empruntService.GetAllEmprunts().FirstOrDefault(x => x.Id == empruntId);
            if (emprunt == null) return;

            Form editForm = new Form
            {
                Text = "Modifier Date de Retour",
                Width = 300,
                Height = 150,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            DateTimePicker dtpRetour = new DateTimePicker
            {
                Value = emprunt.DateRetour ?? DateTime.Now,
                Format = DateTimePickerFormat.Short,
                Location = new Point(20, 20),
                Width = 250
            };

            Button btnOk = new Button
            {
                Text = "OK",
                Location = new Point(100, 60),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(144, 238, 144),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White
            };

            btnOk.Click += (s, ev) =>
            {
                emprunt.DateRetour = dtpRetour.Value;
                _empruntService.UpdateEmprunt(emprunt);
                MessageBox.Show("Date de retour modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                editForm.Close();
                LoadEmprunts();
            };

            editForm.Controls.Add(dtpRetour);
            editForm.Controls.Add(btnOk);
            editForm.ShowDialog();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGestionEmprunts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Timer fadeTimer = new Timer { Interval = 20 };
                fadeTimer.Tick += (s, ev) =>
                {
                    if (this.Opacity > 0.1) this.Opacity -= 0.1;
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

        private void BtnClose_Click(object sender, EventArgs e) => this.Close();
        private void BtnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
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
    }
}

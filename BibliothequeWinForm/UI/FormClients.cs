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
            SetupVisualEffects();
            LoadClients();
            StyleDataGridView();
            SetupButtonEffects();
        }

        #region Styles et effets

        private void SetupVisualEffects()
        {
            this.BackColor = Color.FromArgb(255, 245, 235, 230);
            ApplyRoundedFormCorners(30);
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

        private void SetupButtonEffects()
        {
            btnAjouter.FlatAppearance.BorderSize = 0;
            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnAjouter.ForeColor = Color.White;
            btnAjouter.BackColor = Color.FromArgb(200, 173, 216, 230);

            btnAjouter.MouseEnter += (s, e) =>
            {
                btnAjouter.BackColor = Color.FromArgb(220, 173, 216, 230);
            };
            btnAjouter.MouseLeave += (s, e) =>
            {
                btnAjouter.BackColor = Color.FromArgb(200, 173, 216, 230);
            };
        }

        private void StyleDataGridView()
        {
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClients.GridColor = Color.FromArgb(230, 230, 230);
            dgvClients.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvClients.EnableHeadersVisualStyles = false;

            dgvClients.ColumnHeadersHeight = 42;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230);
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvClients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvClients.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvClients.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvClients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 240);
            dgvClients.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvClients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 236, 233);

            dgvClients.RowTemplate.Height = 40;
            dgvClients.RowHeadersVisible = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #endregion

        #region Gestion Clients

        private void LoadClients()
        {
            dgvClients.Columns.Clear();

            // Filtrage si recherche en cours
            string searchTerm = txtSearch.Text.Trim().ToLower();
            var clients = string.IsNullOrEmpty(searchTerm)
                ? clientService.GetAllClients()
                : clientService.GetAllClients()
                               .Where(c => c.Nom.ToLower().Contains(searchTerm))
                               .ToList();

            dgvClients.DataSource = clients;

            AddButton("Detail", "ℹ️ Détails", Color.FromArgb(0, 123, 255));
            AddButton("Modifier", "✏️ Modifier", Color.FromArgb(255, 193, 7));
            AddButton("Supprimer", "🗑 Supprimer", Color.FromArgb(220, 53, 69));
        }

        private void AddButton(string name, string text, Color color)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = name,
                Text = text,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 120
            };
            dgvClients.Columns.Add(btn);

            dgvClients.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvClients.Columns[e.ColumnIndex].Name == name)
                {
                    e.PaintBackground(e.CellBounds, true);

                    Rectangle rect = new Rectangle(
                        e.CellBounds.X + 6,
                        e.CellBounds.Y + 6,
                        e.CellBounds.Width - 12,
                        e.CellBounds.Height - 12);

                    using (GraphicsPath path = GetRoundedRect(rect, 12))
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brush, path);

                        TextRenderer.DrawText(
                            e.Graphics,
                            text,
                            new Font("Segoe UI", 9.5F, FontStyle.Bold),
                            rect,
                            Color.White,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    e.Handled = true;
                }
            };
        }

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

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int clientId = (int)dgvClients.Rows[e.RowIndex].Cells["Id"].Value;

            if (dgvClients.Columns[e.ColumnIndex].Name == "Detail")
            {
                new FormDetailClient(clientId).ShowDialog();
            }
            else if (dgvClients.Columns[e.ColumnIndex].Name == "Modifier")
            {
                new FormEditClient(clientId).ShowDialog();
                LoadClients();
            }
            else if (dgvClients.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                if (MessageBox.Show("Supprimer ce client ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clientService.DeleteClient(clientId);
                    LoadClients();
                }
            }
        }

        #endregion

        #region Événements

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormAddClient formAdd = new FormAddClient();
            formAdd.ShowDialog();
            LoadClients();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadClients(); // Recharge la grille selon la recherche
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            dgvClients.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #endregion

        #region Bouton retour vers FormMenu

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Hide();
        }

        #endregion

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

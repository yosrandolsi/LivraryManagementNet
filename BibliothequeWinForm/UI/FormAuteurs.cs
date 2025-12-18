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
            SetupVisualEffects();
            LoadAuteurs();
            StyleDataGridView();
        }

        private void SetupVisualEffects()
        {
            this.BackColor = Color.FromArgb(245, 235, 230);
            ApplyRoundedFormCorners(20);
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

        private void StyleDataGridView()
        {
            dgvAuteurs.BorderStyle = BorderStyle.None;
            dgvAuteurs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuteurs.GridColor = Color.FromArgb(230, 230, 230);

            dgvAuteurs.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvAuteurs.EnableHeadersVisualStyles = false;

            dgvAuteurs.ColumnHeadersHeight = 42;
            dgvAuteurs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
            dgvAuteurs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAuteurs.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvAuteurs.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAuteurs.DefaultCellStyle.Font =
                new Font("Segoe UI", 10.5F);
            dgvAuteurs.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvAuteurs.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 240, 245);
            dgvAuteurs.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvAuteurs.RowTemplate.Height = 40;
            dgvAuteurs.RowHeadersVisible = false;
            dgvAuteurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuteurs.MultiSelect = false;
            dgvAuteurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAuteurs()
        {
            dgvAuteurs.Columns.Clear();
            dgvAuteurs.DataSource = auteurService.GetAllAuteurs();

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
            dgvAuteurs.Columns.Add(btn);

            dgvAuteurs.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvAuteurs.Columns[e.ColumnIndex].Name == name)
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

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            new FormAddAuteur().ShowDialog();
            LoadAuteurs();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Hide(); // Masque le formulaire actuel
            FormMenu menu = new FormMenu();
            menu.Show();
        }


        private void dgvAuteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int auteurId = (int)dgvAuteurs.Rows[e.RowIndex].Cells["Id"].Value;

            if (dgvAuteurs.Columns[e.ColumnIndex].Name == "Modifier")
            {
                new FormEditAuteur(auteurId).ShowDialog();
                LoadAuteurs();
            }

            if (dgvAuteurs.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                if (MessageBox.Show("Supprimer cet auteur ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    auteurService.DeleteAuteur(auteurId);
                    LoadAuteurs();
                }
            }
        }

        private void FormAuteurs_Load(object sender, EventArgs e)
        {
            dgvAuteurs.ClearSelection();
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

        private void dgvAuteurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

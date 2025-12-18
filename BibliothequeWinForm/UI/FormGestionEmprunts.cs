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
            _empruntService = new EmpruntService();
            SetupVisualEffects();
            StyleDataGridView();
        }

        private void SetupVisualEffects()
        {
            // Style du formulaire
            this.BackColor = Color.FromArgb(255, 245, 235, 230);

            // Arrondir les bords du formulaire
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

        private void StyleDataGridView()
        {
            dgvEmprunts.BorderStyle = BorderStyle.None;
            dgvEmprunts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmprunts.GridColor = Color.FromArgb(230, 230, 230);

            dgvEmprunts.BackgroundColor = Color.FromArgb(248, 244, 242);
            dgvEmprunts.EnableHeadersVisualStyles = false;

            dgvEmprunts.ColumnHeadersHeight = 42;
            dgvEmprunts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(178, 214, 255);
            dgvEmprunts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmprunts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvEmprunts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEmprunts.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvEmprunts.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvEmprunts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgvEmprunts.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvEmprunts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 246, 255);

            dgvEmprunts.RowTemplate.Height = 40;
            dgvEmprunts.RowHeadersVisible = false;
            dgvEmprunts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmprunts.MultiSelect = false;
        }

        private void FormGestionEmprunts_Load(object sender, EventArgs e)
        {
            dgvEmprunts.AutoGenerateColumns = false;
            dgvEmprunts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmprunts.MultiSelect = false;

            dgvEmprunts.Columns.Clear();

            // Boutons Modifier et Supprimer
            dgvEmprunts.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Modifier",
                UseColumnTextForButtonValue = true,
                Width = 80
            });
            dgvEmprunts.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            // Colonnes de données
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Livre", DataPropertyName = "LivreTitre", ReadOnly = true, Width = 150 });
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Client", DataPropertyName = "ClientNom", ReadOnly = true, Width = 150 });
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Emprunt", DataPropertyName = "DateEmprunt", ReadOnly = true, Width = 120 });
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Retour", DataPropertyName = "DateRetour", ReadOnly = true, Width = 120 });

            dgvEmprunts.CellClick += DgvEmprunts_CellClick;

            LoadEmprunts();
        }

        private void LoadEmprunts()
        {
            dgvEmprunts.DataSource = null;

            var emprunts = _empruntService.GetAllEmprunts()
                .Select(e => new
                {
                    e.Id,
                    LivreTitre = e.Livre?.Titre ?? "",
                    ClientNom = e.Client != null ? $"{e.Client.Nom} {e.Client.Prenom}" : "",
                    DateEmprunt = e.DateEmprunt.ToShortDateString(),
                    DateRetour = e.DateRetour?.ToShortDateString() ?? ""
                })
                .ToList();

            dgvEmprunts.DataSource = emprunts;
        }

        private void DgvEmprunts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int empruntId = Convert.ToInt32(dgvEmprunts.Rows[e.RowIndex].Cells["Id"].Value);

            if (e.ColumnIndex == 0) ModifierEmprunt(empruntId);
            else if (e.ColumnIndex == 1) SupprimerEmprunt(empruntId);
        }

        private void ModifierEmprunt(int empruntId)
        {
            var emprunt = _empruntService.GetAllEmprunts().FirstOrDefault(x => x.Id == empruntId);
            if (emprunt == null) return;

            DateTimePicker dtp = new DateTimePicker { Value = emprunt.DateRetour ?? DateTime.Now };
            Form f = new Form { Width = 250, Height = 100, Text = "Modifier Date Retour" };
            dtp.Dock = DockStyle.Fill;
            f.Controls.Add(dtp);
            Button btnOk = new Button { Text = "OK", Dock = DockStyle.Bottom };
            f.Controls.Add(btnOk);

            btnOk.Click += (s, ev) =>
            {
                emprunt.DateRetour = dtp.Value;
                _empruntService.UpdateEmprunt(emprunt);
                f.Close();
                LoadEmprunts();
            };

            f.ShowDialog();
        }

        private void SupprimerEmprunt(int empruntId)
        {
            if (MessageBox.Show("Voulez-vous vraiment supprimer cet emprunt ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _empruntService.DeleteEmprunt(empruntId);
                LoadEmprunts();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu();
            menu.ShowDialog();
            this.Close();
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

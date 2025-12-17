using BibliothequeWinForm.Models;
using BibliothequeWinForm.Services;
using System;
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
        }

        private void FormGestionEmprunts_Load(object sender, EventArgs e)
        {
            // Configuration du DataGridView
            dgvEmprunts.AutoGenerateColumns = false;
            dgvEmprunts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmprunts.MultiSelect = false;

            dgvEmprunts.Columns.Clear();

            // Colonne Modifier
            DataGridViewButtonColumn btnModifierCol = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Modifier",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvEmprunts.Columns.Add(btnModifierCol);

            // Colonne Supprimer
            DataGridViewButtonColumn btnSupprimerCol = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvEmprunts.Columns.Add(btnSupprimerCol);

            // Colonne cachée Id
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Colonne Titre du livre
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Livre",
                DataPropertyName = "LivreTitre",
                ReadOnly = true,
                Width = 150
            });

            // Colonne Nom du client
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Client",
                DataPropertyName = "ClientNom",
                ReadOnly = true,
                Width = 150
            });

            // Colonne Date d'emprunt
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date Emprunt",
                DataPropertyName = "DateEmprunt",
                ReadOnly = true,
                Width = 120
            });

            // Colonne Date de retour
            dgvEmprunts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date Retour",
                DataPropertyName = "DateRetour",
                ReadOnly = true,
                Width = 120
            });

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
                    LivreTitre = e.Livre != null ? e.Livre.Titre : "",
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

            if (e.ColumnIndex == 0) // Modifier
            {
                ModifierEmprunt(empruntId);
            }
            else if (e.ColumnIndex == 1) // Supprimer
            {
                SupprimerEmprunt(empruntId);
            }
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
    }
}

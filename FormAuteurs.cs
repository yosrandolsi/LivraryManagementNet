using System;
using System.Linq;
using System.Windows.Forms;
using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;

namespace BibliothequeWinForm.Forms
{
    public partial class FormAuteurs : Form
    {
        private BibliothequeContext _context;

        public FormAuteurs()
        {
            InitializeComponent();
            _context = new BibliothequeContext();
        }

        private void FormAuteurs_Load(object sender, EventArgs e)
        {
            LoadAuteurs();
        }

        private void LoadAuteurs()
        {
            dataGridViewAuteurs.DataSource = _context.Auteurs
                .Select(a => new { a.Id, a.Nom, a.Prenom })
                .ToList();
        }

        private void btnAjouterAuteur_Click(object sender, EventArgs e)
        {
            FormAjouterAuteur formAjouter = new FormAjouterAuteur();
            formAjouter.ShowDialog();
            LoadAuteurs();
        }
    }
}

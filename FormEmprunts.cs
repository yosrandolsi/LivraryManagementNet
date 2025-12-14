using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;

namespace BibliothequeWinForm.Forms
{
    public partial class FormEmprunts : Form
    {
        private BibliothequeContext _context;

        public FormEmprunts()
        {
            InitializeComponent();
            _context = new BibliothequeContext();
        }

        private void FormEmprunts_Load(object sender, EventArgs e)
        {
            LoadEmprunts();
        }

        private void LoadEmprunts()
        {
            dataGridViewEmprunts.DataSource = _context.Emprunts
                .Include(e => e.Livre)
                .Select(e => new
                {
                    e.Id,
                    Client = e.NomClient + " " + e.PrenomClient,
                    Livre = e.Livre.Titre,
                    e.DateEmprunt,
                    e.DateRetour
                })
                .ToList();
        }

        private void btnNouvelEmprunt_Click(object sender, EventArgs e)
        {
            FormAjouterEmprunt formAjouter = new FormAjouterEmprunt();
            formAjouter.ShowDialog();
            LoadEmprunts();
        }

        private void btnRetourLivre_Click(object sender, EventArgs e)
        {
            // Logique pour retourner un livre
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;
using BibliothequeWinForm.Data;

namespace BibliothequeWinForm.Forms
{
    public partial class FormCategories : Form
    {
        private BibliothequeContext _context;

        public FormCategories()
        {
            InitializeComponent();
            _context = new BibliothequeContext();
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            dataGridViewCategories.DataSource = _context.Categories
                .Select(c => new { c.Id, c.Nom })
                .ToList();
        }

        private void btnAjouterCategorie_Click(object sender, EventArgs e)
        {
            FormAjouterCategorie formAjouter = new FormAjouterCategorie();
            formAjouter.ShowDialog();
            LoadCategories();
        }
    }
}

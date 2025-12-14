using System;
using System.Windows.Forms;

namespace BibliothequeWinForm.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnLivres_Click(object sender, EventArgs e)
        {
            FormLivres formLivres = new FormLivres();
            formLivres.ShowDialog();
        }

        private void btnAuteurs_Click(object sender, EventArgs e)
        {
            FormAuteurs formAuteurs = new FormAuteurs();
            formAuteurs.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FormCategories formCategories = new FormCategories();
            formCategories.ShowDialog();
        }

        private void btnEmprunts_Click(object sender, EventArgs e)
        {
            FormEmprunts formEmprunts = new FormEmprunts();
            formEmprunts.ShowDialog();
        }
    }
}

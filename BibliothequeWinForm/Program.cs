using BibliothequeWinForm.Data;
using BibliothequeWinForm.UI;
using System;
using System.Windows.Forms;

namespace BibliothequeWinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (var context = new BibliothequeContext())
                {
                    bool created = context.Database.CreateIfNotExists();
                    if (created)
                        MessageBox.Show("La base de données a été créée avec succès !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création de la base : " + ex.Message);
            }

            // Démarrage avec le menu principal
            Application.Run(new FormConnexion());
        }
    }
}

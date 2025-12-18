using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    partial class FormDetailLivre
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitre;
        private Label lblAuteur;
        private Label lblCategorie;
        private Label lblExemplaires;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitre = new Label();
            this.lblAuteur = new Label();
            this.lblCategorie = new Label();
            this.lblExemplaires = new Label();
            this.btnClose = new Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(20, 20);
            this.lblTitre.Size = new System.Drawing.Size(400, 25);
            // 
            // lblAuteur
            // 
            this.lblAuteur.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAuteur.Location = new System.Drawing.Point(20, 60);
            this.lblAuteur.Size = new System.Drawing.Size(400, 25);
            // 
            // lblCategorie
            // 
            this.lblCategorie.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCategorie.Location = new System.Drawing.Point(20, 100);
            this.lblCategorie.Size = new System.Drawing.Size(400, 25);
            // 
            // lblExemplaires
            // 
            this.lblExemplaires.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExemplaires.Location = new System.Drawing.Point(20, 140);
            this.lblExemplaires.Size = new System.Drawing.Size(400, 25);
            // 
            // btnClose
            // 
            this.btnClose.Text = "Fermer";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(150, 200);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormDetailLivre
            // 
            this.ClientSize = new System.Drawing.Size(450, 270);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.lblExemplaires);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Détails du Livre";
            this.ResumeLayout(false);
        }
    }
}

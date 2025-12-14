namespace BibliothequeWinForm.UI
{
    partial class FormEditLivre
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.TextBox txtTitre;

        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.ComboBox cmbAuteurs;

        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.ComboBox cmbCategories;

        private System.Windows.Forms.Label lblExemplaires;
        private System.Windows.Forms.NumericUpDown numExemplaires;

        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.cmbAuteurs = new System.Windows.Forms.ComboBox();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lblExemplaires = new System.Windows.Forms.Label();
            this.numExemplaires = new System.Windows.Forms.NumericUpDown();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numExemplaires)).BeginInit();
            this.SuspendLayout();

            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(30, 25);
            this.lblTitre.Text = "Titre";

            // txtTitre
            this.txtTitre.Location = new System.Drawing.Point(150, 22);
            this.txtTitre.Size = new System.Drawing.Size(200, 23);

            // lblAuteur
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Location = new System.Drawing.Point(30, 65);
            this.lblAuteur.Text = "Auteur";

            // cmbAuteurs
            this.cmbAuteurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuteurs.Location = new System.Drawing.Point(150, 62);
            this.cmbAuteurs.Size = new System.Drawing.Size(200, 23);

            // lblCategorie
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(30, 105);
            this.lblCategorie.Text = "Catégorie";

            // cmbCategories
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.Location = new System.Drawing.Point(150, 102);
            this.cmbCategories.Size = new System.Drawing.Size(200, 23);

            // lblExemplaires
            this.lblExemplaires.AutoSize = true;
            this.lblExemplaires.Location = new System.Drawing.Point(30, 145);
            this.lblExemplaires.Text = "Exemplaires";

            // numExemplaires
            this.numExemplaires.Location = new System.Drawing.Point(150, 142);
            this.numExemplaires.Maximum = 1000;
            this.numExemplaires.Size = new System.Drawing.Size(200, 23);

            // btnEnregistrer
            this.btnEnregistrer.Location = new System.Drawing.Point(150, 190);
            this.btnEnregistrer.Size = new System.Drawing.Size(90, 30);
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);

            // btnAnnuler
            this.btnAnnuler.Location = new System.Drawing.Point(260, 190);
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += (s, e) => this.Close();

            // FormEditLivre
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.cmbAuteurs);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblExemplaires);
            this.Controls.Add(this.numExemplaires);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Text = "Modifier Livre";

            ((System.ComponentModel.ISupportInitialize)(this.numExemplaires)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

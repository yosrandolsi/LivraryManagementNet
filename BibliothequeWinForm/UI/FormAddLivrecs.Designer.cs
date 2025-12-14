namespace BibliothequeWinForm.UI
{
    partial class FormAddLivre
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            ((System.ComponentModel.ISupportInitialize)(this.numExemplaires)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(12, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(30, 15);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Titre";
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(120, 12);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(200, 23);
            this.txtTitre.TabIndex = 1;
            // 
            // lblAuteur
            // 
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Location = new System.Drawing.Point(12, 50);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(42, 15);
            this.lblAuteur.TabIndex = 2;
            this.lblAuteur.Text = "Auteur";
            // 
            // cmbAuteurs
            // 
            this.cmbAuteurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuteurs.FormattingEnabled = true;
            this.cmbAuteurs.Location = new System.Drawing.Point(120, 47);
            this.cmbAuteurs.Name = "cmbAuteurs";
            this.cmbAuteurs.Size = new System.Drawing.Size(200, 23);
            this.cmbAuteurs.TabIndex = 3;
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(12, 85);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(58, 15);
            this.lblCategorie.TabIndex = 4;
            this.lblCategorie.Text = "Catégorie";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(120, 82);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(200, 23);
            this.cmbCategories.TabIndex = 5;
            // 
            // lblExemplaires
            // 
            this.lblExemplaires.AutoSize = true;
            this.lblExemplaires.Location = new System.Drawing.Point(12, 120);
            this.lblExemplaires.Name = "lblExemplaires";
            this.lblExemplaires.Size = new System.Drawing.Size(100, 15);
            this.lblExemplaires.TabIndex = 6;
            this.lblExemplaires.Text = "Exemplaires dispo";
            // 
            // numExemplaires
            // 
            this.numExemplaires.Location = new System.Drawing.Point(120, 118);
            this.numExemplaires.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numExemplaires.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numExemplaires.Name = "numExemplaires";
            this.numExemplaires.Size = new System.Drawing.Size(200, 23);
            this.numExemplaires.TabIndex = 7;
            this.numExemplaires.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(120, 160);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(100, 30);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // FormAddLivre
            // 
            this.ClientSize = new System.Drawing.Size(350, 210);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.numExemplaires);
            this.Controls.Add(this.lblExemplaires);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.cmbAuteurs);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.lblTitre);
            this.Name = "FormAddLivre";
            this.Text = "Ajouter un Livre";
            ((System.ComponentModel.ISupportInitialize)(this.numExemplaires)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

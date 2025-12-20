namespace BibliothequeWinForm.UI
{
    partial class FormDetailLivre
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Forms

        private void InitializeComponent()
        {
            this.lblTitreLabel = new System.Windows.Forms.Label();
            this.lblAuteurLabel = new System.Windows.Forms.Label();
            this.lblCategorieLabel = new System.Windows.Forms.Label();
            this.lblExemplairesLabel = new System.Windows.Forms.Label();

            this.lblTitre = new System.Windows.Forms.Label();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.lblExemplaires = new System.Windows.Forms.Label();

            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnFermer = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ========================
            // FormDetailLivre
            // ========================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Détails du livre";

            // ========================
            // Labels fixes
            // ========================
            this.lblTitreLabel.Text = "Titre :";
            this.lblTitreLabel.Location = new System.Drawing.Point(30, 30);
            this.lblTitreLabel.AutoSize = true;
            this.lblTitreLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblAuteurLabel.Text = "Auteur :";
            this.lblAuteurLabel.Location = new System.Drawing.Point(30, 70);
            this.lblAuteurLabel.AutoSize = true;
            this.lblAuteurLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblCategorieLabel.Text = "Catégorie :";
            this.lblCategorieLabel.Location = new System.Drawing.Point(30, 110);
            this.lblCategorieLabel.AutoSize = true;
            this.lblCategorieLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblExemplairesLabel.Text = "Exemplaires disponibles :";
            this.lblExemplairesLabel.Location = new System.Drawing.Point(30, 150);
            this.lblExemplairesLabel.AutoSize = true;
            this.lblExemplairesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // ========================
            // Labels dynamiques
            // ========================
            this.lblTitre.Location = new System.Drawing.Point(220, 30);
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblAuteur.Location = new System.Drawing.Point(220, 70);
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblCategorie.Location = new System.Drawing.Point(220, 110);
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblExemplaires.Location = new System.Drawing.Point(260, 150);
            this.lblExemplaires.AutoSize = true;
            this.lblExemplaires.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ========================
            // Description
            // ========================
            this.txtDescription.Location = new System.Drawing.Point(34, 190);
            this.txtDescription.Multiline = true;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(520, 150);
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ========================
            // Bouton Fermer
            // ========================
            this.btnFermer.Text = "Fermer";
            this.btnFermer.Location = new System.Drawing.Point(460, 350);
            this.btnFermer.Size = new System.Drawing.Size(95, 35);
            this.btnFermer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);

            // ========================
            // Controls
            // ========================
            this.Controls.Add(this.lblTitreLabel);
            this.Controls.Add(this.lblAuteurLabel);
            this.Controls.Add(this.lblCategorieLabel);
            this.Controls.Add(this.lblExemplairesLabel);

            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.lblExemplaires);

            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnFermer);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitreLabel;
        private System.Windows.Forms.Label lblAuteurLabel;
        private System.Windows.Forms.Label lblCategorieLabel;
        private System.Windows.Forms.Label lblExemplairesLabel;

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.Label lblExemplaires;

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnFermer;
    }
}

namespace BibliothequeWinForm.UI
{
    partial class FormEditCategorie
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
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
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblNom
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(30, 25);
            this.lblNom.Text = "Nom de la catégorie";

            // txtNom
            this.txtNom.Location = new System.Drawing.Point(170, 22);
            this.txtNom.Size = new System.Drawing.Size(200, 23);

            // btnEnregistrer
            this.btnEnregistrer.Location = new System.Drawing.Point(170, 70);
            this.btnEnregistrer.Size = new System.Drawing.Size(90, 30);
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);

            // btnAnnuler
            this.btnAnnuler.Location = new System.Drawing.Point(280, 70);
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += (s, e) => this.Close();

            // FormEditCategorie
            this.ClientSize = new System.Drawing.Size(420, 130);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Text = "Modifier Catégorie";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

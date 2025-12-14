namespace BibliothequeWinForm.UI
{
    partial class FormEditClient
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblCIN;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtCIN;
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
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblCIN = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtCIN = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblNom
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(30, 25);
            this.lblNom.Text = "Nom";

            // txtNom
            this.txtNom.Location = new System.Drawing.Point(120, 22);
            this.txtNom.Size = new System.Drawing.Size(200, 23);

            // lblPrenom
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(30, 65);
            this.lblPrenom.Text = "Prénom";

            // txtPrenom
            this.txtPrenom.Location = new System.Drawing.Point(120, 62);
            this.txtPrenom.Size = new System.Drawing.Size(200, 23);

            // lblCIN
            this.lblCIN.AutoSize = true;
            this.lblCIN.Location = new System.Drawing.Point(30, 105);
            this.lblCIN.Text = "CIN";

            // txtCIN
            this.txtCIN.Location = new System.Drawing.Point(120, 102);
            this.txtCIN.Size = new System.Drawing.Size(200, 23);

            // btnEnregistrer
            this.btnEnregistrer.Location = new System.Drawing.Point(120, 140);
            this.btnEnregistrer.Size = new System.Drawing.Size(90, 30);
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);

            // btnAnnuler
            this.btnAnnuler.Location = new System.Drawing.Point(230, 140);
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += (s, e) => this.Close();

            // FormEditClient
            this.ClientSize = new System.Drawing.Size(380, 200);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblCIN);
            this.Controls.Add(this.txtCIN);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Text = "Modifier Client";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

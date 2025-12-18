namespace BibliothequeWinForm.UI
{
    partial class FormAddClient
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
            this.lblNom.Location = new System.Drawing.Point(30, 30);
            this.lblNom.Text = "Nom";

            // txtNom
            this.txtNom.Location = new System.Drawing.Point(120, 27);
            this.txtNom.Size = new System.Drawing.Size(220, 22);

            // lblPrenom
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(30, 70);
            this.lblPrenom.Text = "Prénom";

            // txtPrenom
            this.txtPrenom.Location = new System.Drawing.Point(120, 67);
            this.txtPrenom.Size = new System.Drawing.Size(220, 22);

            // lblCIN
            this.lblCIN.AutoSize = true;
            this.lblCIN.Location = new System.Drawing.Point(30, 110);
            this.lblCIN.Text = "CIN";

            // txtCIN
            this.txtCIN.Location = new System.Drawing.Point(120, 107);
            this.txtCIN.Size = new System.Drawing.Size(220, 22);

            // btnEnregistrer
            this.btnEnregistrer.Location = new System.Drawing.Point(120, 160);
            this.btnEnregistrer.Size = new System.Drawing.Size(100, 35);
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(144, 238, 144);
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);

            // btnAnnuler
            this.btnAnnuler.Location = new System.Drawing.Point(240, 160);
            this.btnAnnuler.Size = new System.Drawing.Size(100, 35);
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(255, 182, 193);
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);

            // FormAddClient
            this.ClientSize = new System.Drawing.Size(380, 230);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblCIN);
            this.Controls.Add(this.txtCIN);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Ajouter Client";
            this.Load += new System.EventHandler(this.FormAddClient_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

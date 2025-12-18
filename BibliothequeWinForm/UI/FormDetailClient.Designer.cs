namespace BibliothequeWinForm.UI
{
    partial class FormDetailClient
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblCIN;
        private System.Windows.Forms.ListBox lstEmprunts;
        private System.Windows.Forms.Button btnClose;

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
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblCIN = new System.Windows.Forms.Label();
            this.lstEmprunts = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();

            // 
            // FormDetailClient
            // 
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(255, 245, 235, 230);
            this.Text = "Détails du client";

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Détails du client";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;

            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(20, 60);
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblId.AutoSize = true;

            // 
            // lblNom
            // 
            this.lblNom.Location = new System.Drawing.Point(20, 90);
            this.lblNom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNom.AutoSize = true;

            // 
            // lblPrenom
            // 
            this.lblPrenom.Location = new System.Drawing.Point(20, 120);
            this.lblPrenom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrenom.AutoSize = true;

            // 
            // lblCIN
            // 
            this.lblCIN.Location = new System.Drawing.Point(20, 150);
            this.lblCIN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCIN.AutoSize = true;

            // 
            // lstEmprunts
            // 
            this.lstEmprunts.Location = new System.Drawing.Point(20, 190);
            this.lstEmprunts.Size = new System.Drawing.Size(400, 180);
            this.lstEmprunts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstEmprunts.BackColor = System.Drawing.Color.FromArgb(248, 244, 242);
            this.lstEmprunts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // btnClose
            // 
            this.btnClose.Text = "Fermer";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.Location = new System.Drawing.Point(320, 390);

            // Ajouter les controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblCIN);
            this.Controls.Add(this.lstEmprunts);
            this.Controls.Add(this.btnClose);
        }
    }
}

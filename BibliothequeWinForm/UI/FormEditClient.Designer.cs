using System.Drawing;

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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(30, 30);
            this.lblNom.Text = "Nom";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(120, 27);
            this.txtNom.Size = new System.Drawing.Size(250, 22);
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(30, 70);
            this.lblPrenom.Text = "Prénom";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(120, 67);
            this.txtPrenom.Size = new System.Drawing.Size(250, 22);
            // 
            // lblCIN
            // 
            this.lblCIN.AutoSize = true;
            this.lblCIN.Location = new System.Drawing.Point(30, 110);
            this.lblCIN.Text = "CIN";
            // 
            // txtCIN
            // 
            this.txtCIN.Location = new System.Drawing.Point(120, 107);
            this.txtCIN.Size = new System.Drawing.Size(250, 22);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 160);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Enregistrer";
            this.btnSave.BackColor = Color.FromArgb(144, 238, 144); // vert pastel
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 160);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Annuler";
            this.btnCancel.BackColor = Color.FromArgb(255, 182, 193); // rose pastel
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FormEditClient
            // 
            this.ClientSize = new System.Drawing.Size(420, 220);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblCIN);
            this.Controls.Add(this.txtCIN);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier Client";
            this.Load += new System.EventHandler(this.FormEditClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

using System.Drawing;

namespace BibliothequeWinForm.UI
{
    partial class FormAddClient
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtCIN;
        private System.Windows.Forms.Label lblCIN;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.txtCIN = new System.Windows.Forms.TextBox();
            this.lblCIN = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(255, 239, 228, 225);
            this.panelContainer.Controls.Add(this.lblDescription);
            this.panelContainer.Controls.Add(this.btnAnnuler);
            this.panelContainer.Controls.Add(this.btnEnregistrer);
            this.panelContainer.Controls.Add(this.txtCIN);
            this.panelContainer.Controls.Add(this.lblCIN);
            this.panelContainer.Controls.Add(this.txtPrenom);
            this.panelContainer.Controls.Add(this.lblPrenom);
            this.panelContainer.Controls.Add(this.txtNom);
            this.panelContainer.Controls.Add(this.lblNom);
            this.panelContainer.Controls.Add(this.panelTop);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Size = new System.Drawing.Size(500, 400);
            this.panelContainer.TabIndex = 0;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelContainer_Paint);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblDescription.Location = new System.Drawing.Point(60, 140);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(380, 23);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Entrez les informations du nouveau client";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(255, 255, 182, 193);
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(260, 320);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(120, 40);
            this.btnAnnuler.TabIndex = 9;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(255, 144, 238, 144);
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(120, 320);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 40);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // txtCIN
            // 
            this.txtCIN.BackColor = System.Drawing.Color.White;
            this.txtCIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCIN.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCIN.Location = new System.Drawing.Point(160, 280);
            this.txtCIN.Name = "txtCIN";
            this.txtCIN.Size = new System.Drawing.Size(280, 27);
            this.txtCIN.TabIndex = 7;
            // 
            // lblCIN
            // 
            this.lblCIN.AutoSize = true;
            this.lblCIN.BackColor = System.Drawing.Color.Transparent;
            this.lblCIN.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCIN.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblCIN.Location = new System.Drawing.Point(60, 280);
            this.lblCIN.Name = "lblCIN";
            this.lblCIN.Size = new System.Drawing.Size(52, 28);
            this.lblCIN.TabIndex = 6;
            this.lblCIN.Text = "CIN :";
            // 
            // txtPrenom
            // 
            this.txtPrenom.BackColor = System.Drawing.Color.White;
            this.txtPrenom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrenom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrenom.Location = new System.Drawing.Point(160, 230);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(280, 27);
            this.txtPrenom.TabIndex = 5;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.BackColor = System.Drawing.Color.Transparent;
            this.lblPrenom.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblPrenom.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPrenom.Location = new System.Drawing.Point(60, 230);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(88, 28);
            this.lblPrenom.TabIndex = 4;
            this.lblPrenom.Text = "Prénom :";
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.txtNom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNom.Location = new System.Drawing.Point(160, 180);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(280, 27);
            this.txtNom.TabIndex = 3;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.BackColor = System.Drawing.Color.Transparent;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblNom.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblNom.Location = new System.Drawing.Point(60, 180);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(66, 28);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom :";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(255, 144, 238, 144); // VERT PASTEL comme FormAddCategorie
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(460, 80);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 Ajouter Client";
            this.lblTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.LblTitle_Paint);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(410, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(370, 20);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "─";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // FormAddClient
            // 
            this.BackColor = System.Drawing.Color.FromArgb(255, 245, 235, 230);
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddClient_FormClosing);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
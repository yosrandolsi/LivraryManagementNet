namespace BibliothequeWinForm.UI
{
    partial class FormEditLivre
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.Label lblExemplaires;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.ComboBox cmbAuteurs;
        private System.Windows.Forms.ComboBox cmbCategories;
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.numExemplaires = new System.Windows.Forms.NumericUpDown();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.cmbAuteurs = new System.Windows.Forms.ComboBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.lblExemplaires = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();

            this.panelContainer.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExemplaires)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();

            // panelContainer
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(255, 239, 228, 225);
            this.panelContainer.Controls.Add(this.panelForm);
            this.panelContainer.Controls.Add(this.panelTitle);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(600, 400);
            this.panelContainer.TabIndex = 0;

            // panelForm
            this.panelForm.BackColor = System.Drawing.Color.Transparent;
            this.panelForm.Controls.Add(this.btnAnnuler);
            this.panelForm.Controls.Add(this.btnEnregistrer);
            this.panelForm.Controls.Add(this.numExemplaires);
            this.panelForm.Controls.Add(this.cmbCategories);
            this.panelForm.Controls.Add(this.cmbAuteurs);
            this.panelForm.Controls.Add(this.txtTitre);
            this.panelForm.Controls.Add(this.lblExemplaires);
            this.panelForm.Controls.Add(this.lblCategorie);
            this.panelForm.Controls.Add(this.lblAuteur);
            this.panelForm.Controls.Add(this.lblTitre);
            this.panelForm.Location = new System.Drawing.Point(20, 100);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(560, 280);
            this.panelForm.TabIndex = 1;

            // btnAnnuler
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(300, 200);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(150, 40);
            this.btnAnnuler.TabIndex = 9;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);

            // btnEnregistrer
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(120, 200);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(150, 40);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);

            // numExemplaires
            this.numExemplaires.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numExemplaires.Location = new System.Drawing.Point(200, 145);
            this.numExemplaires.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numExemplaires.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExemplaires.Name = "numExemplaires";
            this.numExemplaires.Size = new System.Drawing.Size(150, 27);
            this.numExemplaires.TabIndex = 7;
            this.numExemplaires.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // cmbCategories
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(200, 100);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(300, 28);
            this.cmbCategories.TabIndex = 5;

            // cmbAuteurs
            this.cmbAuteurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuteurs.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbAuteurs.FormattingEnabled = true;
            this.cmbAuteurs.Location = new System.Drawing.Point(200, 60);
            this.cmbAuteurs.Name = "cmbAuteurs";
            this.cmbAuteurs.Size = new System.Drawing.Size(300, 28);
            this.cmbAuteurs.TabIndex = 3;

            // txtTitre
            this.txtTitre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTitre.Location = new System.Drawing.Point(200, 20);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(300, 27);
            this.txtTitre.TabIndex = 1;

            // lblExemplaires
            this.lblExemplaires.AutoSize = true;
            this.lblExemplaires.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblExemplaires.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblExemplaires.Location = new System.Drawing.Point(40, 150);
            this.lblExemplaires.Name = "lblExemplaires";
            this.lblExemplaires.Size = new System.Drawing.Size(140, 20);
            this.lblExemplaires.TabIndex = 6;
            this.lblExemplaires.Text = "Exemplaires disponibles :";

            // lblCategorie
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategorie.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblCategorie.Location = new System.Drawing.Point(40, 105);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(78, 20);
            this.lblCategorie.TabIndex = 4;
            this.lblCategorie.Text = "Catégorie :";

            // lblAuteur
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblAuteur.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblAuteur.Location = new System.Drawing.Point(40, 65);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(57, 20);
            this.lblAuteur.TabIndex = 2;
            this.lblAuteur.Text = "Auteur :";

            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblTitre.Location = new System.Drawing.Point(40, 25);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(46, 20);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Titre :";

            // panelTitle
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(200, 255, 182, 128); // pastel orange
            this.panelTitle.Controls.Add(this.lblSubtitle);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Location = new System.Drawing.Point(20, 20);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(560, 60);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.lblSubtitle.Location = new System.Drawing.Point(250, 35);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(180, 19);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Modification d'un livre existant";

            // btnMinimize
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(490, 15);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "─";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // btnClose
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(530, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(213, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ MODIFIER LIVRE";

            // FormEditLivre
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 245, 235, 230);
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEditLivre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier Livre";
            this.Load += new System.EventHandler(this.FormEditLivre_Load);

            this.panelContainer.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExemplaires)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
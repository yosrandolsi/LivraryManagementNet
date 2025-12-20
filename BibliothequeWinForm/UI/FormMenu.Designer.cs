using System.Drawing;

namespace BibliothequeWinForm
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;

        // Panels principaux
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelImage;

        // Titre et boutons de contrôle
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;

        // Boutons de menu
        private System.Windows.Forms.Button btnAuteurs;
        private System.Windows.Forms.Button btnLivres;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnEmprunts;

        // Image
        private System.Windows.Forms.PictureBox pictureBoxLibrary;

        // Éléments décoratifs
        private System.Windows.Forms.Label lblLibraryName;
        private System.Windows.Forms.Panel panelDecoration1;
        private System.Windows.Forms.Panel panelDecoration2;
        private System.Windows.Forms.Label lblVersion;

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
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBoxLibrary = new System.Windows.Forms.PictureBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnEmprunts = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnLivres = new System.Windows.Forms.Button();
            this.btnAuteurs = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLibraryName = new System.Windows.Forms.Label();
            this.panelDecoration1 = new System.Windows.Forms.Panel();
            this.panelDecoration2 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panelContainer.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLibrary)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(255, 239, 228, 225);
            this.panelContainer.Controls.Add(this.panelImage);
            this.panelContainer.Controls.Add(this.panelButtons);
            this.panelContainer.Controls.Add(this.panelTitle);
            this.panelContainer.Controls.Add(this.lblLibraryName);
            this.panelContainer.Controls.Add(this.panelDecoration1);
            this.panelContainer.Controls.Add(this.panelDecoration2);
            this.panelContainer.Controls.Add(this.lblVersion);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1000, 650);
            this.panelContainer.TabIndex = 0;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // panelImage
            // 
            this.panelImage.BackColor = System.Drawing.Color.Transparent;
            this.panelImage.Controls.Add(this.pictureBoxLibrary);
            this.panelImage.Location = new System.Drawing.Point(350, 120);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(620, 420);
            this.panelImage.TabIndex = 5;
            this.panelImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panelImage_Paint);
            // 
            // pictureBoxLibrary
            // 
            this.pictureBoxLibrary.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLibrary.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxLibrary.Name = "pictureBoxLibrary";
            this.pictureBoxLibrary.Size = new System.Drawing.Size(600, 400);
            this.pictureBoxLibrary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLibrary.TabIndex = 0;
            this.pictureBoxLibrary.TabStop = false;
            this.pictureBoxLibrary.Click += new System.EventHandler(this.PictureBoxLibrary_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.btnEmprunts);
            this.panelButtons.Controls.Add(this.btnClients);
            this.panelButtons.Controls.Add(this.btnCategories);
            this.panelButtons.Controls.Add(this.btnLivres);
            this.panelButtons.Controls.Add(this.btnAuteurs);
            this.panelButtons.Location = new System.Drawing.Point(20, 120);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(300, 420);
            this.panelButtons.TabIndex = 4;
            // 
            // btnEmprunts
            // 
            this.btnEmprunts.BackColor = Color.FromArgb(200, 178, 214, 255); // pastel bleu
            this.btnEmprunts.FlatAppearance.BorderSize = 0;
            this.btnEmprunts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmprunts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEmprunts.ForeColor = Color.White;
            this.btnEmprunts.Location = new System.Drawing.Point(0, 340);
            this.btnEmprunts.Size = new System.Drawing.Size(300, 70);
            this.btnEmprunts.Text = "   GESTION DES EMPRUNTS";
            this.btnEmprunts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmprunts.UseVisualStyleBackColor = false;
            this.btnEmprunts.Click += new System.EventHandler(this.BtnEmprunts_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = Color.FromArgb(200, 173, 216, 230); // pastel bleu clair
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClients.ForeColor = Color.White;
            this.btnClients.Location = new System.Drawing.Point(0, 255);
            this.btnClients.Size = new System.Drawing.Size(300, 70);
            this.btnClients.Text = "   GESTION DES CLIENTS";
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = Color.FromArgb(200, 144, 238, 144); // pastel vert
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCategories.ForeColor = Color.White;
            this.btnCategories.Location = new System.Drawing.Point(0, 170);
            this.btnCategories.Size = new System.Drawing.Size(300, 70);
            this.btnCategories.Text = "   GESTION DES CATÉGORIES";
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.BtnCategories_Click);
            // 
            // btnLivres
            // 
            this.btnLivres.BackColor = Color.FromArgb(200, 255, 182, 128); // pastel orange
            this.btnLivres.FlatAppearance.BorderSize = 0;
            this.btnLivres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLivres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLivres.ForeColor = Color.White;
            this.btnLivres.Location = new System.Drawing.Point(0, 85);
            this.btnLivres.Size = new System.Drawing.Size(300, 70);
            this.btnLivres.Text = "   GESTION DES LIVRES";
            this.btnLivres.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLivres.UseVisualStyleBackColor = false;
            this.btnLivres.Click += new System.EventHandler(this.BtnLivres_Click);
            // 
            // btnAuteurs
            // 
            this.btnAuteurs.BackColor = Color.FromArgb(200, 255, 182, 193); // pastel rose
            this.btnAuteurs.FlatAppearance.BorderSize = 0;
            this.btnAuteurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuteurs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAuteurs.ForeColor = Color.White;
            this.btnAuteurs.Location = new System.Drawing.Point(0, 0);
            this.btnAuteurs.Size = new System.Drawing.Size(300, 70);
            this.btnAuteurs.Text = "   GESTION DES AUTEURS";
            this.btnAuteurs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAuteurs.UseVisualStyleBackColor = false;
            this.btnAuteurs.Click += new System.EventHandler(this.BtnAuteurs_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = Color.FromArgb(200, 180, 167, 210); // pastel violet
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.lblSubtitle);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Location = new System.Drawing.Point(20, 20);
            this.panelTitle.Size = new System.Drawing.Size(950, 80);
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(870, 20);
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.Text = "─";
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new System.Drawing.Point(910, 20);
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, FontStyle.Italic);
            this.lblSubtitle.ForeColor = Color.FromArgb(200, 200, 220);
            this.lblSubtitle.Location = new System.Drawing.Point(350, 50);
            this.lblSubtitle.Text = "Système de Gestion Bibliothèque";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "📚 BIBLIOTHÈQUE";
            // 
            // lblLibraryName
            // 
            this.lblLibraryName.AutoSize = true;
            this.lblLibraryName.BackColor = Color.Transparent;
            this.lblLibraryName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblLibraryName.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblLibraryName.Location = new System.Drawing.Point(40, 600);
            this.lblLibraryName.Text = "Bibliothèque Municipale";
            // 
            // panelDecoration1
            // 
            this.panelDecoration1.BackColor = Color.FromArgb(255, 255, 182, 193); // pastel rose
            this.panelDecoration1.Location = new System.Drawing.Point(20, 560);
            this.panelDecoration1.Size = new System.Drawing.Size(50, 5);
            // 
            // panelDecoration2
            // 
            this.panelDecoration2.BackColor = Color.FromArgb(255, 135, 206, 235); // pastel bleu clair
            this.panelDecoration2.Location = new System.Drawing.Point(80, 560);
            this.panelDecoration2.Size = new System.Drawing.Size(50, 5);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblVersion.ForeColor = Color.FromArgb(150, 150, 150);
            this.lblVersion.Location = new System.Drawing.Point(900, 620);
            this.lblVersion.Text = "Version 2.0.1";
            // 
            // FormMenu
            // 
            this.BackColor = Color.FromArgb(255, 245, 235, 230);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = Color.FromArgb(64, 64, 64);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bibliothèque - Menu Principal";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLibrary)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}

namespace BibliothequeWinForm
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnStartLearning;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAuteurs;
        private System.Windows.Forms.Button btnLivres;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.PictureBox pictureBoxLibrary;
        private System.Windows.Forms.Panel panelLearnMore;
        private System.Windows.Forms.Label lblLearnMoreTitle;
        private System.Windows.Forms.Button btnVisitSite;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.Button btnSave;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.panelLearnMore = new System.Windows.Forms.Panel();
            this.btnVisitSite = new System.Windows.Forms.Button();
            this.lblLearnMoreTitle = new System.Windows.Forms.Label();
            this.pictureBoxLibrary = new System.Windows.Forms.PictureBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnLivres = new System.Windows.Forms.Button();
            this.btnAuteurs = new System.Windows.Forms.Button();
            this.btnStartLearning = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelProfile.SuspendLayout();
            this.panelLearnMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLibrary)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelHeader.Controls.Add(this.lblBrand);
            this.panelHeader.Controls.Add(this.lblHome);
            this.panelHeader.Controls.Add(this.lblAbout);
            this.panelHeader.Controls.Add(this.lblContact);
            this.panelHeader.Controls.Add(this.lblExit);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(20, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(193, 37);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Online library";
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Location = new System.Drawing.Point(600, 20);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(66, 25);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "HOME";
            this.lblHome.Click += new System.EventHandler(this.LblHome_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAbout.ForeColor = System.Drawing.Color.White;
            this.lblAbout.Location = new System.Drawing.Point(680, 20);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(72, 25);
            this.lblAbout.TabIndex = 2;
            this.lblAbout.Text = "ABOUT";
            this.lblAbout.Click += new System.EventHandler(this.LblAbout_Click);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblContact.ForeColor = System.Drawing.Color.White;
            this.lblContact.Location = new System.Drawing.Point(760, 20);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(94, 25);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "CONTACT";
            this.lblContact.Click += new System.EventHandler(this.LblContact_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(860, 15);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(30, 32);
            this.lblExit.TabIndex = 4;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.LblExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelProfile);
            this.panelMain.Controls.Add(this.panelLearnMore);
            this.panelMain.Controls.Add(this.pictureBoxLibrary);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.btnStartLearning);
            this.panelMain.Controls.Add(this.txtSearch);
            this.panelMain.Controls.Add(this.lblDescription);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(900, 590);
            this.panelMain.TabIndex = 1;
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.White;
            this.panelProfile.Controls.Add(this.btnSave);
            this.panelProfile.Controls.Add(this.lblProfileTitle);
            this.panelProfile.Location = new System.Drawing.Point(600, 400);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(280, 160);
            this.panelProfile.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(240, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblProfileTitle
            // 
            this.lblProfileTitle.AutoSize = true;
            this.lblProfileTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProfileTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblProfileTitle.Location = new System.Drawing.Point(15, 20);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(90, 32);
            this.lblProfileTitle.TabIndex = 0;
            this.lblProfileTitle.Text = "Profile";
            // 
            // panelLearnMore
            // 
            this.panelLearnMore.BackColor = System.Drawing.Color.White;
            this.panelLearnMore.Controls.Add(this.btnVisitSite);
            this.panelLearnMore.Controls.Add(this.lblLearnMoreTitle);
            this.panelLearnMore.Location = new System.Drawing.Point(600, 230);
            this.panelLearnMore.Name = "panelLearnMore";
            this.panelLearnMore.Size = new System.Drawing.Size(280, 150);
            this.panelLearnMore.TabIndex = 7;
            // 
            // btnVisitSite
            // 
            this.btnVisitSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnVisitSite.FlatAppearance.BorderSize = 0;
            this.btnVisitSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitSite.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVisitSite.ForeColor = System.Drawing.Color.White;
            this.btnVisitSite.Location = new System.Drawing.Point(20, 70);
            this.btnVisitSite.Name = "btnVisitSite";
            this.btnVisitSite.Size = new System.Drawing.Size(240, 40);
            this.btnVisitSite.TabIndex = 7;
            this.btnVisitSite.Text = "7-Visit site";
            this.btnVisitSite.UseVisualStyleBackColor = false;
            this.btnVisitSite.Click += new System.EventHandler(this.BtnVisitSite_Click);
            // 
            // lblLearnMoreTitle
            // 
            this.lblLearnMoreTitle.AutoSize = true;
            this.lblLearnMoreTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLearnMoreTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblLearnMoreTitle.Location = new System.Drawing.Point(15, 20);
            this.lblLearnMoreTitle.Name = "lblLearnMoreTitle";
            this.lblLearnMoreTitle.Size = new System.Drawing.Size(144, 32);
            this.lblLearnMoreTitle.TabIndex = 0;
            this.lblLearnMoreTitle.Text = "Learn more";
            // 
            // pictureBoxLibrary
            // 
            this.pictureBoxLibrary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pictureBoxLibrary.Location = new System.Drawing.Point(600, 30);
            this.pictureBoxLibrary.Name = "pictureBoxLibrary";
            this.pictureBoxLibrary.Size = new System.Drawing.Size(280, 180);
            this.pictureBoxLibrary.TabIndex = 6;
            this.pictureBoxLibrary.TabStop = false;
            this.pictureBoxLibrary.Click += new System.EventHandler(this.pictureBoxLibrary_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panelButtons.Controls.Add(this.btnClients);
            this.panelButtons.Controls.Add(this.btnCategories);
            this.panelButtons.Controls.Add(this.btnLivres);
            this.panelButtons.Controls.Add(this.btnAuteurs);
            this.panelButtons.Location = new System.Drawing.Point(30, 350);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(540, 210);
            this.panelButtons.TabIndex = 4;
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(20, 160);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(500, 40);
            this.btnClients.TabIndex = 7;
            this.btnClients.Text = "Gestion des Clients";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Location = new System.Drawing.Point(360, 60);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(160, 90);
            this.btnCategories.TabIndex = 6;
            this.btnCategories.Text = "Gestion des Catégories";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.BtnCategories_Click);
            // 
            // btnLivres
            // 
            this.btnLivres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnLivres.FlatAppearance.BorderSize = 0;
            this.btnLivres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLivres.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLivres.ForeColor = System.Drawing.Color.White;
            this.btnLivres.Location = new System.Drawing.Point(190, 60);
            this.btnLivres.Name = "btnLivres";
            this.btnLivres.Size = new System.Drawing.Size(160, 90);
            this.btnLivres.TabIndex = 5;
            this.btnLivres.Text = "Gestion des Livres";
            this.btnLivres.UseVisualStyleBackColor = false;
            this.btnLivres.Click += new System.EventHandler(this.BtnLivres_Click);
            // 
            // btnAuteurs
            // 
            this.btnAuteurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnAuteurs.FlatAppearance.BorderSize = 0;
            this.btnAuteurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuteurs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAuteurs.ForeColor = System.Drawing.Color.White;
            this.btnAuteurs.Location = new System.Drawing.Point(20, 60);
            this.btnAuteurs.Name = "btnAuteurs";
            this.btnAuteurs.Size = new System.Drawing.Size(160, 90);
            this.btnAuteurs.TabIndex = 4;
            this.btnAuteurs.Text = "Gestion des Auteurs";
            this.btnAuteurs.UseVisualStyleBackColor = false;
            this.btnAuteurs.Click += new System.EventHandler(this.BtnAuteurs_Click);
            // 

            // FormMenu
            // 
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bibliothèque - Menu Principal";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.panelLearnMore.ResumeLayout(false);
            this.panelLearnMore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLibrary)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

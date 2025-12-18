namespace BibliothequeWinForm.UI
{
    partial class FormEmprunt
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblLivre;
        private System.Windows.Forms.Label lblDateRetour;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.TextBox txtLivre;
        private System.Windows.Forms.DateTimePicker dtRetour;
        private System.Windows.Forms.Button btnEmprunter;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.DataGridView dgvEmprunts;

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
            this.dgvEmprunts = new System.Windows.Forms.DataGridView();
            this.btnRetour = new System.Windows.Forms.Button();
            this.btnEmprunter = new System.Windows.Forms.Button();
            this.dtRetour = new System.Windows.Forms.DateTimePicker();
            this.txtLivre = new System.Windows.Forms.TextBox();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.lblDateRetour = new System.Windows.Forms.Label();
            this.lblLivre = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();

            this.panelContainer.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();

            // panelContainer
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(255, 239, 228, 225);
            this.panelContainer.Controls.Add(this.panelForm);
            this.panelContainer.Controls.Add(this.panelTitle);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(900, 600);
            this.panelContainer.TabIndex = 0;

            // panelForm
            this.panelForm.BackColor = System.Drawing.Color.Transparent;
            this.panelForm.Controls.Add(this.dgvEmprunts);
            this.panelForm.Controls.Add(this.btnRetour);
            this.panelForm.Controls.Add(this.btnEmprunter);
            this.panelForm.Controls.Add(this.dtRetour);
            this.panelForm.Controls.Add(this.txtLivre);
            this.panelForm.Controls.Add(this.cmbClients);
            this.panelForm.Controls.Add(this.lblDateRetour);
            this.panelForm.Controls.Add(this.lblLivre);
            this.panelForm.Controls.Add(this.lblClient);
            this.panelForm.Location = new System.Drawing.Point(20, 100);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(860, 480);
            this.panelForm.TabIndex = 1;

            // dgvEmprunts
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Location = new System.Drawing.Point(30, 150);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowHeadersWidth = 51;
            this.dgvEmprunts.RowTemplate.Height = 35;
            this.dgvEmprunts.Size = new System.Drawing.Size(800, 300);
            this.dgvEmprunts.TabIndex = 8;

            // btnRetour
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(730, 90);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(100, 40);
            this.btnRetour.TabIndex = 7;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);

            // btnEmprunter
            this.btnEmprunter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEmprunter.ForeColor = System.Drawing.Color.White;
            this.btnEmprunter.Location = new System.Drawing.Point(730, 40);
            this.btnEmprunter.Name = "btnEmprunter";
            this.btnEmprunter.Size = new System.Drawing.Size(100, 40);
            this.btnEmprunter.TabIndex = 6;
            this.btnEmprunter.Text = "Emprunter";
            this.btnEmprunter.UseVisualStyleBackColor = false;
            this.btnEmprunter.Click += new System.EventHandler(this.btnEmprunter_Click);

            // dtRetour
            this.dtRetour.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtRetour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRetour.Location = new System.Drawing.Point(130, 90);
            this.dtRetour.Name = "dtRetour";
            this.dtRetour.Size = new System.Drawing.Size(200, 27);
            this.dtRetour.TabIndex = 5;

            // txtLivre
            this.txtLivre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLivre.Location = new System.Drawing.Point(450, 40);
            this.txtLivre.Name = "txtLivre";
            this.txtLivre.ReadOnly = true;
            this.txtLivre.Size = new System.Drawing.Size(250, 27);
            this.txtLivre.TabIndex = 4;

            // cmbClients
            this.cmbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClients.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(130, 40);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(200, 28);
            this.cmbClients.TabIndex = 3;

            // lblDateRetour
            this.lblDateRetour.AutoSize = true;
            this.lblDateRetour.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDateRetour.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblDateRetour.Location = new System.Drawing.Point(30, 95);
            this.lblDateRetour.Name = "lblDateRetour";
            this.lblDateRetour.Size = new System.Drawing.Size(94, 20);
            this.lblDateRetour.TabIndex = 2;
            this.lblDateRetour.Text = "Date retour :";

            // lblLivre
            this.lblLivre.AutoSize = true;
            this.lblLivre.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblLivre.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblLivre.Location = new System.Drawing.Point(350, 45);
            this.lblLivre.Name = "lblLivre";
            this.lblLivre.Size = new System.Drawing.Size(94, 20);
            this.lblLivre.TabIndex = 1;
            this.lblLivre.Text = "Livre emprunté :";

            // lblClient
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(100, 80, 80, 80);
            this.lblClient.Location = new System.Drawing.Point(30, 45);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(54, 20);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Client :";

            // panelTitle
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(200, 180, 167, 210);
            this.panelTitle.Controls.Add(this.lblSubtitle);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Location = new System.Drawing.Point(20, 20);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(860, 60);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.lblSubtitle.Location = new System.Drawing.Point(300, 35);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(220, 19);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Gestion des emprunts et retours";

            // btnMinimize
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(790, 15);
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
            this.btnClose.Location = new System.Drawing.Point(830, 15);
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
            this.lblTitle.Size = new System.Drawing.Size(265, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 GESTION EMPRUNTS";

            // FormEmprunt
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 245, 235, 230);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEmprunt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Emprunts";
            this.Load += new System.EventHandler(this.FormEmprunt_Load);

            this.panelContainer.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
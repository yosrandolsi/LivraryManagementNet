namespace BibliothequeWinForm.UI
{
    partial class FormEmprunt
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.TextBox txtLivre;
        private System.Windows.Forms.Button btnEmprunter;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.DataGridView dgvEmprunts;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblLivre;
        private System.Windows.Forms.Label lblDateRetour;
        private System.Windows.Forms.DateTimePicker dtRetour;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.txtLivre = new System.Windows.Forms.TextBox();
            this.btnEmprunter = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.dgvEmprunts = new System.Windows.Forms.DataGridView();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblLivre = new System.Windows.Forms.Label();
            this.lblDateRetour = new System.Windows.Forms.Label();
            this.dtRetour = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            this.SuspendLayout();

            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 20);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(44, 16);
            this.lblClient.Text = "Client";

            // 
            // cmbClients
            // 
            this.cmbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(80, 17);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(200, 24);

            // 
            // lblDateRetour
            // 
            this.lblDateRetour.AutoSize = true;
            this.lblDateRetour.Location = new System.Drawing.Point(20, 55);
            this.lblDateRetour.Name = "lblDateRetour";
            this.lblDateRetour.Size = new System.Drawing.Size(82, 16);
            this.lblDateRetour.Text = "Date retour";

            // 
            // dtRetour
            // 
            this.dtRetour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRetour.Location = new System.Drawing.Point(120, 52);
            this.dtRetour.Name = "dtRetour";
            this.dtRetour.Size = new System.Drawing.Size(160, 22);

            // 
            // lblLivre
            // 
            this.lblLivre.AutoSize = true;
            this.lblLivre.Location = new System.Drawing.Point(320, 20);
            this.lblLivre.Name = "lblLivre";
            this.lblLivre.Size = new System.Drawing.Size(36, 16);
            this.lblLivre.Text = "Livre";

            // 
            // txtLivre
            // 
            this.txtLivre.Location = new System.Drawing.Point(380, 17);
            this.txtLivre.Name = "txtLivre";
            this.txtLivre.ReadOnly = true;
            this.txtLivre.Size = new System.Drawing.Size(200, 22);

            // 
            // btnEmprunter
            // 
            this.btnEmprunter.Location = new System.Drawing.Point(600, 15);
            this.btnEmprunter.Name = "btnEmprunter";
            this.btnEmprunter.Size = new System.Drawing.Size(100, 30);
            this.btnEmprunter.Text = "Emprunter";
            this.btnEmprunter.UseVisualStyleBackColor = true;
            this.btnEmprunter.Click += new System.EventHandler(this.btnEmprunter_Click);

            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(720, 15);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(100, 30);
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);

            // 
            // dgvEmprunts
            // 
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Location = new System.Drawing.Point(20, 90);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowHeadersWidth = 51;
            this.dgvEmprunts.RowTemplate.Height = 24;
            this.dgvEmprunts.Size = new System.Drawing.Size(800, 360);

            // 
            // FormEmprunt
            // 
            this.ClientSize = new System.Drawing.Size(850, 480);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.cmbClients);
            this.Controls.Add(this.lblDateRetour);
            this.Controls.Add(this.dtRetour);
            this.Controls.Add(this.lblLivre);
            this.Controls.Add(this.txtLivre);
            this.Controls.Add(this.btnEmprunter);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.dgvEmprunts);
            this.Name = "FormEmprunt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Emprunts";
            this.Load += new System.EventHandler(this.FormEmprunt_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

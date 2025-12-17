namespace BibliothequeWinForm.UI
{
    partial class FormLivres
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.DataGridView dgvLivres;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.dgvLivres = new System.Windows.Forms.DataGridView();
            this.panelContainer.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(248, 244, 242);
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Controls.Add(this.dgvLivres);
            this.panelContainer.Controls.Add(this.panelTop);
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnAjouter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTitle.Text = "📚 Gestion des Livres";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Size = new System.Drawing.Size(170, 40);
            this.btnAjouter.Location = new System.Drawing.Point(520, 15);
            this.btnAjouter.Text = "➕ Ajouter Livre";
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(144, 238, 144);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // dgvLivres
            // 
            this.dgvLivres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLivres.Location = new System.Drawing.Point(20, 90);
            this.dgvLivres.Name = "dgvLivres";
            this.dgvLivres.TabIndex = 0;
            // 
            // FormLivres
            // 
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormLivres_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

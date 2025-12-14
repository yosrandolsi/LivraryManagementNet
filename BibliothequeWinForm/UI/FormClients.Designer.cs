namespace BibliothequeWinForm.UI
{
    partial class FormClients
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnAjouter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();

            // dgvClients
            this.dgvClients.Location = new System.Drawing.Point(12, 12);
            this.dgvClients.Size = new System.Drawing.Size(500, 300);
            this.dgvClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellClick);

            // btnAjouter
            this.btnAjouter.Location = new System.Drawing.Point(12, 320);
            this.btnAjouter.Size = new System.Drawing.Size(100, 30);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);

            // FormClients
            this.ClientSize = new System.Drawing.Size(530, 360);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnAjouter);
            this.Text = "Gestion des Clients";

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

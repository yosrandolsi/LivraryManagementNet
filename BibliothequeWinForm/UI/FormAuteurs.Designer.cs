namespace BibliothequeWinForm.UI
{
    partial class FormAuteurs
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAuteurs;
        private System.Windows.Forms.Button btnAjouter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvAuteurs = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAuteurs)).BeginInit();
            this.SuspendLayout();

            // dgvAuteurs
            this.dgvAuteurs.Location = new System.Drawing.Point(12, 12);
            this.dgvAuteurs.Size = new System.Drawing.Size(500, 300);
            this.dgvAuteurs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuteurs_CellClick);

            // btnAjouter
            this.btnAjouter.Location = new System.Drawing.Point(12, 320);
            this.btnAjouter.Size = new System.Drawing.Size(100, 30);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);

            // FormAuteurs
            this.ClientSize = new System.Drawing.Size(530, 360);
            this.Controls.Add(this.dgvAuteurs);
            this.Controls.Add(this.btnAjouter);
            this.Text = "Gestion des Auteurs";

            ((System.ComponentModel.ISupportInitialize)(this.dgvAuteurs)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

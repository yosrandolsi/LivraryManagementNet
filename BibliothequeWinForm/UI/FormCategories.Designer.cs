namespace BibliothequeWinForm.UI
{
    partial class FormCategories
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnAjouter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();

            // dgvCategories
            this.dgvCategories.Location = new System.Drawing.Point(12, 12);
            this.dgvCategories.Size = new System.Drawing.Size(400, 250);
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);

            // btnAjouter
            this.btnAjouter.Location = new System.Drawing.Point(12, 270);
            this.btnAjouter.Size = new System.Drawing.Size(100, 30);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);

            // FormCategories
            this.ClientSize = new System.Drawing.Size(430, 320);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.btnAjouter);
            this.Text = "Gestion des Catégories";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

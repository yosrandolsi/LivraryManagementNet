namespace BibliothequeWinForm.UI
{
    partial class FormGestionEmprunts
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEmprunts;

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
            this.dgvEmprunts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmprunts
            // 
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmprunts.Location = new System.Drawing.Point(0, 0);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowHeadersWidth = 51;
            this.dgvEmprunts.RowTemplate.Height = 24;
            this.dgvEmprunts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmprunts.Size = new System.Drawing.Size(800, 450);
            this.dgvEmprunts.TabIndex = 0;
            // 
            // FormGestionEmprunts
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEmprunts);
            this.Name = "FormGestionEmprunts";
            this.Text = "Gestion des Emprunts";
            this.Load += new System.EventHandler(this.FormGestionEmprunts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

namespace BibliothequeWinForm.UI
{
    partial class FormLivres
    {
        private System.Windows.Forms.DataGridView dgvLivres;
        private System.Windows.Forms.Button btnAjouter;

        private void InitializeComponent()
        {
            this.dgvLivres = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivres
            // 
            this.dgvLivres.ColumnHeadersHeight = 29;
            this.dgvLivres.Location = new System.Drawing.Point(12, 12);
            this.dgvLivres.Name = "dgvLivres";
            this.dgvLivres.RowHeadersWidth = 51;
            this.dgvLivres.Size = new System.Drawing.Size(700, 300);
            this.dgvLivres.TabIndex = 0;
            this.dgvLivres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivres_CellClick);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(12, 320);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(120, 30);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter Livre";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // FormLivres
            // 
            this.ClientSize = new System.Drawing.Size(730, 370);
            this.Controls.Add(this.dgvLivres);
            this.Controls.Add(this.btnAjouter);
            this.Name = "FormLivres";
            this.Text = "Gestion des Livres";
            this.Load += new System.EventHandler(this.FormLivres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

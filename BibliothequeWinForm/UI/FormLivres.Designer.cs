using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    partial class FormLivres
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Panel panelTop;
        private Label lblTitle;
        private TextBox txtRecherche;
        private Label lblRecherche;
        private Button btnAjouter;
        private DataGridView dgvLivres;
        private FlowLayoutPanel panelCategories;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dgvLivres = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.panelCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.panelContainer.Controls.Add(this.dgvLivres);
            this.panelContainer.Controls.Add(this.panelTop);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Size = new System.Drawing.Size(760, 520);
            this.panelContainer.TabIndex = 0;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // dgvLivres
            // 
            this.dgvLivres.ColumnHeadersHeight = 29;
            this.dgvLivres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLivres.Location = new System.Drawing.Point(20, 145);
            this.dgvLivres.Name = "dgvLivres";
            this.dgvLivres.RowHeadersWidth = 51;
            this.dgvLivres.Size = new System.Drawing.Size(720, 355);
            this.dgvLivres.TabIndex = 0;
            this.dgvLivres.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivres_CellContentClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblRecherche);
            this.panelTop.Controls.Add(this.txtRecherche);
            this.panelTop.Controls.Add(this.btnAjouter);
            this.panelTop.Controls.Add(this.panelCategories);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(720, 125);
            this.panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 Gestion des Livres";
            // 
            // lblRecherche
            // 
            this.lblRecherche.Location = new System.Drawing.Point(15, 50);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(100, 23);
            this.lblRecherche.TabIndex = 1;
            this.lblRecherche.Text = "🔍 Rechercher :";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(140, 50);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(100, 22);
            this.txtRecherche.TabIndex = 2;
            this.txtRecherche.TextChanged += new System.EventHandler(this.TxtRecherche_TextChanged);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(520, 45);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 3;
            this.btnAjouter.Text = "➕ Ajouter Livre";
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // panelCategories
            // 
            this.panelCategories.Location = new System.Drawing.Point(10, 90);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(700, 30);
            this.panelCategories.TabIndex = 4;
            this.panelCategories.WrapContents = false;
            // 
            // FormLivres
            // 
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLivres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormLivres_Load);
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

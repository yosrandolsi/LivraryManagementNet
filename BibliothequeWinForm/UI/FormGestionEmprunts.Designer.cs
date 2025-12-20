namespace BibliothequeWinForm.UI
{
    partial class FormGestionEmprunts
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.DataGridView dgvEmprunts;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dgvEmprunts = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(239, 228, 225);
            this.panelContainer.Controls.Add(this.dgvEmprunts);
            this.panelContainer.Controls.Add(this.panelTop);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Size = new System.Drawing.Size(1000, 650);
            this.panelContainer.TabIndex = 0;
            //this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelContainer_Paint);
            // 
            // dgvEmprunts
            // 
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.AllowUserToResizeRows = false;
            this.dgvEmprunts.BackgroundColor = System.Drawing.Color.FromArgb(248, 244, 242);
            this.dgvEmprunts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Location = new System.Drawing.Point(20, 110);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowHeadersVisible = false;
            this.dgvEmprunts.RowTemplate.Height = 40;
            this.dgvEmprunts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmprunts.Size = new System.Drawing.Size(960, 520);
            this.dgvEmprunts.TabIndex = 0;
            this.dgvEmprunts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmprunts_CellClick);
            this.dgvEmprunts.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvEmprunts_CellPainting);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(173, 216, 230);
            this.panelTop.Controls.Add(this.btnRetour);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(960, 80);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(135, 206, 235);
            this.btnRetour.FlatAppearance.BorderSize = 0;
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(20, 20);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(50, 40);
            this.btnRetour.TabIndex = 3;
            this.btnRetour.Text = "←";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(90, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(421, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 Gestion des Emprunts";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(910, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(870, 20);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "─";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // FormGestionEmprunts
            // 
            this.BackColor = System.Drawing.Color.FromArgb(245, 235, 230);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGestionEmprunts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Emprunts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGestionEmprunts_FormClosing);
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}

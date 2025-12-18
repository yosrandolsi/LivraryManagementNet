using System.Drawing;

namespace BibliothequeWinForm.UI
{
    partial class FormGestionEmprunts
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
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
            this.dgvEmprunts = new System.Windows.Forms.DataGridView();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();

            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();

            // panelContainer
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(255, 239, 228, 225);
            this.panelContainer.Controls.Add(this.dgvEmprunts);
            this.panelContainer.Controls.Add(this.panelTitle);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(900, 600);

            // dgvEmprunts
            this.dgvEmprunts.AllowUserToAddRows = false;
            this.dgvEmprunts.AllowUserToDeleteRows = false;
            this.dgvEmprunts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmprunts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunts.Location = new System.Drawing.Point(20, 100);
            this.dgvEmprunts.Name = "dgvEmprunts";
            this.dgvEmprunts.ReadOnly = true;
            this.dgvEmprunts.RowTemplate.Height = 40;
            this.dgvEmprunts.Size = new System.Drawing.Size(860, 480);
            this.dgvEmprunts.TabIndex = 0;

            // panelTitle
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(200, 178, 214, 255);
            this.panelTitle.Controls.Add(this.lblSubtitle);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Controls.Add(this.btnRetour);
            this.panelTitle.Location = new System.Drawing.Point(20, 20);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(860, 60);
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.lblSubtitle.Location = new System.Drawing.Point(400, 35);
            this.lblSubtitle.Text = "Gestion complète des emprunts et retours de livres";

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Text = "📚 GESTION DES EMPRUNTS";

            // btnMinimize
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(790, 15);
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.Text = "─";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // btnClose
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(830, 15);
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // btnRetour
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRetour.ForeColor = Color.White;
            this.btnRetour.BackColor = Color.FromArgb(178, 214, 255);
            this.btnRetour.Location = new System.Drawing.Point(670, 15);
            this.btnRetour.Size = new System.Drawing.Size(100, 30);
            this.btnRetour.Text = "← Retour";
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);

            // FormGestionEmprunts
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormGestionEmprunts_Load);

            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunts)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace BibliothequeWinForm.UI
{
    partial class FormClients
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Panel panelTitle;
        private Panel panelContent;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnClose;
        private Button btnMinimize;
        private Button btnAjouter;
        private Button btnBack;
        private DataGridView dgvClients;
        private TextBox txtSearch;
        private Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContainer = new Panel();
            this.panelTitle = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.btnClose = new Button();
            this.btnMinimize = new Button();
            this.panelContent = new Panel();
            this.btnBack = new Button();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.dgvClients = new DataGridView();
            this.btnAjouter = new Button();

            // panelContainer
            this.panelContainer.Dock = DockStyle.Fill;
            this.panelContainer.BackColor = Color.FromArgb(239, 228, 225);
            this.panelContainer.Controls.Add(this.panelContent);
            this.panelContainer.Controls.Add(this.panelTitle);

            // panelTitle
            this.panelTitle.BackColor = Color.FromArgb(200, 173, 216, 230);
            this.panelTitle.Dock = DockStyle.Top;
            this.panelTitle.Height = 80;
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Controls.Add(this.lblSubtitle);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.btnMinimize);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 10);
            this.lblTitle.Text = "👥 GESTION CLIENTS";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblSubtitle.ForeColor = Color.FromArgb(230, 230, 230);
            this.lblSubtitle.Location = new Point(20, 45);
            this.lblSubtitle.Text = "Gestion des clients de la bibliothèque";

            // btnMinimize
            this.btnMinimize.FlatStyle = FlatStyle.Flat;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnMinimize.ForeColor = Color.White;
            this.btnMinimize.Size = new Size(30, 30);
            this.btnMinimize.Location = new Point(790, 20);
            this.btnMinimize.Text = "─";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // btnClose
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Size = new Size(30, 30);
            this.btnClose.Location = new Point(830, 20);
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // panelContent
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Padding = new Padding(20);
            this.panelContent.BackColor = Color.Transparent;
            this.panelContent.Controls.Add(this.btnBack);
            this.panelContent.Controls.Add(this.lblSearch);
            this.panelContent.Controls.Add(this.txtSearch);
            this.panelContent.Controls.Add(this.dgvClients);
            this.panelContent.Controls.Add(this.btnAjouter);

            // btnBack
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Color.FromArgb(200, 200, 200);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Size = new Size(100, 30);
            this.btnBack.Location = new Point(0, 0); // visible en haut à gauche
            this.btnBack.Text = "⬅ Retour";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new Point(120, 5);
            this.lblSearch.Text = "Rechercher par Nom :";

            // txtSearch
            this.txtSearch.Location = new Point(270, 2);
            this.txtSearch.Size = new Size(250, 22);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // dgvClients
            this.dgvClients.Location = new Point(0, 40);
            this.dgvClients.Size = new Size(820, 380);
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.MultiSelect = false;
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.CellClick += new DataGridViewCellEventHandler(this.dgvClients_CellClick);

            // btnAjouter
            this.btnAjouter.Size = new Size(180, 40);
            this.btnAjouter.Location = new Point(0, 430);
            this.btnAjouter.Text = "➕ Ajouter Client";
            this.btnAjouter.FlatStyle = FlatStyle.Flat;
            this.btnAjouter.BackColor = Color.FromArgb(200, 173, 216, 230);
            this.btnAjouter.ForeColor = Color.White;
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);

            // FormClients
            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestion des Clients";
        }
    }
}

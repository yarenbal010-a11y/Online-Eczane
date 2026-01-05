namespace OnlineEczane
{
    partial class AnaSayfaFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstKategoriler = new ListBox();
            dgvUrunler = new DataGridView();
            pnlSepet = new Panel();
            btnSatinAl = new Button();
            btnSepettenSil = new Button();
            lblToplam = new Label();
            lstSepet = new ListBox();
            lblSepetBaslik = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).BeginInit();
            pnlSepet.SuspendLayout();
            SuspendLayout();
            // 
            // lstKategoriler
            // 
            lstKategoriler.Dock = DockStyle.Left;
            lstKategoriler.FormattingEnabled = true;
            lstKategoriler.Location = new Point(0, 0);
            lstKategoriler.Name = "lstKategoriler";
            lstKategoriler.Size = new Size(220, 453);
            lstKategoriler.TabIndex = 0;
            lstKategoriler.SelectedIndexChanged += lstKategoriler_SelectedIndexChanged;
            // 
            // dgvUrunler
            // 
            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUrunler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUrunler.Dock = DockStyle.Fill;
            dgvUrunler.Location = new Point(220, 0);
            dgvUrunler.Name = "dgvUrunler";
            dgvUrunler.ReadOnly = true;
            dgvUrunler.RowHeadersWidth = 51;
            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.Size = new Size(516, 453);
            dgvUrunler.TabIndex = 1;
            // 
            // pnlSepet
            // 
            pnlSepet.BackColor = Color.WhiteSmoke;
            pnlSepet.Controls.Add(btnSatinAl);
            pnlSepet.Controls.Add(btnSepettenSil);
            pnlSepet.Controls.Add(lblToplam);
            pnlSepet.Controls.Add(lstSepet);
            pnlSepet.Controls.Add(lblSepetBaslik);
            pnlSepet.Dock = DockStyle.Right;
            pnlSepet.Location = new Point(736, 0);
            pnlSepet.Name = "pnlSepet";
            pnlSepet.Size = new Size(260, 453);
            pnlSepet.TabIndex = 2;
            // 
            // btnSatinAl
            // 
            btnSatinAl.Location = new Point(154, 218);
            btnSatinAl.Name = "btnSatinAl";
            btnSatinAl.Size = new Size(94, 29);
            btnSatinAl.TabIndex = 4;
            btnSatinAl.Text = "Satın Al";
            btnSatinAl.UseVisualStyleBackColor = true;
            // 
            // btnSepettenSil
            // 
            btnSepettenSil.Location = new Point(28, 218);
            btnSepettenSil.Name = "btnSepettenSil";
            btnSepettenSil.Size = new Size(94, 29);
            btnSepettenSil.TabIndex = 3;
            btnSepettenSil.Text = "Seçiliyi Sil";
            btnSepettenSil.UseVisualStyleBackColor = true;
            btnSepettenSil.Click += btnSepettenSil_Click;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Location = new Point(3, 164);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(93, 20);
            lblToplam.TabIndex = 2;
            lblToplam.Text = "Toplam: 0 TL";
            // 
            // lstSepet
            // 
            lstSepet.FormattingEnabled = true;
            lstSepet.Location = new Point(3, 43);
            lstSepet.Name = "lstSepet";
            lstSepet.Size = new Size(257, 104);
            lstSepet.TabIndex = 1;
            // 
            // lblSepetBaslik
            // 
            lblSepetBaslik.AutoSize = true;
            lblSepetBaslik.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSepetBaslik.Location = new Point(3, 9);
            lblSepetBaslik.Name = "lblSepetBaslik";
            lblSepetBaslik.Size = new Size(74, 31);
            lblSepetBaslik.TabIndex = 0;
            lblSepetBaslik.Text = "Sepet";
            // 
            // AnaSayfaFormu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 453);
            Controls.Add(dgvUrunler);
            Controls.Add(pnlSepet);
            Controls.Add(lstKategoriler);
            Name = "AnaSayfaFormu";
            Text = "Ana Sayfa Formu";
            Load += AnaSayfaFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).EndInit();
            pnlSepet.ResumeLayout(false);
            pnlSepet.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstKategoriler;
        private DataGridView dgvUrunler;
        private Panel pnlSepet;
        private ListBox lstSepet;
        private Label lblSepetBaslik;
        private Button btnSatinAl;
        private Button btnSepettenSil;
        private Label lblToplam;
    }
}
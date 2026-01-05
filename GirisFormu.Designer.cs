namespace OnlineEczane
{
    partial class GirisFormu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlsol = new Panel();
            picGorsel = new PictureBox();
            pnlSag = new Panel();
            pnlKart = new Panel();
            btnKayitOl = new Button();
            btnGiris = new Button();
            txtSifreGoster = new CheckBox();
            txtSifre = new TextBox();
            label2 = new Label();
            txtEposta = new TextBox();
            label1 = new Label();
            lblBaslik = new Label();
            pnlsol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGorsel).BeginInit();
            pnlSag.SuspendLayout();
            pnlKart.SuspendLayout();
            SuspendLayout();
            // 
            // pnlsol
            // 
            pnlsol.BackColor = Color.LightGreen;
            pnlsol.Controls.Add(picGorsel);
            pnlsol.Dock = DockStyle.Left;
            pnlsol.Location = new Point(0, 0);
            pnlsol.Name = "pnlsol";
            pnlsol.Size = new Size(250, 600);
            pnlsol.TabIndex = 0;
            // 
            // picGorsel
            // 
            picGorsel.BackColor = Color.SteelBlue;
            picGorsel.Dock = DockStyle.Fill;
            picGorsel.Location = new Point(0, 0);
            picGorsel.Name = "picGorsel";
            picGorsel.Size = new Size(250, 600);
            picGorsel.SizeMode = PictureBoxSizeMode.Zoom;
            picGorsel.TabIndex = 0;
            picGorsel.TabStop = false;
            // 
            // pnlSag
            // 
            pnlSag.Controls.Add(pnlKart);
            pnlSag.Dock = DockStyle.Fill;
            pnlSag.Location = new Point(250, 0);
            pnlSag.Name = "pnlSag";
            pnlSag.Size = new Size(750, 600);
            pnlSag.TabIndex = 1;
            pnlSag.Resize += pnlSag_Resize;
            // 
            // pnlKart
            // 
            pnlKart.Controls.Add(btnKayitOl);
            pnlKart.Controls.Add(btnGiris);
            pnlKart.Controls.Add(txtSifreGoster);
            pnlKart.Controls.Add(txtSifre);
            pnlKart.Controls.Add(label2);
            pnlKart.Controls.Add(txtEposta);
            pnlKart.Controls.Add(label1);
            pnlKart.Controls.Add(lblBaslik);
            pnlKart.Location = new Point(128, 74);
            pnlKart.Name = "pnlKart";
            pnlKart.Size = new Size(462, 420);
            pnlKart.TabIndex = 0;
            // 
            // btnKayitOl
            // 
            btnKayitOl.BackColor = SystemColors.ActiveCaption;
            btnKayitOl.FlatStyle = FlatStyle.Flat;
            btnKayitOl.Location = new Point(85, 313);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(94, 29);
            btnKayitOl.TabIndex = 7;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.UseVisualStyleBackColor = false;
            btnKayitOl.Click += btnKayitOl_Click;
            // 
            // btnGiris
            // 
            btnGiris.BackColor = SystemColors.GradientActiveCaption;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.ForeColor = Color.Black;
            btnGiris.Location = new Point(288, 313);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(94, 29);
            btnGiris.TabIndex = 6;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // txtSifreGöster
            // 
            txtSifreGoster.AutoSize = true;
            txtSifreGoster.Location = new Point(119, 219);
            txtSifreGoster.Name = "txtSifreGöster";
            txtSifreGoster.Size = new Size(119, 24);
            txtSifreGoster.TabIndex = 5;
            txtSifreGoster.Text = "Şifreyi Göster";
            txtSifreGoster.UseVisualStyleBackColor = true;
            txtSifreGoster.CheckedChanged += this.txtSifreGoster_CheckedChanged;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 11F);
            txtSifre.Location = new Point(119, 181);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(218, 32);
            txtSifre.TabIndex = 4;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(20, 181);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 3;
            label2.Text = "Şifre";
            // 
            // txtEposta
            // 
            txtEposta.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtEposta.Location = new Point(119, 109);
            txtEposta.Name = "txtEposta";
            txtEposta.Size = new Size(300, 31);
            txtEposta.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(20, 112);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 1;
            label1.Text = "E-Posta";
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(155, 26);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(140, 41);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Giriş Yap";
            // 
            // GirisFormu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlSag);
            Controls.Add(pnlsol);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "GirisFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OnlineEczane-Giris";
            Load += GirisFormu_Load;
            pnlsol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGorsel).EndInit();
            pnlSag.ResumeLayout(false);
            pnlKart.ResumeLayout(false);
            pnlKart.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlsol;
        private PictureBox picGorsel;
        private Panel pnlSag;
        private Panel pnlKart;
        private TextBox txtEposta;
        private Label label1;
        private Label lblBaslik;
        private TextBox txtSifre;
        private Label label2;
        private Button btnKayitOl;
        private Button btnGiris;
        private CheckBox txtSifreGoster;
    }
}

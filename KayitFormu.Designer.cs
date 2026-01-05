namespace OnlineEczane
{
    partial class KayitFormu
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
            label1 = new Label();
            txtAdSoyad = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtEposta = new TextBox();
            txtSifre = new TextBox();
            btnKaydet = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 48);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad Soyad";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(185, 48);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(125, 27);
            txtAdSoyad.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 108);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 2;
            label2.Text = "E-Posta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 172);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 3;
            label3.Text = "Şifre";
            // 
            // txtEposta
            // 
            txtEposta.Location = new Point(185, 108);
            txtEposta.Name = "txtEposta";
            txtEposta.Size = new Size(125, 27);
            txtEposta.TabIndex = 4;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(185, 172);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(125, 27);
            txtSifre.TabIndex = 5;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(185, 239);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(125, 29);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "Kaydı Oluştur";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // KayitFormu
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKaydet);
            Controls.Add(txtSifre);
            Controls.Add(txtEposta);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtAdSoyad);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "KayitFormu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kayıt Ol";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAdSoyad;
        private Label label2;
        private Label label3;
        private TextBox txtEposta;
        private TextBox txtSifre;
        private Button btnKaydet;
    }
}
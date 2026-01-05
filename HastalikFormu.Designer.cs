namespace OnlineEczane
{
    partial class HastalikFormu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblBaslik = new Label();
            cmbHastalik = new ComboBox();
            btnOner = new Button();
            dgvOneriler = new DataGridView();
            btnDevam = new Button();
            pnlTop = new Panel();
            pnlKart = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOneriler).BeginInit();
            pnlTop.SuspendLayout();
            pnlKart.SuspendLayout();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBaslik.ForeColor = Color.White;
            lblBaslik.Location = new Point(20, 15);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(290, 38);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Hastalığa Göre Öneri";
            // 
            // cmbHastalik
            // 
            cmbHastalik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHastalik.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbHastalik.FormattingEnabled = true;
            cmbHastalik.Location = new Point(30, 40);
            cmbHastalik.Name = "cmbHastalik";
            cmbHastalik.Size = new Size(250, 33);
            cmbHastalik.TabIndex = 1;
            // 
            // btnOner
            // 
            btnOner.BackColor = Color.SteelBlue;
            btnOner.FlatAppearance.BorderSize = 0;
            btnOner.FlatStyle = FlatStyle.Flat;
            btnOner.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnOner.ForeColor = Color.White;
            btnOner.Location = new Point(282, 330);
            btnOner.Name = "btnOner";
            btnOner.Size = new Size(300, 38);
            btnOner.TabIndex = 2;
            btnOner.Text = "İlaç Öner";
            btnOner.UseVisualStyleBackColor = false;
            btnOner.Click += btnOner_Click;
            // 
            // dgvOneriler
            // 
            dgvOneriler.AllowUserToDeleteRows = false;
            dgvOneriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOneriler.BackgroundColor = Color.White;
            dgvOneriler.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 243, 246);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOneriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOneriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(227, 242, 253);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOneriler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOneriler.EnableHeadersVisualStyles = false;
            dgvOneriler.Location = new Point(30, 90);
            dgvOneriler.Name = "dgvOneriler";
            dgvOneriler.ReadOnly = true;
            dgvOneriler.RowHeadersVisible = false;
            dgvOneriler.RowHeadersWidth = 51;
            dgvOneriler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOneriler.Size = new Size(740, 220);
            dgvOneriler.TabIndex = 3;
            // 
            // btnDevam
            // 
            btnDevam.BackColor = Color.SteelBlue;
            btnDevam.FlatStyle = FlatStyle.Flat;
            btnDevam.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDevam.ForeColor = Color.White;
            btnDevam.Location = new Point(30, 330);
            btnDevam.Name = "btnDevam";
            btnDevam.Size = new Size(160, 35);
            btnDevam.TabIndex = 4;
            btnDevam.Text = "Ana Sayfaya Geç";
            btnDevam.UseVisualStyleBackColor = false;
            btnDevam.Click += btnDevam_Click;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.MidnightBlue;
            pnlTop.Controls.Add(lblBaslik);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(818, 60);
            pnlTop.TabIndex = 6;
            // 
            // pnlKart
            // 
            pnlKart.BorderStyle = BorderStyle.FixedSingle;
            pnlKart.Controls.Add(label1);
            pnlKart.Controls.Add(cmbHastalik);
            pnlKart.Controls.Add(btnDevam);
            pnlKart.Controls.Add(btnOner);
            pnlKart.Controls.Add(dgvOneriler);
            pnlKart.Location = new Point(20, 80);
            pnlKart.Name = "pnlKart";
            pnlKart.Size = new Size(800, 400);
            pnlKart.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(30, 15);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 4;
            label1.Text = "Hastalık Seç:";
            // 
            // HastalikFormu
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 518);
            Controls.Add(pnlKart);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HastalikFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hastalığa Göre İlaç Öneri";
            Load += HastalikFormu_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvOneriler).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKart.ResumeLayout(false);
            pnlKart.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBaslik;
        private ComboBox cmbHastalik;
        private Button btnOner;
        private DataGridView dgvOneriler;
        private Button btnDevam;
        private Panel pnlTop;
        private Panel pnlKart;
        private Label label1;
    }
}
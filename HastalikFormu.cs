using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OnlineEczane
{
    public partial class HastalikFormu : Form
    {
        private string DbPath =>
    Path.Combine(Application.StartupPath, "Database", "eczane.db");

        private string ConnectionString =>
            $"Data Source={DbPath};Version=3;";

        private void HastaliklariYukle()
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                var dt = new DataTable();
                using (var da = new SQLiteDataAdapter("SELECT HastalikId, Ad FROM Hastaliklar ORDER BY Ad;", con))
                    da.Fill(dt);

                cmbHastalik.DisplayMember = "Ad";
                cmbHastalik.ValueMember = "HastalikId";
                cmbHastalik.DataSource = dt;
            }
        }
        private void OnerileriGetir(int hastalikId)
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                var dt = new DataTable();

                string sql = @"
        SELECT p.ProductId, p.Name AS Urun, p.Price AS Fiyat, p.Stock AS Stok
        FROM HastalikOneri ho
        JOIN Products p ON p.ProductId = ho.ProductId
        WHERE ho.HastalikId = @hid
        ORDER BY p.Name;";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@hid", hastalikId);
                    using (var da = new SQLiteDataAdapter(cmd))
                        da.Fill(dt);
                }

                dgvOneriler.DataSource = dt;
            }
        }
        



        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            var ana = new AnaSayfaFormu();
            ana.Show();
            this.Hide();
        }

        public HastalikFormu()
        {
            InitializeComponent();
        }

        private void HastalikFormu_Load_1(object sender, EventArgs e)
        {
            HastaliklariYukle();

            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                var dt = new System.Data.DataTable();
                using (var da = new SQLiteDataAdapter("SELECT HastalikId, Ad FROM Hastaliklar ORDER BY Ad;", con))
                    da.Fill(dt);

               

                cmbHastalik.DisplayMember = "Ad";
                cmbHastalik.ValueMember = "HastalikId";
                cmbHastalik.DataSource = dt;
            }

        }


        private void btnOner_Click(object sender, EventArgs e)
        {
            if (cmbHastalik.SelectedValue == null) return;
            int hid = Convert.ToInt32(cmbHastalik.SelectedValue);

            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                var dt = new System.Data.DataTable();

                string sql = @"
SELECT p.ProductId, p.Name AS Urun, p.Price AS Fiyat, p.Stock AS Stok
FROM HastalikOneri ho
JOIN Products p ON p.ProductId = ho.ProductId
WHERE ho.HastalikId = @hid
ORDER BY p.Name;";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@hid", hid);
                    using (var da = new SQLiteDataAdapter(cmd))
                        da.Fill(dt);
                }

                dgvOneriler.DataSource = dt;
            }
        }


        private void btnDevam_Click(object sender, EventArgs e)
        
        {
            AnaSayfaFormu ana = new AnaSayfaFormu();
            ana.Show();
            this.Hide();
        }

    }
}




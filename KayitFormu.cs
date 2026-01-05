using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;



namespace OnlineEczane
{
    public partial class KayitFormu : Form

    {
        private string DbPath =>
    Path.Combine(Application.StartupPath, "Database", "eczane.db");

        private string ConnectionString =>
            $"Data Source={DbPath};Version=3;";

        public KayitFormu()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        
        {
            string adSoyad = txtAdSoyad.Text.Trim();
            string eposta = txtEposta.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrWhiteSpace(adSoyad) ||
                string.IsNullOrWhiteSpace(eposta) ||
                string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();

                // Aynı e-posta var mı?
                using (var kontrol = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Email=@e;", con))
                {
                    kontrol.Parameters.AddWithValue("@e", eposta);
                    long varMi = (long)kontrol.ExecuteScalar();
                    if (varMi > 0)
                    {
                        MessageBox.Show("Bu e-posta zaten kayıtlı.", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Kayıt ekle
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Users (FullName, Email, Password) VALUES (@ad, @e, @p);", con))
                {
                    cmd.Parameters.AddWithValue("@ad", adSoyad);
                    cmd.Parameters.AddWithValue("@e", eposta);
                    cmd.Parameters.AddWithValue("@p", sifre);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Kayıt başarılı ✅ Şimdi giriş yapabilirsiniz.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OnlineEczane
{
    public partial class AnaSayfaFormu : Form
    {
        // --- SEPET MODELİ ---
        private class SepetItem
        {
            public int ProductId { get; set; }
            public string Urun { get; set; } = "";
            public decimal Fiyat { get; set; }
            public int Adet { get; set; }
        }

        private readonly List<SepetItem> _sepet = new List<SepetItem>();
        private decimal toplamTutar = 0;

        private string DbPath => Path.Combine(Application.StartupPath, "Database", "eczane.db");
        private string ConnectionString => $"Data Source={DbPath};Version=3;";

        // Grid kolon isimleri SABİT
        private const string COL_FOTO = "colFoto";
        private const string COL_ID = "colId";
        private const string COL_URUN = "colUrun";
        private const string COL_FIYAT = "colFiyat";
        private const string COL_STOK = "colStok";
        private const string COL_PATH = "colPath";
        private const string COL_EKLE = "colEkle";

        public AnaSayfaFormu()
        {
            InitializeComponent();

          
            this.Load += AnaSayfaFormu_Load;
            lstKategoriler.SelectedIndexChanged += lstKategoriler_SelectedIndexChanged;
            dgvUrunler.CellContentClick += dgvUrunler_CellContentClick;
            btnSatinAl.Click += btnSatinAl_Click;
            btnSepettenSil.Click += btnSepettenSil_Click;
        }

        private void AnaSayfaFormu_Load(object sender, EventArgs e)
        {
            GridHazirla();       // 1 kere
            KategorileriYukle(); // soldaki liste
            SepetiEkranaBas();   // toplam 0 TL
        }

        
        private void GridHazirla()
        {
            dgvUrunler.DataSource = null;
            dgvUrunler.Columns.Clear();

            dgvUrunler.AutoGenerateColumns = false;
            dgvUrunler.AllowUserToAddRows = false;
            dgvUrunler.ReadOnly = true;
            dgvUrunler.RowHeadersVisible = false;
            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.MultiSelect = false;

            dgvUrunler.RowTemplate.Height = 70;

            // FOTO
            var imgCol = new DataGridViewImageColumn
            {
                Name = COL_FOTO,
                HeaderText = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 90
            };
            imgCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns.Add(imgCol);

            // ID
            var idCol = new DataGridViewTextBoxColumn
            {
                Name = COL_ID,
                HeaderText = "ID",
                DataPropertyName = "ProductId",
                Width = 60
            };
            idCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns.Add(idCol);

            // Ürün
            var urunCol = new DataGridViewTextBoxColumn
            {
                Name = COL_URUN,
                HeaderText = "Ürün",
                DataPropertyName = "Urun",
            };
            dgvUrunler.Columns.Add(urunCol);

            // Fiyat
            var fiyatCol = new DataGridViewTextBoxColumn
            {
                Name = COL_FIYAT,
                HeaderText = "Fiyat",
                DataPropertyName = "Fiyat",
                Width = 80
            };
            fiyatCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns.Add(fiyatCol);

            // Stok
            var stokCol = new DataGridViewTextBoxColumn
            {
                Name = COL_STOK,
                HeaderText = "Stok",
                DataPropertyName = "Stok",
                Width = 70
            };
            stokCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns.Add(stokCol);

            // ImagePath
            var pathCol = new DataGridViewTextBoxColumn
            {
                Name = COL_PATH,
                HeaderText = "ImagePath",
                DataPropertyName = "ImagePath",
                Visible = false
            };
            dgvUrunler.Columns.Add(pathCol);

            // SEPETE EKLE BUTONU
            var btnCol = new DataGridViewButtonColumn
            {
                Name = COL_EKLE,
                HeaderText = "",
                Text = "Ekle",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            btnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns.Add(btnCol);

            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

         
            dgvUrunler.Columns[COL_FOTO].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns[COL_FOTO].Width = 90;

            dgvUrunler.Columns[COL_ID].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns[COL_ID].Width = 60;

            dgvUrunler.Columns[COL_FIYAT].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns[COL_FIYAT].Width = 80;

            dgvUrunler.Columns[COL_STOK].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns[COL_STOK].Width = 70;

            dgvUrunler.Columns[COL_EKLE].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvUrunler.Columns[COL_EKLE].Width = 80;
        }

        // 2) KATEGORİLERİ SOLA YÜKLE
        private void KategorileriYukle()
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                var dt = new DataTable();
                using (var da = new SQLiteDataAdapter("SELECT CategoryId, Name FROM Categories ORDER BY Name;", con))
                {
                    da.Fill(dt);
                }

               
                lstKategoriler.DataSource = null;
                lstKategoriler.DisplayMember = "Name";
                lstKategoriler.ValueMember = "CategoryId";
                lstKategoriler.DataSource = dt;
            }
        }

        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedValue == null) return;
            if (!int.TryParse(lstKategoriler.SelectedValue.ToString(), out int kategoriId)) return;

            UrunleriYukle(kategoriId);
        }

        // 3) ÜRÜNLERİ GRID'E YÜKLE
        private void UrunleriYukle(int kategoriId)
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();

                var dt = new DataTable();
                using (var cmd = new SQLiteCommand(
                    "SELECT ProductId, Name AS Urun, Price AS Fiyat, Stock AS Stok, ImagePath " +
                    "FROM Products WHERE CategoryId=@id ORDER BY Name;", con))
                {
                    cmd.Parameters.AddWithValue("@id", kategoriId);
                    using (var da = new SQLiteDataAdapter(cmd))
                        da.Fill(dt);
                }

                dgvUrunler.DataSource = dt;

                foreach (DataGridViewRow row in dgvUrunler.Rows)
                {
                    if (row.IsNewRow) continue;

                    var relPath = row.Cells[COL_PATH].Value?.ToString();
                    row.Cells[COL_FOTO].Value = LoadProductImage(relPath);
                }
            }
        }

        // 4) BUTON TIKLANINCA SEPETE EKLE
        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvUrunler.Columns[e.ColumnIndex].Name != COL_EKLE) return;

            int productId = Convert.ToInt32(dgvUrunler.Rows[e.RowIndex].Cells[COL_ID].Value);
            SepeteEkle(productId);
        }

        private void SepeteEkle(int productId)
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();

                using var cmd = new SQLiteCommand(
                    "SELECT Name, Price, Stock FROM Products WHERE ProductId=@id;", con);
                cmd.Parameters.AddWithValue("@id", productId);

                using var r = cmd.ExecuteReader();
                if (!r.Read()) return;

                string urunAdi = r["Name"]?.ToString() ?? "";
                decimal fiyat = Convert.ToDecimal(r["Price"]);
                int stok = Convert.ToInt32(r["Stock"]);

                var mevcut = _sepet.FirstOrDefault(x => x.ProductId == productId);
                int sepetteki = mevcut?.Adet ?? 0;

                if (sepetteki + 1 > stok)
                {
                    MessageBox.Show("Bu üründen yeterli stok yok!");
                    return;
                }

                if (mevcut == null)
                    _sepet.Add(new SepetItem { ProductId = productId, Urun = urunAdi, Fiyat = fiyat, Adet = 1 });
                else
                    mevcut.Adet++;
            }

            SepetiEkranaBas();
        }

        private void SepetiEkranaBas()
        {
            lstSepet.Items.Clear();
            toplamTutar = 0;

            foreach (var item in _sepet)
            {
                var araToplam = item.Fiyat * item.Adet;
                toplamTutar += araToplam;
                lstSepet.Items.Add($"{item.Urun} x{item.Adet} - {araToplam} TL");
            }

            lblToplam.Text = $"Toplam: {toplamTutar} TL";
        }

        private void btnSepettenSil_Click(object sender, EventArgs e)
        {
            if (lstSepet.SelectedIndex < 0) return;

            // seçilen satır -> aynı indexteki sepet elemanı
            int idx = lstSepet.SelectedIndex;
            if (idx >= 0 && idx < _sepet.Count)
                _sepet.RemoveAt(idx);

            SepetiEkranaBas();
        }

        // 5) SATIN AL -> STOK DÜŞ
        private void btnSatinAl_Click(object sender, EventArgs e)
        {
            if (_sepet.Count == 0)
            {
                MessageBox.Show("Sepet boş.");
                return;
            }

            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                using (var tr = con.BeginTransaction())
                {
                    // stok kontrol
                    foreach (var item in _sepet)
                    {
                        using var cmd = new SQLiteCommand("SELECT Stock FROM Products WHERE ProductId=@id;", con, tr);
                        cmd.Parameters.AddWithValue("@id", item.ProductId);
                        int stok = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);

                        if (stok < item.Adet)
                        {
                            tr.Rollback();
                            MessageBox.Show($"Stok yetersiz: {item.Urun}\nMevcut: {stok} / Sepet: {item.Adet}");
                            return;
                        }
                    }

                    // stok düş
                    foreach (var item in _sepet)
                    {
                        using var cmd = new SQLiteCommand(
                            "UPDATE Products SET Stock = Stock - @q WHERE ProductId=@id;", con, tr);
                        cmd.Parameters.AddWithValue("@q", item.Adet);
                        cmd.Parameters.AddWithValue("@id", item.ProductId);
                        cmd.ExecuteNonQuery();
                    }

                    tr.Commit();
                }
            }

            MessageBox.Show("Satın alma başarılı ✅ Stoklar güncellendi.");

            _sepet.Clear();
            SepetiEkranaBas();

            // ekranda stok güncellensin
            if (lstKategoriler.SelectedValue != null && int.TryParse(lstKategoriler.SelectedValue.ToString(), out int kid))
                UrunleriYukle(kid);
        }

        private Image? LoadProductImage(string? relPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(relPath)) return null;

                relPath = relPath.Replace("/", "\\");
                string fullPath = Path.IsPathRooted(relPath)
                    ? relPath
                    : Path.Combine(Application.StartupPath, relPath);

                if (!File.Exists(fullPath)) return null;

                using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return Image.FromStream(fs);
            }
            catch
            {
                return null;
            }
        }
    }
}

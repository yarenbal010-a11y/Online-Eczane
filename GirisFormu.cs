using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing;


namespace OnlineEczane
{
    public partial class GirisFormu : Form

    {
        private void GirisFormu_Load(object sender, EventArgs e)
        {
            pnlKart.Left = (pnlSag.ClientSize.Width - pnlKart.Width) / 2;
            pnlKart.Top = (pnlSag.ClientSize.Height - pnlKart.Height) / 2;
        }

        private void pnlSag_Resize(object sender, EventArgs e)
        {
            pnlKart.Left = (pnlSag.ClientSize.Width - pnlKart.Width) / 2;
            pnlKart.Top = (pnlSag.ClientSize.Height - pnlKart.Height) / 2;
        }
        private string DbPath =>
    Path.Combine(Application.StartupPath, "Database", "eczane.db");

        private string ConnectionString =>
            $"Data Source={DbPath};Version=3;";
        private void CreateDatabaseIfNotExists()
        {

            string folder = Path.GetDirectoryName(DbPath);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(DbPath))
                SQLiteConnection.CreateFile(DbPath);
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Products SET ImagePath=@p WHERE Name='Aerius';", con))
                {
                    cmd.Parameters.AddWithValue("@p", "fotograflar/aerius.jpg");
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand(
    "UPDATE Products SET ImagePath = NULL;", con))
                {
                    cmd.ExecuteNonQuery();
                }
                 
            }


            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();


                string sql = @"
CREATE TABLE IF NOT EXISTS Hastaliklar (
  HastalikId INTEGER PRIMARY KEY AUTOINCREMENT,
  Ad TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS HastalikOneri (
  HastalikId INTEGER NOT NULL,
  ProductId INTEGER NOT NULL,
  PRIMARY KEY (HastalikId, ProductId)
);


CREATE TABLE IF NOT EXISTS Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    Password TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Categories (
    CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Products (
    ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
    CategoryId INTEGER,
    Name TEXT NOT NULL,
    Description TEXT,
    Price REAL,
    Stock INTEGER,
    ImagePath TEXT
);
INSERT OR IGNORE INTO Categories(CategoryId, Name) VALUES
(1,'Aðrý Kesici'),
(2,'Soðuk Algýnlýðý'),
(3,'Vitamin & Takviye'),
(4,'Mide & Sindirim'),
(5,'Alerji'),
(6,'Cilt Bakým'),
(7,'Göz & Burun'),
(8,'Uyku & Stres'),
(9,'Yara Bakým'),
(10,'Aðýz Bakým');
-- Alerji
UPDATE Products SET ImagePath='fotograflar/aerius.jpg' WHERE Name='Aerius';
UPDATE Products SET ImagePath='fotograflar/avil.jpg' WHERE Name='Avil';
UPDATE Products SET ImagePath='fotograflar/claritin.jpg' WHERE Name='Claritin';
UPDATE Products SET ImagePath='fotograflar/zyrtec.jpg' WHERE Name='Zyrtec';

-- Aðrý Kesici
UPDATE Products SET ImagePath='fotograflar/parol.jpg' WHERE Name='Parol 500mg';
UPDATE Products SET ImagePath='fotograflar/minoset.jpg' WHERE Name LIKE 'Minoset%';
UPDATE Products SET ImagePath='fotograflar/majezik.jpg' WHERE Name='Majezik';
UPDATE Products SET ImagePath='fotograflar/apranax.jpg' WHERE Name='Apranax';
UPDATE Products SET ImagePath='fotograflar/arveles.jpg' WHERE Name='Arveles';
UPDATE Products SET ImagePath='fotograflar/nurofen.jpg' WHERE Name='Nurofen';
UPDATE Products SET ImagePath='fotograflar/dolorex.jpg' WHERE Name='Dolorex';
UPDATE Products SET ImagePath='fotograflar/parol.jpg' WHERE Name='Parol';
UPDATE Products SET ImagePath='fotograflar/Vermidon.jpg' WHERE Name='Vermidon';

-- Soðuk Algýnlýðý
UPDATE Products SET ImagePath='fotograflar/aferin.png' WHERE Name LIKE 'Aferin%';
UPDATE Products SET ImagePath='fotograflar/theraflu.jpg' WHERE Name='Theraflu';
UPDATE Products SET ImagePath='fotograflar/gripin.png' WHERE Name='Gripin';
UPDATE Products SET ImagePath='fotograflar/iburamin.jpg' WHERE Name LIKE 'Iburamin';
UPDATE Products SET ImagePath='fotograflar/bisolvon.jpg' WHERE Name='Bisolvon';
UPDATE Products SET ImagePath='fotograflar/ocean_burun_spreyi.jpg' WHERE Name LIKE 'Ocean%';
UPDATE Products SET ImagePath='fotograflar/sudafed.jpg' WHERE Name='Sudafed';
UPDATE Products SET ImagePath='fotograflar/cinko.jpg' WHERE Name='Çinko';

-- Vitamin
UPDATE Products SET ImagePath='fotograflar/redoxon.jpg' WHERE Name LIKE 'Redoxon%';
UPDATE Products SET ImagePath='fotograflar/supradyn.jpg' WHERE Name='Supradyn';
UPDATE Products SET ImagePath='fotograflar/dvit.jpg' WHERE Name LIKE 'D-Vit%';
UPDATE Products SET ImagePath='fotograflar/b12.jpg' WHERE Name LIKE '%B12%';
UPDATE Products SET ImagePath='fotograflar/magnezyum.jpg' WHERE Name LIKE 'Magnezyum';
UPDATE Products SET ImagePath='fotograflar/omega3.jpg' WHERE Name LIKE 'Omega%';
UPDATE Products SET ImagePath='fotograflar/cvit.jpg' WHERE Name LIKE 'C vitamini';

-- Mide
UPDATE Products SET ImagePath='fotograflar/rennie.jpg' WHERE Name='Rennie';
UPDATE Products SET ImagePath='fotograflar/gaviscon.jpg' WHERE Name='Gaviscon';
UPDATE Products SET ImagePath='fotograflar/nexium.jpg' WHERE Name='Nexium';
UPDATE Products SET ImagePath='fotograflar/loperamid.jpg' WHERE Name='Loperamid';
UPDATE Products SET ImagePath='fotograflar/duphalac.jpg' WHERE Name='Duphalac';
UPDATE Products SET ImagePath='fotograflar/majezik.jpg' WHERE Name='Majezik';
-- Cilt
UPDATE Products SET ImagePath='fotograflar/bepanthol.jpg' WHERE Name='Bepanthol';
UPDATE Products SET ImagePath='fotograflar/fito.jpg' WHERE Name LIKE 'Fito%';
UPDATE Products SET ImagePath='fotograflar/hametan.jpg' WHERE Name='Hametan';
UPDATE Products SET ImagePath='fotograflar/canesten.jpg' WHERE Name='Canesten';
UPDATE Products SET ImagePath='fotograflar/sudocrem.jpg' WHERE Name='Sudocrem';

-- Göz & Burun
UPDATE Products SET ImagePath='fotograflar/goz.jpg' WHERE Name LIKE 'Suni%';
UPDATE Products SET ImagePath='fotograflar/otrivine.jpg' WHERE Name='Otrivine';
UPDATE Products SET ImagePath='fotograflar/Nazal Sprey.jpg' WHERE Name='Nazal Sprey';

-- Uyku & Stres
UPDATE Products SET ImagePath='fotograflar/melatonin.jpg' WHERE Name='Melatonin';
UPDATE Products SET ImagePath='fotograflar/passiflora.jpg' WHERE Name='Passiflora';

-- Yara
UPDATE Products SET ImagePath='fotograflar/betadine.jpg' WHERE Name='Betadine';
UPDATE Products SET ImagePath='fotograflar/oksijenli_su.jpg' WHERE Name LIKE 'Oksijenli%';

-- Aðýz
UPDATE Products SET ImagePath='fotograflar/listerine.jpg' WHERE Name='Listerine';
UPDATE Products SET ImagePath='fotograflar/sensodyne.jpg' WHERE Name='Sensodyne';



INSERT OR IGNORE INTO Products(ProductId, CategoryId, Name, Description, Price, Stock, ImagePath) VALUES
-- Aðrý kesici (Cat 1)
(1,1,'Parol 500mg','Aðrý ve ateþ için',65,50,'images/parol.png'),
(2,1,'Minoset 500mg','Aðrý ve ateþ için',60,45,'images/minoset.png'),
(3,1,'Majezik','Kas-eklem aðrýlarý',120,30,'images/majezik.png'),
(4,1,'Apranax','Aðrý kesici antiinflamatuvar',140,25,'images/apranax.png'),
(5,1,'Arveles','Hýzlý etki aðrý kesici',155,20,'images/arveles.png'),
(6,1,'Nurofen','Aðrý ve ateþ',110,35,'images/nurofen.png'),
(7,1,'Dolorex','Aðrý kesici',135,18,'images/dolorex.png'),
(8,1,'Vermidon','Aðrý kesici',90,22,'images/vermidon.png'),

-- Soðuk algýnlýðý (Cat 2)
(21,2,'Aferin Forte','Soðuk algýnlýðý semptomlarý',95,40,'images/aferin.png'),
(22,2,'Theraflu','Grip/nezle semptomlarý',105,30,'images/theraflu.png'),
(23,2,'Gripin','Soðuk algýnlýðý',80,35,'images/gripin.png'),
(24,2,'Coraspin C','Baðýþýklýk destek',85,25,'images/coraspin.png'),
(25,2,'Ocean Burun Spreyi','Burun temizliði',75,30,'images/ocean.png'),
(26,2,'Iburamin Cold','Nezle grip semptomlarý',115,20,'images/iburamin.png'),
(27,2,'Sudafed','Burun týkanýklýðý',125,18,'images/sudafed.png'),
(28,2,'Bisolvon','Balgam söktürücü',90,15,'images/bisolvon.png'),
(29,2,'Kestine Þurup','Alerjik öksürük destek',110,10,'images/kestine.png'),

-- Vitamin (Cat 3)
(41,3,'Redoxon C','C vitamini',130,40,'images/redoxon.png'),
(42,3,'Supradyn','Multivitamin',210,35,'images/supradyn.png'),
(43,3,'D-Vit 1000','D vitamini',160,30,'images/dvit.png'),
(44,3,'B12 Sprey','B12 takviyesi',190,25,'images/b12.png'),
(45,3,'Magnezyum','Kas-enerji desteði',175,30,'images/magnesium.png'),
(46,3,'Çinko','Baðýþýklýk desteði',150,25,'images/zinc.png'),
(47,3,'Omega 3','Kalp-beyin desteði',240,20,'images/omega3.png'),

-- Mide & sindirim (Cat 4)
(61,4,'Rennie','Mide yanmasý',95,40,'images/rennie.png'),
(62,4,'Gaviscon','Reflü/yanma',140,25,'images/gaviscon.png'),
(63,4,'Nexium','Mide koruyucu',220,15,'images/nexium.png'),
(64,4,'Loperamid','Ýshal için',70,30,'images/loperamid.png'),
(65,4,'Duphalac','Kabýzlýk için',110,20,'images/duphalac.png'),
(66,4,'Majezik Plus (Mide destek)','Mide hassasiyetine destek',180,10,'images/mide.png'),

-- Alerji (Cat 5)
(81,5,'Zyrtec','Alerji semptomlarý',145,25,'images/zyrtec.png'),
(82,5,'Aerius','Alerji',155,20,'fotograflar/aerius.jpg'),
(83,5,'Claritin','Alerji',150,18,'images/claritin.png'),
(84,5,'Avil','Alerji',85,25,'images/avil.png'),

-- Cilt (Cat 6)
(101,6,'Bepanthol','Cilt onarým',160,25,'images/bepanthol.png'),
(102,6,'Fito Krem','Yara/yanýk',150,20,'images/fito.png'),
(103,6,'Hametan','Tahriþ',140,20,'images/hametan.png'),
(104,6,'Canesten','Mantar',180,15,'images/canesten.png'),
(105,6,'Sudocrem','Piþik',170,15,'images/sudocrem.png'),

-- Göz & burun (Cat 7)
(121,7,'Suni Gözyaþý','Göz kuruluðu',160,20,'images/goz.png'),
(122,7,'Nazal Sprey','Burun týkanýklýðý',120,15,'images/nazal.png'),
(123,7,'Otrivine','Burun spreyi',130,15,'images/otrivine.png'),

-- Uyku & stres (Cat 8)
(141,8,'Melatonin','Uyku desteði',190,20,'images/melatonin.png'),
(142,8,'Passiflora','Rahatlama',175,20,'images/passiflora.png'),
(143,8,'Magnezyum Relax','Gevþeme desteði',210,15,'images/relax.png'),
-- 9 Yara Bakým
(161,9,'Betadine','Antiseptik',150,20,'images/betadine.png'),
(162,9,'Oksijenli Su','Yara temizleme',60,30,'images/oksijenli.png'),

-- 10 Aðýz Bakým
(181,10,'Listerine','Aðýz gargarasý',120,20,'images/Listerine.jpg'),
(182,10,'Sensodyne','Hassas diþ macunu',140,15,'images/sensodyne.png');

-- =========================
-- HASTALIK -> ÜRÜN EÞLEÞME
-- (HastalikOneri)
-- =========================

-- Üst solunum / grip / nezle
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (21,22,23,26)
WHERE h.Ad IN ('Grip','Soðuk Algýnlýðý','Ateþ');

-- Öksürük / Bronþit
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (28,29,22)
WHERE h.Ad IN ('Öksürük','Bronþit');

-- Sinüzit / burun þikayetleri
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (25,27,123)
WHERE h.Ad IN ('Sinüzit','Burun Akýntýsý');

-- Aðrýlar
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (1,2,6,7)
WHERE h.Ad IN ('Baþ Aðrýsý','Diþ Aðrýsý');

-- Migren (daha güçlü aðrýlar)
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (3,4,5)
WHERE h.Ad IN ('Migren');

-- Kas/Eklem/Bel aðrýlarý
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (3,4,5,8)
WHERE h.Ad IN ('Kas Aðrýsý','Eklem Aðrýsý','Bel Aðrýsý');

-- Sindirim
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (61,62)
WHERE h.Ad IN ('Mide Yanmasý','Reflü','Gastrit');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (64)
WHERE h.Ad IN ('Ýshal','Gýda Zehirlenmesi');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (65)
WHERE h.Ad IN ('Kabýzlýk');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (62,61)
WHERE h.Ad IN ('Mide Bulantýsý');

-- Alerjik þikayetler
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (81,82,83,84)
WHERE h.Ad IN ('Alerji','Mevsimsel Alerji','Göz Kaþýntýsý');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (81,82,25)
WHERE h.Ad IN ('Burun Akýntýsý');

-- Vitamin / mineral
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (42,41,46)
WHERE h.Ad IN ('Vitamin Eksikliði','Baðýþýklýk Düþüklüðü');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (44)
WHERE h.Ad IN ('B12 Eksikliði');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (43)
WHERE h.Ad IN ('D Vitamini Eksikliði');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (45,143)
WHERE h.Ad IN ('Magnezyum Eksikliði','Yorgunluk','Halsizlik');

-- Cilt
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (101,103,105)
WHERE h.Ad IN ('Cilt Tahriþi','Kaþýntý');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (102,103)
WHERE h.Ad IN ('Egzama');

INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (104)
WHERE h.Ad IN ('Sivilce');

-- Uyku / stres
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.ProductId IN (141,142,143)
WHERE h.Ad IN ('Uykusuzluk','Stres');


CREATE TABLE IF NOT EXISTS Orders (
    OrderId INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    OrderDate TEXT,
    TotalPrice REAL,
    Address TEXT,
    PaymentType TEXT
);

CREATE TABLE IF NOT EXISTS OrderItems (
    OrderItemId INTEGER PRIMARY KEY AUTOINCREMENT,
    OrderId INTEGER,
    ProductId INTEGER,
    Quantity INTEGER,
    UnitPrice REAL
);

";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                }
                HastaliklariEkle(con);
                SeedHastalikVeOneriler(con);
            }
        }
           
        

        
        
        private void HastaliklariEkle(SQLiteConnection con)
        {
            string[] hastaliklar =
            {
        "Grip","Soðuk Algýnlýðý","Boðaz Aðrýsý","Öksürük","Ateþ","Sinüzit","Bronþit",
        "Baþ Aðrýsý","Migren","Kas Aðrýsý","Eklem Aðrýsý","Bel Aðrýsý","Diþ Aðrýsý",
        "Mide Bulantýsý","Mide Yanmasý","Reflü","Gastrit","Ýshal","Kabýzlýk","Gýda Zehirlenmesi",
        "Alerji","Mevsimsel Alerji","Burun Akýntýsý","Göz Kaþýntýsý",
        "Vitamin Eksikliði","Demir Eksikliði","B12 Eksikliði","D Vitamini Eksikliði","Magnezyum Eksikliði",
        "Sivilce","Egzama","Cilt Tahriþi","Kaþýntý",
        "Uykusuzluk","Stres","Yorgunluk","Halsizlik","Baðýþýklýk Düþüklüðü","Baþ Dönmesi"
    };

            using (var tr = con.BeginTransaction())
            using (var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Hastaliklar(Ad) VALUES (@ad);", con, tr))
            {
                var p = cmd.Parameters.Add("@ad", System.Data.DbType.String);

                foreach (var h in hastaliklar)
                {
                    p.Value = h;
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
            }
        }
            private void SeedHastalikVeOneriler(SQLiteConnection con)
        {
            using (var tr = con.BeginTransaction())
            {
                // 1) Hastalýklar (çok olsun)
                string[] hastaliklar =
                {
            "Grip","Soðuk Algýnlýðý","Boðaz Aðrýsý","Öksürük","Ateþ","Sinüzit","Bronþit",
            "Baþ Aðrýsý","Migren","Kas Aðrýsý","Eklem Aðrýsý","Bel Aðrýsý","Diþ Aðrýsý",
            "Mide Bulantýsý","Mide Yanmasý","Reflü","Gastrit","Ýshal","Kabýzlýk",
            "Alerji","Mevsimsel Alerji","Burun Akýntýsý","Göz Kaþýntýsý",
            "Vitamin Eksikliði","Demir Eksikliði","B12 Eksikliði","D Vitamini Eksikliði","Magnezyum Eksikliði",
            "Sivilce","Egzama","Cilt Tahriþi","Kaþýntý",
            "Uykusuzluk","Stres","Yorgunluk","Halsizlik","Baðýþýklýk Düþüklüðü","Baþ Dönmesi"
        };

                foreach (var h in hastaliklar)
                {
                    using var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Hastaliklar(Ad) VALUES (@ad);", con, tr);
                    cmd.Parameters.AddWithValue("@ad", h);
                    cmd.ExecuteNonQuery();
                }

               
                AddMap("Baþ Aðrýsý", "Parol");
                AddMap("Baþ Aðrýsý", "Minoset");
                AddMap("Soðuk Algýnlýðý", "Aferin");
                AddMap("Grip", "Theraflu");
                AddMap("Ateþ", "Parol");
                AddMap("Öksürük", "Bisolvon");
                AddMap("Sinüzit", "Otrivine");
                AddMap("Mide Yanmasý", "Rennie");
                AddMap("Reflü", "Gaviscon");
                AddMap("Alerji", "Zyrtec");
                AddMap("Uykusuzluk", "Melatonin");
                AddMap("Stres", "Passiflora");
                AddMap("Vitamin Eksikliði", "Supradyn");
                AddMap("Baðýþýklýk Düþüklüðü", "Redoxon");

                

                tr.Commit();

                void AddMap(string hastalikAdi, string urunAdiParca)
                {
                    using var cmd = new SQLiteCommand(@"
INSERT OR IGNORE INTO HastalikOneri(HastalikId, ProductId)
SELECT h.HastalikId, p.ProductId
FROM Hastaliklar h
JOIN Products p ON p.Name LIKE '%' || @p || '%'
WHERE h.Ad=@h;", con, tr);

                    cmd.Parameters.AddWithValue("@h", hastalikAdi);
                    cmd.Parameters.AddWithValue("@p", urunAdiParca);
                    cmd.ExecuteNonQuery();
                }

            }


        }

        public GirisFormu()
        {
            InitializeComponent();
            CreateDatabaseIfNotExists();
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            using (var frm = new KayitFormu())
            {
                frm.ShowDialog();
            }
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta = txtEposta.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrWhiteSpace(eposta) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("E-posta ve þifre boþ olamaz.", "Uyarý",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Users WHERE Email=@e AND Password=@p;", con))
                {
                    cmd.Parameters.AddWithValue("@e", eposta);
                    cmd.Parameters.AddWithValue("@p", sifre);

                    long sonuc = (long)cmd.ExecuteScalar();

                    if (sonuc > 0)
                    {
                        HastalikFormu hf = new HastalikFormu();
                        hf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalý e-posta veya þifre.", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void txtSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = !txtSifreGoster.Checked;
        }




    }
}

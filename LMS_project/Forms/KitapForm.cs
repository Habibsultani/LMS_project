using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using LMS_project.Database;

namespace LMS_project.Forms
{
    public partial class KitapForm : Form
    {
        private int _selectedKitapId = -1;

        public KitapForm()
        {
            InitializeComponent();

            this.Load += KitapForm_Load;
            dgvKitaplar.CellClick += dgvKitaplar_CellClick;

            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnTemizle.Click += btnTemizle_Click;
            btnKitabiAra.Click += btnKitabiAra_Click;
        }

        // =========================
        // FORM LOAD
        // =========================
        private void KitapForm_Load(object sender, EventArgs e)
        {
            LoadKategoriler();
            LoadKitaplar(); // ALL books first
            ClearForm();
        }

        // =========================
        // LOAD CATEGORIES
        // =========================
        private void LoadKategoriler()
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string q = "SELECT kategori_id, kategori_adi FROM kategori ORDER BY kategori_adi";
                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKategori.DataSource = dt;
                cmbKategori.DisplayMember = "kategori_adi";
                cmbKategori.ValueMember = "kategori_id";
                cmbKategori.SelectedIndex = -1;
            }
        }

        // =========================
        // LOAD BOOKS (WITH FILTER)
        // =========================
        private void LoadKitaplar(string kitapAdi = "", string yazarAdi = "")
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string query = @"
                    SELECT DISTINCT
                        k.kitab_id,
                        k.kitab_adi,
                        y.yazar_adi,
                        k.yayin_yili,
                        kat.kategori_adi,
                        k.toplam_kopyasi,
                        k.mevcut_adet
                    FROM kitaplar k
                    JOIN kitap_yazari ky ON ky.kitab_id = k.kitab_id
                    JOIN yazar y ON y.yazar_id = ky.yazar_id
                    JOIN kategori kat ON kat.kategori_id = k.kategori_id
                    WHERE 1=1
                ";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(kitapAdi))
                {
                    query += " AND k.kitab_adi LIKE @kitap";
                    cmd.Parameters.AddWithValue("@kitap", "%" + kitapAdi + "%");
                }

                if (!string.IsNullOrWhiteSpace(yazarAdi))
                {
                    query += " AND y.yazar_adi LIKE @yazar";
                    cmd.Parameters.AddWithValue("@yazar", "%" + yazarAdi + "%");
                }

                query += " ORDER BY k.kitab_id DESC";
                cmd.CommandText = query;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKitaplar.DataSource = dt;
            }
        }

        // =========================
        // SEARCH
        // =========================
        private void btnKitabiAra_Click(object sender, EventArgs e)
        {
            LoadKitaplar(
                txtAraKitapAdi.Text.Trim(),
                txtAraYazarAdi.Text.Trim()
            );
        }

        // =========================
        // GRID CLICK
        // =========================
        private void dgvKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvKitaplar.Rows[e.RowIndex];
            _selectedKitapId = Convert.ToInt32(row.Cells["kitab_id"].Value);

            txtKitapAdi.Text = row.Cells["kitab_adi"].Value.ToString();
            txtYazarAdi.Text = row.Cells["yazar_adi"].Value.ToString();
            txtYayinYili.Text = row.Cells["yayin_yili"].Value.ToString();
            txtToplamAdet.Text = row.Cells["toplam_kopyasi"].Value.ToString();
            txtMevcutAdet.Text = row.Cells["mevcut_adet"].Value.ToString();
            cmbKategori.Text = row.Cells["kategori_adi"].Value.ToString();
        }

        // =========================
        // ADD BOOK
        // =========================
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (MySqlConnection conn = DbConnection.GetConnection())
            using (MySqlTransaction tr = conn.BeginTransaction())
            {
                try
                {
                    int kategoriId = GetOrCreateKategori(cmbKategori.Text.Trim(), conn, tr);
                    int yazarId = GetOrCreateYazar(txtYazarAdi.Text.Trim(), conn, tr);

                    string qBook = @"
                        INSERT INTO kitaplar
                        (kitab_adi, yayin_yili, kategori_id, toplam_kopyasi, mevcut_adet)
                        VALUES (@adi, @yil, @kat, @toplam, @mevcut);
                        SELECT LAST_INSERT_ID();
                    ";

                    MySqlCommand cmdBook = new MySqlCommand(qBook, conn, tr);
                    cmdBook.Parameters.AddWithValue("@adi", txtKitapAdi.Text.Trim());
                    cmdBook.Parameters.AddWithValue("@yil", int.Parse(txtYayinYili.Text));
                    cmdBook.Parameters.AddWithValue("@kat", kategoriId);
                    cmdBook.Parameters.AddWithValue("@toplam", int.Parse(txtToplamAdet.Text));
                    cmdBook.Parameters.AddWithValue("@mevcut", int.Parse(txtToplamAdet.Text));

                    int kitapId = Convert.ToInt32(cmdBook.ExecuteScalar());

                    LinkBookAuthor(kitapId, yazarId, conn, tr);

                    tr.Commit();
                    MessageBox.Show("Kitap eklendi.");
                    LoadKategoriler();
                    LoadKitaplar();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Ekleme hatası: " + ex.Message);
                }
            }
        }

        // =========================
        // UPDATE BOOK
        // =========================
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedKitapId == -1)
            {
                MessageBox.Show("Güncellenecek kitap seçiniz.");
                return;
            }

            if (!ValidateInputs()) return;

            using (MySqlConnection conn = DbConnection.GetConnection())
            using (MySqlTransaction tr = conn.BeginTransaction())
            {
                try
                {
                    int kategoriId = GetOrCreateKategori(cmbKategori.Text.Trim(), conn, tr);
                    int yazarId = GetOrCreateYazar(txtYazarAdi.Text.Trim(), conn, tr);

                    string qUpdate = @"
                        UPDATE kitaplar
                        SET kitab_adi=@adi,
                            yayin_yili=@yil,
                            kategori_id=@kat,
                            toplam_kopyasi=@toplam,
                            mevcut_adet=@mevcut
                        WHERE kitab_id=@id;
                    ";

                    MySqlCommand cmd = new MySqlCommand(qUpdate, conn, tr);
                    cmd.Parameters.AddWithValue("@adi", txtKitapAdi.Text.Trim());
                    cmd.Parameters.AddWithValue("@yil", int.Parse(txtYayinYili.Text));
                    cmd.Parameters.AddWithValue("@kat", kategoriId);
                    cmd.Parameters.AddWithValue("@toplam", int.Parse(txtToplamAdet.Text));
                    cmd.Parameters.AddWithValue("@mevcut", int.Parse(txtMevcutAdet.Text));
                    cmd.Parameters.AddWithValue("@id", _selectedKitapId);
                    cmd.ExecuteNonQuery();

                    MySqlCommand del = new MySqlCommand(
                        "DELETE FROM kitap_yazari WHERE kitab_id=@id", conn, tr);
                    del.Parameters.AddWithValue("@id", _selectedKitapId);
                    del.ExecuteNonQuery();

                    LinkBookAuthor(_selectedKitapId, yazarId, conn, tr);

                    tr.Commit();
                    MessageBox.Show("Kitap güncellendi.");
                    LoadKategoriler();
                    LoadKitaplar();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
            }
        }

        // =========================
        // DELETE BOOK
        // =========================
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_selectedKitapId == -1)
            {
                MessageBox.Show("Silinecek kitap seçiniz.");
                return;
            }

            if (HasActiveLoan(_selectedKitapId))
            {
                MessageBox.Show("Bu kitabın aktif ödünç kaydı var. Silinemez.");
                return;
            }

            if (MessageBox.Show("Kitap silinsin mi?", "Onay",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = DbConnection.GetConnection())
            using (MySqlTransaction tr = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand c1 = new MySqlCommand(
                        "DELETE FROM kitap_yazari WHERE kitab_id=@id", conn, tr);
                    c1.Parameters.AddWithValue("@id", _selectedKitapId);
                    c1.ExecuteNonQuery();

                    MySqlCommand c2 = new MySqlCommand(
                        "DELETE FROM kitaplar WHERE kitab_id=@id", conn, tr);
                    c2.Parameters.AddWithValue("@id", _selectedKitapId);
                    c2.ExecuteNonQuery();

                    tr.Commit();
                    MessageBox.Show("Kitap silindi.");
                    LoadKitaplar();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Silme hatası: " + ex.Message);
                }
            }
        }

        // =========================
        // HELPERS
        // =========================
        private void LinkBookAuthor(int kitapId, int yazarId,
            MySqlConnection conn, MySqlTransaction tr)
        {
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO kitap_yazari (kitab_id, yazar_id) VALUES (@k,@y)",
                conn, tr);
            cmd.Parameters.AddWithValue("@k", kitapId);
            cmd.Parameters.AddWithValue("@y", yazarId);
            cmd.ExecuteNonQuery();
        }

        private int GetOrCreateKategori(string ad, MySqlConnection conn, MySqlTransaction tr)
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT kategori_id FROM kategori WHERE kategori_adi=@a",
                conn, tr);
            cmd.Parameters.AddWithValue("@a", ad);
            object r = cmd.ExecuteScalar();
            if (r != null) return Convert.ToInt32(r);

            cmd = new MySqlCommand(
                "INSERT INTO kategori(kategori_adi) VALUES(@a); SELECT LAST_INSERT_ID();",
                conn, tr);
            cmd.Parameters.AddWithValue("@a", ad);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int GetOrCreateYazar(string ad, MySqlConnection conn, MySqlTransaction tr)
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT yazar_id FROM yazar WHERE yazar_adi=@a",
                conn, tr);
            cmd.Parameters.AddWithValue("@a", ad);
            object r = cmd.ExecuteScalar();
            if (r != null) return Convert.ToInt32(r);

            cmd = new MySqlCommand(
                "INSERT INTO yazar(yazar_adi) VALUES(@a); SELECT LAST_INSERT_ID();",
                conn, tr);
            cmd.Parameters.AddWithValue("@a", ad);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private bool HasActiveLoan(int kitapId)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM odunc WHERE kitab_id=@id AND teslim_tarihi IS NULL",
                    conn);
                cmd.Parameters.AddWithValue("@id", kitapId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool ValidateInputs()
        {
            if (txtKitapAdi.Text == "" || txtYazarAdi.Text == "" ||
                txtYayinYili.Text == "" || txtToplamAdet.Text == "" ||
                cmbKategori.Text == "")
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            _selectedKitapId = -1;
            txtKitapAdi.Clear();
            txtYazarAdi.Clear();
            txtYayinYili.Clear();
            txtToplamAdet.Clear();
            txtMevcutAdet.Clear();
            cmbKategori.SelectedIndex = -1;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadKitaplar();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

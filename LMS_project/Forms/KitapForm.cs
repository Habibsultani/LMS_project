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
        }

        // -------------------------
        // FORM LOAD
        // -------------------------
        private void KitapForm_Load(object sender, EventArgs e)
        {
            LoadKategoriler();
            LoadKitaplar();
            ClearForm();
        }

        // -------------------------
        // LOAD CATEGORIES
        // -------------------------
        private void LoadKategoriler()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = "SELECT kategori_id, kategori_adi FROM kategori ORDER BY kategori_adi";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbKategori.DataSource = dt;
                    cmbKategori.DisplayMember = "kategori_adi";
                    cmbKategori.ValueMember = "kategori_id";
                    cmbKategori.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori yüklenemedi: " + ex.Message);
            }
        }

        // -------------------------
        // LOAD BOOKS
        // -------------------------
        private void LoadKitaplar()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            k.kitab_id,
                            k.kitab_adi,
                            k.yayin_yili,
                            kat.kategori_adi,
                            k.toplam_kopyasi,
                            k.mevcut_adet
                        FROM kitaplar k
                        JOIN kategori kat ON kat.kategori_id = k.kategori_id
                        ORDER BY k.kitab_id DESC;
                    ";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKitaplar.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar yüklenemedi: " + ex.Message);
            }
        }

        // -------------------------
        // GRID CLICK
        // -------------------------
        private void dgvKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKitaplar.Rows[e.RowIndex];

            _selectedKitapId = Convert.ToInt32(row.Cells["kitab_id"].Value);

            txtKitapAdi.Text = row.Cells["kitab_adi"].Value.ToString();
            txtYayinYili.Text = row.Cells["yayin_yili"].Value.ToString();
            txtToplamAdet.Text = row.Cells["toplam_kopyasi"].Value.ToString();
            txtMevcutAdet.Text = row.Cells["mevcut_adet"].Value.ToString();

            cmbKategori.Text = row.Cells["kategori_adi"].Value.ToString();
        }

        // -------------------------
        // ADD BOOK
        // -------------------------
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        INSERT INTO kitaplar 
                        (kitab_adi, yayin_yili, kategori_id, toplam_kopyasi, mevcut_adet)
                        VALUES
                        (@adi, @yil, @kategori, @toplam, @mevcut);
                    ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@adi", txtKitapAdi.Text.Trim());
                    cmd.Parameters.AddWithValue("@yil", int.Parse(txtYayinYili.Text));
                    cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@toplam", int.Parse(txtToplamAdet.Text));
                    cmd.Parameters.AddWithValue("@mevcut", int.Parse(txtToplamAdet.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Kitap eklendi.");
                LoadKitaplar();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
        }

        // -------------------------
        // UPDATE BOOK
        // -------------------------
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedKitapId == -1)
            {
                MessageBox.Show("Güncellenecek kitap seçiniz.");
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        UPDATE kitaplar
                        SET kitab_adi=@adi,
                            yayin_yili=@yil,
                            kategori_id=@kategori,
                            toplam_kopyasi=@toplam,
                            mevcut_adet=@mevcut
                        WHERE kitab_id=@id;
                    ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@adi", txtKitapAdi.Text.Trim());
                    cmd.Parameters.AddWithValue("@yil", int.Parse(txtYayinYili.Text));
                    cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@toplam", int.Parse(txtToplamAdet.Text));
                    cmd.Parameters.AddWithValue("@mevcut", int.Parse(txtMevcutAdet.Text));
                    cmd.Parameters.AddWithValue("@id", _selectedKitapId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Kitap güncellendi.");
                LoadKitaplar();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        // -------------------------
        // DELETE BOOK (BLOCK IF LOAN EXISTS)
        // -------------------------
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

            if (MessageBox.Show("Kitap silinsin mi?", "Onay", MessageBoxButtons.YesNo)
                != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = "DELETE FROM kitaplar WHERE kitab_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _selectedKitapId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Kitap silindi.");
                LoadKitaplar();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message);
            }
        }

        // -------------------------
        // HELPERS
        // -------------------------
        private bool HasActiveLoan(int kitapId)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string q = @"SELECT COUNT(*) FROM odunc 
                             WHERE kitab_id=@id AND teslim_tarihi IS NULL";
                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", kitapId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool ValidateInputs()
        {
            if (txtKitapAdi.Text == "" ||
                txtYayinYili.Text == "" ||
                txtToplamAdet.Text == "" ||
                cmbKategori.SelectedIndex == -1)
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
            txtYayinYili.Clear();
            txtToplamAdet.Clear();
            txtMevcutAdet.Clear();
            cmbKategori.SelectedIndex = -1;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

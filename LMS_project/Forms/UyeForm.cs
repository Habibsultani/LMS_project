using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using LMS_project.Database;

namespace LMS_project.Forms
{
    public partial class UyeForm : Form
    {
        private int _selectedOgrenciId = -1;

        public UyeForm()
        {
            InitializeComponent();

            // Event hookups (in case you didn't bind in Designer)
            this.Load += UyeForm_Load;
            dgvUyeler.CellClick += dgvUyeler_CellClick;

            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnTemizle.Click += btnTemizle_Click;
        }

        // -------------------------
        // FORM LOAD: Fill DataGrid
        // -------------------------
        private void UyeForm_Load(object sender, EventArgs e)
        {
            LoadUyeler();
            ClearInputs();
        }

        // -------------------------
        // LOAD MEMBERS INTO GRID
        // -------------------------
        private void LoadUyeler()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            ogrenci_id,
                            ogrenci_num,
                            ad_soyadi,
                            e_posta,
                            telefon,
                            toplam_borc,
                            is_active
                        FROM ogrenci_uyeler
                        ORDER BY ogrenci_id DESC;
                    ";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUyeler.DataSource = dt;

                    // Optional: nicer headers
                    if (dgvUyeler.Columns["ogrenci_id"] != null)
                        dgvUyeler.Columns["ogrenci_id"].HeaderText = "ID";

                    if (dgvUyeler.Columns["ogrenci_num"] != null)
                        dgvUyeler.Columns["ogrenci_num"].HeaderText = "Öğrenci No";

                    if (dgvUyeler.Columns["ad_soyadi"] != null)
                        dgvUyeler.Columns["ad_soyadi"].HeaderText = "Ad Soyad";

                    if (dgvUyeler.Columns["e_posta"] != null)
                        dgvUyeler.Columns["e_posta"].HeaderText = "E-Posta";

                    if (dgvUyeler.Columns["telefon"] != null)
                        dgvUyeler.Columns["telefon"].HeaderText = "Telefon";

                    if (dgvUyeler.Columns["toplam_borc"] != null)
                        dgvUyeler.Columns["toplam_borc"].HeaderText = "Toplam Borç";

                    if (dgvUyeler.Columns["is_active"] != null)
                        dgvUyeler.Columns["is_active"].HeaderText = "Aktif mi?";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üyeler yüklenemedi: " + ex.Message);
            }
        }

        // -------------------------
        // GRID CLICK -> FILL INPUTS
        // -------------------------
        private void dgvUyeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header click

            DataGridViewRow row = dgvUyeler.Rows[e.RowIndex];

            _selectedOgrenciId = Convert.ToInt32(row.Cells["ogrenci_id"].Value);

            txtOgrenciNo.Text = row.Cells["ogrenci_num"].Value?.ToString();
            txtAdSoyad.Text = row.Cells["ad_soyadi"].Value?.ToString();
            txtEmail.Text = row.Cells["e_posta"].Value?.ToString();
            txtTelefon.Text = row.Cells["telefon"].Value?.ToString();
        }

        // -------------------------
        // ADD MEMBER
        // -------------------------
        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ogrNo = txtOgrenciNo.Text.Trim();
            string adSoyad = txtAdSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tel = txtTelefon.Text.Trim();

            if (string.IsNullOrWhiteSpace(ogrNo) || string.IsNullOrWhiteSpace(adSoyad))
            {
                MessageBox.Show("Öğrenci No ve Ad Soyad zorunludur.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        INSERT INTO ogrenci_uyeler (ogrenci_num, ad_soyadi, e_posta, telefon, toplam_borc, is_active)
                        VALUES (@no, @ad, NULLIF(@mail,''), NULLIF(@tel,''), 0, 1);
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", ogrNo);
                        cmd.Parameters.AddWithValue("@ad", adSoyad);
                        cmd.Parameters.AddWithValue("@mail", email);
                        cmd.Parameters.AddWithValue("@tel", tel);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Üye başarıyla eklendi.");
                LoadUyeler();
                ClearInputs();
            }
            catch (MySqlException ex)
            {
                // Common: duplicate ogrenci_num or email unique
                MessageBox.Show("Ekleme hatası (Unique olabilir): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
        }

        // -------------------------
        // UPDATE MEMBER
        // -------------------------
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedOgrenciId == -1)
            {
                MessageBox.Show("Lütfen güncellemek için tablodan bir üye seçin.");
                return;
            }

            string ogrNo = txtOgrenciNo.Text.Trim();
            string adSoyad = txtAdSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tel = txtTelefon.Text.Trim();

            if (string.IsNullOrWhiteSpace(ogrNo) || string.IsNullOrWhiteSpace(adSoyad))
            {
                MessageBox.Show("Öğrenci No ve Ad Soyad zorunludur.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        UPDATE ogrenci_uyeler
                        SET 
                            ogrenci_num = @no,
                            ad_soyadi = @ad,
                            e_posta = NULLIF(@mail,''),
                            telefon = NULLIF(@tel,'')
                        WHERE ogrenci_id = @id;
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", ogrNo);
                        cmd.Parameters.AddWithValue("@ad", adSoyad);
                        cmd.Parameters.AddWithValue("@mail", email);
                        cmd.Parameters.AddWithValue("@tel", tel);
                        cmd.Parameters.AddWithValue("@id", _selectedOgrenciId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Üye başarıyla güncellendi.");
                LoadUyeler();
                ClearInputs();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Güncelleme hatası (Unique olabilir): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        // -------------------------
        // DELETE MEMBER (BLOCK IF ACTIVE LOAN EXISTS)
        // -------------------------
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_selectedOgrenciId == -1)
            {
                MessageBox.Show("Lütfen silmek için tablodan bir üye seçin.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Seçili üyeyi silmek istediğine emin misin?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr != DialogResult.Yes) return;

            try
            {
                // 1) Check active loan
                if (HasActiveLoan(_selectedOgrenciId))
                {
                    MessageBox.Show("Bu üyenin aktif ödünç kaydı var (teslim edilmemiş). Silinemez!");
                    return;
                }

                // 2) Delete
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"DELETE FROM ogrenci_uyeler WHERE ogrenci_id = @id;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _selectedOgrenciId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Üye silindi.");
                LoadUyeler();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message);
            }
        }

        private bool HasActiveLoan(int ogrenciId)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT COUNT(*)
                        FROM odunc
                        WHERE ogrenci_id = @id
                          AND teslim_tarihi IS NULL;
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ogrenciId);
                        object result = cmd.ExecuteScalar();
                        int count = Convert.ToInt32(result);
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aktif ödünç kontrol hatası: " + ex.Message);
                return true; // safest: block delete if unsure
            }
        }

        // -------------------------
        // CLEAR INPUTS
        // -------------------------
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ClearInputs()
        {
            _selectedOgrenciId = -1;

            txtOgrenciNo.Clear();
            txtAdSoyad.Clear();
            txtEmail.Clear();
            txtTelefon.Clear();

            txtOgrenciNo.Focus();
        }
    }
}

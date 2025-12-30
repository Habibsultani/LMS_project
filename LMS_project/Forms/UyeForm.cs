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

            // Safety event bindings
            this.Load += UyeForm_Load;
            dgvUyeler.CellClick += dgvUyeler_CellClick;

            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnTemizle.Click += btnTemizle_Click;
            btnOgrenciAra.Click += btnOgrenciAra_Click;
        }

        // =========================
        // FORM LOAD → LIST ALL
        // =========================
        private void UyeForm_Load(object sender, EventArgs e)
        {
            LoadUyeler();      // 🔥 ALL students
            ClearInputs();
        }

        // =========================
        // LOAD STUDENTS (OPTIONAL FILTER)
        // =========================
        private void LoadUyeler(string whereClause = "", MySqlParameter[] parameters = null)
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
                        WHERE 1=1 " + whereClause + @"
                        ORDER BY ogrenci_id DESC;
                    ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUyeler.DataSource = dt;

                    // Column titles (optional polish)
                    dgvUyeler.Columns["ogrenci_id"].HeaderText = "ID";
                    dgvUyeler.Columns["ogrenci_num"].HeaderText = "Öğrenci No";
                    dgvUyeler.Columns["ad_soyadi"].HeaderText = "Ad Soyad";
                    dgvUyeler.Columns["e_posta"].HeaderText = "E-Posta";
                    dgvUyeler.Columns["telefon"].HeaderText = "Telefon";
                    dgvUyeler.Columns["toplam_borc"].HeaderText = "Toplam Borç";
                    dgvUyeler.Columns["is_active"].HeaderText = "Aktif";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üyeler yüklenemedi: " + ex.Message);
            }
        }

        // =========================
        // SEARCH STUDENT
        // =========================
        private void btnOgrenciAra_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAraAdSoyad.Text.Trim();
            string email = txtAraEmail.Text.Trim();

            // 🔴 If nothing entered → show all again
            if (string.IsNullOrWhiteSpace(adSoyad) && string.IsNullOrWhiteSpace(email))
            {
                LoadUyeler();
                return;
            }

            string where = "";
            var parameters = new System.Collections.Generic.List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(adSoyad))
            {
                where += " AND ad_soyadi LIKE @ad";
                parameters.Add(new MySqlParameter("@ad", "%" + adSoyad + "%"));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                where += " AND e_posta LIKE @mail";
                parameters.Add(new MySqlParameter("@mail", "%" + email + "%"));
            }

            LoadUyeler(where, parameters.ToArray());
        }

        // =========================
        // GRID CLICK → FILL INPUTS
        // =========================
        private void dgvUyeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUyeler.Rows[e.RowIndex];

            _selectedOgrenciId = Convert.ToInt32(row.Cells["ogrenci_id"].Value);

            txtOgrenciNo.Text = row.Cells["ogrenci_num"].Value?.ToString();
            txtAdSoyad.Text = row.Cells["ad_soyadi"].Value?.ToString();
            txtEmail.Text = row.Cells["e_posta"].Value?.ToString();
            txtTelefon.Text = row.Cells["telefon"].Value?.ToString();
        }

        // =========================
        // ADD STUDENT
        // =========================
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOgrenciNo.Text) ||
                string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Öğrenci No ve Ad Soyad zorunludur.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string q = @"
                        INSERT INTO ogrenci_uyeler
                        (ogrenci_num, ad_soyadi, e_posta, telefon, toplam_borc, is_active)
                        VALUES (@no, @ad, NULLIF(@mail,''), NULLIF(@tel,''), 0, 1);
                    ";

                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@no", txtOgrenciNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@tel", txtTelefon.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Üye eklendi.");
                LoadUyeler();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
        }

        // =========================
        // UPDATE STUDENT
        // =========================
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedOgrenciId == -1)
            {
                MessageBox.Show("Güncellemek için üye seçin.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string q = @"
                        UPDATE ogrenci_uyeler
                        SET 
                            ogrenci_num = @no,
                            ad_soyadi = @ad,
                            e_posta = NULLIF(@mail,''),
                            telefon = NULLIF(@tel,'')
                        WHERE ogrenci_id = @id;
                    ";

                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@no", txtOgrenciNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@tel", txtTelefon.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", _selectedOgrenciId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Üye güncellendi.");
                LoadUyeler();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        // =========================
        // DELETE STUDENT
        // =========================
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_selectedOgrenciId == -1)
            {
                MessageBox.Show("Silmek için üye seçin.");
                return;
            }

            if (HasActiveLoan(_selectedOgrenciId))
            {
                MessageBox.Show("Aktif ödünç var. Silinemez!");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string q = "DELETE FROM ogrenci_uyeler WHERE ogrenci_id = @id";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@id", _selectedOgrenciId);
                    cmd.ExecuteNonQuery();
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

        // =========================
        // ACTIVE LOAN CHECK
        // =========================
        private bool HasActiveLoan(int ogrenciId)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string q = @"
                    SELECT COUNT(*)
                    FROM odunc
                    WHERE ogrenci_id = @id
                      AND teslim_tarihi IS NULL;
                ";

                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", ogrenciId);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // =========================
        // CLEAR INPUTS
        // =========================
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtAraAdSoyad.Clear();
            txtAraEmail.Clear();
            LoadUyeler(); // 🔥 BACK TO ALL
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

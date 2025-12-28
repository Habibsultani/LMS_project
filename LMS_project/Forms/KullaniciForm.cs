using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using LMS_project.Database;

namespace LMS_project.Forms
{
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            InitializeComponent();
        }

        // -------------------------
        // ADD NEW USER (ADMIN ONLY)
        // -------------------------
        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (txtUsername.Text.Trim() == "" ||
                txtAdSoyad.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.");
                return;
            }

            // Role mapping
            int rolId = cmbRol.SelectedItem.ToString() == "Admin" ? 1 : 2;

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        INSERT INTO kullanici_tablo 
                        (kullanici_adi, ad_soyad, sifre, rol_id)
                        VALUES 
                        (@username, @adSoyad, SHA2(@password, 256), @rolId);
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@rolId", rolId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kullanıcı başarıyla eklendi.");
                ClearForm();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // -------------------------
        // CLEAR FORM
        // -------------------------
        private void ClearForm()
        {
            txtUsername.Clear();
            txtAdSoyad.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = -1;

            txtUsername.Focus();
        }


        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtAdSoyad.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = -1;

            txtUsername.Focus();
        }
        // -------------------------
        // BACK TO MAIN FORM
        // -------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

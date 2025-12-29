using LMS_project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LMS_project.Forms
{
    public partial class OduncForm : Form
    {
        // STATE VARIABLES
        private int _selectedOgrenciId = -1;
        private int _selectedKitapId = -1;
        private int _selectedOduncId = -1;
        private int _kullaniciId;

        public OduncForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
        }

        // STEP 1 — STUDENT CHECK
        private void btnCheckOgrenci_Click(object sender, EventArgs e)
        {
            if (txtOgrenciNo.Text.Trim() == "")
            {
                MessageBox.Show("Öğrenci numarası giriniz.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT ogrenci_id, is_active
                        FROM ogrenci_uyeler
                        WHERE ogrenci_num = @ogrenciNo
                    ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ogrenciNo", txtOgrenciNo.Text.Trim());

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "Öğrenci bulunamadı.\nÖnce öğrenci ekleyiniz.",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        if (!reader.GetBoolean("is_active"))
                        {
                            MessageBox.Show(
                                "Öğrenci pasif durumda.\nÖdünç verilemez.",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        _selectedOgrenciId = reader.GetInt32("ogrenci_id");

                        MessageBox.Show(
                            "Öğrenci doğrulandı.",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        txtKitapId.Enabled = true;
                        btnCheckKitap.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // STEP 2 — BOOK CHECK
        private void btnCheckKitap_Click(object sender, EventArgs e)
        {
            if (_selectedOgrenciId == -1)
            {
                MessageBox.Show("Önce öğrenci doğrulaması yapmalısınız.");
                return;
            }

            if (txtKitapId.Text.Trim() == "")
            {
                MessageBox.Show("Kitap ID giriniz.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT kitab_id, mevcut_adet
                        FROM kitaplar
                        WHERE kitab_id = @kitapId
                    ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kitapId", txtKitapId.Text.Trim());

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Kitap bulunamadı.");
                            return;
                        }

                        if (reader.GetInt32("mevcut_adet") <= 0)
                        {
                            MessageBox.Show("Kitap stokta yok.");
                            return;
                        }

                        _selectedKitapId = reader.GetInt32("kitab_id");

                        MessageBox.Show(
                            "Kitap uygun. Ödünç verilebilir.",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        btnOduncVer.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // STEP 3 — LOAN (SP)
        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_YeniOduncVer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_ogrenci_id", _selectedOgrenciId);
                    cmd.Parameters.AddWithValue("@p_kitab_id", _selectedKitapId);
                    cmd.Parameters.AddWithValue("@p_kullanici_id", _kullaniciId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Ödünç verme işlemi başarıyla tamamlandı.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ResetOduncVerForm();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Veritabanı Uyarısı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void ResetOduncVerForm()
        {
            _selectedOgrenciId = -1;
            _selectedKitapId = -1;

            txtOgrenciNo.Clear();
            txtKitapId.Clear();

            txtKitapId.Enabled = false;
            btnCheckKitap.Enabled = false;
            btnOduncVer.Enabled = false;

            txtOgrenciNo.Focus();
        }
    }
}

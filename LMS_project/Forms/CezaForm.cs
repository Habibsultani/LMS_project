using LMS_project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LMS_project.Forms
{

    public partial class CezaForm : Form
    {
        private int _selectedOgrenciId = -1;

        public CezaForm()
        {
            InitializeComponent();
        }

        private void CezaForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                SELECT ogrenci_id, ad_soyadi
                FROM ogrenci_uyeler
                ORDER BY ad_soyadi
            ";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbOgrenci.DisplayMember = "ad_soyadi";
                    cmbOgrenci.ValueMember = "ogrenci_id";
                    cmbOgrenci.DataSource = dt;
                    cmbOgrenci.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenciler yüklenemedi: " + ex.Message);
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
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
                    // 1️⃣ Öğrenciyi bul
                    string ogrQuery = @"
                SELECT ogrenci_id
                FROM ogrenci_uyeler
                WHERE ogrenci_num = @no
            ";

                    MySqlCommand ogrCmd = new MySqlCommand(ogrQuery, conn);
                    ogrCmd.Parameters.AddWithValue("@no", txtOgrenciNo.Text.Trim());

                    object ogrIdObj = ogrCmd.ExecuteScalar();

                    if (ogrIdObj == null)
                    {
                        MessageBox.Show("Öğrenci bulunamadı.");
                        return;
                    }

                    _selectedOgrenciId = Convert.ToInt32(ogrIdObj);

                    // 2️⃣ Cezaları getir
                    string cezaQuery = @"
                SELECT
                    c.ceza_id,
                    k.kitab_adi,
                    c.ceza_tutari,
                    c.ceza_tarihi,
                    c.aciklama
                FROM ceza c
                JOIN odunc o ON c.odunc_id = o.odunc_id
                JOIN kitaplar k ON o.kitab_id = k.kitab_id
                WHERE o.ogrenci_id = @ogrId
                  AND c.ceza_tarihi BETWEEN @bas AND @bit
                ORDER BY c.ceza_tarihi
            ";

                    MySqlCommand cezaCmd = new MySqlCommand(cezaQuery, conn);
                    cezaCmd.Parameters.AddWithValue("@ogrId", _selectedOgrenciId);
                    cezaCmd.Parameters.AddWithValue("@bas", dtBaslangic.Value.Date);
                    cezaCmd.Parameters.AddWithValue("@bit", dtBitis.Value.Date);

                    MySqlDataAdapter da = new MySqlDataAdapter(cezaCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCezalar.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Bu öğrenciye ait ceza bulunamadı.");
                    }
                }

                LoadToplamBorc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void LoadToplamBorc()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                SELECT toplam_borc
                FROM ogrenci_uyeler
                WHERE ogrenci_id = @id
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _selectedOgrenciId);

                    object result = cmd.ExecuteScalar();

                    decimal borc = result != null ? Convert.ToDecimal(result) : 0;
                    lblToplamBorc.Text = $"Toplam Borç: {borc:0.00} TL";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplam borç alınamadı: " + ex.Message);
            }
        }




    }
}

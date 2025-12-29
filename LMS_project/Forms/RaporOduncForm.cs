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
    public partial class RaporOduncForm : Form
    {
        public RaporOduncForm()
        {
            InitializeComponent();
        }

        private void btnRaporGetir_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                SELECT
                    o.odunc_id,
                    og.ad_soyadi      AS ogrenci,
                    k.kitab_adi       AS kitap,
                    o.odunc_tarihi,
                    o.son_teslim_tarihi,
                    o.teslim_tarihi,
                    CASE
                        WHEN o.teslim_tarihi IS NULL THEN 'Aktif'
                        ELSE 'Teslim Edildi'
                    END AS durum
                FROM odunc o
                JOIN ogrenci_uyeler og ON o.ogrenci_id = og.ogrenci_id
                JOIN kitaplar k ON o.kitab_id = k.kitab_id
                WHERE o.odunc_tarihi BETWEEN @bas AND @bit
                ORDER BY o.odunc_tarihi
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bas", dtBaslangic.Value.Date);
                    cmd.Parameters.AddWithValue("@bit", dtBitis.Value.Date);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRapor.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Bu tarih aralığında kayıt bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor alınamadı: " + ex.Message);
            }
        }

    }
}

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
    public partial class RaporGecikenKitaplarForm : Form
    {
        public RaporGecikenKitaplarForm()
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
                    og.ad_soyadi AS ogrenci,
                    k.kitab_adi  AS kitap,
                    o.odunc_tarihi,
                    o.son_teslim_tarihi,
                    DATEDIFF(@bugun, o.son_teslim_tarihi) AS gecikme_gunu
                FROM odunc o
                JOIN ogrenci_uyeler og ON o.ogrenci_id = og.ogrenci_id
                JOIN kitaplar k ON o.kitab_id = k.kitab_id
                WHERE o.teslim_tarihi IS NULL
                  AND o.son_teslim_tarihi < @bugun
                ORDER BY gecikme_gunu DESC
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bugun", dtBugun.Value.Date);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRapor.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Geciken kitap bulunamadı.");
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

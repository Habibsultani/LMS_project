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
    public partial class RaporEnCokOduncForm : Form
    {
        public RaporEnCokOduncForm()
        {
            InitializeComponent();
        }

        private void btnRaporGetir_Click(object sender, EventArgs e)
        {
            if (dtBaslangic.Value.Date > dtBitis.Value.Date)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT
                            k.kitab_adi,
                            COUNT(o.odunc_id) AS odunc_sayisi
                            FROM odunc o
                                JOIN kitaplar k ON o.kitab_id = k.kitab_id
                                    WHERE o.odunc_tarihi BETWEEN @bas AND @bit
                                        GROUP BY k.kitab_id, k.kitab_adi
                                            ORDER BY odunc_sayisi DESC
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
                        MessageBox.Show("Bu tarih aralığında ödünç kaydı yok.");
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

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
    public partial class DinamikSorguForm : Form
    {
        public DinamikSorguForm()
        {
            InitializeComponent();
        }

        private void DinamikSorguForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string q = "SELECT kategori_id, kategori_adi FROM kategori";
                    MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    MessageBox.Show("Kategori sayısı: " + dt.Rows.Count); // DEBUG

                    cmbKategori.DataSource = null;
                    cmbKategori.DisplayMember = null;
                    cmbKategori.ValueMember = null;

                    cmbKategori.DataSource = dt;
                    cmbKategori.DisplayMember = "kategori_adi";
                    cmbKategori.ValueMember = "kategori_id";

                    cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbKategori.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori yüklenemedi: " + ex.Message);
            }
        }


        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                SELECT DISTINCT
                    k.kitab_id,
                    k.kitab_adi,
                    y.yazar_adi,
                    k.yayin_yili,
                    k.mevcut_adet
                FROM kitaplar k
                JOIN kitap_yazari ky ON k.kitab_id = ky.kitab_id
                JOIN yazar y ON ky.yazar_id = y.yazar_id
                WHERE 1=1
            ";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    // 🔹 Kitap adı
                    if (!string.IsNullOrWhiteSpace(txtKitapAdi.Text))
                    {
                        query += " AND k.kitab_adi LIKE @kitapAdi";
                        cmd.Parameters.AddWithValue("@kitapAdi", "%" + txtKitapAdi.Text.Trim() + "%");
                    }

                    // 🔹 Yazar adı
                    if (!string.IsNullOrWhiteSpace(txtYazarAdi.Text))
                    {
                        query += " AND y.yazar_adi LIKE @yazarAdi";
                        cmd.Parameters.AddWithValue("@yazarAdi", "%" + txtYazarAdi.Text.Trim() + "%");
                    }

                    // 🔹 Kategori
                    if (cmbKategori.SelectedIndex != -1)
                    {
                        query += " AND k.kategori_id = @kategoriId";
                        cmd.Parameters.AddWithValue("@kategoriId", cmbKategori.SelectedValue);
                    }

                    // 🔹 Basım yılı min
                    if (numBasimYilMin.Value > 0)
                    {
                        query += " AND k.yayin_yili >= @minYil";
                        cmd.Parameters.AddWithValue("@minYil", numBasimYilMin.Value);
                    }

                    // 🔹 Basım yılı max
                    if (numBasimYilMax.Value > 0)
                    {
                        query += " AND k.yayin_yili <= @maxYil";
                        cmd.Parameters.AddWithValue("@maxYil", numBasimYilMax.Value);
                    }

                    // 🔹 Sadece mevcut kitaplar
                    if (chkSadeceMevcut.Checked)
                    {
                        query += " AND k.mevcut_adet > 0";
                    }

                    cmd.CommandText = query;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSonuc.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dinamik sorgu hatası: " + ex.Message);
            }
        }


    }
}

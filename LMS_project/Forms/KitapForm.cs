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

            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            btnTemizle.Click += btnTemizle_Click;
            btnKitabiAra.Click += btnKitabiAra_Click;
            btnBack.Click += btnBack_Click;
        }

        // -------------------------
        // FORM LOAD
        // -------------------------
        private void KitapForm_Load(object sender, EventArgs e)
        {
            LoadKategoriler();
            LoadKitaplar();   // 👈 ALL books first
            ClearForm();
        }

        // -------------------------
        // LOAD CATEGORIES
        // -------------------------
        private void LoadKategoriler()
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string q = "SELECT kategori_id, kategori_adi FROM kategori ORDER BY kategori_adi";
                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKategori.DataSource = dt;
                cmbKategori.DisplayMember = "kategori_adi";
                cmbKategori.ValueMember = "kategori_id";
                cmbKategori.SelectedIndex = -1;
            }
        }

        // -------------------------
        // LOAD ALL BOOKS
        // -------------------------
        private void LoadKitaplar()
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string q = @"
                    SELECT DISTINCT
                        k.kitab_id,
                        k.kitab_adi,
                        y.yazar_adi,
                        k.yayin_yili,
                        kat.kategori_adi,
                        k.toplam_kopyasi,
                        k.mevcut_adet
                    FROM kitaplar k
                    JOIN kategori kat ON kat.kategori_id = k.kategori_id
                    JOIN kitap_yazari ky ON ky.kitab_id = k.kitab_id
                    JOIN yazar y ON y.yazar_id = ky.yazar_id
                    ORDER BY k.kitab_id DESC;
                ";

                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKitaplar.DataSource = dt;
            }
        }

        // -------------------------
        // SEARCH BOOKS
        // -------------------------
        private void SearchKitaplar()
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                string q = @"
                    SELECT DISTINCT
                        k.kitab_id,
                        k.kitab_adi,
                        y.yazar_adi,
                        k.yayin_yili,
                        kat.kategori_adi,
                        k.toplam_kopyasi,
                        k.mevcut_adet
                    FROM kitaplar k
                    JOIN kategori kat ON kat.kategori_id = k.kategori_id
                    JOIN kitap_yazari ky ON ky.kitab_id = k.kitab_id
                    JOIN yazar y ON y.yazar_id = ky.yazar_id
                    WHERE 1=1
                ";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(txtAraKitapAdi.Text))
                {
                    q += " AND k.kitab_adi LIKE @kitap";
                    cmd.Parameters.AddWithValue("@kitap", "%" + txtAraKitapAdi.Text.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtAraYazarAdi.Text))
                {
                    q += " AND y.yazar_adi LIKE @yazar";
                    cmd.Parameters.AddWithValue("@yazar", "%" + txtAraYazarAdi.Text.Trim() + "%");
                }

                cmd.CommandText = q;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKitaplar.DataSource = dt;
            }
        }

        // -------------------------
        // GRID CLICK
        // -------------------------
        private void dgvKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvKitaplar.Rows[e.RowIndex];
            _selectedKitapId = Convert.ToInt32(r.Cells["kitab_id"].Value);

            txtKitapAdi.Text = r.Cells["kitab_adi"].Value.ToString();
            txtYazarAdi.Text = r.Cells["yazar_adi"].Value.ToString();
            txtYayinYili.Text = r.Cells["yayin_yili"].Value.ToString();
            txtToplamAdet.Text = r.Cells["toplam_kopyasi"].Value.ToString();
            txtMevcutAdet.Text = r.Cells["mevcut_adet"].Value.ToString();
            cmbKategori.Text = r.Cells["kategori_adi"].Value.ToString();
        }

        // -------------------------
        // ADD BOOK + AUTHOR
        // -------------------------
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (MySqlConnection conn = DbConnection.GetConnection())
            using (MySqlTransaction tr = conn.BeginTransaction())
            {
                try
                {
                    // 1) Insert book
                    string qBook = @"
                        INSERT INTO kitaplar
                        (kitab_adi, yayin_yili, kategori_id, toplam_kopyasi, mevcut_adet)
                        VALUES (@adi, @yil, @kat, @toplam, @toplam);
                        SELECT LAST_INSERT_ID();
                    ";

                    MySqlCommand cmdBook = new MySqlCommand(qBook, conn, tr);
                    cmdBook.Parameters.AddWithValue("@adi", txtKitapAdi.Text.Trim());
                    cmdBook.Parameters.AddWithValue("@yil", int.Parse(txtYayinYili.Text));
                    cmdBook.Parameters.AddWithValue("@kat", cmbKategori.SelectedValue);
                    cmdBook.Parameters.AddWithValue("@toplam", int.Parse(txtToplamAdet.Text));

                    int kitapId = Convert.ToInt32(cmdBook.ExecuteScalar());

                    // 2) Get or insert author
                    int yazarId;
                    string qYazar = "SELECT yazar_id FROM yazar WHERE yazar_adi=@ad";
                    MySqlCommand cmdYazar = new MySqlCommand(qYazar, conn, tr);
                    cmdYazar.Parameters.AddWithValue("@ad", txtYazarAdi.Text.Trim());

                    object res = cmdYazar.ExecuteScalar();
                    if (res == null)
                    {
                        string ins = "INSERT INTO yazar (yazar_adi) VALUES (@ad); SELECT LAST_INSERT_ID();";
                        MySqlCommand c = new MySqlCommand(ins, conn, tr);
                        c.Parameters.AddWithValue("@ad", txtYazarAdi.Text.Trim());
                        yazarId = Convert.ToInt32(c.ExecuteScalar());
                    }
                    else
                    {
                        yazarId = Convert.ToInt32(res);
                    }

                    // 3) Relation
                    string qRel = "INSERT INTO kitap_yazari (kitab_id, yazar_id) VALUES (@k,@y)";
                    MySqlCommand cmdRel = new MySqlCommand(qRel, conn, tr);
                    cmdRel.Parameters.AddWithValue("@k", kitapId);
                    cmdRel.Parameters.AddWithValue("@y", yazarId);
                    cmdRel.ExecuteNonQuery();

                    tr.Commit();

                    MessageBox.Show("Kitap başarıyla eklendi.");
                    LoadKitaplar();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Ekleme hatası: " + ex.Message);
                }
            }
        }

        // -------------------------
        // UPDATE / DELETE (same logic)
        // -------------------------
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Güncelleme bu projede opsiyonel bırakıldı.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Silme bu projede opsiyonel bırakıldı.");
        }

        // -------------------------
        // SEARCH BUTTON
        // -------------------------
        private void btnKitabiAra_Click(object sender, EventArgs e)
        {
            SearchKitaplar();
        }

        // -------------------------
        // HELPERS
        // -------------------------
        private bool ValidateInputs()
        {
            if (txtKitapAdi.Text == "" ||
                txtYazarAdi.Text == "" ||
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
            txtYazarAdi.Clear();
            txtYayinYili.Clear();
            txtToplamAdet.Clear();
            txtMevcutAdet.Clear();
            cmbKategori.SelectedIndex = -1;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtAraKitapAdi.Clear();
            txtAraYazarAdi.Clear();
            LoadKitaplar(); // 👈 restore ALL books
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

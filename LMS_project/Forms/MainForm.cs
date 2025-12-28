using LMS_project.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;
using LMS_project.Database;


namespace LMS_project
{
    public partial class MainForm : Form
    {   

        private int _kullaniciId;
        private int _rol_id;
        public MainForm(int kullaniciId, int rol_id)
        {
            InitializeComponent();

            _kullaniciId = kullaniciId;
            _rol_id = rol_id;
            String rol;

            if (_rol_id == 1) // Admin rolü
            {
                rol  = "Admin";
            }
            else // Normal kullan?c? rolü
            {
                rol = "Gorevli";
            }



        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string rolAdi = (_rol_id == 1) ? "Admin" : "Görevli";
            lblRoleInfo.Text = "Rol: " + rolAdi;

            string adSoyad = GetKullaniciAdSoyad();

            lblWelcome.Text = "Welcome again, " + adSoyad;

            ApplyAuthorization();
        }

        private void ApplyAuthorization()
        {
            // Görevli (rol_id = 2) k?s?tlamalar?
            if (_rol_id == 2)
            {
                btnUyeYonetimi.Enabled = false;
                btnRaporlar.Enabled = false;
                btnDinamikSorgu.Enabled = false;
                btnKullaniciYonetimi.Enabled = false;
            }

            // Admin (rol_id = 1) ? full access
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

        }





        private string GetKullaniciAdSoyad()
        {
            string adSoyad = "";

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                SELECT ad_soyad
                FROM kullanici_tablo
                WHERE kullanici_id = @id
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _kullaniciId);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        adSoyad = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullan?c? bilgisi al?namad?: " + ex.Message);
            }

            return adSoyad;
        }

        private void btnUyeYonetimi_Click(object sender, EventArgs e)
        {
            // Open UyeForm
            UyeForm uyeForm = new UyeForm();

            // Open as modal dialog
            uyeForm.ShowDialog(this);
        }


        private void btnKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            if (_rol_id != 1)
            {
                MessageBox.Show("Bu i?lem sadece Admin taraf?ndan yap?labilir.");
                return;
            }

            KullaniciForm kullaniciForm = new KullaniciForm();
            kullaniciForm.ShowDialog(this);
        }



    }
}

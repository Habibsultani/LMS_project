using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using LMS_project.Database;

namespace LMS_project.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    string query = @"
                        SELECT kullanici_id, rol_id
                        FROM kullanici_tablo
                        WHERE kullanici_adi = @username
                        AND sifre = SHA2(@password, 256);
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int kullaniciId = reader.GetInt32("kullanici_id");
                                int rolId = reader.GetInt32("rol_id");

                                MessageBox.Show("Giriş başarılı!");

                                // 🔑 CREATE MAIN FORM
                                MainForm mainForm = new MainForm(kullaniciId, rolId);

                                // 🔥 CRITICAL LINE:
                                // When MainForm closes (logout), show LoginForm again
                                mainForm.FormClosed += (s, args) =>
                                {
                                    this.Show();
                                };

                                this.Hide();
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LMS_project.Database
{
    public static class DbConnection
    {
        // Connection string (XAMPP default)
        private static readonly string connectionString =
            "Server=localhost;" +
            "Database=lms_project;" +
            "Uid=root;" +
            "Pwd=;" +
            "SslMode=None;";

        // This method returns an OPEN MySQL connection
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Veritabanına bağlanılamadı: " + ex.Message);
            }

            return connection;
        }
    }
}

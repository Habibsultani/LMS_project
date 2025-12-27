namespace LMS_project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            try
            {                 // Test database connection
                var connection = Database.DbConnection.GetConnection();
                MessageBox.Show("Database c%onnected successfully.");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Habib SUltani");
        }

       
    }
}

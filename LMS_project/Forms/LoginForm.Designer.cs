namespace LMS_project.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(197, 129);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 47);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(197, 261);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 47);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(197, 85);
            label1.Name = "label1";
            label1.Size = new Size(178, 41);
            label1.TabIndex = 4;
            label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 217);
            label2.Name = "label2";
            label2.Size = new Size(76, 41);
            label2.TabIndex = 2;
            label2.Text = "Şifre";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(197, 348);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(188, 40);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Giriş";
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            BackColor = SystemColors.InactiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(807, 553);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Button btnLogin;
    }
}

namespace LMS_project.Forms
{
    partial class KullaniciForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciForm));
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            txtAdSoyad = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            cmbRol = new ComboBox();
            label5 = new Label();
            btnEkle = new Button();
            btnTemizle = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(370, 51);
            label1.Name = "label1";
            label1.Size = new Size(408, 41);
            label1.TabIndex = 0;
            label1.Text = "Yeni bir kullanici ekleme sayfa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(193, 129);
            label2.Name = "label2";
            label2.Size = new Size(172, 41);
            label2.TabIndex = 1;
            label2.Text = "kullanici adi";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(193, 173);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(497, 47);
            txtUsername.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(193, 250);
            label3.Name = "label3";
            label3.Size = new Size(142, 41);
            label3.TabIndex = 3;
            label3.Text = "Ad soyad";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(193, 294);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(497, 47);
            txtAdSoyad.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(193, 420);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(497, 47);
            txtPassword.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(193, 375);
            label4.Name = "label4";
            label4.Size = new Size(76, 41);
            label4.TabIndex = 6;
            label4.Text = "Sifre";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Admin", "Görevli" });
            cmbRol.Location = new Point(193, 541);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(497, 49);
            cmbRol.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(193, 497);
            label5.Name = "label5";
            label5.Size = new Size(76, 41);
            label5.TabIndex = 8;
            label5.Text = "Role";
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.LimeGreen;
            btnEkle.Location = new Point(193, 623);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(497, 58);
            btnEkle.TabIndex = 9;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = SystemColors.ControlDark;
            btnTemizle.Location = new Point(193, 698);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(497, 58);
            btnTemizle.TabIndex = 10;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.SandyBrown;
            btnBack.Location = new Point(930, 71);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(188, 58);
            btnBack.TabIndex = 11;
            btnBack.Text = "Ana sayfaya";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // KullaniciForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1193, 789);
            Controls.Add(btnBack);
            Controls.Add(btnTemizle);
            Controls.Add(btnEkle);
            Controls.Add(label5);
            Controls.Add(cmbRol);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(txtAdSoyad);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "KullaniciForm";
            Text = "User managment page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private Label label3;
        private TextBox txtAdSoyad;
        private TextBox txtPassword;
        private Label label4;
        private ComboBox cmbRol;
        private Label label5;
        private Button btnEkle;
        private Button btnTemizle;
        private Button btnBack;
    }
}
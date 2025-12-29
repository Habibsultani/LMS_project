namespace LMS_project
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblRoleInfo = new Label();
            btnUyeYonetimi = new Button();
            btnKitapYonetimi = new Button();
            btnOduncIslemleri = new Button();
            btnCeza = new Button();
            btnRaporlar = new Button();
            btnDinamikSorgu = new Button();
            btnLogout = new Button();
            lblWelcome = new Label();
            btnKullaniciYonetimi = new Button();
            SuspendLayout();
            // 
            // lblRoleInfo
            // 
            lblRoleInfo.AutoSize = true;
            lblRoleInfo.Location = new Point(118, 128);
            lblRoleInfo.Name = "lblRoleInfo";
            lblRoleInfo.Size = new Size(163, 41);
            lblRoleInfo.TabIndex = 0;
            lblRoleInfo.Text = "Your rol is: ";
            // 
            // btnUyeYonetimi
            // 
            btnUyeYonetimi.Location = new Point(30, 260);
            btnUyeYonetimi.Name = "btnUyeYonetimi";
            btnUyeYonetimi.Size = new Size(310, 58);
            btnUyeYonetimi.TabIndex = 1;
            btnUyeYonetimi.Text = "Uye yontemi";
            btnUyeYonetimi.UseVisualStyleBackColor = true;
            btnUyeYonetimi.Click += btnUyeYonetimi_Click;
            // 
            // btnKitapYonetimi
            // 
            btnKitapYonetimi.Location = new Point(396, 260);
            btnKitapYonetimi.Name = "btnKitapYonetimi";
            btnKitapYonetimi.Size = new Size(279, 58);
            btnKitapYonetimi.TabIndex = 2;
            btnKitapYonetimi.Text = "kitap yontemi";
            btnKitapYonetimi.UseVisualStyleBackColor = true;
            btnKitapYonetimi.Click += btnKitapYonetimi_Click;
            // 
            // btnOduncIslemleri
            // 
            btnOduncIslemleri.Location = new Point(753, 260);
            btnOduncIslemleri.Name = "btnOduncIslemleri";
            btnOduncIslemleri.Size = new Size(269, 58);
            btnOduncIslemleri.TabIndex = 3;
            btnOduncIslemleri.Text = "Odunc Islemeleri";
            btnOduncIslemleri.UseVisualStyleBackColor = true;
            btnOduncIslemleri.Click += btnOduncIslemleri_click;
            // 
            // btnCeza
            // 
            btnCeza.Location = new Point(30, 433);
            btnCeza.Name = "btnCeza";
            btnCeza.Size = new Size(310, 58);
            btnCeza.TabIndex = 4;
            btnCeza.Text = "Ceza Goruntuleme";
            btnCeza.UseVisualStyleBackColor = true;
            btnCeza.Click += btnCeza_click;
            // 
            // btnRaporlar
            // 
            btnRaporlar.Location = new Point(396, 433);
            btnRaporlar.Name = "btnRaporlar";
            btnRaporlar.Size = new Size(279, 58);
            btnRaporlar.TabIndex = 5;
            btnRaporlar.Text = "Raporlar";
            btnRaporlar.UseVisualStyleBackColor = true;
            // 
            // btnDinamikSorgu
            // 
            btnDinamikSorgu.Location = new Point(753, 433);
            btnDinamikSorgu.Name = "btnDinamikSorgu";
            btnDinamikSorgu.Size = new Size(269, 58);
            btnDinamikSorgu.TabIndex = 6;
            btnDinamikSorgu.Text = "Dinamik sorgu";
            btnDinamikSorgu.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.ForeColor = SystemColors.ControlLightLight;
            btnLogout.Location = new Point(910, 31);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(310, 58);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Cikis yap";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(118, 31);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(237, 41);
            lblWelcome.TabIndex = 8;
            lblWelcome.Text = "Welcome again: ";
            // 
            // btnKullaniciYonetimi
            // 
            btnKullaniciYonetimi.BackColor = Color.CornflowerBlue;
            btnKullaniciYonetimi.Location = new Point(910, 96);
            btnKullaniciYonetimi.Name = "btnKullaniciYonetimi";
            btnKullaniciYonetimi.Size = new Size(310, 58);
            btnKullaniciYonetimi.TabIndex = 9;
            btnKullaniciYonetimi.Text = "Kullanici yontemi";
            btnKullaniciYonetimi.UseVisualStyleBackColor = false;
            btnKullaniciYonetimi.Click += btnKullaniciYonetimi_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1232, 648);
            Controls.Add(btnKullaniciYonetimi);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogout);
            Controls.Add(btnDinamikSorgu);
            Controls.Add(btnRaporlar);
            Controls.Add(btnCeza);
            Controls.Add(btnOduncIslemleri);
            Controls.Add(btnKitapYonetimi);
            Controls.Add(btnUyeYonetimi);
            Controls.Add(lblRoleInfo);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoleInfo;
        private Button btnUyeYonetimi;
        private Button btnKitapYonetimi;
        private Button btnOduncIslemleri;
        private Button btnCeza;
        private Button btnRaporlar;
        private Button btnDinamikSorgu;
        private Button btnLogout;
        private Label lblWelcome;
        private Button btnKullaniciYonetimi;
    }
}

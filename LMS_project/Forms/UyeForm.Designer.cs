namespace LMS_project.Forms
{
    partial class UyeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UyeForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtOgrenciNo = new TextBox();
            txtAdSoyad = new TextBox();
            txtEmail = new TextBox();
            txtTelefon = new TextBox();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnTemizle = new Button();
            dgvUyeler = new DataGridView();
            btnBack = new Button();
            label6 = new Label();
            txtAraAdSoyad = new TextBox();
            label7 = new Label();
            txtAraEmail = new TextBox();
            btnOgrenciAra = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUyeler).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(820, 58);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(337, 41);
            label1.TabIndex = 0;
            label1.Text = "User management page";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 214);
            label2.Name = "label2";
            label2.Size = new Size(240, 41);
            label2.TabIndex = 1;
            label2.Text = "Ogrenci Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(538, 214);
            label3.Name = "label3";
            label3.Size = new Size(149, 41);
            label3.TabIndex = 2;
            label3.Text = "Ad soyadi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(940, 214);
            label4.Name = "label4";
            label4.Size = new Size(206, 41);
            label4.TabIndex = 3;
            label4.Text = "E-posta adresi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1388, 214);
            label5.Name = "label5";
            label5.Size = new Size(265, 41);
            label5.TabIndex = 4;
            label5.Text = "telephon numarasi";
            // 
            // txtOgrenciNo
            // 
            txtOgrenciNo.Location = new Point(122, 269);
            txtOgrenciNo.Name = "txtOgrenciNo";
            txtOgrenciNo.Size = new Size(356, 47);
            txtOgrenciNo.TabIndex = 5;
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(538, 269);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(329, 47);
            txtAdSoyad.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(940, 269);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(352, 47);
            txtEmail.TabIndex = 7;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(1388, 269);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(434, 47);
            txtTelefon.TabIndex = 8;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.LimeGreen;
            btnEkle.Location = new Point(198, 380);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(348, 58);
            btnEkle.TabIndex = 9;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Turquoise;
            btnGuncelle.Location = new Point(590, 380);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(328, 58);
            btnGuncelle.TabIndex = 10;
            btnGuncelle.Text = "Guncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.IndianRed;
            btnSil.Location = new Point(972, 380);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(338, 58);
            btnSil.TabIndex = 11;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = SystemColors.ControlDark;
            btnTemizle.Location = new Point(1345, 380);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(375, 58);
            btnTemizle.TabIndex = 12;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            // 
            // dgvUyeler
            // 
            dgvUyeler.AllowUserToAddRows = false;
            dgvUyeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUyeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUyeler.Location = new Point(122, 588);
            dgvUyeler.MultiSelect = false;
            dgvUyeler.Name = "dgvUyeler";
            dgvUyeler.ReadOnly = true;
            dgvUyeler.RowHeadersWidth = 102;
            dgvUyeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUyeler.Size = new Size(1700, 476);
            dgvUyeler.TabIndex = 13;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.SandyBrown;
            btnBack.Location = new Point(833, 1079);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(376, 58);
            btnBack.TabIndex = 14;
            btnBack.Text = "🔙Ana menya dun";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(198, 468);
            label6.Name = "label6";
            label6.Size = new Size(142, 41);
            label6.TabIndex = 15;
            label6.Text = "Ad soyad";
            // 
            // txtAraAdSoyad
            // 
            txtAraAdSoyad.Location = new Point(198, 512);
            txtAraAdSoyad.Name = "txtAraAdSoyad";
            txtAraAdSoyad.Size = new Size(417, 47);
            txtAraAdSoyad.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(655, 468);
            label7.Name = "label7";
            label7.Size = new Size(119, 41);
            label7.TabIndex = 17;
            label7.Text = "E-posta";
            // 
            // txtAraEmail
            // 
            txtAraEmail.Location = new Point(655, 512);
            txtAraEmail.Name = "txtAraEmail";
            txtAraEmail.Size = new Size(451, 47);
            txtAraEmail.TabIndex = 18;
            // 
            // btnOgrenciAra
            // 
            btnOgrenciAra.BackColor = Color.SkyBlue;
            btnOgrenciAra.Location = new Point(1162, 501);
            btnOgrenciAra.Name = "btnOgrenciAra";
            btnOgrenciAra.Size = new Size(558, 58);
            btnOgrenciAra.TabIndex = 19;
            btnOgrenciAra.Text = "Ogrenci ara";
            btnOgrenciAra.UseVisualStyleBackColor = false;
            btnOgrenciAra.Click += btnOgrenciAra_Click;
            // 
            // UyeForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2043, 1175);
            Controls.Add(btnOgrenciAra);
            Controls.Add(txtAraEmail);
            Controls.Add(label7);
            Controls.Add(txtAraAdSoyad);
            Controls.Add(label6);
            Controls.Add(btnBack);
            Controls.Add(dgvUyeler);
            Controls.Add(btnTemizle);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnEkle);
            Controls.Add(txtTelefon);
            Controls.Add(txtEmail);
            Controls.Add(txtAdSoyad);
            Controls.Add(txtOgrenciNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UyeForm";
            Text = " ";
            Load += UyeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUyeler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtOgrenciNo;
        private TextBox txtAdSoyad;
        private TextBox txtEmail;
        private TextBox txtTelefon;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnTemizle;
        private DataGridView dgvUyeler;
        private Button btnBack;
        private Label label6;
        private TextBox txtAraAdSoyad;
        private Label label7;
        private TextBox txtAraEmail;
        private Button btnOgrenciAra;
    }
}
namespace LMS_project.Forms
{
    partial class KitapForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtKitapAdi = new TextBox();
            txtYayinYili = new TextBox();
            txtToplamAdet = new TextBox();
            txtMevcutAdet = new TextBox();
            cmbKategori = new ComboBox();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnTemizle = new Button();
            btnBack = new Button();
            dgvKitaplar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(875, 62);
            label1.Name = "label1";
            label1.Size = new Size(292, 41);
            label1.TabIndex = 0;
            label1.Text = "Kitap verilerin sayfasi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 192);
            label2.Name = "label2";
            label2.Size = new Size(133, 41);
            label2.TabIndex = 1;
            label2.Text = "Kitap adi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(679, 194);
            label3.Name = "label3";
            label3.Size = new Size(130, 41);
            label3.TabIndex = 2;
            label3.Text = "Yayin yili";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(996, 194);
            label4.Name = "label4";
            label4.Size = new Size(182, 41);
            label4.TabIndex = 3;
            label4.Text = "Toplam adet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1324, 192);
            label5.Name = "label5";
            label5.Size = new Size(183, 41);
            label5.TabIndex = 4;
            label5.Text = "Mevcut adet";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1644, 192);
            label6.Name = "label6";
            label6.Size = new Size(129, 41);
            label6.TabIndex = 5;
            label6.Text = "Kategori";
            // 
            // txtKitapAdi
            // 
            txtKitapAdi.Location = new Point(193, 237);
            txtKitapAdi.Name = "txtKitapAdi";
            txtKitapAdi.Size = new Size(457, 47);
            txtKitapAdi.TabIndex = 6;
            // 
            // txtYayinYili
            // 
            txtYayinYili.Location = new Point(679, 238);
            txtYayinYili.Name = "txtYayinYili";
            txtYayinYili.Size = new Size(250, 47);
            txtYayinYili.TabIndex = 7;
            // 
            // txtToplamAdet
            // 
            txtToplamAdet.Location = new Point(996, 238);
            txtToplamAdet.Name = "txtToplamAdet";
            txtToplamAdet.Size = new Size(250, 47);
            txtToplamAdet.TabIndex = 8;
            // 
            // txtMevcutAdet
            // 
            txtMevcutAdet.Location = new Point(1324, 237);
            txtMevcutAdet.Name = "txtMevcutAdet";
            txtMevcutAdet.Size = new Size(250, 47);
            txtMevcutAdet.TabIndex = 9;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(1644, 236);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(302, 49);
            cmbKategori.TabIndex = 10;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Chartreuse;
            btnEkle.Location = new Point(303, 387);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(331, 58);
            btnEkle.TabIndex = 11;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Aquamarine;
            btnGuncelle.Location = new Point(679, 387);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(330, 58);
            btnGuncelle.TabIndex = 12;
            btnGuncelle.Text = "Guncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Brown;
            btnSil.Location = new Point(1040, 387);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(295, 58);
            btnSil.TabIndex = 13;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = SystemColors.AppWorkspace;
            btnTemizle.Location = new Point(1371, 387);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(327, 58);
            btnTemizle.TabIndex = 14;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightSalmon;
            btnBack.Location = new Point(193, 23);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(298, 58);
            btnBack.TabIndex = 15;
            btnBack.Text = "Ana sayfaya dun";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // dgvKitaplar
            // 
            dgvKitaplar.AllowUserToAddRows = false;
            dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKitaplar.Location = new Point(174, 530);
            dgvKitaplar.MultiSelect = false;
            dgvKitaplar.Name = "dgvKitaplar";
            dgvKitaplar.ReadOnly = true;
            dgvKitaplar.RowHeadersWidth = 102;
            dgvKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKitaplar.Size = new Size(1772, 676);
            dgvKitaplar.TabIndex = 16;
            // 
            // KitapForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized2;
            ClientSize = new Size(2076, 1257);
            Controls.Add(dgvKitaplar);
            Controls.Add(btnBack);
            Controls.Add(btnTemizle);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnEkle);
            Controls.Add(cmbKategori);
            Controls.Add(txtMevcutAdet);
            Controls.Add(txtToplamAdet);
            Controls.Add(txtYayinYili);
            Controls.Add(txtKitapAdi);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "KitapForm";
            Text = "KitapForm";
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtKitapAdi;
        private TextBox txtYayinYili;
        private TextBox txtToplamAdet;
        private TextBox txtMevcutAdet;
        private ComboBox cmbKategori;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnTemizle;
        private Button btnBack;
        private DataGridView dgvKitaplar;
    }
}
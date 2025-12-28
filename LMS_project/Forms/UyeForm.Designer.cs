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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtOgrenciNo = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnTemizle = new Button();
            dgvUyeler = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUyeler).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(902, 66);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(337, 41);
            label1.TabIndex = 0;
            label1.Text = "User management page";
            label1.Click += label1_Click;
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
            // textBox1
            // 
            textBox1.Location = new Point(538, 269);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(329, 47);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(940, 269);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(352, 47);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1388, 269);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(434, 47);
            textBox3.TabIndex = 8;
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
            dgvUyeler.Location = new Point(143, 522);
            dgvUyeler.MultiSelect = false;
            dgvUyeler.Name = "dgvUyeler";
            dgvUyeler.ReadOnly = true;
            dgvUyeler.RowHeadersWidth = 102;
            dgvUyeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUyeler.Size = new Size(1663, 476);
            dgvUyeler.TabIndex = 13;
            // 
            // UyeForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized;
            ClientSize = new Size(2043, 1175);
            Controls.Add(dgvUyeler);
            Controls.Add(btnTemizle);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnEkle);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnTemizle;
        private DataGridView dgvUyeler;
    }
}
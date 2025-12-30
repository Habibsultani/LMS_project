namespace LMS_project.Forms
{
    partial class DinamikSorguForm
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
            txtKitapAdi = new TextBox();
            label2 = new Label();
            txtYazarAdi = new TextBox();
            label3 = new Label();
            cmbKategori = new ComboBox();
            label4 = new Label();
            numBasimYilMin = new NumericUpDown();
            label5 = new Label();
            numBasimYilMax = new NumericUpDown();
            chkSadeceMevcut = new CheckBox();
            btnAra = new Button();
            dgvSonuc = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numBasimYilMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBasimYilMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSonuc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 235);
            label1.Name = "label1";
            label1.Size = new Size(137, 41);
            label1.TabIndex = 0;
            label1.Text = "Kitab Adi";
            // 
            // txtKitapAdi
            // 
            txtKitapAdi.Location = new Point(116, 277);
            txtKitapAdi.Name = "txtKitapAdi";
            txtKitapAdi.Size = new Size(250, 47);
            txtKitapAdi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(420, 238);
            label2.Name = "label2";
            label2.Size = new Size(138, 41);
            label2.TabIndex = 2;
            label2.Text = "Yazar Adi";
            // 
            // txtYazarAdi
            // 
            txtYazarAdi.Location = new Point(420, 277);
            txtYazarAdi.Name = "txtYazarAdi";
            txtYazarAdi.Size = new Size(250, 47);
            txtYazarAdi.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(760, 234);
            label3.Name = "label3";
            label3.Size = new Size(210, 41);
            label3.TabIndex = 4;
            label3.Text = "Kitab kategory";
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(760, 279);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(302, 49);
            cmbKategori.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1123, 238);
            label4.Name = "label4";
            label4.Size = new Size(199, 41);
            label4.TabIndex = 6;
            label4.Text = "Min Basim yili";
            // 
            // numBasimYilMin
            // 
            numBasimYilMin.Location = new Point(1123, 281);
            numBasimYilMin.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numBasimYilMin.Name = "numBasimYilMin";
            numBasimYilMin.Size = new Size(300, 47);
            numBasimYilMin.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1444, 234);
            label5.Name = "label5";
            label5.Size = new Size(204, 41);
            label5.TabIndex = 8;
            label5.Text = "Max Basim yili";
            // 
            // numBasimYilMax
            // 
            numBasimYilMax.Location = new Point(1444, 278);
            numBasimYilMax.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numBasimYilMax.Name = "numBasimYilMax";
            numBasimYilMax.Size = new Size(300, 47);
            numBasimYilMax.TabIndex = 9;
            // 
            // chkSadeceMevcut
            // 
            chkSadeceMevcut.AutoSize = true;
            chkSadeceMevcut.Location = new Point(760, 383);
            chkSadeceMevcut.Name = "chkSadeceMevcut";
            chkSadeceMevcut.Size = new Size(323, 45);
            chkSadeceMevcut.TabIndex = 10;
            chkSadeceMevcut.Text = "Sadece mevcut adet";
            chkSadeceMevcut.UseVisualStyleBackColor = true;
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.SkyBlue;
            btnAra.Location = new Point(116, 459);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(1628, 58);
            btnAra.TabIndex = 11;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // dgvSonuc
            // 
            dgvSonuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSonuc.Location = new Point(116, 550);
            dgvSonuc.Name = "dgvSonuc";
            dgvSonuc.RowHeadersWidth = 102;
            dgvSonuc.Size = new Size(1628, 553);
            dgvSonuc.TabIndex = 12;
            // 
            // DinamikSorguForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized3;
            ClientSize = new Size(1981, 1262);
            Controls.Add(dgvSonuc);
            Controls.Add(btnAra);
            Controls.Add(chkSadeceMevcut);
            Controls.Add(numBasimYilMax);
            Controls.Add(label5);
            Controls.Add(numBasimYilMin);
            Controls.Add(label4);
            Controls.Add(cmbKategori);
            Controls.Add(label3);
            Controls.Add(txtYazarAdi);
            Controls.Add(label2);
            Controls.Add(txtKitapAdi);
            Controls.Add(label1);
            Name = "DinamikSorguForm";
            Text = "DinamikSorguForm";
            Load += DinamikSorguForm_Load;
            ((System.ComponentModel.ISupportInitialize)numBasimYilMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBasimYilMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSonuc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtKitapAdi;
        private Label label2;
        private TextBox txtYazarAdi;
        private Label label3;
        private ComboBox cmbKategori;
        private Label label4;
        private NumericUpDown numBasimYilMin;
        private Label label5;
        private NumericUpDown numBasimYilMax;
        private CheckBox chkSadeceMevcut;
        private Button btnAra;
        private DataGridView dgvSonuc;
    }
}
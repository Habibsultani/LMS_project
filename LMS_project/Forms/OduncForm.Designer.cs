namespace LMS_project.Forms
{
    partial class OduncForm
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
            grpOduncVer = new GroupBox();
            btnOduncVer = new Button();
            lblKitapStatus = new Label();
            btnCheckKitap = new Button();
            txtKitapId = new TextBox();
            lblKitapId = new Label();
            lblOgrenciStatus = new Label();
            btnCheckOgrenci = new Button();
            txtOgrenciNo = new TextBox();
            lblOgrenciNo = new Label();
            grpTeslimAl = new GroupBox();
            btnTeslimAl = new Button();
            btnTeslimOgrenciKontrol = new Button();
            txtTeslimOgrenciNo = new TextBox();
            lblOgrenciNoTeslim = new Label();
            dgvAktifOduncler = new DataGridView();
            grpOduncVer.SuspendLayout();
            grpTeslimAl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAktifOduncler).BeginInit();
            SuspendLayout();
            // 
            // grpOduncVer
            // 
            grpOduncVer.BackColor = SystemColors.ControlDarkDark;
            grpOduncVer.Controls.Add(btnOduncVer);
            grpOduncVer.Controls.Add(lblKitapStatus);
            grpOduncVer.Controls.Add(btnCheckKitap);
            grpOduncVer.Controls.Add(txtKitapId);
            grpOduncVer.Controls.Add(lblKitapId);
            grpOduncVer.Controls.Add(lblOgrenciStatus);
            grpOduncVer.Controls.Add(btnCheckOgrenci);
            grpOduncVer.Controls.Add(txtOgrenciNo);
            grpOduncVer.Controls.Add(lblOgrenciNo);
            grpOduncVer.ForeColor = SystemColors.ButtonHighlight;
            grpOduncVer.Location = new Point(193, 103);
            grpOduncVer.Name = "grpOduncVer";
            grpOduncVer.Size = new Size(1643, 479);
            grpOduncVer.TabIndex = 0;
            grpOduncVer.TabStop = false;
            grpOduncVer.Text = "Odunc Ver";
            // 
            // btnOduncVer
            // 
            btnOduncVer.BackColor = Color.DarkGreen;
            btnOduncVer.Enabled = false;
            btnOduncVer.ForeColor = SystemColors.ButtonHighlight;
            btnOduncVer.Location = new Point(105, 358);
            btnOduncVer.Name = "btnOduncVer";
            btnOduncVer.Size = new Size(763, 61);
            btnOduncVer.TabIndex = 8;
            btnOduncVer.Text = "Odunc Ver";
            btnOduncVer.UseVisualStyleBackColor = false;
            btnOduncVer.Click += btnOduncVer_Click;
            // 
            // lblKitapStatus
            // 
            lblKitapStatus.AutoSize = true;
            lblKitapStatus.Location = new Point(933, 265);
            lblKitapStatus.Name = "lblKitapStatus";
            lblKitapStatus.Size = new Size(34, 41);
            lblKitapStatus.TabIndex = 7;
            lblKitapStatus.Text = "``";
            // 
            // btnCheckKitap
            // 
            btnCheckKitap.BackColor = Color.CornflowerBlue;
            btnCheckKitap.Enabled = false;
            btnCheckKitap.Location = new Point(523, 248);
            btnCheckKitap.Name = "btnCheckKitap";
            btnCheckKitap.Size = new Size(345, 58);
            btnCheckKitap.TabIndex = 6;
            btnCheckKitap.Text = "Kitabi Kontrol et";
            btnCheckKitap.UseVisualStyleBackColor = false;
            btnCheckKitap.Click += btnCheckKitap_Click;
            // 
            // txtKitapId
            // 
            txtKitapId.Location = new Point(105, 259);
            txtKitapId.Name = "txtKitapId";
            txtKitapId.Size = new Size(355, 47);
            txtKitapId.TabIndex = 5;
            // 
            // lblKitapId
            // 
            lblKitapId.AutoSize = true;
            lblKitapId.Location = new Point(105, 215);
            lblKitapId.Name = "lblKitapId";
            lblKitapId.Size = new Size(119, 41);
            lblKitapId.TabIndex = 4;
            lblKitapId.Text = "Kitab Id";
            // 
            // lblOgrenciStatus
            // 
            lblOgrenciStatus.AutoSize = true;
            lblOgrenciStatus.ForeColor = SystemColors.ControlLightLight;
            lblOgrenciStatus.Location = new Point(933, 140);
            lblOgrenciStatus.Name = "lblOgrenciStatus";
            lblOgrenciStatus.Size = new Size(34, 41);
            lblOgrenciStatus.TabIndex = 3;
            lblOgrenciStatus.Text = "``";
            // 
            // btnCheckOgrenci
            // 
            btnCheckOgrenci.BackColor = Color.CornflowerBlue;
            btnCheckOgrenci.Location = new Point(523, 131);
            btnCheckOgrenci.Name = "btnCheckOgrenci";
            btnCheckOgrenci.Size = new Size(345, 58);
            btnCheckOgrenci.TabIndex = 2;
            btnCheckOgrenci.Text = "Ogrenciye Kontrol et";
            btnCheckOgrenci.UseVisualStyleBackColor = false;
            btnCheckOgrenci.Click += btnCheckOgrenci_Click;
            // 
            // txtOgrenciNo
            // 
            txtOgrenciNo.Location = new Point(105, 131);
            txtOgrenciNo.MaxLength = 20;
            txtOgrenciNo.Name = "txtOgrenciNo";
            txtOgrenciNo.Size = new Size(355, 47);
            txtOgrenciNo.TabIndex = 1;
            // 
            // lblOgrenciNo
            // 
            lblOgrenciNo.AutoSize = true;
            lblOgrenciNo.Location = new Point(99, 87);
            lblOgrenciNo.Name = "lblOgrenciNo";
            lblOgrenciNo.Size = new Size(256, 41);
            lblOgrenciNo.TabIndex = 0;
            lblOgrenciNo.Text = "Ogrenci Numarasi";
            // 
            // grpTeslimAl
            // 
            grpTeslimAl.BackColor = SystemColors.ControlDarkDark;
            grpTeslimAl.Controls.Add(btnTeslimAl);
            grpTeslimAl.Controls.Add(btnTeslimOgrenciKontrol);
            grpTeslimAl.Controls.Add(txtTeslimOgrenciNo);
            grpTeslimAl.Controls.Add(lblOgrenciNoTeslim);
            grpTeslimAl.ForeColor = SystemColors.ButtonHighlight;
            grpTeslimAl.Location = new Point(193, 615);
            grpTeslimAl.Name = "grpTeslimAl";
            grpTeslimAl.Size = new Size(1643, 250);
            grpTeslimAl.TabIndex = 1;
            grpTeslimAl.TabStop = false;
            grpTeslimAl.Text = "Teslim Al ";
            // 
            // btnTeslimAl
            // 
            btnTeslimAl.BackColor = Color.PaleGreen;
            btnTeslimAl.Enabled = false;
            btnTeslimAl.ForeColor = Color.Black;
            btnTeslimAl.Location = new Point(1065, 126);
            btnTeslimAl.Name = "btnTeslimAl";
            btnTeslimAl.Size = new Size(500, 58);
            btnTeslimAl.TabIndex = 3;
            btnTeslimAl.Text = "Teslim Al ";
            btnTeslimAl.UseVisualStyleBackColor = false;
            btnTeslimAl.Click += btnTeslimAl_Click;
            // 
            // btnTeslimOgrenciKontrol
            // 
            btnTeslimOgrenciKontrol.BackColor = Color.CornflowerBlue;
            btnTeslimOgrenciKontrol.Location = new Point(523, 121);
            btnTeslimOgrenciKontrol.Name = "btnTeslimOgrenciKontrol";
            btnTeslimOgrenciKontrol.Size = new Size(345, 58);
            btnTeslimOgrenciKontrol.TabIndex = 2;
            btnTeslimOgrenciKontrol.Text = "Ogrenciyi kontrol et";
            btnTeslimOgrenciKontrol.UseVisualStyleBackColor = false;
            btnTeslimOgrenciKontrol.Click += btnTeslimOgrenciKontrol_Click;
            // 
            // txtTeslimOgrenciNo
            // 
            txtTeslimOgrenciNo.Location = new Point(105, 132);
            txtTeslimOgrenciNo.Name = "txtTeslimOgrenciNo";
            txtTeslimOgrenciNo.Size = new Size(355, 47);
            txtTeslimOgrenciNo.TabIndex = 1;
            // 
            // lblOgrenciNoTeslim
            // 
            lblOgrenciNoTeslim.AutoSize = true;
            lblOgrenciNoTeslim.Location = new Point(98, 88);
            lblOgrenciNoTeslim.Name = "lblOgrenciNoTeslim";
            lblOgrenciNoTeslim.Size = new Size(256, 41);
            lblOgrenciNoTeslim.TabIndex = 0;
            lblOgrenciNoTeslim.Text = "Ogrenci Numarasi";
            // 
            // dgvAktifOduncler
            // 
            dgvAktifOduncler.AllowUserToDeleteRows = false;
            dgvAktifOduncler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktifOduncler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAktifOduncler.Location = new Point(193, 865);
            dgvAktifOduncler.MultiSelect = false;
            dgvAktifOduncler.Name = "dgvAktifOduncler";
            dgvAktifOduncler.ReadOnly = true;
            dgvAktifOduncler.RowHeadersWidth = 102;
            dgvAktifOduncler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktifOduncler.Size = new Size(1643, 375);
            dgvAktifOduncler.TabIndex = 2;
            dgvAktifOduncler.CellClick += dgvAktifOduncler_CellClick;
            dgvAktifOduncler.Click += dgvAktifOduncler_Click;
            // 
            // OduncForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized3;
            ClientSize = new Size(2009, 1296);
            Controls.Add(dgvAktifOduncler);
            Controls.Add(grpTeslimAl);
            Controls.Add(grpOduncVer);
            Name = "OduncForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Odunc Islemeleri";
            grpOduncVer.ResumeLayout(false);
            grpOduncVer.PerformLayout();
            grpTeslimAl.ResumeLayout(false);
            grpTeslimAl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAktifOduncler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOduncVer;
        private TextBox txtOgrenciNo;
        private Label lblOgrenciNo;
        private Label lblOgrenciStatus;
        private Button btnCheckOgrenci;
        private Label lblKitapId;
        private Button btnCheckKitap;
        private TextBox txtKitapId;
        private Label lblKitapStatus;
        private Button btnOduncVer;
        private GroupBox grpTeslimAl;
        private TextBox txtTeslimOgrenciNo;
        private Label lblOgrenciNoTeslim;
        private Button btnTeslimOgrenciKontrol;
        private DataGridView dgvAktifOduncler;
        private Button btnTeslimAl;
    }
}
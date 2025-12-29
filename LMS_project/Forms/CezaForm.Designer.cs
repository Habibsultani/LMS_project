namespace LMS_project.Forms
{
    partial class CezaForm
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
            dtBaslangic = new DateTimePicker();
            dtBitis = new DateTimePicker();
            btnFiltrele = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvCezalar = new DataGridView();
            lblToplamBorc = new Label();
            txtOgrenciNo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCezalar).BeginInit();
            SuspendLayout();
            // 
            // dtBaslangic
            // 
            dtBaslangic.Location = new Point(678, 309);
            dtBaslangic.Name = "dtBaslangic";
            dtBaslangic.Size = new Size(500, 47);
            dtBaslangic.TabIndex = 1;
            // 
            // dtBitis
            // 
            dtBitis.Location = new Point(1232, 309);
            dtBitis.Name = "dtBitis";
            dtBitis.Size = new Size(500, 47);
            dtBitis.TabIndex = 2;
            // 
            // btnFiltrele
            // 
            btnFiltrele.BackColor = Color.LightSkyBlue;
            btnFiltrele.Location = new Point(310, 397);
            btnFiltrele.Name = "btnFiltrele";
            btnFiltrele.Size = new Size(1422, 58);
            btnFiltrele.TabIndex = 3;
            btnFiltrele.Text = "Filterle";
            btnFiltrele.UseVisualStyleBackColor = false;
            btnFiltrele.Click += btnFiltrele_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 255);
            label1.Name = "label1";
            label1.Size = new Size(231, 41);
            label1.TabIndex = 4;
            label1.Text = "Ogrenci Numasi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(680, 265);
            label2.Name = "label2";
            label2.Size = new Size(218, 41);
            label2.TabIndex = 5;
            label2.Text = "Baslangic Tarihi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1232, 265);
            label3.Name = "label3";
            label3.Size = new Size(149, 41);
            label3.TabIndex = 6;
            label3.Text = "Bitis Tarihi";
            // 
            // dgvCezalar
            // 
            dgvCezalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCezalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCezalar.Location = new Point(310, 551);
            dgvCezalar.Name = "dgvCezalar";
            dgvCezalar.ReadOnly = true;
            dgvCezalar.RowHeadersWidth = 102;
            dgvCezalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCezalar.Size = new Size(1432, 436);
            dgvCezalar.TabIndex = 7;
            // 
            // lblToplamBorc
            // 
            lblToplamBorc.AutoSize = true;
            lblToplamBorc.Location = new Point(310, 1018);
            lblToplamBorc.Name = "lblToplamBorc";
            lblToplamBorc.Size = new Size(0, 41);
            lblToplamBorc.TabIndex = 8;
            // 
            // txtOgrenciNo
            // 
            txtOgrenciNo.Location = new Point(310, 309);
            txtOgrenciNo.Name = "txtOgrenciNo";
            txtOgrenciNo.Size = new Size(321, 47);
            txtOgrenciNo.TabIndex = 9;
            // 
            // CezaForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized4;
            ClientSize = new Size(1992, 1228);
            Controls.Add(txtOgrenciNo);
            Controls.Add(lblToplamBorc);
            Controls.Add(dgvCezalar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnFiltrele);
            Controls.Add(dtBitis);
            Controls.Add(dtBaslangic);
            Name = "CezaForm";
            Text = "CezaForm";
            ((System.ComponentModel.ISupportInitialize)dgvCezalar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbOgrenci;
        private DateTimePicker dtBaslangic;
        private DateTimePicker dtBitis;
        private Button btnFiltrele;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvCezalar;
        private Label lblToplamBorc;
        private TextBox txtOgrenciNo;
    }
}
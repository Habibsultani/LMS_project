namespace LMS_project.Forms
{
    partial class RaporOduncForm
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
            dtBaslangic = new DateTimePicker();
            label2 = new Label();
            dtBitis = new DateTimePicker();
            btnRaporGetir = new Button();
            dgvRapor = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRapor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 156);
            label1.Name = "label1";
            label1.Size = new Size(215, 41);
            label1.TabIndex = 0;
            label1.Text = "Baslangic tarihi";
            // 
            // dtBaslangic
            // 
            dtBaslangic.Location = new Point(182, 200);
            dtBaslangic.Name = "dtBaslangic";
            dtBaslangic.Size = new Size(500, 47);
            dtBaslangic.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(776, 156);
            label2.Name = "label2";
            label2.Size = new Size(146, 41);
            label2.TabIndex = 2;
            label2.Text = "Bitis tarihi";
            // 
            // dtBitis
            // 
            dtBitis.Location = new Point(775, 200);
            dtBitis.Name = "dtBitis";
            dtBitis.Size = new Size(500, 47);
            dtBitis.TabIndex = 3;
            // 
            // btnRaporGetir
            // 
            btnRaporGetir.Location = new Point(1340, 196);
            btnRaporGetir.Name = "btnRaporGetir";
            btnRaporGetir.Size = new Size(395, 58);
            btnRaporGetir.TabIndex = 4;
            btnRaporGetir.Text = "Rapor al";
            btnRaporGetir.UseVisualStyleBackColor = true;
            btnRaporGetir.Click += btnRaporGetir_Click;
            // 
            // dgvRapor
            // 
            dgvRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRapor.Location = new Point(182, 288);
            dgvRapor.Name = "dgvRapor";
            dgvRapor.RowHeadersWidth = 102;
            dgvRapor.Size = new Size(1553, 375);
            dgvRapor.TabIndex = 5;
            // 
            // RaporOduncForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized5;
            ClientSize = new Size(1964, 1264);
            Controls.Add(dgvRapor);
            Controls.Add(btnRaporGetir);
            Controls.Add(dtBitis);
            Controls.Add(label2);
            Controls.Add(dtBaslangic);
            Controls.Add(label1);
            Name = "RaporOduncForm";
            Text = "RaporOduncForm";
            ((System.ComponentModel.ISupportInitialize)dgvRapor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtBaslangic;
        private Label label2;
        private DateTimePicker dtBitis;
        private Button btnRaporGetir;
        private DataGridView dgvRapor;
    }
}
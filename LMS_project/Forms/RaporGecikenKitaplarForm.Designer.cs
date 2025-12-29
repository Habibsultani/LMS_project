namespace LMS_project.Forms
{
    partial class RaporGecikenKitaplarForm
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
            dtBugun = new DateTimePicker();
            btnRaporGetir = new Button();
            dgvRapor = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRapor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 209);
            label1.Name = "label1";
            label1.Size = new Size(215, 41);
            label1.TabIndex = 0;
            label1.Text = "Bugunun Tarihi";
            // 
            // dtBugun
            // 
            dtBugun.Location = new Point(245, 253);
            dtBugun.Name = "dtBugun";
            dtBugun.Size = new Size(542, 47);
            dtBugun.TabIndex = 1;
            // 
            // btnRaporGetir
            // 
            btnRaporGetir.Location = new Point(1038, 249);
            btnRaporGetir.Name = "btnRaporGetir";
            btnRaporGetir.Size = new Size(709, 58);
            btnRaporGetir.TabIndex = 2;
            btnRaporGetir.Text = "Report getir";
            btnRaporGetir.UseVisualStyleBackColor = true;
            btnRaporGetir.Click += btnRaporGetir_Click;
            // 
            // dgvRapor
            // 
            dgvRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRapor.Location = new Point(247, 359);
            dgvRapor.Name = "dgvRapor";
            dgvRapor.RowHeadersWidth = 102;
            dgvRapor.Size = new Size(1502, 719);
            dgvRapor.TabIndex = 3;
            // 
            // RaporGecikenKitaplarForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized7;
            ClientSize = new Size(2006, 1209);
            Controls.Add(dgvRapor);
            Controls.Add(btnRaporGetir);
            Controls.Add(dtBugun);
            Controls.Add(label1);
            Name = "RaporGecikenKitaplarForm";
            Text = "RaporGecikenKitaplarForm";
            ((System.ComponentModel.ISupportInitialize)dgvRapor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtBugun;
        private Button btnRaporGetir;
        private DataGridView dgvRapor;
    }
}
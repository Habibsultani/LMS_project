namespace LMS_project.Forms
{
    partial class Raporlar
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
            btnTarihAraligi = new Button();
            btnGecekenKitablar = new Button();
            btnEnCokUdunc = new Button();
            SuspendLayout();
            // 
            // btnTarihAraligi
            // 
            btnTarihAraligi.Location = new Point(223, 208);
            btnTarihAraligi.Name = "btnTarihAraligi";
            btnTarihAraligi.Size = new Size(691, 58);
            btnTarihAraligi.TabIndex = 0;
            btnTarihAraligi.Text = "Tarih Aralığına Göre Ödünç Raporu";
            btnTarihAraligi.UseVisualStyleBackColor = true;
            btnTarihAraligi.Click += btnTarihAraligi_click;
            // 
            // btnGecekenKitablar
            // 
            btnGecekenKitablar.Location = new Point(223, 311);
            btnGecekenKitablar.Name = "btnGecekenKitablar";
            btnGecekenKitablar.Size = new Size(691, 58);
            btnGecekenKitablar.TabIndex = 1;
            btnGecekenKitablar.Text = "Geciken Kitaplar Raporu";
            btnGecekenKitablar.UseVisualStyleBackColor = true;
            btnGecekenKitablar.Click += btnGecekenKitablar_click;
            // 
            // btnEnCokUdunc
            // 
            btnEnCokUdunc.Location = new Point(223, 410);
            btnEnCokUdunc.Name = "btnEnCokUdunc";
            btnEnCokUdunc.Size = new Size(691, 58);
            btnEnCokUdunc.TabIndex = 2;
            btnEnCokUdunc.Text = "En Çok Ödünç Alınan Kitaplar Raporu";
            btnEnCokUdunc.UseVisualStyleBackColor = true;
            btnEnCokUdunc.Click += btnEnCokUdunc_click;
            // 
            // Raporlar
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aw528649_01_0_resized6;
            ClientSize = new Size(1586, 950);
            Controls.Add(btnEnCokUdunc);
            Controls.Add(btnGecekenKitablar);
            Controls.Add(btnTarihAraligi);
            Name = "Raporlar";
            Text = "Raporlar";
            ResumeLayout(false);
        }

        #endregion

        private Button btnTarihAraligi;
        private Button btnGecekenKitablar;
        private Button btnEnCokUdunc;
    }
}
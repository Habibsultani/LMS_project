using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LMS_project.Forms
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        private void btnTarihAraligi_click(object sender, EventArgs e)
        {
            RaporOduncForm raporOduncForm = new RaporOduncForm();
            raporOduncForm.ShowDialog();
        }

        private void btnGecekenKitablar_click(object sender, EventArgs e)
        {
            RaporGecikenKitaplarForm raporGecikenKitaplarForm = new RaporGecikenKitaplarForm();
            raporGecikenKitaplarForm.ShowDialog();
        }

        private void btnEnCokUdunc_click(object sender, EventArgs e)
        {
            RaporEnCokOduncForm raporEnCokOduncForm = new RaporEnCokOduncForm();
            raporEnCokOduncForm.ShowDialog();
        }
    }
}

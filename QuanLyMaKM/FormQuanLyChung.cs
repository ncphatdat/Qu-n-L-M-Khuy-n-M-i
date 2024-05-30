using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMaKM
{
    public partial class FormQuanLyChung : Form
    {
        public FormQuanLyChung()
        {
            InitializeComponent();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiKhoan formQuanLyTaiKhoan = new FormQuanLyTaiKhoan();
            formQuanLyTaiKhoan.Show();
            this.Close();
        }

        private void btnQLM_Click(object sender, EventArgs e)
        {
            FormTaoMaKM formTaoMaKM = new FormTaoMaKM();
            formTaoMaKM.Show();
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Close();
        }
    }
}

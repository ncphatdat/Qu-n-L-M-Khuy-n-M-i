using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMaKM
{
    public partial class FormDangNhap : Form
    {
        public string SelectedTaiKhoan
        {
            get { return cbTaiKhoan.Text; }
        }
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security=True";
            string tenTK = cbTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT LoaiTK FROM TaiKhoan WHERE TenTK = @TenTK AND MatKhau = @MatKhau";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenTK", tenTK);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Tài khoản chưa được đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string loaiTK = result.ToString();

                            if (loaiTK.Equals("Nhân viên", StringComparison.OrdinalIgnoreCase))
                            {
                                // Chuyển tới FormKhuyenMai
                                NhapMaKhuyenMai formKhuyenMai = new NhapMaKhuyenMai();
                                formKhuyenMai.TenTaiKhoan = this.SelectedTaiKhoan;
                                formKhuyenMai.Show();
                                this.Hide();
                            }
                            else if (loaiTK.Equals("Quản trị viên", StringComparison.OrdinalIgnoreCase))
                            {
                                // Chuyển tới FormQuanLy
                                /*FormQuanLyTaiKhoan formQuanLy = new FormQuanLyTaiKhoan();
                                formQuanLy.Show();
                                this.Hide();*/
                                FormQuanLyChung formQuanLyChung = new FormQuanLyChung();
                                formQuanLyChung.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Loại tài khoản không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyMaKMDataSet1.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.quanLyMaKMDataSet1.TaiKhoan);

            //Hiển thị dữ liệu vào combobox
            LoadDuLieu_ComboBox();
        }

        //Hiển thị dữ liệu vào combobox
        private void LoadDuLieu_ComboBox()
        {
            QuanLyMaKM1DataSet.TaiKhoanDataTable b = new QuanLyMaKM1DataSet.TaiKhoanDataTable();
            QuanLyMaKM1DataSetTableAdapters.TaiKhoanTableAdapter a = new QuanLyMaKM1DataSetTableAdapters.TaiKhoanTableAdapter();
            b.Reset();
            a.Fill(b);
            cbTaiKhoan.DataSource = b;
            cbTaiKhoan.DisplayMember = "TenTK";
            cbTaiKhoan.ValueMember = "MaTK";
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyMaKM
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            // Load today's data into the DataGridView when the form loads
            LoadTodayData();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";
            string tenNV = txtNhanVien.Text.Trim();
            string tenTK = txtTaiKhoanDK.Text.Trim();
            string matKhau = txtMatKhauDK.Text.Trim();
            string loaiTK = cbLoaiTK.SelectedItem?.ToString(); // Ensure the combo box item is selected
            DateTime ngayGioThem = DateTime.Now;

            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(loaiTK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO TaiKhoan (TenNV, TenTK, MatKhau, LoaiTK, NgayGioThem) VALUES (@TenNV, @TenTK, @MatKhau, @LoaiTK, @NgayGioThem)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);
                        cmd.Parameters.AddWithValue("@TenTK", tenTK);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@LoaiTK", loaiTK);
                        cmd.Parameters.AddWithValue("@NgayGioThem", ngayGioThem);

                        cmd.ExecuteNonQuery();
                    }
                }

                // After inserting the new record, reload today's data to display in the DataGridView
                LoadTodayData();

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTodayData()
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";
            DateTime today = DateTime.Today;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaTK, TenNV, TenTK, MatKhau, LoaiTK, NgayGioThem FROM TaiKhoan WHERE CONVERT(date, NgayGioThem) = @Today";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Today", today);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        DGVDangKy.DataSource = dataTable;

                        // Auto-size the columns to fit the data
                        foreach (DataGridViewColumn column in DGVDangKy.Columns)
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }

                        // Format the NgayGioThem column
                        DGVDangKy.Columns["NgayGioThem"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVDangKy_VisibleChanged(object sender, EventArgs e)
        {
            if (DGVDangKy.Visible)
            {
                LoadTodayData();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

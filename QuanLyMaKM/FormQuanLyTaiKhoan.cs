using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyMaKM
{
    public partial class FormQuanLyTaiKhoan : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu của bạn
        private string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

        // Biến tạm thời để lưu trữ MaTK của dòng được chọn
        private int selectedMaTK;

        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadTodayData();
        }

        private void SetupDataGridView()
        {
            // Set DataGridView to read-only
            DGVQuanLy.ReadOnly = true;

            // Disable adding and deleting rows
            DGVQuanLy.AllowUserToAddRows = false;
            DGVQuanLy.AllowUserToDeleteRows = false;

            // Auto-size columns to fill the DataGridView
            DGVQuanLy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add event handler for CellClick
            DGVQuanLy.CellClick += DGVQuanLy_CellClick;
        }

        private void LoadTodayData()
        {
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

                        DGVQuanLy.DataSource = dataTable;

                        // Format the NgayGioThem column
                        if (DGVQuanLy.Columns["NgayGioThem"] != null)
                        {
                            DGVQuanLy.Columns["NgayGioThem"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenNV = txtTenNV.Text.Trim();
            string tenTK = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
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

                    // Kiểm tra xem tên nhân viên và tài khoản đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE TenNV = @TenNV OR TenTK = @TenTK";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@TenNV", tenNV);
                        checkCmd.Parameters.AddWithValue("@TenTK", tenTK);

                        int existingCount = (int)checkCmd.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            MessageBox.Show("Tài khoản đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Nếu không tồn tại, thực hiện thêm mới
                    string insertQuery = "INSERT INTO TaiKhoan (TenNV, TenTK, MatKhau, LoaiTK, NgayGioThem) VALUES (@TenNV, @TenTK, @MatKhau, @LoaiTK, @NgayGioThem)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
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


        private void DGVQuanLy_VisibleChanged(object sender, EventArgs e)
        {
            if (DGVQuanLy.Visible)
            {
                LoadTodayData();
            }
        }

        private void DGVQuanLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = DGVQuanLy.Rows[e.RowIndex];

                // Lưu trữ MaTK vào biến tạm thời
                selectedMaTK = (int)row.Cells["MaTK"].Value;

                // Fill the text boxes with the data from the selected row
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtTaiKhoan.Text = row.Cells["TenTK"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cbLoaiTK.SelectedItem = row.Cells["LoaiTK"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenNV = txtTenNV.Text.Trim();
            string tenTK = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string loaiTK = cbLoaiTK.SelectedItem?.ToString(); // Ensure the combo box item is selected

            if (selectedMaTK == 0 || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(loaiTK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi sửa
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa thông tin này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, dừng lại không sửa
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE TaiKhoan SET TenNV = @TenNV, TenTK = @TenTK, MatKhau = @MatKhau, LoaiTK = @LoaiTK WHERE MaTK = @MaTK";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", selectedMaTK);
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);
                        cmd.Parameters.AddWithValue("@TenTK", tenTK);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@LoaiTK", loaiTK);

                        cmd.ExecuteNonQuery();
                    }
                }

                // After updating the record, reload today's data to display in the DataGridView
                LoadTodayData();

                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaTK == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, dừng lại không xóa
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", selectedMaTK);
                        cmd.ExecuteNonQuery();
                    }
                }

                // After deleting the record, reload today's data to display in the DataGridView
                LoadTodayData();

                // Run the stored procedure ResetIDsAfterDelete
                RunResetIDsAfterDeleteProcedure();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunResetIDsAfterDeleteProcedure()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "EXEC ResetIDsAfterDelete";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi chạy stored procedure: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FormQuanLyChung formQuanLyChung = new FormQuanLyChung();
            formQuanLyChung.Show();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox và ComboBox
            string tenNV = txtTenNV.Text.Trim();
            string tenTK = txtTaiKhoan.Text.Trim();
            string loaiTK = cbLoaiTK.SelectedItem?.ToString(); // Lấy giá trị được chọn từ ComboBox

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo câu truy vấn SQL dựa trên dữ liệu từ TextBox và ComboBox
                    string query = "SELECT MaTK, TenNV, TenTK, MatKhau, LoaiTK, NgayGioThem FROM TaiKhoan";

                    if (!string.IsNullOrEmpty(tenNV) || !string.IsNullOrEmpty(tenTK) || !string.IsNullOrEmpty(loaiTK))
                    {
                        query += " WHERE 1 = 1"; // WHERE 1 = 1 để dễ dàng thêm điều kiện sau này

                        if (!string.IsNullOrEmpty(tenNV))
                        {
                            query += " AND TenNV LIKE @TenNV";
                        }

                        if (!string.IsNullOrEmpty(tenTK))
                        {
                            query += " AND TenTK LIKE @TenTK";
                        }

                        if (!string.IsNullOrEmpty(loaiTK))
                        {
                            query += " AND LoaiTK = @LoaiTK"; // Thay thế LoaiTK bằng tên cột tương ứng trong cơ sở dữ liệu
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm các tham số vào câu truy vấn
                        if (!string.IsNullOrEmpty(tenNV))
                        {
                            cmd.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
                        }

                        if (!string.IsNullOrEmpty(tenTK))
                        {
                            cmd.Parameters.AddWithValue("@TenTK", "%" + tenTK + "%");
                        }

                        if (!string.IsNullOrEmpty(loaiTK))
                        {
                            cmd.Parameters.AddWithValue("@LoaiTK", loaiTK);
                        }

                        // Thực thi truy vấn và hiển thị kết quả lên DataGridView
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        DGVQuanLy.DataSource = dataTable;

                        // Format the NgayGioThem column
                        if (DGVQuanLy.Columns["NgayGioThem"] != null)
                        {
                            DGVQuanLy.Columns["NgayGioThem"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyMaKM
{
    public partial class FormTaoMaKM : Form
    {
        // Biến tạm thời để lưu trữ MaKM của dòng được chọn
        private int selectedMaKM;
        public FormTaoMaKM()
        {
            InitializeComponent();
            LoadData(); // Load data into DataGridView when the form loads
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Set DataGridView to read-only
            DGVQuanLyKM.ReadOnly = true;

            // Disable adding and deleting rows
            DGVQuanLyKM.AllowUserToAddRows = false;
            DGVQuanLyKM.AllowUserToDeleteRows = false;

            // Auto-size columns to fill the DataGridView
            DGVQuanLyKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add event handler for CellClick
            DGVQuanLyKM.CellClick += DGVQuanLyKM_CellClick;
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            string prefix = "CRMVG";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            string newCode;
            bool isUnique = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    while (!isUnique)
                    {
                        string randomPart = new string(Enumerable.Repeat(chars, 8)
                                                      .Select(s => s[random.Next(s.Length)]).ToArray());
                        newCode = prefix + randomPart;

                        string checkQuery = "SELECT COUNT(*) FROM MaKhuyenMai WHERE MaCode = @MaCode";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@MaCode", newCode);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count == 0)
                            {
                                isUnique = true;
                                txtMaCodeMoi.Text = newCode;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateExpiredPromotionCodes()
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string procedureQuery = "EXEC UpdateExpiredPromotionCodes";
                    using (SqlCommand command = new SqlCommand(procedureQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái mã khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UpdateExpiredPromotionCodes();

            string maCode = txtMaCodeMoi.Text;
            string moTa = txtMoTaMoi.Text;
            string trangThai = cbTrangThaiMoi.Text;

            DateTime ngayTao = DateTime.Now;
            DateTime ngayHetHan = ngayTao.AddDays(30);

            string inputText = txtGiaTriMoi.Text;
            decimal giaTriKM;
            if (!decimal.TryParse(inputText, out giaTriKM))
            {
                MessageBox.Show("Giá trị khuyến mãi không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM MaKhuyenMai WHERE MaCode = @MaCode";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaCode", maCode);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Mã đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO MaKhuyenMai (MaCode, MoTa, NgayTao, NgayHetHan, GiaTriKM, TrangThai)
                        VALUES (@MaCode, @MoTa, @NgayTao, @NgayHetHan, @GiaTriKM, @TrangThai)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaCode", maCode);
                        command.Parameters.AddWithValue("@MoTa", moTa);
                        command.Parameters.AddWithValue("@NgayTao", ngayTao);
                        command.Parameters.AddWithValue("@NgayHetHan", ngayHetHan);
                        command.Parameters.AddWithValue("@GiaTriKM", giaTriKM);
                        command.Parameters.AddWithValue("@TrangThai", trangThai);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm mã mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm mã mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM MaKhuyenMai";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Set the DataGridView DataSource
                        DGVQuanLyKM.DataSource = dataTable;

                        // Set DataGridView to read-only mode
                        DGVQuanLyKM.ReadOnly = true;

                        // Adjust column widths to fill the entire space
                        DGVQuanLyKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            if (selectedMaKM == 0)
            {
                MessageBox.Show("Vui lòng chọn một mã khuyến mãi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa mã khuyến mãi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, dừng lại không xóa
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Begin a transaction
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Delete from SuDungMaKM first
                            string deleteSuDungMaKMQuery = "DELETE FROM SuDungMaKM WHERE MaCode = (SELECT MaCode FROM MaKhuyenMai WHERE MaKM = @MaKM)";
                            using (SqlCommand cmd = new SqlCommand(deleteSuDungMaKMQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@MaKM", selectedMaKM);
                                cmd.ExecuteNonQuery();
                            }

                            // Then delete from MaKhuyenMai
                            string deleteMaKhuyenMaiQuery = "DELETE FROM MaKhuyenMai WHERE MaKM = @MaKM";
                            using (SqlCommand cmd = new SqlCommand(deleteMaKhuyenMaiQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@MaKM", selectedMaKM);
                                cmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            // After deleting the record, reload the data to display in the DataGridView
                            LoadData();

                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if any error occurs
                            transaction.Rollback();
                            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            string maCode = txtMaCodeMoi.Text;
            string moTa = txtMoTaMoi.Text;
            string trangThai = cbTrangThaiMoi.Text;
            decimal giaTriKM;

            if (selectedMaKM == 0 || string.IsNullOrEmpty(maCode) || string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(moTa))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và chọn một khuyến mãi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaTriMoi.Text, out giaTriKM))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và chọn một mã khuyến mãi để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi sửa
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa thông tin này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, dừng lại không sửa
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = @"
                UPDATE MaKhuyenMai
                SET MoTa = @MoTa, TrangThai = @TrangThai, GiaTriKM = @GiaTriKM
                WHERE MaCode = @MaCode";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaCode", maCode);
                        command.Parameters.AddWithValue("@MoTa", moTa);
                        command.Parameters.AddWithValue("@TrangThai", trangThai);
                        command.Parameters.AddWithValue("@GiaTriKM", giaTriKM);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private int selectedRowIndex = -1;
        private void DGVQuanLyKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVQuanLyKM.Rows[e.RowIndex];

                // Lưu trữ MaKM vào biến tạm thời
                selectedMaKM = (int)row.Cells["MaKM"].Value;

                // Điền dữ liệu vào các điều khiển tương ứng
                txtMaCodeMoi.Text = row.Cells["MaCode"].Value.ToString();
                txtMoTaMoi.Text = row.Cells["MoTa"].Value.ToString();
                txtGiaTriMoi.Text = row.Cells["GiaTriKM"].Value.ToString();
                cbTrangThaiMoi.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Connection string to the database
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security=True";

            // Query to fetch data from MaKhuyenMai table
            string queryMaKhuyenMai = "SELECT MaKM, MaCode, MoTa, NgayTao, NgayHetHan, GiaTriKM, TrangThai FROM MaKhuyenMai";

            // Query to fetch data from SuDungMaKM table joined with TaiKhoan to get TenTK
            string querySuDungMaKM = @"
        SELECT s.MaSDKM, s.MaCode, s.NgayGioSuDung, s.TrangThaiMoi, s.MaTK, t.TenTK
        FROM SuDungMaKM s
        JOIN TaiKhoan t ON s.MaTK = t.MaTK";

            // Create DataTables to hold the data
            DataTable dataTableMaKhuyenMai = new DataTable();
            DataTable dataTableSuDungMaKM = new DataTable();

            // Fetch data from the database MaKhuyenMai
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryMaKhuyenMai, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTableMaKhuyenMai);
                    }

                    using (SqlCommand command = new SqlCommand(querySuDungMaKM, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTableSuDungMaKM);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Save MaKhuyenMai data to Excel
            SaveDataTableToExcel(dataTableMaKhuyenMai, "C:\\D\\quanlyma\\MaKhuyenMai.xlsx", "MaKhuyenMai");

            // Save SuDungMaKM data to Excel
            SaveDataTableToExcel(dataTableSuDungMaKM, "C:\\D\\quanlyma\\SuDungMaKhuyenMai.xlsx", "SuDungMaKhuyenMai");
        }

        private void SaveDataTableToExcel(DataTable dataTable, string filePath, string sheetName)
        {
            // Create a new Excel workbook
            using (XLWorkbook workbook = new XLWorkbook())
            {
                // Add the DataTable as a worksheet
                workbook.Worksheets.Add(dataTable, sheetName);

                // Save the workbook to the specified file path
                try
                {
                    workbook.SaveAs(filePath);
                    MessageBox.Show($"Xuất dữ liệu thành công: {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void btnThoat_Click(object sender, EventArgs e)
        {
            FormQuanLyChung formQuanLyChung = new FormQuanLyChung();
            formQuanLyChung.Show();
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maCode = txtMaCodeMoi.Text.Trim();
            string moTa = txtMoTaMoi.Text.Trim();
            string trangThai = cbTrangThaiMoi.Text.Trim();
            string giaTriKM = txtGiaTriMoi.Text.Trim();

            // Connection string to the database
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security=True";

            // Query to fetch data from MaKhuyenMai table based on search criteria
            string query = "SELECT * FROM MaKhuyenMai WHERE MaCode LIKE @MaCode AND MoTa LIKE @MoTa AND TrangThai LIKE @TrangThai AND GiaTriKM LIKE @GiaTriKM";

            // Create a DataTable to hold the search result
            DataTable dataTable = new DataTable();

            // Fetch data from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL command
                        command.Parameters.AddWithValue("@MaCode", "%" + maCode + "%");
                        command.Parameters.AddWithValue("@MoTa", "%" + moTa + "%");
                        command.Parameters.AddWithValue("@TrangThai", "%" + trangThai + "%");
                        command.Parameters.AddWithValue("@GiaTriKM", "%" + giaTriKM + "%");

                        // Execute the SQL command and fill the DataTable with the result
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Display the search result in the DataGridView
            DGVQuanLyKM.DataSource = dataTable;
        }

        private void DGVQuanLyKM_VisibleChanged(object sender, EventArgs e)
        {
            if (DGVQuanLyKM.Visible)
            {
                LoadData();
            }
        }

        private void btnThemExcel_Click(object sender, EventArgs e)
        {
            FormThemExcel formThemExcel = new FormThemExcel();
            formThemExcel.Show();
            this.Hide();
        }
    }
}

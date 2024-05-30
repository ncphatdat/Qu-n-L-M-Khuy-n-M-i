using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QuanLyMaKM
{
    public partial class NhapMaKhuyenMai : Form
    {
        public string TenTaiKhoan { get; set; }

        public NhapMaKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnSubmitUse_Click(object sender, EventArgs e)
        {
            // Cập nhật trạng thái mã khuyến mãi hết hạn
            UpdateExpiredPromotionCodes();

            // Lấy giá trị ID từ TextBox tìm kiếm
            string maCode = txtMaCode.Text;

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Kiểm tra mã khuyến mãi và trạng thái của nó
                    string checkQuery = "SELECT TrangThai FROM MaKhuyenMai WHERE MaCode = @MaCode";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaCode", maCode);
                        object result = checkCommand.ExecuteScalar();

                        if (result != null)
                        {
                            string trangThai = result.ToString();
                            if (trangThai == "Chưa sử dụng")
                            {
                                // Cập nhật trạng thái thành "Đã sử dụng"
                                string updateQuery = "UPDATE MaKhuyenMai SET TrangThai = @TrangThai WHERE MaCode = @MaCode";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@MaCode", maCode);
                                    updateCommand.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Đã sử dụng";
                                    updateCommand.ExecuteNonQuery();

                                    // Insert into SuDungMaKM
                                    string insertQuery = "INSERT INTO SuDungMaKM (MaCode, NgayGioSuDung, TrangThaiMoi, MaTK) VALUES (@MaCode, @NgayGioSuDung, @TrangThaiMoi, (SELECT MaTK FROM TaiKhoan WHERE TenTK = @TenTK))";
                                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@MaCode", maCode);
                                        insertCommand.Parameters.AddWithValue("@NgayGioSuDung", DateTime.Now);
                                        insertCommand.Parameters.Add("@TrangThaiMoi", SqlDbType.NVarChar).Value = "Đã sử dụng";
                                        insertCommand.Parameters.AddWithValue("@TenTK", lbTenTK.Text);
                                        insertCommand.ExecuteNonQuery();
                                    }

                                    // Hiển thị thông báo thành công
                                    MessageBox.Show("Sử dụng mã thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Load the updated data into the DataGridView
                                    LoadSuDungMaKMData();
                                }
                            }
                            else
                            {
                                // Mã đã được sử dụng hoặc trạng thái khác
                                MessageBox.Show("Mã đã được sử dụng hoặc không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            // Mã không tồn tại
                            MessageBox.Show("Mã không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
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
                    // Handle the error
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái mã khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DGVMaKhuyenMai_VisibleChanged(object sender, EventArgs e)
        {
            // Load the SuDungMaKM data when the DataGridView becomes visible
            LoadSuDungMaKMData();
        }

        private void LoadSuDungMaKMData()
        {
            // Create a new DataTable to hold the data
            DataTable dataTable = new DataTable();

            // Connection string to the database
            string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security = True";

            // Create a SQL query to select data from the SuDungMaKM table
            string query = @"
        SELECT SuDungMaKM.MaSDKM, SuDungMaKM.MaCode, SuDungMaKM.NgayGioSuDung, SuDungMaKM.TrangThaiMoi, SuDungMaKM.MaTK, TaiKhoan.TenTK
        FROM SuDungMaKM
        JOIN TaiKhoan ON SuDungMaKM.MaTK = TaiKhoan.MaTK";

            // Create a new SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlDataAdapter with the query and connection
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable with data from the SuDungMaKM table
                        dataAdapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
                    DGVMaKhuyenMai.DataSource = dataTable;

                    // Set the DataGridView to read-only mode
                    DGVMaKhuyenMai.ReadOnly = true;

                    // Adjust the columns to fill the DataGridView width
                    DGVMaKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DGVMaKhuyenMai.AutoResizeColumns();
                    DGVMaKhuyenMai.AutoResizeRows();
                    DGVMaKhuyenMai.AllowUserToAddRows = false;
                    DGVMaKhuyenMai.AllowUserToDeleteRows = false;
                    DGVMaKhuyenMai.AllowUserToOrderColumns = true;
                    DGVMaKhuyenMai.AllowUserToResizeColumns = true;
                    DGVMaKhuyenMai.AllowUserToResizeRows = false;

                    // Hide the MaTK column
                    if (DGVMaKhuyenMai.Columns["MaTK"] != null)
                    {
                        DGVMaKhuyenMai.Columns["MaTK"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur
                    MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NhapMaKhuyenMai_Load(object sender, EventArgs e)
        {
            lbTenTK.Text = TenTaiKhoan;
        }
    }
}

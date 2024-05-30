using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Data.SqlClient;

namespace QuanLyMaKM
{
    public partial class FormThemExcel : Form
    {
        public FormThemExcel()
        {
            InitializeComponent();
        }

        private void btnThemExcel_Click(object sender, EventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set properties for OpenFileDialog
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Chọn tệp Excel";
            openFileDialog.Multiselect = false; // Allow only single file selection

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportDataFromExcel(openFileDialog.FileName);
                    MessageBox.Show("Thêm file thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm file không thành công\n" + ex.Message);
                }
            }
        }

        private void ImportDataFromExcel(string filePath)
        {
            // Set the license context to non-commercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();

                // Add columns to DataTable
                for (int i = excelWorksheet.Dimension.Start.Column; i <= excelWorksheet.Dimension.End.Column; i++)
                {
                    var cellValue = excelWorksheet.Cells[1, i].Value;
                    dataTable.Columns.Add(cellValue != null ? cellValue.ToString() : $"Column{i}");
                }

                // Add rows to DataTable
                for (int i = excelWorksheet.Dimension.Start.Row + 1; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    List<string> listRows = new List<string>();
                    for (int j = excelWorksheet.Dimension.Start.Column; j <= excelWorksheet.Dimension.End.Column; j++)
                    {
                        var cellValue = excelWorksheet.Cells[i, j].Value;
                        listRows.Add(cellValue != null ? cellValue.ToString() : string.Empty);
                    }
                    dataTable.Rows.Add(listRows.ToArray());
                }

                // Bind to DataGridView
                DGVMaKhuyenMai.DataSource = dataTable;

                // Adjust columns to fit the content
                DGVMaKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FormTaoMaKM formTaoMaKM = new FormTaoMaKM();
            formTaoMaKM.Show();
            this.Close();
        }

        private void btnThemMa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu trong DataGridView không
            if (DGVMaKhuyenMai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lặp qua từng hàng của DataGridView
            foreach (DataGridViewRow row in DGVMaKhuyenMai.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng chứa dữ liệu
                if (!row.IsNewRow)
                {
                    // Lấy dữ liệu từ các cột của hàng
                    string maCode = row.Cells["MaCode"].Value.ToString();
                    string moTa = row.Cells["MoTa"].Value.ToString();
                    string giaTriKM = row.Cells["GiaTriKM"].Value.ToString();
                    string trangThai = row.Cells["TrangThai"].Value.ToString();

                    // Tạo NgayTao là ngày hiện tại
                    DateTime ngayTao = DateTime.Now;

                    // Tạo NgayHetHan là NgayTao cộng thêm 30 ngày
                    DateTime ngayHetHan = ngayTao.AddDays(30);

                    // Insert dữ liệu vào bảng MaKhuyenMai trong cơ sở dữ liệu
                    string connectionString = "Data Source=DESKTOP-826VIMJ\\SQLEXPRESS; Database=QuanLyMaKM1; Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

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
                                    // Thực hiện các thao tác cần thiết sau khi thêm mã thành công
                                }
                                else
                                {
                                    MessageBox.Show("Thêm mã mới không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            MessageBox.Show("Tất cả mã đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}

namespace QuanLyMaKM
{
    partial class FormTaoMaKM
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCodeMoi = new System.Windows.Forms.TextBox();
            this.txtGiaTriMoi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTrangThaiMoi = new System.Windows.Forms.ComboBox();
            this.btnThemExcel = new System.Windows.Forms.Button();
            this.btnTaoMa = new System.Windows.Forms.Button();
            this.DGVQuanLyKM = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtMoTaMoi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuanLyKM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(565, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá trị code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(565, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả:";
            // 
            // txtMaCodeMoi
            // 
            this.txtMaCodeMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCodeMoi.Location = new System.Drawing.Point(140, 84);
            this.txtMaCodeMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaCodeMoi.Name = "txtMaCodeMoi";
            this.txtMaCodeMoi.Size = new System.Drawing.Size(256, 27);
            this.txtMaCodeMoi.TabIndex = 3;
            // 
            // txtGiaTriMoi
            // 
            this.txtGiaTriMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTriMoi.Location = new System.Drawing.Point(696, 81);
            this.txtGiaTriMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiaTriMoi.Name = "txtGiaTriMoi";
            this.txtGiaTriMoi.Size = new System.Drawing.Size(392, 27);
            this.txtGiaTriMoi.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(20, 599);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(133, 47);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(261, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(524, 46);
            this.label4.TabIndex = 8;
            this.label4.Text = "QUẢN LÝ MÃ KHUYẾN MÃI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Trạng thái:";
            // 
            // cbTrangThaiMoi
            // 
            this.cbTrangThaiMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThaiMoi.FormattingEnabled = true;
            this.cbTrangThaiMoi.Items.AddRange(new object[] {
            "Chưa sử dụng"});
            this.cbTrangThaiMoi.Location = new System.Drawing.Point(140, 126);
            this.cbTrangThaiMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTrangThaiMoi.Name = "cbTrangThaiMoi";
            this.cbTrangThaiMoi.Size = new System.Drawing.Size(171, 28);
            this.cbTrangThaiMoi.TabIndex = 10;
            // 
            // btnThemExcel
            // 
            this.btnThemExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemExcel.Location = new System.Drawing.Point(436, 599);
            this.btnThemExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemExcel.Name = "btnThemExcel";
            this.btnThemExcel.Size = new System.Drawing.Size(133, 47);
            this.btnThemExcel.TabIndex = 11;
            this.btnThemExcel.Text = "Thêm Excel";
            this.btnThemExcel.UseVisualStyleBackColor = true;
            this.btnThemExcel.Click += new System.EventHandler(this.btnThemExcel_Click);
            // 
            // btnTaoMa
            // 
            this.btnTaoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMa.Location = new System.Drawing.Point(404, 85);
            this.btnTaoMa.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoMa.Name = "btnTaoMa";
            this.btnTaoMa.Size = new System.Drawing.Size(141, 28);
            this.btnTaoMa.TabIndex = 12;
            this.btnTaoMa.Text = "Tạo mã";
            this.btnTaoMa.UseVisualStyleBackColor = true;
            this.btnTaoMa.Click += new System.EventHandler(this.btnTaoMa_Click);
            // 
            // DGVQuanLyKM
            // 
            this.DGVQuanLyKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVQuanLyKM.Location = new System.Drawing.Point(20, 192);
            this.DGVQuanLyKM.Margin = new System.Windows.Forms.Padding(4);
            this.DGVQuanLyKM.Name = "DGVQuanLyKM";
            this.DGVQuanLyKM.RowHeadersWidth = 51;
            this.DGVQuanLyKM.Size = new System.Drawing.Size(1069, 363);
            this.DGVQuanLyKM.TabIndex = 13;
            this.DGVQuanLyKM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVQuanLyKM_CellClick);
            this.DGVQuanLyKM.VisibleChanged += new System.EventHandler(this.DGVQuanLyKM_VisibleChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(159, 599);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(133, 47);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(297, 599);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(133, 47);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(713, 599);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(133, 47);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(575, 599);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(133, 47);
            this.btnXuatExcel.TabIndex = 17;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(956, 599);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 47);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMoTaMoi
            // 
            this.txtMoTaMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTaMoi.Location = new System.Drawing.Point(696, 130);
            this.txtMoTaMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMoTaMoi.Name = "txtMoTaMoi";
            this.txtMoTaMoi.Size = new System.Drawing.Size(392, 27);
            this.txtMoTaMoi.TabIndex = 19;
            // 
            // FormTaoMaKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 697);
            this.Controls.Add(this.txtMoTaMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.DGVQuanLyKM);
            this.Controls.Add(this.btnTaoMa);
            this.Controls.Add(this.btnThemExcel);
            this.Controls.Add(this.cbTrangThaiMoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGiaTriMoi);
            this.Controls.Add(this.txtMaCodeMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTaoMaKM";
            this.Text = "Form Tạo Mã Khuyến Mãi";
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuanLyKM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCodeMoi;
        private System.Windows.Forms.TextBox txtGiaTriMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTrangThaiMoi;
        private System.Windows.Forms.Button btnThemExcel;
        private System.Windows.Forms.Button btnTaoMa;
        private System.Windows.Forms.DataGridView DGVQuanLyKM;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMoTaMoi;
    }
}
namespace QuanLyMaKM
{
    partial class FormThemExcel
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
            this.btnThemExcel = new System.Windows.Forms.Button();
            this.DGVMaKhuyenMai = new System.Windows.Forms.DataGridView();
            this.btnThemMa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemExcel
            // 
            this.btnThemExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemExcel.Location = new System.Drawing.Point(304, 47);
            this.btnThemExcel.Name = "btnThemExcel";
            this.btnThemExcel.Size = new System.Drawing.Size(163, 37);
            this.btnThemExcel.TabIndex = 0;
            this.btnThemExcel.Text = "Thêm file excel";
            this.btnThemExcel.UseVisualStyleBackColor = true;
            this.btnThemExcel.Click += new System.EventHandler(this.btnThemExcel_Click);
            // 
            // DGVMaKhuyenMai
            // 
            this.DGVMaKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMaKhuyenMai.Location = new System.Drawing.Point(62, 90);
            this.DGVMaKhuyenMai.Name = "DGVMaKhuyenMai";
            this.DGVMaKhuyenMai.RowHeadersWidth = 51;
            this.DGVMaKhuyenMai.RowTemplate.Height = 24;
            this.DGVMaKhuyenMai.Size = new System.Drawing.Size(671, 285);
            this.DGVMaKhuyenMai.TabIndex = 2;
            // 
            // btnThemMa
            // 
            this.btnThemMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMa.Location = new System.Drawing.Point(62, 402);
            this.btnThemMa.Name = "btnThemMa";
            this.btnThemMa.Size = new System.Drawing.Size(228, 36);
            this.btnThemMa.TabIndex = 3;
            this.btnThemMa.Text = "Thêm mã khuyến mãi";
            this.btnThemMa.UseVisualStyleBackColor = true;
            this.btnThemMa.Click += new System.EventHandler(this.btnThemMa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(552, 402);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(181, 36);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FormThemExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThemMa);
            this.Controls.Add(this.DGVMaKhuyenMai);
            this.Controls.Add(this.btnThemExcel);
            this.Name = "FormThemExcel";
            this.Text = "FormThemExcel";
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaKhuyenMai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThemExcel;
        private System.Windows.Forms.DataGridView DGVMaKhuyenMai;
        private System.Windows.Forms.Button btnThemMa;
        private System.Windows.Forms.Button btnThoat;
    }
}
namespace QuanLyMaKM
{
    partial class NhapMaKhuyenMai
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
            this.txtMaCode = new System.Windows.Forms.TextBox();
            this.btnSubmitUse = new System.Windows.Forms.Button();
            this.DGVMaKhuyenMai = new System.Windows.Forms.DataGridView();
            this.lbTenTK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khuyến Mãi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập mã code:";
            // 
            // txtMaCode
            // 
            this.txtMaCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCode.Location = new System.Drawing.Point(210, 132);
            this.txtMaCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaCode.Name = "txtMaCode";
            this.txtMaCode.Size = new System.Drawing.Size(391, 30);
            this.txtMaCode.TabIndex = 2;
            // 
            // btnSubmitUse
            // 
            this.btnSubmitUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitUse.Location = new System.Drawing.Point(607, 132);
            this.btnSubmitUse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmitUse.Name = "btnSubmitUse";
            this.btnSubmitUse.Size = new System.Drawing.Size(150, 30);
            this.btnSubmitUse.TabIndex = 3;
            this.btnSubmitUse.Text = "Áp dụng";
            this.btnSubmitUse.UseVisualStyleBackColor = true;
            this.btnSubmitUse.Click += new System.EventHandler(this.btnSubmitUse_Click);
            // 
            // DGVMaKhuyenMai
            // 
            this.DGVMaKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMaKhuyenMai.Location = new System.Drawing.Point(33, 196);
            this.DGVMaKhuyenMai.Margin = new System.Windows.Forms.Padding(4);
            this.DGVMaKhuyenMai.Name = "DGVMaKhuyenMai";
            this.DGVMaKhuyenMai.RowHeadersWidth = 51;
            this.DGVMaKhuyenMai.Size = new System.Drawing.Size(724, 272);
            this.DGVMaKhuyenMai.TabIndex = 6;
            this.DGVMaKhuyenMai.VisibleChanged += new System.EventHandler(this.DGVMaKhuyenMai_VisibleChanged);
            // 
            // lbTenTK
            // 
            this.lbTenTK.AutoSize = true;
            this.lbTenTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenTK.Location = new System.Drawing.Point(29, 37);
            this.lbTenTK.Name = "lbTenTK";
            this.lbTenTK.Size = new System.Drawing.Size(0, 20);
            this.lbTenTK.TabIndex = 7;
            // 
            // NhapMaKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.lbTenTK);
            this.Controls.Add(this.DGVMaKhuyenMai);
            this.Controls.Add(this.btnSubmitUse);
            this.Controls.Add(this.txtMaCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NhapMaKhuyenMai";
            this.Text = "Nhập mã khuyến mãi";
            this.Load += new System.EventHandler(this.NhapMaKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMaKhuyenMai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaCode;
        private System.Windows.Forms.Button btnSubmitUse;
        private System.Windows.Forms.DataGridView DGVMaKhuyenMai;
        private System.Windows.Forms.Label lbTenTK;
    }
}


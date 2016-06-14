namespace DelaunayTriangulation {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.gbx_canvas = new System.Windows.Forms.GroupBox();
            this.btn_triangulate = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gbx_canvas
            // 
            this.gbx_canvas.Location = new System.Drawing.Point(12, 12);
            this.gbx_canvas.Name = "gbx_canvas";
            this.gbx_canvas.Size = new System.Drawing.Size(1309, 830);
            this.gbx_canvas.TabIndex = 0;
            this.gbx_canvas.TabStop = false;
            this.gbx_canvas.Text = "画布";
            this.gbx_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.gbx_canvas_Paint);
            // 
            // btn_triangulate
            // 
            this.btn_triangulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_triangulate.Location = new System.Drawing.Point(1109, 848);
            this.btn_triangulate.Name = "btn_triangulate";
            this.btn_triangulate.Size = new System.Drawing.Size(203, 23);
            this.btn_triangulate.TabIndex = 1;
            this.btn_triangulate.Text = "生成delaunay三角网";
            this.btn_triangulate.UseVisualStyleBackColor = true;
            this.btn_triangulate.Click += new System.EventHandler(this.btn_triangulate_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.Location = new System.Drawing.Point(1028, 848);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 877);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_triangulate);
            this.Controls.Add(this.gbx_canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_canvas;
        private System.Windows.Forms.Button btn_triangulate;
        private System.Windows.Forms.Button btn_clear;
    }
}


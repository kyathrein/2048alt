namespace _2048alt
{
    partial class F_Menu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.normal = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // normal
            // 
            this.normal.Location = new System.Drawing.Point(20, 18);
            this.normal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(433, 111);
            this.normal.TabIndex = 0;
            this.normal.Text = "ノーマル";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.Click += new System.EventHandler(this.button1_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(20, 412);
            this.close.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(433, 111);
            this.close.TabIndex = 1;
            this.close.Text = "終了";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // F_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 542);
            this.Controls.Add(this.close);
            this.Controls.Add(this.normal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "F_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button normal;
        private System.Windows.Forms.Button close;
    }
}


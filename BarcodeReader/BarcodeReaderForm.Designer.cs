namespace BarcodeReader
{
    partial class BarcodeReaderForm
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
            this.BarcodeImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SharpnessLabel = new System.Windows.Forms.Label();
            this.SharpnessTrack = new System.Windows.Forms.TrackBar();
            this.FileButton = new System.Windows.Forms.Button();
            this.OpenImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ResultText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodeImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SharpnessTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // BarcodeImage
            // 
            this.BarcodeImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BarcodeImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarcodeImage.Location = new System.Drawing.Point(0, 0);
            this.BarcodeImage.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BarcodeImage.Name = "BarcodeImage";
            this.BarcodeImage.Size = new System.Drawing.Size(1220, 809);
            this.BarcodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BarcodeImage.TabIndex = 0;
            this.BarcodeImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SharpnessLabel);
            this.panel1.Controls.Add(this.SharpnessTrack);
            this.panel1.Controls.Add(this.FileButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1220, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 900);
            this.panel1.TabIndex = 0;
            // 
            // SharpnessLabel
            // 
            this.SharpnessLabel.AutoSize = true;
            this.SharpnessLabel.Location = new System.Drawing.Point(13, 89);
            this.SharpnessLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SharpnessLabel.Name = "SharpnessLabel";
            this.SharpnessLabel.Size = new System.Drawing.Size(146, 24);
            this.SharpnessLabel.TabIndex = 1;
            this.SharpnessLabel.Text = "シャープネス：0";
            // 
            // SharpnessTrack
            // 
            this.SharpnessTrack.Location = new System.Drawing.Point(7, 119);
            this.SharpnessTrack.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.SharpnessTrack.Maximum = 100;
            this.SharpnessTrack.Name = "SharpnessTrack";
            this.SharpnessTrack.Size = new System.Drawing.Size(517, 90);
            this.SharpnessTrack.TabIndex = 2;
            this.SharpnessTrack.Scroll += new System.EventHandler(this.SharpnessTrack_Scroll);
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(7, 24);
            this.FileButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(517, 46);
            this.FileButton.TabIndex = 0;
            this.FileButton.Text = "ファイルを開く";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // OpenImageFileDialog
            // 
            this.OpenImageFileDialog.AddExtension = false;
            this.OpenImageFileDialog.Filter = "画像ファイル|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            this.OpenImageFileDialog.Title = "画像ファイルを開く";
            // 
            // ResultText
            // 
            this.ResultText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultText.Location = new System.Drawing.Point(0, 809);
            this.ResultText.Multiline = true;
            this.ResultText.Name = "ResultText";
            this.ResultText.Size = new System.Drawing.Size(1220, 91);
            this.ResultText.TabIndex = 1;
            // 
            // BarcodeReaderForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1755, 900);
            this.Controls.Add(this.BarcodeImage);
            this.Controls.Add(this.ResultText);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "BarcodeReaderForm";
            this.Text = "BarcodeReader";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.BarcodeReaderForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.BarcodeReaderForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.BarcodeImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SharpnessTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BarcodeImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.OpenFileDialog OpenImageFileDialog;
        private System.Windows.Forms.TextBox ResultText;
        private System.Windows.Forms.Label SharpnessLabel;
        private System.Windows.Forms.TrackBar SharpnessTrack;
    }
}


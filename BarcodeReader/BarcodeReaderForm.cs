using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BarcodeReader
{
    public partial class BarcodeReaderForm : Form
    {
        private Image _loadedImage;
        private Image _modifiedImage;

        public BarcodeReaderForm()
        {
            InitializeComponent();
        }

        private void BarcodeReaderForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void BarcodeReaderForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = e.Data.GetData(DataFormats.FileDrop, false) as string[];
            OpenImageFile(fileName[0]);
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            if (OpenImageFileDialog.ShowDialog(this) != DialogResult.OK)
                return;
            OpenImageFile(OpenImageFileDialog.FileName);
        }

        private void OpenImageFile(string imagePath)
        {
            if (_loadedImage != null)
            {
                _loadedImage.Dispose();
                _loadedImage = null;
            }
            _loadedImage = Image.FromFile(imagePath);
            if (_loadedImage is Bitmap)
            {
                ScanBarcode();
            }
            else
            {
                _loadedImage.Dispose();
                _loadedImage = null;
                BarcodeImage.Image = null;
            }
        }

        private void SharpnessTrack_Scroll(object sender, EventArgs e)
        {
            SharpnessLabel.Text = String.Format("シャープネス：{0}", (float)SharpnessTrack.Value / SharpnessTrack.Maximum);
            ScanBarcode();
        }

        private void ScanBarcode()
        {
            if (_loadedImage == null)
            {
                return;
            }
            if (_modifiedImage != null)
            {
                _modifiedImage.Dispose();
                _modifiedImage = null;
            }
            _modifiedImage = AdjustSharpness(_loadedImage as Bitmap, (float)SharpnessTrack.Value / SharpnessTrack.Maximum);
            BarcodeImage.Image = _modifiedImage;
            using (ZBar.ImageScanner scanner = new ZBar.ImageScanner())
            {
                scanner.SetConfiguration(ZBar.SymbolType.None, ZBar.Config.XDensity, 3);
                scanner.SetConfiguration(ZBar.SymbolType.None, ZBar.Config.YDensity, 3);
                List<ZBar.Symbol> symbols = scanner.Scan(_modifiedImage);
                ResultText.Clear();
                foreach (ZBar.Symbol symbol in symbols)
                {
                    if (ResultText.TextLength > 0)
                    {
                        ResultText.Text += Environment.NewLine;
                    }
                    ResultText.Text += symbol.Data;
                }
            }
        }

        static public Bitmap AdjustSharpness(Bitmap srcImg, float level)
        {
            Bitmap dstImg = new Bitmap(srcImg);

            BitmapData srcDat = srcImg.LockBits(
                new Rectangle(0, 0, srcImg.Width, srcImg.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);
            byte[] srcBuf = new byte[srcImg.Width * srcImg.Height * 4];
            Marshal.Copy(srcDat.Scan0, srcBuf, 0, srcBuf.Length);

            BitmapData dstDat = dstImg.LockBits(
                new Rectangle(0, 0, dstImg.Width, dstImg.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);
            byte[] dstBuf = new byte[dstImg.Width * dstImg.Height * 4];
            Marshal.Copy(dstDat.Scan0, dstBuf, 0, dstBuf.Length);

            for (int i = 1; i < srcImg.Height - 1; i++)
            {

                int dy1 = (i - 1) * (srcImg.Width * 4);
                int dy = i * (srcImg.Width * 4);
                int dy2 = (i + 1) * (srcImg.Width * 4);

                for (int j = 1; j < srcImg.Width - 1; j++)
                {
                    int dx1 = (j - 1) * 4;
                    int dx = j * 4;
                    int dx2 = (j + 1) * 4;

                    for (int k = 0; k < 3; k++)
                    {
                        int value = (int)((float)srcBuf[dy + dx + k] * (1f + level * 4))
                                  - (int)((float)srcBuf[dy1 + dx + k] * level)
                                  - (int)((float)srcBuf[dy + dx1 + k] * level)
                                  - (int)((float)srcBuf[dy + dx2 + k] * level)
                                  - (int)((float)srcBuf[dy2 + dx + k] * level);
                        value = Math.Min(value, 255);
                        value = Math.Max(value, 0);

                        dstBuf[dy + dx + k] = (byte)value;
                    }
                }
            }
            Marshal.Copy(dstBuf, 0, dstDat.Scan0, dstBuf.Length);
            dstImg.UnlockBits(dstDat);
            srcImg.UnlockBits(srcDat);
            return dstImg;
        }
    }
}

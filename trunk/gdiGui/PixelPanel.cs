using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace anticulturematrix
{
    class PixelPanel : PictureBox
    {
        #region Fields
        private int targetWidth;

        private int targetHeight;

        private AtomMatrix atomMatrix; //PixelPanel's model

        private Pen pen = new Pen(new Color());

        private Bitmap bitmap;

        private Size resized;

        private Bitmap resampledBitmap;
        #endregion

        #region Constructor
        public PixelPanel()
        {
            this.targetWidth = MainWindow.surfaceWidth;
            this.targetHeight = MainWindow.surfaceHeight;
            resized = new Size(targetWidth, targetHeight);
            resampledBitmap = new Bitmap(targetWidth, targetHeight);
        }
        #endregion

        #region Public Methods
        public void ShowMatrix(AtomMatrix atomMatrix)
        {
            this.atomMatrix = atomMatrix;

            if (bitmap == null)
                bitmap = new Bitmap(atomMatrix.Width, atomMatrix.Height);

            for (int x = 0; x < atomMatrix.Width; ++x)
                for (int y = 0; y < atomMatrix.Height; ++y)
                    bitmap.SetPixel(x, y, atomMatrix[x, y].Color);

            this.Image = ResizeImage(bitmap);

            Invalidate();//supposed to calls OnPaint()
        }
        #endregion

        #region Private Methods
        private Image ResizeImage(Image imgToResize)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)resampledBitmap.Width / (float)sourceWidth);
            nPercentH = ((float)resampledBitmap.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            //Bitmap largeBitmap = new Bitmap(destWidth, destHeight);
            Graphics graphics = Graphics.FromImage((Image)resampledBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            graphics.Dispose();

            return (Image)resampledBitmap;
        }
        #endregion
    }
}


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageCreator.Logic
{
    public static class ImageCreator
    {
        public static Stream Create(EllipseDimensions dimensions){
            Bitmap bitmap = new Bitmap(1000, 800, PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);

            Brush brush = new LinearGradientBrush(new Point(0, 0), new Point(1000, 800), Color.Red, Color.Blue);
            graphics.FillEllipse(brush, dimensions.X, dimensions.Y, dimensions.Widht, dimensions.Height);

            MemoryStream result = new MemoryStream();
            bitmap.Save(result, ImageFormat.Jpeg);
            result.Seek(0, SeekOrigin.Begin);

            return result;
        }

    }
}
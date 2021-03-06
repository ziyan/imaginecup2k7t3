using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace Omni.Service
{
    public static class Captcha
    {
        public static string GetCaptchaText()
        {
            return Util.Common.GetRandomString(Util.Configuration.LocalSettings["Omni.Service.Captcha.CharacterSet"],
                Convert.ToInt32(Util.Configuration.LocalSettings["Omni.Service.Captcha.Length"]));
        }
        public static byte[] GetCaptchaImage(string text, int width, int height, Color bgColor, Color frontColor)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, width, height);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(bgColor))
            {
                g.FillRectangle(b, rect);
            }
            int emSize = (int)(width * 2 / text.Length);
            string[] fonts = Util.Configuration.LocalSettings["Omni.Service.Captcha.FontSet"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            FontFamily family = new FontFamily(fonts[Util.Common.Rand.Next(fonts.Length - 1)].Trim());
            Font font = new Font(family, emSize);
            SizeF measured = new SizeF(0, 0);
            SizeF workingSize = new SizeF(width, height);
            while (emSize > 2 &&
                (measured = g.MeasureString(text, font)).Width > workingSize.Width ||
                measured.Height > workingSize.Height)
            {
                font.Dispose();
                font = new Font(family, emSize -= 2);
            }
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            SolidBrush sBrush = new SolidBrush(frontColor);
            g.FillPath(sBrush, path);

            // Iterate over every pixel
            double distort = Util.Common.Rand.Next(Convert.ToInt32(Util.Configuration.LocalSettings["Omni.Service.Captcha.DistortRangeLower"]), Convert.ToInt32(Util.Configuration.LocalSettings["Omni.Service.Captcha.DistortRangeHigher"])) * (Util.Common.Rand.Next(Convert.ToInt32(Util.Configuration.LocalSettings["Omni.Service.Captcha.DistortRange"])) == 1 ? 1 : -1);

            // Copy the image so that we're always using the original for source color
            using (Bitmap copy = (Bitmap)bitmap.Clone())
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Adds a simple wave
                        int newX = (int)(x + (distort * Math.Sin(Math.PI * y / 84.0)));
                        int newY = (int)(y + (distort * Math.Cos(Math.PI * x / 44.0)));
                        if (newX < 0 || newX >= width) newX = 0;
                        if (newY < 0 || newY >= height) newY = 0;
                        bitmap.SetPixel(x, y, copy.GetPixel(newX, newY));
                    }
                }
            }

            // Clean up.
            font.Dispose();
            sBrush.Dispose();
            g.Dispose();
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            byte[] image = ms.GetBuffer();
            ms.Dispose();
            return image;
        }
    }
}

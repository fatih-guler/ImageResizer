using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagResizer
{
    // Static Class that We reach from main method.
    public static class Resizer
    {
        // Method that performs resizing operation
        public static Image ResizeImage(System.Drawing.Image imgToResize, Size size)
        {
            // Get the image current width
            int sourceWidth = imgToResize.Width;
            // Get the image current height
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calculate width and height with new desired size
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            nPercent = Math.Min(nPercentW, nPercentH);
            // New Width and Height
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
        // Method that check the rotate of image and rotate in  case the photo rotated itself before resizing.
        public static void Rotate(this Image img)
        {
            var props= img.PropertyItems.FirstOrDefault(x => x.Id == 274);
            if(props != null)
            {
                int orientation = props.Value[0];
                if (orientation == 6)
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (orientation == 8)
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

    }
}

using System;
using System.Drawing;
using CoreGraphics;
using UIKit;

namespace SpaceProgram.iOS.Extensions
{
    public static class ImageExtensions
    {
        public static UIImage Crop(this UIImage sourceImage, float width, float height)
        {
            UIGraphics.BeginImageContext(new CGSize(width, height));

            sourceImage.Draw(new CGRect(0, 0, width, height));

            var resultImage = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            return resultImage;
        }
    }
}

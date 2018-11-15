using System;

using Foundation;
using UIKit;

namespace SpaceProgram.iOS.Cells
{
    public partial class PhotoCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("PhotoCell");
        public static readonly UINib Nib;

        public UIImageView PhotoImageView => photoImageView;

        static PhotoCell()
        {
            Nib = UINib.FromName("PhotoCell", NSBundle.MainBundle);
        }

        public static PhotoCell Create()
        {
            return (PhotoCell)Nib.Instantiate(null, null)[0];
        }

        protected PhotoCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}

using System;

using Foundation;
using SpaceProgram.iOS.Models;
using UIKit;

namespace SpaceProgram.iOS.Cells
{
    public partial class LaunchCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("LaunchCell");
        public static readonly UINib Nib;

        static LaunchCell()
        {
            Nib = UINib.FromName("LaunchCell", NSBundle.MainBundle);
        }

        protected LaunchCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateCell(Launch launch)
        {
            label.Text = launch.Name;
        }
    }
}

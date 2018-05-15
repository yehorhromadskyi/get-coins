using System;

using Foundation;
using GetCoins.iOS.Models;
using UIKit;

namespace GetCoins.iOS.Cells
{
    public partial class RoverCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("RoverCell");
        public static readonly UINib Nib;

        static RoverCell()
        {
            Nib = UINib.FromName("RoverCell", NSBundle.MainBundle);
        }

        protected RoverCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

		public RoverCell() : base (UITableViewCellStyle.Default, Key)
		{
			
		}

		public void UpdateCell(Rover rover)
		{
			nameLabel.Text = rover.Name;
            statusLabel.Text = rover.Status;

			image.Image = UIImage.FromBundle("Rover");
		}
    }
}

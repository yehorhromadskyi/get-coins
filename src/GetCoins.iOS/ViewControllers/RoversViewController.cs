using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace GetCoins.iOS.ViewControllers
{
    [Register("RoversViewController")]
    public class RoversViewController : UITableViewController
    {
        public RoversViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }
    }
}
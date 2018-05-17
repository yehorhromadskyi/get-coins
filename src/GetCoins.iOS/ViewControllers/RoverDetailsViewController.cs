using System;
using Foundation;
using UIKit;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoverDetailsViewController : UIViewController
    {
		public RoverDetailsViewController(IntPtr handle)
            : base(handle)
        {
        }

		public RoverDetailsViewController() : base("RoverDetailsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
		}

		//[Action("SaveRoverDetails:")]
		//public void SaveRoverDetails(UIStoryboardSegue segue)
        //{
		//	Console.WriteLine("Save");
        //}
    }
}


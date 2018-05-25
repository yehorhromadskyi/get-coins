// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace GetCoins.iOS.ViewControllers
{
    [Register ("RoverDetailsViewController")]
    partial class RoverDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView camerasTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (camerasTableView != null) {
                camerasTableView.Dispose ();
                camerasTableView = null;
            }
        }
    }
}
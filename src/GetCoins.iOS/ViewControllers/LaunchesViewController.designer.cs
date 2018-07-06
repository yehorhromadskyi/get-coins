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
    [Register ("LaunchesViewController")]
    partial class LaunchesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView launchesTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView spinner { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (launchesTableView != null) {
                launchesTableView.Dispose ();
                launchesTableView = null;
            }

            if (spinner != null) {
                spinner.Dispose ();
                spinner = null;
            }
        }
    }
}
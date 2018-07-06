// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace GetCoins.iOS.ViewControllers
{
    [Register ("RoversViewController")]
    partial class RoversViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView roversTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView spinner { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (roversTableView != null) {
                roversTableView.Dispose ();
                roversTableView = null;
            }

            if (spinner != null) {
                spinner.Dispose ();
                spinner = null;
            }
        }
    }
}
// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace GetCoins.iOS.Cells
{
    [Register ("PhotoCell")]
    partial class PhotoCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView photoImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (photoImageView != null) {
                photoImageView.Dispose ();
                photoImageView = null;
            }
        }
    }
}
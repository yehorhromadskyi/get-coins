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

namespace SpaceProgram.iOS.ViewControllers
{
    [Register ("RoverCameraPhotosViewController")]
    partial class RoverCameraPhotosViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView photosCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (photosCollectionView != null) {
                photosCollectionView.Dispose ();
                photosCollectionView = null;
            }
        }
    }
}
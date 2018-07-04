using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using GetCoins.iOS.Cells;
using GetCoins.iOS.Models;
using GetCoins.iOS.Services;
using UIKit;
using CoreGraphics;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoverCameraPhotosViewController : UIViewController
    {
        string _rover;
        string _camera;

        PhotosDataSource _photosSource;
        UITapGestureRecognizer _photosTapGesture;

        public RoverCameraPhotosViewController(IntPtr handle)
            : base(handle)
        {
        }

        public RoverCameraPhotosViewController() : base("RoverCameraPhotosViewController", null)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            photosCollectionView.RegisterNibForCell(PhotoCell.Nib, PhotoCell.Key);

            var apiService = new NasaApiService();

            var photos = await apiService.GetPhotosAsync(_rover, _camera);

            _photosSource = new PhotosDataSource(photos);

            _photosTapGesture = new UITapGestureRecognizer(PhotosCollectionTapped);

            photosCollectionView.AddGestureRecognizer(_photosTapGesture);

            photosCollectionView.Delegate = new PhotosCollectionDelegateFlowLayout();

            photosCollectionView.DataSource = _photosSource;
            photosCollectionView.ReloadData();
        }

        void PhotosCollectionTapped()
        {
            var point = _photosTapGesture.LocationInView(photosCollectionView);
            var indexPath = photosCollectionView.IndexPathForItemAtPoint(point);

            if (indexPath != null)
            {
                var cell = (PhotoCell)photosCollectionView.CellForItem(indexPath);
                var photo = _photosSource.Photos[indexPath.Row];

                var fullImageView = new UIImageView(cell.PhotoImageView.Image);
                fullImageView.Frame = UIScreen.MainScreen.Bounds;
                fullImageView.BackgroundColor = UIColor.Black;
                fullImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                fullImageView.UserInteractionEnabled = true;

                var dismissGesture = new UITapGestureRecognizer(DismissFullImage);
                fullImageView.AddGestureRecognizer(dismissGesture);

                NavigationController.NavigationBarHidden = true;
                TabBarController.TabBar.Hidden = true;
                View.AddSubview(fullImageView);
            }
        }

        private void DismissFullImage(UITapGestureRecognizer recognizer)
        {
            NavigationController.NavigationBarHidden = false;
            TabBarController.TabBar.Hidden = false;
            recognizer.View.RemoveFromSuperview();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        internal void SetNavigationParameters(string rover, string camera)
        {
            _rover = rover;
            _camera = camera;
        }
    }

    public class PhotosDataSource : UICollectionViewDataSource
    {
        readonly List<Photo> _photos = new List<Photo>();

        public List<Photo> Photos => _photos;

        public PhotosDataSource(List<Photo> photos)
        {
            _photos = photos;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var photo = _photos[indexPath.Row];

            var cell = (PhotoCell)collectionView.DequeueReusableCell(PhotoCell.Key, indexPath);

            Task.Run(async () =>
            {
                //using (var url = new NSUrl(photo.Image))
                //using (var data = NSData.FromUrl(url))

                var imageBytes = await HttpService.Client.GetByteArrayAsync(photo.Image);
                var image = UIImage.LoadFromData(NSData.FromArray(imageBytes));

                InvokeOnMainThread(() =>
                {
                    cell.PhotoImageView.Image = image;

                    //var isVisible = collectionView.IndexPathsForVisibleItems
                    //                              .Contains(indexPath);
                });
            });

            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section) => _photos.Count;
    }

    public class PhotosCollectionDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var width = collectionView.Bounds.Width;

            return new CGSize(width * 0.48, width * 0.48);
        }
    }
}


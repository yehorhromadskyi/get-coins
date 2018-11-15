using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using GetCoins.iOS.Cells;
using GetCoins.iOS.Extensions;
using GetCoins.iOS.Models;
using GetCoins.iOS.Services;
using UIKit;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoverCameraPhotosViewController : UIViewController
    {
        string _rover;
        string _camera;

        PhotosDataSource _photosSource;
        private UITapGestureRecognizer _photoTappedGesture;

        public RoverCameraPhotosViewController(IntPtr handle)
            : base(handle)
        {
        }

        public RoverCameraPhotosViewController() : base("RoverCameraPhotosViewController", null)
        {
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            photosCollectionView.RegisterNibForCell(PhotoCell.Nib, PhotoCell.Key);

            var apiService = new NasaApiService(HttpService.Client);

            var photos = await apiService.GetPhotosAsync(_rover, _camera);

            _photosSource = new PhotosDataSource(photos);

            _photoTappedGesture = new UITapGestureRecognizer(PhotosCollectionTapped);
            photosCollectionView.AddGestureRecognizer(_photoTappedGesture);

            photosCollectionView.Delegate = new PhotosCollectionDelegateFlowLayout();
            photosCollectionView.DataSource = _photosSource;

            photosCollectionView.ReloadData();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            photosCollectionView.RemoveGestureRecognizer(_photoTappedGesture);
        }

        void PhotosCollectionTapped(UITapGestureRecognizer tapGesture)
        {
            var point = tapGesture.LocationInView(photosCollectionView);
            var indexPath = photosCollectionView.IndexPathForItemAtPoint(point);

            if (indexPath != null)
            {
                var cell = (PhotoCell)photosCollectionView.CellForItem(indexPath);
                var cellLocation = photosCollectionView.ConvertPointToView(new CGPoint(cell.Frame.X, cell.Frame.Y), View);
                var cellFrame = new CGRect(cellLocation, cell.Frame.Size);

                var fullImageView = new UIImageView(cell.PhotoImageView.Image)
                {
                    Frame = cellFrame,
                    BackgroundColor = UIColor.Black,
                    ContentMode = UIViewContentMode.ScaleAspectFit,
                    UserInteractionEnabled = true
                };

                var dismissPhotoPanGesture = new UIPanGestureRecognizer((UIPanGestureRecognizer panGesture) =>
                {
                    DismissFullPhotoMode(cellFrame, panGesture);
                    NavigationController.NavigationBar.Layer.ZPosition = 0;
                });

                fullImageView.AddGestureRecognizer(dismissPhotoPanGesture);
                View.AddSubview(fullImageView);

                NavigationController.NavigationBar.Layer.ZPosition = -1;

                ShowFullImage(fullImageView);
            }
        }

        void ShowFullImage(UIImageView imageView)
        {
            UIView.Animate(.3, () =>
            {
                imageView.Frame = UIScreen.MainScreen.Bounds;
                TabBarController.TabBar.Hidden = true;
            });
        }

        void DismissFullPhotoMode(CGRect cellFrame, UIPanGestureRecognizer panGesture)
        {
            UIView.Animate(0.2, () => { panGesture.View.BackgroundColor = null; });

            var translation = panGesture.TranslationInView(panGesture.View);

            panGesture.View.Center = new CGPoint
            {
                X = panGesture.View.Center.X + translation.X,
                Y = panGesture.View.Center.Y + translation.Y
            };

            if (panGesture.State == UIGestureRecognizerState.Ended)
            {
                TabBarController.TabBar.Hidden = false;

                UIView.Animate(.3, () =>
                {
                    panGesture.View.Frame = cellFrame;
                }, panGesture.View.RemoveFromSuperview);
            }

            panGesture.SetTranslation(new CGPoint(0, 0), panGesture.View);
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
                    var maxSide = (float)Math.Max(image.Size.Width, image.Size.Height);
                    cell.PhotoImageView.Image = image.Crop(maxSide, maxSide);
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


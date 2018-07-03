using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using GetCoins.iOS.Cells;
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

            // Perform any additional setup after loading the view, typically from a nib.

            var apiService = new NasaApiService();

            var photos = await apiService.GetPhotosAsync(_rover, _camera);

            _photosSource = new PhotosDataSource(photos);

            photosCollectionView.DataSource = _photosSource;
            photosCollectionView.ReloadData();
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
                    var isVisible = collectionView.IndexPathsForVisibleItems
                                                  .Contains(indexPath);
                    if (isVisible)
                    {
                        cell.PhotoImageView.Image = image;
                    }
                });
            });

            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section) => _photos.Count;
    }
}


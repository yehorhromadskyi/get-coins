using System;
using System.Collections.Generic;
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

        PhotosTableSource _photosTableSource;

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
            // Perform any additional setup after loading the view, typically from a nib.

            var apiService = new NasaApiService();

            var photos = await apiService.GetPhotosAsync(_rover, _camera);

            _photosTableSource = new PhotosTableSource(photos);

            photosTableView.Source = _photosTableSource;
            photosTableView.ReloadData();
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

    public class PhotosTableSource : UITableViewSource
    {
        readonly List<Photo> _photos = new List<Photo>();

        public List<Photo> Photos => _photos;

        public PhotosTableSource(List<Photo> photos)
        {
            _photos = photos;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var photo = _photos[indexPath.Row];

            if (!(tableView.DequeueReusableCell(PhotoCell.Key) is PhotoCell cell))
            {
                cell = PhotoCell.Create();
            }

            using (var url = new NSUrl(photo.Image))
            using (var data = NSData.FromUrl(url))
                cell.PhotoImageView.Image = UIImage.LoadFromData(data);

            //cell.TextLabel.Text = photo.Image;
            //cell.ImageView.Image = UIImage.fro;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => _photos.Count;
    }
}


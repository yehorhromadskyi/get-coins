using System;
using System.Collections.Generic;
using Foundation;
using SpaceProgram.iOS.Models;
using UIKit;

namespace SpaceProgram.iOS.ViewControllers
{
    public partial class RoverDetailsViewController : UIViewController
    {
        string _roverName;
        List<Camera> _cams;

        CamerasTableSource _camerasTableSource;

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

            _camerasTableSource = new CamerasTableSource(_cams);

            camerasTableView.Source = _camerasTableSource;
        }

        public void SetNavigationParameters(string roverName, List<Camera> cams)
        {
            _roverName = roverName;
            _cams = cams;
        }

        //[Action("SaveRoverDetails:")]
        //public void SaveRoverDetails(UIStoryboardSegue segue)
        //{
        //	Console.WriteLine("Save");
        //}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is RoverCameraPhotosViewController destinationViewController)
            {
                var selectedIndex = camerasTableView.IndexPathForSelectedRow.Row;
                var selectedCamera = _camerasTableSource.Cams[selectedIndex];
                destinationViewController.SetNavigationParameters(_roverName, selectedCamera.Name);
                destinationViewController.NavigationItem.Title = selectedCamera.Name;
            }
        }
    }

    public class CamerasTableSource : UITableViewSource
    {
        public List<Camera> Cams { get; } = new List<Camera>();

        public CamerasTableSource(List<Camera> cams)
        {
            Cams = cams;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("CameraCell");
            var camera = Cams[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "CameraCell");
            }

            cell.TextLabel.Text = camera.Name;
            cell.DetailTextLabel.Text = camera.FullName;

            return cell;
        }

        public override nint RowsInSection(
            UITableView tableview, nint section) => Cams.Count;
    }
}

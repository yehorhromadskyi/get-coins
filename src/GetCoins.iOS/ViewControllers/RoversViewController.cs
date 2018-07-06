using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using System.Collections.Generic;
using GetCoins.iOS.Models;
using GetCoins.iOS.Services;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoversViewController : UIViewController
    {
        RoversTableSource _roversTableSource;

        public RoversViewController(IntPtr handle)
            : base (handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            spinner.StartAnimating();

            var apiService = new NasaApiService(HttpService.Client);

            var rovers = await apiService.GetRoversAsync();

            _roversTableSource = new RoversTableSource(rovers);

            roversTableView.Source = _roversTableSource;
            roversTableView.ReloadData();

            spinner.StopAnimating();
        }

        //[Action("UnwindToRoversViewController:")]
        //public void UnwindToRoversViewController(UIStoryboardSegue segue)
        //{
        //   Console.WriteLine("Unwind");
        //}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is RoverDetailsViewController destinationViewController)
            {
                var selectedIndex = roversTableView.IndexPathForSelectedRow.Row;
                var selectedRover = _roversTableSource.Rovers[selectedIndex];
                destinationViewController.SetNavigationParameters(selectedRover.Name, selectedRover.Cameras);
                destinationViewController.NavigationItem.Title = selectedRover.Name;
            }
        }
    }

    public class RoversTableSource : UITableViewSource
    {
        readonly List<Rover> _rovers = new List<Rover>();

        public List<Rover> Rovers => _rovers;

        public RoversTableSource(List<Rover> rovers)
        {
            _rovers = rovers;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			var cell = tableView.DequeueReusableCell("RoverCell");
            var rover = _rovers[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "RoverCell");            
            }

            cell.TextLabel.Text = rover.Name;
            cell.DetailTextLabel.Text = rover.Status;

			return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => _rovers.Count;
    }
}
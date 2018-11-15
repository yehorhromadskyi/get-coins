using System;
using System.Collections.Generic;
using Foundation;
using GetCoins.iOS.Models;
using GetCoins.iOS.Services;
using UIKit;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoversViewController : UIViewController
    {
        RoversTableSource _roversTableSource;

        public RoversViewController(IntPtr handle)
            : base (handle)
        {
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
        public List<Rover> Rovers { get; } = new List<Rover>();

        public RoversTableSource(List<Rover> rovers)
        {
            Rovers = rovers;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			var cell = tableView.DequeueReusableCell("RoverCell");
            var rover = Rovers[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "RoverCell");            
            }

            cell.TextLabel.Text = rover.Name;
            cell.DetailTextLabel.Text = rover.Status;

			return cell;
        }

        public override nint RowsInSection(
            UITableView tableview, nint section) => Rovers.Count;
    }
}
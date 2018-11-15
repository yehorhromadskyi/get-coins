using System;
using System.Collections.Generic;
using Foundation;
using SpaceProgram.iOS.Cells;
using SpaceProgram.iOS.Models;
using SpaceProgram.iOS.Services;
using UIKit;

namespace SpaceProgram.iOS.ViewControllers
{
    public partial class LaunchesViewController : UIViewController
    {
        public LaunchesViewController(IntPtr handle) : base(handle)
        {

        }

        public LaunchesViewController() : base("LaunchesViewController", null)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            spinner.StartAnimating();

            var apiService = new LaunchLibraryApiService(HttpService.Client);

            var launches = await apiService.GetLaunchesAsync();

            launchesTableView.RegisterNibForCellReuse(LaunchCell.Nib, LaunchCell.Key);

            launchesTableView.Source = new LaunchesDataSource(launches);
            launchesTableView.ReloadData();

            spinner.StopAnimating();
        }
    }

    public class LaunchesDataSource : UITableViewSource
    {
        public List<Launch> Launches { get; }

        public LaunchesDataSource(List<Launch> launches)
        {
            Launches = launches;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (LaunchCell)tableView.DequeueReusableCell(LaunchCell.Key);

            var launch = Launches[indexPath.Row];

            cell.UpdateCell(launch);

            return cell;
        }

        public override nint RowsInSection(
            UITableView tableview, nint section) => Launches.Count;
    }
}


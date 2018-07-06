using System;
using System.Collections.Generic;
using Foundation;
using GetCoins.iOS.Cells;
using GetCoins.iOS.Models;
using GetCoins.iOS.Services;
using UIKit;

namespace GetCoins.iOS.ViewControllers
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

            var apiService = new LaunchLibraryApiService(HttpService.Client);

            var launches = await apiService.GetLaunchesAsync();

            launchesTableView.RegisterNibForCellReuse(LaunchCell.Nib, LaunchCell.Key);

            launchesTableView.Source = new LaunchesDataSource(launches);
            launchesTableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class LaunchesDataSource : UITableViewSource
    {
        readonly List<Launch> _launches;

        public List<Launch> Launches => _launches;

        public LaunchesDataSource(List<Launch> launches)
        {
            _launches = launches;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (LaunchCell)tableView.DequeueReusableCell(LaunchCell.Key);

            var launch = Launches[indexPath.Row];

            cell.UpdateCell(launch);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => _launches.Count;
    }
}


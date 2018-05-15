using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using System.Collections.Generic;
using GetCoins.iOS.Models;
using GetCoins.iOS.Cells;

namespace GetCoins.iOS.ViewControllers
{
    [Register("RoversViewController")]
    public class RoversViewController : UITableViewController
    {
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var rovers = new List<Rover>
            {
                new Rover { Name = "Curiosity", Status = "Active" },
                new Rover { Name = "Opportunity", Status = "Active" },
                new Rover { Name = "Spirit", Status = "Complete" }
            };

            TableView.Source = new RoversTableSource(rovers);

            // Perform any additional setup after loading the view
        }
    }

    public class RoversTableSource : UITableViewSource
    {
        readonly List<Rover> _rovers = new List<Rover>();

        public RoversTableSource(List<Rover> rovers)
        {
            _rovers = rovers;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			var cell = (RoverCell)tableView.DequeueReusableCell(RoverCell.Key);
            var rover = _rovers[indexPath.Row];

            if (cell == null)
            {
				cell = new RoverCell();            
            }

			cell.UpdateCell(rover);         

			return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => _rovers.Count;
    }
}
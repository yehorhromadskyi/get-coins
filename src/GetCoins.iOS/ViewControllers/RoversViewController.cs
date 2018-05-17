﻿using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using System.Collections.Generic;
using GetCoins.iOS.Models;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoversViewController : UIViewController
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

            roversTableView.Source = new RoversTableSource(rovers);

            // Perform any additional setup after loading the view
        }

        [Action("UnwindToRoversViewController:")]
        public void UnwindToRoversViewController(UIStoryboardSegue segue)
        {
           Console.WriteLine("Unwind");
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
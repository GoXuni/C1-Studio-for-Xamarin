using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using C1.CollectionView;

namespace Sunburst101
{
    public partial class GroupController : UIViewController
    {
		private C1CollectionView<Item> cv;
		private C1Sunburst sunburst;

        public GroupController() : base("GroupController", null)
        {
        }

        public GroupController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			sunburst = new C1Sunburst();

			sunburst.Binding = "Value";
			sunburst.BindingName = "Year,Quarter,Month";
			sunburst.ToolTipContent = "{}{name}\n{y}";
			sunburst.DataLabel.Position = PieLabelPosition.Center;
			sunburst.DataLabel.Content = "{}{name}";
            this.Add(sunburst);

			cv = new SunburstViewModel().View;
			cv.GroupChanged += View_GroupChanged;
			cv.SortChanged += Cv_SortChanged;

			//Sort cannot work synchronize with group in current CollectionView
			SortDescription yearSortDescription = new SortDescription("Year", SortDirection.Ascending);
			SortDescription quarterSortDescription = new SortDescription("Quarter", SortDirection.Ascending);
			SortDescription monthSortDescription = new SortDescription("MonthValue", SortDirection.Ascending);
			SortDescription[] sortDescriptions = new SortDescription[] { yearSortDescription, quarterSortDescription, monthSortDescription };
			cv.SortAsync(sortDescriptions);

        }

		private void Cv_SortChanged(object sender, System.EventArgs e)
		{
			GroupDescription yearGroupDescription = new GroupDescription("Year");
			GroupDescription quarterGroupDescription = new GroupDescription("Quarter");
			GroupDescription monthGroupDescription = new GroupDescription("MonthName");
			GroupDescription[] groupDescriptions = new GroupDescription[] { yearGroupDescription, quarterGroupDescription, monthGroupDescription };
			cv.GroupAsync(groupDescriptions);
		}

		private void View_GroupChanged(object sender, System.EventArgs e)
		{
			this.sunburst.ItemsSource = cv;
			CGRect rect = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
									 this.View.Frame.Width, this.View.Frame.Height - 80);

			sunburst.Frame = new CGRect(rect.X, rect.Y, rect.Width, rect.Height - 10);
		}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
          
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


    }
}


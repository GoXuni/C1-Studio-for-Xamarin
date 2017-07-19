using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class FullTextFilterController : UIViewController
    {
        public FullTextFilterController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            var fullTextFilter = new FullTextFilterBehavior();
            fullTextFilter.HighlightColor = UIColor.Blue;
            fullTextFilter.Attach(Grid);
            fullTextFilter.FilterEntry = Filter;
        }
    }
}
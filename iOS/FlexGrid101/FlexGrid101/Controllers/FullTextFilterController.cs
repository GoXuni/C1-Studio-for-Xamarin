using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class FullTextFilterController : UIViewController
    {
        private FullTextFilterBehavior fullTextFilter;

        public FullTextFilterController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            fullTextFilter = new FullTextFilterBehavior();
            fullTextFilter.HighlightColor = UIColor.Blue;
            fullTextFilter.Attach(Grid);
            fullTextFilter.FilterEntry = Filter;
            MatchCaseCheckBox.Checked += OnMatchCaseCheckBoxChecked;
            MatchWholeWordCheckBox.Checked += OnMatchWholeWordCheckBoxChecked;
        }

        void OnMatchCaseCheckBoxChecked(object sender, EventArgs e)
        {
            fullTextFilter.MatchCase = MatchCaseCheckBox.IsChecked;
        }

        void OnMatchWholeWordCheckBoxChecked(object sender, EventArgs e)
        {
            fullTextFilter.MatchWholeWord = MatchWholeWordCheckBox.IsChecked;
        }
    }
}
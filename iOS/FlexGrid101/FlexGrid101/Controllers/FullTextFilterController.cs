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
            Filter.Text = "Rich";
            Grid.AutoGeneratingColumn += (s, e) => { e.Column.MinWidth = 110; e.Column.Width = GridLength.Star; };
            Grid.ItemsSource = data;
            fullTextFilter = new FullTextFilterBehavior();
            fullTextFilter.HighlightColor = UIDevice.CurrentDevice.CheckSystemVersion(13, 0) ? UIColor.SystemBlueColor : UIColor.Blue;
            fullTextFilter.Attach(Grid);
            fullTextFilter.FilterEntry = Filter;
            fullTextFilter.MatchNumbers = true;
            MatchCaseCheckBox.IsChecked = false;
            MatchWholeWordCheckBox.IsChecked = false;
            MatchCaseCheckBox.Checked += OnMatchCaseCheckBoxChecked;
            MatchWholeWordCheckBox.Checked += OnMatchWholeWordCheckBoxChecked;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            MatchCaseCheckBox.Checked -= OnMatchCaseCheckBoxChecked;
            MatchWholeWordCheckBox.Checked -= OnMatchWholeWordCheckBoxChecked;
            Grid.RemoveFromSuperview();
            Filter.RemoveFromSuperview();
            MatchCaseCheckBox.RemoveFromSuperview();
            MatchWholeWordCheckBox.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }

        void OnMatchCaseCheckBoxChecked(object sender, EventArgs e)
        {
            fullTextFilter.MatchCase = MatchCaseCheckBox.IsChecked.Value;
        }

        void OnMatchWholeWordCheckBoxChecked(object sender, EventArgs e)
        {
            fullTextFilter.MatchWholeWord = MatchWholeWordCheckBox.IsChecked.Value;
        }
    }
}
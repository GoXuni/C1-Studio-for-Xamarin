using C1.iOS.Grid;
using Foundation;
using System;
using UIKit;

namespace FlexGrid101
{
    public partial class CheckListController : UIViewController
    {
        public CheckListController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var checkListBehavior = new CheckListBehavior();
            checkListBehavior.SelectionBinding = "Selected";
            checkListBehavior.Attach(Grid);
            Grid.AutoGeneratingColumn += (s, e) => e.Column.Width = GridLength.Star;
            Grid.ItemsSource = Customer.GetCities();
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
}
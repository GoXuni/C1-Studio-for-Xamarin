using Foundation;
using System;
using System.Linq;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class EditingController : UIViewController
    {
        GridCellRange selectedRange;

        public EditingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            Grid.SelectionChanged += OnSelectionChanged;
            Grid.CellDoubleTapped += OnCellDoubleTapped;
        }

        private void OnCellDoubleTapped(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellType == GridCellType.Cell)
            {
                selectedRange = e.CellRange;
                PerformSegue("OpenEditingPopup", this);
            }
        }

        private void OnSelectionChanged(object sender, GridCellRangeEventArgs e)
        {
            this.selectedRange = e.CellRange;
        }

        partial void EditButton_Activated(UIBarButtonItem sender)
        {
            if (selectedRange != null)
            {
                PerformSegue("OpenEditingPopup", this);
            }
            else
            {
                var alert = new UIAlertView("", Foundation.NSBundle.MainBundle.LocalizedString("Please select a row first or double-tap the row directly.", ""), null, "OK");
                alert.Show();
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var popupController = (segue.DestinationViewController as UINavigationController).ChildViewControllers.First() as EditingFormController;
            popupController.Customer = Grid.Rows[selectedRange.Row].DataItem as Customer;
        }

        [Action("CloseEditingForm:")]
        public void CloseEditingForm(UIStoryboardSegue segue)
        {
            var popupController = segue.SourceViewController as EditingFormController;
        }
    }
}
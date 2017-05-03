using CoreGraphics;
using System;
using UIKit;

namespace FlexGrid101
{
    public partial class EditingFormController : UIViewController
    {
        public Customer Customer { get; set; }

        public EditingFormController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            FirstNameField.Text = Customer.FirstName;
            LastNameField.Text = Customer.LastName;
            LastOrderField.Text = Customer.LastOrderDate.ToShortDateString();
            var toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolBar.SetItems(new UIBarButtonItem[] { flexibleSpace, doneButton }, true);
            var datePicker = new UIDatePicker();
            LastOrderField.InputView = datePicker;
            LastOrderField.InputAccessoryView = toolBar;
            OrderTotalField.Text = Customer.OrderTotal.ToString();
            doneButton.Clicked += (s, e) =>
            {
                LastOrderField.Text = GridDateTimeColumn.NSDateToDateTime(datePicker.Date).ToShortDateString();
                LastOrderField.ResignFirstResponder();
            };
        }

        partial void SaveButton_Activated(UIBarButtonItem sender)
        {
            Customer.FirstName = FirstNameField.Text;
            Customer.LastName = LastNameField.Text;
            DateTime lastOrderDate;
            if (DateTime.TryParse(LastOrderField.Text, out lastOrderDate))
            {
                Customer.LastOrderDate = lastOrderDate;
            }
            double orderTotal;
            if (double.TryParse(OrderTotalField.Text, out orderTotal))
            {
                Customer.OrderTotal = orderTotal;
            }
            PerformSegue("CloseEditingForm", this);
        }
    }
}
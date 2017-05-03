using Foundation;
using System;
using UIKit;
using C1.iOS.Calendar;

namespace C1Calendar101
{
    public partial class PopupEditorController : UIViewController
    {
        public PopupEditorController(IntPtr handle) : base(handle)
        {
        }

        [Action("UnwindFromPopupController:")]
        public void UnwindFromPopupController(UIStoryboardSegue segue)
        {
            var popupController = segue.SourceViewController as PopupCalendarController;
            if (popupController.SelectedDate.HasValue)
            {
                Message.Text = string.Format("The date {0:d} was selected.", popupController.SelectedDate.Value);
            }
            else
            {
                Message.Text = "";
            }
        }
    }
}
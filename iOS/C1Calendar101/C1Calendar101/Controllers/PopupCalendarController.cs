using Foundation;
using System;
using UIKit;
using C1.iOS.Calendar;

namespace C1Calendar101
{
    public partial class PopupCalendarController : UIViewController
    {
        public PopupCalendarController(IntPtr handle) : base(handle)
        {
        }

        public DateTime? SelectedDate
        {
            get
            {
                return Calendar != null ? Calendar.SelectedDate : null;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Calendar.SelectionChanged += OnSelectionChanged;
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            Calendar.SelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            PerformSegue("ClosePopup", this);
        }
        public override void DidReceiveMemoryWarning()
        {
            Calendar.RemoveFromSuperview();
            ReleaseDesignerOutlets();
            base.DidReceiveMemoryWarning();
        }
    }
}
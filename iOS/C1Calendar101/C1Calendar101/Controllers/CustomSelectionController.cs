using Foundation;
using System;
using UIKit;
using C1.iOS.Calendar;

namespace C1Calendar101
{
    public partial class CustomSelectionController : UIViewController
    {
        public CustomSelectionController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Calendar.SelectionChanging += OnSelectionChanging;
        }
        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            Calendar.SelectionChanging -= OnSelectionChanging;
        }

        private void OnSelectionChanging(object sender, CalendarSelectionChangingEventArgs e)
        {
            foreach (var date in e.SelectedDates.ToArray())
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    e.SelectedDates.Remove(date);
            }
        }

    }
}
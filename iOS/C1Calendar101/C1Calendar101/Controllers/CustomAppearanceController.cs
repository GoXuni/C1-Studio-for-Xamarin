using Foundation;
using System;
using UIKit;
using C1.iOS.Calendar;

namespace C1Calendar101
{
    public partial class CustomAppearanceController : UIViewController
    {
        public CustomAppearanceController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Calendar.ViewModeAnimation.ScaleFactor = 1.1;
            Calendar.ViewModeAnimation.AnimationMode = CalendarViewModeAnimationMode.ZoomOutIn;
            Calendar.Font = UIFont.FromName("Courier New", 16);
            Calendar.TodayFont = UIFont.FromName("Courier New", 16);
            Calendar.DayOfWeekFont = UIFont.FromName("Arial", 21);
            Calendar.HeaderFont = UIFont.FromName("Arial", 21);
        }
    }
}
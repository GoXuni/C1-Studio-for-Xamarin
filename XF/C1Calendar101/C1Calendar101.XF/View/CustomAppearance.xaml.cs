using C1.Xamarin.Forms.Calendar;
using C1Calendar101.Resources;
using System;

namespace C1Calendar101
{
    public partial class CustomAppearance
    {
        public CustomAppearance()
        {
            InitializeComponent();
            Title = AppResources.CustomAppearanceTitle;

            calendar.ViewModeAnimation.AnimationMode = CalendarViewModeAnimationMode.ZoomOutIn;
            calendar.ViewModeAnimation.ScaleFactor = 1.1;
            calendar.ViewModeAnimation.Duration = TimeSpan.FromMilliseconds(150);

            calendar.NavigateAnimation.Duration = TimeSpan.FromMilliseconds(150);
        }

    }
}

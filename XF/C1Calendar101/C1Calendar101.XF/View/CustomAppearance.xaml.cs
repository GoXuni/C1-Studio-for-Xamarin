using C1.Xamarin.Forms.Calendar;
using C1Calendar101.Resources;
using System;
using Xamarin.Forms.Xaml;

namespace C1Calendar101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

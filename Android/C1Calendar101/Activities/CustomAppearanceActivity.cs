using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Calendar;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Calendar101
{
    [Activity(Label = "@string/custom_appearance", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomAppearanceActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CustomAppearance);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.custom_appearance);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var calendar = FindViewById<C1Calendar>(Resource.Id.Calendar);
            calendar.ViewModeAnimation.AnimationMode = CalendarViewModeAnimationMode.ZoomOutIn;
            calendar.ViewModeAnimation.ScaleFactor = 1.1;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}
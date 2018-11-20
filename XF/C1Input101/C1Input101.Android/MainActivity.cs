using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;
namespace C1Input101.Android
{
    [Activity(Label = "C1Input101", MainLauncher = true, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Android.Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new C1Input101.App());
        }
    }
}


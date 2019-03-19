using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using C1.Xamarin.Forms.Input.Platform.Android;

namespace C1Input101.Android
{
    [Activity(Label = "C1Input101", MainLauncher = true, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            C1InputRenderer.Init();

            FormsAppCompatActivity.ToolbarResource = Android.Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new C1Input101.App());
        }
    }
}


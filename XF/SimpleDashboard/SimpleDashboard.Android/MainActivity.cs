using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using C1.Xamarin.Forms.Chart.Platform.Android;
using C1.Xamarin.Forms.Gauge.Platform.Android;

namespace SimpleDashboard.Android
{
    [Activity(Label = "Sales Dashboard", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FlexChartRenderer.Init();
            C1GaugeRenderer.Init();

            FormsAppCompatActivity.ToolbarResource = Android.Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}


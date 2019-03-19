using Android.App;
using Android.Content.PM;
using Android.OS;
using C1.Xamarin.Forms.Chart.Platform.Android;
using C1.Xamarin.Forms.Grid.Platform.Android;
using C1.Xamarin.Forms.Gauge.Platform.Android;

namespace DashboardDemo.Droid
{
    [Activity(Label = "DashboardDemo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FlexChartRenderer.Init();
            FlexGridRenderer.Init();
            C1GaugeRenderer.Init();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}


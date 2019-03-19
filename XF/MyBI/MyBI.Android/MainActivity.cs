using Android.App;
using Android.Content.PM;
using Android.OS;
using C1.Xamarin.Forms.Grid.Platform.Android;
using C1.Xamarin.Forms.Input.Platform.Android;
using C1.Xamarin.Forms.Gauge.Platform.Android;
using C1.Xamarin.Forms.Chart.Platform.Android;

namespace MyBI.Android
{
    [Activity(Label = "MyBI", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FlexGridRenderer.Init();
            C1InputRenderer.Init();
            C1GaugeRenderer.Init();
            FlexChartRenderer.Init();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}


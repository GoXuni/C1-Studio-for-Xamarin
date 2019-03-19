using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using XAM = Xamarin.Forms;

using Xamarin.Forms.Platform.Android;
using C1.Xamarin.Forms.Chart.Platform.Android;

namespace FlexChart101.Android
{
    [Activity(Label = "FlexChart101", MainLauncher = true, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FlexChartRenderer.Init();

            FormsAppCompatActivity.ToolbarResource = Android.Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new FlexChart101.App());
        }
    }
}


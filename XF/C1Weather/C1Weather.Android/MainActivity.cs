using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;
using XAM = Xamarin.Forms;

using Xamarin.Forms.Platform.Android;
using Plugin.CurrentActivity;

namespace C1Weather.Android
{
    [Activity(Label = "C1Weather", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Android.Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}


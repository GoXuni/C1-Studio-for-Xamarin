using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.IO;
using Android;
using Android.Content.PM;
using C1.Android.Gauge;
using C1.Android.Core;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Gauge101
{
    [Activity(Label = "@string/snapshot", Icon = "@drawable/gauge_basic")]
    public class SnapshotActivity : AppCompatActivity
    {
        private C1RadialGauge mRadialGauge;
        private const int REQUEST_CODE_WRITE_EXTERNAL_STORAGE = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.activity_snapshot);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.snapshot);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            mRadialGauge = this.FindViewById<C1RadialGauge>(Resource.Id.radialGauge1);
            mRadialGauge.Enabled = false;
            mRadialGauge.Value = 25;
            mRadialGauge.Step = 1;
            mRadialGauge.Max = 100;
            mRadialGauge.Min = 1;
            mRadialGauge.ShowText = GaugeShowText.All;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.actionSnapshot)
            {
                // export image and return the status
                if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                {
                    Permission permission = this.CheckSelfPermission(Manifest.Permission.WriteExternalStorage);
                    if (!permission.Equals(Permission.Granted))
                    {
                        this.RequestPermissions(new String[]
                                {Manifest.Permission.WriteExternalStorage}, REQUEST_CODE_WRITE_EXTERNAL_STORAGE);

                    }
                    else
                    {
                        var task = exportImageAsync();
                        return true;
                    }

                }
                else
                {
                    // targetSdkVersion < Android M, we have to use PermissionChecker
                    var task = exportImageAsync();
                    return true;
                }
            }
            else if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }


            return base.OnOptionsItemSelected(item);
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Inflate the menu items for use in the action bar
            MenuInflater inflater = this.MenuInflater;
            inflater.Inflate(Resource.Menu.menu_snapshot, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public async System.Threading.Tasks.Task exportImageAsync()
        {
            String APP_PATH_SD_CARD = "/xuni/samples/gauge/";
            mRadialGauge.IsAnimated = false;
            byte[] image = await mRadialGauge.GetImage();

            String fullPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + APP_PATH_SD_CARD;
            try
            {
                Java.IO.File dir = new Java.IO.File(fullPath);
                if (!dir.Exists())
                {
                    dir.Mkdirs();
                }

                string name = fullPath + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                File.WriteAllBytes(name, image);

                // add index of the image to the gallery
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(new Java.IO.File(name));
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);

                Toast.MakeText(this, Resource.String.snapshotStored, ToastLength.Short).Show();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("exportImage failed: " + e.Message);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (grantResults.Length != 0 && grantResults[0].Equals(Permission.Granted))
            {
                switch (requestCode)
                {
                    case REQUEST_CODE_WRITE_EXTERNAL_STORAGE:
                            exportImageAsync();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                new Android.App.AlertDialog.Builder(this).SetMessage(Resource.String.permissionDenied).SetPositiveButton(Resource.String.positive_button, (IDialogInterfaceOnClickListener)null).Show();
            }
        }
    }
}
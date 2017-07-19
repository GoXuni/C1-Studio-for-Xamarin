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

namespace C1Gauge101
{
    [Activity(Label = "@string/snapshot", Icon = "@drawable/gauge_basic")]
    public class SnapshotActivity : Activity
    {
        private C1RadialGauge mRadialGauge;
        private const int REQUEST_CODE_WRITE_EXTERNAL_STORAGE = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.activity_snapshot);
            mRadialGauge = (C1RadialGauge)FindViewById(Resource.Id.radialGauge1);
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
                        exportImageAsync();
                    }

                }
                else
                {
                    // targetSdkVersion < Android M, we have to use PermissionChecker
                    exportImageAsync();
                }
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

        public async System.Threading.Tasks.Task<bool> exportImageAsync()
        {
            String APP_PATH_SD_CARD = "/xuni/samples/gauge/";
            byte[] image = await mRadialGauge.GetImage();

            String fullPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + APP_PATH_SD_CARD;
            try
            {
                Java.IO.File dir = new Java.IO.File(fullPath);
                if (!dir.Exists())
                {
                    dir.Mkdirs();
                }

                string name = fullPath + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                System.IO.File.WriteAllBytes(name, image);

                // add index of the image to the gallery
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(new Java.IO.File(name));
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);

                Toast.MakeText(this, Resource.String.snapshotStored, ToastLength.Short).Show();
                return true;
            }
            catch (Exception e)
            {
                return false;
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
                new AlertDialog.Builder(this).SetMessage(Resource.String.permissionDenied).SetPositiveButton(Resource.String.positive_button, (IDialogInterfaceOnClickListener)null).Show();
            }
        }
    }
}
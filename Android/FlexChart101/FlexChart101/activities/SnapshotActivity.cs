using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using C1.Android.Core;
using FlexChart101.DataModel;
using System;
using System.Threading.Tasks;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace FlexChart101
{
    [Activity(Label = "@string/snapshot")]
    public class SnapshotActivity : BaseActivity
    {
        private FlexChart mChart;
        private const int REQUEST_CODE_WRITE_EXTERNAL_STORAGE = 1;

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
                        var task = exportImage();
                        return true;
                    }

                }
                else
                {
                    // targetSdkVersion < Android M, we have to use PermissionChecker
                    var task = exportImage();
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
            MenuInflater inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.menu_snapshot, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_snapshot);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.snapshot);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);

            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());
        }

        /**
         * Exports the bitmap of the current chart to the device's storage
         *
         * @return
         *
         */
        public async Task exportImage()
        {
            String APP_PATH_SD_CARD = "/xuni/samples/FlexChart/";
            var image = await mChart.GetImage();

            string fullPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + APP_PATH_SD_CARD;

            try
            {
                Java.IO.File dir = new Java.IO.File(fullPath);
                if (!dir.Exists())
                {
                    dir.Mkdirs();
                }

                // save image to a new file
                string name = fullPath + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                System.IO.File.WriteAllBytes(name, image);

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
                        exportImage();
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

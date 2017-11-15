using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sunburst101
{
    [Activity(Label = "Sunburst101", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : AppCompatActivity
    {
        ListView mSampleList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            C1.Android.Core.LicenseManager.Key = License.Key;
            // Set our view from the "main" layout resource

            this.SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.appName);

            mSampleList = (ListView)FindViewById(Resource.Id.listView1);
            SampleListAdapter adapter = new SampleListAdapter(this);
            mSampleList.Adapter = adapter;
            mSampleList.ItemClick += ItemClick;
        }
        public void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var activityType = ((sender as ListView).GetItemAtPosition(e.Position) as SampleModel).ActivityType;
            Intent intent = new Intent(this, activityType);
            StartActivity(intent);
        }
    }
}


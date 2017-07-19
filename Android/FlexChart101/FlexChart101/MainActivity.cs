using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FlexChart101
{
    [Activity(Label = "FlexChart101", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        ListView mSampleList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            C1.Android.Core.LicenseManager.Key = License.Key;
            // Set our view from the "main" layout resource

            mSampleList = new ListView(this);
            SampleListAdapter adapter = new SampleListAdapter(this);
            mSampleList.Adapter=adapter;
            mSampleList.ItemClick += ItemClick;

            this.SetContentView(mSampleList);
        }
        public void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var activityType = ((sender as ListView).GetItemAtPosition(e.Position) as SampleModel).ActivityType;
            Intent intent = new Intent(this, activityType);
            StartActivity(intent);
        }
    }
}


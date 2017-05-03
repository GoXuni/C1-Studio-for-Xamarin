using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace C1Gauge101
{
    [Activity(Label = "C1Gauge101", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView mSampleList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            C1.Android.Core.LicenseManager.Key = License.Key;
            mSampleList = new ListView(this);
            SampleListAdapter adapter = new SampleListAdapter(this);
            mSampleList.Adapter = adapter;
            mSampleList.ItemClick += ItemClick;

            this.SetContentView(mSampleList);
        }

        public void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent();
            Activity activity;
            // initialize the intent based on user click
            switch (e.Position)
            {
                case 0:
                    activity = new GettingStartedActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
                case 1:
                    activity = new DisplayingValuesActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
                case 2:
                    activity = new UsingRangesActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
                case 3:
                    activity = new AutomaticScalingActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
                case 4:
                    activity = new DirectionActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
                case 5:
                    activity = new BulletGraphActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
                case 6:
                    activity = new CustomAnimationActivity();
                    intent = new Intent(ApplicationContext, activity.Class);
                    break;
            }
            // start the new activity
            StartActivity(intent);
        }
    }
}


using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using Android.Graphics;
using Java.Util;

namespace C1Gauge101
{
    [Activity(Label = "@string/direction", MainLauncher = false, Icon = "@drawable/gauge_linear")]
    public class DirectionActivity : Activity
    {
        private C1BulletGraph mBulletGraph;
        private C1LinearGauge mLinearGauge;
        private Spinner mDirectionSpinner;
        private LinearLayout mLayout;
        private LinearLayout.LayoutParams mParamsHorizontal = new LinearLayout.LayoutParams(100, LinearLayout.LayoutParams.MatchParent);
        private LinearLayout.LayoutParams mParamsVertical = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 100);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_direction);

            // initializing widgets
            mBulletGraph = (C1BulletGraph)FindViewById(Resource.Id.bulletGraph1);
            mLinearGauge = (C1LinearGauge)FindViewById(Resource.Id.linearGauge1);
            mDirectionSpinner = (Spinner)FindViewById(Resource.Id.directionSpinner);
            mLayout = (LinearLayout)FindViewById(Resource.Id.layout1);

            // creating and initializing adapter to string array
            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.directionSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mDirectionSpinner.Adapter = adapter1;
            mDirectionSpinner.ItemSelected += mDirectionSpinner_ItemSelected;

            // setting dafault values
            mBulletGraph.Value = 40;
            mBulletGraph.Bad = 45;
            mBulletGraph.Good = 80;
            mBulletGraph.Max = 100;
            mBulletGraph.Target = 90;
            mBulletGraph.Step = 1;
            //mBulletGraph.GaugeWidth = .5f;

            mLinearGauge.Value = 40;
            mLinearGauge.Min = 0;
            mLinearGauge.Max = 100;
            mLinearGauge.ShowText = GaugeShowText.All;
            //mLinearGauge.GaugeWidth = .5f;
        }

        void mDirectionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // setting the direction of each gauge and applying a new layout
            switch (e.Position)
            {
                case 0:
                    mLinearGauge.Direction = LinearGaugeDirection.Right;
                    mBulletGraph.Direction = LinearGaugeDirection.Right;
                    mBulletGraph.LayoutParameters = mParamsVertical;
                    mLinearGauge.LayoutParameters = mParamsVertical;
                    mLayout.Orientation = Orientation.Vertical;
                    break;
                case 1:
                    mLinearGauge.Direction = LinearGaugeDirection.Left;
                    mBulletGraph.Direction = LinearGaugeDirection.Left;
                    mBulletGraph.LayoutParameters = mParamsVertical;
                    mLinearGauge.LayoutParameters = mParamsVertical;
                    mLayout.Orientation = Orientation.Vertical;
                    break;
                case 2:
                    mLinearGauge.Direction = LinearGaugeDirection.Down;
                    mBulletGraph.Direction = LinearGaugeDirection.Down;
                    mBulletGraph.LayoutParameters = mParamsHorizontal;
                    mLinearGauge.LayoutParameters = mParamsHorizontal;
                    mLayout.Orientation = Orientation.Horizontal;
                    break;
                case 3:
                    mLinearGauge.Direction = LinearGaugeDirection.Up;
                    mBulletGraph.Direction = LinearGaugeDirection.Up;
                    mBulletGraph.LayoutParameters = mParamsHorizontal;
                    mLinearGauge.LayoutParameters = mParamsHorizontal;
                    mLayout.Orientation = Orientation.Horizontal;
                    break;
            }
        }

    }
}



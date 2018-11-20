using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Text.Format;
using Android.Views;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/dynamicCharts")]
    public class DynamicChartsActivity : AppCompatActivity
    {
        static FlexChart mChart;
        static ObservableCollection<object> mList = new ObservableCollection<object>();
        private Handler mHandler;
        private Action taskAction = null;
        private static int SIZE = 10;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_dynamic_charts);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.dynamicCharts);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            mHandler = new Handler();

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mChart.LegendPosition = ChartPositionType.Bottom;
            mChart.ToolTip = null;
            GetList();
            Chartinitialization.InitialDefaultChart(mChart, mList);
           
        }
        protected override void OnStart()
        {
            base.OnStart();
            
            //var h = new Handler(Looper.MainLooper);
            taskAction = new Action(() => {
               if (mList.Count > SIZE)
               {
                   mList.RemoveAt(0);
               }
                System.Random random = new System.Random();
                int temp = random.Next(100);
                string time = DateFormat.Format("mm:ss", new Date()).ToString();
                
                mList.Add(new ChartPoint(time, temp, temp + 10, temp + 20));

               mChart.ItemsSource = mList;

               // There is a issue on mList collection changed event handling. So we have below 4 lines code to refresh the chart.
               mChart.Series[0].Dispose();
               mChart.Series[1].Dispose();
               mChart.Series[2].Dispose();
               mChart.Invalidate();

                mHandler.PostDelayed(taskAction, 125);
            });

            mHandler.PostDelayed(taskAction, 125);
            

        }
        protected override void OnStop()
        {
            // to clear handler call back list, and destroy activity and thread
            //mList.Clear();
            //this.Finish();
            base.OnStop();
        }
        private static IList<object> GetList()
        {
            int n = 60; // number of series elements
            string time = "";
            System.Random random = new System.Random();
            int temp;
            for (int i = 0; i < n; i++)
            {
                temp = random.Next(100);
                time = DateFormat.Format("mm:ss", new Date()).ToString();
                mList.Add(new ChartPoint(time, temp, temp + 10, temp + 20));
            }
            return mList;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
    
}

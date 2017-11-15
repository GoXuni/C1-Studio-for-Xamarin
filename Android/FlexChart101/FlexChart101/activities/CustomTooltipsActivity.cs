
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
using C1.Android.Chart;
using C1.Android.Core;
using FlexChart101.DataModel;
using System.Globalization;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "CustomTooltipsActivity")]
    public class CustomTooltipsActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_custom_tooltips);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.customTooltips);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());
            mChart.Stacking = ChartStackingType.Stacked;
            mChart.Palette = Palette.Cocoa;
            mChart.LegendPosition = ChartPositionType.Bottom;

            MyToolTip t = new MyToolTip(mChart, ApplicationContext);
            FrameLayout.LayoutParams l = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            mChart.ToolTip = t;
            mChart.ToolTipLoading += (object sender, ChartTooltipLoadingEventArgs args) =>
            {
				ChartHitTestInfo e = args.HitTestInfo;
                if (e.Distance < 2 && e.PointIndex >= 0)
                {
                    t.Point = new C1Point(e.Point.X, e.Point.Y);
                    t.UpdateContent(e);
                    t.IsOpen = true;
                }
                else
                {
                    t.IsOpen = false;
                }
            };
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

    public class MyToolTip : ChartTooltip
    {

        ImageView mFlag;
        TextView mTitle;
        TextView mContent;
        String mParentPackage;


        public MyToolTip(FlexChart flexChart, Context context) : base(context)
        {

            mParentPackage = context.PackageName;
            //SetPadding(10, 10, 10, 10);
            // create custom layouts
            LinearLayout customLayout = new LinearLayout(Context);
            customLayout.SetBackgroundColor(Color.ParseColor("#FFFFCA"));
            customLayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout childLayout = new LinearLayout(Context);
            childLayout.Orientation = Android.Widget.Orientation.Horizontal;

            // initialize layout elements
            mFlag = new ImageView(Context);
            mTitle = new TextView(Context);
            mContent = new TextView(Context);

            // set element properties
            mTitle.SetTextColor(Color.Black);
            mTitle.SetTypeface(mTitle.Typeface, TypefaceStyle.Bold);
            mTitle.SetPadding(10, 10, 10, 10);
            mContent.SetTextColor(Color.Black);
            mContent.SetPadding(5,5,5,5);
            mFlag.SetPadding(5, 5, 5, 5);

            // add layouts
            childLayout.AddView(mFlag);
            childLayout.AddView(mTitle);
            customLayout.AddView(childLayout);
            customLayout.AddView(mContent);
            AddView(customLayout);
        }

        public void UpdateContent(ChartHitTestInfo hitTestInfo)
        {
            mFlag.SetImageResource(Resources.GetIdentifier(hitTestInfo.X.ToString().ToLower(CultureInfo.CurrentUICulture), "drawable", mParentPackage));
            mTitle.Text = hitTestInfo.Series.Name;
            mContent.Text = hitTestInfo.X.ToString() + " " + hitTestInfo.Y.ToString();
        }

    }
}

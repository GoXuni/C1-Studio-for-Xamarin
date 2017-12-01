
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

using FlexChart101.DataModel;

using Android.Graphics;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "CustomPlotElementsActivity")]
	public class CustomPlotElementsActivity : AppCompatActivity
    {
		private FlexChart mChart;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.activity_custom_plot_elements);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.customPlotElements);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);

			// set the binding for X-axis of FlexChart
			mChart.BindingX = "name";

			// initialize series elements and set the binding to variables of
			// ChartPoint
			ChartSeries seriesdevices = new ChartSeries();
			seriesdevices.Chart = mChart;
			seriesdevices.SeriesName = "Devices sold";
			seriesdevices.Binding = "devicesSold";
			// add series to list
			mChart.Series.Add(seriesdevices);

			// setting the source of data/items in FlexChart
			mChart.ItemsSource = CustomPoint.GetList(this);

			// Set axis Y title.
			mChart.AxisY.Title = "Devices Sold (billions)";
			// Set axis Y line invisible.
			mChart.AxisY.AxisLine = false;

			seriesdevices.SymbolRendered += (object sender, RenderSymbolEventArgs e) =>
			{
				int left = (int)(e.Point.X - e.Size.Width / 2 + 25);
				int top = (int)(e.Point.Y + (e.Size.Height - e.Size.Width) / 2 - 25);
				int right = (int)(left + e.Size.Width + 25);
				int bottom = (int)(top + e.Size.Width + 25); 
				CustomPoint customPoint = (CustomPoint)CustomPoint.GetList(this)[e.Index];

				if (customPoint != null)
				{
					e.Engine.DrawImage(customPoint.logo, left, top, e.Size.Width - 50, e.Size.Width - 50);
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

   
    class CustomPoint : Java.Lang.Object
	{
		public string name { get; set; }
		public int devicesSold { get; set; }
		public Bitmap logo { get; set; }
        private static List<Bitmap> bitMap = new List<Bitmap>();
        CustomPoint(string name, int devicesSold, Bitmap logo)
		{
			this.name = name;
			this.devicesSold = devicesSold;
			this.logo = logo;
		}

		// a method to create random values for seriesDevices and assign respective
		// bitmaps
		public static IList<object> GetList(Context context)
		{
			IList<object> list = new List<object>();
			int n = 3;
			int min = 15; // minimum value for the chart
			String[] names = { "Apple", "Google", "Microsoft" };
			int[] imageResources = { Resource.Drawable.logo_apple, Resource.Drawable.logo_google,  Resource.Drawable.logo_microsoft };
			Bitmap logo;
			Random random = new Random();

			for (int i = 0; i < n; i++)
			{
                if (bitMap != null && bitMap.Count == n)
                {
                    logo = bitMap[i];
                }
                else
                {
                    logo = BitmapFactory.DecodeResource(context.Resources, imageResources[i]);
                    bitMap.Add(logo);
                }
				list.Add(new CustomPoint(names[i], random.Next(85) + min, logo));
			}
			return list;
		}
    }
}

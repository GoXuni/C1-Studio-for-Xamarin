using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using Foundation;

namespace FlexChart101
{
	public partial class CustomizingAxesController : UIViewController
	{
		FlexChart chart;

		public CustomizingAxesController() : base("CustomizingAxesController", null)
		{
		}


		public CustomizingAxesController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			chart = new FlexChart();
			chart.BindingX = "Name";
			chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Sales" });
			chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Expenses" });
			chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads,Downloads" });
			chart.ItemsSource = SalesData.GetSalesDataList();
			this.Add(chart);
			chart.AxisX.LabelLoading += (object sender, AxisLabelLoadingEventArgs e) =>
			{
				string path = "Images/" + e.LabelString;
				UIImage image = null;
				try
				{
					image = new UIImage(path);
				}
				catch (Exception)
				{
					image = null;
				}

                UIImageView imageView = new UIImageView();
                imageView.Frame = new CGRect(0, 0, 25, 20);
                imageView.Image = image;
                e.Label = imageView;
			};

			chart.AxisY.LabelLoading += (object sender, AxisLabelLoadingEventArgs e) =>
			{
                UILabel label = new UILabel();
                label.Text = "$" + (e.Value / 1000).ToString() + "K";
                label.AdjustsFontSizeToFitWidth = true;
                if (e.Value <= 8000)
				{
                    label.TextColor = UIColor.Red;
				}
				else if (e.Value <= 12000 && e.Value > 8000)
				{
                    label.TextColor = UIColor.Green;
				}
				else
				{
                    label.TextColor = UIColor.Black;
				}
                e.Label = label;
			};
		}


		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			chart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
									 this.View.Frame.Width, this.View.Frame.Height - 80);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using Foundation;

namespace FlexChart101
{
	public partial class CustomTooltipsController : UIViewController
	{
		FlexChart chart;

		public CustomTooltipsController() : base("CustomTooltipsController", null)
		{
		}

		public CustomTooltipsController(IntPtr handle) : base(handle)
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
			chart.Palette = Palette.Cocoa;
			chart.Stacking = ChartStackingType.Stacked;
			chart.LegendPosition = ChartPositionType.Bottom;

			MyTooltip t = new MyTooltip();
			t.Frame = new CGRect(0, 0, 100, 50);
			t.BackgroundColor = new UIColor(1.0f, 1.0f, 0.792f, 1.0f);
			chart.ToolTip = t;
			chart.ToolTipLoading += (object sender, ChartTooltipLoadingEventArgs args) =>
			{

				ChartHitTestInfo e = args.HitTestInfo;
				if (e.Distance < 2 && e.PointIndex >= 0)
				{
					double left = e.Point.X, top = e.Point.Y - t.Frame.Height, width = t.Frame.Width, height = t.Frame.Height;
					double screenWidth = UIScreen.MainScreen.Bounds.Size.Width;
					double margin = 5;
					if (left + width > screenWidth) left = screenWidth - width - margin;
					t.Frame = new CGRect(left, top, width ,height);
					t.UpdateContent(e);
					t.IsOpen = true;
				}
				else
				{
					t.IsOpen = false;
				}
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

	public class MyTooltip : ChartTooltip
	{
		UILabel label;
		UIImage image;
		UIImageView imageView;

		public void UpdateContent(ChartHitTestInfo hitTestInfo)
		{
			if (label == null && imageView == null)
			{
				label = new UILabel(new CGRect(this.Bounds.Size.Width / 4, 0, this.Bounds.Size.Width * 3 / 4, this.Bounds.Size.Height));
				label.TextColor = UIColor.Black;
				label.Lines = 3;
				label.Text = string.Format("{0} \n\n {1:C2}", hitTestInfo.Series.Name, hitTestInfo.Y);
				label.Font = label.Font.WithSize(11);

				image = new UIImage("Images/" + SalesData.GetCountries()[hitTestInfo.PointIndex]);
				imageView = new UIImageView(image);
				this.AddSubview(imageView);
				this.AddSubview(label);
			}
			else
			{
				image = new UIImage("Images/" + SalesData.GetCountries()[hitTestInfo.PointIndex]);
				imageView.Image = image;
				label.Text = string.Format("{0} \n\n {1:C2}", hitTestInfo.Series.Name, hitTestInfo.Y);
				imageView.SetNeedsLayout();
				label.SetNeedsLayout();
			}
		}

	}
}


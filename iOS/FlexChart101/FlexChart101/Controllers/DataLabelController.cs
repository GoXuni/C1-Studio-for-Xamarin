using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
	public partial class DataLabelController : UIViewController
	{
		FlexChart chart;

		public DataLabelController() : base("DataLabelController", null)
		{
		}

		public DataLabelController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			chart = new FlexChart();
			chart.ChartType = ChartType.Bar;
			chart.BindingX = "Name";
			chart.Series.Add(new ChartSeries() { SeriesName = "Total Expenses", Binding = "Expenses" });
			chart.ItemsSource = SalesData.GetSalesDataList2();
			chart.Palette = Palette.Organic;
			chart.AxisY.AxisLine = true;
			chart.AxisY.Labels = false;
			this.Add(chart);

			chart.DataLabel.Position = ChartLabelPosition.Left;
			chart.DataLabel.Content = "{x} {y}";
			chart.DataLabel.Border = true;
			chart.DataLabel.BorderStyle = new ChartStyle { Stroke = UIColor.Red, StrokeThickness = 1 };
			chart.DataLabel.Style = new ChartStyle { FontFamily = UIFont.SystemFontOfSize(20, UIFontWeight.Black) };

			modeSelector.SelectedSegment = 1;
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			chart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80 + 30,
									 this.View.Frame.Width, this.View.Frame.Height - 80 - 30);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void modeChanged(UISegmentedControl sender)
		{
			switch (sender.SelectedSegment)
			{
				case 0:
					chart.DataLabel.Position = ChartLabelPosition.None;
					break;
				case 1:
					chart.DataLabel.Position = ChartLabelPosition.Left;
					break;
				case 2:
					chart.DataLabel.Position = ChartLabelPosition.Top;
					break;
				case 3:
					chart.DataLabel.Position = ChartLabelPosition.Right;
					break;
				case 4:
					chart.DataLabel.Position = ChartLabelPosition.Bottom;
					break;
				case 5:
					chart.DataLabel.Position = ChartLabelPosition.Center;
					break;
			}
		}

	}
}


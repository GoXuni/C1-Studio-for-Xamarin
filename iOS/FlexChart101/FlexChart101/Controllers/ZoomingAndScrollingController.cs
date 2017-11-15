using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using C1.iOS.Core;
using System.Collections.Generic;
using Foundation;
using C1.iOS.Chart.Interaction;

namespace FlexChart101
{
	public partial class ZoomingAndScrollingController : UIViewController
	{
		public ZoomingAndScrollingController(IntPtr handle) : base (handle)
		{
		}

		public ZoomingAndScrollingController() : base("ZoomingAndScrollingController", null)
		{
		}

		partial void zoomModeChanged(UISegmentedControl sender)
		{
			ZoomBehavior z = chart.Behaviors[0] as ZoomBehavior;
			z.ZoomMode = (GestureMode)(int)sender.SelectedSegment;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			chart.ItemsSource = GenerateRandNormal(500);
			chart.Palette = Palette.Superhero; 
			chart.Header = NSBundle.MainBundle.LocalizedString("Drag to scroll/Pinch to zoom", "optional");
			chart.AxisY.Format = "n2";

			chart.BindingX = "X";
			chart.Series.Add(new ChartSeries() { SeriesName = "Normal Distribution", Binding = "Y" });
			chart.ChartType = ChartType.Scatter;
			chart.LegendPosition = ChartPositionType.Bottom;

			ZoomBehavior z = new ZoomBehavior();
			chart.Behaviors.Add(z);

			TranslateBehavior t = new TranslateBehavior();
			chart.Behaviors.Add(t);

			zoomModeSelector.SelectedSegment = 3;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		Random rnd = new Random();

		List<CGPoint> GenerateRandNormal(int n)
		{
			if (n % 2 == 1)
				n++;

			List<CGPoint> points = new List<CGPoint>(n);

			for (int i = 0; i < n / 2; i++)
			{
				do
				{
					double u = 2 * rnd.NextDouble() - 1;
					double v = 2 * rnd.NextDouble() - 1;

					double s = u * u + v * v;

					if (s < 1)
					{
						s = Math.Sqrt(-2 * Math.Log(s) / s);
						points.Add(new CGPoint(i, u * s));
						points.Add(new CGPoint(i + 1, v * s));
						break;
					}
				} while (true);
			}

			return points;
		}
	}
}


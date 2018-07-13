using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using C1.iOS.Chart.Interaction;
using Foundation;
using System.Collections.Generic;

namespace FlexChart101
{
	public partial class LineMarkerController : UIViewController
	{
		//FlexChart chart;
		C1LineMarker lineMarker;
		string[] lines = { NSBundle.MainBundle.LocalizedString("None", ""), NSBundle.MainBundle.LocalizedString("Vertical", ""), NSBundle.MainBundle.LocalizedString("Horizontal", ""), NSBundle.MainBundle.LocalizedString("Both", "") };
		string[] lineMarkerAlign = { NSBundle.MainBundle.LocalizedString("Right", ""), NSBundle.MainBundle.LocalizedString("Left", ""), NSBundle.MainBundle.LocalizedString("Auto", ""), NSBundle.MainBundle.LocalizedString("Bottom", ""), NSBundle.MainBundle.LocalizedString("Top", "") };
		string[] interaction = { NSBundle.MainBundle.LocalizedString("None", ""), NSBundle.MainBundle.LocalizedString("Move", ""), NSBundle.MainBundle.LocalizedString("Drag", "") };
		private IList<UILabel> yLabels = new List<UILabel>();
		private UILabel xLabel;

		public class LineMarkerModel : UIPickerViewModel
		{
			LineMarkerController tk;

			public LineMarkerModel(LineMarkerController tk)
			{
				this.tk = tk;
			}

			public override nint GetComponentCount(UIPickerView v)
			{
				return 3;
			}

			public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
			{
				if (component == 0)
					return tk.lines.Length;
				else if (component == 1)
					return tk.lineMarkerAlign.Length;
				else
					return tk.interaction.Length;
			}

			public override string GetTitle(UIPickerView picker, nint row, nint component)
			{
				if (component == 0)
					return tk.lines[row];
				else if (component == 1)
					return tk.lineMarkerAlign[row];
				else
					return tk.interaction[row];
			}

			public override void Selected(UIPickerView picker, nint row, nint component)
			{
				if (component == 0)
				{
					if (row == 0)
					{
						tk.lineMarker.Lines = LineMarkerLines.None;
					}
					else if (row == 1)
					{
						tk.lineMarker.Lines = LineMarkerLines.Vertical;
					}
					else if (row == 2)
					{
						tk.lineMarker.Lines = LineMarkerLines.Horizontal;
					}
					else if (row == 3)
					{
						tk.lineMarker.Lines = LineMarkerLines.Both;
					}
				}
				else if (component == 1)
				{
					if (row == 0)
					{
						tk.lineMarker.Alignment = LineMarkerAlignment.Right;
					}
					else if (row == 1)
					{
						tk.lineMarker.Alignment = LineMarkerAlignment.Left;
					}
					else if (row == 2)
					{
						tk.lineMarker.Alignment = LineMarkerAlignment.Auto;
					}
					else if (row == 3)
					{
						tk.lineMarker.Alignment = LineMarkerAlignment.Bottom;
					}
					else if (row == 4)
					{
						tk.lineMarker.Alignment = LineMarkerAlignment.Top;
					}
				}
				else
				{
					if (row == 0)
					{
						tk.lineMarker.Interaction = LineMarkerInteraction.None;
					}
					else if (row == 1)
					{
						tk.lineMarker.Interaction = LineMarkerInteraction.Move;
					}
					else if (row == 2)
					{
						tk.lineMarker.Interaction = LineMarkerInteraction.Drag;
					}
				}

			}
		}

		public LineMarkerController() : base("LineMarkerController", null)
		{
		}

		public LineMarkerController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			picker.Select(1, 0, false);
			picker.Select(1, 2, false);
            picker.Select(2, 1, false);
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			picker.Model = new LineMarkerModel(this);

			chart.ItemsSource = new LineMarkerViewModel().Items;
            // initialize series elements and set the binding to variables of
            // ChartPoint
            chart.ChartType = ChartType.Line;
            chart.BindingX = "Date";
            ChartSeries inputSeries = new ChartSeries();
			ChartSeries outputSeries = new ChartSeries();
			inputSeries.SeriesName = "Input";
            inputSeries.Binding = "Input";
            outputSeries.SeriesName = "Output";
            outputSeries.Binding = "Output";
            chart.Series.Add(inputSeries);
            chart.Series.Add(outputSeries);

			initMarker();
			chart.Layers.Add(lineMarker);
		}

		private void initMarker()
		{
			lineMarker = new C1LineMarker();
			lineMarker.DragContent = true;
			UIView view = new UIView(new CGRect(0, 0, 110, 70));
			xLabel = new UILabel(new CGRect(5, 5 , 110, 20));
			view.Add(xLabel);
            view.BackgroundColor = UIColor.FromRGBA(0.53f, 0.53f, 0.53f, 1.00f);
			for (int index = 0; index < chart.Series.Count; index++)
			{
				var series = chart.Series[index];
				var fill = ((IChart)chart).GetColor(index);
				UILabel yLabel = new UILabel(new CGRect(5, 25 + 20*index, 110, 20));
				yLabels.Add(yLabel);
                yLabel.TextColor = index == 0 ? UIColor.FromRGBA(0.53f, 0.67f, 0.78f, 1.00f) : UIColor.FromRGBA(0.89f, 0.66f, 0.38f, 1.00f);
				view.Add(yLabel);
			}
			lineMarker.Content = view;
			lineMarker.PositionChanged += LineMarker_PositionChanged;
		}

		private void LineMarker_PositionChanged(object sender, PositionChangedArgs e)
		{
			if (chart != null)
			{
				var info = chart.HitTest(new CGPoint(e.Position.X, double.NaN));
				int pointIndex = info.PointIndex;
				xLabel.Text = string.Format("{0:MM-dd}", info.X);

				for (int index = 0; index < chart.Series.Count; index++)
				{
					var series = chart.Series[index];
					var value = series.GetValues(0)[pointIndex];

					var fill = (int)((IChart)chart).GetColor(index);
					string content = string.Format("{0} = {1}", series.SeriesName, string.Format("{0:f0}", value));
					UILabel yLabel = yLabels[index];
					yLabel.Text = content;
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


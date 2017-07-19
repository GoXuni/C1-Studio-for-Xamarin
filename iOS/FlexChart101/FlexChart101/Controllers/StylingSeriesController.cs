using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class StylingSeriesController : UIViewController
    {
        FlexChart chart;

        public StylingSeriesController() : base("StylingSeriesController", null)
        {
        }

        public StylingSeriesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            chart = new FlexChart();
            chart.BindingX = "Name";
            chart.Series.Add(new ChartSeries()
            {
                SeriesName = "Sales",
                Binding = "Sales,Sales",
                Style = new ChartStyle { Fill = new UIColor(0, 0.8f, 0, 1), Stroke = UIColor.Green, StrokeThickness = 2 } 
            });
            chart.Series.Add(new ChartSeries() 
            { 
                SeriesName = "Expenses", 
                Binding = "Expenses,Expenses",
                Style = new ChartStyle { Fill = UIColor.Red, Stroke = new UIColor(0.702f, 0, 0, 1), StrokeThickness = 2 }
            });
            chart.Series.Add(new ChartSeries() 
            { 
                SeriesName = "Downloads", 
                Binding = "Downloads,Downloads", 
                ChartType = ChartType.LineSymbols,
                Style = new ChartStyle { Fill = new UIColor(1, 0.416f, 1, 1), Stroke = UIColor.Blue, StrokeThickness = 10 },
                SymbolStyle = new ChartStyle { Fill = UIColor.Yellow, Stroke = UIColor.Yellow, StrokeThickness = 5 }
            });
            chart.ItemsSource = SalesData.GetSalesDataList();
            this.Add(chart);
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


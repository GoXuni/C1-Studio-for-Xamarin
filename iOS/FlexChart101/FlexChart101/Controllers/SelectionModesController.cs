using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using Foundation;

namespace FlexChart101
{
    public partial class SelectionModesController : UIViewController
    {
        FlexChart chart;

        string[] chartTypes = { NSBundle.MainBundle.LocalizedString("Column", ""), NSBundle.MainBundle.LocalizedString("Bar", ""), NSBundle.MainBundle.LocalizedString("Scatter", ""), NSBundle.MainBundle.LocalizedString("Line", ""), NSBundle.MainBundle.LocalizedString("LineSymbol", ""), NSBundle.MainBundle.LocalizedString("Area", "") };
        string[] chartSelection = { NSBundle.MainBundle.LocalizedString("None", ""), NSBundle.MainBundle.LocalizedString("Series", ""), NSBundle.MainBundle.LocalizedString("Point", "") };

        public class ChartTypesModel : UIPickerViewModel
        {
            SelectionModesController tk;

            public ChartTypesModel(SelectionModesController tk)
            {
                this.tk = tk;
            }

            public override nint GetComponentCount(UIPickerView v)
            {
                return 2;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                if (component == 0)
                    return tk.chartTypes.Length;
                else
                    return tk.chartSelection.Length;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                if (component == 0)
                    return tk.chartTypes[row];
                else
                    return tk.chartSelection[row];
            }

            public override void Selected(UIPickerView picker, nint row, nint component)
            {
                if (component == 0)
                {
                    if (row == 0)
                    {
                        tk.chart.ChartType = ChartType.Column;
                    }
                    else if (row == 1)
                    {
                        tk.chart.ChartType = ChartType.Bar;
                    }
                    else if (row == 2)
                    {
                        tk.chart.ChartType = ChartType.Scatter;
                    }
                    else if (row == 3)
                    {
                        tk.chart.ChartType = ChartType.Line;
                    }
                    else if (row == 4)
                    {
                        tk.chart.ChartType = ChartType.LineSymbols;
                    }
                    else if (row == 5)
                    {
                        tk.chart.ChartType = ChartType.Area;
                    }
                }
                else if (component == 1)
                {
                    if (row == 0)
                    {
                        tk.chart.SelectionMode = ChartSelectionModeType.None;

                    }
                    else if (row == 1)
                    {
                        tk.chart.SelectionMode = ChartSelectionModeType.Series;
                    }
                    else if (row == 2)
                    {
                        tk.chart.SelectionMode = ChartSelectionModeType.Point;
                    }
                }

            }

        }

        public SelectionModesController() : base("SelectionModesController", null)
        {
        }

        public SelectionModesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            picker.Model = new ChartTypesModel(this);

            chart = new FlexChart();
            chart.BindingX = "Name";
            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Sales" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Expenses" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads,Downloads" });
            chart.ItemsSource = SalesData.GetSalesDataList();
            this.Add(chart);

            chart.SelectionMode = ChartSelectionModeType.Series;
            chart.SelectionStyle = new ChartStyle { Stroke = UIColor.Red, StrokeThickness = 3 };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            picker.Select(0, 0, false);
            picker.Select(1, 1, false);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            chart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80 + 140,
                                     this.View.Frame.Width, this.View.Frame.Height - 80 - 140);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


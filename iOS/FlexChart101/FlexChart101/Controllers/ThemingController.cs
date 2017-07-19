using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class ThemingController : UIViewController
    {
        FlexChart chart;

        string[] pickerData = new string[] { "Standard", "Cocoa", "Coral", "Dark", "HighContrast", "Light", "Midnight", "Modern", "Organic", "Slate", "Zen", "Cyborg", "Superhero", "Flatly", "Darkly", "Cerulean" };

        public class ThemeModel : UIPickerViewModel
        {
            ThemingController tk = null;

            public ThemeModel(ThemingController tk)
            {
                this.tk = tk;
            }

            public override nint GetComponentCount(UIPickerView v)
            {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return tk.pickerData.Length;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                if (component == 0)
                    return tk.pickerData[row];
                else
                    return row.ToString();
            }

            public override void Selected(UIPickerView picker, nint row, nint component)
            {
                nint selected = picker.SelectedRowInComponent(0);
                var chart = tk.chart;
                switch (selected)
                {
                    case 0:
                        chart.Palette = Palette.Standard;
                        break;
                    case 1:
                        chart.Palette = Palette.Cocoa;
                        break;
                    case 2:
                        chart.Palette = Palette.Coral;
                        break;
                    case 3:
                        chart.Palette = Palette.Dark;
                        break;
                    case 4:
                        chart.Palette = Palette.Highcontrast;
                        break;
                    case 5:
                        chart.Palette = Palette.Light;
                        break;
                    case 6:
                        chart.Palette = Palette.Midnight;
                        break;
                    case 7:
                        chart.Palette = Palette.Modern;
                        break;
                    case 8:
                        chart.Palette = Palette.Organic;
                        break;
                    case 9:
                        chart.Palette = Palette.Slate;
                        break;
                    case 10:
                        chart.Palette = Palette.Zen;
                        break;
                    case 11:
                        chart.Palette = Palette.Cyborg;
                        break;
                    case 12:
                        chart.Palette = Palette.Superhero;
                        break;
                    case 13:
                        chart.Palette = Palette.Flatly;
                        break;
                    case 14:
                        chart.Palette = Palette.Darkly;
                        break;
                    case 15:
                        chart.Palette = Palette.Cerulean;
                        break;
                    default:
                        break;
                }

            }
        }

        public ThemingController() : base("ThemingController", null)
        {
        }

        public ThemingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            picker.Model = new ThemeModel(this);
            picker.ShowSelectionIndicator = true;

            chart = new FlexChart();
            chart.BindingX = "Name";
            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Sales" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Expenses" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads,Downloads" });
            chart.ItemsSource = SalesData.GetSalesDataList();
            this.Add(chart);
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


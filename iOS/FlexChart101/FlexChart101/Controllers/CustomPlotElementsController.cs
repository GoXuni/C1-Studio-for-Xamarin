using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using Foundation;
using System.Collections.Generic;
using C1.iOS.Core;
using System.Linq;

namespace FlexChart101
{
    public partial class CustomPlotElementsController : UIViewController
    {
        public CustomPlotElementsController() : base("CustomPlotElementsController", null)
        {
        }

        public CustomPlotElementsController(IntPtr handle) : base(handle)
        {
        }
        FlexChart chart;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            chart = new FlexChart();
            this.Add(chart);

            var cList = new List<Company>
            {
                new Company { Name = "Apple", DevicesSold = 15.58} ,
                new Company { Name = "Google", DevicesSold = 20.23 },
                new Company { Name = "Microsoft", DevicesSold = 10.46 },
            };

            chart.ItemsSource = cList;

            chart.BindingX = "Name";
            chart.Series.Add(new ChartSeries() { SeriesName = "DevicesSold", Binding = "DevicesSold,DevicesSold" });

            chart.LegendPosition = ChartPositionType.None;
            chart.AxisY.AxisLine = false;
            chart.AxisY.Title = "Devices Sold (billions)";
            chart.AxisY.Style = new ChartStyle() { FontAttributes = CoreText.CTFontSymbolicTraits.Italic, FontSize = 16 };

            chart.Series[0].SymbolLoading += (object sender, SymbolEventArgs e) =>
            {
                var company = e.Item as Company;
                string s = "Images/" + company.Name.ToLower() + ".png";
                var img = new UIImage(s);
                UIImageView imgView = new UIImageView(img);
                imgView.ContentMode = UIViewContentMode.ScaleAspectFit;
                e.PlotElement.Content = imgView;
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

    public class Company
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double DevicesSold { get; set; }
    }
}


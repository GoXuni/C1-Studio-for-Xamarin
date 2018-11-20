using FlexChart101.Resources;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;

namespace FlexChart101
{
    public partial class CustomPlotElements : ContentPage
    {

        public CustomPlotElements()
        {
            InitializeComponent();
            Title = AppResources.CustomPlotElementsTitle;

            flexChart1.ItemsSource = new List<Company>
            {
                new Company { Name = "Apple", DevicesSold = 15.58},
                new Company { Name = "Google", DevicesSold = 20.23 },
                new Company { Name = "Microsoft", DevicesSold = 10.46 },
            };

            flexChart1.AxisY.AxisLine = false;
            flexChart1.AxisY.Title = "Devices Sold (billions)";
            flexChart1.LegendPosition = ChartPositionType.None;
        }

        void OnSymbolLoading(object sender, SymbolEventArgs e)
        {
            var company = e.Item as Company;
            var img = new Image()
            {
                Source = ImageSource.FromResource(string.Format("FlexChart101.Images.{0}.png", company.Name.ToLower())),
                Aspect = Aspect.AspectFit,
            };
            var root = new Grid() { Children = { img }, Padding = 10, BackgroundColor = Color.SteelBlue};
            root.InputTransparent = true;
            e.PlotElement.Content = root;
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public double DevicesSold { get; set; }
    }
}

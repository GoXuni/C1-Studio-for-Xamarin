using FlexChart101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			this.flexChart1.ItemsSource = new List<Company>
			{
				new Company { Name = "Apple", DevicesSold = 15.58},
				new Company { Name = "Google", DevicesSold = 20.23 },
				new Company { Name = "Microsoft", DevicesSold = 10.46 },
			};

            this.flexChart1.AxisY.AxisLine = false;
            this.flexChart1.AxisY.Title = "Devices Sold (billions)";
            this.flexChart1.LegendPosition = ChartPositionType.None;
		}

        void OnSymbolRendering(object sender, RenderSymbolEventArgs e)
        {
            Company company;
            if (e.Item == null)
            {
                company = ((List<Company>)flexChart1.ItemsSource).ElementAt(e.Index);
            }
            else
            {
                company = e.Item as Company;
            }

            e.PlotElement = new PlotElementWithIcon(company);
        }
	}

	public class PlotElementWithIcon : ChartPlotElement
	{
		Company company;
		Image img;
		Layout root;

		public PlotElementWithIcon(Company company)
		{
			this.company = company;
			this.img = new Image()
			{
				Source = ImageSource.FromResource(string.Format("FlexChart101.Images.{0}.png", this.company.Name.ToLower()))
			};
            root = new Grid() { Children = { this.img }, Padding = 10, BackgroundColor = Color.SteelBlue };
            root.InputTransparent = true;
            this.Content = root;
            
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

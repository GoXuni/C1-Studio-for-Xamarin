using System;
using C1.Xamarin.Forms.Chart;
using Sunburst101.Resources;
using Xamarin.Forms;
namespace Sunburst101
{
    public partial class LegendAndTitles
    {
        public LegendAndTitles()
        {
            InitializeComponent();
            Title = AppResources.LegendTitleTitle;
            this.lblHeader.Text = AppResources.Header;
            this.lblFooter.Text = AppResources.Footer;
            this.lblLegend.Text = AppResources.LegendPosition;

            this.sunburst.ItemsSource = new SunburstViewModel().HierarchicalData;
            this.pickerLegendPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;

            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerLegendPosition.Items.Add(item);
            }
            this.pickerLegendPosition.SelectedIndex = 1;
            this.sunburst.LegendPosition = ChartPositionType.Auto;

            this.sunburst.Header = AppResources.Header;
            this.sunburst.Footer = AppResources.Footer;
        }

        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.pickerLegendPosition.Items[this.pickerLegendPosition.SelectedIndex];
            this.sunburst.LegendPosition = (ChartPositionType)(Enum.Parse(typeof(ChartPositionType), type));
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                Grid.SetColumn(gridOption, 0);
                Grid.SetRow(gridOption, 0);
                Grid.SetColumnSpan(gridOption, 1);
                Grid.SetRowSpan(gridOption, 2);

                Grid.SetRow(sunburst, 0);
                Grid.SetColumn(sunburst, 1);
                Grid.SetRowSpan(sunburst, 2);
                Grid.SetColumnSpan(sunburst, 1);

                Grid.SetRow(header, 0);
                Grid.SetColumn(header, 0);
                Grid.SetRow(footer, 1);
                Grid.SetColumn(footer, 0);
                Grid.SetRow(legend, 2);
                Grid.SetColumn(legend, 0);
            }
            else
            {
                this.gridOption.HorizontalOptions = LayoutOptions.FillAndExpand;
                Grid.SetRow(gridOption, 0);
                Grid.SetColumn(gridOption, 0);
                Grid.SetColumnSpan(gridOption, 2);
                Grid.SetRowSpan(gridOption, 1);

                Grid.SetRow(sunburst, 1);
                Grid.SetColumn(sunburst, 0);
                Grid.SetColumnSpan(sunburst, 2);
                Grid.SetRowSpan(sunburst, 2);

                Grid.SetRow(header, 0);
                Grid.SetColumn(header, 0);
                Grid.SetRow(footer, 0);
                Grid.SetColumn(footer, 1);
                Grid.SetRow(legend, 1);
                Grid.SetColumn(legend, 0);

            }
        }

    }
}

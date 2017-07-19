using System;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using Xamarin.Forms;
namespace FlexChart101
{
    public partial class PieLegendAndTitlesSample
    {
        public PieLegendAndTitlesSample()
        {
            InitializeComponent();
            Title = AppResources.PieLegendSampleTitle;
            this.lblHeader.Text = AppResources.Header;
            this.lblFooter.Text = AppResources.Footer;
            this.lblLegend.Text = AppResources.LegendPosition;

            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.pickerLegendPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;

            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerLegendPosition.Items.Add(item);
            }
            this.pickerLegendPosition.SelectedIndex = 1;
            this.flexPie.LegendPosition = ChartPositionType.Auto;
            this.flexPie.ToolTip = null;
        }

        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.pickerLegendPosition.Items[this.pickerLegendPosition.SelectedIndex];
            this.flexPie.LegendPosition = (ChartPositionType)(Enum.Parse(typeof(ChartPositionType), type));
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                Grid.SetColumn(gridOption, 0);
                Grid.SetRow(gridOption, 0);
                Grid.SetColumnSpan(gridOption, 2);
                Grid.SetRowSpan(gridOption, 2);

                Grid.SetRow(flexPie, 0);
                Grid.SetColumn(flexPie, 1);
                Grid.SetRowSpan(flexPie, 2);
                Grid.SetColumnSpan(flexPie, 1);

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

                Grid.SetRow(flexPie, 1);
                Grid.SetColumn(flexPie, 0);
                Grid.SetColumnSpan(flexPie, 2);
                Grid.SetRowSpan(flexPie, 2);

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

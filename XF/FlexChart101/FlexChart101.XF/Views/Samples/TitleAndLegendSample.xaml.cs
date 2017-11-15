using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class TitleAndLegendSample
    {
        public TitleAndLegendSample()
        {
            InitializeComponent();
            Title = AppResources.LegendSampleTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
    }
}

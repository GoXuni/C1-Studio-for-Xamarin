using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class MixedChartTypesSample
    {
        public MixedChartTypesSample()
        {
            InitializeComponent();
            Title = AppResources.MixedChartTypesTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
    }
}

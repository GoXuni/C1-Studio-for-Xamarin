using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class BubbleChartSample
    {
        public BubbleChartSample()
        {
            InitializeComponent();
            Title = AppResources.BubbleChartTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            //this.flexChart.LegendPosition = C1.Xamarin.Forms.Chart.ChartPositionType.Bottom;
        }
    }
}

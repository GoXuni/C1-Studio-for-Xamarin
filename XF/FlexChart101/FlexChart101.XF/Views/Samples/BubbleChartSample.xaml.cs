using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

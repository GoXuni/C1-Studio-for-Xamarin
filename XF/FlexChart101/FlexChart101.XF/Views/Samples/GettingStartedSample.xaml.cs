using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class GettingStartedSample
    {
        public GettingStartedSample()
        {
            InitializeComponent();

            Title = AppResources.GettingStartedTitle;
            flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
    }
}

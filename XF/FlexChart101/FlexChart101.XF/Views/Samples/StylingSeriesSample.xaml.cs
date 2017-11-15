using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class StylingSeriesSample
    {
        public StylingSeriesSample()
        {
            InitializeComponent();
            Title = AppResources.StylingSeriesTitle;
            
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
    }
}

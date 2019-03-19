using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

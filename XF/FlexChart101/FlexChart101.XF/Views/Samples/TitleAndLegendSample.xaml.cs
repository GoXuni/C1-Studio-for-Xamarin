using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

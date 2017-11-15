using C1.Xamarin.Forms.Chart.Platform.UWP;

namespace Sunburst101.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            FlexChartRenderer.Init();

            this.InitializeComponent();

            LoadApplication(new Sunburst101.App());
        }
    }
}

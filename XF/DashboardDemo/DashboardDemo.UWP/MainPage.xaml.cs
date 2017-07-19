using C1.Xamarin.Forms.Chart.Platform.UWP;
using C1.Xamarin.Forms.Gauge.Platform.UWP;

namespace DashboardDemo.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            FlexChartRenderer.Init();
            C1GaugeRenderer.Init();

            this.InitializeComponent();

            LoadApplication(new DashboardDemo.App());
        }
    }
}

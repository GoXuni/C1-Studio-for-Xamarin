using C1.Xamarin.Forms.Chart.Platform.UWP;

namespace FlexChart101.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            FlexChartRenderer.Init();

            this.InitializeComponent();

            LoadApplication(new FlexChart101.App());
        }
    }
}

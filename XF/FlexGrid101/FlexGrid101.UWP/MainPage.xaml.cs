using C1.Xamarin.Forms.Grid.Platform.UWP;
using C1.Xamarin.Forms.Gauge.Platform.UWP;

namespace FlexGrid101.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            FlexGridRenderer.Init();
            C1GaugeRenderer.Init();

            this.InitializeComponent();

            LoadApplication(new FlexGrid101.App());
        }
    }
}

using C1.Xamarin.Forms.Gauge.Platform.UWP;

namespace C1Gauge101.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            C1GaugeRenderer.Init();

            this.InitializeComponent();

            LoadApplication(new C1Gauge101.App());
        }
    }
}

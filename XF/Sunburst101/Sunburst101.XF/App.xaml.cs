using Xamarin.Forms;

namespace Sunburst101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new Xamarin.Forms.NavigationPage(new FlexChartSamples()) { BarBackgroundColor = Color.FromHex("#9D2235"), BarTextColor = Color.White };
            }
            else
            {
                MainPage = new Xamarin.Forms.NavigationPage(new FlexChartSamples()) { BarBackgroundColor = Color.FromHex("#9E9E9E"), BarTextColor = Color.White };
            }
        }

        protected override void OnStart()
        {
            C1.Xamarin.Forms.Core.LicenseManager.Key = Sunburst101.License.Key;
        }
    }
}

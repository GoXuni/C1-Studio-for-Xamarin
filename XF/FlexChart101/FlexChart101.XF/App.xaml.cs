using Xamarin.Forms;

namespace FlexChart101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Xamarin.Forms.NavigationPage(new FlexChartSamples()) { BarBackgroundColor = Color.FromHex("#9E9E9E"), BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
            C1.Xamarin.Forms.Core.LicenseManager.Key = FlexChart101.License.Key;
        }
    }
}

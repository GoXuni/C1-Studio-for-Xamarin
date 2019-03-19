using Sunburst101.Resources;
using Xamarin.Forms.Xaml;

namespace Sunburst101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStarted
    {
        public GettingStarted()
        {
            InitializeComponent();
            Title = AppResources.GettingStartedTitle;
            SunburstViewModel model = new SunburstViewModel();
            this.sunburst.ItemsSource = model.FlatData;
            
        }
    }
}

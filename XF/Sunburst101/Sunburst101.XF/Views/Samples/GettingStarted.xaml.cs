using Sunburst101.Resources;

namespace Sunburst101
{
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

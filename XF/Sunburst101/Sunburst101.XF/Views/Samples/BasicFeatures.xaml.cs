
using Sunburst101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sunburst101
{

    /// <summary>
    /// Interaction logic for BasicFeatures.xaml
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicFeatures
    {
        public BasicFeatures()
        {
            InitializeComponent();

            Title = AppResources.BasicFeaturesTitle;
            this.lblOffset.Text = AppResources.Offset;
            this.lblReversed.Text = AppResources.Reversed;
            this.lblStartAngle.Text = AppResources.StartAngle;
            this.lblRadius.Text = AppResources.InnerRadius;

            this.sunburst.ItemsSource = new SunburstViewModel().HierarchicalData;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                Grid.SetColumn(gridOption, 0);
                Grid.SetRow(gridOption, 0);
                Grid.SetRowSpan(gridOption, 2);

                Grid.SetRow(sunburst, 0);
                Grid.SetColumn(sunburst, 1);
                Grid.SetRowSpan(sunburst, 2);
            }
            else
            {
                Grid.SetRow(gridOption, 0);
                Grid.SetColumn(gridOption, 0);
                Grid.SetColumnSpan(gridOption, 2);

                Grid.SetRow(sunburst, 1);
                Grid.SetColumn(sunburst, 0);
                Grid.SetColumnSpan(sunburst, 2);
            }
        }
    }
}

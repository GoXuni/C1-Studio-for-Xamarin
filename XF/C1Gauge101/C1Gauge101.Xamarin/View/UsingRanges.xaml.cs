using C1Gauge101.Resources;
using Xamarin.Forms;

namespace C1Gauge101
{
    public partial class UsingRanges : ContentPage
    {
        public UsingRanges()
        {
            InitializeComponent();
            this.lblShowRanges.Text = AppResources.ShowRanges;
            Title = AppResources.UsingRangesTitle;

            BindingContext = new SampleViewModel() { Value = 25 };

            linearGauge.Pointer.Thickness = 0.5;
            radialGauge.Pointer.Thickness = 0.5;
        }
    }
}

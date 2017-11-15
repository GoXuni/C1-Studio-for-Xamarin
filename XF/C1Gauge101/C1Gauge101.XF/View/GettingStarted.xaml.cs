using C1Gauge101.Resources;
using Xamarin.Forms;
using C1.Xamarin.Forms.Gauge;

namespace C1Gauge101
{
    public partial class GettingStarted : ContentPage
    {
        public GettingStarted()
        {
            InitializeComponent();
            Title = AppResources.GettingStartedTitle;
            this.lblValue.Text = AppResources.Value;
            BindingContext = new SampleViewModel() { Value = 25, ShowText = GaugeShowText.None };

            ValueLabel.Text = ValueStepper.Value.ToString("N0");
            ValueStepper.ValueChanged += ValueStepper_ValueChanged;
        }

        void ValueStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueLabel.Text = e.NewValue.ToString("N0");
        }
    }
}

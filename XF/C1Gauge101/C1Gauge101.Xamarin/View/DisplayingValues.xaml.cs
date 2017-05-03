using C1Gauge101.Resources;
using Xamarin.Forms;

namespace C1Gauge101
{
    public partial class DisplayingValues : ContentPage
    {
        public DisplayingValues()
        {
            InitializeComponent();
            Title = AppResources.DisplayingValuesTitle;
            this.lblShowText.Text = AppResources.ShowText;
            this.showItemsPicker.Title = new OnPlatform<string>
            {
                iOS = AppResources.ShowText,
                Android = AppResources.ShowText
            };
            BindingContext = new SampleViewModel() { Max = 1, Value = .25, Step = .01, Format = "P0", ShowRanges = false };
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //Populates show text picker, beause the property Items is not bindable.
            var viewModel = BindingContext as SampleViewModel;
            showItemsPicker.Items.Clear();
            foreach (var showTextItem in viewModel.ShowTextItems)
            {
                showItemsPicker.Items.Add(showTextItem);
            }
            viewModel.ShowTextSelectedIndex = 0;
        }
    }
}

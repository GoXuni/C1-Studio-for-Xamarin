using C1.Xamarin.Forms.Input;
using C1Input101.Resources;
using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace C1Input101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoCompleteSample
    {
        public AutoCompleteSample()
        {
            Countries = Country.GetCountries();
            var flagConverter = new FlagConverter();
            CountriesWithFlag = Country.GetCountries().Where(c => flagConverter.HasFlag(c.Name));
            InitializeComponent();
            Title = AppResources.AutoCompleteTitle;
            ACMLabel.Text = AppResources.AutoCompleteMode;
            ClearLabel.Text = AppResources.ShowClearButton;
            foreach (var item in Enum.GetNames(typeof(AutoCompleteMode)))
            {
                this.ACMPicker.Items.Add(item);
            }
            this.ACMPicker.SelectedIndex = 1;
        }

        public string HighlightsText
        {
            get
            {
                return AppResources.Highlights;
            }
        }

        public string CustomDropDownText
        {
            get
            {
                return AppResources.CustomDropdown;
            }
        }

        public string DynamicText
        {
            get
            {
                return AppResources.Dynamic;
            }
        }

        public IEnumerable Countries { get; set; }

        public IEnumerable CountriesWithFlag { get; set; }

        private async void OnDynamicFiltering(object sender, AutoCompleteFilteringEventArgs e)
        {
            var autoComplete = sender as C1AutoComplete;
            var deferal = e.GetDeferral();
            try
            {
                var collectionView = new YouTubeDataCollection();
                await collectionView.SearchAsync(e.FilterString);
                autoComplete.SelectedIndex = -1;
                autoComplete.ItemsSource = collectionView;
                e.Cancel = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                deferal.Complete();
            }
        }

        private void ACMPicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.HighlightAC.AutoCompleteMode = (AutoCompleteMode)Enum.Parse(typeof(AutoCompleteMode), this.ACMPicker.Items[this.ACMPicker.SelectedIndex]);
            this.CustomAC.AutoCompleteMode = (AutoCompleteMode)Enum.Parse(typeof(AutoCompleteMode), this.ACMPicker.Items[this.ACMPicker.SelectedIndex]);
            this.DynamicAC.AutoCompleteMode = (AutoCompleteMode)Enum.Parse(typeof(AutoCompleteMode), this.ACMPicker.Items[this.ACMPicker.SelectedIndex]);

        }

        private void ClearSwitch_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            this.HighlightAC.ShowClearButton = e.Value;
            this.CustomAC.ShowClearButton = e.Value;
            this.DynamicAC.ShowClearButton = e.Value;
        }
    }
}

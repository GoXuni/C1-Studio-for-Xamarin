using C1.Xamarin.Forms.Input;
using C1Input101.Resources;
using System.Collections;
using System.Linq;

namespace C1Input101
{
    public partial class AutoCompleteSample
    {
        public AutoCompleteSample()
        {
            Countries = Country.GetCountries();
            var flagConverter = new FlagConverter();
            CountriesWithFlag = Country.GetCountries().Where(c => flagConverter.HasFlag(c.Name));
            InitializeComponent();
            Title = AppResources.AutoCompleteTitle;
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
                var collectionView = new YouTubeCollectionView();
                await collectionView.SearchAsync(e.FilterString);
                autoComplete.ItemsSource = collectionView;
                e.Cancel = true;
            }
            finally
            {
                deferal.Complete();
            }
        }
    }
}

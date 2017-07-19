using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1Input101.Resources;
using C1.CollectionView;
using System.Linq.Expressions;
using System.Collections;
using C1.Xamarin.Forms.Input;
using System.Collections.ObjectModel;

namespace C1Input101
{
    public partial class AutoCompleteSample
    {
        ObservableCollection<Country> countries;
        public AutoCompleteSample()
        {
            countries = Country.GetCountries();
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

        public string DelayText
        {
            get
            {
                return AppResources.Delay;
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

        public IEnumerable ItemsSource
        {
            get
            {
                return this.countries;
            }
        }

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

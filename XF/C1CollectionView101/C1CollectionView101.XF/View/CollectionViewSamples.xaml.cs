using C1CollectionView101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace C1CollectionView101

{
    public partial class CollectionViewSamples : ContentPage
    {
        public CollectionViewSamples()
        {
            InitializeComponent();
            Title = "C1CollectionView 101";
            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.SortingTitle, Description= AppResources.SortingDescription, SampleViewType = 0, Thumbnail="sort.png" },
                new Sample() { Name = AppResources.FilteringTitle, Description= AppResources.FilteringDescription, SampleViewType = 1, Thumbnail="filter.png" },
                new Sample() { Name = AppResources.GroupingTitle, Description= AppResources.GroupingDescription, SampleViewType = 2, Thumbnail="flexgrid_grouping.png"},
                new Sample() { Name = AppResources.SimpleOnDemandTitle, Description= AppResources.SimpleOnDemandDescription, SampleViewType = 4, Thumbnail="flexgrid_loading.png" },
                new Sample() { Name = AppResources.OnDemandTitle, Description= AppResources.OnDemandDescription, SampleViewType = 3, Thumbnail="flexgrid_loading.png" },
            };
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                listView.IsEnabled = false;
                var sample = e.Item as Sample;
                await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
            }
            finally
            {
                listView.IsEnabled = true;
            }
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 0: return new Sorting();
                case 1: return new Filtering();
                case 2: return new Grouping();
                case 3: return new OnDemand();
                case 4: return new SimpleOnDemand();
            }
            return null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}

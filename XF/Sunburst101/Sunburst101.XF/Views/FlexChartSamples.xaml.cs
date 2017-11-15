using Sunburst101.Resources;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Sunburst101
{
    public partial class FlexChartSamples 
    {
        public FlexChartSamples()
        {
            InitializeComponent();
            Title = "Sunburst101";
            BindingContext = GetSamples();
        }
        
        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescriptionShort, SampleViewType = 0, Thumbnail="GettingStarted.png"},
                new Sample() { Name = AppResources.GroupTitle, Description = AppResources.GroupDescriptionShort, SampleViewType = 1, Thumbnail="GroupCollection.png"},
                new Sample() { Name = AppResources.BasicFeaturesTitle, Description = AppResources.BasicFeaturesDescriptionShort, SampleViewType = 2, Thumbnail="BasicFeatures.png"},
                new Sample() { Name = AppResources.LegendTitleTitle, Description = AppResources.LegendTitleDescriptionShort, SampleViewType = 3, Thumbnail="LegendAndTitles.png"},
                new Sample() { Name = AppResources.SelectionTitle, Description = AppResources.SelectionDescriptionShort, SampleViewType = 4, Thumbnail="Selection.png"},
                new Sample() { Name = AppResources.PeriodicTableTitle, Description = AppResources.PeriodicTableDescriptionShort, SampleViewType = 5, Thumbnail="Selection.png"},

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
                case 0: return new GettingStarted();
                case 1: return new Group();
                case 2: return new BasicFeatures();
                case 3: return new LegendAndTitles();
                case 4: return new Selection();
                case 5: return new PeriodicTable();
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

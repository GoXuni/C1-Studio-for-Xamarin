using FlexViewer101.Resources;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlexViewerSamples : ContentPage
    {
        public FlexViewerSamples()
        {
            InitializeComponent();
            BindingContext = GetSamples();
            this.Title = "FlexViewer101";
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail="GettingStarted.png"},
                new Sample() { Name = AppResources.PdfBrowserTitle, Description = AppResources.PdfBrowserDescription, SampleViewType = 2 , Thumbnail="BrowsePDF.jpg"},
                new Sample() { Name = AppResources.CustomizeAppearanceTitle, Description = AppResources.CustomizeAppearanceDescription, SampleViewType = 3 , Thumbnail="CustomizeApearance.jpg"},
                new Sample() { Name = AppResources.ExportTitle, Description = AppResources.ExportDescription, SampleViewType = 4 , Thumbnail="Export.png"},
            };
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var sample = e.Item as Sample;
                listView.IsEnabled = false;
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
                case 1: return new GettingStarted();
                case 2: return new PdfBrowser();
                case 3: return new CustomizeAppearance();
                case 4: return new Export();
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

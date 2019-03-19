using C1.CollectionView;
using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnDemand : ContentPage
    {
        YouTubeCollectionView _collectionView;

        public OnDemand()
        {
            InitializeComponent();

            this.Title = AppResources.OnDemandTitle;
            search.Placeholder = AppResources.SearchPlaceholderText;
            emptyListLabel.Text = AppResources.EmptyListText;

            Load();
        }

        private async void Load()
        {
            _collectionView = new YouTubeCollectionView() { PageSize = 25 };
            var grouping = new C1GroupCollectionView<YouTubeVideo>(_collectionView, false);
            await grouping.GroupAsync("PublishedDay");
            grid.ItemsSource = grouping;
            grid.MinColumnWidth = 85;
            search.Text = "Xamarin.Forms";
            var task = PerformSearch();
        }

        private async void OnCompleted(object sender, EventArgs e)
        {
            await PerformSearch();
            grid.Focus();
        }

        private async Task PerformSearch()
        {
            try
            {
                activityIndicator.IsRunning = true;
                grid.Focus();
                await _collectionView.SearchAsync(search.Text);
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }

        private void OnCellDoubleTapped(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellType == GridCellType.Cell)
            {
                var video = grid.Rows[e.CellRange.Row].DataItem as YouTubeVideo;
                if (video != null)
                    Device.OpenUri(new Uri(video.Link));
            }
        }
    }
}

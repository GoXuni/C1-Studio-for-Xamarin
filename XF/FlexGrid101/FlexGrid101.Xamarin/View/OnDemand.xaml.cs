using FlexGrid101.Resources;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class OnDemand : ContentPage
    {
        YouTubeCollectionView _collectionView;

        public OnDemand()
        {
            InitializeComponent();

            this.Title = AppResources.OnDemandTitle;
            search.Placeholder = AppResources.SearchPlaceholderText;
            emptyListLabel.Text = AppResources.EmptyListText;

            _collectionView = new YouTubeCollectionView() { PageSize = 25 };
            grid.ItemsSource = _collectionView;
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

        private void OnCellDoubleTapped(object sender, C1.Xamarin.Forms.Grid.GridCellRangeEventArgs e)
        {
            var video = grid.Rows[e.CellRange.Row].DataItem as YouTubeVideo;
            Device.OpenUri(new Uri(video.Link));
        }
    }
}

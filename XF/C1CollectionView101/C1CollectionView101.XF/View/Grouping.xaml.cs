using C1CollectionView101.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.CollectionView;

namespace C1CollectionView101
{
    public partial class Grouping : ContentPage
    {
        C1CollectionView<YouTubeVideo> _collectionView;
        ObservableCollection<YouTubeVideo> _videos;

        public Grouping()
        {
            InitializeComponent();
            Title = AppResources.GroupingTitle;

            list.IsGroupingEnabled = true;
            list.GroupDisplayBinding = new Binding("Group");
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            try
            {
                message.IsVisible = false;
                list.IsVisible = false;
                activityIndicator.IsRunning = true;
                _videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin Forms", "relevance", null, 50)).Item2);
                _collectionView = new C1CollectionView<YouTubeVideo>(_videos);
                await _collectionView.GroupAsync(v => v.ChannelTitle);
                list.ItemsSource = _collectionView;
                list.IsVisible = true;
            }
            catch
            {
                message.Text = AppResources.InternetConnectionError;
                message.IsVisible = true;
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is YouTubeVideo)
            {
                var video = e.Item as YouTubeVideo;
                Device.OpenUri(new Uri(video.Link));
            }
        }
    }
}

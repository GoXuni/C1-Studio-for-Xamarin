using CoreGraphics;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;

namespace C1CollectionView101
{
    public partial class SortingController : UITableViewController
    {
        C1CollectionView<YouTubeVideo> _collectionView;

        public SortingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            var indicator = new UIActivityIndicatorView(new CGRect(0, 0, 40, 40));
            indicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
            indicator.Center = View.Center;
            View.AddSubview(indicator);
            try
            {
                indicator.StartAnimating();
                var videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin iOS", "relevance", null, 50)).Item2);
                _collectionView = new C1CollectionView<YouTubeVideo>(videos);
                TableView.Source = new YouTubeCollectionViewSource(TableView, _collectionView);
            }
            catch
            {
                var alert = new UIAlertView("", "There was a problem when trying to get the data from internet.Please check your internet connection", null, "OK");
                alert.Show();
            }
            finally
            {
                indicator.StopAnimating();
            }
        }

        async partial void SortButton_Activated(UIBarButtonItem sender)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                await _collectionView.SortAsync(x => x.Title, direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            }
        }

        private SortDirection GetCurrentSortDirection()
        {
            var sort = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "Title");
            return sort != null ? sort.Direction : SortDirection.Descending;
        }

        //private void OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item is YouTubeVideo)
        //    {
        //        var video = e.Item as YouTubeVideo;
        //        Device.OpenUri(new Uri(video.Link));
        //    }
        //}
    }
}
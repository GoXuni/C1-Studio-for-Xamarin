using CoreGraphics;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;

namespace C1CollectionView101
{
    public partial class GroupingController : UITableViewController
    {
        public GroupingController(IntPtr handle) : base(handle)
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
                var videos = (await YouTubeCollectionView.LoadVideosAsync("Xamarin iOS", "relevance", null, 50)).Item2;
                var source = new YouTubeTableViewSource(TableView) { ItemsSource = videos };
                await source.CollectionView.GroupAsync("ChannelTitle");
                TableView.Source = source;
            }
            catch
            {
                var alert = new UIAlertView("", Foundation.NSBundle.MainBundle.LocalizedString("InternetConnectionError", ""), null, "OK");
                alert.Show();
            }
            finally
            {
                indicator.StopAnimating();
            }
        }

    }
}
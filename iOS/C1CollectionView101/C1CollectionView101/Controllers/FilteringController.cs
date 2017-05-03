using CoreGraphics;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;

namespace C1CollectionView101
{
    public partial class FilteringController : UIViewController
    {
        private C1CollectionView<YouTubeVideo> _collectionView;

        public FilteringController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            FilterField.EditingChanged += OnValueChanged;
            FilterField.ShouldReturn = new UITextFieldCondition(tf => { tf.ResignFirstResponder(); return true; });
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

        private async void OnValueChanged(object sender, EventArgs e)
        {
            await _collectionView.FilterAsync(FilterField.Text);
        }
    }
}
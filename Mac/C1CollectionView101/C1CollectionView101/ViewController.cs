using System;
using AppKit;
using Foundation;
using C1.CollectionView;
using C1.Mac.CollectionView;
using System.Threading.Tasks;

namespace C1CollectionView101
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        public ViewController()
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            //var collectionView = new YouTubeCollectionView();
            //await collectionView.SearchAsync("Xamarin.Mac");
            var videos = await YouTubeCollectionView.LoadVideosAsync("Xamarin.Mac", "relevance", null, 50);
            var source = new C1TableViewSource(TableView);
            source.ItemsSource = videos.Item2;
            await source.CollectionView.GroupAsync("ChannelTitle");
            TableView.Source = source;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}

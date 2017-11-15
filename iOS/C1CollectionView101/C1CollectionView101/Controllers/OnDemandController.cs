using C1.CollectionView;
using C1.iOS.CollectionView;
using CoreGraphics;
using System;
using System.Threading.Tasks;
using UIKit;

namespace C1CollectionView101
{
    public partial class OnDemandController : UIViewController
    {
        YouTubeCollectionView _collectionView;

        public OnDemandController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Load();
        }

        private async void Load()
        {
            CollectionView.BackgroundColor = UIColor.White;
            SearchField.EditingChanged += OnSearchEditingChanged;
            SearchField.ShouldReturn = new UITextFieldCondition(tf => { tf.ResignFirstResponder(); return true; });
            _collectionView = new YouTubeCollectionView();
            _collectionView.PageSize = 50;
            var itemSize = 100;
            var grouping = new C1GroupCollectionView<YouTubeVideo>(_collectionView, false);
            await grouping.GroupAsync("PublishedDay");
            var source = new YouTubeCollectionViewSource(CollectionView);
            source.ItemsSource = grouping;
            source.EmptyMessageLabel.TextColor = UIColor.Black;
            source.EmptyMessageLabel.Text = Foundation.NSBundle.MainBundle.LocalizedString("EmptyText", ""); ;
            var layout = new C1CollectionViewFlowLayout();
            layout.SectionHeadersPinToVisibleBounds = true;
            layout.EstimatedItemSize = new CGSize(itemSize, itemSize);
            source.CollectionViewLayout = layout;
            CollectionView.Source = source;
        }

        private async void OnSearchEditingChanged(object sender, EventArgs e)
        {
            await _collectionView.SearchAsync(SearchField.Text);
        }
    }
}
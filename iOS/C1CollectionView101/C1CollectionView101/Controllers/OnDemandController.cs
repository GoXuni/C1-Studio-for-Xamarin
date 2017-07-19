using System;
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

            var refreshControl = new UIRefreshControl();
            TableView.AddSubview(refreshControl);
            SearchField.EditingChanged += OnSearchEditingChanged;
            SearchField.ShouldReturn = new UITextFieldCondition(tf => { tf.ResignFirstResponder(); return true; });
            _collectionView = new YouTubeCollectionView();
            var source = new YouTubeTableViewSource(TableView, _collectionView, refreshControl);
            source.EmptyMessage = Foundation.NSBundle.MainBundle.LocalizedString("EmptyText", ""); ;
            TableView.Source = source;
        }

        private async void OnSearchEditingChanged(object sender, EventArgs e)
        {
            await _collectionView.SearchAsync(SearchField.Text);
        }
    }
}
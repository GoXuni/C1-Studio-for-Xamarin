using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
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

            _collectionView = new YouTubeCollectionView() { PageSize = 25 };
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Add(new GridImageColumn { Binding = "Thumbnail", Header = " ", Width = new GridLength(70), ImagePadding = new UIEdgeInsets(4, 4, 4, 0), PlaceholderImage = new UIImage("Images/default.png") });
            Grid.Columns.Add(new GridColumn { Binding = "Title", Header = "Title", MinWidth = 180, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "ChannelTitle", Header = "Channel" });
            Grid.GridLinesVisibility = GridLinesVisibility.None;
            Grid.SelectionMode = GridSelectionMode.None;
            Grid.ItemsSource = _collectionView;
            Grid.CellTapped += OnCellTapped;
            SearchField.Text = "Xamarin iOS";
            SearchField.ShouldReturn = new UITextFieldCondition(OnShouldReturn);
            SearchField.EditingDidEnd += OnEditingDidEnd;
            var task = PerformSearch();
        }

        private bool OnShouldReturn(UITextField textField)
        {
            textField.ResignFirstResponder();
            return true;
        }

        private async void OnEditingDidEnd(object sender, EventArgs e)
        {
            await PerformSearch();
            Grid.BecomeFirstResponder();
        }

        private void OnCellTapped(object sender, GridCellRangeEventArgs e)
        {
            var video = Grid.Rows[e.CellRange.Row].DataItem as YouTubeVideo;
            if (video != null)
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl(video.Link));
            }
        }

        private async Task PerformSearch()
        {
            try
            {
                ActivityIndicator.StartAnimating();
                Grid.BecomeFirstResponder();
                await _collectionView.SearchAsync(SearchField.Text);
            }
            finally
            {
                ActivityIndicator.StopAnimating();
            }
        }

    }
}
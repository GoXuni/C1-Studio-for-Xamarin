using Foundation;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;
using C1.iOS.CollectionView;

namespace C1CollectionView101
{
    public class YouTubeTableViewSource : C1TableViewSource<object>
    {
        private string CellIdentifier = "YouTube";
        private Dictionary<string, UIImage> _cache = new Dictionary<string, UIImage>();

        public YouTubeTableViewSource(UITableView tableView, ICollectionView<object> collectionView, UIRefreshControl refreshControl = null)
            : base(tableView, collectionView, refreshControl)
        {
        }

        public override UITableViewCell GetItemCell(UITableView tableView, object item)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);

            var video = item as YouTubeVideo;
            LoadImageInBackground(cell.ImageView, video.Thumbnail);
            cell.TextLabel.Text = video.Title;
            cell.DetailTextLabel.Text = video.Description;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var video = GetItem(indexPath) as YouTubeVideo;
            if (video != null)
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl(video.Link));
            }
        }

        #region ** images

        static UIImage _placeHolder;
        static UIImage PlaceHolder
        {
            get
            {
                if (_placeHolder == null)
                {
                    _placeHolder = new UIImage("Images/default.png");
                }
                return _placeHolder;
            }
        }

        protected async void LoadImageInBackground(UIImageView imageView, string url)
        {
            UIImage image;
            imageView.Tag = url.GetHashCode();
            if (!_cache.TryGetValue(url, out image))
            {
                imageView.Image = PlaceHolder;
                image = await Task.Run(() => new UIImage(NSData.FromUrl(new NSUrl(url))));
                _cache[url] = image;
            }
            if (imageView.Tag == url.GetHashCode())
            {
                imageView.Image = image;
            }
        }

        #endregion
    }
}

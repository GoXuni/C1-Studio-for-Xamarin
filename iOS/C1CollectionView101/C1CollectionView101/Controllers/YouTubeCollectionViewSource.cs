using Foundation;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;

namespace C1CollectionView101
{
    public class YouTubeCollectionViewSource : XuniCollectionViewSource<object>
    {
        private string CellIdentifier = "YouTube";
        private Dictionary<string, UIImage> _cache = new Dictionary<string, UIImage>();

        public YouTubeCollectionViewSource(UITableView tableView, ICollectionView<object> collectionView, UIRefreshControl refreshControl = null, string emptyMessage = null)
            : base(tableView, collectionView, refreshControl, emptyMessage)
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

        private YouTubeVideo GetVideo(NSIndexPath indexPath)
        {
            var grouping = CollectionView as ISupportGrouping;
            YouTubeVideo video;
            if (grouping != null && grouping.GroupDescriptions.Count == 1)
            {
                var group = CollectionView[indexPath.Section] as ICollectionViewGroup<object, object>;
                video = group[indexPath.Row] as YouTubeVideo;
            }
            else
            {
                video = CollectionView[indexPath.Row] as YouTubeVideo;
            }

            return video;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var video = GetVideo(indexPath);
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

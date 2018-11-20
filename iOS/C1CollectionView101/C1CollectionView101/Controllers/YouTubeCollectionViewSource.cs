using C1.iOS.CollectionView;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;
using System;

namespace C1CollectionView101
{
    internal class YouTubeCollectionViewSource : C1CollectionViewSource<object>
    {
        private string YouTubeCellIdentifier = "YouTube";
        private string YouTubeHeaderIdentifier = "YouTubeHeader";

        public YouTubeCollectionViewSource(UICollectionView collectionView)
            : base(collectionView)
        {
            UICollectionView.RegisterClassForCell(typeof(YouTubeCell), YouTubeCellIdentifier);
            UICollectionView.RegisterClassForSupplementaryView(typeof(YouTubeHeaderCell), UICollectionElementKindSection.Header, YouTubeHeaderIdentifier);
        }

        protected override UICollectionReusableView GetGroupCell(UICollectionView collectionView, NSIndexPath indexPath, ICollectionViewGroup<object, object> group)
        {
            var header = collectionView.DequeueReusableSupplementaryView(UICollectionElementKindSection.Header, YouTubeHeaderIdentifier, indexPath) as YouTubeHeaderCell;
            header.Title.Text = group.Group.ToString().ToUpper();
            header.Title.Font = UIFont.SystemFontOfSize(UIFont.SmallSystemFontSize);
            return header;
        }

        public override UICollectionViewCell GetItemCell(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            var cell = collectionView.DequeueReusableCell(YouTubeCellIdentifier, indexPath) as YouTubeCell;
            LoadImageInBackground(cell.ImageView, (item as YouTubeVideo)?.Thumbnail);
            return cell;
        }

        #region ** images

        private Dictionary<string, UIImage> _cache = new Dictionary<string, UIImage>();

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
            if (string.IsNullOrWhiteSpace(url))
            {
                imageView.Image = PlaceHolder;
                return;
            }
            UIImage image;
            imageView.Tag = url.GetHashCode();
            if (!_cache.TryGetValue(url, out image))
            {
                imageView.Image = PlaceHolder;
                try
                {
                    image = await Task.Run(() => new UIImage(NSData.FromUrl(new NSUrl(url))));
                    _cache[url] = image;
                }
                catch { }
            }
            if (imageView.Tag == url.GetHashCode() && image != null)
            {
                imageView.Image = image;
            }
        }

        #endregion
    }

    internal class YouTubeCell : UICollectionViewCell
    {
        public UIImageView ImageView { get; set; }

        [Export("initWithFrame:")]
        public YouTubeCell(CGRect frame)
            : base(frame)
        {
            ImageView = new UIImageView();
            ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            ImageView.Frame = new CGRect(new CGPoint(), frame.Size);
            ImageView.ClipsToBounds = true;
            ContentView.AddSubview(ImageView);
            AddConstraint(NSLayoutConstraint.Create(ImageView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(ImageView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(ImageView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(ImageView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0));
        }

        internal void UpdateImage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                ImageView.Image = null;
            else
                ImageView.Image = UIImage.LoadFromData(NSData.FromUrl(new NSUrl(url)));
        }
    }

    internal class YouTubeHeaderCell : UICollectionReusableView
    {
        [Export("initWithFrame:")]
        public YouTubeHeaderCell(CGRect frame)
            : base(frame)
        {
            Title = new UILabel();
            Title.Frame = new CGRect(new CGPoint(), frame.Size).Inset(4, 4);
            Title.TextColor = UIColor.Gray;
            BackgroundColor = UIColor.White;
            AddSubview(Title);
        }

        public UILabel Title { get; private set; }
        public nfloat SeparatorHeight { get; set; } = 1;

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            //Draws bottom separator
            var context = UIGraphics.GetCurrentContext();
            context.SetFillColor(UIColor.LightGray.CGColor);
            context.FillRect(new CGRect(0, rect.Height - SeparatorHeight, rect.Width, SeparatorHeight));
        }
    }
}
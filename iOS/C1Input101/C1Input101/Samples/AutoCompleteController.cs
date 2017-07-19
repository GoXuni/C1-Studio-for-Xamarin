using System;
using UIKit;
using Foundation;
using CoreGraphics;
using C1.iOS.Core;
using C1.iOS.Input;
using C1.CollectionView;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace C1Input101
{

    public partial class AutoCompleteController : UIViewController
    {
        public AutoCompleteController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            HighlightDropdown.DropDownHeight = 200;
            HighlightDropdown.DisplayMemberPath = "Name";
            HighlightDropdown.IsAnimated = true;
            HighlightDropdown.ItemsSource = Countries.GetDemoDataList();

            DelayDropdown.DropDownHeight = 200;
            DelayDropdown.DisplayMemberPath = @"Name";
            DelayDropdown.IsAnimated = true;
            DelayDropdown.ItemsSource = Countries.GetDemoDataList();
            DelayDropdown.Delay = TimeSpan.FromSeconds(1);

            CustomDropdown.DropDownHeight = 200;
            CustomDropdown.DisplayMemberPath = @"Name";
            CustomDropdown.IsAnimated = true;
            CustomDropdown.HighlightedColor = UIColor.Red;
            CustomDropdown.ItemsSource = Countries.GetDemoDataList();
            CustomDropdown.ItemLoading += (s, e) =>
            {
                e.ItemView = GetCountryCell(CustomDropdown, e.Item as Countries, e);
            };

            FilterDropdown.DisplayMemberPath = "Title";
            FilterDropdown.DropDownHeight = 200;
            FilterDropdown.Filtering += async (sender, e) =>
            {
                var deferral = e.GetDeferral();
                try
                {
                    var collectionView = new YouTubeCollectionView();
                    await collectionView.SearchAsync(e.FilterString);
                    FilterDropdown.ItemsSource = collectionView;
                    e.Cancel = true;
                }
                finally
                {
                    deferral.Complete();
                }
            };
            FilterDropdown.ItemLoading += (s, e) =>
            {
                e.ItemView = GetYoutubeCell(FilterDropdown, e.Item as YouTubeVideo, e);
            };
            FilterDropdown.IsAnimated = true;
        }

        #region ** custom cell

        const string CellIdentifier = "TableCell";

        private UITableViewCell GetCountryCell(C1AutoComplete custom, Countries item, ComboBoxItemLoadingEventArgs e)
        {
            UITableViewCell cell = e.GetReusableItemView(CellIdentifier);

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            CGRect rect = cell.ContentView.Frame;
            UIView selectedBackgroundView = new UIView(cell.Bounds);
            selectedBackgroundView.BackgroundColor = new UIColor((nfloat)(0 / 255.0), (nfloat)(122.0 / 255.0), (nfloat)(255.0 / 255.0), (nfloat)1.0);
            cell.SelectedBackgroundView = selectedBackgroundView;

            foreach (UIView view in cell.ContentView.Subviews)
            {
                view.RemoveFromSuperview();
            }

            UIImageView imageView = new UIImageView(new CGRect(4, 0, 48, 48));
			NSString imagePath = new NSString("Images/" + (NSString)item.Name.ToLower() + ".png");
            imageView.Image = new UIImage(imagePath);
            cell.ContentView.Add(imageView);

            UILabel label = new UILabel(new CGRect(65, 10, rect.Size.Width - 40, rect.Size.Height / 2));
            label.Text = item.Name;
            cell.ContentView.Add(label);

            return cell;
        }

        #endregion

        #region ** youtube

        private string YouTubeCellIdentifier = "YouTube";
        private Dictionary<string, UIImage> _cache = new Dictionary<string, UIImage>();

        private UITableViewCell GetYoutubeCell(C1AutoComplete filterDropdown, YouTubeVideo video, ComboBoxItemLoadingEventArgs e)
        {
            UITableViewCell cell = e.GetReusableItemView(YouTubeCellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, YouTubeCellIdentifier);

            LoadImageInBackground(cell.ImageView, video.Thumbnail);
            cell.TextLabel.Text = video.Title;
            cell.DetailTextLabel.Text = video.Description;

            return cell;
        }

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

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}



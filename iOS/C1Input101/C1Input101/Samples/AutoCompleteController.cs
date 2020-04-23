using System;
using UIKit;
using Foundation;
using CoreGraphics;
using C1.iOS.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C1Input101
{

    public partial class AutoCompleteController : UIViewController
    {
        public AutoCompleteController(IntPtr handle) : base(handle)
        {

        }

        private const string acmTitleKey = "AutoCompleteMode";

        private IList<string> acmItems = new List<string>() {
            C1.iOS.Input.AutoCompleteMode.StartsWith.ToString(),
            C1.iOS.Input.AutoCompleteMode.Contains.ToString(),
            C1.iOS.Input.AutoCompleteMode.EndsWith.ToString(),
            C1.iOS.Input.AutoCompleteMode.MatchCase.ToString(),
            C1.iOS.Input.AutoCompleteMode.MatchWholeWord.ToString()
        };

        public IList<string> ACMItems
        {
            get
            {
                return acmItems;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AutoCompleteMode.Text = NSBundle.MainBundle.GetLocalizedString("AutoCompleteMode", "");
            ShowClearButton.Text = NSBundle.MainBundle.GetLocalizedString("ShowClearButton", "");

            clearSwitch.ValueChanged += ClearSwitch_ValueChanged;
            clearSwitch.On = false;
            HighlightDropdown.DropDownHeight = 200;
            HighlightDropdown.DisplayMemberPath = "Name";
            HighlightDropdown.IsAnimated = true;
            HighlightDropdown.ItemsSource = Countries.GetDemoDataList();

            CustomDropdown.DropDownHeight = 200;
            CustomDropdown.DisplayMemberPath = @"Name";
            CustomDropdown.IsAnimated = true;
            CustomDropdown.HighlightColor = UIColor.Red;
            CustomDropdown.ItemsSource = Countries.GetDemoImageDataList();
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
                    var dataCollection = new YouTubeDataCollection();
                    await dataCollection.SearchAsync(e.FilterString);
                    FilterDropdown.ItemsSource = dataCollection;
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
            acmField.ToPickerWithValues(ACMItems, 0, (selectedIndex) =>
            {
                HighlightDropdown.AutoCompleteMode = (C1.iOS.Input.AutoCompleteMode)Enum.Parse(typeof(C1.iOS.Input.AutoCompleteMode), ACMItems[selectedIndex]);
                CustomDropdown.AutoCompleteMode = (C1.iOS.Input.AutoCompleteMode)Enum.Parse(typeof(C1.iOS.Input.AutoCompleteMode), ACMItems[selectedIndex]);
                FilterDropdown.AutoCompleteMode = (C1.iOS.Input.AutoCompleteMode)Enum.Parse(typeof(C1.iOS.Input.AutoCompleteMode), ACMItems[selectedIndex]);
            });
        }

        private void ClearSwitch_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            HighlightDropdown.ShowClearButton = clearSwitch.On;
            CustomDropdown.ShowClearButton = clearSwitch.On;
            FilterDropdown.ShowClearButton = clearSwitch.On;
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
            const int padding = 4;
            UIImageView imageView = new UIImageView(new CGRect(padding, 0, 48, 48));
            UILabel label = new UILabel(new CGRect(65, 10, rect.Size.Width - 40, rect.Size.Height / 2));
         
            imageView.TranslatesAutoresizingMaskIntoConstraints = false;
            label.TranslatesAutoresizingMaskIntoConstraints = false;

            NSString imagePath = new NSString("Images/" + (NSString)item.Name.ToLower() + ".png");
            imageView.Image = new UIImage(imagePath);
            cell.ContentView.Add(imageView);

            label.Text = item.Name;
            cell.ContentView.Add(label);

            // anchor image to parent cell
            imageView.LeadingAnchor.ConstraintEqualTo(cell.LeadingAnchor, (nfloat)(padding)).Active = true;
            imageView.TopAnchor.ConstraintEqualTo(cell.TopAnchor).Active = true;
            imageView.BottomAnchor.ConstraintEqualTo(cell.BottomAnchor).Active = true;

            // anchor label follow to image
            label.LeadingAnchor.ConstraintEqualTo(imageView.LeadingAnchor, (nfloat)(padding + imageView.Frame.Width)).Active = true;
            label.TopAnchor.ConstraintEqualTo(cell.TopAnchor).Active = true;
            label.BottomAnchor.ConstraintEqualTo(cell.BottomAnchor).Active = true;

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
            if (acmField != null)
            {
                if (acmField.InputView != null)
                {
                    acmField.InputView.Dispose();
                    acmField.InputView = null;
                }
                if (acmField.InputAccessoryView != null)
                {
                    acmField.InputAccessoryView.Dispose();
                    acmField.InputAccessoryView = null;
                }
            }
            foreach (var item in HighlightDropdown.ItemsSource)
            {
                ((NSObject)item).Dispose();
            }
            foreach (var item in CustomDropdown.ItemsSource)
            {
                ((NSObject)item).Dispose();
            }
            HighlightDropdown.RemoveFromSuperview();
            CustomDropdown.RemoveFromSuperview();
            FilterDropdown.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
    public static class UITextFieldEx
    {
        public static void ToPickerWithValues(this UITextField textField, IList<string> values, int index, Action<int> action)
        {
            var toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolBar.SetItems(new UIBarButtonItem[] { flexibleSpace, doneButton }, true);

            var model = new UIPickerViewStringArrayModel();
            var picker = new UIPickerView();
            picker.Model = model;
            foreach (var displayValue in values)
            {
                model.Items.Add(displayValue.ToString());
            }
            picker.Select(index, 0, true);
            textField.InputView = picker;
            textField.InputAccessoryView = toolBar;
            textField.Text = values[index].ToString();

            doneButton.Clicked += (s, e) =>
            {
                var selectedIndex = (int)picker.SelectedRowInComponent(0);
                textField.Text = values[selectedIndex].ToString();
                textField.EndEditing(true);
                action?.Invoke(selectedIndex);
            };
        }
    }
    internal class UIPickerViewStringArrayModel : UIPickerViewModel
    {
        public UIPickerViewStringArrayModel()
        {
            Items = new List<string>();
        }

        public List<string> Items { get; private set; }
        public event EventHandler<SelectedItemEventArgs> SelectedItem;
        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return Items.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return Items[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            if (SelectedItem != null)
                SelectedItem(this, new SelectedItemEventArgs((int)row));
        }

        internal class SelectedItemEventArgs : EventArgs
        {

            public SelectedItemEventArgs(int row)
            {
                Index = row;
            }
            public int Index { get; private set; }
        }
    }
}



using C1.CollectionView;
using C1.iOS.Core;
using C1.iOS.Grid;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace FlexGrid101
{
    public partial class CustomSortIconController : UIViewController
    {
        public List<string> positionOptionStrings = new List<string>();
        public List<string> iconOptionStrings = new List<string>();
        public CustomSortIconController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolBar.SetItems(new UIBarButtonItem[] { flexibleSpace, doneButton }, true);

            var positionItems = new GridSortIconPosition[] { GridSortIconPosition.Left, GridSortIconPosition.Inline, GridSortIconPosition.Right };
            foreach (var value in Enum.GetValues(typeof(GridSortIconPosition)))
            {
                positionOptionStrings.Add(value.ToString());
            }
            var iconItems = new C1IconTemplate[] { C1IconTemplate.TriangleNorth, C1IconTemplate.ChevronUp, C1IconTemplate.ArrowUp };
            foreach (var value in new string[] { nameof(C1IconTemplate.TriangleNorth), nameof(C1IconTemplate.ChevronUp), nameof(C1IconTemplate.ArrowUp) })
            {
                iconOptionStrings.Add(value);
            }
            var modelPosition = new PositionMModePickerViewModel(Grid, SelectionPositionModeField, positionItems);
            var positionOptionPicker = new UIPickerView();
            positionOptionPicker.Model = modelPosition;
            SelectionPositionModeField.Text = string.Empty;
            SelectionPositionModeField.Placeholder = NSBundle.MainBundle.GetLocalizedString("Sort Icon Position", "");
            SelectionPositionModeField.InputView = positionOptionPicker;
            SelectionPositionModeField.InputAccessoryView = toolBar;

            var modelIcon = new IconModePickerViewModel(Grid, SelectionIconModeField, iconItems);
            var iconOptionPicker = new UIPickerView();
            iconOptionPicker.Model = modelIcon;
            SelectionIconModeField.Text = string.Empty;
            SelectionIconModeField.Placeholder = NSBundle.MainBundle.GetLocalizedString("Sort Icon Template", "");
            SelectionIconModeField.InputView = iconOptionPicker;
            SelectionIconModeField.InputAccessoryView = toolBar;

            doneButton.Clicked += (s, e) =>
            {
                Grid.BecomeFirstResponder();
            };

            Grid.AllowDragging = GridAllowDragging.Both;
            Grid.AllowResizing = GridAllowResizing.Both;
            //Use together with AllowResizing and AllowDragging to avoid gesture conflicts in the edge of the screen.
            NavigationController.InteractivePopGestureRecognizer.Enabled = false;
            LoadData();
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        private async void LoadData()
        {
            var cv = new C1CollectionView<Customer>(Customer.GetCustomerList(100));
            await cv.SortAsync(new SortDescription("FirstName", SortDirection.Ascending), new SortDescription("LastName", SortDirection.Descending));
            Grid.ItemsSource = cv;
            Grid.SortAscendingIconTemplate = new C1IconTemplate(() => new C1BitmapIcon()
            {
                Source = UIImage.FromBundle("arrow_up")
            });
        }
    }
    public class PositionMModePickerViewModel : UIPickerViewModel
    {
        FlexGrid grid;
        UITextField textField;
        GridSortIconPosition[] positionItems;
        public PositionMModePickerViewModel(FlexGrid grid, UITextField textField, GridSortIconPosition[] positionItems)
        {
            this.grid = grid;
            this.textField = textField;
            this.positionItems = positionItems;
        }
        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }
        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return 3;
        }
        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            switch (row)
            {
                default:
                case 0:
                    return GridSortIconPosition.Left.ToString();
                case 1:
                    return GridSortIconPosition.Inline.ToString();
                case 2:
                    return GridSortIconPosition.Right.ToString();
            }
        }
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            this.textField.Text = GetTitle(pickerView,row,component);
            this.grid.SortIconPosition = positionItems[(int)row];
        }
    }
    public class IconModePickerViewModel : UIPickerViewModel
    {
        FlexGrid grid;
        UITextField textField;
        C1IconTemplate[] iconItems;
        public IconModePickerViewModel(FlexGrid grid, UITextField textField, C1IconTemplate[] iconItems)
        {
            this.grid = grid;
            this.textField = textField;
            this.iconItems = iconItems;
        }
        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }
        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return 3;
        }
        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            switch (row)
            {
                default:
                case 0:
                    return nameof(C1IconTemplate.TriangleNorth);
                case 1:
                    return nameof(C1IconTemplate.ChevronUp);
                case 2:
                    return nameof(C1IconTemplate.ArrowUp);
            }
        }
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            this.textField.Text = GetTitle(pickerView, row, component);
            this.grid.SortAscendingIconTemplate = iconItems[(int)row];
        }
    }
}
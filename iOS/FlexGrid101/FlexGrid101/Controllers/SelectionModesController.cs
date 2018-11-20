using System;
using Foundation;
using CoreGraphics;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class SelectionModesController : UIViewController
    {
        public string[] pickerOptionStrings = new string[] { NSBundle.MainBundle.GetLocalizedString("None", ""), NSBundle.MainBundle.GetLocalizedString("Cell", ""),
            NSBundle.MainBundle.GetLocalizedString("Cell Range", ""), NSBundle.MainBundle.GetLocalizedString("Row", ""), NSBundle.MainBundle.GetLocalizedString("Row Range", "") };

        public SelectionModesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolBar.SetItems(new UIBarButtonItem[] { flexibleSpace, doneButton }, true);

            var model = new SelectionModePickerViewModel();
            var picker = new UIPickerView();
            picker.Model = model;
            picker.Select((nint)(int)Grid.SelectionMode, 0, true);
            SelectionModeField.InputView = picker;
            SelectionModeField.InputAccessoryView = toolBar;
            SelectionModeField.Text = pickerOptionStrings[2];

            doneButton.Clicked += (s, e) =>
            {
                var selectedIndex = (int)picker.SelectedRowInComponent(0);
                var selectedMode = (GridSelectionMode)selectedIndex;
                SelectionModeField.Text = pickerOptionStrings[selectedIndex];
                Grid.SelectionMode = selectedMode;
                Grid.BecomeFirstResponder();
            };

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            Grid.AllowResizing = GridAllowResizing.Both;
            Grid.SelectionChanged += OnSelectionChanged;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }

        private void OnSelectionChanged(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellRange != null && e.CellRange.Row != -1)
            {
                int rowsSelected = Math.Abs(e.CellRange.Row2 - e.CellRange.Row) + 1;
                int colsSelected = Math.Abs(e.CellRange.Column2 - e.CellRange.Column) + 1;

                SelectionLabel.Text = (rowsSelected * colsSelected).ToString() + NSBundle.MainBundle.GetLocalizedString(" cell(s) selected", "");
            }
        }

        public class SelectionModePickerViewModel : UIPickerViewModel
        {
            public SelectionModePickerViewModel()
            {
            }

            public override nint GetComponentCount(UIPickerView picker)
            {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView picker, nint component)
            {
                return 5;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                switch (row)
                {
                    default:
                    case 0:
                        return NSBundle.MainBundle.GetLocalizedString("None", "");
                    case 1:
                        return NSBundle.MainBundle.GetLocalizedString("Cell", "");
                    case 2:
                        return NSBundle.MainBundle.GetLocalizedString("Cell Range", "");
                    case 3:
                        return NSBundle.MainBundle.GetLocalizedString("Row", "");
                    case 4:
                        return NSBundle.MainBundle.GetLocalizedString("Row Range", "");
                }
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
            }
        }
    }
}
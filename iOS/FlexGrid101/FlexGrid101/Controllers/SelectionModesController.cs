using System;
using CoreGraphics;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class SelectionModesController : UIViewController
    {
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
            SelectionModeField.Text = Grid.SelectionMode.ToString();

            doneButton.Clicked += (s, e) =>
            {
                var selectedIndex = (int)picker.SelectedRowInComponent(0);
                var selectedMode = (GridSelectionMode)selectedIndex;
                SelectionModeField.Text = selectedMode.ToString();
                Grid.SelectionMode = selectedMode;
                Grid.BecomeFirstResponder();
            };

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            Grid.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellRange != null && e.CellRange.Row != -1)
            {
                int rowsSelected = Math.Abs(e.CellRange.Row2 - e.CellRange.Row) + 1;
                int colsSelected = Math.Abs(e.CellRange.Column2 - e.CellRange.Column) + 1;

                SelectionLabel.Text = (rowsSelected * colsSelected).ToString() + " cell(s) selected";
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
                        return GridSelectionMode.None.ToString();
                    case 1:
                        return GridSelectionMode.Cell.ToString();
                    case 2:
                        return GridSelectionMode.CellRange.ToString();
                    case 3:
                        return GridSelectionMode.Row.ToString();
                    case 4:
                        return GridSelectionMode.RowRange.ToString();
                }
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
            }
        }
    }
}
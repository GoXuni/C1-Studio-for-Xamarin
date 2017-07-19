using System;
using UIKit;
using C1.iOS.Grid;
using C1.iOS.Core;

namespace FlexGrid101
{
    public partial class EditConfirmationController : UIViewController
    {
        public EditConfirmationController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.AutoGeneratingColumn += (s, e) =>
              {
                  if (e.Property.Name == "Id")
                      e.Cancel = true;
              };
            Grid.ItemsSource = data;
            Grid.BeginningEdit += OnBeginningEdit;
            Grid.CellEditEnded += OnCellEditEnded;

            Grid.GridLinesVisibility = GridLinesVisibility.None;
            Grid.HeadersGridLinesVisibility = GridLinesVisibility.None;
            Grid.HeadersVisibility = GridHeadersVisibility.Column;
            Grid.BackgroundColor = UIColor.White;
            Grid.RowBackgroundColor = ColorEx.FromARGB(0xFF, 0xE2, 0xEF, 0xDB);
            Grid.RowTextColor = UIColor.Black;
            Grid.AlternatingRowBackgroundColor = UIColor.White;
            Grid.ColumnHeaderBackgroundColor = ColorEx.FromARGB(0xFF, 0x70, 0xAD, 0x46);
            Grid.ColumnHeaderTextColor = UIColor.White;
            Grid.ColumnHeaderFont = UIFont.BoldSystemFontOfSize(UIFont.LabelFontSize);
            Grid.SelectionBackgroundColor = ColorEx.FromARGB(0xFF, 0x5A, 0x82, 0x3F);
            Grid.SelectionTextColor = UIColor.White;
        }

        private object _originalValue;

        private void OnBeginningEdit(object sender, GridCellEditEventArgs e)
        {
            _originalValue = Grid[e.CellRange.Row, e.CellRange.Column];
        }

        private void OnCellEditEnded(object sender, GridCellEditEventArgs e)
        {
            var originalValue = _originalValue;
            var currentValue = Grid[e.CellRange.Row, e.CellRange.Column];
            if (!e.CancelEdits && (originalValue == null && currentValue != null || !originalValue.Equals(currentValue)))
            {
                var alert = new UIAlertView();
                alert.Title = Foundation.NSBundle.MainBundle.LocalizedString("Confirm Edit", "");
                alert.Message = Foundation.NSBundle.MainBundle.LocalizedString("Do you want to commit the edit?", "");
                alert.AddButton(Foundation.NSBundle.MainBundle.LocalizedString("Ok", ""));
                alert.AddButton(Foundation.NSBundle.MainBundle.LocalizedString("Cancel", ""));
                alert.CancelButtonIndex = 1;
                alert.Clicked += (s, e2) =>
                {
                    if (e2.ButtonIndex == alert.CancelButtonIndex)
                    {
                        Grid[e.CellRange.Row, e.CellRange.Column] = originalValue;
                    }
                };
                alert.Show();
            }
        }

    }
}
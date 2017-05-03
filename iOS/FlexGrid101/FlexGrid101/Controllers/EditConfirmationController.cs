using System;
using UIKit;
using C1.iOS.Grid;

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
        }

        private object _originalValue;
        private int row;
        private int column;

        private void OnBeginningEdit(object sender, GridCellEditEventArgs e)
        {
            _originalValue = Grid[e.CellRange.Row, e.CellRange.Column];
            row = e.CellRange.Row;
            column = e.CellRange.Column;
        }

        private void OnCellEditEnded(object sender, GridCellEditEventArgs e)
        {
            if (!e.CancelEdits)
            {
                var alert = new UIAlertView();
                alert.Title = "Confirm Edit";
                alert.Message = "Do you want to commit the edit?";
                alert.AddButton("Yes");
                alert.AddButton("No");
                alert.CancelButtonIndex = 1;
                alert.Clicked += (s, e2) =>
                {
                    if (e2.ButtonIndex == alert.CancelButtonIndex)
                    {
                        Grid[row, column] = _originalValue;
                        Grid.Refresh(range: e.CellRange);
                    }
                };
                alert.Show();
            }
        }

    }
}
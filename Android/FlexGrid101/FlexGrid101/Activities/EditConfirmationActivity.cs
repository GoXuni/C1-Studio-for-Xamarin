using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/EditConfirmationTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class EditConfirmationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            Grid.ItemsSource = Customer.GetCustomerList(100);
            Grid.BeginningEdit += OnBeginningEdit;
            Grid.CellEditEnded += OnCellEditEnded;
        }

        public FlexGrid Grid { get; set; }

        private object _originalValue;
        private int row;
        private int column;

        private void OnBeginningEdit(object sender, GridCellEditEventArgs e)
        {
            var grid = sender as FlexGrid;
            _originalValue = grid[e.CellRange.Row, e.CellRange.Column];
            row = e.CellRange.Row;
            column = e.CellRange.Column;
        }

        private void OnCellEditEnded(object sender, GridCellEditEventArgs e)
        {
            if (!e.CancelEdits)
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle(Resources.GetString(Resource.String.EditConfirmationQuestionTitle));
                alert.SetMessage(Resources.GetString(Resource.String.EditConfirmationQuestion));
                alert.SetPositiveButton("Yes", new EventHandler<DialogClickEventArgs>((s, e2) => { }));
                alert.SetNegativeButton("No", new EventHandler<DialogClickEventArgs>((s, e2) =>
                {
                    Grid[row, column] = _originalValue;
                    Grid.Refresh(range: e.CellRange);
                }));
                alert.Show();
            }
        }
    }
}
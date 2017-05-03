using Foundation;
using System;
using System.Collections.ObjectModel;
using UIKit;

namespace FlexGrid101
{
    public partial class ColumnLayoutFormController : UITableViewController
    {
        public ObservableCollection<ColumnInfo> Columns { get; set; }
        public bool Saved { get; set; }

        public ColumnLayoutFormController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new ColumnLayoutTableSource(Columns);
            TableView.AllowsSelectionDuringEditing = true;
            TableView.SetEditing(true, false);
        }

        partial void DoneButton_Activated(UIBarButtonItem sender)
        {
            Saved = true;
            PerformSegue("CloseColumnLayoutForm", this);
        }
    }

    internal class ColumnLayoutTableSource : UITableViewSource
    {
        private ObservableCollection<ColumnInfo> Columns { get; set; }
        private string CellIdentifier = "Cell";

        public ColumnLayoutTableSource(ObservableCollection<ColumnInfo> columns)
        {
            Columns = columns;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Columns.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            var columnInfo = Columns[indexPath.Row];
            //Appends the checkmark in the title
            cell.TextLabel.Text = (columnInfo.IsVisible ? "\u2713 " : "\u2001 ") + columnInfo.Name;
            return cell;
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void MoveRow(UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
        {
            Columns.Move(sourceIndexPath.Row, destinationIndexPath.Row);
        }

        public override bool ShouldIndentWhileEditing(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableViewCellEditingStyle.None;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //Toggle checkmark
            var columnInfo = Columns[indexPath.Row];
            columnInfo.IsVisible = !columnInfo.IsVisible;
            tableView.ReloadRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
        }
    }
}
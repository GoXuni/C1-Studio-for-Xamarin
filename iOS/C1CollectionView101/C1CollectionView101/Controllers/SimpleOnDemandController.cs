using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;
using C1.iOS.CollectionView;
using System.Threading;
using Foundation;

namespace C1CollectionView101
{
    public partial class SimpleOnDemandController : UITableViewController
    {
        public SimpleOnDemandController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // instantiate our on demand collection view
            RefreshControl = new UIRefreshControl();
            var myCollectionView = new SimpleOnDemandCollectionView();
            var myCollectionViewSource = new SimpleOnDemandCollectionViewSource(TableView);
            myCollectionViewSource.ItemsSource = myCollectionView;
            myCollectionViewSource.RefreshControl = RefreshControl;
            TableView.Source = myCollectionViewSource;
        }
    }

    public class SimpleOnDemandCollectionView : C1CursorCollectionView<MyDataItem>
    {
        public SimpleOnDemandCollectionView()
        {
            PageSize = 20;
        }

        public int PageSize { get; set; }
        protected override async Task<Tuple<string, IReadOnlyList<MyDataItem>>> GetPageAsync(int startingIndex, string pageToken, int? count = null, IReadOnlyList<SortDescription> sortDescriptions = null, FilterExpression filterExpresssion = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var newItems = new List<MyDataItem>();
            await Task.Run(() =>
            {
                // create new page of items
                for (int i = 0; i < this.PageSize; i++)
                {
                    newItems.Add(new MyDataItem(startingIndex + i));
                }
            });
            return new Tuple<string, IReadOnlyList<MyDataItem>>("token not used", newItems);
        }
    }

    public class SimpleOnDemandCollectionViewSource : C1TableViewSource<MyDataItem>
    {
        private string CellIdentifier = "Default";

        public SimpleOnDemandCollectionViewSource(UITableView tableView)
            : base(tableView)
        {
        }

        public override UITableViewCell GetItemCell(UITableView tableView, NSIndexPath indexPath, MyDataItem item)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);

            cell.TextLabel.Text = item.ItemName;
            cell.DetailTextLabel.Text = item.ItemDateTime.ToLongTimeString();

            return cell;
        }
    }

    public class MyDataItem
    {
        public MyDataItem(int index)
        {
            this.ItemName = "My Data Item #" + index.ToString();
            this.ItemDateTime = DateTime.Now;
        }
        public string ItemName { get; set; }
        public DateTime ItemDateTime { get; set; }

    }

}
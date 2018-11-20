using System;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;
using C1.iOS.Grid;
using Foundation;

namespace FlexGrid101
{
    public partial class GroupingController : UIViewController
    {
        C1CollectionView<Customer> _collectionView;

        public GroupingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var task = UpdateVideos();
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }

        private async Task UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _collectionView = new C1CollectionView<Customer>(data);
            await _collectionView.GroupAsync(c => c.Country);
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Add(new GridColumn { Binding = "Active", Width = new GridLength(75) });
            Grid.Columns.Add(new GridColumn { Binding = "Name", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Width = new GridLength(110), Format = "C", Aggregate = GridAggregate.Sum, HorizontalAlignment = UIControlContentHorizontalAlignment.Right, HeaderHorizontalAlignment = UIControlContentHorizontalAlignment.Right });
            Grid.GroupHeaderFormat = NSBundle.MainBundle.GetLocalizedString("{name}: {value} ({count} items)", "");
            Grid.ItemsSource = _collectionView;
            _collectionView.SortChanged += OnSortChanged;
            UpdateSortButton();
        }

        private async void OnSortClicked(object sender, EventArgs e)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                await _collectionView.SortAsync(x => x.Name, direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            }
        }

        private void OnCollapseClicked(object sender, EventArgs e)
        {
            Grid.CollapseGroups();
        }

        void OnSortChanged(object sender, EventArgs e)
        {
            UpdateSortButton();
        }

        private void UpdateSortButton()
        {
            var direction = GetCurrentSortDirection();
        }

        private SortDirection GetCurrentSortDirection()
        {
            var sort = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "Name");
            return sort != null ? sort.Direction : SortDirection.Descending;
        }

        public void OnSelectionChanging(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellType == GridCellType.Cell || e.CellType == GridCellType.RowHeader)
            {
                var row = Grid.Rows[e.CellRange.Row] as GridGroupRow;
                if (row != null)
                    e.Cancel = true;
            }
        }
    }
}
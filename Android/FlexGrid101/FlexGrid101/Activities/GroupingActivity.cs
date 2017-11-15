
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using System;
using System.Linq;
using System.Threading.Tasks;
using C1.Android.Grid;
using C1.CollectionView;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace FlexGrid101
{
    [Activity(Label = "@string/GroupingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class GroupingActivity : AppCompatActivity
    {
        private C1CollectionView<Customer> _collectionView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.GroupingTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            var task = UpdateVideos();
        }

        public FlexGrid Grid;

        private async Task UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _collectionView = new C1CollectionView<Customer>(data);
            await _collectionView.GroupAsync(c => c.Country);
            Grid.AutoGenerateColumns = false;
            Grid.ShowOutlineBar = true;
            Grid.IsReadOnly = true;
            Grid.Columns.Add(new GridColumn { Binding = "Active", Width = new GridLength(TypedValue.ApplyDimension(ComplexUnitType.Dip, 60, Resources.DisplayMetrics)) });
            Grid.Columns.Add(new GridColumn { Binding = "Name", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Width = new GridLength(TypedValue.ApplyDimension(ComplexUnitType.Dip, 110, Resources.DisplayMetrics)), Format = "C", Aggregate = GridAggregate.Sum, HorizontalAlignment = Android.Views.GravityFlags.Right, HeaderHorizontalAlignment = Android.Views.GravityFlags.Right });
            Grid.GroupHeaderFormat = Resources.GetString(Resource.String.GroupHeaderFormat);
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
            //if (direction == SortDirection.Ascending)
            //{
            //    toolbarItemSort.Icon = Device.OnPlatform<FileImageSource>(null, new FileImageSource() { File = "ic_sort_descending.png" }, new FileImageSource() { File = "Assets/AppBar/appbar.sort.alphabetical.descending.png" });
            //}
            //else
            //{
            //    toolbarItemSort.Icon = Device.OnPlatform<FileImageSource>(null, new FileImageSource() { File = "ic_sort_ascending.png" }, new FileImageSource() { File = "Assets/AppBar/appbar.sort.alphabetical.ascending.png" });
            //}
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
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}
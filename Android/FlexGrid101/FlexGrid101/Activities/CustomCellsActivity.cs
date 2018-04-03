
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using C1.Android.Grid;
using C1.Android.Gauge;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/CustomCellsTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomCellsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.CustomCellsTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new GridColumn() { Binding = "FirstName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn() { Binding = "LastName", Width = GridLength.Star });
            grid.Columns.Add(new GridBulletGraphColumn() { Binding = "OrderTotal", Header = "Order Total", Width = GridLength.Star });

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
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

    public class GridBulletGraphColumn : GridColumn
    {
        protected override object GetCellContentType(GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                return typeof(C1BulletGraph);
            }
            else
            {
                return base.GetCellContentType(cellType, row);
            }
        }

        protected override View CreateCellContent(GridCellType cellType, object cellContentType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var gauge = new C1BulletGraph(Grid.Context);
                gauge.IsAnimated = false;
                gauge.Max = 10000;
                gauge.Target = 7000;
                gauge.Bad = 1000;
                gauge.Good = 6000;
                gauge.IsReadOnly = true;
                return gauge;
            }
            else
            {
                return base.CreateCellContent(cellType, cellContentType, row);
            }
        }

        protected override void BindCellContent(View cellContent, GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var gauge = cellContent as C1BulletGraph;
                gauge.Value = (double)GetCellValue(cellType, row);
            }
            else
            {
                base.BindCellContent(cellContent, cellType, row);
            }
        }
    }

}
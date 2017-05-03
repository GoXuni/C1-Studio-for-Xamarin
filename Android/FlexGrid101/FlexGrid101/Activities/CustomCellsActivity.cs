
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using C1.Android.Grid;
using C1.Android.Gauge;

namespace FlexGrid101
{
    [Activity(Label = "@string/CustomCellsTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomCellsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new GridColumn() { Binding = "FirstName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn() { Binding = "LastName", Width = GridLength.Star });
            grid.Columns.Add(new GridRadialGaugeColumn() { Binding = "OrderTotal", Header = "Order Total", Width = GridLength.Star });

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }

    public class GridRadialGaugeColumn : GridColumn
    {
        protected override object GetCellContentType(GridCellType cellType)
        {
            if (cellType == GridCellType.Cell)
            {
                return typeof(C1BulletGraph);
            }
            else
            {
                return base.GetCellContentType(cellType);
            }
        }

        protected override View CreateCellContent(GridCellType cellType, object cellContentType)
        {
            if (cellType == GridCellType.Cell)
            {
                var gauge = new C1BulletGraph(Grid.Context);
                gauge.Max = 10000;
                gauge.Target = 7000;
                gauge.Bad = 1000;
                gauge.Good = 6000;
                return gauge;
            }
            else
            {
                return base.CreateCellContent(cellType, cellContentType);
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
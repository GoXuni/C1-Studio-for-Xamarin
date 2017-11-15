using System;
using UIKit;
using C1.iOS.Grid;
using C1.iOS.Gauge;

namespace FlexGrid101
{
    public partial class CustomCellsController : UIViewController
    {
        public CustomCellsController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Grid.Columns.Add(new GridColumn() { Binding = "FirstName", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn() { Binding = "LastName", Width = GridLength.Star });
            Grid.Columns.Add(new GridRadialGaugeColumn() { Binding = "OrderTotal", Header = "Order Total", Width = GridLength.Star });

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
        }
    }

    public class GridRadialGaugeColumn : GridColumn
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

        protected override UIView CreateCellContent(GridCellType cellType, object cellContentType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var gauge = new C1BulletGraph();
                gauge.Max = 10000;
                gauge.Target = 7000;
                gauge.Bad = 1000;
                gauge.Good = 6000;
                return gauge;
            }
            else
            {
                return base.CreateCellContent(cellType, cellContentType, row);
            }
        }

        protected override void BindCellContent(UIView cellContent, GridCellType cellType, GridRow row)
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
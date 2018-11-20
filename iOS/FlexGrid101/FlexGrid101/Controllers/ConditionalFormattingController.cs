using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class ConditionalFormattingController : UIViewController
    {
        public ConditionalFormattingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Grid.Columns.Add(new GridColumn { Binding = "FirstName", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "LastName", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Format = "C2", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "OrderCount", Format = "N1", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "CountryId", Header = "Country", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Format = "d", Mode = GridDateTimeColumnMode.Date, MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Header = "Last Order Time", Format = "t", Mode = GridDateTimeColumnMode.Time, MinWidth = 110, Width = GridLength.Star });

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            Grid.Columns["CountryId"].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };

            Grid.CellFactory = new MyCellFactory();

        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }

    public class MyCellFactory : GridCellFactory
    {
        private static UIColor Red = UIColor.Red;
        private static UIColor Green = UIColor.FromRGBA(0, (nfloat)0.518, 0, 1);

        public override void PrepareCell(GridCellType cellType, GridCellRange range, GridCellView cell)
        {
            base.PrepareCell(cellType, range, cell);
            var orderCountColumn = Grid.Columns["OrderCount"];
            if (cellType == GridCellType.Cell && range.Column == orderCountColumn.Index)
            {
                var cellValue = Grid[range.Row, range.Column] as int?;
                if (cellValue.HasValue)
                {
                    cell.BackgroundColor = cellValue < 50.0 ? UIColor.FromRGB(0xFF, 0x70, 0x70) : UIColor.FromRGB(0x8E, 0xE9, 0x8E);
                }
            }
        }

        /// <summary>
        /// Binds the content of the cell.
        /// </summary>
        /// <param name="cellType">Type of the cell.</param>
        /// <param name="range">The range.</param>
        /// <param name="cellContent">Content of the cell.</param>
        public override void BindCellContent(GridCellType cellType, GridCellRange range, UIView cellContent)
        {
            base.BindCellContent(cellType, range, cellContent);
            var orderTotalColumn = Grid.Columns["OrderTotal"];
            var orderCountColumn = Grid.Columns["OrderCount"];
            if (cellType == GridCellType.Cell && range.Column == orderTotalColumn.Index)
            {
                var label = cellContent as UILabel;
                if (label != null)
                {
                    var cellValue = Grid[range.Row, range.Column] as double?;
                    if (cellValue.HasValue)
                    {
                        label.TextColor = cellValue < 5000.0 ? Red : Green;
                    }
                }
            }
            if (cellType == GridCellType.Cell && range.Column == orderCountColumn.Index)
            {
                var label = cellContent as UILabel;
                if (label != null)
                {
                    var cellValue = Grid[range.Row, range.Column] as int?;
                    if (cellValue.HasValue)
                    {
                        label.TextColor = UIColor.Black;
                    }
                }
            }
        }

        public override void UnbindCellContent(GridCellType cellType, GridCellRange range, UIView cellContent)
        {
            base.UnbindCellContent(cellType, range, cellContent);
            var label = cellContent as UILabel;
            if (label != null)
            {
                label.TextColor = UIColor.Black;
            }
        }
    }

}
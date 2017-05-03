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

            Grid.Columns.Add(new GridColumn { Binding = "Id", Width = new GridLength(100) });
            Grid.Columns.Add(new GridColumn { Binding = "FirstName" });
            Grid.Columns.Add(new GridColumn { Binding = "LastName" });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Format = "C2" });
            Grid.Columns.Add(new GridColumn { Binding = "OrderCount", Format = "N1" });
            Grid.Columns.Add(new GridColumn { Binding = "CountryId", Header = "Country" });
            Grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Format = "d", Mode = GridDateTimeColumnMode.Date });
            Grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Header = "Last Order Time", Format = "t", Mode = GridDateTimeColumnMode.Time });

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            Grid.Columns[0].IsVisible = false;
            Grid.Columns[5].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };

            Grid.CellFactory = new MyCellFactory();

        }
    }

    public class MyCellFactory : GridCellFactory
    {
        private static UIColor Red = UIColor.Red;
        private static UIColor Green = UIColor.FromRGBA(0, (nfloat)0.518, 0, 1);

        public override void PrepareCell(GridCellType cellType, GridCellRange range, GridCellView cell)
        {
            base.PrepareCell(cellType, range, cell);
            if (cellType == GridCellType.Cell && range.Column == 4)
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
            if (cellType == GridCellType.Cell && range.Column == 3)
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
            if (cellType == GridCellType.Cell && range.Column == 4)
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
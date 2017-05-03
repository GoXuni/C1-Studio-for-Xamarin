using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class ConditionalFormatting : ContentPage
    {
        public ConditionalFormatting()
        {
            InitializeComponent();
            this.Title = AppResources.ConditionalFormattingTitle;
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Columns[4].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };

            grid.CellFactory = new MyCellFactory();
        }
    }

    public class MyCellFactory : GridCellFactory
    {
        public override void PrepareCell(GridCellType cellType, GridCellRange range, GridCellView cell)
        {
            base.PrepareCell(cellType, range, cell);
            if (cellType == GridCellType.Cell && range.Column == 3)
            {
                var cellValue = Grid[range.Row, range.Column] as int?;
                if (cellValue.HasValue)
                {
                    cell.BackgroundColor = cellValue < 50.0 ? Color.FromRgb((double)0xFF / 255.0, (double)0x70 / 255.0, (double)0x70 / 255.0) : Color.FromRgb((double)0x8E / 255.0, (double)0xE9 / 255.0, (double)0x8E / 255.0);
                }
            }
        }

        /// <summary>
        /// Binds the content of the cell.
        /// </summary>
        /// <param name="cellType">Type of the cell.</param>
        /// <param name="range">The range.</param>
        /// <param name="cellContent">Content of the cell.</param>
        public override void BindCellContent(GridCellType cellType, GridCellRange range, View cellContent)
        {
            base.BindCellContent(cellType, range, cellContent);
            if (cellType == GridCellType.Cell && range.Column == 2)
            {
                var label = cellContent as Label;
                if (label != null)
                {
                    var cellValue = Grid[range.Row, range.Column] as double?;
                    if (cellValue.HasValue)
                    {
                        label.TextColor = cellValue < 5000.0 ? Color.Red : Color.Green;
                    }
                }
            }
            if (cellType == GridCellType.Cell && range.Column == 3)
            {
                var label = cellContent as Label;
                if (label != null)
                {
                    var cellValue = Grid[range.Row, range.Column] as int?;
                    if (cellValue.HasValue)
                    {
                        label.TextColor = Color.Black;
                    }
                }
            }
        }

        public override void UnbindCellContent(GridCellType cellType, GridCellRange range, View cellContent)
        {
            base.UnbindCellContent(cellType, range, cellContent);
            var label = cellContent as Label;
            if (label != null)
            {
                label.TextColor = Color.Default;
                label.BackgroundColor = Color.Default;
            }
        }
    }
}

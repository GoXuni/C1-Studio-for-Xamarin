using System;
using System.Globalization;
using C1.Xamarin.Forms.Grid;
using Xamarin.Forms;

namespace FlexGrid101
{
    public class GridImageColumn : GridColumn
    {
        protected override object GetCellContentType(GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
                return typeof(Image);
            else
                return base.GetCellContentType(cellType, row);
        }

        protected override View CreateCellContent(GridCellType cellType, object cellContentType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
                return new Image();
            else
                return base.CreateCellContent(cellType, cellContentType, row);
        }

        protected override void BindCellContent(View cellContent, GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var dataItem = row.DataItem;
                var image = cellContent as Image;
                if (image != null && dataItem != null)
                {
                    var value = GetCellValue(cellType, row);
                    image.Source = new ImageConverter().Convert(value, typeof(ImageSource), null, CultureInfo.InvariantCulture) as ImageSource;
                    //image.SetBinding(Image.SourceProperty, new Binding(Binding, converter: new ImageConverter(), source: dataItem));
                }
            }
            else
            {
                base.BindCellContent(cellContent, cellType, row);
            }
        }

        protected override bool AllowEditing(GridRow row)
        {
            return false;
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string && Uri.IsWellFormedUriString(value as string, UriKind.RelativeOrAbsolute))
            {
                return ImageSource.FromUri(new Uri(value as string));
            }
            else if (value is Uri)
            {
                return ImageSource.FromUri(value as Uri);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}

using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using C1.Android.Core;
using C1.Android.Grid;

namespace FlexGrid101
{
    public class GridImageColumn : GridColumn
    {
        private Dictionary<int, CancellationTokenSource> _cancellationTickets = new Dictionary<int, CancellationTokenSource>();

        public int? PlaceholderImageResource { get; set; }
        public C1Thickness ImagePadding { get; set; }

        protected override void PrepareCell(GridCellType cellType, GridRow row, GridCellView cell)
        {
            base.PrepareCell(cellType, row, cell);
            cell.Padding = ImagePadding;
        }

        protected override object GetCellContentType(GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
                return typeof(ImageView);
            else
                return base.GetCellContentType(cellType, row);
        }

        protected override View CreateCellContent(GridCellType cellType, object cellContentType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
                return new ImageView(Grid.Context);
            else
                return base.CreateCellContent(cellType, cellContentType, row);
        }

        protected override void BindCellContent(View cellContent, GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var dataItem = row.DataItem;
                var image = cellContent as ImageView;
                if (image != null && dataItem != null)
                {
                    var value = GetCellValue(cellType, row);
                    var cts = new CancellationTokenSource();
                    _cancellationTickets[row.Index] = cts;
                    if (value is string && Uri.IsWellFormedUriString(value as string, UriKind.RelativeOrAbsolute))
                    {
                        LoadImageInBackground(image, value as string, cts.Token);
                    }
                    else if (value is Uri)
                    {
                        LoadImageInBackground(image, (value as Uri).AbsoluteUri, cts.Token);
                    }
                }
            }
            else
            {
                base.BindCellContent(cellContent, cellType, row);
            }
        }

        protected override void UnbindCellContent(View cellContent, GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                CancellationTokenSource cts;
                if (_cancellationTickets.TryGetValue(row.Index, out cts))
                {
                    cts.Cancel();
                    _cancellationTickets.Remove(row.Index);
                }
            }
            else
            {
                base.UnbindCellContent(cellContent, cellType, row);
            }
        }

        protected override bool AllowEditing(GridRow row)
        {
            return false;
        }

        private void LoadImageInBackground(ImageView imageView, string url, CancellationToken cancellationToken)
        {
            Bitmap imageSource = null;
            if (PlaceholderImageResource.HasValue)
                imageView.SetImageResource(PlaceholderImageResource.Value);
            Task.Run(() =>
            {
                var imageStream = new Java.Net.URL(url).OpenStream();
                imageSource = BitmapFactory.DecodeStream(imageStream);
            }).ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion && !cancellationToken.IsCancellationRequested)
                {
                    imageView.SetImageBitmap(imageSource);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

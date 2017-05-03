using Foundation;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public class GridImageColumn : GridColumn
    {
        private Dictionary<int, CancellationTokenSource> _cancellationTickets = new Dictionary<int, CancellationTokenSource>();

        public UIImage PlaceholderImage { get; set; }
        public UIEdgeInsets ImagePadding { get; set; }

        protected override void PrepareCell(GridCellType cellType, GridRow row, GridCellView cell)
        {
            base.PrepareCell(cellType, row, cell);
            cell.Padding = ImagePadding;
        }

        protected override object GetCellContentType(GridCellType cellType)
        {
            if (cellType == GridCellType.Cell)
                return typeof(UIImage);
            else
                return base.GetCellContentType(cellType);
        }

        protected override UIView CreateCellContent(GridCellType cellType, object cellContentType)
        {
            if (cellType == GridCellType.Cell)
                return new UIImageView();
            else
                return base.CreateCellContent(cellType, cellContentType);
        }

        protected override void BindCellContent(UIView cellContent, GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var dataItem = row.DataItem;
                var image = cellContent as UIImageView;
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

        protected override void UnbindCellContent(UIView cellContent, GridCellType cellType, GridRow row)
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

        private void LoadImageInBackground(UIImageView imageView, string url, CancellationToken cancellationToken)
        {
            UIImage imageSource = null;
            if (PlaceholderImage != null)
                imageView.Image = PlaceholderImage;
            Task.Run(() =>
            {
                imageSource = new UIImage(NSData.FromUrl(new NSUrl(url)));
            }).ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion && !cancellationToken.IsCancellationRequested)
                {
                    imageView.Image = imageSource;
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

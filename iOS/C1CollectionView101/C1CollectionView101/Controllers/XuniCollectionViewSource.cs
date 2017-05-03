using CoreGraphics;
using Foundation;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;

namespace C1CollectionView101
{
    /// <summary>
    /// This class is the bridge between <see cref="UITableView"/> and <see cref="XuniCollectionView{T}"/>.
    /// </summary>
    /// <remarks>
    /// Inherit this class and implement GetCell to set the cell appeareance as you wish.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="UIKit.UITableViewSource" />
    public abstract class XuniCollectionViewSource<T> : UITableViewSource
        where T : class
    {
        public XuniCollectionViewSource(UITableView tableView, ICollectionView<T> collectionView, UIRefreshControl refreshControl = null, string emptyMessage = null)
        {
            EmptyMessage = emptyMessage ?? "There are no items to show";
            TableView = tableView;
            CollectionView = collectionView;
            CollectionView.CollectionChanged += OnCollectionChanged;
            RefreshControl = refreshControl;
            Load();
        }

        private async void Load()
        {
            TableView.ReloadData();
            await LoadMoreItems();
            if (RefreshControl != null && CollectionView.CanRefresh())
            {
                RefreshControl.ValueChanged += async (s, e) =>
                {
                    RefreshControl.BeginRefreshing();
                    await CollectionView.RefreshAsync();
                    RefreshControl.EndRefreshing();
                };
            }
            UpdateEmptyMessage();
        }

        public ICollectionView<T> CollectionView { get; private set; }
        public UITableView TableView { get; private set; }
        public UIRefreshControl RefreshControl { get; private set; }
        public string EmptyMessage { get; private set; }

        public override nint NumberOfSections(UITableView tableView)
        {
            if (CollectionView.CanGroup() && CollectionView.GetGroupDescriptions().Count == 1)
            {
                return CollectionView.Count;
            }
            else
            {
                return 1;
            }
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (CollectionView.CanGroup() && CollectionView.GetGroupDescriptions().Count == 1)
            {
                var item = CollectionView[(int)section];
                var group = item as ICollectionViewGroup<object, object>;
                return group.Count;
            }
            else
            {
                return CollectionView.Count + (CollectionView.CanLoadItems() && CollectionView.HasMoreItems() ? 1 : 0);
            }
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            if (CollectionView.CanGroup() && CollectionView.GetGroupDescriptions().Count == 1)
            {
                var group = CollectionView[(int)section] as ICollectionViewGroup<object, object>;
                return group.Group.ToString();
            }
            return "";
        }
        public sealed override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (CollectionView.CanGroup() && CollectionView.GetGroupDescriptions().Count == 1)
            {
                var group = CollectionView[indexPath.Section] as ICollectionViewGroup<object, object>;
                return GetItemCell(tableView, group[indexPath.Row] as T);
            }
            else
            {
                if (indexPath.Row >= CollectionView.Count)
                {
                    var cell = new UITableViewCell();
                    var activityIndicator = new UIActivityIndicatorView(new CGRect(0, 0, TableView.Frame.Width, cell.Frame.Height));
                    activityIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
                    activityIndicator.StartAnimating();
                    cell.ContentView.AddSubview(activityIndicator);
                    var task = LoadMoreItems();
                    return cell;
                }
                else
                {
                    return GetItemCell(tableView, CollectionView[indexPath.Row] as T);
                }
            }
        }

        public abstract UITableViewCell GetItemCell(UITableView tableView, T item);

        private void UpdateEmptyMessage()
        {
            if (CollectionView.Count > 0)
            {
                TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
                TableView.BackgroundView = null;
            }
            else
            {
                var emptyLabel = new UILabel() { Text = EmptyMessage, TextColor = UIColor.Black, TextAlignment = UITextAlignment.Center };
                TableView.BackgroundView = emptyLabel;
                TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            }
        }

        private async Task LoadMoreItems()
        {
            if (CollectionView.CanLoadItems() && CollectionView.HasMoreItems())
            {
                try
                {
                    await CollectionView.LoadMoreItemsAsync();
                }
                catch
                {
                    TableView.ReloadData();
                }
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //switch (e.Action)
            //{
            //    case NotifyCollectionChangedAction.Add:
            //        {
            //            TableView.BeginUpdates();
            //            var indexes = Enumerable.Range(e.NewStartingIndex, e.NewItems.Count).Select(i => NSIndexPath.Create(0, i)).ToArray();
            //            TableView.InsertRows(indexes, UITableViewRowAnimation.Automatic);
            //            TableView.EndUpdates();
            //        }
            //        break;
            //    case NotifyCollectionChangedAction.Remove:
            //        {
            //            var indexes = Enumerable.Range(e.OldStartingIndex, e.OldItems.Count).Select(i => NSIndexPath.FromIndex((nuint)i)).ToArray();
            //            TableView.DeleteRows(indexes, UITableViewRowAnimation.Automatic);
            //        }
            //        break;
            //    case NotifyCollectionChangedAction.Replace:
            //        {
            //            var indexes = Enumerable.Range(e.NewStartingIndex, e.NewItems.Count).Select(i => NSIndexPath.FromIndex((nuint)i)).ToArray();
            //            TableView.ReloadRows(indexes, UITableViewRowAnimation.Automatic);
            //        }
            //        break;
            //    case NotifyCollectionChangedAction.Move:
            //        {
            //            TableView.MoveRow(NSIndexPath.FromIndex((nuint)e.OldStartingIndex), NSIndexPath.FromIndex((nuint)e.NewStartingIndex));
            //        }
            //        break;
            //    case NotifyCollectionChangedAction.Reset:
            //        {
            //            TableView.ReloadData();
            //        }
            //        break;
            //}
            TableView.ReloadData();
            UpdateEmptyMessage();
        }
    }
}
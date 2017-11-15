using C1.CollectionView;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using SQLite.Net.Async;
using System.Collections.Specialized;

namespace SQLiteDataBase
{
    /// <summary>
    /// This coleccion view allows showing and modifying a SQLite data table in any control.
    /// </summary>
    /// <remarks>
    /// The collection view supports loading on demand, sorting, filtering and editing.
    /// </remarks>
    public class SQLiteCollectionView<T> : C1CursorCollectionView<T, int?>, ISupportSorting, ISupportFiltering, ISupportEditing
        where T : class
    {
        #region ** fields

        private SQLiteAsyncConnection _connection;

        #endregion

        #region ** initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteCollectionView{T}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public SQLiteCollectionView(SQLiteAsyncConnection connection)
        {
            _connection = connection;
        }

        #endregion

        #region ** object model

        /// <summary>
        /// Gets or sets the number of items brought from the data base in each page while scrolling.
        /// </summary>
        public int PageCount { get; set; } = 50;

        #endregion

        #region ** editing

        public bool CanInsert(int index)
        {
            return true;
        }

        public bool CanRemove(int index)
        {
            return true;
        }

        public bool CanReplace(int index)
        {
            return true;
        }

        public bool CanMove(int fromIndex, int toIndex)
        {
            return false;
        }

        public async Task<int> InsertAsync(int index, object item)
        {
            var result = await _connection.InsertAsync(item);
            if ((SortDescriptions != null && SortDescriptions.Count > 0) || FilterExpression != null)
            {
                await RefreshAsync();
            }
            else
            {
                //gets the "count" to know the position where the element was inserted.
                var insertedIndex = await _connection.Table<T>().CountAsync() - 1;
                if (InternalList.Count >= insertedIndex)
                {
                    InternalList.Insert(insertedIndex, item as T);
                    var awaiter = NotifyCollectionChangedAsyncEventArgs.Create(NotifyCollectionChangedAction.Add, item, insertedIndex);
                    OnCollectionChanged(awaiter.EventArgs);
                    await awaiter.WaitDeferralsAsync();
                    return insertedIndex;
                }
            }
            return -1;
        }

        public async Task RemoveAsync(int index)
        {
            var item = this[index];
            await _connection.DeleteAsync(item);
            InternalList.RemoveAt(index);
            var awaiter = NotifyCollectionChangedAsyncEventArgs.Create(NotifyCollectionChangedAction.Remove, item, index);
            OnCollectionChanged(awaiter.EventArgs);
            await awaiter.WaitDeferralsAsync();
        }

        public async Task ReplaceAsync(int index, object item)
        {
            await _connection.UpdateAsync(item);
        }

        public Task MoveAsync(int fromIndex, int toIndex)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ** implementation

        public override bool CanSort(params SortDescription[] sortDescriptions)
        {
            return sortDescriptions?.Length <= 1;
        }

        public override bool CanFilter(FilterExpression filterExpression)
        {
            return true;
        }

        /// <summary>
        /// Returns the items in the page as well as a token to the next page.
        /// </summary>
        /// <param name="startingIndex">The index where the returned items will be inserted.</param>
        /// <param name="pageToken">The token of the requesting page, pass null if no pages had been requested so far.</param>
        /// <param name="count">The desired number of items to be returned.</param>
        /// <param name="sortDescriptions">The sort descriptions.</param>
        /// <param name="filterExpresssion">The filter expression.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A tuple containing the items and a token to the next page.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override async Task<Tuple<int?, IReadOnlyList<T>>> GetPageAsync(int startingIndex, int? pageToken, int? count = null, IReadOnlyList<SortDescription> sortDescriptions = null, FilterExpression filterExpression = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = _connection.Table<T>();
            count = count ?? PageCount;
            if (filterExpression != null)
            {
                query = query.Where(filterExpression.GetSQLFilterExpression<T>());
            }
            if (sortDescriptions?.Count > 0)
            {
                var sortDescription = sortDescriptions[0];
                var sortExpression = sortDescription.GetSortExpression<T>();
                if (sortDescription.Direction == SortDirection.Ascending)
                    query = query.OrderBy(sortExpression);
                else
                    query = query.OrderByDescending(sortExpression);
            }
            query = query.Skip(startingIndex).Take(count.Value);
            var items = await query.ToListAsync();
            int? nextPageKey = items.Count == count ? startingIndex + items.Count : (int?)null;
            return new Tuple<int?, IReadOnlyList<T>>(nextPageKey, items);
        }

        #endregion
    }
}

using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Specialized;
using C1.CollectionView;

namespace C1CollectionView101
{
    public abstract class CollectionViewAdapter<T> : RecyclerView.Adapter
        where T : class
    {
        public enum ItemType : int { Item, Group, Load };

        public CollectionViewAdapter(ICollectionView<T> collectionView)
        {
            CollectionView = collectionView;
            CollectionView.CollectionChanged += OnCollectionChanged;
        }

        public ICollectionView<T> CollectionView { get; private set; }

        public override int ItemCount
        {
            get
            {
                return CollectionView.Count + (CollectionView.CanLoadItems() && CollectionView.HasMoreItems() ? 1 : 0);
            }
        }

        public sealed override int GetItemViewType(int position)
        {
            if (position >= CollectionView.Count)
                return (int)ItemType.Load;
            var item = CollectionView[position];
            if (item is GroupItem<object, object>)
                return (int)ItemType.Group;
            else
                return (int)ItemType.Item;
        }

        public sealed override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            switch ((ItemType)viewType)
            {
                default:
                case ItemType.Item:
                    return OnCreateItemViewHolder(parent);
                case ItemType.Group:
                    return OnCreateGroupViewHolder(parent);
                case ItemType.Load:
                    return OnCreateLoadViewHolder(parent);
            }
        }

        protected abstract RecyclerView.ViewHolder OnCreateItemViewHolder(ViewGroup parent);

        protected virtual RecyclerView.ViewHolder OnCreateGroupViewHolder(ViewGroup parent)
        {
            var view = LayoutInflater.FromContext(parent.Context).Inflate(global::Android.Resource.Layout.SimpleListItem1, parent, false);
            return new GroupViewHolder(view);
        }

        protected virtual RecyclerView.ViewHolder OnCreateLoadViewHolder(ViewGroup parent)
        {
            var progress = new ProgressBar(parent.Context);
            progress.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            return new LoadViewHolder(progress);
        }

        public sealed override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch ((ItemType)holder.ItemViewType)
            {
                default:
                case ItemType.Item:
                    OnBindItemViewHolder(holder, position);
                    break;
                case ItemType.Group:
                    OnBindGroupViewHolder(holder, position);
                    break;
                case ItemType.Load:
                    OnBindLoadViewHolder(holder, position);
                    break;
            }
        }

        protected abstract void OnBindItemViewHolder(RecyclerView.ViewHolder holder, int position);

        protected virtual void OnBindGroupViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var groupHolder = holder as GroupViewHolder;
            if (groupHolder != null)
            {
                var group = CollectionView[position] as GroupItem<object, object>;
                if (group != null && group.Group != null)
                {
                    groupHolder.SetGroupTitle(group.Group.ToString());
                }
            }
        }

        protected virtual void OnBindLoadViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            holder.ItemView.Post(async () =>
            {
                await CollectionView.LoadMoreItemsAsync();
            });
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    NotifyItemRangeInserted(e.NewStartingIndex + 1, e.NewItems.Count);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    NotifyItemRangeRemoved(e.OldStartingIndex, e.OldItems.Count);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    NotifyItemRangeChanged(e.OldStartingIndex, e.OldItems.Count);
                    break;
                case NotifyCollectionChangedAction.Move:
                    NotifyItemMoved(e.OldStartingIndex, e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    NotifyDataSetChanged();
                    break;
            }
        }

        private class LoadViewHolder : RecyclerView.ViewHolder
        {
            public LoadViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class GroupViewHolder : RecyclerView.ViewHolder
        {
            TextView _textView;
            public GroupViewHolder(View itemView) : base(itemView)
            {
                _textView = itemView.FindViewById<TextView>(global::Android.Resource.Id.Text1);
            }

            public void SetGroupTitle(string group)
            {
                _textView.Text = group;
            }
        }
    }
}
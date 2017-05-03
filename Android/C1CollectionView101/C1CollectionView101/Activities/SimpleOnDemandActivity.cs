using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using C1.CollectionView;

namespace C1CollectionView101
{
    [Activity(Label = "@string/SimpleOnDemandTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class SimpleOnDemandActivity : Activity
    {
        private SimpleOnDemandCollectionView _collectionView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SimpleOnDemand);

            SwipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.SwipeRefresh);
            RecyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);


            _collectionView = new SimpleOnDemandCollectionView();
            RecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            RecyclerView.SetAdapter(new SimpleOnDemandAdapter(_collectionView));

            SwipeRefresh.Refresh += OnRefresh;
        }

        public SwipeRefreshLayout SwipeRefresh { get; set; }
        public RecyclerView RecyclerView { get; set; }

        private async void OnRefresh(object sender, System.EventArgs e)
        {
            try
            {
                SwipeRefresh.Refreshing = true;
                await _collectionView.RefreshAsync();
            }
            finally
            {
                SwipeRefresh.Refreshing = false;
            }
        }
    }

    internal class SimpleOnDemandAdapter : CollectionViewAdapter<MyDataItem>
    {

        public SimpleOnDemandAdapter(ICollectionView<MyDataItem> collectionView)
            : base(collectionView)
        {
        }

        protected override RecyclerView.ViewHolder OnCreateItemViewHolder(ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context)
                               .Inflate(Resource.Layout.ListItem, null, false);
            return new SimpleOnDemandViewHolder(view);
        }

        protected override void OnBindItemViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as SimpleOnDemandViewHolder;
            var item = CollectionView[position];
            h.SetTitle(item.ItemName);
            h.SetSubtitle(item.ItemDateTime.ToLongTimeString());
        }
    }

    internal class SimpleOnDemandViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;
        private TextView _subTitle;

        public SimpleOnDemandViewHolder(View itemView)
            : base(itemView)
        {
            _title = itemView.FindViewById<TextView>(Resource.Id.Title);
            _subTitle = itemView.FindViewById<TextView>(Resource.Id.Subtitle);
            var icon = itemView.FindViewById<ImageView>(Resource.Id.Icon);
            icon.Visibility = ViewStates.Gone;
        }

        internal void SetTitle(string title)
        {
            _title.Text = title;
        }

        internal void SetSubtitle(string subTitle)
        {
            _subTitle.Text = subTitle;
        }
    }


    public class SimpleOnDemandCollectionView : C1CursorCollectionView<MyDataItem>
    {
        public SimpleOnDemandCollectionView()
        {
            PageSize = 20;
        }

        public int PageSize { get; set; }
        protected override async Task<Tuple<string, IReadOnlyList<MyDataItem>>> GetPageAsync(string pageToken, int? count = null)
        {
            var newItems = new List<MyDataItem>();
            await Task.Run(() =>
            {
                // create new page of items
                for (int i = 0; i < this.PageSize; i++)
                {
                    newItems.Add(new MyDataItem(this.Count + i));
                }
            });
            return new Tuple<string, IReadOnlyList<MyDataItem>>("token not used", newItems);
        }
    }
    public class MyDataItem
    {
        public MyDataItem(int index)
        {
            this.ItemName = "My Data Item #" + index.ToString();
            this.ItemDateTime = DateTime.Now;
        }
        public string ItemName { get; set; }
        public DateTime ItemDateTime { get; set; }

    }

}
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;

using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1CollectionView101
{
    [Activity(Label = "C1CollectionView101", MainLauncher = true, Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(BaseContext));
            var adapter = new CollectionViewSamplesAdapter();
            adapter.ItemClicked += (s, e) =>
            {
                switch (e.Position)
                {
                    case 0:
                        StartActivity(typeof(SortingActivity));
                        break;
                    case 1:
                        StartActivity(typeof(FilteringActivity));
                        break;
                    case 2:
                        StartActivity(typeof(GroupingActivity));
                        break;
                    case 3:
                        StartActivity(typeof(SimpleOnDemandActivity));
                        break;
                    case 4:
                        StartActivity(typeof(OnDemandActivity));
                        break;
                }
            };
            recyclerView.SetAdapter(adapter);
        }
    }
    internal class CollectionViewSamplesAdapter : RecyclerView.Adapter
    {
        public event EventHandler<FlexGridSampleItemClickedEventArgs> ItemClicked;

        public override int ItemCount
        {
            get
            {
                return 5;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                               .Inflate(Resource.Layout.ListItem, null);
            view.Click += (s, e) =>
            {
                var v = s as View;
                var recyclerView = v.Parent as RecyclerView;
                int itemPosition = recyclerView.GetChildAdapterPosition(v);

                if (ItemClicked != null)
                    ItemClicked(v, new FlexGridSampleItemClickedEventArgs { Position = itemPosition });
            };
            return new FlexGridSamplesViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as FlexGridSamplesViewHolder;
            var resources = holder.ItemView.Context.Resources;
            switch (position)
            {
                case 0:
                    h.SetTitle(resources.GetString(Resource.String.SortingTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.SortingDescription));
                    h.SetIcon(Resource.Drawable.sort);
                    break;
                case 1:
                    h.SetTitle(resources.GetString(Resource.String.FilteringTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.FilteringDescription));
                    h.SetIcon(Resource.Drawable.filter);
                    break;
                case 2:
                    h.SetTitle(resources.GetString(Resource.String.GroupingTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.GroupingDescription));
                    h.SetIcon(Resource.Drawable.grouping);
                    break;
                case 3:
                    h.SetTitle(resources.GetString(Resource.String.SimpleOnDemandTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.SimpleOnDemandDescription));
                    h.SetIcon(Resource.Drawable.loading);
                    break;
                case 4:
                    h.SetTitle(resources.GetString(Resource.String.OnDemandTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.OnDemandDescription));
                    h.SetIcon(Resource.Drawable.loading);
                    break;
            }
        }
    }

    public class FlexGridSampleItemClickedEventArgs : EventArgs
    {
        public int Position { get; set; }
    }

    internal class FlexGridSamplesViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;
        private TextView _subTitle;
        private ImageView _icon;

        public FlexGridSamplesViewHolder(View itemView)
            : base(itemView)
        {
            _title = itemView.FindViewById<TextView>(Resource.Id.Title);
            _subTitle = itemView.FindViewById<TextView>(Resource.Id.Subtitle);
            _icon = itemView.FindViewById<ImageView>(Resource.Id.Icon);
        }

        internal void SetTitle(string title)
        {
            _title.Text = title;
        }

        internal void SetSubtitle(string title)
        {
            _subTitle.Text = title;
        }

        internal void SetIcon(int resourceId)
        {
            _icon.SetImageResource(resourceId);
        }
    }

}


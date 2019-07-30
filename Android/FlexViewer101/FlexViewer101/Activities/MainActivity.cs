using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexViewer101
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            C1.Android.Core.LicenseManager.Key = License.Key;
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(BaseContext));
            var adapter = new FlexViewerSamplesAdapter();
            adapter.ItemClicked += (s, e) =>
            {
                switch (e.Position)
                {
                    case 0:
                        StartActivity(typeof(GettingStartedActivity));
                        break;
                    case 1:
                        StartActivity(typeof(PdfBrowserActivity));
                        break;
                    case 2:
                        StartActivity(typeof(CustomizeAppearanceActivity));
                        break;
                    case 3:
                        StartActivity(typeof(ExportActivity));
                        break;
                }
            };
            recyclerView.SetAdapter(adapter);
        }
    }
    internal class FlexViewerSamplesAdapter : RecyclerView.Adapter
    {
        public event EventHandler<FlexGridSampleItemClickedEventArgs> ItemClicked;

        public override int ItemCount
        {
            get
            {
                return 4;
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
            return new FlexViewerSamplesViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as FlexViewerSamplesViewHolder;
            var resources = holder.ItemView.Context.Resources;
            switch (position)
            {
                case 0:
                    h.SetTitle(resources.GetString(Resource.String.GettingStartedTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.GettingStartedDescription));
                    h.SetIcon(Resource.Drawable.GettingStarted);
                    break;
                case 1:
                    h.SetTitle(resources.GetString(Resource.String.PdfBrowserTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.PdfBrowserDescription));
                    h.SetIcon(Resource.Drawable.BrowsePDF);
                    break;
                case 2:
                    h.SetTitle(resources.GetString(Resource.String.CustomizeAppearanceTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.CustomizeAppearanceDescription));
                    h.SetIcon(Resource.Drawable.CustomizeApearance);
                    break;
                case 3:
                    h.SetTitle(resources.GetString(Resource.String.ExportTitle));
                    h.SetSubtitle(resources.GetString(Resource.String.ExportDescription));
                    h.SetIcon(Resource.Drawable.Export);
                    break;
            }
        }
    }

    public class FlexGridSampleItemClickedEventArgs : EventArgs
    {
        public int Position { get; set; }
    }

    internal class FlexViewerSamplesViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;
        private TextView _subTitle;
        private ImageView _icon;

        public FlexViewerSamplesViewHolder(View itemView)
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


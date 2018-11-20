using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Calendar101
{
    [Activity(Label = "C1Calendar101", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            C1.Android.Core.LicenseManager.Key = License.Key;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(BaseContext));
            var adapter = new CalendarSamplesAdapter();
            adapter.ItemClicked += (s, e) =>
            {
                switch (e.Position)
                {
                    case 0:
                        StartActivity(typeof(GettingStartedActivity));
                        break;
                    case 1:
                        StartActivity(typeof(VerticalOrientationActivity));
                        break;
                    case 2:
                        StartActivity(typeof(CustomDayContentActivity));
                        break;
                    case 3:
                        StartActivity(typeof(CustomHeaderActivity));
                        break;
                    case 4:
                        StartActivity(typeof(CustomAppearanceActivity));
                        break;
                    case 5:
                        StartActivity(typeof(PopupEditorActivity));
                        break;
                    case 6:
                        StartActivity(typeof(CustomSelectionActivity));
                        break;
                }
            };
            recyclerView.SetAdapter(adapter);
        }
    }

    internal class CalendarSamplesAdapter : RecyclerView.Adapter
    {
        public event EventHandler<CalendarSampleItemClickedEventArgs> ItemClicked;

        public override int ItemCount
        {
            get
            {
                return 7;
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
                      ItemClicked(v, new CalendarSampleItemClickedEventArgs { Position = itemPosition });
              };
            return new CalendarSamplesViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as CalendarSamplesViewHolder;
            var resources = holder.ItemView.Context.Resources;
            switch (position)
            {
                case 0:
                    h.SetTitle(resources.GetString(Resource.String.getting_started));
                    h.SetSubtitle(resources.GetString(Resource.String.getting_started_desc));
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
                case 1:
                    h.SetTitle(resources.GetString(Resource.String.vertical_orientation));
                    h.SetSubtitle(resources.GetString(Resource.String.vertical_orientation_desc));
                    h.SetIcon(Resource.Drawable.calendar_vertical);
                    break;
                case 2:
                    h.SetTitle(resources.GetString(Resource.String.custom_day_content));
                    h.SetSubtitle(resources.GetString(Resource.String.custom_day_content_desc));
                    h.SetIcon(Resource.Drawable.calendar2);
                    break;
                case 3:
                    h.SetTitle(resources.GetString(Resource.String.custom_header));
                    h.SetSubtitle(resources.GetString(Resource.String.custom_header_desc));
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
                case 4:
                    h.SetTitle(resources.GetString(Resource.String.custom_appearance));
                    h.SetSubtitle(resources.GetString(Resource.String.custom_appearance_desc));
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
                case 5:
                    h.SetTitle(resources.GetString(Resource.String.popup_editor));
                    h.SetSubtitle(resources.GetString(Resource.String.popup_editor_desc));
                    h.SetIcon(Resource.Drawable.calendar_datepicker);
                    break;
                case 6:
                    h.SetTitle(resources.GetString(Resource.String.custom_selection));
                    h.SetSubtitle(resources.GetString(Resource.String.custom_selection_desc));
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
            }
        }
    }

    public class CalendarSampleItemClickedEventArgs : EventArgs
    {
        public int Position { get; set; }
    }

    internal class CalendarSamplesViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;
        private TextView _subTitle;
        private ImageView _icon;

        public CalendarSamplesViewHolder(View itemView)
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


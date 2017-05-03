using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace C1Calendar101
{
    [Activity(Label = "C1Calendar101", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            C1.Android.Core.LicenseManager.Key = License.Key;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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
            switch (position)
            {
                case 0:
                    h.SetTitle("Getting Started");
                    h.SetSubtitle("Shows a basic calendar with selection and interaction.");
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
                case 1:
                    h.SetTitle("Vertical Orientation");
                    h.SetSubtitle("Shows a calendar with vertical navigation/scrolling.");
                    h.SetIcon(Resource.Drawable.calendar_vertical);
                    break;
                case 2:
                    h.SetTitle("Custom Day Content");
                    h.SetSubtitle("Shows how to customize a day slot to show custom content.");
                    h.SetIcon(Resource.Drawable.calendar2);
                    break;
                case 3:
                    h.SetTitle("Custom Header");
                    h.SetSubtitle("Shows a custom header inspired by a popular Android or iOS calendar app.");
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
                case 4:
                    h.SetTitle("Custom Appearance");
                    h.SetSubtitle("Shows a calendar with a custom style.");
                    h.SetIcon(Resource.Drawable.calendar);
                    break;
                case 5:
                    h.SetTitle("Popup Editor");
                    h.SetSubtitle("Shows how to use the control as a pop-up date selector.");
                    h.SetIcon(Resource.Drawable.calendar_datepicker);
                    break;
                case 6:
                    h.SetTitle("Custom Selection");
                    h.SetSubtitle("Shows custom selection scenarios.");
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


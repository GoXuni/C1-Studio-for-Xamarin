using System;
using Android.App;

using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V4.Content;
using C1.Android.Input;

using System.Threading;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace C1Input101
{
    [Activity(Label = "@string/autocomplete", Icon = "@drawable/icon")]
    public class AutoCompleteActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_autocomplete);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.autocomplete);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var highLightAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_highlight);
            highLightAutoComplete.ItemsSource = Countries.GetDemoDataList();
            highLightAutoComplete.DisplayMemberPath = "Name";
            highLightAutoComplete.EditableHeaderBackgroundColor = Android.Graphics.Color.White;
            highLightAutoComplete.DropDownBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.window_background));
            highLightAutoComplete.DropDownBorderWidth = 1;
            highLightAutoComplete.HeaderBorderWidth = 1;
            highLightAutoComplete.HeaderBorderColor = Android.Graphics.Color.Black;

            var customAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_custom);
            customAutoComplete.ItemsSource = Countries1.GetDemoDataList();
            customAutoComplete.DisplayMemberPath = "Name";
            customAutoComplete.EditableHeaderBackgroundColor = Android.Graphics.Color.White;
            customAutoComplete.DropDownBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.window_background));
            customAutoComplete.DropDownBorderWidth = 1;
            customAutoComplete.HeaderBorderWidth = 1;
            customAutoComplete.HeaderBorderColor = Android.Graphics.Color.Black;

            customAutoComplete.ItemLoading += (object sender, ComboBoxItemLoadingEventArgs e) =>
            {
                createItemView(e.Item as Countries1, e);
            };


            var filterAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_filter);
            filterAutoComplete.DisplayMemberPath = "Title";
            filterAutoComplete.IsAnimated = true;
            filterAutoComplete.Delay = TimeSpan.FromSeconds(1);
            filterAutoComplete.EditableHeaderBackgroundColor = Android.Graphics.Color.White;
            filterAutoComplete.DropDownBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.window_background));
            filterAutoComplete.DropDownBorderWidth = 1;
            filterAutoComplete.HeaderBorderWidth = 1;
            filterAutoComplete.HeaderBorderColor = Android.Graphics.Color.Black;

            filterAutoComplete.Filtering += async (sender, e) =>
            {
                var deferral = e.GetDeferral();
                try
                {
                    var collectionView = new YouTubeCollectionView();
                    await collectionView.SearchAsync(e.FilterString);
                    filterAutoComplete.ItemsSource = collectionView;
                    e.Cancel = true;
                }
                finally
                {
                    deferral.Complete();
                }
            };

            filterAutoComplete.ItemLoading += (object sender, ComboBoxItemLoadingEventArgs e) =>
            {
                createYouTubeItemView(e.Item as YouTubeVideo, e);
            };
        }

        private void createItemView(Countries1 item, ComboBoxItemLoadingEventArgs e)
        {
            View originalItemView = e.ItemView;
            var itemView = LayoutInflater.FromContext(originalItemView.Context).Inflate(Resource.Layout.custom_item, (ViewGroup)originalItemView.Parent, false);

            TextView titleView = itemView.FindViewById<TextView>(Resource.Id.textView1);
            ImageView iconView = itemView.FindViewById<ImageView>(Resource.Id.imageView1);
            titleView.Text = item.Name;
            iconView.SetImageResource(item.ImageId);

            e.ItemView = itemView;
        }

        private void createYouTubeItemView(YouTubeVideo video, ComboBoxItemLoadingEventArgs e)
        {
            View originalItemView = e.ItemView;
            var itemView = LayoutInflater.FromContext(originalItemView.Context).Inflate(Resource.Layout.ListItem, (ViewGroup)originalItemView.Parent, false);

            YoutubeViewHolder holder = new YoutubeViewHolder(itemView);
            holder.SetTitle(video.Title);
            holder.SetSubtitle(video.Description);
            holder.SetVideoThumbnail(video.Thumbnail, CancellationToken.None);

            e.ItemView = holder.ItemView;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }

}


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
            highLightAutoComplete.ItemsSource = Country.GetDemoDataList();
            highLightAutoComplete.DisplayMemberPath = "Name";

            var customAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_custom);
            customAutoComplete.ItemsSource = CountryWithFlag.GetDemoDataList();
            customAutoComplete.DisplayMemberPath = "Name";
            customAutoComplete.ItemLoading += (object sender, ComboBoxItemLoadingEventArgs e) =>
            {
                CreateItemView(e.Item as CountryWithFlag, e);
            };


            var filterAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_filter);
            filterAutoComplete.DisplayMemberPath = "Title";
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
                CreateYouTubeItemView(e.Item as YouTubeVideo, e);
            };
        }

        private void CreateItemView(CountryWithFlag item, ComboBoxItemLoadingEventArgs e)
        {
            View originalItemView = e.ItemView;
            var itemView = LayoutInflater.FromContext(originalItemView.Context).Inflate(Resource.Layout.custom_item, (ViewGroup)originalItemView.Parent, false);

            TextView titleView = itemView.FindViewById<TextView>(Resource.Id.textView1);
            ImageView iconView = itemView.FindViewById<ImageView>(Resource.Id.imageView1);
            titleView.Text = item.Name;
            iconView.SetImageResource(item.ImageId);

            e.ItemView = itemView;
        }

        private void CreateYouTubeItemView(YouTubeVideo video, ComboBoxItemLoadingEventArgs e)
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


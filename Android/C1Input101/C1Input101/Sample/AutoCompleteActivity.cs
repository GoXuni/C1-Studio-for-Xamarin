using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

using C1.Android.Input;
using C1.Android.Core;
using Java.Lang;
using Java.IO;
using Java.Net;

using System.Collections.Generic;
using Android.Support.V7.Widget;
using C1.Android.CollectionView;
using C1.CollectionView;
using System.Threading;

namespace C1Input101
{
    [Activity(Label = "@string/autocomplete", Icon = "@drawable/icon")]
    public class AutoCompleteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_autocomplete);

            var highLightAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_highlight);
            highLightAutoComplete.ItemsSource = Countries.GetDemoDataList();
            highLightAutoComplete.DisplayMemberPath = "Name";

            var delayAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_delay);
            delayAutoComplete.ItemsSource = Countries.GetDemoDataList();
            delayAutoComplete.DisplayMemberPath = "Name";
            delayAutoComplete.Delay = TimeSpan.FromSeconds(1.5);

            var customAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_custom);
            customAutoComplete.ItemsSource = Countries1.GetDemoDataList();
            customAutoComplete.DisplayMemberPath = "Name";

            customAutoComplete.ItemLoading += (object sender, ComboBoxItemLoadingEventArgs e) =>
            {
                createItemView(e.Item as Countries1, e);
            };


            var filterAutoComplete = (C1AutoComplete)this.FindViewById(Resource.Id.autocomplete_filter);
            filterAutoComplete.DisplayMemberPath = "Title";
            filterAutoComplete.IsAnimated = true;
            filterAutoComplete.DropDownHeight = 200;
            filterAutoComplete.Delay = TimeSpan.FromSeconds(1);
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
    }

}


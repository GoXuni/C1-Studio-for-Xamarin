using System;
using Android.Support.V7.Widget;
using Android.Views;
using C1.CollectionView;
using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics;
using System.Threading;
using C1.Android.CollectionView;

namespace C1CollectionView101
{
    internal class YouTubeAdapter : C1RecyclerViewAdapter<object>
    {
        public YouTubeAdapter(ICollectionView<object> collectionView)
            : base(collectionView)
        {
        }

        protected override RecyclerView.ViewHolder OnCreateGroupViewHolder(ViewGroup parent)
        {
            var itemView = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.ListGroup, parent, false);
            return new YoutubeGroupViewHolder(itemView);
        }

        protected override void OnBindGroupViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as YoutubeGroupViewHolder;
            var group = CollectionView[position] as ICollectionViewGroup<object, object>;
            h.SetTitle(group.Group.ToString().ToUpper());
        }

        protected override RecyclerView.ViewHolder OnCreateItemViewHolder(ViewGroup parent)
        {
            var itemView = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);
            return new YoutubeViewHolder(itemView);
        }

        protected override void OnBindItemViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = holder as YoutubeViewHolder;
            var video = CollectionView[position] as YouTubeVideo;
            h.SetTitle(video.Title);
            h.SetSubtitle(video.Description);
            h.SetVideoThumbnail(video.Thumbnail, CancellationToken.None);
        }
    }

    internal class YoutubeViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;
        private TextView _subTitle;
        private ImageView _icon;

        public YoutubeViewHolder(View itemView)
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

        internal void SetVideoThumbnail(string url, CancellationToken cancellationToken)
        {
            _icon.SetImageResource(Resource.Drawable.placeholder);
            Bitmap imageSource = null;
            Task.Run(() =>
            {
                var imageStream = new Java.Net.URL(url).OpenStream();
                imageSource = BitmapFactory.DecodeStream(imageStream);
            }).ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion && !cancellationToken.IsCancellationRequested)
                {
                    _icon.SetImageBitmap(imageSource);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }

    internal class YoutubeGroupViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;

        public YoutubeGroupViewHolder(View itemView)
            : base(itemView)
        {
            _title = itemView.FindViewById<TextView>(Resource.Id.Title);
        }

        internal void SetTitle(string title)
        {
            _title.Text = title;
        }
    }
}
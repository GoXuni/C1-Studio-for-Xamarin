using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Widget;

namespace C1CollectionView101
{
    [Activity(Label = "@string/OnDemandTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class OnDemandActivity : Activity
    {
        private YouTubeCollectionView _collectionView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OnDemand);

            SwipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.SwipeRefresh);
            RecyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            Search = FindViewById<EditText>(Resource.Id.Search);


            _collectionView = new YouTubeCollectionView();
            RecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            RecyclerView.SetAdapter(new YouTubeAdapter(_collectionView));

            SwipeRefresh.Refresh += OnRefresh;
            Search.TextChanged += OnTextChanged;
        }

        public SwipeRefreshLayout SwipeRefresh { get; set; }
        public RecyclerView RecyclerView { get; set; }
        public EditText Search { get; set; }

        private async void OnTextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            await _collectionView.SearchAsync(Search.Text);
        }

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
}
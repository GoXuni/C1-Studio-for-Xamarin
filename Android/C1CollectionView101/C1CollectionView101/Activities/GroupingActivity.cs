using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using C1.CollectionView;

namespace C1CollectionView101
{
    [Activity(Label = "@string/GroupingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class GroupingActivity : Activity
    {
        private ICollectionView<object> _collectionView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            RecyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);

            var task = UpdateVideos();
        }

        public RecyclerView RecyclerView { get; set; }

        private async Task UpdateVideos()
        {
            var indicator = new ProgressBar(this);
            try
            {
                indicator.Activated = true;
                var videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin Android", "relevance", null, 50)).Item2);
                _collectionView = new C1CollectionView<YouTubeVideo>(videos).AsPlain();
                await _collectionView.GroupAsync("ChannelTitle");
                RecyclerView.SetLayoutManager(new LinearLayoutManager(this));
                RecyclerView.SetAdapter(new YouTubeAdapter(_collectionView));
            }
            catch
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetMessage(Resources.GetString(Resource.String.InternetConnectionError));
                var alert = builder.Create();
                alert.Show();
            }
            finally
            {
                indicator.Activated = false;
            }
        }
    }
}
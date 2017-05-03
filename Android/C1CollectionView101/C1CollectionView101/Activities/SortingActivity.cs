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
    [Activity(Label = "@string/SortingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class SortingActivity : Activity
    {
        private C1CollectionView<YouTubeVideo> _collectionView;

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
                _collectionView = new C1CollectionView<YouTubeVideo>(videos);
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
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var sortMenuItem = menu.Add(0, 0, 0, Resource.String.SortingTitle);
            sortMenuItem.SetShowAsAction(ShowAsAction.Always);
            var direction = GetCurrentSortDirection();
            sortMenuItem.SetIcon(direction == SortDirection.Descending ? Resource.Drawable.ic_sort_ascending : Resource.Drawable.ic_sort_descending);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                var task = ToggleSort(item);
            }
            return base.OnOptionsItemSelected(item);
        }

        private async Task ToggleSort(IMenuItem item)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                item.SetEnabled(false);
                var newDirection = direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                await _collectionView.SortAsync(x => x.Title, newDirection);
                item.SetEnabled(true);
                InvalidateOptionsMenu();
            }
        }

        private SortDirection GetCurrentSortDirection()
        {
            var sort = SortDirection.Descending;
            if (_collectionView != null)
            {
                var sortDescription = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "Title");
                if (sortDescription != null)
                    sort = sortDescription.Direction;
            }
            return sort;
        }

    }
}
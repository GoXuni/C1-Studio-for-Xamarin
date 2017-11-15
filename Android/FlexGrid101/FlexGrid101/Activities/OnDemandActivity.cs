using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Util;
using System.Threading.Tasks;
using C1.Android.Core;
using C1.Android.Grid;
using Android.Content.PM;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/OnDemandTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class OnDemandActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OnDemand);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.OnDemandTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            Search = FindViewById<EditText>(Resource.Id.Search);
            ProgressBar = FindViewById<ProgressBar>(Resource.Id.ProgressBar);
            EmptyListLabel = FindViewById<TextView>(Resource.Id.EmptyListLabel);

            var dips_4 = TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
            var dips_70 = TypedValue.ApplyDimension(ComplexUnitType.Dip, 70, Resources.DisplayMetrics);
            var dips_100 = TypedValue.ApplyDimension(ComplexUnitType.Dip, 100, Resources.DisplayMetrics);
            var dips_160 = TypedValue.ApplyDimension(ComplexUnitType.Dip, 160, Resources.DisplayMetrics);

            CollectionView = new YouTubeCollectionView() { PageSize = 25 };
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Add(new GridImageColumn { Binding = "Thumbnail", Header = " ", Width = new GridLength(dips_70), ImagePadding = new C1Thickness(dips_4, dips_4, 0, dips_4), PlaceholderImageResource = Resource.Drawable.placeholder });
            Grid.Columns.Add(new GridColumn { Binding = "Title", Header = "Title", MinWidth = dips_160, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "ChannelTitle", Header = "Channel", Width = new GridLength(dips_100) });
            Grid.GridLinesVisibility = GridLinesVisibility.None;
            Grid.SelectionMode = GridSelectionMode.None;
            Grid.ItemsSource = CollectionView;
            Grid.CellTapped += OnCellTapped;
            Search.Text = "Xamarin Android";
            Search.EditorAction += OnEditorAction;
            var task = PerformSearch();
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
        public FlexGrid Grid { get; set; }
        public YouTubeCollectionView CollectionView { get; set; }
        public EditText Search { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public TextView EmptyListLabel { get; set; }

        private async void OnEditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            await PerformSearch();
            Grid.RequestFocus();
        }

        private void OnCellTapped(object sender, GridCellRangeEventArgs e)
        {
            var video = Grid.Rows[e.CellRange.Row].DataItem as YouTubeVideo;
            if (video != null)
            {
                var browserIntent = new Intent(Intent.ActionView, Uri.Parse(video.Link));
                StartActivity(browserIntent);
            }
        }

        private async Task PerformSearch()
        {
            try
            {
                Grid.Visibility = ViewStates.Invisible;
                EmptyListLabel.Visibility = ViewStates.Invisible;
                ProgressBar.Visibility = ViewStates.Visible;
                Grid.RequestFocus();
                await CollectionView.SearchAsync(Search.Text);
            }
            finally
            {
                var empty = CollectionView.Count == 0;
                Grid.Visibility = empty ? ViewStates.Invisible : ViewStates.Visible;
                EmptyListLabel.Visibility = empty ? ViewStates.Visible : ViewStates.Invisible;
                ProgressBar.Visibility = ViewStates.Invisible;
            }
        }
    }
}
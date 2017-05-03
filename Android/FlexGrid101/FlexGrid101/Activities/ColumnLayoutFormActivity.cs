
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/ColumnLayoutTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class ColumnLayoutFormActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var columnLayout = Intent.Extras.GetString("columnLayout");
            var columns = ColumnLayoutActivity.DeserializeLayout(columnLayout);

            SetContentView(Resource.Layout.GettingStarted);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            Grid.ItemsSource = columns;
        }

        public FlexGrid Grid { get; set; }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var filterMenuItem = menu.Add(0, 0, 0, Resource.String.ColumnLayoutSave);
            filterMenuItem.SetShowAsAction(ShowAsAction.Always);
            filterMenuItem.SetIcon(Resource.Drawable.ic_action_save);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                FinishColumnLayout();
            }
            return base.OnOptionsItemSelected(item);
        }

        private async void FinishColumnLayout()
        {
            Grid.FinishEditing();
            Intent.PutExtra("columnLayout", await ColumnLayoutActivity.SerializeLayout(Grid.ItemsSource as ColumnInfo[]));
            SetResult(Result.Ok, Intent);
            Finish();
        }
    }
}
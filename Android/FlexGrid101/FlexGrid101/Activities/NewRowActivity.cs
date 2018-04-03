using Android.App;
using Android.OS;
using Android.Content.PM;
using C1.Android.Grid;
using C1.CollectionView;
using System.Threading.Tasks;
using System.Collections;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace FlexGrid101
{
    [Activity(Label = "@string/NewRowTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class NewRowActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewRow);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.NewRowTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = new CustomCollectionView<Customer>(data);
            grid.NewRowPlaceholder = ApplicationContext.GetString(Resource.String.NewRowPlaceholder);
            grid.AllowDragging = GridAllowDragging.Both;
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

    public class CustomCollectionView<T> : C1CollectionView<T>
        where T : class
    {
        public CustomCollectionView(IEnumerable source)
            : base(source)
        {
        }

        public override async Task<int> InsertAsync(int index, object item)
        {
            await Task.Delay(1000); //simulates a network operation
            return await base.InsertAsync(index, item);
        }

        public override async Task RemoveAsync(int index)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.RemoveAsync(index);
        }

        public override async Task ReplaceAsync(int index, object item)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.ReplaceAsync(index, item);
        }

        public override async Task MoveAsync(int fromIndex, int toIndex)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.MoveAsync(fromIndex, toIndex);
        }
    }
}
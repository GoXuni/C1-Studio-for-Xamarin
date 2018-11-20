using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/gettingStarted")]
    public class TreeMapActivity : AppCompatActivity
    {
        private C1TreeMap treeMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_tree_map);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.treeMap);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            treeMap = this.FindViewById<C1TreeMap>(Resource.Id.treeMap);
            treeMap.ChartType = C1.Android.Chart.TreeMapType.Squarified;
            treeMap.Binding = "sales";
            treeMap.BindingName = "type";
            treeMap.MaxDepth = 2;
            treeMap.ChildItemsPath = "items";
            treeMap.ItemsSource = ChartPoint.CreateHierarchicalData();

            treeMap.DataLabel = new ChartDataLabel() { Content = "{}{type}", Position = ChartLabelPosition.Center };
            treeMap.DataLabel.Style.FontSize = 10;
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

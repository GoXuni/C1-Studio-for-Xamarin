using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using C1.Android.Chart;
using C1.DataCollection;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace Sunburst101
{
    [Activity(Label = "@string/group_collection", Icon = "@drawable/GroupCollection")]
    public class GroupCollectionActivity : AppCompatActivity
    {
        private C1DataCollection<Item> cv;
        private C1Sunburst sunburst;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_getting_started);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.group_collection);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            sunburst = (C1Sunburst)FindViewById(Resource.Id.sunburst);

            sunburst.Binding = "Value";
            sunburst.BindingName = "Year,Quarter,Month";
            sunburst.ToolTipContent = "{}{name}\n{y}";
            sunburst.DataLabel.Position = PieLabelPosition.Center;
            sunburst.DataLabel.Content = "{}{name}";

            //LinearLayout layout = new LinearLayout(this);
            //LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            //layout.AddView(sunburst, param);


            cv = new SunburstViewModel().View;
            cv.GroupChanged += View_GroupChanged;
            cv.SortChanged += Cv_SortChanged;

            //Sort cannot work synchronize with group in current DataCollection
            SortDescription yearSortDescription = new SortDescription("Year", SortDirection.Ascending);
            SortDescription quarterSortDescription = new SortDescription("Quarter", SortDirection.Ascending);
            SortDescription monthSortDescription = new SortDescription("MonthValue", SortDirection.Ascending);
            SortDescription[] sortDescriptions = new SortDescription[] { yearSortDescription, quarterSortDescription, monthSortDescription };
            cv.SortAsync(sortDescriptions);
            //SetContentView(layout);
        }

        private void Cv_SortChanged(object sender, System.EventArgs e)
        {
            GroupDescription yearGroupDescription = new GroupDescription("Year");
            GroupDescription quarterGroupDescription = new GroupDescription("Quarter");
            GroupDescription monthGroupDescription = new GroupDescription("MonthName");
            GroupDescription[] groupDescriptions = new GroupDescription[] { yearGroupDescription, quarterGroupDescription, monthGroupDescription };
            cv.GroupAsync(groupDescriptions);
        }

        private void View_GroupChanged(object sender, System.EventArgs e)
        {
            this.sunburst.ItemsSource = cv;
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

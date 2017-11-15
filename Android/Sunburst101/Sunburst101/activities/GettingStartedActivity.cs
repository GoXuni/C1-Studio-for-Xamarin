using Android.App;
using Android.Widget;
using Android.OS;

using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace Sunburst101
{
    [Activity(Label = "@string/getting_started", Icon = "@drawable/GettingStarted")]
    public class GettingStartedActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_getting_started);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.getting_started);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            C1Sunburst sunburst = (C1Sunburst)FindViewById(Resource.Id.sunburst);

            sunburst.Binding = "Value";
            sunburst.BindingName = "Year,Quarter,Month";
            sunburst.ToolTipContent = "{}{name}\n{y}";
            sunburst.DataLabel.Position = PieLabelPosition.Center;
            sunburst.DataLabel.Content = "{}{name}";
            sunburst.ItemsSource = new SunburstViewModel().FlatData;
            //LinearLayout layout = new LinearLayout(this);
            //LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            //layout.AddView(sunburst, param);

            
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

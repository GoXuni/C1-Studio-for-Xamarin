using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Input101
{
    [Activity(Label = "C1Input101", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.ApplicationName);

            C1.Android.Core.LicenseManager.Key = License.Key;
            var sampleList = (ListView)FindViewById(Resource.Id.listView1);
            SampleListAdapter adapter = new SampleListAdapter(this);
            sampleList.Adapter = adapter;
            sampleList.ItemClick += ItemClick;
        }

        public void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent();
            // initialize the intent based on user click
            switch (e.Position)
            {
                case 0:
                    AutoCompleteActivity autoActivity = new AutoCompleteActivity();
                    intent = new Intent(ApplicationContext, autoActivity.Class);
                    break;
                case 1:
                    ComboBoxActivity comActivity = new ComboBoxActivity();
                    intent = new Intent(ApplicationContext, comActivity.Class);
                    break;
                case 2:
                    DropDownActivity dropDownActivity = new DropDownActivity();
                    intent = new Intent(ApplicationContext, dropDownActivity.Class);
                    break;
                case 3:
                    MaskActivity maskActivity = new MaskActivity();
                    intent = new Intent(ApplicationContext, maskActivity.Class);
                    break;
            }
            // start the new activity
            StartActivity(intent);
        }
    }
}


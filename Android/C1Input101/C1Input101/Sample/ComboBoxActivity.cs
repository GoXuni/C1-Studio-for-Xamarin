using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

using C1.Android.Input;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Input101
{
    [Activity(Label = "@string/combobox", Icon = "@drawable/icon")]
    public class ComboBoxActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.activity_combobox);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.combobox);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            TextView editableLabel = ((TextView)this.FindViewById(Resource.Id.textView1));
            editableLabel.SetText(Resource.String.editable);

            C1ComboBox comboBox = (C1ComboBox)this.FindViewById(Resource.Id.editable_combobox);
            comboBox.DisplayMemberPath = "Name";
            comboBox.ItemsSource = Country.GetDemoDataList();

            TextView nonEditableLabel = ((TextView)this.FindViewById(Resource.Id.textView2));
            nonEditableLabel.SetText(Resource.String.noneditable);

            C1ComboBox nonEditableComboBox = (C1ComboBox)this.FindViewById(Resource.Id.noneditable_combobox);
            nonEditableComboBox.ItemsSource = Country.GetDemoDataList();
            nonEditableComboBox.DisplayMemberPath = "Name";
            nonEditableComboBox.IsEditable = false;
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


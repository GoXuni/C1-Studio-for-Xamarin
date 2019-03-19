using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
//using Android.Widget;
using C1.Android.Grid;
using System.IO;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/ExportTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class ExportActivity : AppCompatActivity
    {
        private string FILENAME = "ExportedGrid";
        FlexGrid grid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.ExportTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            grid.ItemsSource = Customer.GetCustomerList(100);
            grid.ZoomMode = GridZoomMode.Disabled;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var editMenuItem = menu.Add(0, 0, 0, Resource.String.ExportTitle);
            editMenuItem.SetShowAsAction(ShowAsAction.Always);
            editMenuItem.SetIcon(Resource.Drawable.ic_action_save);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                Save();
            }
            else if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        public void Save()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            PopupMenu menu = new PopupMenu(this, toolbar);
            menu.MenuItemClick += (s1, arg1) => {
                string type = arg1.Item.TitleFormatted.ToString();
                string PathAndName = Path.Combine(Environment.ExternalStorageDirectory.ToString(), FILENAME) + "." + type;
                switch (type)
                {
                    case "CSV":
                        grid.Save(PathAndName, GridFileFormat.Csv, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                        menu.Dismiss();
                        break;
                    case "Txt":
                        grid.Save(PathAndName, GridFileFormat.Text, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                        menu.Dismiss();
                        break;
                    case "HTML":
                        grid.Save(PathAndName, GridFileFormat.Html, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                        menu.Dismiss();
                        break;
                }
                if (type != "Cancel")
                {
                    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                    alert.SetTitle("Saved");
                    alert.SetMessage("File has been saved to: " + PathAndName);
                    alert.SetPositiveButton("OK", (senderAlert, args) => {});
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
                if (type == "HTML")
                {
                    //Device.OpenUri(new Uri(PathAndName));
                }
            };
            menu.Inflate(Resource.Layout.PopUp);
            menu.Show();
        }
    }
}
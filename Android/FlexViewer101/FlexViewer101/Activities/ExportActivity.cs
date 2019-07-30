using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Viewer;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexViewer101
{
    [Activity(Label = "ExportActivity")]
    public class ExportActivity : AppCompatActivity
    {
        MemoryStream memoryStream;
        FlexViewer flexViewer;
        private string FILENAME = "ExportedPdf";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PdfBrowser);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.ExportTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            // Create your application here

            flexViewer = FindViewById<FlexViewer>(Resource.Id.FlexViewer);
            using (var stream = Assets.Open("Simple List.pdf", Android.Content.Res.Access.Streaming))
            {
                using (var sr = new StreamReader(stream))
                {
                    memoryStream = new MemoryStream();
                    sr.BaseStream.CopyTo(memoryStream);
                    flexViewer.LoadDocument(memoryStream);
                }
            }
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var editMenuItem = menu.Add(0, 0, 0, Resource.String.PdfBrowserTitle);
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
            menu.MenuItemClick += (s1, arg1) =>
            {
                string type = arg1.Item.TitleFormatted.ToString();
                string PathAndName = string.Empty;
                switch (type)
                {
                    case "pdf":
                        PathAndName = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), FILENAME) + "." + type;
                        flexViewer.Save(PathAndName);
                        menu.Dismiss();
                        break;
                    case "png":
                        PathAndName = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), FILENAME + "{0}") + "." + type;
                        flexViewer.SaveAsPng(PathAndName, GrapeCity.Documents.Common.OutputRange.All);
                        menu.Dismiss();
                        break;

                }
                if (type != "Cancel")
                {
                    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                    alert.SetTitle("Saved");
                    alert.SetMessage("File has been saved to: " + PathAndName);
                    alert.SetPositiveButton("OK", (senderAlert, args) => { });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            };
            menu.Inflate(Resource.Layout.PopUp);
            menu.Show();
        }
    }
}
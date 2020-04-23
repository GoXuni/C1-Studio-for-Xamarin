using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Viewer;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexViewer101
{
    [Activity(Label = "PdfBrowserActivity")]
    public class PdfBrowserActivity : AppCompatActivity
    {
        static readonly int READ_REQUEST_CODE = 1337;
        MemoryStream memoryStream;
        FlexViewer flexViewer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PdfBrowser);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.PdfBrowserTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            // Create your application here

            flexViewer = FindViewById<FlexViewer>(Resource.Id.FlexViewer);
            flexViewer.DocumentOpening += FlexViewer_DocumentOpening;
            flexViewer.DocumentSaving += FlexViewer_DocumentSaving;
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

        private void FlexViewer_DocumentSaving(object sender, SaveDocumentStreamEventArgs e)
        {
            var deferral = e.GetDeferral();
            try
            {
                e.FilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "export.png");
                e.PageRange = new GrapeCity.Documents.Common.OutputRange(1, 2);
            }
            finally
            {
                deferral.Complete();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var editMenuItem = menu.Add(0, 0, 0, Resource.String.PdfBrowserTitle);
            editMenuItem.SetShowAsAction(ShowAsAction.Always);
            editMenuItem.SetIcon(Resource.Drawable.ic_action_open);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                OpenFile();
            }
            else if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        public void OpenFile()
        {
            Intent intent = new Intent(Intent.ActionOpenDocument);
            intent.AddCategory(Intent.CategoryOpenable);
            intent.SetType("application/pdf");

            StartActivityForResult(intent, READ_REQUEST_CODE);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == READ_REQUEST_CODE && resultCode == Result.Ok)
            {
                if (data != null)
                {
                    Android.Net.Uri uri = data.Data;
                    using (var stream = ContentResolver.OpenInputStream(uri))
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            memoryStream = new MemoryStream();
                            sr.BaseStream.CopyTo(memoryStream);
                            flexViewer.LoadDocument(memoryStream);
                        }
                    }
                }
            }
        }

        private async void FlexViewer_DocumentOpening(object sender, DocumentStreamEventArgs e)
        {
            var deferral = e.GetDeferral();
            try
            {
                e.Stream = await PickFile(e.AllowedTypes);
            }
            finally
            {
                deferral.Complete();
            }
        }

        private async Task<Stream> PickFile(string[] allowedTypes)
        {
            Stream stream = null;
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile(allowedTypes);
                if (fileData == null)
                    return null; // user canceled file picking

                stream = fileData.GetStream();

                return stream;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Core;
using C1.Android.Viewer;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexViewer101
{
    [Activity(Label = "@string/GettingStartedTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomizeHamburgerMenuActivity : AppCompatActivity
    {
        MemoryStream memoryStream;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.CustomizeHamburgerMenuTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var flexViewer = FindViewById<FlexViewer>(Resource.Id.FlexViewer);

            using (var stream = Assets.Open("DefaultDocument.pdf", Android.Content.Res.Access.Streaming))
            {
                using (var sr = new StreamReader(stream))
                {
                    memoryStream = new MemoryStream();
                    sr.BaseStream.CopyTo(memoryStream);
                    flexViewer.LoadDocument(memoryStream);
                }
            }

            flexViewer.MenuItems.Add(new MenuItem(GetString(Resource.String.ExportToBitmap), new C1PathIcon(this) { Data = @"M12,1L8,5H11V14H13V5H16M18,23H6C4.89,23 4,22.1 4,21V9A2,2 0 0,1 6,7H9V9H6V21H18V9H15V7H18A2,2 0 0,1 20,9V21A2,2 0 0,1 18,23Z" }, new ExportToBmpCommand(flexViewer)));
            flexViewer.MenuItems.Add(new MenuItem("New Menu", new C1PathIcon(this) { Data = @"M6.1,10L4,18V8H21A2,2 0 0,0 19,6H12L10,4H4A2,2 0 0,0 2,6V18A2,2 0 0,0 4,20H19C19.9,20 20.7,19.4 20.9,18.5L23.2,10H6.1M19,18H6L7.6,12H20.6L19,18Z" }, new MyCommand(flexViewer, this)));
            flexViewer.MenuItemClicked += FlexViewer_MenuItemClicked;
            flexViewer.MenuItems[flexViewer.MenuItems.Count - 1].Header = GetString(Resource.String.ChangeBackground);
            flexViewer.DocumentOpening += FlexViewer_DocumentOpening;
            flexViewer.DocumentSaving += FlexViewer_DocumentSaving;
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

        private void FlexViewer_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ClickedItem.Header);
        }
        public override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            if (memoryStream != null)
            {
                memoryStream.Dispose();
                memoryStream = null;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (memoryStream != null)
            {
                memoryStream.Dispose();
                memoryStream = null;
            }
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
    public class MyCommand : ICommand
    {
        private FlexViewer _flexViewer;
        private Android.Content.Context _context;
        public MyCommand(FlexViewer flexViewer, Android.Content.Context context)
        {
            _flexViewer = flexViewer;
            _context = context;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _flexViewer.PageBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(_context, Resource.Color.colorWhite));
            _flexViewer.BackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(_context, Resource.Color.colorLightSlateGray));
            _flexViewer.PageBorderColor = new Android.Graphics.Color(ContextCompat.GetColor(_context, Resource.Color.colorBlack));
            _flexViewer.Padding = new C1Thickness(20, 20, 20, 20);
            _flexViewer.PageSpacing = 5;
            _flexViewer.Refresh();
        }
    }

    public class ExportToBmpCommand : ICommand
    {
        private FlexViewer _flexViewer;
        public ExportToBmpCommand(FlexViewer flexViewer)
        {
            _flexViewer = flexViewer;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "export.bmp");
            _flexViewer.SaveAsBmp(filePath);
        }
    }
}
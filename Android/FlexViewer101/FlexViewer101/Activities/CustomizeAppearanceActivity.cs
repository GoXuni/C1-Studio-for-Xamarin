using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Core;
using C1.Android.Viewer;
using System.IO;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexViewer101
{
    [Activity(Label = "@string/GettingStartedTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomizeAppearanceActivity : AppCompatActivity
    {
        MemoryStream memoryStream;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.CustomizeAppearanceTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var flexViewer = FindViewById<FlexViewer>(Resource.Id.FlexViewer);
            flexViewer.PageBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.colorWhite));
            flexViewer.BackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.colorLightSlateGray));
            flexViewer.PageBorderColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.colorBlack));
            flexViewer.Padding = new C1Thickness(20, 20, 20, 20);
            flexViewer.PageSpacing = 5;

            using (var stream = Assets.Open("PdfViewer.pdf", Android.Content.Res.Access.Streaming))
            {
                using (var sr = new StreamReader(stream))
                {
                    memoryStream = new MemoryStream();
                    sr.BaseStream.CopyTo(memoryStream);
                    flexViewer.LoadDocument(memoryStream);
                }
            }
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
    }
}
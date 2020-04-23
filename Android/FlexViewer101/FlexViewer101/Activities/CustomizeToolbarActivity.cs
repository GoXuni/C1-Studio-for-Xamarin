using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using C1.Android.Viewer;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using ImeOptions = Android.Views.InputMethods.ImeAction;
using Android.Text;
using C1.Android.Core;

namespace FlexViewer101
{
    [Activity(Label = "CustomizeToolbarActivity")]
    public class CustomizeToolbarActivity : AppCompatActivity
    {
        static readonly int READ_REQUEST_CODE = 1337;
        MemoryStream memoryStream;
        FlexViewer flexViewer;
        EditText searchTextBox;
        C1ToggleButton btnNext, btnPrevious;
        LinearLayout stackLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomizeToolbar);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            stackLayout = FindViewById<LinearLayout>(Resource.Id.searchLayout);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.CustomizeToolbarTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            // Create your application here

            var nextIcon = C1IconTemplate.ChevronRight.CreateIcon();
            var previousIcon = C1IconTemplate.ChevronLeft.CreateIcon();

            nextIcon.RenderWidth = 40;
            nextIcon.RenderHeight = 40;

            previousIcon.RenderWidth = 40;
            previousIcon.RenderHeight = 40;

            btnNext = new C1ToggleButton(this.ApplicationContext);
            btnPrevious = new C1ToggleButton(this.ApplicationContext);

            flexViewer = FindViewById<FlexViewer>(Resource.Id.FlexViewer);
            searchTextBox = FindViewById<EditText>(Resource.Id.SearchText);
            searchTextBox.EditorAction += Entry_EditorAction;
            searchTextBox.InputType = InputTypes.TextFlagAutoCorrect;
            searchTextBox.ImeOptions = ImeOptions.Search;

            btnPrevious.SetBackgroundColor(Android.Graphics.Color.Transparent);
            btnPrevious.Color = Android.Graphics.Color.Black;
            btnPrevious.Padding = new C1Thickness(10);
            btnPrevious.CheckedContent = previousIcon;
            btnPrevious.UncheckedContent = previousIcon;
            btnPrevious.Checked += BtnPrevious_Checked;

            btnNext.SetBackgroundColor(Android.Graphics.Color.Transparent);
            btnNext.Color = Android.Graphics.Color.Black;
            btnNext.Padding = new C1Thickness(10);
            btnNext.CheckedContent = nextIcon;
            btnNext.UncheckedContent = nextIcon;
            btnNext.Checked += BtnNext_Checked;
        
            stackLayout.Visibility = ViewStates.Gone;

            stackLayout.AddView(btnPrevious);
            stackLayout.AddView(btnNext);


            flexViewer.ShowToolbar = false;
            flexViewer.ShowMenu = false;
            using (var stream = Assets.Open("Simple List.pdf", Android.Content.Res.Access.Streaming))
            {
                using (var sr = new StreamReader(stream))
                {
                    memoryStream = new MemoryStream();
                    sr.BaseStream.CopyTo(memoryStream);
                    flexViewer.LoadDocument(memoryStream);
                }
            }
            // Create your application here
        }

        private void BtnPrevious_Checked(object sender, EventArgs e)
        {
            flexViewer.Previous();
        }

        private void BtnNext_Checked(object sender, EventArgs e)
        {
            flexViewer.Next();
        }

        private void Entry_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            var result = flexViewer.SearchText(searchTextBox.Text, false, false, false);
            if (result.Count > 0)
            {
                btnNext.Visibility = ViewStates.Visible;
                btnPrevious.Visibility = ViewStates.Visible;
            }
            else
            {
                btnNext.Visibility = ViewStates.Invisible;
                btnPrevious.Visibility = ViewStates.Invisible;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var editMenuItem = menu.Add(0, 0, 0, Resource.String.CustomizeToolbarTitle);
            editMenuItem.SetShowAsAction(ShowAsAction.Always);
            editMenuItem.SetIcon(Resource.Drawable.ic_action_open);

            var searchMenuItem = menu.Add(0, 1, 1, Resource.String.CustomizeToolbarTitle);
            searchMenuItem.SetShowAsAction(ShowAsAction.Always);
            searchMenuItem.SetIcon(Resource.Drawable.ic_action_search);

            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                OpenFile();
            }
            else if(item.ItemId == 1)
            {
                OnSearch();
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
        public void OnSearch()
        {
            if (stackLayout.Visibility == ViewStates.Gone) stackLayout.Visibility = ViewStates.Visible;
            else stackLayout.Visibility = ViewStates.Gone;

            if (stackLayout.Visibility == ViewStates.Gone)
            {
                searchTextBox.Text = "";
                flexViewer.ResetSearch();
            }
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

    }
}
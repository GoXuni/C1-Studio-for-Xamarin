using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using C1.Xamarin.Forms.Core;
using Xamarin.Forms;
using FlexViewer101.Resources;
using Xamarin.Forms.Xaml;
using Plugin.FilePicker.Abstractions;
using Plugin.FilePicker;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomizeToolbar : ContentPage
    {
        Assembly assembly;
        bool _pickingFile = false;
        string[] _fileTypes;
        private bool onAppearingFirstTime = true;
        public CustomizeToolbar()
        {
            InitializeComponent();
            this.Title = AppResources.CustomizeToolbarTitle;
            flexViewer.ShowToolbar = false;
            flexViewer.ShowMenu = false;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    _fileTypes = new string[] { "application/pdf" };
                    break;
                case Device.iOS:
                    //http://cocoadocs.org/docsets/Cutis/0.1/Structs/UTType.html#/s:ZvV5Cutis6UTType5ImageS0_
                    _fileTypes = new string[] { "com.adobe.pdf" };
                    break;
                default:
                    _fileTypes = new string[] { ".pdf" };
                    break;
            }

            var nextIcon = C1IconTemplate.ChevronRight.CreateIcon();
            nextIcon.WidthRequest = 20;
            nextIcon.HeightRequest = 20;
            var previousIcon = C1IconTemplate.ChevronLeft.CreateIcon();
            previousIcon.WidthRequest = 20;
            previousIcon.HeightRequest = 20;

            btnNext.IsVisible = false;

            btnNext.CheckedContent = nextIcon;
            btnNext.UncheckedContent = nextIcon;
            btnNext.Checked += BtnNext_Checked;

            btnPrevious.IsVisible = false;
            btnPrevious.CheckedContent = previousIcon;
            btnPrevious.UncheckedContent = previousIcon;
            btnPrevious.Checked += BtnPrevious_Checked;

            searchBar.IsVisible = false;
            searchBar.SearchButtonPressed += SearchBarSearchBarButtonPressed;
            searchBar.TextChanged += SearchBarTextChanged;

            btnOpen.Text = "Open";
            btnSearch.Text = "Search";
        }

        private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(searchBar.Text))
            {
                flexViewer.ResetSearch();
                btnNext.IsEnabled = false;
                btnPrevious.IsEnabled = false;
            }
        }

        private void BtnPrevious_Checked(object sender, EventArgs e)
        {
            flexViewer.Previous();
        }

        private void BtnNext_Checked(object sender, EventArgs e)
        {
            flexViewer.Next();
        }

        private void SearchBarSearchBarButtonPressed(object sender, EventArgs e)
        {
            var result = flexViewer.SearchText(searchBar.Text, false, false, false);
            if (result != null && result.Count > 0)
            {
                btnNext.IsEnabled = true;
                btnPrevious.IsEnabled = true;
            }
            else
            {
                btnNext.IsEnabled = false;
                btnPrevious.IsEnabled = false;
            }
        }

        protected override void OnAppearing()
        {
            if (onAppearingFirstTime)
            {
                base.OnAppearing();
                searchBar.WidthRequest = this.Width - (btnNext.WidthRequest + btnPrevious.WidthRequest + 18);
                flexViewer.HeightRequest = this.Height - searchBar.HeightRequest;
                if (_pickingFile)
                {
                    _pickingFile = false;
                    return;
                }

                assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly; ;
                Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.Simple List.pdf");
                flexViewer.LoadDocument(stream);
                onAppearingFirstTime = false;
            }
        }
        async void OnOpen(object sender, EventArgs e)
        {
            Stream stream = null;
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile(_fileTypes);
                if (fileData == null)
                    return; // user canceled file picking

                stream = fileData.GetStream();

                flexViewer.LoadDocument(stream);
                _pickingFile = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
                return;
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            searchBar.WidthRequest = this.Width - (btnNext.WidthRequest + btnPrevious.WidthRequest + 18);
            flexViewer.HeightRequest = this.Height - searchBar.HeightRequest;
        }
        void OnSearch(object sender, EventArgs e)
        {
            searchBar.IsVisible = !searchBar.IsVisible;
            btnNext.IsVisible = !btnNext.IsVisible;
            btnPrevious.IsVisible = !btnPrevious.IsVisible;
            if (searchBar.IsVisible == false)
            {
                flexViewer.ResetSearch();
            }
        }
    }
}
using C1.Xamarin.Forms.Core;
using C1.Xamarin.Forms.Viewer;
using FlexViewer101.Resources;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomizeHamburgerMenu : ContentPage
    {
        Assembly assembly;
        private bool onAppearingFirstTime = true;
        public CustomizeHamburgerMenu()
        {
            InitializeComponent();
            this.Title = AppResources.CustomizeHamburgerTitle;
            flexViewer.MenuItems.Add(new C1.Xamarin.Forms.Viewer.MenuItem(AppResources.ExportBmp, new C1PathIcon() { Data = @"M12,1L8,5H11V14H13V5H16M18,23H6C4.89,23 4,22.1 4,21V9A2,2 0 0,1 6,7H9V9H6V21H18V9H15V7H18A2,2 0 0,1 20,9V21A2,2 0 0,1 18,23Z" }, new ExportToBmpCommand(flexViewer)));
            flexViewer.MenuItems.Add(new C1.Xamarin.Forms.Viewer.MenuItem("New Menu", new C1PathIcon() { Data = @"M6.1,10L4,18V8H21A2,2 0 0,0 19,6H12L10,4H4A2,2 0 0,0 2,6V18A2,2 0 0,0 4,20H19C19.9,20 20.7,19.4 20.9,18.5L23.2,10H6.1M19,18H6L7.6,12H20.6L19,18Z" }, new MyCommand(flexViewer)));            
            flexViewer.MenuItemClicked += FlexViewer_MenuItemClicked;
            SetMenuWidth();
            flexViewer.DocumentOpening += FlexViewer_DocumentOpening;
            flexViewer.DocumentSaving += FlexViewer_DocumentSaving;
        }

        private void FlexViewer_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ClickedItem.Header);
        }

        protected override void OnAppearing()
        {
            if (onAppearingFirstTime)
            {
                base.OnAppearing();
                assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.DefaultDocument.pdf");
                flexViewer.LoadDocument(stream);
                onAppearingFirstTime = false;
                flexViewer.MenuItems[flexViewer.MenuItems.Count - 1].Header = AppResources.ChangeBackGround;
                SetMenuWidth();
            }
        }

        void SetMenuWidth()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    flexViewer.MenuWidth = 220;
                    break;
                case Device.Android:
                    flexViewer.MenuWidth = 450;
                    break;
                default:
                    flexViewer.MenuWidth = 300;
                    break;
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

        private async void FlexViewer_DocumentSaving(object sender, SaveDocumentStreamEventArgs e)
        {
            var deferral = e.GetDeferral();
            try
            {
                e.FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "export.png");
                e.PageRange = new GrapeCity.Documents.Common.OutputRange(1, 2);
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
        public MyCommand(FlexViewer flexViewer)
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
            _flexViewer.BackgroundColor = Color.Green;
            _flexViewer.PageBorderColor = Color.Red;
            _flexViewer.Padding = new Thickness(40, 40, 40, 40);
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
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "export.bmp");
            _flexViewer.SaveAsBmp(filePath);
        }
    }

}
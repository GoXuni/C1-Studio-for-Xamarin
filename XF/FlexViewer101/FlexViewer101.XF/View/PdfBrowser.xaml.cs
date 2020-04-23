using C1.Xamarin.Forms.Viewer;
using FlexViewer101.Resources;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfBrowser : ContentPage
    {
        Assembly assembly;
        bool _pickingFile = false;
        string[] _fileTypes;
        private bool onAppearingFirstTime = true;

        public PdfBrowser()
        {
            InitializeComponent();
            this.Title = AppResources.PdfBrowserTitle;
            btnSave.Text = AppResources.OpenFile;

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

            flexViewer.DocumentOpening += FlexViewer_DocumentOpening;
            flexViewer.DocumentSaving += FlexViewer_DocumentSaving;
        }

        private void FlexViewer_DocumentSaving(object sender, SaveDocumentStreamEventArgs e)
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

        protected override void OnAppearing()
        {
            if (onAppearingFirstTime)
            {
                base.OnAppearing();

                if (_pickingFile)
                {
                    _pickingFile = false;
                    return;
                }

                assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.Simple List.pdf");
                flexViewer.LoadDocument(stream);
                onAppearingFirstTime = false;
            }
        }
        async void OnOpen(object sender, EventArgs e)
        {
            var stream = await PickFile(_fileTypes);
            if (stream != null)
            {
                flexViewer.LoadDocument(stream);
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

                _pickingFile = true;
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

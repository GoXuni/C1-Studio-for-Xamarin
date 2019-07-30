using C1.Xamarin.Forms.Viewer;
using FlexViewer101.Resources;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        }
        protected override void OnAppearing()
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
    }
}

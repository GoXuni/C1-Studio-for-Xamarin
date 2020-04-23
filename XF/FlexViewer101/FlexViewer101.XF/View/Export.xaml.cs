using FlexViewer101.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using C1.Xamarin.Forms.Viewer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Export : ContentPage
    {
        Assembly assembly;
        private string FILENAME = "Exported";
        private bool onAppearingFirstTime = true;
        public Export()
        {
            InitializeComponent();
            this.Title = AppResources.ExportTitle;
            btnSave.Text = AppResources.ExportTitle;
            flexViewer.ZoomMode = FlexViewerZoomMode.PageWidth;
            flexViewer.PageDisplayMode = PageDisplayMode.OnePage;
            flexViewer.ShowMenu = false;
        }
        protected override void OnAppearing()
        {
            if (onAppearingFirstTime)
            {
                base.OnAppearing();

                assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.Simple List.pdf");
                flexViewer.LoadDocument(stream);
                onAppearingFirstTime = false;
            }
        }
        async void OnSave(object sender, EventArgs e)
        {
            var type = await DisplayActionSheet(AppResources.Save_As, "Cancel", null, "pdf", "png");
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string PathAndName = Path.Combine(folder, FILENAME);
            switch (type)
            {
                case "pdf":
                    flexViewer.Save(PathAndName + "." + type, true);
                    await DisplayAlert(AppResources.Saved, AppResources.FileSaved + folder, "OK");
                    break;
                case "png":
                    flexViewer.SaveAsPng(PathAndName + "{0}." + type, GrapeCity.Documents.Common.OutputRange.All);
                    await DisplayAlert(AppResources.Saved, AppResources.FileSaved + folder, "OK");
                    break;
            }
        }
    }
}
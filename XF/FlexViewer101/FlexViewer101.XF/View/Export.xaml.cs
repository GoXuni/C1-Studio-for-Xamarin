using FlexViewer101.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Export : ContentPage
    {
        Assembly assembly;
        private string FILENAME = "ExportedPdf";
        public Export()
        {
            InitializeComponent();
            this.Title = AppResources.ExportTitle;
            btnSave.Text = AppResources.ExportTitle;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.Simple List.pdf");
            flexViewer.LoadDocument(stream);
        }
        async void OnSave(object sender, EventArgs e)
        {
            var type = await DisplayActionSheet("Save As", "Cancel", null, "pdf", "png");

            string PathAndName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME);
            switch (type)
            {
                case "pdf":
                    flexViewer.Save(PathAndName + "." + type);
                    break;
                case "png":
                    flexViewer.SaveAsPng(PathAndName + "{0}." + type, GrapeCity.Documents.Common.OutputRange.All);
                    break;
            }
            if (type != "Cancel")
            {
                await DisplayAlert("Saved", "File has been saved to: " + PathAndName, "OK");
            }
        }
    }
}
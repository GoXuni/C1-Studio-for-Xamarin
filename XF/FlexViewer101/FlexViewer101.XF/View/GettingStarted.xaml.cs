using C1.Xamarin.Forms.Viewer;
using FlexViewer101.Resources;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexViewer101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStarted : ContentPage
    {
        Assembly assembly;
        private bool onAppearingFirstTime = true;
        public GettingStarted()
        {
            InitializeComponent();
            this.Title = AppResources.GettingStartedTitle;
            flexViewer.ZoomMode = FlexViewerZoomMode.PageWidth;
            flexViewer.PageDisplayMode = PageDisplayMode.OnePage;
            flexViewer.ShowMenu = false;
        }

        protected override void OnAppearing()
        {
            if (onAppearingFirstTime == true)
            {
                base.OnAppearing();
                assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.DefaultDocument.pdf");
                flexViewer.LoadDocument(stream);
                onAppearingFirstTime = false;
            }
        }
    }
}

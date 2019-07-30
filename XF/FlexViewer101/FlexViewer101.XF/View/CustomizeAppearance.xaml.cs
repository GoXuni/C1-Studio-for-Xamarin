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
    public partial class CustomizeAppearance : ContentPage
    {
        Assembly assembly;
        public CustomizeAppearance()
        {
            InitializeComponent();
            this.Title = AppResources.CustomizeAppearanceTitle;

            flexViewer.PageBackgroundColor = Color.White;
            flexViewer.BackgroundColor = Color.LightSlateGray;
            flexViewer.PageBorderColor = Color.Black;
            flexViewer.Padding = new Thickness(20, 20, 20, 20);
            flexViewer.PageSpacing = 5;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.PdfViewer.pdf");
            flexViewer.LoadDocument(stream);
        }
    }
}

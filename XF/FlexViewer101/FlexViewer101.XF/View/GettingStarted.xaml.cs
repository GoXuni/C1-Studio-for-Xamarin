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
        public GettingStarted()
        {
            InitializeComponent();
            this.Title = AppResources.GettingStartedTitle;   
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            assembly = IntrospectionExtensions.GetTypeInfo(typeof(GettingStarted)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("FlexViewer101.Resources.DefaultDocument.pdf");
            flexViewer.LoadDocument(stream);
        }
    }
}

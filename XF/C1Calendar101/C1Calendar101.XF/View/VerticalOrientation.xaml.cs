using C1Calendar101.Resources;
using Xamarin.Forms.Xaml;

namespace C1Calendar101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerticalOrientation
    {
        public VerticalOrientation()
        {
            InitializeComponent();
            Title = AppResources.VerticalOrientationTitle;
        }

    }
}

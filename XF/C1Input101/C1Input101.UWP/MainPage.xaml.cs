using C1.Xamarin.Forms.Input.Platform.UWP;

namespace C1Input101.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            C1InputRenderer.Init();
            this.InitializeComponent();

            LoadApplication(new C1Input101.App());
        }
    }
}

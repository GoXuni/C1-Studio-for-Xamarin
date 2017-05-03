using Foundation;
using UIKit;

namespace FlexGrid101.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            System.AppDomain ad = System.AppDomain.CurrentDomain;

            global::Xamarin.Forms.Forms.Init();
            C1.Xamarin.Forms.Grid.Platform.iOS.FlexGridRenderer.Init();
            C1.Xamarin.Forms.Gauge.Platform.iOS.C1GaugeRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(application, launchOptions);
        }
    }
}



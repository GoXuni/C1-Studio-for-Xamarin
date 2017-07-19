using Foundation;
using UIKit;

namespace C1Input101.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            C1.Xamarin.Forms.Input.Platform.iOS.C1InputRenderer.Init();
            C1.Xamarin.Forms.Calendar.Platform.iOS.C1CalendarRenderer.Init();

            LoadApplication(new C1Input101.App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

    }
}

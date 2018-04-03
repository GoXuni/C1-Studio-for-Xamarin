using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;

namespace C1Calendar101.iOS
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
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Workaround from https://bugzilla.xamarin.com/show_bug.cgi?id=59596
            try
            {
                // Get the user's preferred language
                var language = NSLocale.PreferredLanguages[0];
                // Extract the language code
                var languageDic = NSLocale.ComponentsFromLocaleIdentifier(language);
                var languageCode = languageDic["kCFLocaleLanguageCodeKey"].ToString();
                // Force .NET culture to that of the device
                var culture = new System.Globalization.CultureInfo(languageCode);
                System.Globalization.CultureInfo.CurrentCulture = culture;
                System.Globalization.CultureInfo.CurrentUICulture = culture;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to set culture from iOS device culture");
            }
            global::Xamarin.Forms.Forms.Init();
            C1.Xamarin.Forms.Calendar.Platform.iOS.C1CalendarRenderer.Init();

            LoadApplication(new C1Calendar101.App());

            return base.FinishedLaunching(app, options);
        }
    }
}
using System;
using UIKit;
using Foundation;
using C1.iOS.Core;

namespace C1Gauge101
{
	public partial class ExportImageViewController : UIViewController
	{
		public ExportImageViewController(IntPtr handle) : base (handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void DoSnapshot (UIKit.UIBarButtonItem sender)
		{
			SaveImageToDisk();
		}

		async void SaveImageToDisk()
		{
			var gaugeImage = new UIImage(NSData.FromArray(await RadialGauge.GetImage()));
			gaugeImage.SaveToPhotosAlbum((image, error) =>
			{
				string message, title;

				if (error == null)
				{
					title = Foundation.NSBundle.MainBundle.LocalizedString("ImageSavedTitle", "");
					message = Foundation.NSBundle.MainBundle.LocalizedString("ImageSavedDescription", "");

                }
				else
				{
					title = Foundation.NSBundle.MainBundle.LocalizedString("PermissionDenied", "");
					message = error.Description;
				}

				UIAlertView alert = new UIAlertView(title, message, null, "OK", null);
				alert.Show();
			});
		}

	}
}


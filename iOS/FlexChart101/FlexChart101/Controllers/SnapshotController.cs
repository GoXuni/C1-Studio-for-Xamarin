using System;

using Foundation;
using UIKit;
using C1.iOS.Chart;
using C1.iOS.Core;

namespace FlexChart101
{
	public partial class SnapshotController : UIViewController
	{
		public SnapshotController() : base("SnapshotController", null)
		{
		}

		public SnapshotController(IntPtr handle) : base(handle)
		{ 
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Chart.BindingX = "Name";
			Chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Sales" });
            Chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Expenses" });
            Chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads,Downloads" });
			Chart.ItemsSource = SalesData.GetSalesDataList();
		}

		partial void doSnapshot(UIKit.UIBarButtonItem sender)
		{
			UIGraphics.BeginImageContextWithOptions(View.Bounds.Size, false, 0.0f);
			View.Layer.RenderInContext(UIGraphics.GetCurrentContext());
			UIImage ima = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			ima.SaveToPhotosAlbum((image, error) =>
			{
			if (error == null)
				new UIAlertView(NSBundle.MainBundle.LocalizedString("Image Saved", "optional"), NSBundle.MainBundle.LocalizedString("The image has been saved to your device‘s picture album.", "optional"), null, NSBundle.MainBundle.LocalizedString("OK", "optional"), null).Show();
			else
				new UIAlertView(NSBundle.MainBundle.LocalizedString("Failure", "optional"), error.Description, null, NSBundle.MainBundle.LocalizedString("OK", "optional"), null).Show();
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


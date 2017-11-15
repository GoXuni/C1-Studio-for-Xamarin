// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FlexChart101
{
	[Register ("LineMarkerController")]
	partial class LineMarkerController
	{
		[Outlet]
		C1.iOS.Chart.FlexChart chart { get; set; }

		[Outlet]
		UIKit.UIPickerView picker { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (picker != null) {
				picker.Dispose ();
				picker = null;
			}

			if (chart != null) {
				chart.Dispose ();
				chart = null;
			}
		}
	}
}

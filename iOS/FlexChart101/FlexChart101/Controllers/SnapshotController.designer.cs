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
	[Register ("SnapshotController")]
	partial class SnapshotController
	{
		[Outlet]
		C1.iOS.Chart.FlexChart Chart { get; set; }

		[Action ("doSnapshot:")]
		partial void doSnapshot (UIKit.UIBarButtonItem sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Chart != null) {
				Chart.Dispose ();
				Chart = null;
			}
		}
	}
}

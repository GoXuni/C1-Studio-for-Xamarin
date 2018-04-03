// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FlexChart101.Controllers
{
	[Register ("UpdateAnimationController")]
	partial class UpdateAnimationController
	{
		[Outlet]
		C1.iOS.Chart.FlexChart chart { get; set; }

		[Outlet]
		UIKit.UIPickerView picker { get; set; }

		[Action ("AddPoint:")]
		partial void AddPoint (UIKit.UIButton sender);

		[Action ("RemovePoint:")]
		partial void RemovePoint (UIKit.UIButton sender);
		
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

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
	[Register ("LoadAnimationController")]
	partial class LoadAnimationController
	{
		[Outlet]
		UIKit.UIPickerView picker { get; set; }

		[Action ("reverseSwitched:")]
		partial void reverseSwitched (UIKit.UISwitch sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (picker != null) {
				picker.Dispose ();
				picker = null;
			}
		}
	}
}

using System;
using UIKit;
using C1.iOS.Input;
using CoreGraphics;

namespace C1Input101
{
	public partial class MaskedInputController : UIViewController
	{
		public MaskedInputController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			MaskedID.Mask = "000-00-0000";
			MaskedDOB.Mask = "90/90/0000";
			MaskedPhone.Mask = "(999) 000-0000";
			MaskedState.Mask = "LL";
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



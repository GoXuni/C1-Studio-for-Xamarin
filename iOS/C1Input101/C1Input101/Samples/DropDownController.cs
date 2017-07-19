using System;
using UIKit;
using C1.iOS.Calendar;
using C1.iOS.Input;

namespace C1Input101
{
	public partial class DropDownController : UIViewController
	{
		public static C1MaskedTextField maskedField;
		public C1Calendar calendar;
		public static C1DropDown d;

		public DropDownController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			DropDown.DropDownHeight = 300;
			DropDown.DropDownWidth = DropDown.Frame.Size.Width;
			DropDown.DropDownMode = DropDownMode.ForceBelow;
			DropDown.IsAnimated = true;
			d = DropDown;

			maskedField = new C1MaskedTextField();
            maskedField.Mask = Foundation.NSBundle.MainBundle.LocalizedString("00/00/0000", "");
            maskedField.BackgroundColor = UIColor.Clear;
			maskedField.BorderStyle = UITextBorderStyle.None;
			DropDown.Header = maskedField;

			calendar = new C1Calendar();
			calendar.SelectionChanged += (object sender, CalendarSelectionChangedEventArgs e) =>
			{
				DateTime dateTime = calendar.SelectedDates[0];
                string strDate = dateTime.ToString(Foundation.NSBundle.MainBundle.LocalizedString("MM-dd-yyyy", ""));
                maskedField.Text = strDate;
				d.IsDropDownOpen = false;
			};
			DropDown.DropDown = calendar;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



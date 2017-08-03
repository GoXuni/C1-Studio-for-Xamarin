using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using C1.Android.Calendar;
using C1.Android.Input;
using Java.Text;

namespace C1Input101
{
	[Activity(Label = "@string/dropdown", Icon = "@drawable/icon")]
	public class DropDownActivity : Activity
	{
        C1DropDown dropdown;
        C1MaskedTextView header;
        C1Calendar calendar;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			dropdown = new C1DropDown(this);
			header = new C1MaskedTextView(this);
            header.Mask = Resources.GetString(Resource.String.date_mask_string);

            calendar = new C1Calendar(this);
			dropdown.Header = header;
			dropdown.DropDown = calendar;
			dropdown.DropDownHeight = 300;
			dropdown.IsAnimated = true;

            calendar.SelectionChanged += (object sender, CalendarSelectionChangedEventArgs e) =>
			{
				dropdown.IsDropDownOpen = false;
				System.DateTime  dateTime = calendar.SelectedDates[0];
                string strDate = dateTime.ToString(Resources.GetString(Resource.String.date_mask_format));
                header.Value = strDate;
			};


            LinearLayout layout = new LinearLayout(this);
            LinearLayout.LayoutParams parameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            layout.AddView(dropdown, parameters);
            SetContentView(layout);

            

        }

	}
}


using Foundation;
using System;
using UIKit;
using C1.iOS.Calendar;

namespace C1Calendar101
{
    public partial class CustomHeaderController : UIViewController
    {
        public CustomHeaderController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            var model = new ViewModePickerViewModel(async row =>
            {
                switch (row)
                {
                    case 0:
                        await Calendar.ChangeViewModeAsync(CalendarViewMode.Month);
                        break;
                    case 1:
                        await Calendar.ChangeViewModeAsync(CalendarViewMode.Year);
                        break;
                    case 2:
                        await Calendar.ChangeViewModeAsync(CalendarViewMode.Decade);
                        break;
                }
            });
            ViewModePicker.Model = model;
            Calendar.ViewModeChanged += OnViewModeChanged;
            Calendar.DisplayDateChanged += OnDisplayDateChanged;
            UpdateHeaderLabel();
        }

        async partial void TodayButton_TouchUpInside(UIButton sender)
        {
            await Calendar.ChangeViewModeAsync(CalendarViewMode.Month, DateTime.Today);
            Calendar.SelectedDate = DateTime.Today;
        }     
        public override void DidReceiveMemoryWarning()
        {
            Calendar.RemoveFromSuperview();
            HeaderLabel.RemoveFromSuperview();
            TodayButton.RemoveFromSuperview();
            ViewModePicker.RemoveFromSuperview();
            ReleaseDesignerOutlets();
            base.DidReceiveMemoryWarning();
        }
       
        private void OnViewModeChanged(object sender, EventArgs e)
        {
            switch (Calendar.ViewMode)
            {
                case CalendarViewMode.Month:
                    ViewModePicker.Select(0, 0, true);
                    break;
                case CalendarViewMode.Year:
                    ViewModePicker.Select(1, 0, true);
                    break;
                case CalendarViewMode.Decade:
                    ViewModePicker.Select(2, 0, true);
                    break;
            }
        }

        private void OnDisplayDateChanged(object sender, EventArgs e)
        {
            UpdateHeaderLabel();
        }

        private void UpdateHeaderLabel()
        {
            HeaderLabel.Text = Calendar.DisplayDate.ToString("Y");
        }

        public class ViewModePickerViewModel : UIPickerViewModel
        {
            Action<nint> _selected;
            public ViewModePickerViewModel(Action<nint> selected)
            {
                _selected = selected;
            }

            public override nint GetComponentCount(UIPickerView picker)
            {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView picker, nint component)
            {
                return 3;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                switch (row)
                {
                    default:
                    case 0:
                        return NSBundle.MainBundle.LocalizedString("Month View", "");
                    case 1:
                        return NSBundle.MainBundle.LocalizedString("Year View", "");
                    case 2:
                        return NSBundle.MainBundle.LocalizedString("Decade View", "");
                }
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                _selected(row);
            }
        }

    }
}
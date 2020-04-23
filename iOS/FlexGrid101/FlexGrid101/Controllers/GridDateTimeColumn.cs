using CoreGraphics;
using Foundation;
using System;
using System.Reflection;
using UIKit;
using C1.iOS.Core;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public class GridDateTimeColumn : GridColumn
    {
        public GridDateTimeColumn() : base() { }
        public GridDateTimeColumn(PropertyInfo property) : base(property) { }

        public GridDateTimeColumnMode Mode { get; set; }

        protected override UIView CreateCellEditor(GridRow row)
        {
            if (DataType == typeof(DateTime))
            {
                var original = (DateTime)GetCellValue(GridCellType.Cell, row);
                var datePicker = new UIDatePicker();
                if (Mode == GridDateTimeColumnMode.Date)
                {
                    datePicker.Mode = UIDatePickerMode.Date;
                    datePicker.Date = DateTimeToNSDate(original);
                }
                else
                {
                    datePicker.Mode = UIDatePickerMode.Time;
                    datePicker.Date = DateTimeToNSDate(DateTime.Today + original.TimeOfDay);
                }
                var toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
                var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
                var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
                toolBar.SetItems(new UIBarButtonItem[] { flexibleSpace, doneButton }, true);

                var entry = new C1TextField();
                entry.Insets = Grid.CellPadding;
                entry.InputView = datePicker;
                entry.InputAccessoryView = toolBar;
                entry.Text = original.ToString(Format);
                entry.BackgroundColor = Grid.EditorBackgroundColor;
                entry.TextColor = Grid.EditorTextColor;

                doneButton.Clicked += (s, e) =>
                {
                    entry.Text = NSDateToDateTime(datePicker.Date).ToString(Format);
                    Grid.FinishEditing();
                };
                return entry;
            }
            else
            {
                return base.CreateCellEditor(row);
            }
        }

        protected override object GetEditorValue(GridRow row, UIView editor)
        {
            var field = editor as UITextField;
            if (field != null)
            {
                var original = (DateTime)GetCellValue(GridCellType.Cell, row);
                if (original.ToString(Format) == field.Text)
                    return original;

                var datePicker = field.InputView as UIDatePicker;
                var newDate = NSDateToDateTime(datePicker.Date);
                if (Mode == GridDateTimeColumnMode.Date)
                {
                    return new DateTime(newDate.Year, newDate.Month, newDate.Day, original.Hour, original.Minute, original.Second);
                }
                else
                {
                    return new DateTime(original.Year, original.Month, original.Day, newDate.Hour, newDate.Minute, newDate.Second);
                }
            }
            return null;
        }

        public static NSDate DateTimeToNSDate(DateTime date)
        {
            DateTime reference = TimeZoneInfo.ConvertTime(new DateTime(2001, 1, 1, 0, 0, 0), TimeZoneInfo.Local);
            return NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
        }

        public static DateTime NSDateToDateTime(NSDate date)
        {
            var calendar = new NSCalendar(NSCalendarType.Gregorian);
            var components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, date);
            return new DateTime((int)components.Year, (int)components.Month, (int)components.Day, (int)components.Hour, (int)components.Minute, (int)components.Second);
        }

    }

    public enum GridDateTimeColumnMode
    {
        Date,
        Time
    }
}

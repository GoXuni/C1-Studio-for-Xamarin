using Android.App;
using Android.Text.Format;
using Android.Widget;
using C1.Android.Grid;
using System;
using System.Reflection;

namespace FlexGrid101
{
    public class GridDateTimeColumn : GridColumn
    {
        public GridDateTimeColumn() : base() { }
        public GridDateTimeColumn(PropertyInfo property) : base(property) { }

        public GridDateTimeColumnMode Mode { get; set; }

        protected override Android.Views.View CreateCellEditor(GridRow row)
        {
            if (DataType == typeof(DateTime))
            {
                var original = (DateTime)GetCellValue(GridCellType.Cell, row);
                var entry = new EditText(Grid.Context);
                entry.Focusable = false; //Avoids keyboard from appearing.
                entry.SetPadding((int)Grid.CellPadding.Left, (int)Grid.CellPadding.Top, (int)Grid.CellPadding.Right, (int)Grid.CellPadding.Bottom);
                entry.SetTextSize(global::Android.Util.ComplexUnitType.Dip, 14);//This matches the default TextView.FontSize
                entry.Text = original.ToString(Format);
                entry.SetBackgroundColor(Grid.EditorBackgroundColor.Value);
                entry.SetTextColor(Grid.EditorTextColor.Value);

                Dialog dialog;
                if (Mode == GridDateTimeColumnMode.Date)
                {
                    dialog = new DatePickerDialog(Grid.Context, new EventHandler<DatePickerDialog.DateSetEventArgs>((s, e) =>
                    {
                        entry.Text = new DateTime(e.Year, e.Month + 1, e.DayOfMonth, original.Hour, original.Minute, original.Second).ToString(Format);
                        Grid.FinishEditing();
                    }), original.Year, original.Month - 1, original.Day);
                }
                else
                {
                    dialog = new TimePickerDialog(Grid.Context, new EventHandler<TimePickerDialog.TimeSetEventArgs>((s, e) =>
                    {
                        entry.Text = new DateTime(original.Year, original.Month, original.Day, e.HourOfDay, e.Minute, 0).ToString(Format);
                        Grid.FinishEditing();
                    }), original.Hour, original.Minute, DateFormat.Is24HourFormat(Grid.Context));
                }
                dialog.CancelEvent += (s, e) =>
                {
                    Grid.FinishEditing();
                };
                dialog.Show();

                return entry;
            }
            else
            {
                return base.CreateCellEditor(row);
            }
        }

        protected override object GetEditorValue(GridRow row, Android.Views.View editor)
        {
            var field = editor as EditText;
            if (field != null)
            {
                var original = (DateTime)GetCellValue(GridCellType.Cell, row);
                if (original.ToString(Format) == field.Text)
                    return original;

                var newDate = DateTime.Parse(field.Text);
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
    }

    public enum GridDateTimeColumnMode
    {
        Date,
        Time
    }
}

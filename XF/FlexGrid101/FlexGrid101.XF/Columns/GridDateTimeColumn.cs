﻿using System;
using System.Reflection;
using C1.Xamarin.Forms.Grid;
using Xamarin.Forms;

namespace FlexGrid101
{
    public class GridDateTimeColumn : GridColumn
    {
        public GridDateTimeColumn() : base() { }
        public GridDateTimeColumn(PropertyInfo property) : base(property) { }

        public GridDateTimeColumnMode Mode { get; set; } = GridDateTimeColumnMode.Date;

        protected override View CreateCellEditor(GridRow row)
        {
            if (DataType == typeof(DateTime))
            {
                var original = (DateTime)GetCellValue(GridCellType.Cell, row);
                if (Mode == GridDateTimeColumnMode.Date)
                {
                    var datePicker = new DatePicker();
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        datePicker.FontSize = 14;//This is performed to match XF.Android Label.
                    }
                    datePicker.BackgroundColor = Grid.EditorBackgroundColor;
                    datePicker.TextColor = Grid.EditorTextColor;
                    datePicker.Date = original;
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        datePicker.Unfocused += (sender, e) =>
                      {
                          Grid.FinishEditing();
                      };
                    }
                    else
                    {
                        datePicker.PropertyChanged += (sender, e) =>
                          {
                              if (e.PropertyName == DatePicker.DateProperty.PropertyName && sender == datePicker)
                              {
                                  Grid.FinishEditing();
                              }
                          };
                    }
                    return datePicker;
                }
                else
                {
                    var timePicker = new TimePicker();
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        timePicker.FontSize = 14;//This is performed to match XF.Android Label.
                    }
                    timePicker.BackgroundColor = Grid.EditorBackgroundColor;
                    timePicker.TextColor = Grid.EditorTextColor;
                    timePicker.Time = original.TimeOfDay;
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        timePicker.Unfocused += (sender, e) =>
                       {
                           Grid.FinishEditing();
                       };
                    }
                    else
                    {
                        timePicker.PropertyChanged += (sender, e) =>
                        {
                            if (e.PropertyName == TimePicker.TimeProperty.PropertyName && sender == timePicker)
                            {
                                Grid.FinishEditing();
                            }
                        };
                    }
                    return timePicker;
                }
            }
            else
            {
                return base.CreateCellEditor(row);
            }
        }

        protected override object GetEditorValue(GridRow row, View editor)
        {
            var original = (DateTime)GetCellValue(GridCellType.Cell, row);
            if (editor is DatePicker)
            {
                var datePicker = editor as DatePicker;
                return new DateTime(datePicker.Date.Year, datePicker.Date.Month, datePicker.Date.Day, original.Hour, original.Minute, original.Second);
            }
            else if (editor is TimePicker)
            {
                var timePicker = editor as TimePicker;
                return new DateTime(original.Year, original.Month, original.Day, timePicker.Time.Hours, timePicker.Time.Minutes, timePicker.Time.Seconds);
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

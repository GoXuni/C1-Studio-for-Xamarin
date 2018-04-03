using System;
using UIKit;
using Foundation;
using CoreGraphics;
using C1.iOS.Chart;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using C1.iOS.Core;

namespace FlexChart101.Controllers
{
    public partial class UpdateAnimationController : UIViewController
    {
        string[] chartTypes = { NSBundle.MainBundle.LocalizedString("Column", "optional"), NSBundle.MainBundle.LocalizedString("Area", "optional"), NSBundle.MainBundle.LocalizedString("Line", "optional"), NSBundle.MainBundle.LocalizedString("LineSymbols", "optional"), NSBundle.MainBundle.LocalizedString("Spline", "optional"), NSBundle.MainBundle.LocalizedString("SplineSymbols", "optional"), NSBundle.MainBundle.LocalizedString("SplineArea", "optional"), NSBundle.MainBundle.LocalizedString("Scatter", "optional") };
        string[] chartAnimation = { NSBundle.MainBundle.LocalizedString("Beginning", "optional"), NSBundle.MainBundle.LocalizedString("Middle", "optional"), NSBundle.MainBundle.LocalizedString("End", "optional") };
        private ObservableCollection<object> data;
        private int index = 0;
        public class ChartTypesModel : UIPickerViewModel
        {
            UpdateAnimationController tk;

            public ChartTypesModel(UpdateAnimationController tk)
            {
                this.tk = tk;
            }

            public override nint GetComponentCount(UIPickerView v)
            {
                return 2;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                if (component == 0)
                    return tk.chartTypes.Length;
                else
                    return tk.chartAnimation.Length;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                if (component == 0)
                    return tk.chartTypes[row];
                else
                    return tk.chartAnimation[row];
            }

            public override void Selected(UIPickerView picker, nint row, nint component)
            {
                if (component == 0)
                {
                    if (row == 0)
                    {
                        tk.chart.ChartType = ChartType.Column;
                    }
                    else if (row == 1)
                    {
                        tk.chart.ChartType = ChartType.Area;
                    }
                    else if (row == 2)
                    {
                        tk.chart.ChartType = ChartType.Line;
                    }
                    else if (row == 3)
                    {
                        tk.chart.ChartType = ChartType.LineSymbols;
                    }
                    else if (row == 4)
                    {
                        tk.chart.ChartType = ChartType.Spline;
                    }
                    else if (row == 5)
                    {
                        tk.chart.ChartType = ChartType.SplineSymbols;
                    }
                    else if (row == 6)
                    {
                        tk.chart.ChartType = ChartType.SplineArea;
                    }
                    else if (row == 7)
                    {
                        tk.chart.ChartType = ChartType.Scatter;
                    }
                }
            }

        }

        public UpdateAnimationController() : base("UpdateAnimationController", null)
        {
        }

        public UpdateAnimationController(IntPtr handle) : base(handle)
        {
        }

        Random rnd = new Random();
        UIButton removeButton = null;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            data = new ObservableCollection<object>();
            for (int i = 0; i < 8; i++)
            {
                data.Add(new MyDataObject { Value = rnd.Next(i, 10 + i * i), XValue = GetRandomLetter() });
            }

            picker.Model = new ChartTypesModel(this);

            chart.BindingX = "XValue";
            chart.Series.Add(new ChartSeries{SeriesName = "Value", Binding = "Value"});
            chart.ItemsSource = data;

            chart.LegendPosition = ChartPositionType.None;
            chart.Palette = Palette.Cocoa;
            chart.AxisY.AxisLine = false;

           // flexChart.AnimationMode = AnimationMode.All;
            chart.AnimationMode = AnimationMode.Point;
            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1500 * 10000);
            updateAnimation.Easing = C1Easing.Linear;
            chart.UpdateAnimation = updateAnimation;

        }

        partial void AddPoint(UIButton sender)
        {
            if (picker.SelectedRowInComponent(1) == 0)
            {
                data.Insert(0, new MyDataObject { Value = rnd.Next(10, 50), XValue = GetRandomLetter() });
            }
            else if (picker.SelectedRowInComponent(1) == 1)
            {
                data.Insert(data.Count / 2, new MyDataObject { Value = rnd.Next(10, 50), XValue = GetRandomLetter() });
            }
            else if (picker.SelectedRowInComponent(1) == 2)
            {
                data.Add(new MyDataObject { Value = rnd.Next(10, 50), XValue = GetRandomLetter() });
            }
            if(data.Count > 1 && removeButton != null)
            {
                removeButton.Enabled = true;
            }
        }

        partial void RemovePoint(UIButton sender)
        {
            if(data.Count > 1)
            {
                if (picker.SelectedRowInComponent(1) == 0)
                {
                    data.RemoveAt(0);
                }
                else if (picker.SelectedRowInComponent(1) == 1)
                {
                    data.RemoveAt(data.Count / 2);
                }
                else if (picker.SelectedRowInComponent(1) == 2)
                {
                    data.RemoveAt(data.Count - 1);
                } 
                if(data.Count <= 1)
                {
                    sender.Enabled = false;
                    removeButton = sender;
                }
            }
        }

        class MyDataObject
        {
            public string XValue { get; set; }
            public double Value { get; set; }
        }

        string GetRandomLetter()
        {
            return Char.ConvertFromUtf32(rnd.Next(65, 90));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


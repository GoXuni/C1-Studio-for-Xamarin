using System;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using System.Collections.Generic;
using C1.iOS.Core;
using C1.CollectionView;
using Foundation;

namespace FlexChart101.Controllers
{
    public partial class PieAnimationController : UIViewController
    {
        string[] animationMode = { NSBundle.MainBundle.LocalizedString("None", ""), NSBundle.MainBundle.LocalizedString("Point", ""), NSBundle.MainBundle.LocalizedString("Series", ""), NSBundle.MainBundle.LocalizedString("All", "") };

        public class ChartTypesModel : UIPickerViewModel
        {
            PieAnimationController tk;

            public ChartTypesModel(PieAnimationController tk)
            {
                this.tk = tk;
            }

            public override nint GetComponentCount(UIPickerView v)
            {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
               return tk.animationMode.Length;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                return tk.animationMode[row];
            }

            public override void Selected(UIPickerView picker, nint row, nint component)
            {
                if (row == 0)
                {
                    tk.flexPie.AnimationMode = AnimationMode.None;
                }
                else if (row == 1)
                {
                    tk.flexPie.AnimationMode = AnimationMode.Point;
                }
                else if (row == 2)
                {
                    tk.flexPie.AnimationMode = AnimationMode.Series;
                }
                else if (row == 3)
                {
                    tk.flexPie.AnimationMode = AnimationMode.All;
                }
             }

        }


        C1CollectionView<MyData> data;
        const string TITLE = "Mobile/Tablet Browser Market Share";

        double[] safari = new double[] { 41.54, 48.35, 57.48, 61.67 };
        double[] chrome = new double[] { 28.51, 17.12, 4.79, 0.76 };
        double[] android_browser = new double[] { 15.8, 21.54, 26.54, 20.61 };
        double[] opera_mini = new double[] { 7.62, 6.65, 8.7, 11.91 };
        double[] internet_explorer = new double[] { 2.36, 5.2, 1.74, 0.81 };
        double[] other = new double[] { 1.68, 2.1, 2.45, 1.83 };

        public PieAnimationController() : base("PieAnimationController", null)
        {
        }

        public PieAnimationController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            picker.Model = new ChartTypesModel(this);
            this.flexPie.ToolTip = null;

            // prepare data source
            List<MyData> list = new List<MyData>();
            list.Add(new MyData { Label = "Safari", Value = safari[0] });
            list.Add(new MyData { Label = "Chrome", Value = chrome[0] });
            list.Add(new MyData { Label = "Android", Value = android_browser[0] });
            list.Add(new MyData { Label = "Opera", Value = opera_mini[0] });
            list.Add(new MyData { Label = "IE", Value = internet_explorer[0] });
            list.Add(new MyData { Label = "Other", Value = other[0] });

            data = new C1CollectionView<MyData>(list);

            // set flexPie properties
            this.flexPie.ItemsSource = data;
            flexPie.BindingName = "Label";
            flexPie.Binding = "Value";
            this.flexPie.Header = TITLE + " 2015";
            this.flexPie.Palette = Palette.Cyborg;
            this.flexPie.SliceBorderWidth = 1;
            this.flexPie.SelectedItemOffset = .1;
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = C1Easing.Linear;
            flexPie.LoadAnimation = loadAnimation;
            flexPie.AnimationMode = AnimationMode.Point;
                   
            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1000 * 10000);
            updateAnimation.Easing = C1Easing.Linear;
            this.flexPie.UpdateAnimation = updateAnimation;

            flexPie.SelectedItemPosition = ChartPositionType.Auto;
            flexPie.SelectedItemPosition = ChartPositionType.Top;

            flexPie.LegendPosition = ChartPositionType.Left;

            this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 7.5, 2.5 };
            flexPie.SelectionMode = ChartSelectionModeType.Point;
                   
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            picker.Select(1, 0, false);
        }

        partial void valueChanged(UIKit.UIStepper sender)
        {
            double value = stepper.Value / 10;
            flexPie.InnerRadius = value;
            innerRadiusLabel.Text = value.ToString();
            innerRadiusLabel.SizeToFit();
        }

        partial void yearChanged(UIKit.UISegmentedControl sender)
        {
            if(sender.SelectedSegment == 0)
            {
                flexPie.BeginUpdate();
                this.flexPie.Header = TITLE + " 2015";
                data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[0] });
                data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[0] });
                data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[0] });
                data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[0] });
                data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[0] });
                data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[0] });
                flexPie.EndUpdate();
            }
            if (sender.SelectedSegment == 1)
            {
                flexPie.BeginUpdate();
                this.flexPie.Header = TITLE + " 2014";
                data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[1] });
                data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[1] });
                data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[1] });
                data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[1] });
                data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[1] });
                data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[1] });
                flexPie.EndUpdate();
            }
            if (sender.SelectedSegment == 2)
            {
                flexPie.BeginUpdate();
                this.flexPie.Header = TITLE + " 2013";
                data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[2] });
                data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[2] });
                data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[2] });
                data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[2] });
                data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[2] });
                data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[2] });
                flexPie.EndUpdate();
            }
            if (sender.SelectedSegment == 3)
            {
                flexPie.BeginUpdate();
                this.flexPie.Header = TITLE + " 2012";
                data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[3] });
                data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[3] });
                data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[3] });
                data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[3] });
                data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[3] });
                data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[3] });
                flexPie.EndUpdate();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    class MyData
    {
        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
            }
        }
        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }

}


using System;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using System.Collections.Generic;
using C1.Xamarin.Forms.Core;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateAnimationSample
    {
        private ObservableCollection<MyDataObject> objects;
        private Random rnd = new Random();

        public UpdateAnimationSample()
        {
            InitializeComponent();
            Title = AppResources.UpdateAnimationTitle;

            // initialize pickers
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.Spline.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineArea.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            this.pickerChartType.SelectedIndex = 0;
            this.pickerChartType.SelectedIndexChanged += pickerChartType_SelectedIndexChanged;
            this.pickerUpdatePosition.Items.Add(UpdatePosition.Beginning.ToString());
            this.pickerUpdatePosition.Items.Add(UpdatePosition.Middle.ToString());
            this.pickerUpdatePosition.Items.Add(UpdatePosition.End.ToString());
            this.pickerUpdatePosition.SelectedIndex = 0;
            btnAdd.Text = AppResources.AddPoint;
            btnRemove.Text = AppResources.RemovePoint;

            if (Device.Idiom != TargetIdiom.Phone)
            {
                ButtonCol.Width = 250;
            }
            else
            {
                btnAdd.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                btnRemove.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            }
            // populate dummy data set using ObservableCollection
            // note: you should use ObservableCollection or anything else that implements INotifyPropertyChanged to see updates in the FlexChart
            objects = new ObservableCollection<MyDataObject>();
            for (int i = 0; i < 8; i++)
            {
                objects.Add(new MyDataObject { Value = rnd.Next(i, 10 + i * i), XValue = GetRandomLetter() });
            }
            this.flexChart.ItemsSource = objects;

            // misc chart properties
            //flexChart.Palette = Palette.Cocoa;
            List<Color> CustomPalette = new List<Color> { Color.FromHex("#f44336"), Color.FromHex("#9c27b0"), Color.FromHex("#3f51b5"), Color.FromHex("#03A9F4"), Color.FromHex("#009688"), Color.FromHex("#8BC34A") };
            flexChart.CustomPalette = CustomPalette;
            flexChart.Palette = Palette.Custom;
            flexChart.AxisY.AxisLine = false;
            flexChart.AxisY.MajorTickMarks = ChartTickMarkType.None;
            flexChart.LegendPosition = ChartPositionType.None;

            flexChart.SelectionStyle = new ChartStyle();
            flexChart.SelectionStyle.Stroke = Color.Red;
            flexChart.SelectionStyle.StrokeThickness = 3;
            flexChart.SelectionStyle.StrokeDashArray = new double[] {2, 1 };

            flexChart.AnimationMode = AnimationMode.All;
            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1000 * 10000);
            updateAnimation.Easing = C1Easing.Linear;
            flexChart.UpdateAnimation = updateAnimation;

            flexChart.AnimationMode = C1.Xamarin.Forms.Chart.AnimationMode.Point;
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            flexChart.LoadAnimation = loadAnimation;
        }

        void OnAddPoint(object sender, EventArgs e)
        {
            if (this.pickerUpdatePosition.SelectedIndex != -1 && this.flexChart != null)
            {
                if (this.pickerUpdatePosition.SelectedIndex == 0)
                {
                    objects.Insert(0, new MyDataObject { Value = rnd.Next(10, 80), XValue = GetRandomLetter() });
                }
                else if (this.pickerUpdatePosition.SelectedIndex == 1)
                {
                    objects.Insert(objects.Count / 2, new MyDataObject { Value = rnd.Next(10, 80), XValue = GetRandomLetter() });
                }
                else
                {
                    objects.Add(new MyDataObject { Value = rnd.Next(10, 80), XValue = GetRandomLetter() });
                }
                if(objects.Count > 1)
                {
                    btnRemove.IsEnabled = true;
                }
            }
        }
        void OnRemovePoint(object sender, EventArgs e)
        {
            if(objects.Count > 1)
            {
                if (this.pickerUpdatePosition.SelectedIndex != -1 && this.flexChart != null)
                {
                    if (this.pickerUpdatePosition.SelectedIndex == 0)
                    {
                        objects.RemoveAt(0);
                    }
                    else if (this.pickerUpdatePosition.SelectedIndex == 1)
                    {
                        objects.RemoveAt(objects.Count / 2);
                    }
                    else
                    {
                        objects.RemoveAt(objects.Count - 1);
                    }
                }
                if (objects.Count <= 1)
                {
                    btnRemove.IsEnabled = false;
                }
            }
        }
        
        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pickerChartType.SelectedIndex != -1 && this.flexChart != null)
            {
                this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
            }
            
        }

        string GetRandomLetter()
        {
            return Char.ConvertFromUtf32(rnd.Next(65, 90));
        }

    }

    class MyDataObject
    {
        public string XValue { get; set; }
        public double Value { get; set; }
    }
    enum UpdatePosition
    {
        Beginning,
        Middle,
        End
    }
}

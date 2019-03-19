using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using C1.Xamarin.Forms.Core;
using C1.CollectionView;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PieAnimationSample
    {
        C1CollectionView<MyData> data;
        const string TITLE = "Mobile Browser Market Share";

        double[] safari = new double[] { 41.54, 48.35, 57.48, 61.67 };
        double[] chrome = new double[] { 28.51, 17.12, 4.79, 0.76 };
        double[] android_browser = new double[] { 15.8, 21.54, 26.54, 20.61 };
        double[] opera_mini = new double[] { 7.62, 6.65, 8.7, 11.91 };
        double[] internet_explorer = new double[] { 2.36, 5.2, 1.74, 0.81 };
        double[] other = new double[] { 1.68, 2.1, 2.45, 1.83 };

        public PieAnimationSample()
        {
            InitializeComponent();
            Title = AppResources.LoadAnimationTitle;

            this.lblInnerRadius.Text = AppResources.InnerRadius;
            this.lblAnimationMode.Text = AppResources.AnimationMode;
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
            this.flexPie.Header = TITLE + " 2015";
            //this.flexPie.Palette = Palette.Cyborg;
            List<Color> CustomPalette = new List<Color> { Color.FromHex("#f44336"), Color.FromHex("#9c27b0"), Color.FromHex("#3f51b5"), Color.FromHex("#03A9F4"), Color.FromHex("#009688"), Color.FromHex("#8BC34A") };
            this.flexPie.Palette = Palette.Custom;
            this.flexPie.CustomPalette = CustomPalette;
            this.flexPie.SliceBorderWidth = 1;
            
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            flexPie.LoadAnimation = loadAnimation;

            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1000 * 5000);
            updateAnimation.Easing = C1Easing.Linear;
            this.flexPie.UpdateAnimation = updateAnimation;

            flexPie.SelectedItemPosition = ChartPositionType.Auto;
            flexPie.SelectedItemPosition = ChartPositionType.Top;

            flexPie.LegendPosition = ChartPositionType.Left;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 15, 5 };
                    break;
                case Device.UWP:
                    this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 15, 5 };
                    break;
                case Device.iOS:
                    this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 7.5, 2.5 };
                    break;
            }

            this.pickerAnimationMode.SelectedIndexChanged += pickerAnimationMode_SelectedIndexChanged;
            foreach (var item in Enum.GetNames(typeof(AnimationMode)))
            {
                this.pickerAnimationMode.Items.Add(item);
            }
            this.pickerAnimationMode.SelectedIndex = 1;

            root.SizeChanged += root_SizeChanged;

        }

        async void btnUpdate2015_Clicked(object sender, EventArgs e)
        {
            flexPie.BeginUpdate();
            this.flexPie.Header = TITLE + " 2015";
            await data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[0] });
            await data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[0] });
            await data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[0] });
            await data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[0] });
            await data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[0] });
            await data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[0] });
            btnUpdate2015.BackgroundColor = Color.FromHex("#2196F3");
            btnUpdate2014.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2013.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2012.BackgroundColor = Color.FromHex("#64B5F6");
            flexPie.EndUpdate();

        }
        async void btnUpdate2014_Clicked(object sender, EventArgs e)
        {
            flexPie.BeginUpdate();
            this.flexPie.Header = TITLE + " 2014";
            await data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[1] });
            await data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[1] });
            await data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[1] });
            await data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[1] });
            await data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[1] });
            await data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[1] });
            btnUpdate2015.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2014.BackgroundColor = Color.FromHex("#2196F3");
            btnUpdate2013.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2012.BackgroundColor = Color.FromHex("#64B5F6");
            flexPie.EndUpdate();
        }
        async void btnUpdate2013_Clicked(object sender, EventArgs e)
        {
            flexPie.BeginUpdate();
            this.flexPie.Header = TITLE + " 2013";
            await data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[2] });
            await data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[2] });
            await data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[2] });
            await data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[2] });
            await data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[2] });
            await data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[2] });
            btnUpdate2015.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2014.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2013.BackgroundColor = Color.FromHex("#2196F3");
            btnUpdate2012.BackgroundColor = Color.FromHex("#64B5F6");
            flexPie.EndUpdate();
        }
        async void btnUpdate2012_Clicked(object sender, EventArgs e)
        {
            flexPie.BeginUpdate();
            this.flexPie.Header = TITLE + " 2012";
            await data.ReplaceAsync(0, new MyData { Label = "Safari", Value = safari[3] });
            await data.ReplaceAsync(1, new MyData { Label = "Chrome", Value = chrome[3] });
            await data.ReplaceAsync(2, new MyData { Label = "Android", Value = android_browser[3] });
            await data.ReplaceAsync(3, new MyData { Label = "Opera", Value = opera_mini[3] });
            await data.ReplaceAsync(4, new MyData { Label = "IE", Value = internet_explorer[3] });
            await data.ReplaceAsync(5, new MyData { Label = "Other", Value = other[3] });
            btnUpdate2015.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2014.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2013.BackgroundColor = Color.FromHex("#64B5F6");
            btnUpdate2012.BackgroundColor = Color.FromHex("#2196F3");
            flexPie.EndUpdate();

        }

        void root_SizeChanged(object sender, EventArgs e)
        {
            if (root.Width > root.Height)
            {
                stackOptions.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                stackOptions.Orientation = StackOrientation.Vertical;
            }
        }
        void pickerAnimationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.pickerAnimationMode.Items[this.pickerAnimationMode.SelectedIndex];
            this.flexPie.AnimationMode = (AnimationMode)(Enum.Parse(typeof(AnimationMode), type));
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

using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using System.Collections.Generic;
using C1.Xamarin.Forms.Core;

namespace FlexChart101
{
    public partial class FinancialChart
    {
        public FinancialChart()
        {
            InitializeComponent();
            Title = AppResources.FinancialChartTitle;
            List<Color> CustomPalette = new List<Color> {Color.FromHex("#3F51B5") };
            
            this.flexChart.CustomPalette = CustomPalette;
            this.flexChart.Palette = Palette.Custom;
            this.flexChart.ItemsSource = ChartSampleFactory.FinancialData();
            this.flexChart.ChartType = ChartType.Candlestick;
            this.flexChart.LegendPosition = ChartPositionType.None;
            this.flexChart.AxisY.MajorGridStyle.Fill = Color.FromRgba(50, 50, 50, 20);
            this.flexChart.AxisX.Format = "MM/dd/yyyy";
            this.flexChart.AxisY.AxisLine = false;
            this.pickerChartType.Items.Add(ChartType.Candlestick.ToString());
            this.pickerChartType.Items.Add(ChartType.HighLowOpenClose.ToString());
            this.pickerChartType.SelectedIndex = 0;

            this.flexChart.AnimationMode = C1.Xamarin.Forms.Chart.AnimationMode.Point;
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            this.flexChart.LoadAnimation = loadAnimation;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }
    }
}

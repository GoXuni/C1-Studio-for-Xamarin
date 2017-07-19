using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class FinancialChart
    {
        public FinancialChart()
        {
            InitializeComponent();
            Title = AppResources.FinancialChartTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.FinancialData();
            this.flexChart.ChartType = ChartType.Candlestick;
            this.flexChart.LegendPosition = ChartPositionType.None;
            this.flexChart.AxisY.MajorGridStyle.Fill = Color.FromRgba(50, 50, 50, 20);
            this.flexChart.AxisX.Format = "MM/dd/yyyy";
            this.pickerChartType.Items.Add(ChartType.Candlestick.ToString());
            this.pickerChartType.Items.Add(ChartType.HighLowOpenClose.ToString());
            this.pickerChartType.SelectedIndex = 0;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }
    }
}

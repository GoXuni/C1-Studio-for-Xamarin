using System;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class SelectionModesSample
    {
        public SelectionModesSample()
        {
            InitializeComponent();
            Title = AppResources.SelectionModesTitle;
            this.lblChartType.Text = AppResources.ChartType;
            this.lblSelectionMode.Text = AppResources.SelectionMode;
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            //Device.OnPlatform(Android: () =>
            //    this.flexChart.SelectedDashes = new double[] { 15, 5 }
            //    );

            //Device.OnPlatform(WinPhone: () =>
            //   this.flexChart.SelectedDashes = new double[] { 3, 1 }
            //    );

            //Device.OnPlatform(iOS: () =>
            //    this.flexChart.SelectedDashes = new double[] { 7.5, 2.5 }
            //    );
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Bar.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            foreach (var item in Enum.GetNames(typeof(ChartSelectionModeType)))
            {
                this.pickerSelectionMode.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 0;
            this.pickerSelectionMode.SelectedIndex = 1;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }

        void pickerSelectionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.SelectionMode = (ChartSelectionModeType)Enum.Parse(typeof(ChartSelectionModeType), this.pickerSelectionMode.Items[this.pickerSelectionMode.SelectedIndex]);
        }
    }
}

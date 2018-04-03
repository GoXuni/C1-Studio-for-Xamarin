using System;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using System.Collections.Generic;
using C1.CollectionView;
using C1.Xamarin.Forms.Core;
using Xamarin.Forms;

namespace FlexChart101
{
    public partial class LoadAnimationSample
    {
        public LoadAnimationSample()
        {
            InitializeComponent();
            Title = AppResources.LoadAnimationTitle;
            this.lblChartType.Text = AppResources.ChartType;
            this.lblStacking.Text = AppResources.Stacking;
            this.lblRotated.Text = AppResources.Rotated;
            

            foreach (var item in ChartSampleFactory.GetAllChartTypes())
            {
                this.pickerChartType.Items.Add(item.ToString());
            }
            foreach (var item in Enum.GetNames(typeof(ChartStackingType)))
            {
                this.pickerStackType.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(AnimationMode)))
            {
                this.pickerAnimationMode.Items.Add(item);
            }
            
            this.pickerChartType.SelectedIndex = 0;
            this.pickerStackType.SelectedIndex = 0;
            this.pickerAnimationMode.SelectedIndex = 3;

            flexChart.AnimationMode = C1.Xamarin.Forms.Chart.AnimationMode.All;
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1500 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            flexChart.LoadAnimation = loadAnimation;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
            if (flexChart.ChartType == ChartType.Bubble)
            {
                PrepareBubbleChart();
            }
            else if (flexChart.ChartType == ChartType.Candlestick || flexChart.ChartType == ChartType.HighLowOpenClose)
            {
                PrepareFinancialChart();
            }
            else
            {
                PrepareBasicChart();
            }
            
        }

        void pickerStackType_SelectedIndexChanged(object sender, EventArgs e)
        {
             ChartStackingType stacking = (ChartStackingType)Enum.Parse(typeof(ChartStackingType), this.pickerStackType.Items[this.pickerStackType.SelectedIndex]);
             this.flexChart.Stacking = stacking;
        }
        void pickerAnimationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimationMode mode = (AnimationMode)Enum.Parse(typeof(AnimationMode), this.pickerAnimationMode.Items[this.pickerAnimationMode.SelectedIndex]);
            this.flexChart.AnimationMode = mode;
        }

        private void PrepareBasicChart()
        {
            ChartSeries sales = new ChartSeries();
            sales.SeriesName = "Sales";
            sales.Binding = "Sales";
            ChartSeries expensses = new ChartSeries();
            expensses.SeriesName = "Expenses";
            expensses.Binding = "Expenses";
            ChartSeries downloads = new ChartSeries();
            downloads.SeriesName = "Downloads";
            downloads.Binding = "Downloads";
            
            flexChart.Series.Clear();
            flexChart.Series.Add(sales);
            flexChart.Series.Add(expensses);
            flexChart.Series.Add(downloads);

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
        private void PrepareBubbleChart()
        {
            ChartSeries sales = new ChartSeries();
            sales.SeriesName = "Sales";
            sales.Binding = "Sales,Downloads";
            ChartSeries expensses = new ChartSeries();
            expensses.SeriesName = "Expenses";
            expensses.Binding = "Expenses,Downloads";
            
            flexChart.Series.Clear();
            flexChart.Series.Add(sales);
            flexChart.Series.Add(expensses);

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }

        private void PrepareFinancialChart()
        {
            this.flexChart.BindingX = "Date";
            this.flexChart.LegendPosition = ChartPositionType.None;
            this.flexChart.AxisY.MajorGridStyle.Fill = Color.FromRgba(50, 50, 50, 20);
            this.flexChart.AxisX.Format = "MM/dd/yyyy";

            ChartSeries series = new ChartSeries();
            series.SeriesName = "Sales";
            series.Binding = "High,Low,Open,Close";

            flexChart.Series.Clear();
            flexChart.Series.Add(series);

            this.flexChart.ItemsSource = ChartSampleFactory.FinancialData();
        }
            
    }
}

using System;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using C1.Xamarin.Forms.Core;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart.Interaction;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadAnimationSample
    {
        public LoadAnimationSample()
        {
            InitializeComponent();
            Title = AppResources.LoadAnimationTitle;
            lblChartType.Text = AppResources.ChartType;
            lblStacking.Text = AppResources.Stacking;
            lblRotated.Text = AppResources.Rotated;


            foreach (var item in ChartSampleFactory.GetAllChartTypes())
            {
                pickerChartType.Items.Add(item.ToString());
            }
            foreach (var item in Enum.GetNames(typeof(ChartStackingType)))
            {
                pickerStackType.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(AnimationMode)))
            {
                pickerAnimationMode.Items.Add(item);
            }
            ZoomBehavior z = new ZoomBehavior();
            z.ZoomMode = GestureMode.X;
            flexChart.Behaviors.Add(z);

            TranslateBehavior t = new TranslateBehavior();
            flexChart.Behaviors.Add(t);
            pickerChartType.SelectedIndex = 0;
            pickerStackType.SelectedIndex = 0;
            pickerAnimationMode.SelectedIndex = 3;

            flexChart.AnimationMode = C1.Xamarin.Forms.Chart.AnimationMode.All;
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1500 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            flexChart.LoadAnimation = loadAnimation;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), pickerChartType.Items[pickerChartType.SelectedIndex]);
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
            ChartStackingType stacking = (ChartStackingType)Enum.Parse(typeof(ChartStackingType), pickerStackType.Items[pickerStackType.SelectedIndex]);
            flexChart.Stacking = stacking;
        }
        void pickerAnimationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimationMode mode = (AnimationMode)Enum.Parse(typeof(AnimationMode), pickerAnimationMode.Items[pickerAnimationMode.SelectedIndex]);
            flexChart.AnimationMode = mode;
        }

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (flexChart.Rotated)
            {
                if (flexChart.ChartType == ChartType.Candlestick || flexChart.ChartType == ChartType.HighLowOpenClose)
                {
                    flexChart.AxisY.Format = "MM/dd/yyyy";
                }
                flexChart.AxisX.Format = "0";
            }
            else
            {
                if (flexChart.ChartType == ChartType.Candlestick || flexChart.ChartType == ChartType.HighLowOpenClose)
                {
                    flexChart.AxisY.Format = "0";
                    flexChart.AxisX.Format = "MM/dd/yyyy";
                }
            }
        }

        private void PrepareBasicChart()
        {
            flexChart.BindingX = "Name";
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

            flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
        private void PrepareBubbleChart()
        {
            flexChart.BindingX = "Name";
            ChartSeries sales = new ChartSeries();
            sales.SeriesName = "Sales";
            sales.Binding = "Sales,Downloads";
            ChartSeries expensses = new ChartSeries();
            expensses.SeriesName = "Expenses";
            expensses.Binding = "Expenses,Downloads";

            flexChart.Series.Clear();
            flexChart.Series.Add(sales);
            flexChart.Series.Add(expensses);

            flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }

        private void PrepareFinancialChart()
        {
            flexChart.BindingX = "Date";
            flexChart.LegendPosition = ChartPositionType.None;
            flexChart.AxisY.MajorGridStyle.Fill = Color.FromRgba(50, 50, 50, 20);
            flexChart.AxisX.Format = "MM/dd/yyyy";

            ChartSeries series = new ChartSeries();
            series.SeriesName = "Sales";
            series.Binding = "High,Low,Open,Close";

            flexChart.Series.Clear();
            flexChart.Series.Add(series);

            flexChart.ItemsSource = ChartSampleFactory.FinancialData();
        }

    }
}

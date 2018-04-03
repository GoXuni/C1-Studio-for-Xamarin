using SimpleDashboard.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using C1.Xamarin.Forms.Gauge;

namespace SimpleDashboard
{
    public partial class PhoneDash : ContentPage
    {
        private DataSource ds;
        public PhoneDash()
        {
            InitializeComponent();
            this.Title = AppResources.SalesDashboardTitle;
            ds = new DataSource();
            this.chart.BindingContext = ds;
            this.pie.BindingContext = ds;

            this.chart.AxisY.AxisLine = false;
            double[] dashes = new double[] { 3, 1};

            Device.OnPlatform(Android: () =>
                dashes = new double[] { 21, 7 }
            );

            Device.OnPlatform(WinPhone: () =>
               dashes = new double[] { 3, 1 }
                );

            Device.OnPlatform(iOS: () =>
                dashes = new double[] { 7.5, 2.5 }
                );

            this.pie.SelectionStyle.StrokeDashArray = null;
            this.chart.SelectionStyle.StrokeDashArray = null;
            this.pie.SelectionStyle.StrokeThickness = 2;
            this.chart.SelectionStyle.StrokeThickness = 2;
            this.chart.SelectionMode = ChartSelectionModeType.Series;
            this.chart.SelectionChanged += chart_SelectionChanged;
            this.pie.SelectionChanged += pie_SelectionChanged;
            this.pie.SelectionMode = ChartSelectionModeType.Point;
            this.chart.AxisY.MajorGridStyle.StrokeThickness = 0;
            this.SizeChanged += PhoneDash_SizeChanged;
            this.graph3.IsReadOnly = true;

        }

        void pie_SelectionChanged(object sender, EventArgs e)
        {
            if (pie.SelectedIndex != -1) 
            {
                //this.graph3.SetBinding(Xuni.Forms.Gauge.XuniBulletGraph.ValueProperty, new Binding("DownloadsGoal"));
                Quarter selectedQuarter = ds.Data[pie.SelectedIndex];

                if (pie.Binding.Equals("Downloads"))
                {
                    System.Diagnostics.Debug.WriteLine ("DL");
                    this.graph3.Value = selectedQuarter.DownloadsGoal;
                    this.label1.Text = selectedQuarter.Name + " Downloads Goal";
                }
                else if (pie.Binding.Equals("Sales"))
                {
                    this.graph3.Value = selectedQuarter.SalesGoal;
                    this.label1.Text = selectedQuarter.Name + " Sales Goal";
                }
                else if (pie.Binding.Equals("Expenses"))
                {
                    this.graph3.Value = selectedQuarter.ExpensesGoal;
                    this.label1.Text = selectedQuarter.Name + " Expenses Goal";
                }
            }
        }

        void PhoneDash_SizeChanged(object sender, EventArgs e)
        {
            gridLayout.RowDefinitions.Clear();
            gridLayout.ColumnDefinitions.Clear();
            if(this.Width > this.Height)
            {
                gridLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                gridLayout.RowDefinitions.Add(new RowDefinition());
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = 50 });
                Grid.SetColumn(chart, 0);
                Grid.SetRow(chart, 0);
                Grid.SetRowSpan(chart, 2);
                Grid.SetColumn(pie, 1);
                Grid.SetRow(pie, 0);
                Grid.SetRowSpan(pie, 2);
                Grid.SetColumn(graph3, 2);
                Grid.SetRow(graph3, 1);
                Grid.SetColumn(label1, 2);
                Grid.SetRow(label1, 0);
                chart.LegendPosition = ChartPositionType.Bottom;
                graph3.Direction = LinearGaugeDirection.Up;

            }
            else
            {
                gridLayout.RowDefinitions.Add(new RowDefinition());
                gridLayout.RowDefinitions.Add(new RowDefinition());
                gridLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                gridLayout.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
                Grid.SetColumn(chart, 0);
                Grid.SetRow(chart, 0);
                Grid.SetRowSpan(chart, 1);
                Grid.SetColumn(pie, 0);
                Grid.SetRow(pie, 1);
                Grid.SetRowSpan(pie, 1);
                Grid.SetColumn(pie, 0);
                Grid.SetRow(label1, 2);
                Grid.SetColumn(label1, 0);
                Grid.SetRow(graph3, 3);
                Grid.SetColumn(graph3, 0);
                chart.LegendPosition = ChartPositionType.Right;
                graph3.Direction = LinearGaugeDirection.Right;
            }
        }


        void chart_SelectionChanged(object sender, EventArgs e)
        {
            if (chart.SelectedSeries != null)
            {
                this.pie.Binding = chart.SelectedSeries.SeriesName;
                this.pie.Header = chart.SelectedSeries.SeriesName;
            }
        }
    }
}

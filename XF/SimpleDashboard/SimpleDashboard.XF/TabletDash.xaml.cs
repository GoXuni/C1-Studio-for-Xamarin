using SimpleDashboard.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;

namespace SimpleDashboard
{
    public partial class TabletDash : ContentPage
    {
        public TabletDash()
        {
            InitializeComponent();
            this.Title =AppResources.SalesDashboardTitle;
            DataSource ds = new DataSource();
            this.chart.BindingContext = ds;
            this.pie.BindingContext = ds;

            this.chart.AxisY.AxisLine = false;

            double[] dashes = new double[] { 3, 1 };

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
            this.chart.AxisY.MajorGridStyle.StrokeThickness = 0;
            this.graph.IsReadOnly = true;
            this.graph2.IsReadOnly = true;
            this.graph3.IsReadOnly = true;
            List<Color> CustomPalette = new List<Color> { Color.FromHex("#f44336"), Color.FromHex("#9c27b0"), Color.FromHex("#3f51b5"), Color.FromHex("#03a9fa"), Color.FromHex("#009688"), Color.FromHex("#8bc34a"), Color.FromHex("#ff3b3b") };
            chart.Palette = Palette.Custom;
            chart.CustomPalette = CustomPalette;
            pie.Palette = Palette.Custom;
            pie.CustomPalette = CustomPalette;
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

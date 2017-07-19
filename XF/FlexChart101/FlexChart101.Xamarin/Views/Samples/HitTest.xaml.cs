using FlexChart101.Resources;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlexChart101
{
    public partial class HitTest
    {
        public HitTest()
        {
            InitializeComponent();
            this.lblChartElement.Text = AppResources.ChartElement;
            this.lblSeriesName.Text = AppResources.Series;
            this.lblPointIdx.Text = AppResources.PointIndex;
            Title = AppResources.HitTestTitle;

            int len = 40;
            List<Point> listCosTuple = new List<Point>();
            List<Point> listSinTuple = new List<Point>();

            for (int i = 0; i < len; i++)
            {
                listCosTuple.Add(new Point(i, Math.Cos(0.12 * i)));
                listSinTuple.Add(new Point(i, Math.Sin(0.12 * i)));
            }

            this.flexChart.AxisY.Format = "n2";

            this.seriesCosX.ItemsSource = listCosTuple;
            this.seriesSinX.ItemsSource = listSinTuple;
        }

        void flexChart_Tapped(object sender, C1.Xamarin.Forms.Core.C1TappedEventArgs e)
        {
            var hitTest = this.flexChart.HitTest(e.HitPoint);

            this.stackHitTest.BindingContext = hitTest;
            this.stackData.BindingContext = hitTest;

            this.stackSeries.IsVisible = hitTest != null && hitTest.Series != null;
            this.stackData.IsVisible = hitTest != null && hitTest.PointIndex != -1;
        }
    }
}

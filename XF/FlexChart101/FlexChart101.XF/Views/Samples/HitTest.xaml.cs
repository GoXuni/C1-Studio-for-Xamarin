using FlexChart101.Resources;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HitTest
    {
        public HitTest()
        {
            InitializeComponent();
            lblChartElement.Text = AppResources.ChartElement;
            lblSeriesName.Text = AppResources.Series;
            lblPointIdx.Text = AppResources.PointIndex;
            Title = AppResources.HitTestTitle;

            int len = 40;
            var listCosTuple = new List<Point>();
            var listSinTuple = new List<Point>();

            for (int i = 0; i < len; i++)
            {
                listCosTuple.Add(new Point(i, Math.Cos(0.12 * i)));
                listSinTuple.Add(new Point(i, Math.Sin(0.12 * i)));
            }

            flexChart.AxisY.Format = "n2";

            seriesCosX.ItemsSource = listCosTuple;
            seriesSinX.ItemsSource = listSinTuple;
        }

        void flexChart_Tapped(object sender, C1.Xamarin.Forms.Core.C1TappedEventArgs e)
        {
            var hitTest = flexChart.HitTest(e.GetPosition(sender as View));

            stackHitTest.BindingContext = hitTest;
            stackData.BindingContext = hitTest;

            stackSeries.IsVisible = hitTest != null && hitTest.Series != null;
            stackData.IsVisible = hitTest != null && hitTest.PointIndex != -1;
            var type = e.PointerDeviceType;
        }
    }
}

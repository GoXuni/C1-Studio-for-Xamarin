using FlexChart101.Resources;
using System;
using Xamarin.Forms;

namespace FlexChart101
{
    public partial class PieGettingStartedSample
    {
        public PieGettingStartedSample()
        {
            InitializeComponent();
            Title = AppResources.PieGettingStartedTitle;
            this.pieChart.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.donutChart.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.root.SizeChanged += root_SizeChanged;
        }

        void root_SizeChanged(object sender, EventArgs e)
        {
            if (root.Width > root.Height)
            {
                Grid.SetColumn(pieChart, 0);
                Grid.SetRow(pieChart, 0);
                Grid.SetRowSpan(pieChart, 2);
                Grid.SetColumnSpan(pieChart, 1);

                Grid.SetRow(donutChart, 0);
                Grid.SetColumn(donutChart, 1);
                Grid.SetRowSpan(donutChart, 2);
                Grid.SetColumnSpan(donutChart, 1);
            }
            else
            {
                Grid.SetRow(pieChart, 0);
                Grid.SetColumn(pieChart, 0);
                Grid.SetColumnSpan(pieChart, 2);
                Grid.SetRowSpan(pieChart, 1);

                Grid.SetRow(donutChart, 1);
                Grid.SetColumn(donutChart, 0);
                Grid.SetColumnSpan(donutChart, 2);
                Grid.SetRowSpan(donutChart, 1);
            }
        }
    }
}

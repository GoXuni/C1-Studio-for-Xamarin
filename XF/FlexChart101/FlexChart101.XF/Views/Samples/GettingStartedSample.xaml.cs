using FlexChart101.Resources;
using C1.Xamarin.Forms.Core;
using System;

namespace FlexChart101
{
    public partial class GettingStartedSample
    {
        public GettingStartedSample()
        {
            InitializeComponent();

            Title = AppResources.GettingStartedTitle;
            flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            
        }
    }
}

using FlexChart101.Resources;
using C1.Xamarin.Forms.Core;
using System;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

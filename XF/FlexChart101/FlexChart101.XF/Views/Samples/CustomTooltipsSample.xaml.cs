using FlexChart101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using C1.Xamarin.Forms.Core;

namespace FlexChart101
{
    public partial class CustomTooltipsSample : ContentPage
    {
        public CustomTooltipsSample()
        {
            InitializeComponent();

			Title = AppResources.CustomTooltipsTitle;

			this.chart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.chart.Palette = Palette.Zen;
			//this.chart.AxisY.MajorUnit = 2000;
			this.chart.LegendPosition = ChartPositionType.Bottom;
			this.chart.Stacking = ChartStackingType.Stacked;
			chart.Palette = Palette.Cocoa;
            Device.OnPlatform(Android: ()=> { image.WidthRequest = 35; image.HeightRequest = 21; label1.FontSize = 17; label2.FontSize = 17; } );
            Device.OnPlatform(iOS: () => { image.WidthRequest = 20; image.HeightRequest = 15; });
        }
    }
}

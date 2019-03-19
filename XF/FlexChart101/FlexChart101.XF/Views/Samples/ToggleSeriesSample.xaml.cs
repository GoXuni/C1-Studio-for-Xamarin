using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToggleSeriesSample
    {
        public ToggleSeriesSample()
        {
            InitializeComponent();
            Title = AppResources.ToggleSeriesTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.Palette = Palette.Darkly;
            this.flexChart.AxisX.Format = "M/dd";
        }
    }
    public class SeriesVisibilityBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartSeriesVisibilityType visible = (ChartSeriesVisibilityType)value;
            return visible != ChartSeriesVisibilityType.Hidden && visible != ChartSeriesVisibilityType.Legend;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? ChartSeriesVisibilityType.Visible : ChartSeriesVisibilityType.Hidden;
        }
    }

}

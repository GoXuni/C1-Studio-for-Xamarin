using FlexChart101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using System.Globalization;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomizingAxesSample : ContentPage
    {
        FlagConverter flagConverter = new FlagConverter();

        public CustomizingAxesSample()
        {
            InitializeComponent();

			Title = AppResources.CustomizingAxesTitle;

			this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.LegendPosition = ChartPositionType.Top;

            this.flexChart.AxisX.LabelLoading += (object sender, AxisLabelLoadingEventArgs e) =>
           {
               Image img = new Image();
               ImageSource src = this.flagConverter.Convert(e.LabelString, typeof(ImageSource), null, CultureInfo.CurrentUICulture) as ImageSource;
               img.Source = src;
               e.Label = img;
               Device.OnPlatform(Android: () => { img.WidthRequest = 35; img.HeightRequest = 20; });
           };
            this.flexChart.AxisY.LabelLoading += (object sender, AxisLabelLoadingEventArgs e) =>
            {
                Label label = new Label();
                label.YAlign = TextAlignment.Center;
                label.XAlign = TextAlignment.End;

                if (e.Value > 4000)
                {
                    label.TextColor = Color.Green;
                }
                else if (e.Value <= 4000)
                {
                    label.TextColor = Color.Red;
                }
                label.Text = string.Format("${0}K", e.Value / 1000);
                label.FontSize = 12;
                e.Label = label;
            };
        }
    }
	
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1Weather.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C1Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
            Title = AppResources.About;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Device.OpenUri(new Uri("https://www.openweathermap.org"));
            };
            weatherLabel.GestureRecognizers.Add(tapGestureRecognizer);
            aboutLabel.Text = AppResources.AboutLabelText;
            weatherLabel.Text = AppResources.WeatherLabelTest;
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    if (Device.Idiom == TargetIdiom.Desktop)
                    {
                        aboutLabel.FontSize = 18;
                        weatherLabel.FontSize = 18;
                    }
                    else
                    {
                        aboutLabel.FontSize = 10;
                        weatherLabel.FontSize = 10;
                    }
                    break;
            }
        }
    }
}
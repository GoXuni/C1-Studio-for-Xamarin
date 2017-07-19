using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using System.Globalization;

namespace FlexChart101
{
    public class Utility
    {
        public static void CheckNavBar(ContentPage page)
        {
            //remove navgiation bar on android
            Device.OnPlatform(Android: () => NavigationPage.SetHasNavigationBar(page, false));
        }
    }

    public class FlagConverter : IValueConverter
    {
        private static ImageSource us = ImageSource.FromResource("FlexChart101.Images.US.png", typeof(App));
        private static ImageSource germany = ImageSource.FromResource("FlexChart101.Images.Germany.png", typeof(App));
        private static ImageSource uk = ImageSource.FromResource("FlexChart101.Images.UK.png", typeof(App));
        private static ImageSource japan = ImageSource.FromResource("FlexChart101.Images.Japan.png", typeof(App));
        private static ImageSource italy = ImageSource.FromResource("FlexChart101.Images.Italy.png", typeof(App));
        private static ImageSource greece = ImageSource.FromResource("FlexChart101.Images.Greece.png", typeof(App));
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                String flag = value.ToString().ToUpper();

                switch (flag)
                {
                    case "US":
                        return us;

                    case "UK":
                        return uk;

                    case "GERMANY":
                        return germany;

                    case "JAPAN":
                        return japan;

                    case "ITALY":
                        return italy;

                    case "GREECE":
                        return greece;

                }
            }

            return us;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return us;
        }
    }

    public class PreciseStepper : Stepper
    {
        public PreciseStepper()
        {
            this.ValueChanged += PreciseStepper_ValueChanged;
        }


        public PreciseStepper(double min, double max, double val, double increment)
            : base(min, max, val, increment)
        {
            this.ValueChanged += PreciseStepper_ValueChanged;
        }
        void PreciseStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (Math.Abs(this.Value - 0) < 0.000000000001)
                this.Value = 0;
        }
    }
}

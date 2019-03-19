using C1Calendar101.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Calendar;
using Xamarin.Forms.Xaml;

namespace C1Calendar101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDayContent
    {
        private List<ImageSource> _icons = new List<ImageSource>();
        private Random _rand = new Random();
        private Dictionary<DateTime, ImageSource> WeatherForecast = new Dictionary<DateTime, ImageSource>();

        public CustomDayContent()
        {
            InitializeComponent();
            Title = AppResources.CustomDayContentTitle;

            _icons.Add(ImageSource.FromResource("C1Calendar101.Images.partly-cloudy-day-icon.png"));
            _icons.Add(ImageSource.FromResource("C1Calendar101.Images.Sunny-icon.png"));
            _icons.Add(ImageSource.FromResource("C1Calendar101.Images.rain-icon.png"));
            _icons.Add(ImageSource.FromResource("C1Calendar101.Images.snow-icon.png"));
            _icons.Add(ImageSource.FromResource("C1Calendar101.Images.thunder-lightning-storm-icon.png"));
            _icons.Add(ImageSource.FromResource("C1Calendar101.Images.Overcast-icon.png"));

            for (int i = 0; i < 10; i++)
            {
                WeatherForecast[DateTime.Today.AddDays(i)] = GetRandomIcon();
            }
        }

        public void OnDaySlotLoading(object sender, CalendarDaySlotLoadingEventArgs e)
        {
            if (!e.IsAdjacentDay)
            {
                if (WeatherForecast.ContainsKey(e.Date))
                {
                    var daySlotWithImage = new CalendarImageDaySlot(e.Date);
                    daySlotWithImage.DayText = e.Date.Day + "";
                    daySlotWithImage.DayFontSize = 8;
                    //daySlotWithImage.ImageAspect = Aspect.Fill;
                    //daySlotWithImage.ImageSource = UriImageSource.FromUri(WeatherForecast[e.Date]);
                    daySlotWithImage.ImageSource = WeatherForecast[e.Date];
                    e.DaySlot = daySlotWithImage;

                }
                else
                {
                    e.DaySlot.BindingContext = new MyDataContext(e.Date);
                }
            }
            else
            {
                e.DaySlot.BindingContext = new MyDataContext(e.Date);
            }
        }

        public void OnDayOfWeekSlotLoading(object sender, CalendarDayOfWeekSlotLoadingEventArgs e)
        {
            if (!e.IsWeekend)
            {
                (e.DayOfWeekSlot as Label).FontAttributes = FontAttributes.Bold;
                (e.DayOfWeekSlot as Label).FontSize = 8;
            }
            else
            {
                (e.DayOfWeekSlot as Label).FontAttributes = FontAttributes.Italic;
                (e.DayOfWeekSlot as Label).FontSize = 8;
            }
        }

        private ImageSource GetRandomIcon()
        {
            return _icons[_rand.Next(0, _icons.Count - 1)];
        }
    }

    public class MyDataContext
    {
        private static Random _rand = new Random();
        public MyDataContext(DateTime date)
        {
            Day = date.Day;
            RedDotVisible = Day % 3 == 0;
            GreenDotVisible = Day % 3 == 1;
            BlueDotVisible = Day % 3 == 2;
        }

        public int Day { get; set; }
        public bool RedDotVisible { get; set; }
        public bool GreenDotVisible { get; set; }
        public bool BlueDotVisible { get; set; }
    }
}

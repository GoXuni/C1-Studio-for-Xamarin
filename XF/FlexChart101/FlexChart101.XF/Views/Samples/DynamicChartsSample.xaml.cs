using System;
using System.Collections.Generic;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using System.Threading;
using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicChartsSample
    {
        internal Random random = new Random();
        List<DummyObject> list = new List<DummyObject>();
        private CancellationTokenSource cancellation;

        public DynamicChartsSample()
        {
            InitializeComponent();
            Title = AppResources.DynamicChartTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            for (int i = 0; i < 60; i++)
            {
                list.Add(getItem());
            }
            this.flexChart.ItemsSource = list;
            this.flexChart.Palette = Palette.Coral;
            this.flexChart.AxisX.MajorUnit = 20;
            this.cancellation = new CancellationTokenSource();
        }

        public void CancelTimer()
        {
            Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
        }

        public void StartTimer()
        {
            // This solution is from https://forums.xamarin.com/discussion/49492/how-can-i-stop-device-starttimer
            CancellationTokenSource cts = this.cancellation; // safe copy
            Device.StartTimer(TimeSpan.FromSeconds(Device.OnPlatform(0.1, .1, 0.1)), () =>
            {
                if (cts.IsCancellationRequested) return false;
                if (list.Count > 60)
                    list.RemoveAt(0);
                list.Add(getItem());
                flexChart.ItemsSource = list.ToArray();
                return true;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartTimer();
        }

        protected override bool OnBackButtonPressed()
        {
            CancelTimer();
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            CancelTimer();
            base.OnDisappearing();
        }

        public DummyObject getItem()
        {
            double nextDouble = random.Next(0, 1000);

            while (nextDouble < 900)
            {
                nextDouble = random.Next(0, 1000);
            }

            double trucks = nextDouble + 20;
            double ships = nextDouble + 10;
            double planes = nextDouble;

            DateTime now = DateTime.Now;

            return new DummyObject(now, now.ToString("mm:ss"), trucks, ships, planes);
        }

        public class DummyObject
        {
            public String Name { get; set; }

            public DateTime Time { get; set; }

            public double Trucks { get; set; }

            public double Ships { get; set; }

            public double Planes { get; set; }

            public DummyObject(DateTime time, String name, double trucks, double ships, double planes)
            {
                this.Time = time;
                this.Name = name;
                this.Trucks = trucks;
                this.Ships = ships;
                this.Planes = planes;
            }

        }
    }
}

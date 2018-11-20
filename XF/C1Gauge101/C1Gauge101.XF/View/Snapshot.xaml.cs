using C1Gauge101.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Core;
using C1.Xamarin.Forms.Gauge;
using System.Threading;

namespace C1Gauge101
{
    public partial class Snapshot : ContentPage
    {
        private Random _rand = new Random();
        private uint _stepDuration = 4000;

        private CancellationTokenSource cancellation;

        public Snapshot()
        {
            InitializeComponent();
            Title = AppResources.ExportImageTitle;

            BindingContext = new SampleViewModel() { Value = 25, ShowText = GaugeShowText.All };
            snapshotFrameBorder.IsVisible = false;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                snapshotFrameBorder.IsVisible = false;
            };
            snapshotFrame.GestureRecognizers.Add(tapGestureRecognizer);
            gauge.UpdateAnimation.Duration = TimeSpan.FromMilliseconds(_stepDuration);
            this.Take.Text = AppResources.Take;
            this.Save.Text = AppResources.Save;

            this.cancellation = new CancellationTokenSource();
        }

        async void OnSnapshotClicked(object sender, EventArgs e)
        {
            gauge.IsAnimated = false;
            var image = await gauge.GetImage();
            snapshot.Source = ImageSource.FromStream(() => new MemoryStream(image));
            await Task.Delay(100);
            snapshotFrameBorder.BackgroundColor = C1ThemeInfo.ApplicationTheme.TextColor;
            snapshotFrame.BackgroundColor = C1ThemeInfo.ApplicationTheme.BackgroundColor;
            snapshotFrameBorder.IsVisible = true;
            gauge.IsAnimated = true;
        }

        async void OnSaveSnapshotClicked(object sender, EventArgs e)
        {
            //uses the IPicture interface to use the appropriate saving mechanism from the picture class in each individual project
            var originalBackground = gauge.BackgroundColor;
            gauge.BackgroundColor = C1ThemeInfo.ApplicationTheme.BackgroundColor;
            gauge.IsAnimated = false;
            DependencyService.Get<IPicture>().SavePictureToDisk("Gauge", gauge.GetImage());
            
            //generic success message
            await DisplayAlert(AppResources.ImageSavedTitle,
              AppResources.ImageSavedDescription,
              AppResources.OKTitle);
            gauge.BackgroundColor = originalBackground;
            gauge.IsAnimated = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // This solution is from https://forums.xamarin.com/discussion/49492/how-can-i-stop-device-starttimer
            CancellationTokenSource cts = this.cancellation; // safe copy

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (cts.IsCancellationRequested) return false;

                var viewModel = BindingContext as SampleViewModel;
                double nextValue = _rand.Next((int)viewModel.Min, (int)viewModel.Max);
                gauge.Value = nextValue;
                return true;
            });
        }

        protected override bool OnBackButtonPressed()
        {
            Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();

            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
            base.OnDisappearing();

        }
    }
}

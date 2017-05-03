using C1Gauge101.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Gauge;

namespace C1Gauge101
{
    public partial class AutomaticScaling : ContentPage
    {
        private Random _rand = new Random();
        private uint _stepDuration = 4000;
        CancellationTokenSource ts;

        public AutomaticScaling()
        {
            InitializeComponent();
            Title = AppResources.AutomaticScalingTitle;
            this.lblStartAngle.Text = AppResources.StartAngle;
            this.lblSweepAngle.Text = AppResources.SweepAngle;
            BindingContext = new SampleViewModel() { Max = 200, Value = 60, ShowText = GaugeShowText.All };

            StartAngleStepper.ValueChanged += OnStartAngleChanged;
            SweepAngleStepper.ValueChanged += OnSweepAngleChanged;
            StartAngleLabel.Text = StartAngleStepper.Value.ToString("N0");
            SweepAngleLabel.Text = SweepAngleStepper.Value.ToString("N0");
            Gauge.UpdateAnimation.Duration = TimeSpan.FromMilliseconds(_stepDuration - 500);

            ts = new CancellationTokenSource();
        }

        void OnStartAngleChanged(object sender, ValueChangedEventArgs e)
        {
            StartAngleLabel.Text = e.NewValue.ToString("N0");
        }

        void OnSweepAngleChanged(object sender, ValueChangedEventArgs e)
        {
            SweepAngleLabel.Text = e.NewValue.ToString("N0");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await AnimateNextStep();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ts.Cancel();
        }

        private async Task AnimateNextStep()
        {
            var viewModel = BindingContext as SampleViewModel;
            
            try
            {
                await Task.Delay(TimeSpan.FromMilliseconds(_stepDuration), ts.Token);
            }
            catch (TaskCanceledException)
            {
                return;
            }

            double nextValue = _rand.Next((int)viewModel.Min, (int)viewModel.Max);
            viewModel.Value = nextValue;

            await AnimateNextStep();
        }

    }
}

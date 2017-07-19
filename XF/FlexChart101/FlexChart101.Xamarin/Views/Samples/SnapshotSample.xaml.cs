using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Core;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class SnapshotSample
    {
        public SnapshotSample()
        {
            InitializeComponent();
            Title = AppResources.ExportImageTitle;

            snapshotFrame.Opacity = 0;
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                snapshotFrame.Opacity = 1;
            };
            snapshotFrame.GestureRecognizers.Add(tapGestureRecognizer);
            this.SavePicture.Text = AppResources.TakeSnapshot;
        }
        async void OnSnapshotClicked(object sender, EventArgs e)
        {
            //uses the IPicture interface to use the appropriate saving mechanism from the picture class in each individual project
            var originalBackground = flexChart.BackgroundColor;
            if (originalBackground == null || originalBackground.A == 0 || originalBackground.A == -1)
            {
                flexChart.BackgroundColor = ColorEx.ThemeBackgroundColor;
            }
            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", flexChart.GetImage());

            //generic success message
            await DisplayAlert(AppResources.ImageSavedTitle,
               AppResources.ImageSavedDescription,
               AppResources.OKTitle);
            flexChart.BackgroundColor = originalBackground;
        }

    }
}

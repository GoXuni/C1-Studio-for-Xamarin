using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PieBasicFeaturesSample
    {

        public PieBasicFeaturesSample()
        {
            InitializeComponent();
            Title = AppResources.PieBasicFeaturesTitle;
            this.lblOffset.Text = AppResources.Offset;
            this.lblReversed.Text = AppResources.Reversed;
            this.lblStartAngle.Text = AppResources.StartAngle;
            this.lblRadius.Text = AppResources.InnerRadius;

            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.flexPie.Palette = Palette.Midnight;
            this.flexPie.SelectionChanged += FlexPie_SelectionChanged;
        }

        void FlexPie_SelectionChanged(object sender, EventArgs e)
        {
            this.flexPie.Header = "SelectedIndex " + flexPie.SelectedIndex;
            System.Diagnostics.Debug.WriteLine("SelectedIndex: " + flexPie.SelectedIndex);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                Grid.SetColumn(gridOption, 0);
                Grid.SetRow(gridOption, 0);
                Grid.SetRowSpan(gridOption, 2);

                Grid.SetRow(flexPie, 0);
                Grid.SetColumn(flexPie, 1);
                Grid.SetRowSpan(flexPie, 2);
            }
            else
            {
                Grid.SetRow(gridOption, 0);
                Grid.SetColumn(gridOption, 0);
                Grid.SetColumnSpan(gridOption, 2);

                Grid.SetRow(flexPie, 1);
                Grid.SetColumn(flexPie, 0);
                Grid.SetColumnSpan(flexPie, 2);
            }
        }

    }
}

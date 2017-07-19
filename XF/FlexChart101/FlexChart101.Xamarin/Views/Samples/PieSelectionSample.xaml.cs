using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class PieSelectionSample
    {
        public PieSelectionSample()
        {
            InitializeComponent();
            Title = AppResources.PieSelectionTitle;

            this.lblSelectedOffset.Text = AppResources.SelectedItemOffset;
            this.lblSelectedPos.Text = AppResources.SelectedItemPosition;
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.flexPie.Palette = Palette.Superhero;
            this.flexPie.ToolTip = null;

            Device.OnPlatform(Android: () =>
                this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 15, 5 }
                );

            Device.OnPlatform(WinPhone: () =>
               this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 3, 1 }
                );

            Device.OnPlatform(iOS: () =>
                this.flexPie.SelectionStyle.StrokeDashArray = new double[] { 7.5, 2.5 }
                );

            this.pickerPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;
            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerPosition.Items.Add(item);
            }
            this.pickerPosition.SelectedIndex = 3;

            root.SizeChanged += root_SizeChanged;

        }

        void root_SizeChanged(object sender, EventArgs e)
        {
            if (root.Width > root.Height)
            {
                stackOptions.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                stackOptions.Orientation = StackOrientation.Vertical;
            }
        }
        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.pickerPosition.Items[this.pickerPosition.SelectedIndex];
            this.flexPie.SelectedItemPosition = (ChartPositionType)(Enum.Parse(typeof(ChartPositionType), type));
        }
    }
}

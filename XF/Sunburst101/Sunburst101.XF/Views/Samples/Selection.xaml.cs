using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using Sunburst101.Resources;

namespace Sunburst101
{
    public partial class Selection
    {
        public Selection()
        {
            InitializeComponent();
            Title = AppResources.SelectionTitle;

            this.lblSelectedOffset.Text = AppResources.SelectedItemOffset;
            this.lblSelectedPos.Text = AppResources.SelectedItemPosition;
            this.sunburst.ItemsSource = new SunburstViewModel().FlatData;
            this.sunburst.Palette = Palette.Superhero;
            this.sunburst.ToolTip = null;

            Device.OnPlatform(Android: () =>
                this.sunburst.SelectionStyle.StrokeDashArray = new double[] { 15, 5 }
                );

            Device.OnPlatform(WinPhone: () =>
               this.sunburst.SelectionStyle.StrokeDashArray = new double[] { 3, 1 }
                );

            Device.OnPlatform(iOS: () =>
                this.sunburst.SelectionStyle.StrokeDashArray = new double[] { 7.5, 2.5 }
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
            this.sunburst.SelectedItemPosition = (ChartPositionType)(Enum.Parse(typeof(ChartPositionType), type));
        }
    }
}

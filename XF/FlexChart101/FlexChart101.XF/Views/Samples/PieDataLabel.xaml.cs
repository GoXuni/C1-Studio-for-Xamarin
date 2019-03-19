using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PieDataLabel
    {
        public PieDataLabel()
        {
            InitializeComponent();
            Title = AppResources.PieDataLabelsTitle;
            this.lblPos.Text = AppResources.LabelPosition;
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.flexPie.Palette = Palette.Organic;
            this.flexPie.DataLabel.Content = "{y}";
            this.flexPie.DataLabel.Border = true;
            this.flexPie.DataLabel.BorderStyle = new ChartStyle { Stroke = Color.Red, StrokeThickness = 2 };
            this.flexPie.DataLabel.Style = new ChartStyle { Stroke = Color.Gray, FontSize = 20 };

            foreach (var item in Enum.GetNames(typeof(PieLabelPosition)))
            {
                this.pickPostion.Items.Add(item);
            }
            this.pickPostion.SelectedIndex = 2;
        }

        void pickPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexPie.DataLabel.Position = (PieLabelPosition)Enum.Parse(typeof(PieLabelPosition), this.pickPostion.Items[this.pickPostion.SelectedIndex]);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                this.flexPie.LegendPosition = ChartPositionType.Right;
            }
            else
            {
                this.flexPie.LegendPosition = ChartPositionType.Bottom;
            }
        }
    }
}

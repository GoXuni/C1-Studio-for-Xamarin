using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataLabelSample
    {
        public DataLabelSample()
        {
            InitializeComponent();
            Title = AppResources.DataLabelsTitle;

            this.lblPos.Text = AppResources.LabelPosition;
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList2();
            this.flexChart.Palette = Palette.Organic;
            this.flexChart.DataLabel.Content = "{x} {y}";
            this.flexChart.DataLabel.BorderStyle = new ChartStyle { Stroke = Color.Blue, StrokeThickness = 1 };
            this.flexChart.DataLabel.Style = new ChartStyle { Stroke = Color.Red, FontSize = 20 };

            foreach (var item in Enum.GetNames(typeof(ChartLabelPosition)))
            {
                this.pickPostion.Items.Add(item);
            }
            this.pickPostion.SelectedIndex = 1;
        }

        void pickPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.DataLabel.Position = (ChartLabelPosition)Enum.Parse(typeof(ChartLabelPosition), this.pickPostion.Items[this.pickPostion.SelectedIndex]);
        }
    }
}

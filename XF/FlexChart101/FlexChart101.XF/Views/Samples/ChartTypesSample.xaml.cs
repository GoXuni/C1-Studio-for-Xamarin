using System;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class ChartTypesSample
    {
        public ChartTypesSample()
        {
            InitializeComponent();
            Title = AppResources.BasicChartTypesTitle;
            this.lblChartType.Text = AppResources.ChartType;
            this.lblStacking.Text = AppResources.Stacking;
            this.lblRotated.Text = AppResources.Rotated;
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            foreach (var item in ChartSampleFactory.GetBasicChartTypes())
            {
                this.pickerChartType.Items.Add(item.ToString());
            }
            foreach (var item in Enum.GetNames(typeof(ChartStackingType)))
            {
                this.pickerStackType.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 0;
            this.pickerStackType.SelectedIndex = 1;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }

        void pickerStackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartStackingType stacking=(ChartStackingType)Enum.Parse(typeof(ChartStackingType), this.pickerStackType.Items[this.pickerStackType.SelectedIndex]);
            this.flexChart.Stacking = stacking;
        }      
    }
}

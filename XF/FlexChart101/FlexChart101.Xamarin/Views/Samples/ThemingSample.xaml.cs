using System;
using System.Collections.Generic;
using System.Reflection;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class ThemingSample
    {
        List<Palette> listPalettes;

        public ThemingSample()
        {
            InitializeComponent();
            Title = AppResources.ThemingTitle;
            this.lblTheming.Text = AppResources.Therming;
            this.listPalettes = new List<Palette>();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            foreach (var field in typeof(Palette).GetRuntimeFields())
            {
                if (field.FieldType == typeof(Palette))
                {
                    listPalettes.Add((Palette)field.GetValue(null));
                    picker.Items.Add(field.Name);
                }
            }
            picker.SelectedIndex = 0;
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.Palette = this.listPalettes[this.picker.SelectedIndex];
        }
    }
}

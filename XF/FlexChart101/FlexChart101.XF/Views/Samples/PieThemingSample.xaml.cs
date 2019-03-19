using System;
using System.Collections.Generic;
using C1.Xamarin.Forms.Chart;
using System.Reflection;
using FlexChart101.Resources;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PieThemingSample
    {
        List<Palette> listPalettes;

        public PieThemingSample()

        {
            InitializeComponent();
            Title = AppResources.PieThemingTitle;
            this.lblTheming.Text = AppResources.Therming;
            this.listPalettes = new List<Palette>();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();

            foreach (var field in typeof(Palette).GetRuntimeFields())
            {
                if (field.FieldType == typeof(Palette))
                {
                    listPalettes.Add((Palette)field.GetValue(null));
                    this.pickerTheming.Items.Add(field.Name);
                }
            }

            this.pickerTheming.SelectedIndex = 0;
            this.pickerTheming.SelectedIndexChanged += pickerThemeing_SelectedIndexChanged;
        }

        void pickerThemeing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexPie.Palette = this.listPalettes[this.pickerTheming.SelectedIndex];
        }
    }
}

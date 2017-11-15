﻿using FlexChart101.Resources;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlexChart101
{
    public partial class FlexChartSamples 
    {
        public FlexChartSamples()
        {
            InitializeComponent();
            Title = "FlexChart101";
            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail="chart_column.png"},
                new Sample() { Name = AppResources.BasicChartTypesTitle, Description = AppResources.BasicChartTypesDescription, SampleViewType = 2 , Thumbnail="chart_area.png"},
                new Sample() { Name = AppResources.MixedChartTypesTitle, Description = AppResources.MixedChartTypesDescription, SampleViewType = 3 , Thumbnail="chart_composite.png"},
                new Sample() { Name = AppResources.FinancialChartTitle, Description = AppResources.FinancialChartDescription, SampleViewType = 4 , Thumbnail="chart_finance.png"},
                new Sample() { Name = AppResources.BubbleChartTitle, Description = AppResources.BubbleChartDescription, SampleViewType = 5 , Thumbnail="chart_bubble.png"},
                new Sample() { Name = AppResources.DataLabelsTitle, Description = AppResources.DataLabelsDescription, SampleViewType = 6 , Thumbnail="chart_tooltip.png"},
                new Sample() { Name = AppResources.AnnotationTitle, Description = AppResources.AnnotationDescription, SampleViewType = 0, Thumbnail="chart_annotation.png"},
                new Sample() { Name = AppResources.MultipleAxesTitle, Description = AppResources.MultipleAxesDescription, SampleViewType = 7 , Thumbnail="chart_multiaxes.png"},
                new Sample() { Name = AppResources.LegendSampleTitle, Description = AppResources.LegendSampleDescription, SampleViewType = 8 , Thumbnail="chart_title.png"},
                new Sample() { Name = AppResources.SelectionModesTitle, Description = AppResources.SelectionModesDescription, SampleViewType = 9, Thumbnail="chart_selection.png"},
                new Sample() { Name = AppResources.ToggleSeriesTitle, Description = AppResources.ToggleSeriesDescription, SampleViewType = 10, Thumbnail="chart_column.png"},
                new Sample() { Name = AppResources.DynamicChartTitle, Description = AppResources.DynamicChartDescription, SampleViewType = 11, Thumbnail="chart_dynamic.png"},
                new Sample() { Name = AppResources.HitTestTitle, Description = AppResources.HitTestDescription, SampleViewType = 12, Thumbnail="chart_selection.png"},
                new Sample() { Name = AppResources.ThemingTitle, Description = AppResources.ThemingDescription, SampleViewType = 13, Thumbnail="themes.png"},
                new Sample() { Name = AppResources.StylingSeriesTitle, Description = AppResources.StylingSeriesDescription, SampleViewType = 14, Thumbnail="chart_composite.png"},
                new Sample() { Name = AppResources.ExportImageTitle, Description = AppResources.ExportImageDescription, SampleViewType = 15, Thumbnail="export_image.png"},
                new Sample() { Name = AppResources.ZonesTitle, Description = AppResources.ZonesDescription, SampleViewType = 16, Thumbnail="chart_scatter.png"},
                new Sample() { Name = AppResources.CustomPlotElementsTitle, Description = AppResources.CustomPlotElementsDescription, SampleViewType = 17, Thumbnail="custom.png"},
                new Sample() { Name = AppResources.CustomizingAxesTitle, Description = AppResources.CustomizingAxesDescription, SampleViewType = 18 , Thumbnail="chart_axes.png"},
                new Sample() { Name = AppResources.CustomTooltipsTitle, Description = AppResources.CustomTooltipsDescription, SampleViewType = 19 , Thumbnail="chart_tooltip.png"},
                new Sample() { Name = AppResources.LineMarkerTitle, Description = AppResources.LineMarkerDescription, SampleViewType = 20, Thumbnail="chart_linemarker.png"},
                new Sample() { Name = AppResources.ZoomingScrollingTitle, Description = AppResources.ZoomingScrollingDescription, SampleViewType = 21, Thumbnail="chart_scatter.png"},
                //new Sample() { Name = AppResources.ScrollingTitle, Description = AppResources.ScrollingDescription, SampleViewType = 22, Thumbnail="chart_scrolling.png"},
                
                new Sample() { Name = AppResources.PieGettingStartedTitle, Description = AppResources.PieGettingStartedDescription, SampleViewType = 22, Thumbnail="pie.png"},
                new Sample() { Name = AppResources.PieBasicFeaturesTitle, Description = AppResources.PieBasicFeaturesDescription, SampleViewType = 23, Thumbnail="pie_doughnut.png"},
                new Sample() { Name = AppResources.PieLegendSampleTitle, Description = AppResources.PieLegendSampleDescription, SampleViewType = 24, Thumbnail="pie_title.png"},
                new Sample() { Name = AppResources.PieSelectionTitle, Description = AppResources.PieSelectionDescription, SampleViewType = 25, Thumbnail="pie_selection.png"},
                new Sample() { Name = AppResources.PieDataLabelsTitle, Description = AppResources.PieDataLabelsDescription, SampleViewType = 26, Thumbnail="pie_labels.png"},
                new Sample() { Name = AppResources.PieThemingTitle, Description = AppResources.PieThemingDescription, SampleViewType = 27, Thumbnail="themes.png"},

            };
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                listView.IsEnabled = false;
                var sample = e.Item as Sample;
                await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
            }
            finally
            {
                listView.IsEnabled = true;
            }
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 0: return new AnnotationSample();
                case 1: return new GettingStartedSample();
                case 2: return new ChartTypesSample();
                case 3: return new MixedChartTypesSample();
                case 4: return new FinancialChart();
                case 5: return new BubbleChartSample();
                case 6: return new DataLabelSample();
                case 7: return new MultipleAxesSamples();
                case 8: return new TitleAndLegendSample();
                case 9: return new SelectionModesSample();
                case 10: return new ToggleSeriesSample();
                case 11: return new DynamicChartsSample();
                case 12: return new HitTest();
                case 13: return new ThemingSample();
                case 14: return new StylingSeriesSample();
                case 15: return new SnapshotSample();
                case 16: return new ZonesSample();
                case 17: return new CustomPlotElements();
                case 18: return new CustomizingAxesSample();
                case 19: return new CustomTooltipsSample();
                case 20: return new LineMarkerSample();
                case 21: return new ZoomingAndScrolling();
                //case 22: return new ScrollingSample();
                case 22: return new PieGettingStartedSample();
                case 23: return new PieBasicFeaturesSample();
                case 24: return new PieLegendAndTitlesSample();
                case 25: return new PieSelectionSample();
                case 26: return new PieDataLabel();
                case 27: return new PieThemingSample();
            }
            return null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}

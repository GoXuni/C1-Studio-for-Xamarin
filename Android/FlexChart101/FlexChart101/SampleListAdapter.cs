using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FlexChart101
{
	class SampleListAdapter : BaseAdapter
	{
		public List<SampleModel> list;
		private LayoutInflater mInflater;

		public SampleListAdapter(Context context)
		{
			list = new List<SampleModel>();
			this.mInflater = LayoutInflater.From(context);
			// initializing SampleModel objects for each sample
			SampleModel gettingStarted = new SampleModel(context.Resources.GetString(Resource.String.gettingStarted), context.Resources.GetString(
					Resource.String.gettingStartedDesc), Resource.Drawable.chart_column, typeof(GettingStartedActivity));
			SampleModel basicChartTypes = new SampleModel(context.Resources.GetString(Resource.String.basicChartTypes), context.Resources.GetString(
						  Resource.String.basicChartTypesDesc), Resource.Drawable.chart_area, typeof(BasicChartTypesActivity));
			SampleModel mixedChartTypes = new SampleModel(context.Resources.GetString(Resource.String.mixedChartTypes), context.Resources.GetString(
						  Resource.String.mixedChartTypesDesc), Resource.Drawable.chart_composite, typeof(MixedChartTypesActivity));
			SampleModel financialChart = new SampleModel(context.Resources.GetString(Resource.String.financialChart), context.Resources.GetString(
						  Resource.String.financialChartDesc), Resource.Drawable.chart_finance, typeof(FinancialChartTypesActivity));
			SampleModel bubbleChart = new SampleModel(context.Resources.GetString(Resource.String.bubbleChart), context.Resources.GetString(
						  Resource.String.bubbleChartDesc), Resource.Drawable.chart_bubble, typeof(BubbleChartActivity));
			SampleModel customTooltips = new SampleModel(context.Resources.GetString(Resource.String.customTooltips), context.Resources.GetString(
						  Resource.String.customTooltipsDesc), Resource.Drawable.chart_tooltip, typeof(CustomTooltipsActivity));
			SampleModel dataLabels = new SampleModel(context.Resources.GetString(Resource.String.dataLabels), context.Resources.GetString(
						  Resource.String.dataLabelsDesc), Resource.Drawable.chart_tooltip, typeof(DataLabelsActivity));
			SampleModel theming = new SampleModel(context.Resources.GetString(Resource.String.theming), context.Resources.GetString(Resource.String.themingDesc),
						  Resource.Drawable.themes, typeof(ThemingActivity));
			SampleModel stylingSeries = new SampleModel(context.Resources.GetString(Resource.String.stylingSeries), context.Resources.GetString(
						 Resource.String.stylingSeriesDesc), Resource.Drawable.chart_composite, typeof(StylingSeriesActivity));
			SampleModel legendAndTitles = new SampleModel(context.Resources.GetString(Resource.String.legendAndTitles), context.Resources.GetString(
						  Resource.String.legendAndTitlesDesc), Resource.Drawable.chart_aggregate, typeof(LegendAndTitlesActivity));
			SampleModel selectionModes = new SampleModel(context.Resources.GetString(Resource.String.selectionModes), context.Resources.GetString(
						  Resource.String.selectionModesDesc), Resource.Drawable.chart_selection, typeof(SelectionModesActivity));
			SampleModel toggleSeries = new SampleModel(context.Resources.GetString(Resource.String.toggleSeries), context.Resources.GetString(
						  Resource.String.toggleSeriesDesc), Resource.Drawable.chart_column, typeof(ToggleSeriesActivity));
			SampleModel loadAnimation = new SampleModel(context.Resources.GetString(Resource.String.animationOptions), context.Resources.GetString(
			              Resource.String.animationOptionsDesc), Resource.Drawable.chart_animation, typeof(LoadAnimationActivity));
			SampleModel updateAnimation = new SampleModel(context.Resources.GetString(Resource.String.updateAnimation), context.Resources.GetString(
			              Resource.String.updateAnimationDesc), Resource.Drawable.chart_animation, typeof(UpdateAnimationActivity));
			//SampleModel conditionalFormatting = new SampleModel(context.Resources.GetString(Resource.String.conditionalFormatting), context.Resources.GetString(
			//              Resource.String.conditionalFormattingDesc), Resource.Drawable.chart_format, typeof(ConditionalFormattingActivity));
			SampleModel dynamicCharts = new SampleModel(context.Resources.GetString(Resource.String.dynamicCharts), context.Resources.GetString(
						  Resource.String.dynamicChartsDesc), Resource.Drawable.chart_dynamic, typeof(DynamicChartsActivity));
			//SampleModel scrolling = new SampleModel(context.Resources.GetString(Resource.String.scrolling), context.Resources.GetString(Resource.String.scrollingDesc),
			              //Resource.Drawable.chart_scatter, typeof(ScrollingActivity));
			SampleModel zoomingAndScrolling = new SampleModel(context.Resources.GetString(Resource.String.zoomingAndScrolling), context.Resources.GetString(
			              Resource.String.zoomingAndScrollingDesc), Resource.Drawable.chart_scatter, typeof(ZoomingAndScrollingActivity));
			SampleModel hitTest = new SampleModel(context.Resources.GetString(Resource.String.hitTest), context.Resources.GetString(Resource.String.hitTestDesc),
						  Resource.Drawable.chart_line, typeof(HitTestActivity));
            SampleModel histogram = new SampleModel(context.Resources.GetString(Resource.String.histogram), context.Resources.GetString(Resource.String.histogramDesc),
                          Resource.Drawable.histogram, typeof(HistogramActivity));
            SampleModel multipleAxes = new SampleModel(context.Resources.GetString(Resource.String.multipleAxes), context.Resources.GetString(
						  Resource.String.multipleAxesDesc), Resource.Drawable.chart_composite, typeof(MultipleAxesActivity));
			SampleModel customPlotElements = new SampleModel(context.Resources.GetString(Resource.String.customPlotElements), context.Resources.GetString(
						  Resource.String.customPlotElementsDesc), Resource.Drawable.custom, typeof(CustomPlotElementsActivity));
			SampleModel snapshotActivity = new SampleModel(context.Resources.GetString(Resource.String.snapshot), context.Resources.GetString(
						  Resource.String.snapshotDesc), Resource.Drawable.chart_column, typeof(SnapshotActivity));
			SampleModel customMarkerActivity = new SampleModel(context.Resources.GetString(Resource.String.customMarker), context.Resources.GetString(
			              Resource.String.customMarkerDesc), Resource.Drawable.chart_marker, typeof(CustomMarkerActivity));
			SampleModel customizingAxesLabelActivity = new SampleModel(context.Resources.GetString(Resource.String.customizingAxesLabel), context.Resources
						  .GetString(Resource.String.customizingAxesLabelDesc), Resource.Drawable.chart_axes, typeof(CustomizingAxesLabelActivity));
			//SampleModel logActivity = new SampleModel(context.Resources.GetString(Resource.String.scaling), context.Resources
			//              .GetString(Resource.String.scalingDesc), Resource.Drawable.chart_axes, typeof(LogarithmicActivity));
			SampleModel annotation = new SampleModel(context.Resources.GetString(Resource.String.annotation), context.Resources.GetString(
			              Resource.String.annotationDesc), Resource.Drawable.chart_annotation, typeof(AnnotationActivity));
			SampleModel zones = new SampleModel(context.Resources.GetString(Resource.String.zones), context.Resources.GetString(
						  Resource.String.zonesDesc), Resource.Drawable.chart_scatter, typeof(ZonesActivity));

			// FlexPie samples
			SampleModel flexpieGettingStarted = new SampleModel(context.Resources.GetString(Resource.String.getting_started), context.Resources.GetString(
				Resource.String.getting_started_desc), Resource.Drawable.pie, typeof(Pie.GettingStartedActivity));
			SampleModel flexpieBasicFeatures = new SampleModel(context.Resources.GetString(Resource.String.basic_features), context.Resources.GetString(
					Resource.String.basic_features_desc), Resource.Drawable.pie_doughnut, typeof(Pie.BasicFeaturesActivity));
			SampleModel flexpieLegendAndTitles = new SampleModel(context.Resources.GetString(Resource.String.legend_and_titles), context.Resources.GetString(
					Resource.String.legend_and_titles_desc), Resource.Drawable.pie_title, typeof(Pie.LegendAndTitlesActivity));
			SampleModel flexpieSelection = new SampleModel(context.Resources.GetString(Resource.String.selection),
					context.Resources.GetString(Resource.String.selection_desc), Resource.Drawable.pie_selection, typeof(Pie.SelectionActivity));
			SampleModel flexpieTheming = new SampleModel(context.Resources.GetString(Resource.String.pietheming), context.Resources.GetString(Resource.String.theming_desc_desc),
					Resource.Drawable.themes, typeof(Pie.ThemingActivity));
			SampleModel flexpieDataLabels = new SampleModel(context.Resources.GetString(Resource.String.data_labels), context.Resources.GetString(
					Resource.String.data_labels_desc), Resource.Drawable.pie_selection, typeof(Pie.DataLabelsActivity));
            SampleModel flexpieAnimation = new SampleModel(context.Resources.GetString(Resource.String.animationOptions),
                    context.Resources.GetString(Resource.String.animationOptionsDesc), Resource.Drawable.pie_selection, typeof(Pie.AnimationActivity));


            // adding objects to list
            list.Add(gettingStarted);
			list.Add(basicChartTypes);
			list.Add(mixedChartTypes);
			list.Add(financialChart);
			list.Add(bubbleChart);
			list.Add(customTooltips);
			list.Add(dataLabels);
			list.Add(annotation);
			list.Add(customMarkerActivity);
			list.Add(customizingAxesLabelActivity);
			list.Add(multipleAxes);
			list.Add(legendAndTitles);
			//list.Add(conditionalFormatting);
			list.Add(customPlotElements);
			list.Add(selectionModes);
			list.Add(toggleSeries);
            list.Add(dynamicCharts);
			list.Add(hitTest);
            list.Add(histogram);
            //list.Add(scrolling);
            list.Add(zoomingAndScrolling);
			list.Add(theming);
			list.Add(stylingSeries);
			////list.Add(logActivity);
			list.Add(snapshotActivity);
			list.Add(zones);
            list.Add(loadAnimation);
            list.Add(updateAnimation);

            // FlexPie samples
            list.Add(flexpieGettingStarted);
			list.Add(flexpieBasicFeatures);
			list.Add(flexpieLegendAndTitles);
			list.Add(flexpieSelection);
			list.Add(flexpieTheming);
			list.Add(flexpieDataLabels);
            list.Add(flexpieAnimation);
            

        }


		public override int Count
		{
			get { return list.Count; }
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return (Java.Lang.Object)list[position];
		}



		public override long GetItemId(int position)
		{
			return list.ElementAt(position).getThumbnailResourceId();
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			if (convertView == null)
			{
				convertView = this.mInflater.Inflate(Resource.Layout.activity_custom_list, parent, false);
			}

			SampleModel sample = list.ElementAt(position);

			// creating custom view for each list element
			((ImageView)convertView.FindViewById(Resource.Id.sampleImage)).SetImageResource(sample.getThumbnailResourceId());
			((TextView)convertView.FindViewById(Resource.Id.sampleName)).SetText(sample.getName(), TextView.BufferType.Normal);
			((TextView)convertView.FindViewById(Resource.Id.sampleDesc)).SetText(sample.getDescription(), TextView.BufferType.Normal);

			return convertView;
		}

	}
}
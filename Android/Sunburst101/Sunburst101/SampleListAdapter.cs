using System.Collections.Generic;
using System.Linq;

using Android.Content;
using Android.Views;
using Android.Widget;

namespace Sunburst101
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
			SampleModel gettingStarted = new SampleModel(context.Resources.GetString(Resource.String.getting_started), context.Resources.GetString(
				Resource.String.getting_started_desc), Resource.Drawable.GettingStarted, typeof(GettingStartedActivity));
            SampleModel groupCollection = new SampleModel(context.Resources.GetString(Resource.String.group_collection), context.Resources.GetString(
                    Resource.String.group_collection_desc), Resource.Drawable.GroupCollection, typeof(GroupCollectionActivity));
            SampleModel basicFeatures = new SampleModel(context.Resources.GetString(Resource.String.basic_features), context.Resources.GetString(
					Resource.String.basic_features_desc), Resource.Drawable.BasicFeatures, typeof(BasicFeaturesActivity));
			SampleModel legendAndTitles = new SampleModel(context.Resources.GetString(Resource.String.legend_and_titles), context.Resources.GetString(
					Resource.String.legend_and_titles_desc), Resource.Drawable.LegendAndTitles, typeof(LegendAndTitlesActivity));
			SampleModel selection = new SampleModel(context.Resources.GetString(Resource.String.selection),
					context.Resources.GetString(Resource.String.selection_desc), Resource.Drawable.Selection, typeof(SelectionActivity));
            SampleModel periodicTable = new SampleModel(context.Resources.GetString(Resource.String.periodictable),
                    context.Resources.GetString(Resource.String.periodictable_desc), Resource.Drawable.Selection, typeof(PeriodicTableActivity));

            // adding objects to list
            list.Add(gettingStarted);
            list.Add(groupCollection);
            list.Add(basicFeatures);
			list.Add(legendAndTitles);
			list.Add(selection);
            list.Add(periodicTable);
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
				convertView = this.mInflater.Inflate(Resource.Layout.custom_list, parent, false);
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
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
using Android.Content.Res;


namespace C1Gauge101
{
    class SampleListAdapter : BaseAdapter
    {
        private List<SampleModel> mList;
        private LayoutInflater mInflater;

        public SampleListAdapter(Context context)
        {
            mList = new List<SampleModel>();
            this.mInflater = LayoutInflater.From(context);

            // initializing SampleModel objects for each sample
            //SampleModel gettingStarted = new SampleModel(context.Resources.GetString(Resource.String.getting_started), context.Resources.GetString(
            //        Resource.String.getting_started_desc), Resource.Drawable.calendar);
            SampleModel gettingStarted = new SampleModel(context.Resources.GetString(Resource.String.getting_started), context.Resources.GetString(
                    Resource.String.getting_started_desc), Resource.Drawable.gauge_basic);
            SampleModel displayingValues = new SampleModel(context.Resources.GetString(Resource.String.displaying_values), context.Resources.GetString(
                    Resource.String.displaying_values_desc), Resource.Drawable.gauge_radial);
            SampleModel usingRanges = new SampleModel(context.Resources.GetString(Resource.String.using_ranges), context.Resources.GetString(
                    Resource.String.using_ranges_desc), Resource.Drawable.gauge_ranges);
            SampleModel automaticScaling = new SampleModel(context.Resources.GetString(Resource.String.automatic_scaling), context.Resources.GetString(
                    Resource.String.automatic_scaling_desc), Resource.Drawable.gauge_scaling);
            SampleModel direction = new SampleModel(context.Resources.GetString(Resource.String.direction),
                    context.Resources.GetString(Resource.String.direction_desc), Resource.Drawable.gauge_linear);
            SampleModel bulletGraph = new SampleModel(context.Resources.GetString(Resource.String.bulletgraph), context.Resources.GetString(
                    Resource.String.bulletgraph_desc), Resource.Drawable.gauge_bullet);
            SampleModel customAnimation = new SampleModel(context.Resources.GetString(Resource.String.custom_animation), context.Resources.GetString(
                    Resource.String.custom_animation_desc), Resource.Drawable.gauge_basic);

            // adding objects to list
            mList.Add(gettingStarted);
            mList.Add(displayingValues);
            mList.Add(usingRanges);
            mList.Add(automaticScaling);
            mList.Add(direction);
            mList.Add(bulletGraph);
            mList.Add(customAnimation);
        }


        public override int Count
        {
            get { return mList.Count(); }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return (Java.Lang.Object)mList.ElementAt(position);
        }



        public override long GetItemId(int position)
        {
            return mList.ElementAt(position).getThumbnailResourceId();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = this.mInflater.Inflate(Resource.Layout.activity_custom_list, parent, false);
            }

            SampleModel sample = mList.ElementAt(position);

            // creating custom view for each list element
            ((ImageView)convertView.FindViewById(Resource.Id.sampleImage)).SetImageResource(sample.getThumbnailResourceId());
            ((TextView)convertView.FindViewById(Resource.Id.sampleName)).SetText(sample.getName(), TextView.BufferType.Normal);
            ((TextView)convertView.FindViewById(Resource.Id.sampleDesc)).SetText(sample.getDescription(), TextView.BufferType.Normal);

            return convertView;
        }

    }
}
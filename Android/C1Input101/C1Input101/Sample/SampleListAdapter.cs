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
using Java.Lang;

namespace C1Input101
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
            SampleModel autocomplete = new SampleModel(context.Resources.GetString(Resource.String.autocomplete), context.Resources.GetString(
                Resource.String.autocomplete_desc), Resource.Drawable.input_autocomplete);
            SampleModel comboBox = new SampleModel(context.Resources.GetString(Resource.String.combobox), context.Resources.GetString(
                Resource.String.combobox_desc), Resource.Drawable.input_combobox);
            SampleModel dropdown = new SampleModel(context.Resources.GetString(Resource.String.dropdown), context.Resources.GetString(
                Resource.String.dropdown_desc), Resource.Drawable.input_dropdown);
            SampleModel basicMask = new SampleModel(context.Resources.GetString(Resource.String.basic_mask), context.Resources.GetString(
                Resource.String.basic_mask_desc), Resource.Drawable.input_mask);

            //// adding objects to list
            mList.Add(autocomplete);
            mList.Add(comboBox);
            mList.Add(dropdown);
            mList.Add(basicMask);
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
            return mList.ElementAt(position).ThumbnailResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = this.mInflater.Inflate(Resource.Layout.activity_custom_list, parent, false);
            }

            SampleModel sample = mList.ElementAt(position);

            // creating custom view for each list element
            ((ImageView)convertView.FindViewById(Resource.Id.sampleImage)).SetImageResource(sample.ThumbnailResourceId);
            ((TextView)convertView.FindViewById(Resource.Id.sampleName)).SetText(sample.Name, TextView.BufferType.Normal);
            ((TextView)convertView.FindViewById(Resource.Id.sampleDesc)).SetText(sample.Description, TextView.BufferType.Normal);

            return convertView;
        }

    }
}
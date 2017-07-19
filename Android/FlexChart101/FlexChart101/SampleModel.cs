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
    class SampleModel:Java.Lang.Object
    {
        private String name;
        private String description;
        private int thumbnailResourceId;
        public Type ActivityType { get; private set; }
        public SampleModel(String name, String description, int thumbnailResourceId, Type activityType)
        {
            this.name = name;
            this.description = description;
            this.thumbnailResourceId = thumbnailResourceId;
            this.ActivityType = activityType;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getDescription()
        {
            return description;
        }

        public void setDescription(String description)
        {
            this.description = description;
        }

        public int getThumbnailResourceId()
        {
            return thumbnailResourceId;
        }

        public void setThumbnailResourceId(int thumbnailResourceId)
        {
            this.thumbnailResourceId = thumbnailResourceId;
        }
    }
}
using System;

namespace C1Input101
{
    public class SampleModel : Java.Lang.Object
    {
        public SampleModel(String name, String description, int thumbnailResourceId)
        {
            Name = name;
            Description = description;
            ThumbnailResourceId = thumbnailResourceId;
        }

        public String Name { get; set; }
        public String Description { get; set; }
        public int ThumbnailResourceId { get; set; }
    }
}
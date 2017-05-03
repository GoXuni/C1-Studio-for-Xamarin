using Xamarin.Forms;

namespace C1Gauge101
{
    public class Sample
    {
        public string Name { get; set; }

        public int SampleViewType { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public ImageSource ThumbnailImageSource
        {
            get
            {
                return ImageSource.FromResource("C1Gauge101.Images." + Thumbnail);
            }
        }
    }
}

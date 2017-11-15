using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sunburst101
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
                return ImageSource.FromResource("Sunburst101.Images." + Thumbnail, typeof(App));
            }
        }
    }
}

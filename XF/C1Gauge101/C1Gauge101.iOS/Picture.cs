using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(C1Gauge101.Picture_iOS))]

namespace C1Gauge101
{
    public class Picture_iOS : IPicture
    {
        async public void SavePictureToDisk(string filename, Task<byte[]> imageData)
        {
            var chartImage = new UIImage(NSData.FromArray(await imageData));
            chartImage.SaveToPhotosAlbum((image, error) =>
            {
                //you can retrieve the saved UI Image as well if needed using
                //var i = image as UIImage;
                if (error != null)
                {
                    Console.WriteLine(error.ToString());
                }
            });
        }
    }
}
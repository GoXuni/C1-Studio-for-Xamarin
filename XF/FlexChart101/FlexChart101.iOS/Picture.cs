using System.Threading.Tasks;
using UIKit;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(FlexChart101.iOS.Picture_iOS))]
namespace FlexChart101.iOS
{
    public class Picture_iOS : IPicture
    {
        async public void SavePictureToDisk(string filename, Task<byte[]> imageData)
        {
            NSData data = NSData.FromArray(await imageData);
            var chartImage = new UIImage(data);
            chartImage.SaveToPhotosAlbum((image, error) =>
            {
                //you can retrieve the saved UI Image as well if needed using
                //var i = image as UIImage;
                if (error != null)
                {
                    System.Diagnostics.Debug.WriteLine(error.ToString());
                }
            });
        }
    }
}

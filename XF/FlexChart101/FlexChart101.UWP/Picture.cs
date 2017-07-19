using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

[assembly: Xamarin.Forms.Dependency(typeof(FlexChart101.UWP.Picture_UWP))]
namespace FlexChart101.UWP
{
    public class Picture_UWP : IPicture
    {
        async public void SavePictureToDisk(string filename, Task<byte[]> imageData)
        {
            string name = filename + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
            StorageFile outputFile = await KnownFolders.SavedPictures.CreateFileAsync(name, CreationCollisionOption.ReplaceExisting);
            var bitmapEncodingMode = BitmapEncoder.PngEncoderId;

            byte[] data = await imageData;
            BitmapImage image = await ByteArrayToBitmapImage(data);

            using (var writeStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                await writeStream.WriteAsync(data.AsBuffer());
            }
        }

        private async Task<BitmapImage> ByteArrayToBitmapImage(byte[] byteArray)
        {
            var bitmapImage = new BitmapImage();

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(byteArray.AsBuffer());
                stream.Seek(0);

                await bitmapImage.SetSourceAsync(stream);
            }

            return bitmapImage;
        }
    }
}

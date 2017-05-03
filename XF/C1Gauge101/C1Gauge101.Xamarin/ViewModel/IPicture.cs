using System.Threading.Tasks;

namespace C1Gauge101
{
    public interface IPicture
    {
        void SavePictureToDisk(string filename, Task<byte[]> imageData);

    }
}

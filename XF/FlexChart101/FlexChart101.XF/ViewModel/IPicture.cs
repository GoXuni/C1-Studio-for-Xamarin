using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChart101
{
    public interface IPicture
    {
        void SavePictureToDisk(string v, Task<byte[]> task);
    }
}

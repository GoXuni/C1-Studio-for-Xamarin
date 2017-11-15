using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Sunburst101.Periodic
{
    class Utils
    {
        public static ElementsCollection DeserializeXml(string path)
        {
            Assembly asm = typeof(PeriodicTable).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream(path))
            {
                using (var reader = new StreamReader(stream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ElementsCollection));
                    return (ElementsCollection)xmlSerializer.Deserialize(reader);
                }
            }
        }
    }
}

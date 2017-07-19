using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace C1Input101
{
    public class Country
    {
        public override string ToString()
        {
            return Name;
        }

        public static readonly string[] Countries = { "Germany", "Japan", "Australia", "Bangladesh", "Brazil", "Canada", "China", "France", "India", "Nepal", "Pakistan", "Srilanka" };
        public string Name { get; set; }
        public static ObservableCollection<Country> GetCountries()
        {
            ObservableCollection<Country> listContries = new ObservableCollection<Country>();

            foreach (var item in Countries)
            {
                listContries.Add(new Country() { Name = item });
            }
            return listContries;
        }
    }
    public class FlagConverter : IValueConverter
    {

        Dictionary<string, ImageSource> flags = new Dictionary<string, ImageSource>();
        public FlagConverter()
        {
            for (int i = 0; i < Country.Countries.Length; i++)
            {
                string strFlag = Country.Countries[i];
                flags.Add(strFlag, ImageSource.FromResource(string.Format("C1Input101.Images.{0}.png", strFlag.ToLower()), typeof(App)));
            }
        }
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return flags[value.ToString()];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
